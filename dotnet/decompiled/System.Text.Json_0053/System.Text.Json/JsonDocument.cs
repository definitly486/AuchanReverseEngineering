using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Text.Json;

public sealed class JsonDocument : IDisposable
{
	private ref struct PropertyNameSet : IDisposable
	{
		[InlineArray(16)]
		private struct InlineRangeArray16
		{
			private (int Start, int Length) _element0;
		}

		private sealed class PropertyNameComparer : IEqualityComparer<ReadOnlyMemory<byte>>
		{
			internal static readonly PropertyNameComparer Instance = new PropertyNameComparer();

			public bool Equals(ReadOnlyMemory<byte> left, ReadOnlyMemory<byte> right)
			{
				if (left.Length == right.Length)
				{
					return left.Span.SequenceEqual(right.Span);
				}
				return false;
			}

			public int GetHashCode(ReadOnlyMemory<byte> name)
			{
				return System.Marvin.ComputeHash32(name.Span, System.Marvin.DefaultSeed);
			}
		}

		private HashSet<ReadOnlyMemory<byte>> _hashSet;

		private int _arraySetCount;

		private bool _useArraySet;

		private InlineRangeArray16 _arraySet;

		public PropertyNameSet()
		{
			_hashSet = null;
			_arraySetCount = 0;
			_arraySet = default(InlineRangeArray16);
			_useArraySet = true;
		}

		internal void SetCapacity(int capacity)
		{
			if (capacity <= 16)
			{
				_useArraySet = true;
				return;
			}
			_useArraySet = false;
			if (_hashSet == null)
			{
				_hashSet = new HashSet<ReadOnlyMemory<byte>>(capacity, PropertyNameComparer.Instance);
			}
			else
			{
				_hashSet.EnsureCapacity(capacity);
			}
		}

		internal void AddPropertyName(JsonProperty property, JsonDocument document)
		{
			DbRow dbRow = document._parsedData.Get(property.Value.MetadataDbIndex - 12);
			ReadOnlyMemory<byte> utf8Json = document._utf8Json;
			ReadOnlyMemory<byte> item = utf8Json.Slice(dbRow.Location, dbRow.SizeOrLength);
			if (dbRow.HasComplexChildren)
			{
				SwitchToHashSet(utf8Json);
				item = JsonReaderHelper.GetUnescaped(item.Span);
			}
			if (_useArraySet)
			{
				for (int i = 0; i < _arraySetCount; i++)
				{
					(int, int) tuple = global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<InlineRangeArray16, (int, int)>(ref _arraySet, 16)[i];
					if (utf8Json.Span.Slice(tuple.Item1, tuple.Item2).SequenceEqual(item.Span))
					{
						ThrowHelper.ThrowJsonException_DuplicatePropertyNotAllowed(item.Span);
					}
				}
				global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<InlineRangeArray16, (int, int)>(ref _arraySet, 16)[_arraySetCount] = (dbRow.Location, dbRow.SizeOrLength);
				_arraySetCount++;
			}
			else if (!_hashSet.Add(item))
			{
				ThrowHelper.ThrowJsonException_DuplicatePropertyNotAllowed(item.Span);
			}
		}

		private void SwitchToHashSet(ReadOnlyMemory<byte> utf8Json)
		{
			if (_useArraySet)
			{
				if (_hashSet == null)
				{
					_hashSet = new HashSet<ReadOnlyMemory<byte>>(16, PropertyNameComparer.Instance);
				}
				for (int i = 0; i < _arraySetCount; i++)
				{
					(int, int) tuple = global::_003CPrivateImplementationDetails_003E.InlineArrayAsSpan<InlineRangeArray16, (int, int)>(ref _arraySet, 16)[i];
					ReadOnlyMemory<byte> item = utf8Json.Slice(tuple.Item1, tuple.Item2);
					_hashSet.Add(item);
				}
				_useArraySet = false;
				_arraySetCount = 0;
			}
		}

		internal void Reset()
		{
			_hashSet?.Clear();
			_arraySetCount = 0;
		}

		public readonly void Dispose()
		{
		}
	}

