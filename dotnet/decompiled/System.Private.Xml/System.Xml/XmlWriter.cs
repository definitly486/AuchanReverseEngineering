using System.IO;
using System.Threading.Tasks;

namespace System.Xml;

public abstract class XmlWriter : IDisposable, IAsyncDisposable
{
	private char[] _writeNodeBuffer;

	public abstract WriteState WriteState { get; }

	public abstract void WriteStartDocument();

	public abstract void WriteStartDocument(bool standalone);

	public abstract void WriteEndDocument();

	public abstract void WriteDocType(string name, string? pubid, string? sysid, string? subset);

	public void WriteStartElement(string localName, string? ns)
	{
		WriteStartElement(null, localName, ns);
	}

	public abstract void WriteStartElement(string? prefix, string localName, string? ns);

	public void WriteStartElement(string localName)
	{
		WriteStartElement(null, localName, null);
	}

	public abstract void WriteEndElement();

	public abstract void WriteFullEndElement();

	public void WriteAttributeString(string localName, string? ns, string? value)
	{
		WriteStartAttribute(null, localName, ns);
		WriteString(value);
		WriteEndAttribute();
	}

	public void WriteAttributeString(string localName, string? value)
	{
		WriteStartAttribute(null, localName, null);
		WriteString(value);
		WriteEndAttribute();
	}

	public void WriteAttributeString(string? prefix, string localName, string? ns, string? value)
	{
		WriteStartAttribute(prefix, localName, ns);
		WriteString(value);
		WriteEndAttribute();
	}

	public void WriteStartAttribute(string localName, string? ns)
	{
		WriteStartAttribute(null, localName, ns);
	}

	public abstract void WriteStartAttribute(string? prefix, string localName, string? ns);

	public void WriteStartAttribute(string localName)
	{
		WriteStartAttribute(null, localName, null);
	}

	public abstract void WriteEndAttribute();

	public abstract void WriteCData(string? text);

	public abstract void WriteComment(string? text);

	public abstract void WriteProcessingInstruction(string name, string? text);

	public abstract void WriteEntityRef(string name);

	public abstract void WriteCharEntity(char ch);

	public abstract void WriteWhitespace(string? ws);

	public abstract void WriteString(string? text);

	public abstract void WriteSurrogateCharEntity(char lowChar, char highChar);

	public abstract void WriteChars(char[] buffer, int index, int count);

	public abstract void WriteRaw(char[] buffer, int index, int count);

	public abstract void WriteRaw(string data);

	public abstract void WriteBase64(byte[] buffer, int index, int count);

	public virtual void WriteBinHex(byte[] buffer, int index, int count)
	{
		BinHexEncoder.Encode(buffer, index, count, this);
	}

	public virtual void Close()
	{
	}

	public abstract void Flush();

	public abstract string? LookupPrefix(string ns);

	public virtual void WriteValue(string? value)
	{
		if (value != null)
		{
			WriteString(value);
		}
	}

	public virtual void WriteAttributes(XmlReader reader, bool defattr)
	{
		ArgumentNullException.ThrowIfNull(reader, "reader");
		XmlNodeType nodeType = reader.NodeType;
		if ((nodeType == XmlNodeType.Element || nodeType == XmlNodeType.XmlDeclaration) ? true : false)
		{
			if (reader.MoveToFirstAttribute())
			{
				WriteAttributes(reader, defattr);
				reader.MoveToElement();
			}
			return;
		}
		if (reader.NodeType != XmlNodeType.Attribute)
		{
			throw new XmlException("Xml_InvalidPosition", string.Empty);
		}
		do
		{
			if (!defattr && reader.IsDefaultInternal)
			{
				continue;
			}
			WriteStartAttribute(reader.Prefix, reader.LocalName, reader.NamespaceURI);
			while (reader.ReadAttributeValue())
			{
				if (reader.NodeType == XmlNodeType.EntityReference)
				{
					WriteEntityRef(reader.Name);
				}
				else
				{
					WriteString(reader.Value);
				}
			}
			WriteEndAttribute();
		}
		while (reader.MoveToNextAttribute());
	}

