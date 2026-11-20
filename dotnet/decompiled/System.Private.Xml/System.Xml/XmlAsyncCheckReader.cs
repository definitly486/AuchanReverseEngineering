using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace System.Xml;

[DefaultMember("Item")]
internal class XmlAsyncCheckReader : XmlReader
{
	private readonly XmlReader _coreReader;

	private Task _lastTask = Task.CompletedTask;

	public override XmlReaderSettings Settings
	{
		get
		{
			XmlReaderSettings settings = _coreReader.Settings;
			settings = ((settings == null) ? new XmlReaderSettings() : settings.Clone());
			settings.Async = true;
			settings.ReadOnly = true;
			return settings;
		}
	}

	public override XmlNodeType NodeType
	{
		get
		{
			CheckAsync();
			return _coreReader.NodeType;
		}
	}

	public override string Name
	{
		get
		{
			CheckAsync();
			return _coreReader.Name;
		}
	}

	public override string LocalName
	{
		get
		{
			CheckAsync();
			return _coreReader.LocalName;
		}
	}

	public override string NamespaceURI
	{
		get
		{
			CheckAsync();
			return _coreReader.NamespaceURI;
		}
	}

	public override string Prefix
	{
		get
		{
			CheckAsync();
			return _coreReader.Prefix;
		}
	}

	public override string Value
	{
		get
		{
			CheckAsync();
			return _coreReader.Value;
		}
	}

	public override int Depth
	{
		get
		{
			CheckAsync();
			return _coreReader.Depth;
		}
	}

	public override string BaseURI
	{
		get
		{
			CheckAsync();
			return _coreReader.BaseURI;
		}
	}

	public override bool IsEmptyElement
	{
		get
		{
			CheckAsync();
			return _coreReader.IsEmptyElement;
		}
	}

	public override bool IsDefault
	{
		get
		{
			CheckAsync();
			return _coreReader.IsDefault;
		}
	}

	public override char QuoteChar
	{
		get
		{
			CheckAsync();
			return _coreReader.QuoteChar;
		}
	}

	public override XmlSpace XmlSpace
	{
		get
		{
			CheckAsync();
			return _coreReader.XmlSpace;
		}
	}

	public override string XmlLang
	{
		get
		{
			CheckAsync();
			return _coreReader.XmlLang;
		}
	}

	public override IXmlSchemaInfo SchemaInfo
	{
		get
		{
			CheckAsync();
			return _coreReader.SchemaInfo;
		}
	}

	public override Type ValueType
	{
		get
		{
			CheckAsync();
			return _coreReader.ValueType;
		}
	}

	public override int AttributeCount
	{
		get
		{
			CheckAsync();
			return _coreReader.AttributeCount;
		}
	}

	public override bool EOF
	{
		get
		{
			CheckAsync();
			return _coreReader.EOF;
		}
	}

	public override ReadState ReadState
	{
		get
		{
			CheckAsync();
			return _coreReader.ReadState;
		}
	}

	public override XmlNameTable NameTable
	{
		get
		{
			CheckAsync();
			return _coreReader.NameTable;
		}
	}

	public override bool CanResolveEntity
	{
		get
		{
			CheckAsync();
			return _coreReader.CanResolveEntity;
		}
	}

	public override bool CanReadBinaryContent
	{
		get
		{
			CheckAsync();
			return _coreReader.CanReadBinaryContent;
		}
	}

	public override bool CanReadValueChunk
	{
		get
		{
			CheckAsync();
			return _coreReader.CanReadValueChunk;
		}
	}

	public override bool HasAttributes
	{
		get
		{
			CheckAsync();
			return _coreReader.HasAttributes;
		}
	}

	internal override XmlNamespaceManager NamespaceManager
	{
		get
		{
			CheckAsync();
			return _coreReader.NamespaceManager;
		}
	}

	internal override IDtdInfo DtdInfo
	{
		get
		{
			CheckAsync();
			return _coreReader.DtdInfo;
		}
	}

	public static XmlAsyncCheckReader CreateAsyncCheckWrapper(XmlReader reader)
	{
		if (reader is IXmlLineInfo)
		{
			if (reader is IXmlNamespaceResolver)
			{
				if (reader is IXmlSchemaInfo)
				{
					return new XmlAsyncCheckReaderWithLineInfoNSSchema(reader);
				}
				return new XmlAsyncCheckReaderWithLineInfoNS(reader);
			}
			return new XmlAsyncCheckReaderWithLineInfo(reader);
		}
		if (reader is IXmlNamespaceResolver)
		{
			return new XmlAsyncCheckReaderWithNS(reader);
		}
		return new XmlAsyncCheckReader(reader);
	}