	internal readonly struct DbRow
	{
		private readonly int _location;

		private readonly int _sizeOrLengthUnion;

		private readonly int _numberOfRowsAndTypeUnion;

		internal int Location => _location;

		internal int SizeOrLength => _sizeOrLengthUnion & 0x7FFFFFFF;

		internal bool IsUnknownSize => _sizeOrLengthUnion == -1;

		internal bool HasComplexChildren => _sizeOrLengthUnion < 0;

		internal int NumberOfRows => _numberOfRowsAndTypeUnion & 0xFFFFFFF;

		internal JsonTokenType TokenType => (JsonTokenType)((uint)_numberOfRowsAndTypeUnion >> 28);

		internal bool IsSimpleValue => (int)TokenType >= 5;

		internal DbRow(JsonTokenType jsonTokenType, int location, int sizeOrLength)
		{
			_location = location;
			_sizeOrLengthUnion = sizeOrLength;
			_numberOfRowsAndTypeUnion = (int)((uint)jsonTokenType << 28);
		}
	}

	private struct MetadataDb : IDisposable
	{
		private byte[] _data;

		private bool _convertToAlloc;

		private bool _isLocked;

		internal int Length { get; private set; }

		private MetadataDb(byte[] initialDb, bool isLocked, bool convertToAlloc)
		{
			_data = initialDb;
			_isLocked = isLocked;
			_convertToAlloc = convertToAlloc;
			Length = 0;
		}

		internal MetadataDb(byte[] completeDb)
		{
			_data = completeDb;
			_isLocked = true;
			_convertToAlloc = false;
			Length = completeDb.Length;
		}

		internal static MetadataDb CreateRented(int payloadLength, bool convertToAlloc)
		{
			int num = payloadLength + 12;
			if (num > 1048576 && num <= 4194304)
			{
				num = 1048576;
			}
			return new MetadataDb(ArrayPool<byte>.Shared.Rent(num), isLocked: false, convertToAlloc);
		}

		internal static MetadataDb CreateLocked(int payloadLength)
		{
			return new MetadataDb(new byte[payloadLength + 12], isLocked: true, convertToAlloc: false);
		}

		public void Dispose()
		{
			byte[] array = Interlocked.Exchange(ref _data, null);
			if (array != null)
			{
				ArrayPool<byte>.Shared.Return(array);
				Length = 0;
			}
		}

		internal void CompleteAllocations()
		{
			if (_isLocked)
			{
				return;
			}
			if (_convertToAlloc)
			{
				byte[] data = _data;
				_data = _data.AsSpan(0, Length).ToArray();
				_isLocked = true;
				_convertToAlloc = false;
				ArrayPool<byte>.Shared.Return(data);
			}
			else if (Length <= _data.Length / 2)
			{
				byte[] array = ArrayPool<byte>.Shared.Rent(Length);
				byte[] array2 = array;
				if (array.Length < _data.Length)
				{
					Buffer.BlockCopy(_data, 0, array, 0, Length);
					array2 = _data;
					_data = array;
				}
				ArrayPool<byte>.Shared.Return(array2);
			}
		}

		internal void Append(JsonTokenType tokenType, int startLocation, int length)
		{
			if (Length >= _data.Length - 12)
			{
				Enlarge();
			}
			DbRow value = new DbRow(tokenType, startLocation, length);
			MemoryMarshal.Write(_data.AsSpan(Length), in value);
			Length += 12;
		}

		private void Enlarge()
		{
			byte[] data = _data;
			int num = data.Length * 2;
			if ((uint)num > 2147483591u)
			{
				num = 2147483591;
			}
			if (num == data.Length)
			{
				num = int.MaxValue;
			}
			_data = ArrayPool<byte>.Shared.Rent(num);
			Buffer.BlockCopy(data, 0, _data, 0, data.Length);
			ArrayPool<byte>.Shared.Return(data);
		}

