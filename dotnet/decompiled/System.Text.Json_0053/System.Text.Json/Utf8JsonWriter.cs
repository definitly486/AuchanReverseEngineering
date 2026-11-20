using System.Buffers;
using System.Buffers.Text;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Text.Json;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed class Utf8JsonWriter : IDisposable, IAsyncDisposable
{
	[InlineArray(3)]
	private struct Inline3ByteArray
	{
		public byte byte0;
	}

	internal enum EnclosingContainerType : byte
	{
		None = 0,
		Object = 5,
		Array = 16,
		Utf8StringSequence = 32,
		Utf16StringSequence = 48,
		Base64StringSequence = 64
	}

	private IBufferWriter<byte> _output;

	private Stream _stream;

	private ArrayBufferWriter<byte> _arrayBufferWriter;

	private Memory<byte> _memory;

	private EnclosingContainerType _enclosingContainer;

	private bool _commentAfterNoneOrPropertyName;

	private JsonTokenType _tokenType;

	private BitStack _bitStack;

	private Inline3ByteArray _partialStringData;

	private byte _partialStringDataLength;

	private int _currentDepth;

	private JsonWriterOptions _options;

	private byte _indentByte;

	private int _indentLength;

	private int _newLineLength;

	public int BytesPending { get; private set; }

	public long BytesCommitted { get; private set; }

	private int Indentation => CurrentDepth * _indentLength;

	public int CurrentDepth => _currentDepth & 0x7FFFFFFF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string DebuggerDisplay => $"BytesCommitted = {BytesCommitted} BytesPending = {BytesPending} CurrentDepth = {CurrentDepth}";

	private bool IsWritingPartialString => (int)_enclosingContainer >= 32;

	private bool CanWriteValue => (_enclosingContainer == EnclosingContainerType.Array) | ((uint)_enclosingContainer == (uint)_tokenType);

	private Utf8JsonWriter()
	{
	}

	public Utf8JsonWriter(IBufferWriter<byte> bufferWriter, JsonWriterOptions options = default(JsonWriterOptions))
	{
		ArgumentNullException.ThrowIfNull(bufferWriter, "bufferWriter");
		_output = bufferWriter;
		SetOptions(options);
	}

	private void SetOptions(JsonWriterOptions options)
	{
		_options = options;
		_indentByte = (byte)_options.IndentCharacter;
		_indentLength = options.IndentSize;
		_newLineLength = options.NewLine.Length;
		if (_options.MaxDepth == 0)
		{
			_options.MaxDepth = 1000;
		}
	}

	public void Reset()
	{
		CheckNotDisposed();
		_arrayBufferWriter?.Clear();
		ResetHelper();
	}

	internal void ResetAllStateForCacheReuse()
	{
		ResetHelper();
		_stream = null;
		_arrayBufferWriter = null;
		_output = null;
	}

	internal void Reset(IBufferWriter<byte> bufferWriter, JsonWriterOptions options)
	{
		_output = bufferWriter;
		SetOptions(options);
	}

	internal static Utf8JsonWriter CreateEmptyInstanceForCaching()
	{
		return new Utf8JsonWriter();
	}

	private void ResetHelper()
	{
		BytesPending = 0;
		BytesCommitted = 0L;
		_memory = default(Memory<byte>);
		_enclosingContainer = EnclosingContainerType.None;
		_tokenType = JsonTokenType.None;
		_commentAfterNoneOrPropertyName = false;
		_currentDepth = 0;
		_bitStack = default(BitStack);
		_partialStringData = default(Inline3ByteArray);
		_partialStringDataLength = 0;
	}

	private void CheckNotDisposed()
	{
		if (_stream == null && _output == null)
		{
			ThrowHelper.ThrowObjectDisposedException_Utf8JsonWriter();
		}
	}

	public void Flush()
	{
		CheckNotDisposed();
		_memory = default(Memory<byte>);
		if (_stream != null)
		{
			if (BytesPending != 0)
			{
				_arrayBufferWriter.Advance(BytesPending);
				BytesPending = 0;
				_stream.Write(_arrayBufferWriter.WrittenSpan);
				BytesCommitted += _arrayBufferWriter.WrittenCount;
				_arrayBufferWriter.Clear();
			}
			_stream.Flush();
		}
		else if (BytesPending != 0)
		{
			_output.Advance(BytesPending);
			BytesCommitted += BytesPending;
			BytesPending = 0;
		}
	}

	public void Dispose()
	{
		if (_stream != null || _output != null)
		{
			Flush();
			ResetHelper();
			_stream = null;
			_arrayBufferWriter = null;
			_output = null;
		}
	}

	public async ValueTask DisposeAsync()
	{
		if (_stream != null || _output != null)
		{
			await FlushAsync().ConfigureAwait(continueOnCapturedContext: false);
			ResetHelper();
			_stream = null;
			_arrayBufferWriter = null;
			_output = null;
		}
	}

	public async Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		CheckNotDisposed();
		_memory = default(Memory<byte>);
		if (_stream != null)
		{
			if (BytesPending != 0)
			{
				_arrayBufferWriter.Advance(BytesPending);
				BytesPending = 0;
				await _stream.WriteAsync(_arrayBufferWriter.WrittenMemory, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				BytesCommitted += _arrayBufferWriter.WrittenCount;
				_arrayBufferWriter.Clear();
			}
			await _stream.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		else if (BytesPending != 0)
		{
			_output.Advance(BytesPending);
			BytesCommitted += BytesPending;
			BytesPending = 0;
		}
	}

	public void WriteStartObject()
	{
		WriteStart(123);
		_tokenType = JsonTokenType.StartObject;
	}

	private void WriteStart(byte token)
	{
		if (CurrentDepth >= _options.MaxDepth)
		{
			ThrowInvalidOperationException_DepthTooLarge();
		}
		if (_options.IndentedOrNotSkipValidation)
		{
			WriteStartSlow(token);
		}
		else
		{
			WriteStartMinimized(token);
		}
		_currentDepth &= int.MaxValue;
		_currentDepth++;
	}

	private void WriteStartMinimized(byte token)
	{
		if (_memory.Length - BytesPending < 2)
		{
			Grow(2);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = token;
	}

	private void WriteStartSlow(byte token)
	{
		if (_options.Indented)
		{
			if (!_options.SkipValidation)
			{
				ValidateStart();
				UpdateBitStackOnStart(token);
			}
			WriteStartIndented(token);
		}
		else
		{
			ValidateStart();
			UpdateBitStackOnStart(token);
			WriteStartMinimized(token);
		}
	}

	private void ValidateStart()
	{
		if (!CanWriteValue)
		{
			OnValidateStartFailed();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DoesNotReturn]
	private void OnValidateStartFailed()
	{
		if (IsWritingPartialString)
		{
			ThrowInvalidOperationException(ExceptionResource.CannotWriteWithinString);
		}
		if (_enclosingContainer == EnclosingContainerType.Object)
		{
			ThrowInvalidOperationException(ExceptionResource.CannotStartObjectArrayWithoutProperty);
		}
		else
		{
			ThrowInvalidOperationException(ExceptionResource.CannotStartObjectArrayAfterPrimitiveOrClose);
		}
	}

	private void WriteStartIndented(byte token)
	{
		int indentation = Indentation;
		int num = indentation + 1 + 3;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		JsonTokenType tokenType = _tokenType;
		if ((tokenType != JsonTokenType.PropertyName && tokenType != JsonTokenType.None) || _commentAfterNoneOrPropertyName)
		{
			WriteNewLine(span);
			WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		span[BytesPending++] = token;
	}

	public void WriteEndObject()
	{
		WriteEnd(125);
		_tokenType = JsonTokenType.EndObject;
	}

	private void WriteEnd(byte token)
	{
		if (_options.IndentedOrNotSkipValidation)
		{
			WriteEndSlow(token);
		}
		else
		{
			WriteEndMinimized(token);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		if (CurrentDepth != 0)
		{
			_currentDepth--;
		}
	}

	private void WriteEndMinimized(byte token)
	{
		if (_memory.Length - BytesPending < 1)
		{
			Grow(1);
		}
		_memory.Span[BytesPending++] = token;
	}

	private void WriteEndSlow(byte token)
	{
		if (_options.Indented)
		{
			if (!_options.SkipValidation)
			{
				ValidateEnd(token);
			}
			WriteEndIndented(token);
		}
		else
		{
			ValidateEnd(token);
			WriteEndMinimized(token);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ValidateEnd(byte token)
	{
		if (_tokenType == JsonTokenType.PropertyName)
		{
			ThrowInvalidOperationException_MismatchedObjectArray(token);
		}
		if (token == 93)
		{
			if (_enclosingContainer != EnclosingContainerType.Array)
			{
				ThrowInvalidOperationException_MismatchedObjectArray(token);
			}
		}
		else if (_enclosingContainer != EnclosingContainerType.Object)
		{
			ThrowInvalidOperationException_MismatchedObjectArray(token);
		}
		EnclosingContainerType enclosingContainerType = (_bitStack.Pop() ? EnclosingContainerType.Object : EnclosingContainerType.Array);
		_enclosingContainer = ((_bitStack.CurrentDepth != 0) ? enclosingContainerType : EnclosingContainerType.None);
	}

	private void WriteEndIndented(byte token)
	{
		if (_tokenType == JsonTokenType.StartObject || _tokenType == JsonTokenType.StartArray)
		{
			WriteEndMinimized(token);
			return;
		}
		int num = Indentation;
		if (num != 0)
		{
			num -= _indentLength;
		}
		int num2 = num + 3;
		if (_memory.Length - BytesPending < num2)
		{
			Grow(num2);
		}
		Span<byte> span = _memory.Span;
		WriteNewLine(span);
		WriteIndentation(span.Slice(BytesPending), num);
		BytesPending += num;
		span[BytesPending++] = token;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void WriteNewLine(Span<byte> output)
	{
		if (_newLineLength == 2)
		{
			output[BytesPending++] = 13;
		}
		output[BytesPending++] = 10;
	}

	private void WriteIndentation(Span<byte> buffer, int indent)
	{
		JsonWriterHelper.WriteIndentation(buffer, indent, _indentByte);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void UpdateBitStackOnStart(byte token)
	{
		if (token == 91)
		{
			_bitStack.PushFalse();
			_enclosingContainer = EnclosingContainerType.Array;
		}
		else
		{
			_bitStack.PushTrue();
			_enclosingContainer = EnclosingContainerType.Object;
		}
	}

	private void Grow(int requiredSize)
	{
		if (_memory.Length == 0)
		{
			FirstCallToGetMemory(requiredSize);
			return;
		}
		int num = Math.Max(4096, requiredSize);
		if (_stream != null)
		{
			int num2 = BytesPending + num;
			JsonHelpers.ValidateInt32MaxArrayLength((uint)num2);
			_memory = _arrayBufferWriter.GetMemory(num2);
			return;
		}
		_output.Advance(BytesPending);
		BytesCommitted += BytesPending;
		BytesPending = 0;
		_memory = _output.GetMemory(num);
		if (_memory.Length < num)
		{
			ThrowHelper.ThrowInvalidOperationException_NeedLargerSpan();
		}
	}

	private void FirstCallToGetMemory(int requiredSize)
	{
		int num = Math.Max(256, requiredSize);
		if (_stream != null)
		{
			_memory = _arrayBufferWriter.GetMemory(num);
			return;
		}
		_memory = _output.GetMemory(num);
		if (_memory.Length < num)
		{
			ThrowHelper.ThrowInvalidOperationException_NeedLargerSpan();
		}
	}

	private void SetFlagToAddListSeparatorBeforeNextItem()
	{
		_currentDepth |= int.MinValue;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DoesNotReturn]
	private void ThrowInvalidOperationException(ExceptionResource resource)
	{
		ThrowHelper.ThrowInvalidOperationException(resource, 0, _options.MaxDepth, 0, _tokenType);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DoesNotReturn]
	private void ThrowInvalidOperationException_MismatchedObjectArray(byte token)
	{
		ThrowHelper.ThrowInvalidOperationException(ExceptionResource.MismatchedObjectArray, 0, _options.MaxDepth, token, _tokenType);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DoesNotReturn]
	private void ThrowInvalidOperationException_DepthTooLarge()
	{
		ThrowHelper.ThrowInvalidOperationException(ExceptionResource.DepthTooLarge, _currentDepth, _options.MaxDepth, 0, JsonTokenType.None);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void ValidateWritingProperty()
	{
		if (!_options.SkipValidation && (_enclosingContainer != EnclosingContainerType.Object || _tokenType == JsonTokenType.PropertyName))
		{
			OnValidateWritingPropertyFailed();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DoesNotReturn]
	private void OnValidateWritingPropertyFailed()
	{
		if (IsWritingPartialString)
		{
			ThrowInvalidOperationException(ExceptionResource.CannotWriteWithinString);
		}
		ThrowInvalidOperationException(ExceptionResource.CannotWritePropertyWithinArray);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void TranscodeAndWrite(ReadOnlySpan<char> escapedPropertyName, Span<byte> output)
	{
		JsonWriterHelper.ToUtf8(escapedPropertyName, output.Slice(BytesPending), out var written);
		BytesPending += written;
	}

	public void WriteNull(JsonEncodedText propertyName)
	{
		WriteLiteralHelper(propertyName.EncodedUtf8Bytes, JsonConstants.NullValue);
		_tokenType = JsonTokenType.Null;
	}

	internal void WriteNullSection(ReadOnlySpan<byte> escapedPropertyNameSection)
	{
		if (_options.Indented)
		{
			ReadOnlySpan<byte> utf8PropertyName = escapedPropertyNameSection.Slice(1, escapedPropertyNameSection.Length - 3);
			WriteLiteralHelper(utf8PropertyName, JsonConstants.NullValue);
			_tokenType = JsonTokenType.Null;
		}
		else
		{
			ReadOnlySpan<byte> nullValue = JsonConstants.NullValue;
			WriteLiteralSection(escapedPropertyNameSection, nullValue);
			SetFlagToAddListSeparatorBeforeNextItem();
			_tokenType = JsonTokenType.Null;
		}
	}

	private void WriteLiteralHelper(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> value)
	{
		WriteLiteralByOptions(utf8PropertyName, value);
		SetFlagToAddListSeparatorBeforeNextItem();
	}

	public void WriteBoolean(JsonEncodedText propertyName, bool value)
	{
		if (value)
		{
			WriteLiteralHelper(propertyName.EncodedUtf8Bytes, JsonConstants.TrueValue);
			_tokenType = JsonTokenType.True;
		}
		else
		{
			WriteLiteralHelper(propertyName.EncodedUtf8Bytes, JsonConstants.FalseValue);
			_tokenType = JsonTokenType.False;
		}
	}

	private void WriteLiteralByOptions(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<byte> value)
	{
		ValidateWritingProperty();
		if (_options.Indented)
		{
			WriteLiteralIndented(utf8PropertyName, value);
		}
		else
		{
			WriteLiteralMinimized(utf8PropertyName, value);
		}
	}

	private void WriteLiteralMinimized(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<byte> value)
	{
		int num = escapedPropertyName.Length + value.Length + 3 + 1;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		escapedPropertyName.CopyTo(span.Slice(BytesPending));
		BytesPending += escapedPropertyName.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		value.CopyTo(span.Slice(BytesPending));
		BytesPending += value.Length;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void WriteLiteralSection(ReadOnlySpan<byte> escapedPropertyNameSection, ReadOnlySpan<byte> value)
	{
		int num = escapedPropertyNameSection.Length + value.Length + 1;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		escapedPropertyNameSection.CopyTo(span.Slice(BytesPending));
		BytesPending += escapedPropertyNameSection.Length;
		value.CopyTo(span.Slice(BytesPending));
		BytesPending += value.Length;
	}

	private void WriteLiteralIndented(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<byte> value)
	{
		int indentation = Indentation;
		int num = indentation + escapedPropertyName.Length + value.Length + 4 + 1 + _newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.None)
		{
			WriteNewLine(span);
		}
		WriteIndentation(span.Slice(BytesPending), indentation);
		BytesPending += indentation;
		span[BytesPending++] = 34;
		escapedPropertyName.CopyTo(span.Slice(BytesPending));
		BytesPending += escapedPropertyName.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 32;
		value.CopyTo(span.Slice(BytesPending));
		BytesPending += value.Length;
	}

	public void WriteNumber(JsonEncodedText propertyName, long value)
	{
		ReadOnlySpan<byte> encodedUtf8Bytes = propertyName.EncodedUtf8Bytes;
		WriteNumberByOptions(encodedUtf8Bytes, value);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Number;
	}

	public void WriteNumber(JsonEncodedText propertyName, int value)
	{
		WriteNumber(propertyName, (long)value);
	}

	private void WriteNumberByOptions(ReadOnlySpan<byte> utf8PropertyName, long value)
	{
		ValidateWritingProperty();
		if (_options.Indented)
		{
			WriteNumberIndented(utf8PropertyName, value);
		}
		else
		{
			WriteNumberMinimized(utf8PropertyName, value);
		}
	}

	private void WriteNumberMinimized(ReadOnlySpan<byte> escapedPropertyName, long value)
	{
		int num = escapedPropertyName.Length + 20 + 3 + 1;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		escapedPropertyName.CopyTo(span.Slice(BytesPending));
		BytesPending += escapedPropertyName.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out var bytesWritten);
		BytesPending += bytesWritten;
	}

	private void WriteNumberIndented(ReadOnlySpan<byte> escapedPropertyName, long value)
	{
		int indentation = Indentation;
		int num = indentation + escapedPropertyName.Length + 20 + 4 + 1 + _newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.None)
		{
			WriteNewLine(span);
		}
		WriteIndentation(span.Slice(BytesPending), indentation);
		BytesPending += indentation;
		span[BytesPending++] = 34;
		escapedPropertyName.CopyTo(span.Slice(BytesPending));
		BytesPending += escapedPropertyName.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 32;
		Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out var bytesWritten);
		BytesPending += bytesWritten;
	}

	public void WritePropertyName(JsonEncodedText propertyName)
	{
		WritePropertyNameHelper(propertyName.EncodedUtf8Bytes);
	}

	internal void WritePropertyNameSection(ReadOnlySpan<byte> escapedPropertyNameSection)
	{
		if (_options.Indented)
		{
			ReadOnlySpan<byte> utf8PropertyName = escapedPropertyNameSection.Slice(1, escapedPropertyNameSection.Length - 3);
			WritePropertyNameHelper(utf8PropertyName);
			return;
		}
		WriteStringPropertyNameSection(escapedPropertyNameSection);
		_currentDepth &= int.MaxValue;
		_tokenType = JsonTokenType.PropertyName;
		_commentAfterNoneOrPropertyName = false;
	}

	private void WritePropertyNameHelper(ReadOnlySpan<byte> utf8PropertyName)
	{
		WriteStringByOptionsPropertyName(utf8PropertyName);
		_currentDepth &= int.MaxValue;
		_tokenType = JsonTokenType.PropertyName;
		_commentAfterNoneOrPropertyName = false;
	}

	private void WriteStringByOptionsPropertyName(ReadOnlySpan<byte> utf8PropertyName)
	{
		ValidateWritingProperty();
		if (_options.Indented)
		{
			WriteStringIndentedPropertyName(utf8PropertyName);
		}
		else
		{
			WriteStringMinimizedPropertyName(utf8PropertyName);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void WriteStringMinimizedPropertyName(ReadOnlySpan<byte> escapedPropertyName)
	{
		int num = escapedPropertyName.Length + 3 + 1;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		escapedPropertyName.CopyTo(span.Slice(BytesPending));
		BytesPending += escapedPropertyName.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void WriteStringPropertyNameSection(ReadOnlySpan<byte> escapedPropertyNameSection)
	{
		int num = escapedPropertyNameSection.Length + 1;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		escapedPropertyNameSection.CopyTo(span.Slice(BytesPending));
		BytesPending += escapedPropertyNameSection.Length;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void WriteStringIndentedPropertyName(ReadOnlySpan<byte> escapedPropertyName)
	{
		int indentation = Indentation;
		int num = indentation + escapedPropertyName.Length + 4 + 1 + _newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.None)
		{
			WriteNewLine(span);
		}
		WriteIndentation(span.Slice(BytesPending), indentation);
		BytesPending += indentation;
		span[BytesPending++] = 34;
		escapedPropertyName.CopyTo(span.Slice(BytesPending));
		BytesPending += escapedPropertyName.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 32;
	}

	public void WriteString(JsonEncodedText propertyName, string? value)
	{
		if (value == null)
		{
			WriteNull(propertyName);
		}
		else
		{
			WriteString(propertyName, value.AsSpan());
		}
	}

	public void WriteString(JsonEncodedText propertyName, ReadOnlySpan<char> value)
	{
		WriteStringHelperEscapeValue(propertyName.EncodedUtf8Bytes, value);
	}

	private void WriteStringHelperEscapeValue(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<char> value)
	{
		JsonWriterHelper.ValidateValue(value);
		int num = JsonWriterHelper.NeedsEscaping(value, _options.Encoder);
		if (num != -1)
		{
			WriteStringEscapeValueOnly(utf8PropertyName, value, num);
		}
		else
		{
			WriteStringByOptions(utf8PropertyName, value);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.String;
	}

	private void WriteStringEscapeValueOnly(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<char> value, int firstEscapeIndex)
	{
		char[] array = null;
		int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(value.Length, firstEscapeIndex);
		Span<char> span = ((maxEscapedLength > 128) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[128]);
		Span<char> destination = span;
		JsonWriterHelper.EscapeString(value, destination, firstEscapeIndex, _options.Encoder, out var written);
		WriteStringByOptions(escapedPropertyName, destination.Slice(0, written));
		if (array != null)
		{
			ArrayPool<char>.Shared.Return(array);
		}
	}

	private void WriteStringByOptions(ReadOnlySpan<byte> utf8PropertyName, ReadOnlySpan<char> value)
	{
		ValidateWritingProperty();
		if (_options.Indented)
		{
			WriteStringIndented(utf8PropertyName, value);
		}
		else
		{
			WriteStringMinimized(utf8PropertyName, value);
		}
	}

	private void WriteStringMinimized(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<char> escapedValue)
	{
		int num = escapedValue.Length * 3 + escapedPropertyName.Length + 6;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		escapedPropertyName.CopyTo(span.Slice(BytesPending));
		BytesPending += escapedPropertyName.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 34;
		TranscodeAndWrite(escapedValue, span);
		span[BytesPending++] = 34;
	}

	private void WriteStringIndented(ReadOnlySpan<byte> escapedPropertyName, ReadOnlySpan<char> escapedValue)
	{
		int indentation = Indentation;
		int num = indentation + escapedValue.Length * 3 + escapedPropertyName.Length + 7 + _newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.None)
		{
			WriteNewLine(span);
		}
		WriteIndentation(span.Slice(BytesPending), indentation);
		BytesPending += indentation;
		span[BytesPending++] = 34;
		escapedPropertyName.CopyTo(span.Slice(BytesPending));
		BytesPending += escapedPropertyName.Length;
		span[BytesPending++] = 34;
		span[BytesPending++] = 58;
		span[BytesPending++] = 32;
		span[BytesPending++] = 34;
		TranscodeAndWrite(escapedValue, span);
		span[BytesPending++] = 34;
	}

	private void ValidateWritingValue()
	{
		if (!CanWriteValue)
		{
			OnValidateWritingValueFailed();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DoesNotReturn]
	private void OnValidateWritingValueFailed()
	{
		if (IsWritingPartialString)
		{
			ThrowInvalidOperationException(ExceptionResource.CannotWriteWithinString);
		}
		if (_enclosingContainer == EnclosingContainerType.Object)
		{
			ThrowInvalidOperationException(ExceptionResource.CannotWriteValueWithinObject);
		}
		else
		{
			ThrowInvalidOperationException(ExceptionResource.CannotWriteValueAfterPrimitiveOrClose);
		}
	}

	public void WriteNullValue()
	{
		WriteLiteralByOptions(JsonConstants.NullValue);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Null;
	}

	public void WriteBooleanValue(bool value)
	{
		if (value)
		{
			WriteLiteralByOptions(JsonConstants.TrueValue);
			_tokenType = JsonTokenType.True;
		}
		else
		{
			WriteLiteralByOptions(JsonConstants.FalseValue);
			_tokenType = JsonTokenType.False;
		}
		SetFlagToAddListSeparatorBeforeNextItem();
	}

	private void WriteLiteralByOptions(ReadOnlySpan<byte> utf8Value)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteLiteralIndented(utf8Value);
		}
		else
		{
			WriteLiteralMinimized(utf8Value);
		}
	}

	private void WriteLiteralMinimized(ReadOnlySpan<byte> utf8Value)
	{
		int num = utf8Value.Length + 1;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		utf8Value.CopyTo(span.Slice(BytesPending));
		BytesPending += utf8Value.Length;
	}

	private void WriteLiteralIndented(ReadOnlySpan<byte> utf8Value)
	{
		int indentation = Indentation;
		int num = indentation + utf8Value.Length + 1 + _newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		utf8Value.CopyTo(span.Slice(BytesPending));
		BytesPending += utf8Value.Length;
	}

	public void WriteNumberValue(long value)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteNumberValueIndented(value);
		}
		else
		{
			WriteNumberValueMinimized(value);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Number;
	}

	private void WriteNumberValueMinimized(long value)
	{
		int num = 21;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out var bytesWritten);
		BytesPending += bytesWritten;
	}

	private void WriteNumberValueIndented(long value)
	{
		int indentation = Indentation;
		int num = indentation + 20 + 1 + _newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out var bytesWritten);
		BytesPending += bytesWritten;
	}

	internal void WriteNumberValueAsString(long value)
	{
		Span<byte> destination = stackalloc byte[20];
		Utf8Formatter.TryFormat(value, destination, out var bytesWritten);
		WriteNumberValueAsStringUnescaped(destination.Slice(0, bytesWritten));
	}

	public void WriteStringValue(JsonEncodedText value)
	{
		ReadOnlySpan<byte> encodedUtf8Bytes = value.EncodedUtf8Bytes;
		WriteStringByOptions(encodedUtf8Bytes);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.String;
	}

	public void WriteStringValue(string? value)
	{
		if (value == null)
		{
			WriteNullValue();
		}
		else
		{
			WriteStringValue(value.AsSpan());
		}
	}

	public void WriteStringValue(ReadOnlySpan<char> value)
	{
		JsonWriterHelper.ValidateValue(value);
		WriteStringEscape(value);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.String;
	}

	private void WriteStringEscape(ReadOnlySpan<char> value)
	{
		int num = JsonWriterHelper.NeedsEscaping(value, _options.Encoder);
		if (num != -1)
		{
			WriteStringEscapeValue(value, num);
		}
		else
		{
			WriteStringByOptions(value);
		}
	}

	private void WriteStringByOptions(ReadOnlySpan<char> value)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteStringIndented(value);
		}
		else
		{
			WriteStringMinimized(value);
		}
	}

	private void WriteStringMinimized(ReadOnlySpan<char> escapedValue)
	{
		int num = escapedValue.Length * 3 + 3;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		TranscodeAndWrite(escapedValue, span);
		span[BytesPending++] = 34;
	}

	private void WriteStringIndented(ReadOnlySpan<char> escapedValue)
	{
		int indentation = Indentation;
		int num = indentation + escapedValue.Length * 3 + 3 + _newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		span[BytesPending++] = 34;
		TranscodeAndWrite(escapedValue, span);
		span[BytesPending++] = 34;
	}

	private void WriteStringEscapeValue(ReadOnlySpan<char> value, int firstEscapeIndexVal)
	{
		char[] array = null;
		int maxEscapedLength = JsonWriterHelper.GetMaxEscapedLength(value.Length, firstEscapeIndexVal);
		Span<char> span = ((maxEscapedLength > 128) ? ((Span<char>)(array = ArrayPool<char>.Shared.Rent(maxEscapedLength))) : stackalloc char[128]);
		Span<char> destination = span;
		JsonWriterHelper.EscapeString(value, destination, firstEscapeIndexVal, _options.Encoder, out var written);
		WriteStringByOptions(destination.Slice(0, written));
		if (array != null)
		{
			ArrayPool<char>.Shared.Return(array);
		}
	}

	private void WriteStringByOptions(ReadOnlySpan<byte> utf8Value)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteStringIndented(utf8Value);
		}
		else
		{
			WriteStringMinimized(utf8Value);
		}
	}

	private void WriteStringMinimized(ReadOnlySpan<byte> escapedValue)
	{
		int num = escapedValue.Length + 2 + 1;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		span[BytesPending++] = 34;
		escapedValue.CopyTo(span.Slice(BytesPending));
		BytesPending += escapedValue.Length;
		span[BytesPending++] = 34;
	}

	private void WriteStringIndented(ReadOnlySpan<byte> escapedValue)
	{
		int indentation = Indentation;
		int num = indentation + escapedValue.Length + 2 + 1 + _newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		span[BytesPending++] = 34;
		escapedValue.CopyTo(span.Slice(BytesPending));
		BytesPending += escapedValue.Length;
		span[BytesPending++] = 34;
	}

	internal void WriteNumberValueAsStringUnescaped(ReadOnlySpan<byte> utf8Value)
	{
		WriteStringByOptions(utf8Value);
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.String;
	}

	[CLSCompliant(false)]
	public void WriteNumberValue(ulong value)
	{
		if (!_options.SkipValidation)
		{
			ValidateWritingValue();
		}
		if (_options.Indented)
		{
			WriteNumberValueIndented(value);
		}
		else
		{
			WriteNumberValueMinimized(value);
		}
		SetFlagToAddListSeparatorBeforeNextItem();
		_tokenType = JsonTokenType.Number;
	}

	private void WriteNumberValueMinimized(ulong value)
	{
		int num = 21;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out var bytesWritten);
		BytesPending += bytesWritten;
	}

	private void WriteNumberValueIndented(ulong value)
	{
		int indentation = Indentation;
		int num = indentation + 20 + 1 + _newLineLength;
		if (_memory.Length - BytesPending < num)
		{
			Grow(num);
		}
		Span<byte> span = _memory.Span;
		if (_currentDepth < 0)
		{
			span[BytesPending++] = 44;
		}
		if (_tokenType != JsonTokenType.PropertyName)
		{
			if (_tokenType != JsonTokenType.None)
			{
				WriteNewLine(span);
			}
			WriteIndentation(span.Slice(BytesPending), indentation);
			BytesPending += indentation;
		}
		Utf8Formatter.TryFormat(value, span.Slice(BytesPending), out var bytesWritten);
		BytesPending += bytesWritten;
	}
}
