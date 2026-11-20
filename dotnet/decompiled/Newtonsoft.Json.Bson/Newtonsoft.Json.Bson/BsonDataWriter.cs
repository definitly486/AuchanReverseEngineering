using System;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson.Utilities;

namespace Newtonsoft.Json.Bson;

public class BsonDataWriter : JsonWriter
{
	private readonly bool _safeAsync;

	private bool _finishingAsync;

	private readonly Newtonsoft.Json.Bson.BsonBinaryWriter _writer;

	private Newtonsoft.Json.Bson.BsonToken _root;

	private Newtonsoft.Json.Bson.BsonToken _parent;

	private string _propertyName;

	public override Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!_safeAsync)
		{
			return base.FlushAsync(cancellationToken);
		}
		return _writer.FlushAsync(cancellationToken);
	}

	public override Task WriteEndAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!_safeAsync || base.Top != 1)
		{
			return base.WriteEndAsync(cancellationToken);
		}
		return CompleteAsync(cancellationToken);
	}

	private bool WillCloseAll(Newtonsoft.Json.Bson.BsonType type)
	{
		if (type != _root.Type)
		{
			return false;
		}
		for (Newtonsoft.Json.Bson.BsonToken parent = _parent; parent != _root; parent = parent.Parent)
		{
			if (parent.Type == type)
			{
				return false;
			}
		}
		return true;
	}

	public override Task WriteEndArrayAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!_safeAsync || !WillCloseAll(Newtonsoft.Json.Bson.BsonType.Array))
		{
			return base.WriteEndArrayAsync(cancellationToken);
		}
		return CompleteAsync(cancellationToken);
	}

	public override Task WriteEndObjectAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!_safeAsync || !WillCloseAll(Newtonsoft.Json.Bson.BsonType.Object))
		{
			return base.WriteEndObjectAsync(cancellationToken);
		}
		return CompleteAsync(cancellationToken);
	}

	public override Task CloseAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		if (_safeAsync)
		{
			if (base.AutoCompleteOnClose)
			{
				if (base.CloseOutput)
				{
					return CompleteAndCloseOutputAsync(cancellationToken);
				}
				return CompleteAsync(cancellationToken);
			}
			if (base.CloseOutput)
			{
				_writer?.Close();
			}
			return AsyncUtils.CompletedTask;
		}
		return base.CloseAsync(cancellationToken);
	}

	private Task CompleteAsync(CancellationToken cancellationToken)
	{
		if (cancellationToken.IsCancellationRequested)
		{
			return cancellationToken.FromCanceled();
		}
		int top = base.Top;
		if (top == 0)
		{
			return AsyncUtils.CompletedTask;
		}
		_finishingAsync = true;
		try
		{
			while (top-- != 0)
			{
				WriteEnd();
			}
		}
		finally
		{
			_finishingAsync = false;
		}
		return _writer.WriteTokenAsync(_root, cancellationToken);
	}

	private async Task CompleteAndCloseOutputAsync(CancellationToken cancellationToken)
	{
		await CompleteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		_writer?.Close();
	}

	public BsonDataWriter(Stream stream)
	{
		ValidationUtils.ArgumentNotNull(stream, "stream");
		if (GetType() == typeof(BsonDataWriter))
		{
			_safeAsync = true;
			_writer = new Newtonsoft.Json.Bson.BsonBinaryWriter(new AsyncBinaryWriter(stream));
		}
		else
		{
			_writer = new Newtonsoft.Json.Bson.BsonBinaryWriter(new BinaryWriter(stream));
		}
	}

	public override void Flush()
	{
		_writer.Flush();
	}

	protected override void WriteEnd(JsonToken token)
	{
		base.WriteEnd(token);
		RemoveParent();
		if (!_finishingAsync && base.Top == 0)
		{
			_writer.WriteToken(_root);
		}
	}

	public override void WriteComment(string text)
	{
		throw ExceptionUtils.CreateJsonWriterException(this, "Cannot write JSON comment as BSON.", null);
	}

	public override void WriteStartConstructor(string name)
	{
		throw ExceptionUtils.CreateJsonWriterException(this, "Cannot write JSON constructor as BSON.", null);
	}

	public override void WriteRaw(string json)
	{
		throw ExceptionUtils.CreateJsonWriterException(this, "Cannot write raw JSON as BSON.", null);
	}

	public override void WriteRawValue(string json)
	{
		throw ExceptionUtils.CreateJsonWriterException(this, "Cannot write raw JSON as BSON.", null);
	}

	public override void WriteStartArray()
	{
		base.WriteStartArray();
		AddParent(new Newtonsoft.Json.Bson.BsonArray());
	}

	public override void WriteStartObject()
	{
		base.WriteStartObject();
		AddParent(new Newtonsoft.Json.Bson.BsonObject());
	}

	public override void WritePropertyName(string name)
	{
		if (name != null && name.Contains("\0"))
		{
			throw ExceptionUtils.CreateJsonWriterException(this, "Property name must not contain a null byte.", null);
		}
		base.WritePropertyName(name);
		_propertyName = name;
	}

	public override void Close()
	{
		base.Close();
		if (base.CloseOutput)
		{
			_writer?.Close();
		}
	}

	private void AddParent(Newtonsoft.Json.Bson.BsonToken container)
	{
		AddToken(container);
		_parent = container;
	}

	private void RemoveParent()
	{
		_parent = _parent.Parent;
	}

	private void AddValue(object value, Newtonsoft.Json.Bson.BsonType type)
	{
		AddToken(new Newtonsoft.Json.Bson.BsonValue(value, type));
	}

	internal void AddToken(Newtonsoft.Json.Bson.BsonToken token)
	{
		if (_parent != null)
		{
			if (_parent is Newtonsoft.Json.Bson.BsonObject bsonObject)
			{
				bsonObject.Add(_propertyName, token);
				_propertyName = null;
			}
			else
			{
				((Newtonsoft.Json.Bson.BsonArray)_parent).Add(token);
			}
			return;
		}
		if (token.Type != Newtonsoft.Json.Bson.BsonType.Object && token.Type != Newtonsoft.Json.Bson.BsonType.Array)
		{
			throw ExceptionUtils.CreateJsonWriterException(this, "Error writing {0} value. BSON must start with an Object or Array.".FormatWith(CultureInfo.InvariantCulture, token.Type), null);
		}
		_parent = token;
		_root = token;
	}

	public override void WriteValue(object value)
	{
		if (value is BigInteger)
		{
			SetWriteState(JsonToken.Integer, null);
			AddToken(new Newtonsoft.Json.Bson.BsonBinary(((BigInteger)value).ToByteArray(), Newtonsoft.Json.Bson.BsonBinaryType.Binary));
		}
		else
		{
			base.WriteValue(value);
		}
	}

	public override void WriteNull()
	{
		base.WriteNull();
		AddToken(new Newtonsoft.Json.Bson.BsonEmpty(Newtonsoft.Json.Bson.BsonType.Null));
	}

	public override void WriteUndefined()
	{
		base.WriteUndefined();
		AddToken(new Newtonsoft.Json.Bson.BsonEmpty(Newtonsoft.Json.Bson.BsonType.Undefined));
	}

	public override void WriteValue(string value)
	{
		base.WriteValue(value);
		AddToken((value == null) ? ((Newtonsoft.Json.Bson.BsonToken)new Newtonsoft.Json.Bson.BsonEmpty(Newtonsoft.Json.Bson.BsonType.Null)) : ((Newtonsoft.Json.Bson.BsonToken)new Newtonsoft.Json.Bson.BsonString(value, includeLength: true)));
	}

	public override void WriteValue(int value)
	{
		base.WriteValue(value);
		AddValue(value, Newtonsoft.Json.Bson.BsonType.Integer);
	}

	[CLSCompliant(false)]
	public override void WriteValue(uint value)
	{
		if (value > int.MaxValue)
		{
			throw ExceptionUtils.CreateJsonWriterException(this, "Value is too large to fit in a signed 32 bit integer. BSON does not support unsigned values.", null);
		}
		base.WriteValue(value);
		AddValue(value, Newtonsoft.Json.Bson.BsonType.Integer);
	}

	public override void WriteValue(long value)
	{
		base.WriteValue(value);
		AddValue(value, Newtonsoft.Json.Bson.BsonType.Long);
	}

	[CLSCompliant(false)]
	public override void WriteValue(ulong value)
	{
		if (value > long.MaxValue)
		{
			throw ExceptionUtils.CreateJsonWriterException(this, "Value is too large to fit in a signed 64 bit integer. BSON does not support unsigned values.", null);
		}
		base.WriteValue(value);
		AddValue(value, Newtonsoft.Json.Bson.BsonType.Long);
	}

	public override void WriteValue(float value)
	{
		base.WriteValue(value);
		AddValue(value, Newtonsoft.Json.Bson.BsonType.Number);
	}

	public override void WriteValue(double value)
	{
		base.WriteValue(value);
		AddValue(value, Newtonsoft.Json.Bson.BsonType.Number);
	}

	public override void WriteValue(bool value)
	{
		base.WriteValue(value);
		AddToken(value ? new Newtonsoft.Json.Bson.BsonBoolean(value: true) : new Newtonsoft.Json.Bson.BsonBoolean(value: false));
	}

	public override void WriteValue(short value)
	{
		base.WriteValue(value);
		AddValue(value, Newtonsoft.Json.Bson.BsonType.Integer);
	}

	[CLSCompliant(false)]
	public override void WriteValue(ushort value)
	{
		base.WriteValue(value);
		AddValue(value, Newtonsoft.Json.Bson.BsonType.Integer);
	}

	public override void WriteValue(char value)
	{
		base.WriteValue(value);
		string text = null;
		text = value.ToString(CultureInfo.InvariantCulture);
		AddToken(new Newtonsoft.Json.Bson.BsonString(text, includeLength: true));
	}

	public override void WriteValue(byte value)
	{
		base.WriteValue(value);
		AddValue(value, Newtonsoft.Json.Bson.BsonType.Integer);
	}

	[CLSCompliant(false)]
	public override void WriteValue(sbyte value)
	{
		base.WriteValue(value);
		AddValue(value, Newtonsoft.Json.Bson.BsonType.Integer);
	}

	public override void WriteValue(decimal value)
	{
		base.WriteValue(value);
		AddValue(value, Newtonsoft.Json.Bson.BsonType.Number);
	}

	public override void WriteValue(DateTime value)
	{
		base.WriteValue(value);
		value = DateTimeUtils.EnsureDateTime(value, base.DateTimeZoneHandling);
		AddValue(value, Newtonsoft.Json.Bson.BsonType.Date);
	}

	public override void WriteValue(DateTimeOffset value)
	{
		base.WriteValue(value);
		AddValue(value, Newtonsoft.Json.Bson.BsonType.Date);
	}

	public override void WriteValue(byte[] value)
	{
		if (value == null)
		{
			WriteNull();
			return;
		}
		base.WriteValue(value);
		AddToken(new Newtonsoft.Json.Bson.BsonBinary(value, Newtonsoft.Json.Bson.BsonBinaryType.Binary));
	}

	public override void WriteValue(Guid value)
	{
		base.WriteValue(value);
		AddToken(new Newtonsoft.Json.Bson.BsonBinary(value.ToByteArray(), Newtonsoft.Json.Bson.BsonBinaryType.Uuid));
	}

	public override void WriteValue(TimeSpan value)
	{
		base.WriteValue(value);
		AddToken(new Newtonsoft.Json.Bson.BsonString(value.ToString(), includeLength: true));
	}

	public override void WriteValue(Uri value)
	{
		if (value == null)
		{
			WriteNull();
			return;
		}
		base.WriteValue(value);
		AddToken(new Newtonsoft.Json.Bson.BsonString(value.ToString(), includeLength: true));
	}
}