		internal void SetLength(int index, int length)
		{
			MemoryMarshal.Write(_data.AsSpan(index + 4), in length);
		}

		internal void SetNumberOfRows(int index, int numberOfRows)
		{
			Span<byte> span = _data.AsSpan(index + 8);
			MemoryMarshal.Write<int>(span, (MemoryMarshal.Read<int>(span) & -268435456) | numberOfRows);
		}

		internal void SetHasComplexChildren(int index)
		{
			Span<byte> span = _data.AsSpan(index + 4);
			MemoryMarshal.Write<int>(span, MemoryMarshal.Read<int>(span) | int.MinValue);
		}

		internal int FindIndexOfFirstUnsetSizeOrLength(JsonTokenType lookupType)
		{
			return FindOpenElement(lookupType);
		}

		private int FindOpenElement(JsonTokenType lookupType)
		{
			Span<byte> span = _data.AsSpan(0, Length);
			for (int num = Length - 12; num >= 0; num -= 12)
			{
				DbRow dbRow = MemoryMarshal.Read<DbRow>(span.Slice(num));
				if (dbRow.IsUnknownSize && dbRow.TokenType == lookupType)
				{
					return num;
				}
			}
			return -1;
		}

		internal DbRow Get(int index)
		{
			return MemoryMarshal.Read<DbRow>(_data.AsSpan(index));
		}

		internal JsonTokenType GetJsonTokenType(int index)
		{
			return (JsonTokenType)(MemoryMarshal.Read<uint>(_data.AsSpan(index + 8)) >> 28);
		}

		internal MetadataDb CopySegment(int startIndex, int endIndex)
		{
			DbRow dbRow = Get(startIndex);
			int num = endIndex - startIndex;
			byte[] array = new byte[num];
			_data.AsSpan(startIndex, num).CopyTo(array);
			Span<int> span = MemoryMarshal.Cast<byte, int>(array.AsSpan());
			int num2 = span[0];
			if (dbRow.TokenType == JsonTokenType.String)
			{
				num2--;
			}
			for (int num3 = (num - 12) / 4; num3 >= 0; num3 -= 3)
			{
				span[num3] -= num2;
			}
			return new MetadataDb(array);
		}
	}

	private readonly struct StackRow
	{
		internal readonly int SizeOrLength;

		internal readonly int NumberOfRows;

		internal StackRow(int sizeOrLength = 0, int numberOfRows = -1)
		{
			SizeOrLength = sizeOrLength;
			NumberOfRows = numberOfRows;
		}
	}

	private struct StackRowStack : IDisposable
	{
		private byte[] _rentedBuffer;

		private int _topOfStack;

		public StackRowStack(int initialSize)
		{
			_rentedBuffer = ArrayPool<byte>.Shared.Rent(initialSize);
			_topOfStack = _rentedBuffer.Length;
		}

		public void Dispose()
		{
			byte[] rentedBuffer = _rentedBuffer;
			_rentedBuffer = null;
			_topOfStack = 0;
			if (rentedBuffer != null)
			{
				ArrayPool<byte>.Shared.Return(rentedBuffer);
			}
		}

		internal void Push(StackRow row)
		{
			if (_topOfStack < 8)
			{
				Enlarge();
			}
			_topOfStack -= 8;
			MemoryMarshal.Write(_rentedBuffer.AsSpan(_topOfStack), in row);
		}

		internal StackRow Pop()
		{
			StackRow result = MemoryMarshal.Read<StackRow>(_rentedBuffer.AsSpan(_topOfStack));
			_topOfStack += 8;
			return result;
		}

		private void Enlarge()
		{
			byte[] rentedBuffer = _rentedBuffer;
			_rentedBuffer = ArrayPool<byte>.Shared.Rent(rentedBuffer.Length * 2);
			Buffer.BlockCopy(rentedBuffer, _topOfStack, _rentedBuffer, _rentedBuffer.Length - rentedBuffer.Length + _topOfStack, rentedBuffer.Length - _topOfStack);
			_topOfStack += _rentedBuffer.Length - rentedBuffer.Length;
			ArrayPool<byte>.Shared.Return(rentedBuffer);
		}
	}