	public XmlAsyncCheckReader(XmlReader reader)
	{
		_coreReader = reader;
	}

	private void CheckAsync()
	{
		if (!_lastTask.IsCompleted)
		{
			throw new InvalidOperationException("Xml_AsyncIsRunningException");
		}
	}

	public override string ReadContentAsString()
	{
		CheckAsync();
		return _coreReader.ReadContentAsString();
	}

	public override string ReadElementContentAsString()
	{
		CheckAsync();
		return _coreReader.ReadElementContentAsString();
	}

	public override string ReadElementContentAsString(string localName, string namespaceURI)
	{
		CheckAsync();
		return _coreReader.ReadElementContentAsString(localName, namespaceURI);
	}

	public override string GetAttribute(string name)
	{
		CheckAsync();
		return _coreReader.GetAttribute(name);
	}

	public override string GetAttribute(string name, string namespaceURI)
	{
		CheckAsync();
		return _coreReader.GetAttribute(name, namespaceURI);
	}

	public override string GetAttribute(int i)
	{
		CheckAsync();
		return _coreReader.GetAttribute(i);
	}

	public override bool MoveToAttribute(string name)
	{
		CheckAsync();
		return _coreReader.MoveToAttribute(name);
	}

	public override bool MoveToAttribute(string name, string ns)
	{
		CheckAsync();
		return _coreReader.MoveToAttribute(name, ns);
	}

	public override void MoveToAttribute(int i)
	{
		CheckAsync();
		_coreReader.MoveToAttribute(i);
	}

	public override bool MoveToFirstAttribute()
	{
		CheckAsync();
		return _coreReader.MoveToFirstAttribute();
	}

	public override bool MoveToNextAttribute()
	{
		CheckAsync();
		return _coreReader.MoveToNextAttribute();
	}

	public override bool MoveToElement()
	{
		CheckAsync();
		return _coreReader.MoveToElement();
	}

	public override bool ReadAttributeValue()
	{
		CheckAsync();
		return _coreReader.ReadAttributeValue();
	}

	public override bool Read()
	{
		CheckAsync();
		return _coreReader.Read();
	}

	public override void Close()
	{
		CheckAsync();
		_coreReader.Close();
	}

	public override void Skip()
	{
		CheckAsync();
		_coreReader.Skip();
	}

	public override string LookupNamespace(string prefix)
	{
		CheckAsync();
		return _coreReader.LookupNamespace(prefix);
	}

	public override void ResolveEntity()
	{
		CheckAsync();
		_coreReader.ResolveEntity();
	}

	public override int ReadElementContentAsBase64(byte[] buffer, int index, int count)
	{
		CheckAsync();
		return _coreReader.ReadElementContentAsBase64(buffer, index, count);
	}

	public override int ReadElementContentAsBinHex(byte[] buffer, int index, int count)
	{
		CheckAsync();
		return _coreReader.ReadElementContentAsBinHex(buffer, index, count);
	}

	public override int ReadValueChunk(char[] buffer, int index, int count)
	{
		CheckAsync();
		return _coreReader.ReadValueChunk(buffer, index, count);
	}

	public override string ReadString()
	{
		CheckAsync();
		return _coreReader.ReadString();
	}

	public override XmlNodeType MoveToContent()
	{
		CheckAsync();
		return _coreReader.MoveToContent();
	}

	public override void ReadStartElement()
	{
		CheckAsync();
		_coreReader.ReadStartElement();
	}

	public override void ReadStartElement(string name)
	{
		CheckAsync();
		_coreReader.ReadStartElement(name);
	}

	public override void ReadStartElement(string localname, string ns)
	{
		CheckAsync();
		_coreReader.ReadStartElement(localname, ns);
	}

	public override string ReadElementString()
	{
		CheckAsync();
		return _coreReader.ReadElementString();
	}

	public override void ReadEndElement()
	{
		CheckAsync();
		_coreReader.ReadEndElement();
	}

	public override bool IsStartElement()
	{
		CheckAsync();
		return _coreReader.IsStartElement();
	}

	public override bool IsStartElement(string name)
	{
		CheckAsync();
		return _coreReader.IsStartElement(name);
	}

	public override bool IsStartElement(string localname, string ns)
	{
		CheckAsync();
		return _coreReader.IsStartElement(localname, ns);
	}

	public override string ReadInnerXml()
	{
		CheckAsync();
		return _coreReader.ReadInnerXml();
	}

	protected override void Dispose(bool disposing)
	{
		CheckAsync();
		_coreReader.Dispose();
	}
}
