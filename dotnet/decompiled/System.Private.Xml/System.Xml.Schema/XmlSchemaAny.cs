using System.ComponentModel;
using System.Xml.Serialization;

namespace System.Xml.Schema;

public class XmlSchemaAny : XmlSchemaParticle
{
	private string _ns;

	private XmlSchemaContentProcessing _processContents;

	private NamespaceList _namespaceList;

	[XmlAttribute("namespace")]
	public string? Namespace
	{
		get
		{
			return _ns;
		}
		set
		{
			_ns = value;
		}
	}

	[XmlAttribute("processContents")]
	[DefaultValue(XmlSchemaContentProcessing.None)]
	public XmlSchemaContentProcessing ProcessContents
	{
		get
		{
			return _processContents;
		}
		set
		{
			_processContents = value;
		}
	}

	[XmlIgnore]
	internal NamespaceList? NamespaceList => _namespaceList;

	[XmlIgnore]
	internal string ResolvedNamespace
	{
		get
		{
			if (string.IsNullOrEmpty(_ns))
			{
				return "##any";
			}
			return _ns;
		}
	}

	[XmlIgnore]
	internal XmlSchemaContentProcessing ProcessContentsCorrect
	{
		get
		{
			if (_processContents != XmlSchemaContentProcessing.None)
			{
				return _processContents;
			}
			return XmlSchemaContentProcessing.Strict;
		}
	}

	internal void BuildNamespaceList(string targetNamespace)
	{
		if (_ns != null)
		{
			_namespaceList = new NamespaceList(_ns, targetNamespace);
		}
		else
		{
			_namespaceList = new NamespaceList();
		}
	}

	internal bool Allows(XmlQualifiedName qname)
	{
		return _namespaceList.Allows(qname.Namespace);
	}
}