	private ReadOnlyMemory<byte> _utf8Json;

	private MetadataDb _parsedData;

	private byte[] _extraRentedArrayPoolBytes;

	private PooledByteBufferWriter _extraPooledByteBufferWriter;

	private static JsonDocument s_nullLiteral;

	private static JsonDocument s_trueLiteral;

	private static JsonDocument s_falseLiteral;

	internal bool IsDisposable { get; }

	public JsonElement RootElement => new JsonElement(this, 0);

	private JsonDocument(ReadOnlyMemory<byte> utf8Json, MetadataDb parsedData, byte[] extraRentedArrayPoolBytes = null, PooledByteBufferWriter extraPooledByteBufferWriter = null, bool isDisposable = true)
	{
		_utf8Json = utf8Json;
		_parsedData = parsedData;
		_extraRentedArrayPoolBytes = extraRentedArrayPoolBytes;
		_extraPooledByteBufferWriter = extraPooledByteBufferWriter;
		IsDisposable = isDisposable;
	}

	public void Dispose()
	{
		int length = _utf8Json.Length;
		if (length == 0 || !IsDisposable)
		{
			return;
		}
		_parsedData.Dispose();
		_utf8Json = ReadOnlyMemory<byte>.Empty;
		if (_extraRentedArrayPoolBytes != null)
		{
			byte[] array = Interlocked.Exchange(ref _extraRentedArrayPoolBytes, null);
			if (array != null)
			{
				array.AsSpan(0, length).Clear();
				ArrayPool<byte>.Shared.Return(array);
			}
		}
		else if (_extraPooledByteBufferWriter != null)
		{
			Interlocked.Exchange(ref _extraPooledByteBufferWriter, null)?.Dispose();
		}
	}

	internal JsonTokenType GetJsonTokenType(int index)
	{
		CheckNotDisposed();
		return _parsedData.GetJsonTokenType(index);
	}

