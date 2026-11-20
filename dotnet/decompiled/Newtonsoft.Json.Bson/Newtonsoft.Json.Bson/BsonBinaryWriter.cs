using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson.Utilities;

namespace Newtonsoft.Json.Bson;

internal class BsonBinaryWriter
{
	private readonly AsyncBinaryWriter _asyncWriter;

	private static readonly Encoding Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

	private readonly BinaryWriter _writer;

	private byte[] _largeByteBuffer;

	public DateTimeKind DateTimeKindHandling { get; set; }

	public Task FlushAsync(CancellationToken cancellationToken)
	{
		if (_asyncWriter == null)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return cancellationToken.FromCanceled();
			}
			Flush();
			return AsyncUtils.CompletedTask;
		}
		return _asyncWriter.FlushAsync(cancellationToken);
	}

	public Task WriteTokenAsync(Newtonsoft.Json.Bson.BsonToken t, CancellationToken cancellationToken)
	{
		if (_asyncWriter == null)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return cancellationToken.FromCanceled();
			}
			WriteToken(t);
			return AsyncUtils.CompletedTask;
		}
		CalculateSize(t);
		return WriteTokenInternalAsync(t, cancellationToken);
	}

	private Task WriteTokenInternalAsync(Newtonsoft.Json.Bson.BsonToken t, CancellationToken cancellationToken)
	{
		switch (t.Type)
		{
		case Newtonsoft.Json.Bson.BsonType.Object:
			return WriteObjectAsync((Newtonsoft.Json.Bson.BsonObject)t, cancellationToken);
		case Newtonsoft.Json.Bson.BsonType.Array:
			return WriteArrayAsync((Newtonsoft.Json.Bson.BsonArray)t, cancellationToken);
		case Newtonsoft.Json.Bson.BsonType.Integer:
			return _asyncWriter.WriteAsync(Convert.ToInt32(((Newtonsoft.Json.Bson.BsonValue)t).Value, CultureInfo.InvariantCulture), cancellationToken);
		case Newtonsoft.Json.Bson.BsonType.Long:
			return _asyncWriter.WriteAsync(Convert.ToInt64(((Newtonsoft.Json.Bson.BsonValue)t).Value, CultureInfo.InvariantCulture), cancellationToken);
		case Newtonsoft.Json.Bson.BsonType.Number:
			return _asyncWriter.WriteAsync(Convert.ToDouble(((Newtonsoft.Json.Bson.BsonValue)t).Value, CultureInfo.InvariantCulture), cancellationToken);
		case Newtonsoft.Json.Bson.BsonType.String:
		{
			Newtonsoft.Json.Bson.BsonString bsonString = (Newtonsoft.Json.Bson.BsonString)t;
			return WriteStringAsync((string)bsonString.Value, bsonString.ByteCount, bsonString.CalculatedSize - 4, cancellationToken);
		}
		case Newtonsoft.Json.Bson.BsonType.Boolean:
			return _asyncWriter.WriteAsync((bool)((Newtonsoft.Json.Bson.BsonValue)t).Value, cancellationToken);
		case Newtonsoft.Json.Bson.BsonType.Undefined:
		case Newtonsoft.Json.Bson.BsonType.Null:
			return AsyncUtils.CompletedTask;
		case Newtonsoft.Json.Bson.BsonType.Date:
		{
			Newtonsoft.Json.Bson.BsonValue bsonValue = (Newtonsoft.Json.Bson.BsonValue)t;
			return _asyncWriter.WriteAsync(TicksFromDateObject(bsonValue.Value), cancellationToken);
		}
		case Newtonsoft.Json.Bson.BsonType.Binary:
			return WriteBinaryAsync((Newtonsoft.Json.Bson.BsonBinary)t, cancellationToken);
		case Newtonsoft.Json.Bson.BsonType.Oid:
			return _asyncWriter.WriteAsync((byte[])((Newtonsoft.Json.Bson.BsonValue)t).Value, cancellationToken);
		case Newtonsoft.Json.Bson.BsonType.Regex:
			return WriteRegexAsync((Newtonsoft.Json.Bson.BsonRegex)t, cancellationToken);
		default:
			throw new ArgumentOutOfRangeException("t", "Unexpected token when writing BSON: {0}".FormatWith(CultureInfo.InvariantCulture, t.Type));
		}
	}

	private async Task WriteObjectAsync(Newtonsoft.Json.Bson.BsonObject value, CancellationToken cancellationToken)
	{
		await _asyncWriter.WriteAsync(value.CalculatedSize, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		foreach (Newtonsoft.Json.Bson.BsonProperty property in value)
		{
			await _asyncWriter.WriteAsync((byte)property.Value.Type, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await WriteStringAsync((string)property.Name.Value, property.Name.ByteCount, null, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			Newtonsoft.Json.Bson.BsonType type = property.Value.Type;
			if (type != Newtonsoft.Json.Bson.BsonType.Null && type != Newtonsoft.Json.Bson.BsonType.Undefined)
			{
				await WriteTokenInternalAsync(property.Value, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		await _asyncWriter.WriteAsync((byte)0, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	private async Task WriteArrayAsync(Newtonsoft.Json.Bson.BsonArray value, CancellationToken cancellationToken)
	{
		await _asyncWriter.WriteAsync(value.CalculatedSize, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		ulong index = 0uL;
		foreach (Newtonsoft.Json.Bson.BsonToken c in value)
		{
			await _asyncWriter.WriteAsync((byte)c.Type, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await WriteStringAsync(index.ToString(CultureInfo.InvariantCulture), MathUtils.IntLength(index), null, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			Newtonsoft.Json.Bson.BsonType type = c.Type;
			if (type != Newtonsoft.Json.Bson.BsonType.Null && type != Newtonsoft.Json.Bson.BsonType.Undefined)
			{
				await WriteTokenInternalAsync(c, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			index++;
		}
		await _asyncWriter.WriteAsync((byte)0, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	private async Task WriteBinaryAsync(Newtonsoft.Json.Bson.BsonBinary value, CancellationToken cancellationToken)
	{
		byte[] data = (byte[])value.Value;
		await _asyncWriter.WriteAsync(data.Length, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		await _asyncWriter.WriteAsync((byte)value.BinaryType, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		await _asyncWriter.WriteAsync(data, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	private async Task WriteRegexAsync(Newtonsoft.Json.Bson.BsonRegex value, CancellationToken cancellationToken)
	{
		await WriteStringAsync((string)value.Pattern.Value, value.Pattern.ByteCount, null, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		await WriteStringAsync((string)value.Options.Value, value.Options.ByteCount, null, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	private Task WriteStringAsync(string s, int byteCount, int? calculatedlengthPrefix, CancellationToken cancellationToken)
	{
		if (calculatedlengthPrefix.HasValue)
		{
			return WritePrefixedStringAsync(s, byteCount, calculatedlengthPrefix.GetValueOrDefault(), cancellationToken);
		}
		return WriteUtf8BytesAsync(s, byteCount, cancellationToken);
	}

	private async Task WritePrefixedStringAsync(string s, int byteCount, int calculatedlengthPrefix, CancellationToken cancellationToken)
	{
		await _asyncWriter.WriteAsync(calculatedlengthPrefix, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		await WriteUtf8BytesAsync(s, byteCount, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	private Task WriteUtf8BytesAsync(string s, int byteCount, CancellationToken cancellationToken)
	{
		if (s == null)
		{
			return _asyncWriter.WriteAsync((byte)0, cancellationToken);
		}
		if (byteCount <= 255)
		{
			if (_largeByteBuffer == null)
			{
				_largeByteBuffer = new byte[256];
			}
			else
			{
				_largeByteBuffer[byteCount] = 0;
			}
			Encoding.GetBytes(s, 0, s.Length, _largeByteBuffer, 0);
			return _asyncWriter.WriteAsync(_largeByteBuffer, 0, byteCount + 1, cancellationToken);
		}
		byte[] array = new byte[byteCount + 1];
		Encoding.GetBytes(s, 0, s.Length, array, 0);
		return _asyncWriter.WriteAsync(array, cancellationToken);
	}

	public BsonBinaryWriter(BinaryWriter writer)
	{
		DateTimeKindHandling = DateTimeKind.Utc;
		_asyncWriter = writer as AsyncBinaryWriter;
		_writer = writer;
	}

	public void Flush()
	{
		_writer.Flush();
	}

	public void Close()
	{
		_writer.Close();
	}

	public void WriteToken(Newtonsoft.Json.Bson.BsonToken t)
	{
		CalculateSize(t);
		WriteTokenInternal(t);
	}

	private void WriteTokenInternal(Newtonsoft.Json.Bson.BsonToken t)
	{
		switch (t.Type)
		{
		case Newtonsoft.Json.Bson.BsonType.Object:
		{
			Newtonsoft.Json.Bson.BsonObject bsonObject = (Newtonsoft.Json.Bson.BsonObject)t;
			_writer.Write(bsonObject.CalculatedSize);
			foreach (Newtonsoft.Json.Bson.BsonProperty item in bsonObject)
			{
				_writer.Write((sbyte)item.Value.Type);
				WriteString((string)item.Name.Value, item.Name.ByteCount, null);
				WriteTokenInternal(item.Value);
			}
			_writer.Write((byte)0);
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Array:
		{
			Newtonsoft.Json.Bson.BsonArray bsonArray = (Newtonsoft.Json.Bson.BsonArray)t;
			_writer.Write(bsonArray.CalculatedSize);
			ulong num = 0uL;
			foreach (Newtonsoft.Json.Bson.BsonToken item2 in bsonArray)
			{
				_writer.Write((sbyte)item2.Type);
				WriteString(num.ToString(CultureInfo.InvariantCulture), MathUtils.IntLength(num), null);
				WriteTokenInternal(item2);
				num++;
			}
			_writer.Write((byte)0);
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Integer:
		{
			Newtonsoft.Json.Bson.BsonValue bsonValue4 = (Newtonsoft.Json.Bson.BsonValue)t;
			_writer.Write(Convert.ToInt32(bsonValue4.Value, CultureInfo.InvariantCulture));
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Long:
		{
			Newtonsoft.Json.Bson.BsonValue bsonValue3 = (Newtonsoft.Json.Bson.BsonValue)t;
			_writer.Write(Convert.ToInt64(bsonValue3.Value, CultureInfo.InvariantCulture));
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Number:
		{
			Newtonsoft.Json.Bson.BsonValue bsonValue2 = (Newtonsoft.Json.Bson.BsonValue)t;
			_writer.Write(Convert.ToDouble(bsonValue2.Value, CultureInfo.InvariantCulture));
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.String:
		{
			Newtonsoft.Json.Bson.BsonString bsonString = (Newtonsoft.Json.Bson.BsonString)t;
			WriteString((string)bsonString.Value, bsonString.ByteCount, bsonString.CalculatedSize - 4);
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Boolean:
		{
			Newtonsoft.Json.Bson.BsonBoolean bsonBoolean = (Newtonsoft.Json.Bson.BsonBoolean)t;
			_writer.Write((bool)bsonBoolean.Value);
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Date:
		{
			Newtonsoft.Json.Bson.BsonValue bsonValue = (Newtonsoft.Json.Bson.BsonValue)t;
			_writer.Write(TicksFromDateObject(bsonValue.Value));
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Binary:
		{
			Newtonsoft.Json.Bson.BsonBinary bsonBinary = (Newtonsoft.Json.Bson.BsonBinary)t;
			byte[] array = (byte[])bsonBinary.Value;
			_writer.Write(array.Length);
			_writer.Write((byte)bsonBinary.BinaryType);
			_writer.Write(array);
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Oid:
		{
			byte[] buffer = (byte[])((Newtonsoft.Json.Bson.BsonValue)t).Value;
			_writer.Write(buffer);
			break;
		}
		case Newtonsoft.Json.Bson.BsonType.Regex:
		{
			Newtonsoft.Json.Bson.BsonRegex bsonRegex = (Newtonsoft.Json.Bson.BsonRegex)t;
			WriteString((string)bsonRegex.Pattern.Value, bsonRegex.Pattern.ByteCount, null);
			WriteString((string)bsonRegex.Options.Value, bsonRegex.Options.ByteCount, null);
			break;
		}
		default:
			throw new ArgumentOutOfRangeException("t", "Unexpected token when writing BSON: {0}".FormatWith(CultureInfo.InvariantCulture, t.Type));
		case Newtonsoft.Json.Bson.BsonType.Undefined:
		case Newtonsoft.Json.Bson.BsonType.Null:
			break;
		}
	}

	private long TicksFromDateObject(object value)
	{
		if (value is DateTimeOffset dateTimeOffset)
		{
			return DateTimeUtils.ConvertDateTimeToJavaScriptTicks(dateTimeOffset.UtcDateTime, dateTimeOffset.Offset);
		}
		DateTime dateTime = (DateTime)value;
		if (DateTimeKindHandling == DateTimeKind.Utc)
		{
			dateTime = dateTime.ToUniversalTime();
		}
		else if (DateTimeKindHandling == DateTimeKind.Local)
		{
			dateTime = dateTime.ToLocalTime();
		}
		return DateTimeUtils.ConvertDateTimeToJavaScriptTicks(dateTime, convertToUtc: false);
	}

	private void WriteString(string s, int byteCount, int? calculatedlengthPrefix)
	{
		if (calculatedlengthPrefix.HasValue)
		{
			_writer.Write(calculatedlengthPrefix.GetValueOrDefault());
		}
		WriteUtf8Bytes(s, byteCount);
		_writer.Write((byte)0);
	}

	public void WriteUtf8Bytes(string s, int byteCount)
	{
		if (s == null)
		{
			return;
		}
		if (byteCount <= 256)
		{
			if (_largeByteBuffer == null)
			{
				_largeByteBuffer = new byte[256];
			}
			Encoding.GetBytes(s, 0, s.Length, _largeByteBuffer, 0);
			_writer.Write(_largeByteBuffer, 0, byteCount);
		}
		else
		{
			byte[] bytes = Encoding.GetBytes(s);
			_writer.Write(bytes);
		}
	}

	private int CalculateSize(int stringByteCount)
	{
		return stringByteCount + 1;
	}

	private int CalculateSizeWithLength(int stringByteCount, bool includeSize)
	{
		return ((!includeSize) ? 1 : 5) + stringByteCount;
	}

	private int CalculateSize(Newtonsoft.Json.Bson.BsonToken t)
	{
		switch (t.Type)
		{
		case Newtonsoft.Json.Bson.BsonType.Object:
		{
			Newtonsoft.Json.Bson.BsonObject bsonObject = (Newtonsoft.Json.Bson.BsonObject)t;
			int num4 = 4;
			foreach (Newtonsoft.Json.Bson.BsonProperty item in bsonObject)
			{
				int num5 = 1;
				num5 += CalculateSize(item.Name);
				num5 += CalculateSize(item.Value);
				num4 += num5;
			}
			return bsonObject.CalculatedSize = num4 + 1;
		}
		case Newtonsoft.Json.Bson.BsonType.Array:
		{
			Newtonsoft.Json.Bson.BsonArray bsonArray = (Newtonsoft.Json.Bson.BsonArray)t;
			int num2 = 4;
			ulong num3 = 0uL;
			foreach (Newtonsoft.Json.Bson.BsonToken item2 in bsonArray)
			{
				num2++;
				num2 += CalculateSize(MathUtils.IntLength(num3));
				num2 += CalculateSize(item2);
				num3++;
			}
			num2++;
			bsonArray.CalculatedSize = num2;
			return bsonArray.CalculatedSize;
		}
		case Newtonsoft.Json.Bson.BsonType.Integer:
			return 4;
		case Newtonsoft.Json.Bson.BsonType.Long:
			return 8;
		case Newtonsoft.Json.Bson.BsonType.Number:
			return 8;
		case Newtonsoft.Json.Bson.BsonType.String:
		{
			Newtonsoft.Json.Bson.BsonString bsonString = (Newtonsoft.Json.Bson.BsonString)t;
			string text = (string)bsonString.Value;
			bsonString.ByteCount = ((text != null) ? Encoding.GetByteCount(text) : 0);
			bsonString.CalculatedSize = CalculateSizeWithLength(bsonString.ByteCount, bsonString.IncludeLength);
			return bsonString.CalculatedSize;
		}
		case Newtonsoft.Json.Bson.BsonType.Boolean:
			return 1;
		case Newtonsoft.Json.Bson.BsonType.Undefined:
		case Newtonsoft.Json.Bson.BsonType.Null:
			return 0;
		case Newtonsoft.Json.Bson.BsonType.Date:
			return 8;
		case Newtonsoft.Json.Bson.BsonType.Binary:
		{
			Newtonsoft.Json.Bson.BsonBinary obj = (Newtonsoft.Json.Bson.BsonBinary)t;
			byte[] array = (byte[])obj.Value;
			obj.CalculatedSize = 5 + array.Length;
			return obj.CalculatedSize;
		}
		case Newtonsoft.Json.Bson.BsonType.Oid:
			return 12;
		case Newtonsoft.Json.Bson.BsonType.Regex:
		{
			Newtonsoft.Json.Bson.BsonRegex bsonRegex = (Newtonsoft.Json.Bson.BsonRegex)t;
			int num = 0;
			num += CalculateSize(bsonRegex.Pattern);
			num += CalculateSize(bsonRegex.Options);
			bsonRegex.CalculatedSize = num;
			return bsonRegex.CalculatedSize;
		}
		default:
			throw new ArgumentOutOfRangeException("t", "Unexpected token when writing BSON: {0}".FormatWith(CultureInfo.InvariantCulture, t.Type));
		}
	}
}
