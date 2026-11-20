using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace System.Xml;

[EditorBrowsable(EditorBrowsableState.Never)]
public class XmlTextReader : XmlReader, IXmlLineInfo, IXmlNamespaceResolver
{
	private readonly XmlTextReaderImpl _impl;

	public override XmlNodeType NodeType => _impl.NodeType;

	public override string Name => _impl.Name;

	public override string LocalName => _impl.LocalName;

	public override string NamespaceURI => _impl.NamespaceURI;

	public override string Prefix => _impl.Prefix;

	public override string Value => _impl.Value;

	public override int Depth => _impl.Depth;

	public override string BaseURI => _impl.BaseURI;

	public override bool IsEmptyElement => _impl.IsEmptyElement;

	public override bool IsDefault => _impl.IsDefault;

	public override char QuoteChar => _impl.QuoteChar;

	public override XmlSpace XmlSpace => _impl.XmlSpace;

	public override string XmlLang => _impl.XmlLang;

	public override int AttributeCount => _impl.AttributeCount;

	public override bool EOF => _impl.EOF;

	public override ReadState ReadState => _impl.ReadState;

	public override XmlNameTable NameTable => _impl.NameTable;

	public override bool CanResolveEntity => true;

	public override bool CanReadBinaryContent => true;

	public override bool CanReadValueChunk => false;

	public int LineNumber => _impl.LineNumber;

	public int LinePosition => _impl.LinePosition;

	public bool Namespaces => _impl.Namespaces;

	public bool Normalization
	{
		set
		{
			_impl.Normalization = value;
		}
	}

	public WhitespaceHandling WhitespaceHandling
	{
		get
		{
			return _impl.WhitespaceHandling;
		}
		set
		{
			_impl.WhitespaceHandling = value;
		}
	}

	public DtdProcessing DtdProcessing => _impl.DtdProcessing;

	public EntityHandling EntityHandling
	{
		set
		{
			_impl.EntityHandling = value;
		}
	}

	public XmlResolver? XmlResolver
	{
		set
		{
			_impl.XmlResolver = value;
		}
	}

	internal XmlTextReaderImpl Impl => _impl;

	internal override XmlNamespaceManager? NamespaceManager => _impl.NamespaceManager;

	internal bool XmlValidatingReaderCompatibilityMode
	{
		set
		{
			_impl.XmlValidatingReaderCompatibilityMode = value;
		}
	}

	internal override IDtdInfo? DtdInfo => _impl.DtdInfo;

	public XmlTextReader(Stream input)
	{
		_impl = new XmlTextReaderImpl(input);
		_impl.OuterReader = this;
	}

	public XmlTextReader([StringSyntax("Uri")] string url, Stream input, XmlNameTable nt)
	{
		_impl = new XmlTextReaderImpl(url, input, nt);
		_impl.OuterReader = this;
	}

	public XmlTextReader(TextReader input)
	{
		_impl = new XmlTextReaderImpl(input);
		_impl.OuterReader = this;
	}

	public XmlTextReader(TextReader input, XmlNameTable nt)
	{
		_impl = new XmlTextReaderImpl(input, nt);
		_impl.OuterReader = this;
	}

	public override string? GetAttribute(string name)
	{
		return _impl.GetAttribute(name);
	}

	public override string? GetAttribute(string localName, string? namespaceURI)
	{
		return _impl.GetAttribute(localName, namespaceURI);
	}

	public override string GetAttribute(int i)
	{
		return _impl.GetAttribute(i);
	}

	public override bool MoveToAttribute(string name)
	{
		return _impl.MoveToAttribute(name);
	}

	public override bool MoveToAttribute(string localName, string? namespaceURI)
	{
		return _impl.MoveToAttribute(localName, namespaceURI);
	}

	public override void MoveToAttribute(int i)
	{
		_impl.MoveToAttribute(i);
	}

	public override bool MoveToFirstAttribute()
	{
		return _impl.MoveToFirstAttribute();
	}

	public override bool MoveToNextAttribute()
	{
		return _impl.MoveToNextAttribute();
	}

	public override bool MoveToElement()
	{
		return _impl.MoveToElement();
	}

	public override bool ReadAttributeValue()
	{
		return _impl.ReadAttributeValue();
	}

	public override bool Read()
	{
		return _impl.Read();
	}

	public override void Close()
	{
		_impl.Close();
	}

	public override void Skip()
	{
		_impl.Skip();
	}

	public override string? LookupNamespace(string prefix)
	{
		string text = _impl.LookupNamespace(prefix);
		if (text != null && text.Length == 0)
		{
			text = null;
		}
		return text;
	}

	public override void ResolveEntity()
	{
		_impl.ResolveEntity();
	}

	public override int ReadElementContentAsBase64(byte[] buffer, int index, int count)
	{
		return _impl.ReadElementContentAsBase64(buffer, index, count);
	}

	public override int ReadElementContentAsBinHex(byte[] buffer, int index, int count)
	{
		return _impl.ReadElementContentAsBinHex(buffer, index, count);
	}

	public override string ReadString()
	{
		_impl.MoveOffEntityReference();
		return base.ReadString();
	}

	public bool HasLineInfo()
	{
		return true;
	}

	string IXmlNamespaceResolver.LookupNamespace(string prefix)
	{
		return _impl.LookupNamespace(prefix);
	}

	string IXmlNamespaceResolver.LookupPrefix(string namespaceName)
	{
		return _impl.LookupPrefix(namespaceName);
	}
}