	internal int GetPropertyCount(int index)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(index);
		CheckExpectedType(JsonTokenType.StartObject, dbRow.TokenType);
		return dbRow.SizeOrLength;
	}

	internal int GetEndIndex(int index, bool includeEndElement)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(index);
		if (dbRow.IsSimpleValue)
		{
			return index + 12;
		}
		int num = index + 12 * dbRow.NumberOfRows;
		if (includeEndElement)
		{
			num += 12;
		}
		return num;
	}

	internal ReadOnlyMemory<byte> GetRawValue(int index, bool includeQuotes)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(index);
		if (dbRow.IsSimpleValue)
		{
			if (includeQuotes && dbRow.TokenType == JsonTokenType.String)
			{
				return _utf8Json.Slice(dbRow.Location - 1, dbRow.SizeOrLength + 2);
			}
			return _utf8Json.Slice(dbRow.Location, dbRow.SizeOrLength);
		}
		int endIndex = GetEndIndex(index, includeEndElement: false);
		int location = dbRow.Location;
		dbRow = _parsedData.Get(endIndex);
		return _utf8Json.Slice(location, dbRow.Location - location + dbRow.SizeOrLength);
	}

	private ReadOnlyMemory<byte> GetPropertyRawValue(int valueIndex)
	{
		CheckNotDisposed();
		int num = _parsedData.Get(valueIndex - 12).Location - 1;
		DbRow dbRow = _parsedData.Get(valueIndex);
		int num2;
		if (dbRow.IsSimpleValue)
		{
			num2 = dbRow.Location + dbRow.SizeOrLength;
			if (dbRow.TokenType == JsonTokenType.String)
			{
				num2++;
			}
			return _utf8Json.Slice(num, num2 - num);
		}
		int endIndex = GetEndIndex(valueIndex, includeEndElement: false);
		dbRow = _parsedData.Get(endIndex);
		num2 = dbRow.Location + dbRow.SizeOrLength;
		return _utf8Json.Slice(num, num2 - num);
	}

	internal string GetString(int index, JsonTokenType expectedType)
	{
		CheckNotDisposed();
		DbRow dbRow = _parsedData.Get(index);
		JsonTokenType tokenType = dbRow.TokenType;
		if (tokenType == JsonTokenType.Null)
		{
			return null;
		}
		CheckExpectedType(expectedType, tokenType);
		ReadOnlySpan<byte> readOnlySpan = _utf8Json.Span.Slice(dbRow.Location, dbRow.SizeOrLength);
		if (!dbRow.HasComplexChildren)
		{
			return JsonReaderHelper.TranscodeHelper(readOnlySpan);
		}
		return JsonReaderHelper.GetUnescapedString(readOnlySpan);
	}

	internal string GetRawValueAsString(int index)
	{
		return JsonReaderHelper.TranscodeHelper(GetRawValue(index, includeQuotes: true).Span);
	}

	internal string GetPropertyRawValueAsString(int valueIndex)
	{
		return JsonReaderHelper.TranscodeHelper(GetPropertyRawValue(valueIndex).Span);
	}

	internal JsonElement CloneElement(int index)
	{
		int endIndex = GetEndIndex(index, includeEndElement: true);
		MetadataDb parsedData = _parsedData.CopySegment(index, endIndex);
		return new JsonDocument(GetRawValue(index, includeQuotes: true).ToArray(), parsedData, null, null, isDisposable: false).RootElement;
	}

	private static void Parse(ReadOnlySpan<byte> utf8JsonSpan, JsonReaderOptions readerOptions, ref MetadataDb database, ref StackRowStack stack)
	{
		bool flag = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		Utf8JsonReader utf8JsonReader = new Utf8JsonReader(utf8JsonSpan, isFinalBlock: true, new JsonReaderState(readerOptions));
		while (utf8JsonReader.Read())
		{
			JsonTokenType tokenType = utf8JsonReader.TokenType;
			int num4 = (int)utf8JsonReader.TokenStartIndex;
			switch (tokenType)
			{
			case JsonTokenType.StartObject:
			{
				if (flag)
				{
					num++;
				}
				num3++;
				database.Append(tokenType, num4, -1);
				StackRow row2 = new StackRow(num, num2 + 1);
				stack.Push(row2);
				num = 0;
				num2 = 0;
				break;
			}
			case JsonTokenType.EndObject:
			{
				int index = database.FindIndexOfFirstUnsetSizeOrLength(JsonTokenType.StartObject);
				num3++;
				num2++;
				database.SetLength(index, num);
				int length2 = database.Length;
				database.Append(tokenType, num4, utf8JsonReader.ValueSpan.Length);
				database.SetNumberOfRows(index, num2);
				database.SetNumberOfRows(length2, num2);
				StackRow stackRow2 = stack.Pop();
				num = stackRow2.SizeOrLength;
				num2 += stackRow2.NumberOfRows;
				break;
			}
			case JsonTokenType.StartArray:
			{
				if (flag)
				{
					num++;
				}
				num2++;
				database.Append(tokenType, num4, -1);
				StackRow row = new StackRow(num, num3 + 1);
				stack.Push(row);
				num = 0;
				num3 = 0;
				break;
			}
			case JsonTokenType.EndArray:
			{
				int num5 = database.FindIndexOfFirstUnsetSizeOrLength(JsonTokenType.StartArray);
				num3++;
				num2++;
				database.SetLength(num5, num);
				database.SetNumberOfRows(num5, num3);
				if (num + 1 != num3)
				{
					database.SetHasComplexChildren(num5);
				}
				int length = database.Length;
				database.Append(tokenType, num4, utf8JsonReader.ValueSpan.Length);
				database.SetNumberOfRows(length, num3);
				StackRow stackRow = stack.Pop();
				num = stackRow.SizeOrLength;
				num3 += stackRow.NumberOfRows;
				break;
			}
			case JsonTokenType.PropertyName:
				num3++;
				num2++;
				num++;
				database.Append(tokenType, num4 + 1, utf8JsonReader.ValueSpan.Length);
				if (utf8JsonReader.ValueIsEscaped)
				{
					database.SetHasComplexChildren(database.Length - 12);
				}
				break;
			default:
				num3++;
				num2++;
				if (flag)
				{
					num++;
				}
				if (tokenType == JsonTokenType.String)
				{
					database.Append(tokenType, num4 + 1, utf8JsonReader.ValueSpan.Length);
					if (utf8JsonReader.ValueIsEscaped)
					{
						database.SetHasComplexChildren(database.Length - 12);
					}
				}
				else
				{
					database.Append(tokenType, num4, utf8JsonReader.ValueSpan.Length);
				}
				break;
			}
			flag = utf8JsonReader.IsInArray;
		}
		database.CompleteAllocations();
	}

	private static void ValidateNoDuplicateProperties(JsonDocument document)
	{
		JsonValueKind valueKind = document.RootElement.ValueKind;
		if (valueKind - 1 <= JsonValueKind.Object)
		{
			ValidateDuplicatePropertiesCore(document);
		}
	}

	private static void ValidateDuplicatePropertiesCore(JsonDocument document)
	{
		using PropertyNameSet propertyNameSet = new PropertyNameSet();
		Stack<int> stack = new Stack<int>();
		int? num = null;
		stack.Push(document.RootElement.MetadataDbIndex);
		do
		{
			JsonElement target = new JsonElement(document, stack.Peek());
			switch (target.ValueKind)
			{
			case JsonValueKind.Object:
			{
				JsonElement.ObjectEnumerator objectEnumerator = new JsonElement.ObjectEnumerator(target, num ?? (-1));
				while (true)
				{
					if (objectEnumerator.MoveNext())
					{
						JsonValueKind valueKind = objectEnumerator.Current.Value.ValueKind;
						if (valueKind - 1 <= JsonValueKind.Object)
						{
							stack.Push(objectEnumerator.Current.Value.MetadataDbIndex);
							num = null;
							break;
						}
						continue;
					}
					objectEnumerator.Reset();
					propertyNameSet.SetCapacity(target.GetPropertyCount());
					foreach (JsonProperty item in objectEnumerator)
					{
						propertyNameSet.AddPropertyName(item, document);
					}
					propertyNameSet.Reset();
					num = stack.Pop();
					break;
				}
				break;
			}
			case JsonValueKind.Array:
			{
				JsonElement.ArrayEnumerator arrayEnumerator = new JsonElement.ArrayEnumerator(target, num ?? (-1));
				while (true)
				{
					if (arrayEnumerator.MoveNext())
					{
						JsonValueKind valueKind = arrayEnumerator.Current.ValueKind;
						if (valueKind - 1 <= JsonValueKind.Object)
						{
							stack.Push(arrayEnumerator.Current.MetadataDbIndex);
							num = null;
							break;
						}
						continue;
					}
					num = stack.Pop();
					break;
				}
				break;
			}
			default:
				ThrowHelper.ThrowJsonException();
				break;
			}
		}
		while (stack.Count != 0);
	}

	private void CheckNotDisposed()
	{
		if (_utf8Json.IsEmpty)
		{
			ThrowHelper.ThrowObjectDisposedException_JsonDocument();
		}
	}

	private static void CheckExpectedType(JsonTokenType expected, JsonTokenType actual)
	{
		if (expected != actual)
		{
			ThrowHelper.ThrowJsonElementWrongTypeException(expected, actual);
		}
	}

	private static void CheckSupportedOptions(JsonReaderOptions readerOptions, string paramName)
	{
		if (readerOptions.CommentHandling == JsonCommentHandling.Allow)
		{
			throw new ArgumentException("JsonDocumentDoesNotSupportComments", paramName);
		}
	}

	public static JsonDocument ParseValue(ref Utf8JsonReader reader)
	{
		return ParseValue(ref reader, allowDuplicateProperties: true);
	}

	internal static JsonDocument ParseValue(ref Utf8JsonReader reader, bool allowDuplicateProperties)
	{
		TryParseValue(ref reader, out var document, shouldThrow: true, useArrayPools: true, allowDuplicateProperties);
		return document;
	}

	internal static bool TryParseValue(ref Utf8JsonReader reader, [NotNullWhen(true)] out JsonDocument document, bool shouldThrow, bool useArrayPools, bool allowDuplicateProperties = true)
	{
		JsonReaderState currentState = reader.CurrentState;
		CheckSupportedOptions(currentState.Options, "reader");
		Utf8JsonReader utf8JsonReader = reader;
		ReadOnlySpan<byte> readOnlySpan = default(ReadOnlySpan<byte>);
		ReadOnlySequence<byte> sequence = default(ReadOnlySequence<byte>);
		try
		{
			JsonTokenType tokenType = reader.TokenType;
			if ((tokenType == JsonTokenType.None || tokenType == JsonTokenType.PropertyName) && !reader.Read())
			{
				if (shouldThrow)
				{
					ThrowHelper.ThrowJsonReaderException(ref reader, ExceptionResource.ExpectedJsonTokens, 0);
				}
				reader = utf8JsonReader;
				document = null;
				return false;
			}
			switch (reader.TokenType)
			{
			case JsonTokenType.StartObject:
			case JsonTokenType.StartArray:
			{
				long tokenStartIndex = reader.TokenStartIndex;
				if (!reader.TrySkip())
				{
					if (shouldThrow)
					{
						ThrowHelper.ThrowJsonReaderException(ref reader, ExceptionResource.ExpectedJsonTokens, 0);
					}
					reader = utf8JsonReader;
					document = null;
					return false;
				}
				long num2 = reader.BytesConsumed - tokenStartIndex;
				ReadOnlySequence<byte> originalSequence2 = reader.OriginalSequence;
				if (originalSequence2.IsEmpty)
				{
					readOnlySpan = checked(reader.OriginalSpan.Slice((int)tokenStartIndex, (int)num2));
				}
				else
				{
					sequence = originalSequence2.Slice(tokenStartIndex, num2);
				}
				break;
			}
			case JsonTokenType.True:
			case JsonTokenType.False:
			case JsonTokenType.Null:
				if (useArrayPools)
				{
					if (reader.HasValueSequence)
					{
						sequence = reader.ValueSequence;
					}
					else
					{
						readOnlySpan = reader.ValueSpan;
					}
					break;
				}
				document = CreateForLiteral(reader.TokenType);
				return true;
			case JsonTokenType.Number:
				if (reader.HasValueSequence)
				{
					sequence = reader.ValueSequence;
				}
				else
				{
					readOnlySpan = reader.ValueSpan;
				}
				break;
			case JsonTokenType.String:
			{
				ReadOnlySequence<byte> originalSequence = reader.OriginalSequence;
				if (originalSequence.IsEmpty)
				{
					int length = reader.ValueSpan.Length + 2;
					readOnlySpan = reader.OriginalSpan.Slice((int)reader.TokenStartIndex, length);
				}
				else
				{
					long num = 2L;
					sequence = originalSequence.Slice(length: (!reader.HasValueSequence) ? (num + reader.ValueSpan.Length) : (num + reader.ValueSequence.Length), start: reader.TokenStartIndex);
				}
				break;
			}
			default:
				if (shouldThrow)
				{
					byte nextByte = reader.ValueSpan[0];
					ThrowHelper.ThrowJsonReaderException(ref reader, ExceptionResource.ExpectedStartOfValueNotFound, nextByte);
				}
				reader = utf8JsonReader;
				document = null;
				return false;
			}
		}
		catch
		{
			reader = utf8JsonReader;
			throw;
		}
		int num3 = (readOnlySpan.IsEmpty ? checked((int)sequence.Length) : readOnlySpan.Length);
		if (useArrayPools)
		{
			byte[] array = ArrayPool<byte>.Shared.Rent(num3);
			Span<byte> destination = array.AsSpan(0, num3);
			try
			{
				if (readOnlySpan.IsEmpty)
				{
					sequence.CopyTo(destination);
				}
				else
				{
					readOnlySpan.CopyTo(destination);
				}
				document = Parse(array.AsMemory(0, num3), currentState.Options, array, null, allowDuplicateProperties);
			}
			catch
			{
				destination.Clear();
				ArrayPool<byte>.Shared.Return(array);
				throw;
			}
		}
		else
		{
			byte[] array2 = ((!readOnlySpan.IsEmpty) ? readOnlySpan.ToArray() : BuffersExtensions.ToArray(in sequence));
			document = ParseUnrented(array2, currentState.Options, reader.TokenType, allowDuplicateProperties);
		}
		return true;
	}

	private static JsonDocument CreateForLiteral(JsonTokenType tokenType)
	{
		switch (tokenType)
		{
		case JsonTokenType.False:
			if (s_falseLiteral == null)
			{
				s_falseLiteral = Create(JsonConstants.FalseValue.ToArray());
			}
			return s_falseLiteral;
		case JsonTokenType.True:
			if (s_trueLiteral == null)
			{
				s_trueLiteral = Create(JsonConstants.TrueValue.ToArray());
			}
			return s_trueLiteral;
		default:
			if (s_nullLiteral == null)
			{
				s_nullLiteral = Create(JsonConstants.NullValue.ToArray());
			}
			return s_nullLiteral;
		}
		JsonDocument Create(byte[] utf8Json)
		{
			MetadataDb parsedData = MetadataDb.CreateLocked(utf8Json.Length);
			parsedData.Append(tokenType, 0, utf8Json.Length);
			return new JsonDocument(utf8Json, parsedData, null, null, isDisposable: false);
		}
	}

	private static JsonDocument Parse(ReadOnlyMemory<byte> utf8Json, JsonReaderOptions readerOptions, byte[] extraRentedArrayPoolBytes = null, PooledByteBufferWriter extraPooledByteBufferWriter = null, bool allowDuplicateProperties = true)
	{
		ReadOnlySpan<byte> span = utf8Json.Span;
		MetadataDb database = MetadataDb.CreateRented(utf8Json.Length, convertToAlloc: false);
		StackRowStack stack = new StackRowStack(512);
		JsonDocument jsonDocument;
		try
		{
			Parse(span, readerOptions, ref database, ref stack);
			jsonDocument = new JsonDocument(utf8Json, database, extraRentedArrayPoolBytes, extraPooledByteBufferWriter);
			if (!allowDuplicateProperties)
			{
				ValidateNoDuplicateProperties(jsonDocument);
			}
		}
		catch
		{
			database.Dispose();
			throw;
		}
		finally
		{
			stack.Dispose();
		}
		return jsonDocument;
	}

	private static JsonDocument ParseUnrented(ReadOnlyMemory<byte> utf8Json, JsonReaderOptions readerOptions, JsonTokenType tokenType = JsonTokenType.None, bool allowDuplicateProperties = true)
	{
		ReadOnlySpan<byte> span = utf8Json.Span;
		MetadataDb database;
		if (tokenType == JsonTokenType.String || tokenType == JsonTokenType.Number)
		{
			database = MetadataDb.CreateLocked(utf8Json.Length);
			StackRowStack stack = default(StackRowStack);
			Parse(span, readerOptions, ref database, ref stack);
		}
		else
		{
			database = MetadataDb.CreateRented(utf8Json.Length, convertToAlloc: true);
			StackRowStack stack2 = new StackRowStack(512);
			try
			{
				Parse(span, readerOptions, ref database, ref stack2);
			}
			finally
			{
				stack2.Dispose();
			}
		}
		JsonDocument jsonDocument = new JsonDocument(utf8Json, database, null, null, isDisposable: false);
		if (!allowDuplicateProperties)
		{
			ValidateNoDuplicateProperties(jsonDocument);
		}
		return jsonDocument;
	}
}
