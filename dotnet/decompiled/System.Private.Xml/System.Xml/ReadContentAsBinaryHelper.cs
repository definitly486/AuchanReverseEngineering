namespace System.Xml;

internal sealed class ReadContentAsBinaryHelper
{
	private enum State
	{
		None,
		InReadContent,
		InReadElementContent
	}

	private readonly XmlReader _reader;

	private State _state;

	private int _valueOffset;

	private bool _isEnd;

	private readonly bool _canReadValueChunk;

	private readonly char[] _valueChunk;

	private int _valueChunkLength;

	private IncrementalReadDecoder _decoder;

	private Base64Decoder _base64Decoder;

	private BinHexDecoder _binHexDecoder;

	internal ReadContentAsBinaryHelper(XmlReader reader)
	{
		_reader = reader;
		_canReadValueChunk = reader.CanReadValueChunk;
		if (_canReadValueChunk)
		{
			_valueChunk = new char[256];
		}
	}

	internal static ReadContentAsBinaryHelper CreateOrReset(ReadContentAsBinaryHelper helper, XmlReader reader)
	{
		if (helper == null)
		{
			return new ReadContentAsBinaryHelper(reader);
		}
		helper.Reset();
		return helper;
	}

	internal int ReadElementContentAsBase64(byte[] buffer, int index, int count)
	{
		ArgumentNullException.ThrowIfNull(buffer, "buffer");
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		ArgumentOutOfRangeException.ThrowIfNegative(index, "index");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(count, buffer.Length - index, "count");
		switch (_state)
		{
		case State.None:
			if (_reader.NodeType != XmlNodeType.Element)
			{
				throw _reader.CreateReadElementContentAsException("ReadElementContentAsBase64");
			}
			if (!InitOnElement())
			{
				return 0;
			}
			break;
		case State.InReadContent:
			throw new InvalidOperationException("Xml_MixingBinaryContentMethods");
		case State.InReadElementContent:
			if (_decoder == _base64Decoder)
			{
				return ReadElementContentAsBinary(buffer, index, count);
			}
			break;
		default:
			return 0;
		}
		InitBase64Decoder();
		return ReadElementContentAsBinary(buffer, index, count);
	}

	internal int ReadElementContentAsBinHex(byte[] buffer, int index, int count)
	{
		ArgumentNullException.ThrowIfNull(buffer, "buffer");
		ArgumentOutOfRangeException.ThrowIfNegative(count, "count");
		ArgumentOutOfRangeException.ThrowIfNegative(index, "index");
		ArgumentOutOfRangeException.ThrowIfGreaterThan(count, buffer.Length - index, "count");
		switch (_state)
		{
		case State.None:
			if (_reader.NodeType != XmlNodeType.Element)
			{
				throw _reader.CreateReadElementContentAsException("ReadElementContentAsBinHex");
			}
			if (!InitOnElement())
			{
				return 0;
			}
			break;
		case State.InReadContent:
			throw new InvalidOperationException("Xml_MixingBinaryContentMethods");
		case State.InReadElementContent:
			if (_decoder == _binHexDecoder)
			{
				return ReadElementContentAsBinary(buffer, index, count);
			}
			break;
		default:
			return 0;
		}
		InitBinHexDecoder();
		return ReadElementContentAsBinary(buffer, index, count);
	}

	internal void Finish()
	{
		if (_state != State.None)
		{
			while (MoveToNextContentNode(moveIfOnContentNode: true))
			{
			}
			if (_state == State.InReadElementContent)
			{
				if (_reader.NodeType != XmlNodeType.EndElement)
				{
					throw new XmlException("Xml_InvalidNodeType", _reader.NodeType.ToString(), _reader as IXmlLineInfo);
				}
				_reader.Read();
			}
		}
		Reset();
	}

	internal void Reset()
	{
		_state = State.None;
		_isEnd = false;
		_valueOffset = 0;
	}

	private bool InitOnElement()
	{
		bool isEmptyElement = _reader.IsEmptyElement;
		_reader.Read();
		if (isEmptyElement)
		{
			return false;
		}
		if (!MoveToNextContentNode(moveIfOnContentNode: false))
		{
			if (_reader.NodeType != XmlNodeType.EndElement)
			{
				throw new XmlException("Xml_InvalidNodeType", _reader.NodeType.ToString(), _reader as IXmlLineInfo);
			}
			_reader.Read();
			return false;
		}
		_state = State.InReadElementContent;
		_isEnd = false;
		return true;
	}

	private void InitBase64Decoder()
	{
		if (_base64Decoder == null)
		{
			_base64Decoder = new Base64Decoder();
		}
		else
		{
			_base64Decoder.Reset();
		}
		_decoder = _base64Decoder;
	}

	private void InitBinHexDecoder()
	{
		if (_binHexDecoder == null)
		{
			_binHexDecoder = new BinHexDecoder();
		}
		else
		{
			_binHexDecoder.Reset();
		}
		_decoder = _binHexDecoder;
	}

	private int ReadContentAsBinary(byte[] buffer, int index, int count)
	{
		if (_isEnd)
		{
			Reset();
			return 0;
		}
		_decoder.SetNextOutputBuffer(buffer, index, count);
		do
		{
			if (_canReadValueChunk)
			{
				while (true)
				{
					if (_valueOffset < _valueChunkLength)
					{
						int num = _decoder.Decode(_valueChunk, _valueOffset, _valueChunkLength - _valueOffset);
						_valueOffset += num;
					}
					if (_decoder.IsFull)
					{
						return _decoder.DecodedCount;
					}
					if ((_valueChunkLength = _reader.ReadValueChunk(_valueChunk, 0, 256)) == 0)
					{
						break;
					}
					_valueOffset = 0;
				}
			}
			else
			{
				string value = _reader.Value;
				int num2 = _decoder.Decode(value, _valueOffset, value.Length - _valueOffset);
				_valueOffset += num2;
				if (_decoder.IsFull)
				{
					return _decoder.DecodedCount;
				}
			}
			_valueOffset = 0;
		}
		while (MoveToNextContentNode(moveIfOnContentNode: true));
		_isEnd = true;
		return _decoder.DecodedCount;
	}

	private int ReadElementContentAsBinary(byte[] buffer, int index, int count)
	{
		if (count == 0)
		{
			return 0;
		}
		int num = ReadContentAsBinary(buffer, index, count);
		if (num > 0)
		{
			return num;
		}
		if (_reader.NodeType != XmlNodeType.EndElement)
		{
			throw new XmlException("Xml_InvalidNodeType", _reader.NodeType.ToString(), _reader as IXmlLineInfo);
		}
		_reader.Read();
		_state = State.None;
		return 0;
	}

	private bool MoveToNextContentNode(bool moveIfOnContentNode)
	{
		do
		{
			switch (_reader.NodeType)
			{
			case XmlNodeType.Attribute:
				return !moveIfOnContentNode;
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
				if (!moveIfOnContentNode)
				{
					return true;
				}
				goto IL_0078;
			case XmlNodeType.EntityReference:
				if (!_reader.CanResolveEntity)
				{
					break;
				}
				_reader.ResolveEntity();
				goto IL_0078;
			case XmlNodeType.ProcessingInstruction:
			case XmlNodeType.Comment:
			case XmlNodeType.EndEntity:
				goto IL_0078;
			}
			return false;
			IL_0078:
			moveIfOnContentNode = false;
		}
		while (_reader.Read());
		return false;
	}
}
