using System.Threading.Tasks;

namespace System.Xml;

internal abstract class XmlRawWriter : XmlWriter
{
	protected XmlRawWriterBase64Encoder _base64Encoder;

	protected IXmlNamespaceResolver _resolver;

	public override WriteState WriteState
	{
		get
		{
			throw new InvalidOperationException("Xml_InvalidOperation");
		}
	}

	internal virtual IXmlNamespaceResolver NamespaceResolver
	{
		set
		{
			_resolver = value;
		}
	}

	internal virtual bool SupportsNamespaceDeclarationInChunks => false;

	public override void WriteStartDocument()
	{
		throw new InvalidOperationException("Xml_InvalidOperation");
	}

	public override void WriteStartDocument(bool standalone)
	{
		throw new InvalidOperationException("Xml_InvalidOperation");
	}

	public override void WriteEndDocument()
	{
		throw new InvalidOperationException("Xml_InvalidOperation");
	}

	public override void WriteDocType(string name, string pubid, string sysid, string subset)
	{
	}

	public override void WriteEndElement()
	{
		throw new InvalidOperationException("Xml_InvalidOperation");
	}

	public override void WriteFullEndElement()
	{
		throw new InvalidOperationException("Xml_InvalidOperation");
	}

	public override void WriteBase64(byte[] buffer, int index, int count)
	{
		if (_base64Encoder == null)
		{
			_base64Encoder = new XmlRawWriterBase64Encoder(this);
		}
		_base64Encoder.Encode(buffer, index, count);
	}

	public override string LookupPrefix(string ns)
	{
		throw new InvalidOperationException("Xml_InvalidOperation");
	}

	public override void WriteCData(string text)
	{
		WriteString(text);
	}

	public override void WriteCharEntity(char ch)
	{
		WriteString(char.ToString(ch));
	}

	public override void WriteSurrogateCharEntity(char lowChar, char highChar)
	{
		global::_003C_003Ey__InlineArray2<char> buffer = default(global::_003C_003Ey__InlineArray2<char>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<char>, char>(ref buffer, 0) = lowChar;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<char>, char>(ref buffer, 1) = highChar;
		WriteString(new string(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<char>, char>(in buffer, 2)));
	}

	public override void WriteWhitespace(string ws)
	{
		WriteString(ws);
	}

	public override void WriteChars(char[] buffer, int index, int count)
	{
		WriteString(new string(buffer, index, count));
	}

	public override void WriteRaw(char[] buffer, int index, int count)
	{
		WriteString(new string(buffer, index, count));
	}

	public override void WriteRaw(string data)
	{
		WriteString(data);
	}

	public override void WriteValue(string value)
	{
		WriteString(value);
	}

	public override void WriteAttributes(XmlReader reader, bool defattr)
	{
		throw new InvalidOperationException("Xml_InvalidOperation");
	}

	public override void WriteNode(XmlReader reader, bool defattr)
	{
		throw new InvalidOperationException("Xml_InvalidOperation");
	}

	internal virtual void WriteXmlDeclaration(XmlStandalone standalone)
	{
	}

	internal virtual void WriteXmlDeclaration(string xmldecl)
	{
	}

	internal abstract void StartElementContent();

	internal virtual void OnRootElement(ConformanceLevel conformanceLevel)
	{
	}

	internal abstract void WriteEndElement(string prefix, string localName, string ns);

	internal virtual void WriteFullEndElement(string prefix, string localName, string ns)
	{
		WriteEndElement(prefix, localName, ns);
	}

	internal abstract void WriteNamespaceDeclaration(string prefix, string ns);

	internal virtual void WriteStartNamespaceDeclaration(string prefix)
	{
		throw new NotSupportedException();
	}

	internal virtual void WriteEndNamespaceDeclaration()
	{
		throw new NotSupportedException();
	}

	internal virtual void WriteEndBase64()
	{
		_base64Encoder.Flush();
	}

	internal virtual void Close(WriteState currentState)
	{
		Close();
	}

	public override Task WriteStartDocumentAsync()
	{
		throw new InvalidOperationException("Xml_InvalidOperation");
	}

	public override Task WriteEndElementAsync()
	{
		throw new InvalidOperationException("Xml_InvalidOperation");
	}

	public override Task WriteCharEntityAsync(char ch)
	{
		return WriteStringAsync(char.ToString(ch));
	}

	public override Task WriteSurrogateCharEntityAsync(char lowChar, char highChar)
	{
		global::_003C_003Ey__InlineArray2<char> buffer = default(global::_003C_003Ey__InlineArray2<char>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<char>, char>(ref buffer, 0) = lowChar;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<char>, char>(ref buffer, 1) = highChar;
		return WriteStringAsync(new string(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<char>, char>(in buffer, 2)));
	}

	public override Task WriteWhitespaceAsync(string ws)
	{
		return WriteStringAsync(ws);
	}

	public override Task WriteCharsAsync(char[] buffer, int index, int count)
	{
		return WriteStringAsync(new string(buffer, index, count));
	}

	public override Task WriteRawAsync(char[] buffer, int index, int count)
	{
		return WriteStringAsync(new string(buffer, index, count));
	}

	public override Task WriteRawAsync(string data)
	{
		return WriteStringAsync(data);
	}

	internal virtual Task WriteXmlDeclarationAsync(XmlStandalone standalone)
	{
		return Task.CompletedTask;
	}

	internal virtual Task WriteEndElementAsync(string prefix, string localName, string ns)
	{
		throw new NotImplementedException();
	}

	internal virtual Task WriteNamespaceDeclarationAsync(string prefix, string ns)
	{
		throw new NotImplementedException();
	}

	internal virtual Task WriteStartNamespaceDeclarationAsync(string prefix)
	{
		throw new NotSupportedException();
	}

	internal virtual Task WriteEndNamespaceDeclarationAsync()
	{
		throw new NotSupportedException();
	}

	internal virtual Task WriteEndBase64Async()
	{
		return _base64Encoder.FlushAsync();
	}

	internal virtual ValueTask DisposeAsyncCore(WriteState currentState)
	{
		return DisposeAsyncCore();
	}
}
