using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson.Utilities;

namespace Newtonsoft.Json.Bson;

public class BsonDataReader : JsonReader
{
	private enum BsonReaderState
	{
		Normal,
		ReferenceStart,
		ReferenceRef,
		ReferenceId,
		CodeWScopeStart,
		CodeWScopeCode,
		CodeWScopeScope,
		CodeWScopeScopeObject,
		CodeWScopeScopeEnd
	}

	private class ContainerContext
	{
		public readonly Newtonsoft.Json.Bson.BsonType Type;

		public int Length;

		public int Position;

		public ContainerContext(Newtonsoft.Json.Bson.BsonType type)
		{
			Type = type;
		}
	}

	private readonly AsyncBinaryReader _asyncReader;

	private static readonly byte[] SeqRange1 = new byte[2] { 0, 127 };

	private static readonly byte[] SeqRange2 = new byte[2] { 194, 223 };

	private static readonly byte[] SeqRange3 = new byte[2] { 224, 239 };

	private static readonly byte[] SeqRange4 = new byte[2] { 240, 244 };

	private readonly BinaryReader _reader;

	private readonly List<ContainerContext> _stack;

	private byte[] _byteBuffer;

	private char[] _charBuffer;

	private Newtonsoft.Json.Bson.BsonType _currentElementType;

	private BsonReaderState _bsonReaderState;

	private ContainerContext _currentContext;

	private bool _readRootValueAsArray;

	private bool _jsonNet35BinaryCompatibility;

	private DateTimeKind _dateTimeKindHandling;

	public DateTimeKind DateTimeKindHandling
	{
		get
		{
			return _dateTimeKindHandling;
		}
		set
		{
			_dateTimeKindHandling = value;
		}
	}

	private Task<string> ReadElementAsync(CancellationToken cancellationToken)
	{
		Task<Newtonsoft.Json.Bson.BsonType> task = ReadTypeAsync(cancellationToken);
		if (task.Status == TaskStatus.RanToCompletion)
		{
			_currentElementType = task.Result;
			return ReadStringAsync(cancellationToken);
		}
		return ReadElementAsync(task, cancellationToken);
	}

	private async Task<string> ReadElementAsync(Task<Newtonsoft.Json.Bson.BsonType> typeReadTask, CancellationToken cancellationToken)
	{
		_currentElementType = await typeReadTask.ConfigureAwait(continueOnCapturedContext: false);
		return await ReadStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	public override Task<bool> ReadAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		Task<bool> task;
		switch (_bsonReaderState)
		{
		case BsonReaderState.Normal:
			task = ReadNormalAsync(cancellationToken);
			break;
		case BsonReaderState.ReferenceStart:
		case BsonReaderState.ReferenceRef:
		case BsonReaderState.ReferenceId:
			task = ReadReferenceAsync(cancellationToken);
			break;
		case BsonReaderState.CodeWScopeStart:
		case BsonReaderState.CodeWScopeCode:
		case BsonReaderState.CodeWScopeScope:
		case BsonReaderState.CodeWScopeScopeObject:
		case BsonReaderState.CodeWScopeScopeEnd:
			task = ReadCodeWScopeAsync(cancellationToken);
			break;
		default:
			throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected state: {0}".FormatWith(CultureInfo.InvariantCulture, _bsonReaderState));
		}
		if (task.Status == TaskStatus.RanToCompletion)
		{
			if (!task.Result)
			{
				SetToken(JsonToken.None);
			}
			return task;
		}
		return ReadCatchingEndOfStreamAsync(task);
	}

	private async Task<bool> ReadCatchingEndOfStreamAsync(Task<bool> task)
	{
		try
		{
			if (await task.ConfigureAwait(continueOnCapturedContext: false))
			{
				return true;
			}
		}
		catch (EndOfStreamException)
		{
		}
		SetToken(JsonToken.None);
		return false;
	}