	public virtual void WriteNode(XmlReader reader, bool defattr)
	{
		ArgumentNullException.ThrowIfNull(reader, "reader");
		bool canReadValueChunk = reader.CanReadValueChunk;
		int num = ((reader.NodeType == XmlNodeType.None) ? (-1) : reader.Depth);
		do
		{
			switch (reader.NodeType)
			{
			case XmlNodeType.Element:
				WriteStartElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
				WriteAttributes(reader, defattr);
				if (reader.IsEmptyElement)
				{
					WriteEndElement();
				}
				break;
			case XmlNodeType.Text:
				if (canReadValueChunk)
				{
					if (_writeNodeBuffer == null)
					{
						_writeNodeBuffer = new char[1024];
					}
					int count;
					while ((count = reader.ReadValueChunk(_writeNodeBuffer, 0, 1024)) > 0)
					{
						WriteChars(_writeNodeBuffer, 0, count);
					}
				}
				else
				{
					WriteString(reader.Value);
				}
				break;
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
				WriteWhitespace(reader.Value);
				break;
			case XmlNodeType.CDATA:
				WriteCData(reader.Value);
				break;
			case XmlNodeType.EntityReference:
				WriteEntityRef(reader.Name);
				break;
			case XmlNodeType.ProcessingInstruction:
			case XmlNodeType.XmlDeclaration:
				WriteProcessingInstruction(reader.Name, reader.Value);
				break;
			case XmlNodeType.DocumentType:
				WriteDocType(reader.Name, reader.GetAttribute("PUBLIC"), reader.GetAttribute("SYSTEM"), reader.Value);
				break;
			case XmlNodeType.Comment:
				WriteComment(reader.Value);
				break;
			case XmlNodeType.EndElement:
				WriteFullEndElement();
				break;
			}
		}
		while (reader.Read() && (num < reader.Depth || (num == reader.Depth && reader.NodeType == XmlNodeType.EndElement)));
	}

	public void WriteElementString(string localName, string? ns, string? value)
	{
		WriteStartElement(localName, ns);
		if (!string.IsNullOrEmpty(value))
		{
			WriteString(value);
		}
		WriteEndElement();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing && WriteState != WriteState.Closed)
		{
			Close();
		}
	}

	public static XmlWriter Create(Stream output)
	{
		ArgumentNullException.ThrowIfNull(output, "output");
		XmlWriterSettings s_defaultWriterSettings = XmlWriterSettings.s_defaultWriterSettings;
		return new XmlWellFormedWriter(new XmlUtf8RawTextWriter(output, s_defaultWriterSettings), s_defaultWriterSettings);
	}

	public static XmlWriter Create(Stream output, XmlWriterSettings? settings)
	{
		if (settings == null)
		{
			settings = XmlWriterSettings.s_defaultWriterSettings;
		}
		return settings.CreateWriter(output);
	}

	public static XmlWriter Create(TextWriter output, XmlWriterSettings? settings)
	{
		if (settings == null)
		{
			settings = XmlWriterSettings.s_defaultWriterSettings;
		}
		return settings.CreateWriter(output);
	}

	public virtual Task WriteStartDocumentAsync()
	{
		throw new NotImplementedException();
	}

	public virtual Task WriteEndElementAsync()
	{
		throw new NotImplementedException();
	}

	protected internal virtual Task WriteStartAttributeAsync(string? prefix, string localName, string? ns)
	{
		throw new NotImplementedException();
	}

	protected internal virtual Task WriteEndAttributeAsync()
	{
		throw new NotImplementedException();
	}

	public virtual Task WriteEntityRefAsync(string name)
	{
		throw new NotImplementedException();
	}

	public virtual Task WriteCharEntityAsync(char ch)
	{
		throw new NotImplementedException();
	}

	public virtual Task WriteWhitespaceAsync(string? ws)
	{
		throw new NotImplementedException();
	}

	public virtual Task WriteStringAsync(string? text)
	{
		throw new NotImplementedException();
	}

	public virtual Task WriteSurrogateCharEntityAsync(char lowChar, char highChar)
	{
		throw new NotImplementedException();
	}

	public virtual Task WriteCharsAsync(char[] buffer, int index, int count)
	{
		throw new NotImplementedException();
	}

	public virtual Task WriteRawAsync(char[] buffer, int index, int count)
	{
		throw new NotImplementedException();
	}

	public virtual Task WriteRawAsync(string data)
	{
		throw new NotImplementedException();
	}

	public virtual Task FlushAsync()
	{
		throw new NotImplementedException();
	}

	public async ValueTask DisposeAsync()
	{
		await DisposeAsyncCore().ConfigureAwait(continueOnCapturedContext: false);
		Dispose(disposing: false);
		GC.SuppressFinalize(this);
	}

	protected virtual ValueTask DisposeAsyncCore()
	{
		if (WriteState != WriteState.Closed)
		{
			Dispose(disposing: true);
		}
		return default(ValueTask);
	}
}
