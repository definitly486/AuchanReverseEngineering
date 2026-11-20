using System.Reflection;
using System.Xml;

namespace System.IO.Packaging;

[DefaultMember("Item")]
internal class XmlWrappingReader : XmlReader, IXmlLineInfo, IXmlNamespaceResolver
{
	protected XmlReader _reader;

	protected IXmlLineInfo _readerAsIXmlLineInfo;

	protected IXmlNamespaceResolver _readerAsResolver;

	public override XmlReaderSettings Settings => _reader.Settings;

	public override XmlNodeType NodeType => _reader.NodeType;

	public override string Name => _reader.Name;

	public override string LocalName => _reader.LocalName;

	public override string NamespaceURI => _reader.NamespaceURI;

	public override string Prefix => _reader.Prefix;

	public override string Value => _reader.Value;

	public override int Depth => _reader.Depth;

	public override string BaseURI => _reader.BaseURI;

	public override bool IsEmptyElement => _reader.IsEmptyElement;

	public override bool IsDefault => _reader.IsDefault;

	public override XmlSpace XmlSpace => _reader.XmlSpace;

	public override string XmlLang => _reader.XmlLang;

	public override Type ValueType => _reader.ValueType;

	public override int AttributeCount => _reader.AttributeCount;

	public override bool CanResolveEntity => _reader.CanResolveEntity;

	public override bool EOF => _reader.EOF;

	public override ReadState ReadState => _reader.ReadState;

	public override bool HasAttributes => _reader.HasAttributes;

	public override XmlNameTable NameTable => _reader.NameTable;

	public virtual int LineNumber
	{
		get
		{
			if (_readerAsIXmlLineInfo != null)
			{
				return _readerAsIXmlLineInfo.LineNumber;
			}
			return 0;
		}
	}

	public virtual int LinePosition
	{
		get
		{
			if (_readerAsIXmlLineInfo != null)
			{
				return _readerAsIXmlLineInfo.LinePosition;
			}
			return 0;
		}
	}

	protected XmlReader Reader
	{
		get
		{
			return _reader;
		}
		set
		{
			_reader = value;
			_readerAsIXmlLineInfo = value as IXmlLineInfo;
			_readerAsResolver = value as IXmlNamespaceResolver;
		}
	}

	internal XmlWrappingReader(XmlReader baseReader)
	{
		Reader = baseReader;
	}

	public override string GetAttribute(string name)
	{
		return _reader.GetAttribute(name);
	}

	public override string GetAttribute(string name, string namespaceURI)
	{
		return _reader.GetAttribute(name, namespaceURI);
	}

	public override string GetAttribute(int i)
	{
		return _reader.GetAttribute(i);
	}

	public override bool MoveToAttribute(string name)
	{
		return _reader.MoveToAttribute(name);
	}

	public override bool MoveToAttribute(string name, string ns)
	{
		return _reader.MoveToAttribute(name, ns);
	}

	public override void MoveToAttribute(int i)
	{
		_reader.MoveToAttribute(i);
	}

	public override bool MoveToFirstAttribute()
	{
		return _reader.MoveToFirstAttribute();
	}

	public override bool MoveToNextAttribute()
	{
		return _reader.MoveToNextAttribute();
	}

	public override bool MoveToElement()
	{
		return _reader.MoveToElement();
	}

	public override bool Read()
	{
		return _reader.Read();
	}

	public override void Skip()
	{
		_reader.Skip();
	}

	public override string LookupNamespace(string prefix)
	{
		return _reader.LookupNamespace(prefix);
	}

	string IXmlNamespaceResolver.LookupPrefix(string namespaceName)
	{
		if (_readerAsResolver != null)
		{
			return _readerAsResolver.LookupPrefix(namespaceName);
		}
		return null;
	}

	public override void ResolveEntity()
	{
		_reader.ResolveEntity();
	}

	public override bool ReadAttributeValue()
	{
		return _reader.ReadAttributeValue();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing)
			{
				((IDisposable)_reader).Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	public virtual bool HasLineInfo()
	{
		if (_readerAsIXmlLineInfo != null)
		{
			return _readerAsIXmlLineInfo.HasLineInfo();
		}
		return false;
	}
}