	private async Task<bool> ReadCodeWScopeCodeAsync(CancellationToken cancellationToken)
	{
		await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		SetToken(JsonToken.String, await ReadLengthStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
		_bsonReaderState = BsonReaderState.CodeWScopeScope;
		return true;
	}

	private async Task<bool> ReadCodeWScopeScopeAsync(CancellationToken cancellationToken)
	{
		SetToken(JsonToken.StartObject);
		_bsonReaderState = BsonReaderState.CodeWScopeScopeObject;
		ContainerContext containerContext = new ContainerContext(Newtonsoft.Json.Bson.BsonType.Object);
		PushContext(containerContext);
		ContainerContext containerContext2 = containerContext;
		containerContext2.Length = await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		return true;
	}

	private async Task<bool> ReadCodeWScopeScopeObjectAsync(CancellationToken cancellationToken)
	{
		bool num = await ReadNormalAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		if (num && TokenType == JsonToken.EndObject)
		{
			_bsonReaderState = BsonReaderState.CodeWScopeScopeEnd;
		}
		return num;
	}

	private Task<bool> ReadCodeWScopeAsync(CancellationToken cancellationToken)
	{
		switch (_bsonReaderState)
		{
		case BsonReaderState.CodeWScopeCode:
			return ReadCodeWScopeCodeAsync(cancellationToken);
		case BsonReaderState.CodeWScopeScope:
			if (base.CurrentState != State.PostValue)
			{
				return ReadCodeWScopeScopeAsync(cancellationToken);
			}
			break;
		case BsonReaderState.CodeWScopeScopeObject:
			return ReadCodeWScopeScopeObjectAsync(cancellationToken);
		default:
			throw new ArgumentOutOfRangeException();
		case BsonReaderState.CodeWScopeStart:
		case BsonReaderState.CodeWScopeScopeEnd:
			break;
		}
		ReadCodeWScope();
		return AsyncUtils.True;
	}

	private async Task<bool> ReadPropertyReferenceAsync(CancellationToken cancellationToken)
	{
		switch (_bsonReaderState)
		{
		case BsonReaderState.ReferenceRef:
			SetToken(JsonToken.String, await ReadLengthStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			return true;
		case BsonReaderState.ReferenceId:
			SetToken(JsonToken.Bytes, await ReadBytesAsync(12, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			return true;
		default:
			throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected state when reading BSON reference: " + _bsonReaderState);
		}
	}

	private Task<bool> ReadReferenceAsync(CancellationToken cancellationToken)
	{
		if (base.CurrentState == State.Property)
		{
			return ReadPropertyReferenceAsync(cancellationToken);
		}
		ReadReference();
		return AsyncUtils.True;
	}

	private async Task<bool> ReadNormalStartAsync(CancellationToken cancellationToken)
	{
		JsonToken token = ((!_readRootValueAsArray) ? JsonToken.StartObject : JsonToken.StartArray);
		Newtonsoft.Json.Bson.BsonType type = ((!_readRootValueAsArray) ? Newtonsoft.Json.Bson.BsonType.Object : Newtonsoft.Json.Bson.BsonType.Array);
		SetToken(token);
		ContainerContext containerContext = new ContainerContext(type);
		PushContext(containerContext);
		ContainerContext containerContext2 = containerContext;
		containerContext2.Length = await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		return true;
	}

	private async Task<bool> ReadNormalPropertyAsync(CancellationToken cancellationToken)
	{
		await ReadTypeAsync(_currentElementType, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		return true;
	}

	private async Task<bool> ReadNormalPostValueAsync(ContainerContext context, CancellationToken cancellationToken)
	{
		int num = context.Length - 1;
		if (context.Position < num)
		{
			if (context.Type == Newtonsoft.Json.Bson.BsonType.Array)
			{
				await ReadElementAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				await ReadTypeAsync(_currentElementType, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				SetToken(JsonToken.PropertyName, await ReadElementAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			}
		}
		else
		{
			if (context.Position != num)
			{
				throw ExceptionUtils.CreateJsonReaderException(this, "Read past end of current container context.");
			}
			if (await ReadByteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false) != 0)
			{
				throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected end of object byte value.");
			}
			PopContext();
			if (_currentContext != null)
			{
				MovePosition(context.Length);
			}
			SetToken((context.Type == Newtonsoft.Json.Bson.BsonType.Object) ? JsonToken.EndObject : JsonToken.EndArray);
		}
		return true;
	}

	private Task<bool> ReadNormalAsync(CancellationToken cancellationToken)
	{
		switch (base.CurrentState)
		{
		case State.Start:
			return ReadNormalStartAsync(cancellationToken);
		case State.Property:
			return ReadNormalPropertyAsync(cancellationToken);
		case State.ObjectStart:
		case State.ArrayStart:
		case State.PostValue:
		{
			ContainerContext currentContext = _currentContext;
			if (currentContext != null)
			{
				return ReadNormalPostValueAsync(currentContext, cancellationToken);
			}
			return AsyncUtils.False;
		}
		case State.Complete:
		case State.Closed:
		case State.ConstructorStart:
		case State.Constructor:
		case State.Error:
		case State.Finished:
			return AsyncUtils.False;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private Task<byte> ReadByteAsync(CancellationToken cancellationToken)
	{
		MovePosition(1);
		return _asyncReader.ReadByteAsync(cancellationToken);
	}

	private Task ReadTypeAsync(Newtonsoft.Json.Bson.BsonType type, CancellationToken cancellationToken)
	{
		switch (type)
		{
		case Newtonsoft.Json.Bson.BsonType.Number:
		case Newtonsoft.Json.Bson.BsonType.String:
		case Newtonsoft.Json.Bson.BsonType.Object:
		case Newtonsoft.Json.Bson.BsonType.Array:
		case Newtonsoft.Json.Bson.BsonType.Binary:
		case Newtonsoft.Json.Bson.BsonType.Oid:
		case Newtonsoft.Json.Bson.BsonType.Boolean:
		case Newtonsoft.Json.Bson.BsonType.Date:
		case Newtonsoft.Json.Bson.BsonType.Regex:
		case Newtonsoft.Json.Bson.BsonType.Code:
		case Newtonsoft.Json.Bson.BsonType.Symbol:
		case Newtonsoft.Json.Bson.BsonType.Integer:
		case Newtonsoft.Json.Bson.BsonType.TimeStamp:
		case Newtonsoft.Json.Bson.BsonType.Long:
			return ReadTypeTrulyAsync(type, cancellationToken);
		case Newtonsoft.Json.Bson.BsonType.Undefined:
		case Newtonsoft.Json.Bson.BsonType.Null:
		case Newtonsoft.Json.Bson.BsonType.Reference:
		case Newtonsoft.Json.Bson.BsonType.CodeWScope:
			ReadType(type);
			return AsyncUtils.CompletedTask;
		default:
			throw new ArgumentOutOfRangeException("type", "Unexpected BsonType value: " + type);
		}
	}

	private async Task ReadTypeTrulyAsync(Newtonsoft.Json.Bson.BsonType type, CancellationToken cancellationToken)
	{
		switch (type)
		{
		case Newtonsoft.Json.Bson.BsonType.Number:
			if (base.FloatParseHandling == FloatParseHandling.Decimal)
			{
				SetToken(JsonToken.Float, Convert.ToDecimal(await ReadDoubleAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false), CultureInfo.InvariantCulture));
			}
			else
			{
				SetToken(JsonToken.Float, await ReadDoubleAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			}
			break;
		case Newtonsoft.Json.Bson.BsonType.String:
		case Newtonsoft.Json.Bson.BsonType.Symbol:
			SetToken(JsonToken.String, await ReadLengthStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			break;
		case Newtonsoft.Json.Bson.BsonType.Object:
		{
			SetToken(JsonToken.StartObject);
			ContainerContext containerContext3 = new ContainerContext(Newtonsoft.Json.Bson.BsonType.Object);
			PushContext(containerContext3);
			ContainerContext containerContext2 = containerContext3;
			containerContext2.Length = await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Array:
		{
			SetToken(JsonToken.StartArray);
			ContainerContext containerContext = new ContainerContext(Newtonsoft.Json.Bson.BsonType.Array);
			PushContext(containerContext);
			ContainerContext containerContext2 = containerContext;
			containerContext2.Length = await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Binary:
		{
			Tuple<byte[], Newtonsoft.Json.Bson.BsonBinaryType> tuple = await ReadBinaryAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			SetToken(JsonToken.Bytes, (tuple.Item2 != Newtonsoft.Json.Bson.BsonBinaryType.Uuid) ? tuple.Item1 : ((object)new Guid(tuple.Item1)));
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Oid:
			SetToken(JsonToken.Bytes, await ReadBytesAsync(12, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			break;
		case Newtonsoft.Json.Bson.BsonType.Boolean:
			SetToken(JsonToken.Boolean, Convert.ToBoolean(await ReadByteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false)));
			break;
		case Newtonsoft.Json.Bson.BsonType.Date:
		{
			DateTime dateTime = DateTimeUtils.ConvertJavaScriptTicksToDateTime(await ReadInt64Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			switch (DateTimeKindHandling)
			{
			case DateTimeKind.Unspecified:
				dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
				break;
			case DateTimeKind.Local:
				dateTime = dateTime.ToLocalTime();
				break;
			}
			SetToken(JsonToken.Date, dateTime);
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Regex:
			SetToken(JsonToken.String, "/" + await ReadStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false) + "/" + await ReadStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			break;
		case Newtonsoft.Json.Bson.BsonType.Code:
			SetToken(JsonToken.String, await ReadLengthStringAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			break;
		case Newtonsoft.Json.Bson.BsonType.Integer:
			SetToken(JsonToken.Integer, (long)(await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false)));
			break;
		case Newtonsoft.Json.Bson.BsonType.TimeStamp:
		case Newtonsoft.Json.Bson.BsonType.Long:
			SetToken(JsonToken.Integer, await ReadInt64Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			break;
		}
	}

	private async Task<Tuple<byte[], Newtonsoft.Json.Bson.BsonBinaryType>> ReadBinaryAsync(CancellationToken cancellationToken)
	{
		int dataLength = await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		Newtonsoft.Json.Bson.BsonBinaryType binaryType = (Newtonsoft.Json.Bson.BsonBinaryType)(await ReadByteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
		if (binaryType == Newtonsoft.Json.Bson.BsonBinaryType.BinaryOld && !_jsonNet35BinaryCompatibility)
		{
			dataLength = await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		return Tuple.Create(await ReadBytesAsync(dataLength, cancellationToken).ConfigureAwait(continueOnCapturedContext: false), binaryType);
	}

	private async Task<string> ReadStringAsync(CancellationToken cancellationToken)
	{
		EnsureBuffers();
		StringBuilder builder = null;
		int totalBytesRead = 0;
		int offset = 0;
		byte b = default(byte);
		while (true)
		{
			int count = offset;
			while (true)
			{
				bool flag = count < 128;
				if (flag)
				{
					byte num = await _asyncReader.ReadByteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					b = num;
					flag = num > 0;
				}
				if (!flag)
				{
					break;
				}
				_byteBuffer[count++] = b;
			}
			int num2 = count - offset;
			totalBytesRead += num2;
			if (count < 128 && builder == null)
			{
				int chars = Encoding.UTF8.GetChars(_byteBuffer, 0, num2, _charBuffer, 0);
				MovePosition(totalBytesRead + 1);
				return new string(_charBuffer, 0, chars);
			}
			int lastFullCharStop = GetLastFullCharStop(count - 1);
			int chars2 = Encoding.UTF8.GetChars(_byteBuffer, 0, lastFullCharStop + 1, _charBuffer, 0);
			if (builder == null)
			{
				builder = new StringBuilder(256);
			}
			builder.Append(_charBuffer, 0, chars2);
			if (lastFullCharStop < num2 - 1)
			{
				offset = num2 - lastFullCharStop - 1;
				Array.Copy(_byteBuffer, lastFullCharStop + 1, _byteBuffer, 0, offset);
				continue;
			}
			if (count < 128)
			{
				break;
			}
			offset = 0;
		}
		MovePosition(totalBytesRead + 1);
		return builder.ToString();
	}

	private async Task<string> ReadLengthStringAsync(CancellationToken cancellationToken)
	{
		int num = await ReadInt32Async(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		MovePosition(num);
		string s = await GetStringAsync(num - 1, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		await _asyncReader.ReadByteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		return s;
	}

	private Task<string> GetStringAsync(int length, CancellationToken cancellationToken)
	{
		if (length != 0)
		{
			return GetNonEmptyStringAsync(length, cancellationToken);
		}
		return AsyncUtils.EmptyString;
	}

	private async Task<string> GetNonEmptyStringAsync(int length, CancellationToken cancellationToken)
	{
		EnsureBuffers();
		StringBuilder builder = null;
		int totalBytesRead = 0;
		int offset = 0;
		do
		{
			int count = ((length - totalBytesRead > 128 - offset) ? (128 - offset) : (length - totalBytesRead));
			int num = await _asyncReader.ReadAsync(_byteBuffer, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (num == 0)
			{
				throw new EndOfStreamException("Unable to read beyond the end of the stream.");
			}
			totalBytesRead += num;
			num += offset;
			if (num == length)
			{
				int chars = Encoding.UTF8.GetChars(_byteBuffer, 0, num, _charBuffer, 0);
				return new string(_charBuffer, 0, chars);
			}
			int lastFullCharStop = GetLastFullCharStop(num - 1);
			if (builder == null)
			{
				builder = new StringBuilder(length);
			}
			int chars2 = Encoding.UTF8.GetChars(_byteBuffer, 0, lastFullCharStop + 1, _charBuffer, 0);
			builder.Append(_charBuffer, 0, chars2);
			if (lastFullCharStop < num - 1)
			{
				offset = num - lastFullCharStop - 1;
				Array.Copy(_byteBuffer, lastFullCharStop + 1, _byteBuffer, 0, offset);
			}
			else
			{
				offset = 0;
			}
		}
		while (totalBytesRead < length);
		return builder.ToString();
	}

	private Task<double> ReadDoubleAsync(CancellationToken cancellationToken)
	{
		MovePosition(8);
		return _asyncReader.ReadDoubleAsync(cancellationToken);
	}

	private Task<int> ReadInt32Async(CancellationToken cancellationToken)
	{
		MovePosition(4);
		return _asyncReader.ReadInt32Async(cancellationToken);
	}

	private Task<long> ReadInt64Async(CancellationToken cancellationToken)
	{
		MovePosition(8);
		return _asyncReader.ReadInt64Async(cancellationToken);
	}

	private async Task<Newtonsoft.Json.Bson.BsonType> ReadTypeAsync(CancellationToken cancellationToken)
	{
		MovePosition(1);
		return (Newtonsoft.Json.Bson.BsonType)(await _asyncReader.ReadByteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
	}

	private Task<byte[]> ReadBytesAsync(int count, CancellationToken cancellationToken)
	{
		MovePosition(count);
		return _asyncReader.ReadBytesAsync(count, cancellationToken);
	}

	private async Task<JsonToken> GetContentTokenAsync(CancellationToken cancellationToken)
	{
		while (await ReadAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
		{
			JsonToken tokenType = TokenType;
			if (tokenType != JsonToken.Comment)
			{
				return tokenType;
			}
		}
		SetToken(JsonToken.None);
		return JsonToken.None;
	}

	public override Task<bool?> ReadAsBooleanAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (_asyncReader != null)
		{
			return DoReadAsBooleanAsync(cancellationToken);
		}
		return base.ReadAsBooleanAsync(cancellationToken);
	}

	private async Task<bool?> DoReadAsBooleanAsync(CancellationToken cancellationToken)
	{
		JsonToken jsonToken = await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		switch (jsonToken)
		{
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.Integer:
		case JsonToken.Float:
		{
			bool flag = ((!(Value is BigInteger)) ? Convert.ToBoolean(Value, CultureInfo.InvariantCulture) : ((BigInteger)Value != 0L));
			SetToken(JsonToken.Boolean, flag, updateIndex: false);
			return flag;
		}
		case JsonToken.String:
			return ReadBooleanString((string)Value);
		case JsonToken.Boolean:
			return (bool)Value;
		default:
			throw ExceptionUtils.CreateJsonReaderException(this, "Error reading boolean. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, jsonToken));
		}
	}

	public override Task<byte[]> ReadAsBytesAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (_asyncReader != null)
		{
			return DoReadAsBytesAsync(cancellationToken);
		}
		return base.ReadAsBytesAsync(cancellationToken);
	}

	private async Task<byte[]> DoReadAsBytesAsync(CancellationToken cancellationToken)
	{
		JsonToken jsonToken = await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		switch (jsonToken)
		{
		case JsonToken.StartObject:
		{
			await ReadIntoWrappedTypeObjectAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			byte[] data = await ReadAsBytesAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await ReaderReadAndAssertAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (TokenType != JsonToken.EndObject)
			{
				throw ExceptionUtils.CreateJsonReaderException(this, "Error reading bytes. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, TokenType));
			}
			SetToken(JsonToken.Bytes, data, updateIndex: false);
			return data;
		}
		case JsonToken.String:
		{
			string text = (string)Value;
			Guid g;
			byte[] array2 = ((text.Length == 0) ? CollectionUtils.ArrayEmpty<byte>() : ((!ConvertUtils.TryConvertGuid(text, out g)) ? Convert.FromBase64String(text) : g.ToByteArray()));
			SetToken(JsonToken.Bytes, array2, updateIndex: false);
			return array2;
		}
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.Bytes:
			if (ValueType == typeof(Guid))
			{
				byte[] array = ((Guid)Value).ToByteArray();
				SetToken(JsonToken.Bytes, array, updateIndex: false);
				return array;
			}
			return (byte[])Value;
		case JsonToken.StartArray:
			return await ReadArrayIntoByteArrayAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		default:
			throw ExceptionUtils.CreateJsonReaderException(this, "Error reading bytes. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, jsonToken));
		}
	}

	private async Task ReadIntoWrappedTypeObjectAsync(CancellationToken cancellationToken)
	{
		await ReaderReadAndAssertAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		if (Value?.ToString() == "$type")
		{
			await ReaderReadAndAssertAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (Value != null && Value.ToString().StartsWith("System.Byte[]", StringComparison.Ordinal))
			{
				await ReaderReadAndAssertAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (Value?.ToString() == "$value")
				{
					return;
				}
			}
		}
		throw ExceptionUtils.CreateJsonReaderException(this, "Error reading bytes. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, JsonToken.StartObject));
	}

	public override Task<DateTime?> ReadAsDateTimeAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (_asyncReader != null)
		{
			return DoReadAsDateTimeAsync(cancellationToken);
		}
		return base.ReadAsDateTimeAsync(cancellationToken);
	}

	private async Task<DateTime?> DoReadAsDateTimeAsync(CancellationToken cancellationToken)
	{
		switch (await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
		{
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.Date:
			if (Value is DateTimeOffset)
			{
				SetToken(JsonToken.Date, ((DateTimeOffset)Value).DateTime, updateIndex: false);
			}
			return (DateTime)Value;
		case JsonToken.String:
			return ReadDateTimeString((string)Value);
		default:
			throw ExceptionUtils.CreateJsonReaderException(this, "Error reading date. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, TokenType));
		}
	}

	public override Task<DateTimeOffset?> ReadAsDateTimeOffsetAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (_asyncReader != null)
		{
			return DoReadAsDateTimeOffsetAsync(cancellationToken);
		}
		return base.ReadAsDateTimeOffsetAsync(cancellationToken);
	}

	private async Task<DateTimeOffset?> DoReadAsDateTimeOffsetAsync(CancellationToken cancellationToken)
	{
		JsonToken jsonToken = await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		switch (jsonToken)
		{
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.Date:
			if (Value is DateTime)
			{
				SetToken(JsonToken.Date, new DateTimeOffset((DateTime)Value), updateIndex: false);
			}
			return (DateTimeOffset)Value;
		case JsonToken.String:
			return ReadDateTimeOffsetString((string)Value);
		default:
			throw ExceptionUtils.CreateJsonReaderException(this, "Error reading date. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, jsonToken));
		}
	}

	internal DateTimeOffset? ReadDateTimeOffsetString(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			SetToken(JsonToken.Null, null, updateIndex: false);
			return null;
		}
		if (DateTimeUtils.TryParseDateTimeOffset(s, base.DateFormatString, base.Culture, out var dt))
		{
			SetToken(JsonToken.Date, dt, updateIndex: false);
			return dt;
		}
		if (DateTimeOffset.TryParse(s, base.Culture, DateTimeStyles.RoundtripKind, out dt))
		{
			SetToken(JsonToken.Date, dt, updateIndex: false);
			return dt;
		}
		SetToken(JsonToken.String, s, updateIndex: false);
		throw ExceptionUtils.CreateJsonReaderException(this, "Could not convert string to DateTimeOffset: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
	}

	public override Task<decimal?> ReadAsDecimalAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (_asyncReader != null)
		{
			return DoReadAsDecimalAsync(cancellationToken);
		}
		return base.ReadAsDecimalAsync(cancellationToken);
	}

	private async Task<decimal?> DoReadAsDecimalAsync(CancellationToken cancellationToken)
	{
		JsonToken jsonToken = await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		switch (jsonToken)
		{
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.Integer:
		case JsonToken.Float:
			if (!(Value is decimal))
			{
				SetToken(JsonToken.Float, Convert.ToDecimal(Value, CultureInfo.InvariantCulture), updateIndex: false);
			}
			return (decimal)Value;
		case JsonToken.String:
			return ReadDecimalString((string)Value);
		default:
			throw ExceptionUtils.CreateJsonReaderException(this, "Error reading decimal. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, jsonToken));
		}
	}

	public override Task<double?> ReadAsDoubleAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (_asyncReader != null)
		{
			return DoReadAsDoubleAsync(cancellationToken);
		}
		return base.ReadAsDoubleAsync(cancellationToken);
	}

	private async Task<double?> DoReadAsDoubleAsync(CancellationToken cancellationToken)
	{
		JsonToken jsonToken = await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		switch (jsonToken)
		{
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.Integer:
		case JsonToken.Float:
			if (!(Value is double))
			{
				double num = ((!(Value is BigInteger)) ? Convert.ToDouble(Value, CultureInfo.InvariantCulture) : ((double)(BigInteger)Value));
				SetToken(JsonToken.Float, num, updateIndex: false);
			}
			return (double)Value;
		case JsonToken.String:
			return ReadDoubleString((string)Value);
		default:
			throw ExceptionUtils.CreateJsonReaderException(this, "Error reading double. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, jsonToken));
		}
	}

	public override Task<int?> ReadAsInt32Async(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (_asyncReader != null)
		{
			return DoReadAsInt32Async(cancellationToken);
		}
		return base.ReadAsInt32Async(cancellationToken);
	}

	private async Task<int?> DoReadAsInt32Async(CancellationToken cancellationToken)
	{
		JsonToken jsonToken = await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		switch (jsonToken)
		{
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.Integer:
		case JsonToken.Float:
			if (!(Value is int))
			{
				SetToken(JsonToken.Integer, Convert.ToInt32(Value, CultureInfo.InvariantCulture), updateIndex: false);
			}
			return (int)Value;
		case JsonToken.String:
		{
			string s = (string)Value;
			return ReadInt32String(s);
		}
		default:
			throw ExceptionUtils.CreateJsonReaderException(this, "Error reading integer. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, jsonToken));
		}
	}

	public override Task<string> ReadAsStringAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (_asyncReader != null)
		{
			return DoReadAsStringAsync(cancellationToken);
		}
		return base.ReadAsStringAsync(cancellationToken);
	}

	private async Task<string> DoReadAsStringAsync(CancellationToken cancellationToken)
	{
		JsonToken jsonToken = await GetContentTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		switch (jsonToken)
		{
		case JsonToken.None:
		case JsonToken.Null:
		case JsonToken.EndArray:
			return null;
		case JsonToken.String:
			return (string)Value;
		default:
			if (JsonTokenUtils.IsPrimitiveToken(jsonToken) && Value != null)
			{
				string text;
				if (Value is IFormattable formattable)
				{
					text = formattable.ToString(null, base.Culture);
				}
				else
				{
					Uri uri = Value as Uri;
					text = ((uri != null) ? uri.OriginalString : Value.ToString());
				}
				SetToken(JsonToken.String, text, updateIndex: false);
				return text;
			}
			throw ExceptionUtils.CreateJsonReaderException(this, "Error reading string. Unexpected token: {0}.".FormatWith(CultureInfo.InvariantCulture, jsonToken));
		}
	}

	internal async Task ReaderReadAndAssertAsync(CancellationToken cancellationToken)
	{
		if (!(await ReadAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false)))
		{
			throw CreateUnexpectedEndException();
		}
	}

	internal JsonReaderException CreateUnexpectedEndException()
	{
		return ExceptionUtils.CreateJsonReaderException(this, "Unexpected end when reading JSON.");
	}

	internal async Task<byte[]> ReadArrayIntoByteArrayAsync(CancellationToken cancellationToken)
	{
		List<byte> buffer = new List<byte>();
		do
		{
			if (!(await ReadAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false)))
			{
				SetToken(JsonToken.None);
			}
		}
		while (!ReadArrayElementIntoByteArrayReportDone(buffer));
		byte[] array = buffer.ToArray();
		SetToken(JsonToken.Bytes, array, updateIndex: false);
		return array;
	}

	private bool ReadArrayElementIntoByteArrayReportDone(List<byte> buffer)
	{
		switch (TokenType)
		{
		case JsonToken.None:
			throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected end when reading bytes.");
		case JsonToken.Integer:
			buffer.Add(Convert.ToByte(Value, CultureInfo.InvariantCulture));
			return false;
		case JsonToken.EndArray:
			return true;
		case JsonToken.Comment:
			return false;
		default:
			throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected token when reading bytes: {0}.".FormatWith(CultureInfo.InvariantCulture, TokenType));
		}
	}

	internal int? ReadInt32String(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			SetToken(JsonToken.Null, null, updateIndex: false);
			return null;
		}
		if (int.TryParse(s, NumberStyles.Integer, base.Culture, out var result))
		{
			SetToken(JsonToken.Integer, result, updateIndex: false);
			return result;
		}
		SetToken(JsonToken.String, s, updateIndex: false);
		throw ExceptionUtils.CreateJsonReaderException(this, "Could not convert string to integer: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
	}

	internal double? ReadDoubleString(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			SetToken(JsonToken.Null, null, updateIndex: false);
			return null;
		}
		if (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, base.Culture, out var result))
		{
			SetToken(JsonToken.Float, result, updateIndex: false);
			return result;
		}
		SetToken(JsonToken.String, s, updateIndex: false);
		throw ExceptionUtils.CreateJsonReaderException(this, "Could not convert string to double: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
	}

	internal decimal? ReadDecimalString(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			SetToken(JsonToken.Null, null, updateIndex: false);
			return null;
		}
		if (decimal.TryParse(s, NumberStyles.Number, base.Culture, out var result))
		{
			SetToken(JsonToken.Float, result, updateIndex: false);
			return result;
		}
		SetToken(JsonToken.String, s, updateIndex: false);
		throw ExceptionUtils.CreateJsonReaderException(this, "Could not convert string to decimal: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
	}

	internal DateTime? ReadDateTimeString(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			SetToken(JsonToken.Null, null, updateIndex: false);
			return null;
		}
		if (DateTimeUtils.TryParseDateTime(s, base.DateTimeZoneHandling, base.DateFormatString, base.Culture, out var dt))
		{
			dt = DateTimeUtils.EnsureDateTime(dt, base.DateTimeZoneHandling);
			SetToken(JsonToken.Date, dt, updateIndex: false);
			return dt;
		}
		if (DateTime.TryParse(s, base.Culture, DateTimeStyles.RoundtripKind, out dt))
		{
			dt = DateTimeUtils.EnsureDateTime(dt, base.DateTimeZoneHandling);
			SetToken(JsonToken.Date, dt, updateIndex: false);
			return dt;
		}
		throw ExceptionUtils.CreateJsonReaderException(this, "Could not convert string to DateTime: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
	}

	internal bool? ReadBooleanString(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			SetToken(JsonToken.Null, null, updateIndex: false);
			return null;
		}
		if (bool.TryParse(s, out var result))
		{
			SetToken(JsonToken.Boolean, result, updateIndex: false);
			return result;
		}
		SetToken(JsonToken.String, s, updateIndex: false);
		throw ExceptionUtils.CreateJsonReaderException(this, "Could not convert string to boolean: {0}.".FormatWith(CultureInfo.InvariantCulture, s));
	}

	public BsonDataReader(Stream stream)
		: this(stream, readRootValueAsArray: false, DateTimeKind.Local)
	{
	}

	public BsonDataReader(Stream stream, bool readRootValueAsArray, DateTimeKind dateTimeKindHandling)
	{
		ValidationUtils.ArgumentNotNull(stream, "stream");
		_stack = new List<ContainerContext>();
		_readRootValueAsArray = readRootValueAsArray;
		_dateTimeKindHandling = dateTimeKindHandling;
		if (GetType() == typeof(BsonDataReader))
		{
			_reader = (_asyncReader = new AsyncBinaryReader(stream));
		}
		else
		{
			_reader = new BinaryReader(stream);
		}
	}

	private string ReadElement()
	{
		_currentElementType = ReadType();
		return ReadString();
	}

	public override bool Read()
	{
		try
		{
			bool flag;
			switch (_bsonReaderState)
			{
			case BsonReaderState.Normal:
				flag = ReadNormal();
				break;
			case BsonReaderState.ReferenceStart:
			case BsonReaderState.ReferenceRef:
			case BsonReaderState.ReferenceId:
				flag = ReadReference();
				break;
			case BsonReaderState.CodeWScopeStart:
			case BsonReaderState.CodeWScopeCode:
			case BsonReaderState.CodeWScopeScope:
			case BsonReaderState.CodeWScopeScopeObject:
			case BsonReaderState.CodeWScopeScopeEnd:
				flag = ReadCodeWScope();
				break;
			default:
				throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected state: {0}".FormatWith(CultureInfo.InvariantCulture, _bsonReaderState));
			}
			if (!flag)
			{
				SetToken(JsonToken.None);
				return false;
			}
			return true;
		}
		catch (EndOfStreamException)
		{
			SetToken(JsonToken.None);
			return false;
		}
	}

	public override void Close()
	{
		base.Close();
		if (base.CloseInput)
		{
			_reader?.Close();
		}
	}

	private bool ReadCodeWScope()
	{
		switch (_bsonReaderState)
		{
		case BsonReaderState.CodeWScopeStart:
			SetToken(JsonToken.PropertyName, "$code");
			_bsonReaderState = BsonReaderState.CodeWScopeCode;
			return true;
		case BsonReaderState.CodeWScopeCode:
			ReadInt32();
			SetToken(JsonToken.String, ReadLengthString());
			_bsonReaderState = BsonReaderState.CodeWScopeScope;
			return true;
		case BsonReaderState.CodeWScopeScope:
		{
			if (base.CurrentState == State.PostValue)
			{
				SetToken(JsonToken.PropertyName, "$scope");
				return true;
			}
			SetToken(JsonToken.StartObject);
			_bsonReaderState = BsonReaderState.CodeWScopeScopeObject;
			ContainerContext containerContext = new ContainerContext(Newtonsoft.Json.Bson.BsonType.Object);
			PushContext(containerContext);
			containerContext.Length = ReadInt32();
			return true;
		}
		case BsonReaderState.CodeWScopeScopeObject:
		{
			bool num = ReadNormal();
			if (num && TokenType == JsonToken.EndObject)
			{
				_bsonReaderState = BsonReaderState.CodeWScopeScopeEnd;
			}
			return num;
		}
		case BsonReaderState.CodeWScopeScopeEnd:
			SetToken(JsonToken.EndObject);
			_bsonReaderState = BsonReaderState.Normal;
			return true;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private bool ReadReference()
	{
		switch (base.CurrentState)
		{
		case State.ObjectStart:
			SetToken(JsonToken.PropertyName, "$ref");
			_bsonReaderState = BsonReaderState.ReferenceRef;
			return true;
		case State.Property:
			if (_bsonReaderState == BsonReaderState.ReferenceRef)
			{
				SetToken(JsonToken.String, ReadLengthString());
				return true;
			}
			if (_bsonReaderState == BsonReaderState.ReferenceId)
			{
				SetToken(JsonToken.Bytes, ReadBytes(12));
				return true;
			}
			throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected state when reading BSON reference: " + _bsonReaderState);
		case State.PostValue:
			if (_bsonReaderState == BsonReaderState.ReferenceRef)
			{
				SetToken(JsonToken.PropertyName, "$id");
				_bsonReaderState = BsonReaderState.ReferenceId;
				return true;
			}
			if (_bsonReaderState == BsonReaderState.ReferenceId)
			{
				SetToken(JsonToken.EndObject);
				_bsonReaderState = BsonReaderState.Normal;
				return true;
			}
			throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected state when reading BSON reference: " + _bsonReaderState);
		default:
			throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected state when reading BSON reference: " + base.CurrentState);
		}
	}

	private bool ReadNormal()
	{
		switch (base.CurrentState)
		{
		case State.Start:
		{
			JsonToken token2 = ((!_readRootValueAsArray) ? JsonToken.StartObject : JsonToken.StartArray);
			int type = ((!_readRootValueAsArray) ? 3 : 4);
			SetToken(token2);
			ContainerContext containerContext = new ContainerContext((Newtonsoft.Json.Bson.BsonType)type);
			PushContext(containerContext);
			containerContext.Length = ReadInt32();
			return true;
		}
		case State.Complete:
		case State.Closed:
			return false;
		case State.Property:
			ReadType(_currentElementType);
			return true;
		case State.ObjectStart:
		case State.ArrayStart:
		case State.PostValue:
		{
			ContainerContext currentContext = _currentContext;
			if (currentContext == null)
			{
				if (!base.SupportMultipleContent)
				{
					return false;
				}
				goto case State.Start;
			}
			int num = currentContext.Length - 1;
			if (currentContext.Position < num)
			{
				if (currentContext.Type == Newtonsoft.Json.Bson.BsonType.Array)
				{
					ReadElement();
					ReadType(_currentElementType);
					return true;
				}
				SetToken(JsonToken.PropertyName, ReadElement());
				return true;
			}
			if (currentContext.Position == num)
			{
				if (ReadByte() != 0)
				{
					throw ExceptionUtils.CreateJsonReaderException(this, "Unexpected end of object byte value.");
				}
				PopContext();
				if (_currentContext != null)
				{
					MovePosition(currentContext.Length);
				}
				JsonToken token = ((currentContext.Type == Newtonsoft.Json.Bson.BsonType.Object) ? JsonToken.EndObject : JsonToken.EndArray);
				SetToken(token);
				return true;
			}
			throw ExceptionUtils.CreateJsonReaderException(this, "Read past end of current container context.");
		}
		default:
			throw new ArgumentOutOfRangeException();
		case State.ConstructorStart:
		case State.Constructor:
		case State.Error:
		case State.Finished:
			return false;
		}
	}

	private void PopContext()
	{
		_stack.RemoveAt(_stack.Count - 1);
		if (_stack.Count == 0)
		{
			_currentContext = null;
		}
		else
		{
			_currentContext = _stack[_stack.Count - 1];
		}
	}

	private void PushContext(ContainerContext newContext)
	{
		_stack.Add(newContext);
		_currentContext = newContext;
	}

	private byte ReadByte()
	{
		MovePosition(1);
		return _reader.ReadByte();
	}

	private void ReadType(Newtonsoft.Json.Bson.BsonType type)
	{
		switch (type)
		{
		case Newtonsoft.Json.Bson.BsonType.Number:
		{
			double num = ReadDouble();
			if (base.FloatParseHandling == FloatParseHandling.Decimal)
			{
				SetToken(JsonToken.Float, Convert.ToDecimal(num, CultureInfo.InvariantCulture));
			}
			else
			{
				SetToken(JsonToken.Float, num);
			}
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.String:
		case Newtonsoft.Json.Bson.BsonType.Symbol:
			SetToken(JsonToken.String, ReadLengthString());
			break;
		case Newtonsoft.Json.Bson.BsonType.Object:
		{
			SetToken(JsonToken.StartObject);
			ContainerContext containerContext2 = new ContainerContext(Newtonsoft.Json.Bson.BsonType.Object);
			PushContext(containerContext2);
			containerContext2.Length = ReadInt32();
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Array:
		{
			SetToken(JsonToken.StartArray);
			ContainerContext containerContext = new ContainerContext(Newtonsoft.Json.Bson.BsonType.Array);
			PushContext(containerContext);
			containerContext.Length = ReadInt32();
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Binary:
		{
			Newtonsoft.Json.Bson.BsonBinaryType binaryType;
			byte[] array = ReadBinary(out binaryType);
			object value3 = ((binaryType != Newtonsoft.Json.Bson.BsonBinaryType.Uuid) ? array : ((object)new Guid(array)));
			SetToken(JsonToken.Bytes, value3);
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Undefined:
			SetToken(JsonToken.Undefined);
			break;
		case Newtonsoft.Json.Bson.BsonType.Oid:
		{
			byte[] value2 = ReadBytes(12);
			SetToken(JsonToken.Bytes, value2);
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Boolean:
		{
			bool flag = Convert.ToBoolean(ReadByte());
			SetToken(JsonToken.Boolean, flag);
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Date:
		{
			DateTime dateTime = DateTimeUtils.ConvertJavaScriptTicksToDateTime(ReadInt64());
			SetToken(JsonToken.Date, DateTimeKindHandling switch
			{
				DateTimeKind.Unspecified => DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified), 
				DateTimeKind.Local => dateTime.ToLocalTime(), 
				_ => dateTime, 
			});
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Null:
			SetToken(JsonToken.Null);
			break;
		case Newtonsoft.Json.Bson.BsonType.Regex:
		{
			string text = ReadString();
			string text2 = ReadString();
			string value = "/" + text + "/" + text2;
			SetToken(JsonToken.String, value);
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Reference:
			SetToken(JsonToken.StartObject);
			_bsonReaderState = BsonReaderState.ReferenceStart;
			break;
		case Newtonsoft.Json.Bson.BsonType.Code:
			SetToken(JsonToken.String, ReadLengthString());
			break;
		case Newtonsoft.Json.Bson.BsonType.CodeWScope:
			SetToken(JsonToken.StartObject);
			_bsonReaderState = BsonReaderState.CodeWScopeStart;
			break;
		case Newtonsoft.Json.Bson.BsonType.Integer:
			SetToken(JsonToken.Integer, (long)ReadInt32());
			break;
		case Newtonsoft.Json.Bson.BsonType.TimeStamp:
		case Newtonsoft.Json.Bson.BsonType.Long:
			SetToken(JsonToken.Integer, ReadInt64());
			break;
		default:
			throw new ArgumentOutOfRangeException("type", "Unexpected BsonType value: " + type);
		}
	}

	private byte[] ReadBinary(out Newtonsoft.Json.Bson.BsonBinaryType binaryType)
	{
		int count = ReadInt32();
		binaryType = (Newtonsoft.Json.Bson.BsonBinaryType)ReadByte();
		if (binaryType == Newtonsoft.Json.Bson.BsonBinaryType.BinaryOld && !_jsonNet35BinaryCompatibility)
		{
			count = ReadInt32();
		}
		return ReadBytes(count);
	}

	private string ReadString()
	{
		EnsureBuffers();
		StringBuilder stringBuilder = null;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int num3 = num2;
			byte b;
			while (num3 < 128 && (b = _reader.ReadByte()) > 0)
			{
				_byteBuffer[num3++] = b;
			}
			int num4 = num3 - num2;
			num += num4;
			if (num3 < 128 && stringBuilder == null)
			{
				int chars = Encoding.UTF8.GetChars(_byteBuffer, 0, num4, _charBuffer, 0);
				MovePosition(num + 1);
				return new string(_charBuffer, 0, chars);
			}
			int lastFullCharStop = GetLastFullCharStop(num3 - 1);
			int chars2 = Encoding.UTF8.GetChars(_byteBuffer, 0, lastFullCharStop + 1, _charBuffer, 0);
			if (stringBuilder == null)
			{
				stringBuilder = new StringBuilder(256);
			}
			stringBuilder.Append(_charBuffer, 0, chars2);
			if (lastFullCharStop < num4 - 1)
			{
				num2 = num4 - lastFullCharStop - 1;
				Array.Copy(_byteBuffer, lastFullCharStop + 1, _byteBuffer, 0, num2);
				continue;
			}
			if (num3 < 128)
			{
				break;
			}
			num2 = 0;
		}
		MovePosition(num + 1);
		return stringBuilder.ToString();
	}

	private string ReadLengthString()
	{
		int num = ReadInt32();
		MovePosition(num);
		string result = GetString(num - 1);
		_reader.ReadByte();
		return result;
	}

	private string GetString(int length)
	{
		if (length == 0)
		{
			return string.Empty;
		}
		EnsureBuffers();
		StringBuilder stringBuilder = null;
		int num = 0;
		int num2 = 0;
		do
		{
			int count = ((length - num > 128 - num2) ? (128 - num2) : (length - num));
			int num3 = _reader.Read(_byteBuffer, num2, count);
			if (num3 == 0)
			{
				throw new EndOfStreamException("Unable to read beyond the end of the stream.");
			}
			num += num3;
			num3 += num2;
			if (num3 == length)
			{
				int chars = Encoding.UTF8.GetChars(_byteBuffer, 0, num3, _charBuffer, 0);
				return new string(_charBuffer, 0, chars);
			}
			int lastFullCharStop = GetLastFullCharStop(num3 - 1);
			if (stringBuilder == null)
			{
				stringBuilder = new StringBuilder(length);
			}
			int chars2 = Encoding.UTF8.GetChars(_byteBuffer, 0, lastFullCharStop + 1, _charBuffer, 0);
			stringBuilder.Append(_charBuffer, 0, chars2);
			if (lastFullCharStop < num3 - 1)
			{
				num2 = num3 - lastFullCharStop - 1;
				Array.Copy(_byteBuffer, lastFullCharStop + 1, _byteBuffer, 0, num2);
			}
			else
			{
				num2 = 0;
			}
		}
		while (num < length);
		return stringBuilder.ToString();
	}

	private int GetLastFullCharStop(int start)
	{
		int num = start;
		int num2 = 0;
		for (; num >= 0; num--)
		{
			num2 = BytesInSequence(_byteBuffer[num]);
			switch (num2)
			{
			case 0:
				continue;
			default:
				num--;
				break;
			case 1:
				break;
			}
			break;
		}
		if (num2 == start - num)
		{
			return start;
		}
		return num;
	}

	private int BytesInSequence(byte b)
	{
		if (b <= SeqRange1[1])
		{
			return 1;
		}
		if (b >= SeqRange2[0] && b <= SeqRange2[1])
		{
			return 2;
		}
		if (b >= SeqRange3[0] && b <= SeqRange3[1])
		{
			return 3;
		}
		if (b >= SeqRange4[0] && b <= SeqRange4[1])
		{
			return 4;
		}
		return 0;
	}

	private void EnsureBuffers()
	{
		if (_byteBuffer == null)
		{
			_byteBuffer = new byte[128];
		}
		if (_charBuffer == null)
		{
			int maxCharCount = Encoding.UTF8.GetMaxCharCount(128);
			_charBuffer = new char[maxCharCount];
		}
	}

	private double ReadDouble()
	{
		MovePosition(8);
		return _reader.ReadDouble();
	}

	private int ReadInt32()
	{
		MovePosition(4);
		return _reader.ReadInt32();
	}

	private long ReadInt64()
	{
		MovePosition(8);
		return _reader.ReadInt64();
	}

	private Newtonsoft.Json.Bson.BsonType ReadType()
	{
		MovePosition(1);
		return (Newtonsoft.Json.Bson.BsonType)_reader.ReadSByte();
	}

	private void MovePosition(int count)
	{
		_currentContext.Position += count;
	}

	private byte[] ReadBytes(int count)
	{
		MovePosition(count);
		return _reader.ReadBytes(count);
	}
}
