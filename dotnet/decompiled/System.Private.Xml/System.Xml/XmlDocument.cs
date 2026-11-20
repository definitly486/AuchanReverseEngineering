using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace System.Xml;

public class XmlDocument : XmlNode
{
	private static readonly (string key, int hash)[] s_nameTableSeeds = new(string, int)[15]
	{
		("#document", System.Xml.NameTable.ComputeHash32("#document")),
		("#document-fragment", System.Xml.NameTable.ComputeHash32("#document-fragment")),
		("#comment", System.Xml.NameTable.ComputeHash32("#comment")),
		("#text", System.Xml.NameTable.ComputeHash32("#text")),
		("#cdata-section", System.Xml.NameTable.ComputeHash32("#cdata-section")),
		("#entity", System.Xml.NameTable.ComputeHash32("#entity")),
		("id", System.Xml.NameTable.ComputeHash32("id")),
		("xmlns", System.Xml.NameTable.ComputeHash32("xmlns")),
		("xml", System.Xml.NameTable.ComputeHash32("xml")),
		("space", System.Xml.NameTable.ComputeHash32("space")),
		("lang", System.Xml.NameTable.ComputeHash32("lang")),
		("#whitespace", System.Xml.NameTable.ComputeHash32("#whitespace")),
		("#significant-whitespace", System.Xml.NameTable.ComputeHash32("#significant-whitespace")),
		("http://www.w3.org/2000/xmlns/", System.Xml.NameTable.ComputeHash32("http://www.w3.org/2000/xmlns/")),
		("http://www.w3.org/XML/1998/namespace", System.Xml.NameTable.ComputeHash32("http://www.w3.org/XML/1998/namespace"))
	};

	private readonly XmlImplementation _implementation;

	private readonly DomNameTable _domNameTable;

	private XmlLinkedNode _lastChild;

	private Hashtable _htElementIdMap;

	private Hashtable _htElementIDAttrDecl;

	private SchemaInfo _schemaInfo;

	private XmlSchemaSet _schemas;

	private bool _reportValidity;

	private bool _actualLoadingStatus;

	private XmlNodeChangedEventHandler _onNodeInsertingDelegate;

	private XmlNodeChangedEventHandler _onNodeInsertedDelegate;

	private XmlNodeChangedEventHandler _onNodeRemovingDelegate;

	private XmlNodeChangedEventHandler _onNodeRemovedDelegate;

	private XmlNodeChangedEventHandler _onNodeChangingDelegate;

	private XmlNodeChangedEventHandler _onNodeChangedDelegate;

	internal bool fEntRefNodesPresent;

	internal bool fCDataNodesPresent;

	private bool _preserveWhitespace;

	private bool _isLoading;

	internal string strDocumentName;

	internal string strDocumentFragmentName;

	internal string strCommentName;

	internal string strTextName;

	internal string strCDataSectionName;

	internal string strEntityName;

	internal string strID;

	internal string strXmlns;

	internal string strXml;

	internal string strSpace;

	internal string strLang;

	internal string strNonSignificantWhitespaceName;

	internal string strSignificantWhitespaceName;

	internal string strReservedXmlns;

	internal string strReservedXml;

	internal string baseURI;

	private XmlResolver _resolver;

	internal bool bSetResolver;

	internal object objLock;

	internal static readonly EmptyEnumerator EmptyEnumerator = new EmptyEnumerator();

	internal static readonly IXmlSchemaInfo NotKnownSchemaInfo = new XmlSchemaInfo(XmlSchemaValidity.NotKnown);

	internal static readonly IXmlSchemaInfo ValidSchemaInfo = new XmlSchemaInfo(XmlSchemaValidity.Valid);

	internal static readonly IXmlSchemaInfo InvalidSchemaInfo = new XmlSchemaInfo(XmlSchemaValidity.Invalid);

	[CompilerGenerated]
	private XmlNamedNodeMap _003CEntities_003Ek__BackingField;

	internal SchemaInfo? DtdSchemaInfo
	{
		get
		{
			return _schemaInfo;
		}
		set
		{
			_schemaInfo = value;
		}
	}

	public override XmlNodeType NodeType => XmlNodeType.Document;

	public override XmlNode? ParentNode => null;

	public virtual XmlDocumentType? DocumentType => (XmlDocumentType)FindChild(XmlNodeType.DocumentType);

	internal virtual XmlDeclaration? Declaration
	{
		get
		{
			if (HasChildNodes)
			{
				return FirstChild as XmlDeclaration;
			}
			return null;
		}
	}

	public XmlImplementation Implementation => _implementation;

	public override string Name => strDocumentName;

	public override string LocalName => strDocumentName;

	public XmlElement? DocumentElement => (XmlElement)FindChild(XmlNodeType.Element);

	internal override bool IsContainer => true;

	internal override XmlLinkedNode? LastNode
	{
		get
		{
			return _lastChild;
		}
		set
		{
			_lastChild = value;
		}
	}

	public override XmlDocument? OwnerDocument => null;

	public XmlSchemaSet Schemas
	{
		get
		{
			return _schemas ?? (_schemas = new XmlSchemaSet(NameTable));
		}
		set
		{
			_schemas = value;
		}
	}

	internal bool CanReportValidity => _reportValidity;

	internal bool HasSetResolver => bSetResolver;

	public virtual XmlResolver? XmlResolver
	{
		set
		{
			_resolver = value;
			if (!bSetResolver)
			{
				bSetResolver = true;
			}
			XmlDocumentType documentType = DocumentType;
			if (documentType != null)
			{
				documentType.DtdSchemaInfo = null;
			}
		}
	}

	public XmlNameTable NameTable => _implementation.NameTable;

	public bool PreserveWhitespace
	{
		get
		{
			return _preserveWhitespace;
		}
		set
		{
			_preserveWhitespace = value;
		}
	}

	public override bool IsReadOnly => false;

	internal XmlNamedNodeMap Entities
	{
		get
		{
			return _003CEntities_003Ek__BackingField ?? (_003CEntities_003Ek__BackingField = new XmlNamedNodeMap(this));
		}
		set
		{
			_003CEntities_003Ek__BackingField = value;
		}
	}

	internal bool IsLoading
	{
		get
		{
			return _isLoading;
		}
		set
		{
			_isLoading = value;
		}
	}

	internal bool ActualLoadingStatus => _actualLoadingStatus;

	public override string InnerText
	{
		[param: AllowNull]
		set
		{
			throw new InvalidOperationException("Xdom_Document_Innertext");
		}
	}

	public override string InnerXml
	{
		get
		{
			return base.InnerXml;
		}
		set
		{
			LoadXml(value);
		}
	}

	internal string? Version => Declaration?.Version;

	internal string? Encoding => Declaration?.Encoding;

	internal string? Standalone => Declaration?.Standalone;

	public override IXmlSchemaInfo SchemaInfo
	{
		get
		{
			if (_reportValidity)
			{
				XmlElement documentElement = DocumentElement;
				if (documentElement != null)
				{
					switch (documentElement.SchemaInfo.Validity)
					{
					case XmlSchemaValidity.Valid:
						return ValidSchemaInfo;
					case XmlSchemaValidity.Invalid:
						return InvalidSchemaInfo;
					}
				}
			}
			return NotKnownSchemaInfo;
		}
	}

	public override string BaseURI => baseURI;

	public XmlDocument()
		: this(new XmlImplementation())
	{
	}

	public XmlDocument(XmlNameTable nt)
		: this(new XmlImplementation(nt))
	{
	}

	protected internal XmlDocument(XmlImplementation imp)
	{
		_implementation = imp;
		_domNameTable = new DomNameTable(this);
		strXmlns = "xmlns";
		strXml = "xml";
		strReservedXmlns = "http://www.w3.org/2000/xmlns/";
		strReservedXml = "http://www.w3.org/XML/1998/namespace";
		baseURI = string.Empty;
		objLock = new object();
		if (imp.NameTable.GetType() == typeof(NameTable))
		{
			NameTable nameTable = (NameTable)imp.NameTable;
			strDocumentName = nameTable.GetOrAddEntry(s_nameTableSeeds[0].key, s_nameTableSeeds[0].hash);
			strDocumentFragmentName = nameTable.GetOrAddEntry(s_nameTableSeeds[1].key, s_nameTableSeeds[1].hash);
			strCommentName = nameTable.GetOrAddEntry(s_nameTableSeeds[2].key, s_nameTableSeeds[2].hash);
			strTextName = nameTable.GetOrAddEntry(s_nameTableSeeds[3].key, s_nameTableSeeds[3].hash);
			strCDataSectionName = nameTable.GetOrAddEntry(s_nameTableSeeds[4].key, s_nameTableSeeds[4].hash);
			strEntityName = nameTable.GetOrAddEntry(s_nameTableSeeds[5].key, s_nameTableSeeds[5].hash);
			strID = nameTable.GetOrAddEntry(s_nameTableSeeds[6].key, s_nameTableSeeds[6].hash);
			strNonSignificantWhitespaceName = nameTable.GetOrAddEntry(s_nameTableSeeds[11].key, s_nameTableSeeds[11].hash);
			strSignificantWhitespaceName = nameTable.GetOrAddEntry(s_nameTableSeeds[12].key, s_nameTableSeeds[12].hash);
			strXmlns = nameTable.GetOrAddEntry(s_nameTableSeeds[7].key, s_nameTableSeeds[7].hash);
			strXml = nameTable.GetOrAddEntry(s_nameTableSeeds[8].key, s_nameTableSeeds[8].hash);
			strSpace = nameTable.GetOrAddEntry(s_nameTableSeeds[9].key, s_nameTableSeeds[9].hash);
			strLang = nameTable.GetOrAddEntry(s_nameTableSeeds[10].key, s_nameTableSeeds[10].hash);
			strReservedXmlns = nameTable.GetOrAddEntry(s_nameTableSeeds[13].key, s_nameTableSeeds[13].hash);
			strReservedXml = nameTable.GetOrAddEntry(s_nameTableSeeds[14].key, s_nameTableSeeds[14].hash);
		}
		else
		{
			XmlNameTable nameTable2 = imp.NameTable;
			strDocumentName = nameTable2.Add("#document");
			strDocumentFragmentName = nameTable2.Add("#document-fragment");
			strCommentName = nameTable2.Add("#comment");
			strTextName = nameTable2.Add("#text");
			strCDataSectionName = nameTable2.Add("#cdata-section");
			strEntityName = nameTable2.Add("#entity");
			strID = nameTable2.Add("id");
			strNonSignificantWhitespaceName = nameTable2.Add("#whitespace");
			strSignificantWhitespaceName = nameTable2.Add("#significant-whitespace");
			strXmlns = nameTable2.Add("xmlns");
			strXml = nameTable2.Add("xml");
			strSpace = nameTable2.Add("space");
			strLang = nameTable2.Add("lang");
			strReservedXmlns = nameTable2.Add("http://www.w3.org/2000/xmlns/");
			strReservedXml = nameTable2.Add("http://www.w3.org/XML/1998/namespace");
		}
	}

	internal static void CheckName(string name)
	{
		int num = ValidateNames.ParseNmtoken(name, 0);
		if (num < name.Length)
		{
			throw new XmlException("Xml_BadNameChar", XmlException.BuildCharExceptionArgs(name, num));
		}
	}

	internal XmlName AddXmlName(string prefix, string localName, string namespaceURI, IXmlSchemaInfo schemaInfo)
	{
		return _domNameTable.AddName(prefix, localName, namespaceURI, schemaInfo);
	}

	internal XmlName GetXmlName(string prefix, string localName, string namespaceURI, IXmlSchemaInfo schemaInfo)
	{
		return _domNameTable.GetName(prefix, localName, namespaceURI, schemaInfo);
	}

	internal XmlName AddAttrXmlName(string prefix, string localName, string namespaceURI, IXmlSchemaInfo schemaInfo)
	{
		XmlName xmlName = AddXmlName(prefix, localName, namespaceURI, schemaInfo);
		if (!IsLoading)
		{
			object prefix2 = xmlName.Prefix;
			object namespaceURI2 = xmlName.NamespaceURI;
			object localName2 = xmlName.LocalName;
			if ((prefix2 == strXmlns || (xmlName.Prefix.Length == 0 && localName2 == strXmlns)) ^ (namespaceURI2 == strReservedXmlns))
			{
				throw new ArgumentException(System.SR.Format("Xdom_Attr_Reserved_XmlNS", namespaceURI));
			}
		}
		return xmlName;
	}

	internal bool AddIdInfo(XmlName eleName, XmlName attrName)
	{
		if (_htElementIDAttrDecl == null || _htElementIDAttrDecl[eleName] == null)
		{
			if (_htElementIDAttrDecl == null)
			{
				_htElementIDAttrDecl = new Hashtable();
			}
			_htElementIDAttrDecl.Add(eleName, attrName);
			return true;
		}
		return false;
	}

	private XmlName GetIDInfoByElement_(XmlName eleName)
	{
		XmlName xmlName = GetXmlName(eleName.Prefix, eleName.LocalName, string.Empty, null);
		if (xmlName != null)
		{
			return (XmlName)_htElementIDAttrDecl[xmlName];
		}
		return null;
	}

	internal XmlName GetIDInfoByElement(XmlName eleName)
	{
		if (_htElementIDAttrDecl == null)
		{
			return null;
		}
		return GetIDInfoByElement_(eleName);
	}

	private static WeakReference<XmlElement> GetElement(ArrayList elementList, XmlElement elem)
	{
		ArrayList arrayList = new ArrayList();
		foreach (WeakReference<XmlElement> element in elementList)
		{
			if (!element.TryGetTarget(out var target))
			{
				arrayList.Add(element);
			}
			else if (target == elem)
			{
				return element;
			}
		}
		foreach (WeakReference<XmlElement> item in arrayList)
		{
			elementList.Remove(item);
		}
		return null;
	}

	internal void AddElementWithId(string id, XmlElement elem)
	{
		if (_htElementIdMap == null || !_htElementIdMap.Contains(id))
		{
			if (_htElementIdMap == null)
			{
				_htElementIdMap = new Hashtable();
			}
			ArrayList arrayList = new ArrayList();
			arrayList.Add(new WeakReference<XmlElement>(elem));
			_htElementIdMap.Add(id, arrayList);
		}
		else
		{
			ArrayList arrayList2 = (ArrayList)_htElementIdMap[id];
			if (GetElement(arrayList2, elem) == null)
			{
				arrayList2.Add(new WeakReference<XmlElement>(elem));
			}
		}
	}

	internal void RemoveElementWithId(string id, XmlElement elem)
	{
		if (_htElementIdMap == null || !_htElementIdMap.Contains(id))
		{
			return;
		}
		ArrayList arrayList = (ArrayList)_htElementIdMap[id];
		WeakReference<XmlElement> element = GetElement(arrayList, elem);
		if (element != null)
		{
			arrayList.Remove(element);
			if (arrayList.Count == 0)
			{
				_htElementIdMap.Remove(id);
			}
		}
	}

	public override XmlNode CloneNode(bool deep)
	{
		XmlDocument xmlDocument = Implementation.CreateDocument();
		xmlDocument.SetBaseURI(baseURI);
		if (deep)
		{
			xmlDocument.ImportChildren(this, xmlDocument, deep);
		}
		return xmlDocument;
	}

	internal XmlResolver GetResolver()
	{
		return _resolver;
	}

	internal override bool IsValidChildType(XmlNodeType type)
	{
		switch (type)
		{
		case XmlNodeType.ProcessingInstruction:
		case XmlNodeType.Comment:
		case XmlNodeType.Whitespace:
		case XmlNodeType.SignificantWhitespace:
			return true;
		case XmlNodeType.DocumentType:
			if (DocumentType != null)
			{
				throw new InvalidOperationException("Xdom_DualDocumentTypeNode");
			}
			return true;
		case XmlNodeType.Element:
			if (DocumentElement != null)
			{
				throw new InvalidOperationException("Xdom_DualDocumentElementNode");
			}
			return true;
		case XmlNodeType.XmlDeclaration:
			if (Declaration != null)
			{
				throw new InvalidOperationException("Xdom_DualDeclarationNode");
			}
			return true;
		default:
			return false;
		}
	}

	private static bool HasNodeTypeInPrevSiblings(XmlNodeType nt, XmlNode refNode)
	{
		if (refNode == null)
		{
			return false;
		}
		XmlNode xmlNode = null;
		if (refNode.ParentNode != null)
		{
			xmlNode = refNode.ParentNode.FirstChild;
		}
		while (xmlNode != null)
		{
			if (xmlNode.NodeType == nt)
			{
				return true;
			}
			if (xmlNode == refNode)
			{
				break;
			}
			xmlNode = xmlNode.NextSibling;
		}
		return false;
	}

	private static bool HasNodeTypeInNextSiblings(XmlNodeType nt, XmlNode refNode)
	{
		for (XmlNode xmlNode = refNode; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			if (xmlNode.NodeType == nt)
			{
				return true;
			}
		}
		return false;
	}

	internal override bool CanInsertBefore(XmlNode newChild, XmlNode refChild)
	{
		if (refChild == null)
		{
			refChild = FirstChild;
		}
		if (refChild == null)
		{
			return true;
		}
		switch (newChild.NodeType)
		{
		case XmlNodeType.XmlDeclaration:
			return refChild == FirstChild;
		case XmlNodeType.ProcessingInstruction:
		case XmlNodeType.Comment:
			return refChild.NodeType != XmlNodeType.XmlDeclaration;
		case XmlNodeType.DocumentType:
			if (refChild.NodeType != XmlNodeType.XmlDeclaration)
			{
				return !HasNodeTypeInPrevSiblings(XmlNodeType.Element, refChild.PreviousSibling);
			}
			break;
		case XmlNodeType.Element:
			if (refChild.NodeType != XmlNodeType.XmlDeclaration)
			{
				return !HasNodeTypeInNextSiblings(XmlNodeType.DocumentType, refChild);
			}
			break;
		}
		return false;
	}

	internal override bool CanInsertAfter(XmlNode newChild, XmlNode refChild)
	{
		if (refChild == null)
		{
			refChild = LastChild;
		}
		if (refChild == null)
		{
			return true;
		}
		switch (newChild.NodeType)
		{
		case XmlNodeType.ProcessingInstruction:
		case XmlNodeType.Comment:
		case XmlNodeType.Whitespace:
		case XmlNodeType.SignificantWhitespace:
			return true;
		case XmlNodeType.DocumentType:
			return !HasNodeTypeInPrevSiblings(XmlNodeType.Element, refChild);
		case XmlNodeType.Element:
			return !HasNodeTypeInNextSiblings(XmlNodeType.DocumentType, refChild.NextSibling);
		default:
			return false;
		}
	}

	public XmlAttribute CreateAttribute(string name)
	{
		string namespaceURI = string.Empty;
		XmlNode.SplitName(name, out var prefix, out var localName);
		SetDefaultNamespace(prefix, localName, ref namespaceURI);
		return CreateAttribute(prefix, localName, namespaceURI);
	}

	internal void SetDefaultNamespace(string prefix, string localName, ref string namespaceURI)
	{
		if (prefix == strXmlns || (prefix.Length == 0 && localName == strXmlns))
		{
			namespaceURI = strReservedXmlns;
		}
		else if (prefix == strXml)
		{
			namespaceURI = strReservedXml;
		}
	}

	public virtual XmlCDataSection CreateCDataSection(string? data)
	{
		fCDataNodesPresent = true;
		return new XmlCDataSection(data, this);
	}

	public virtual XmlComment CreateComment(string? data)
	{
		return new XmlComment(data, this);
	}

	public virtual XmlDocumentType CreateDocumentType(string name, string? publicId, string? systemId, string? internalSubset)
	{
		return new XmlDocumentType(name, publicId, systemId, internalSubset, this);
	}

	public virtual XmlDocumentFragment CreateDocumentFragment()
	{
		return new XmlDocumentFragment(this);
	}

	public XmlElement CreateElement(string name)
	{
		XmlNode.SplitName(name, out var prefix, out var localName);
		return CreateElement(prefix, localName, string.Empty);
	}

	internal void AddDefaultAttributes(XmlElement elem)
	{
		SchemaInfo dtdSchemaInfo = DtdSchemaInfo;
		SchemaElementDecl schemaElementDecl = GetSchemaElementDecl(elem);
		if (schemaElementDecl == null || schemaElementDecl.AttDefs == null)
		{
			return;
		}
		foreach (KeyValuePair<XmlQualifiedName, SchemaAttDef> attDef in schemaElementDecl.AttDefs)
		{
			SchemaAttDef value = attDef.Value;
			if (value.Presence == SchemaDeclBase.Use.Default || value.Presence == SchemaDeclBase.Use.Fixed)
			{
				string name = value.Name.Name;
				string attrNamespaceURI = string.Empty;
				string attrPrefix;
				if (dtdSchemaInfo.SchemaType == SchemaType.DTD)
				{
					attrPrefix = value.Name.Namespace;
				}
				else
				{
					attrPrefix = value.Prefix;
					attrNamespaceURI = value.Name.Namespace;
				}
				XmlAttribute attributeNode = PrepareDefaultAttribute(value, attrPrefix, name, attrNamespaceURI);
				elem.SetAttributeNode(attributeNode);
			}
		}
	}

	private SchemaElementDecl GetSchemaElementDecl(XmlElement elem)
	{
		SchemaInfo dtdSchemaInfo = DtdSchemaInfo;
		if (dtdSchemaInfo != null)
		{
			XmlQualifiedName key = new XmlQualifiedName(elem.LocalName, (dtdSchemaInfo.SchemaType == SchemaType.DTD) ? elem.Prefix : elem.NamespaceURI);
			if (dtdSchemaInfo.ElementDecls.TryGetValue(key, out var value))
			{
				return value;
			}
		}
		return null;
	}

	private XmlAttribute PrepareDefaultAttribute(SchemaAttDef attdef, string attrPrefix, string attrLocalname, string attrNamespaceURI)
	{
		SetDefaultNamespace(attrPrefix, attrLocalname, ref attrNamespaceURI);
		XmlAttribute xmlAttribute = CreateDefaultAttribute(attrPrefix, attrLocalname, attrNamespaceURI);
		xmlAttribute.InnerXml = attdef.DefaultValueRaw;
		XmlUnspecifiedAttribute obj = xmlAttribute as XmlUnspecifiedAttribute;
		if (obj != null)
		{
			obj.SetSpecified(f: false);
			return xmlAttribute;
		}
		return xmlAttribute;
	}

	public virtual XmlEntityReference CreateEntityReference(string name)
	{
		return new XmlEntityReference(name, this);
	}

	public virtual XmlProcessingInstruction CreateProcessingInstruction(string target, string? data)
	{
		ArgumentNullException.ThrowIfNull(target, "target");
		return new XmlProcessingInstruction(target, data, this);
	}

	public virtual XmlDeclaration CreateXmlDeclaration(string version, string? encoding, string? standalone)
	{
		return new XmlDeclaration(version, encoding, standalone, this);
	}

	public virtual XmlText CreateTextNode(string? text)
	{
		return new XmlText(text, this);
	}

	public virtual XmlSignificantWhitespace CreateSignificantWhitespace(string? text)
	{
		return new XmlSignificantWhitespace(text, this);
	}

	public virtual XmlWhitespace CreateWhitespace(string? text)
	{
		return new XmlWhitespace(text, this);
	}

	public XmlAttribute CreateAttribute(string qualifiedName, string? namespaceURI)
	{
		XmlNode.SplitName(qualifiedName, out var prefix, out var localName);
		return CreateAttribute(prefix, localName, namespaceURI);
	}

	public XmlElement CreateElement(string qualifiedName, string? namespaceURI)
	{
		XmlNode.SplitName(qualifiedName, out var prefix, out var localName);
		return CreateElement(prefix, localName, namespaceURI);
	}

	public virtual XmlNode ImportNode(XmlNode node, bool deep)
	{
		return ImportNodeInternal(node, deep);
	}

	private XmlNode ImportNodeInternal(XmlNode node, bool deep)
	{
		if (node == null)
		{
			throw new InvalidOperationException("Xdom_Import_NullNode");
		}
		XmlNode xmlNode;
		switch (node.NodeType)
		{
		case XmlNodeType.Element:
			xmlNode = CreateElement(node.Prefix, node.LocalName, node.NamespaceURI);
			ImportAttributes(node, xmlNode);
			if (deep)
			{
				ImportChildren(node, xmlNode, deep);
			}
			break;
		case XmlNodeType.Attribute:
			xmlNode = CreateAttribute(node.Prefix, node.LocalName, node.NamespaceURI);
			ImportChildren(node, xmlNode, deep: true);
			break;
		case XmlNodeType.Text:
			xmlNode = CreateTextNode(node.Value);
			break;
		case XmlNodeType.Comment:
			xmlNode = CreateComment(node.Value);
			break;
		case XmlNodeType.ProcessingInstruction:
			xmlNode = CreateProcessingInstruction(node.Name, node.Value);
			break;
		case XmlNodeType.XmlDeclaration:
		{
			XmlDeclaration xmlDeclaration = (XmlDeclaration)node;
			xmlNode = CreateXmlDeclaration(xmlDeclaration.Version, xmlDeclaration.Encoding, xmlDeclaration.Standalone);
			break;
		}
		case XmlNodeType.CDATA:
			xmlNode = CreateCDataSection(node.Value);
			break;
		case XmlNodeType.DocumentType:
		{
			XmlDocumentType xmlDocumentType = (XmlDocumentType)node;
			xmlNode = CreateDocumentType(xmlDocumentType.Name, xmlDocumentType.PublicId, xmlDocumentType.SystemId, xmlDocumentType.InternalSubset);
			break;
		}
		case XmlNodeType.DocumentFragment:
			xmlNode = CreateDocumentFragment();
			if (deep)
			{
				ImportChildren(node, xmlNode, deep);
			}
			break;
		case XmlNodeType.EntityReference:
			xmlNode = CreateEntityReference(node.Name);
			break;
		case XmlNodeType.Whitespace:
			xmlNode = CreateWhitespace(node.Value);
			break;
		case XmlNodeType.SignificantWhitespace:
			xmlNode = CreateSignificantWhitespace(node.Value);
			break;
		default:
			throw new InvalidOperationException(System.SR.Format(CultureInfo.InvariantCulture, "Xdom_Import", node.NodeType));
		}
		return xmlNode;
	}

	private void ImportAttributes(XmlNode fromElem, XmlNode toElem)
	{
		int count = fromElem.Attributes.Count;
		for (int i = 0; i < count; i++)
		{
			if (fromElem.Attributes[i].Specified)
			{
				toElem.Attributes.SetNamedItem(ImportNodeInternal(fromElem.Attributes[i], deep: true));
			}
		}
	}

	private void ImportChildren(XmlNode fromNode, XmlNode toNode, bool deep)
	{
		for (XmlNode xmlNode = fromNode.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			toNode.AppendChild(ImportNodeInternal(xmlNode, deep));
		}
	}

	public virtual XmlAttribute CreateAttribute(string? prefix, string localName, string? namespaceURI)
	{
		return new XmlAttribute(AddAttrXmlName(prefix, localName, namespaceURI, null), this);
	}

	protected internal virtual XmlAttribute CreateDefaultAttribute(string? prefix, string localName, string? namespaceURI)
	{
		return new XmlUnspecifiedAttribute(prefix, localName, namespaceURI, this);
	}

	public virtual XmlElement CreateElement(string? prefix, string localName, string? namespaceURI)
	{
		XmlElement xmlElement = new XmlElement(AddXmlName(prefix, localName, namespaceURI, null), empty: true, this);
		if (!IsLoading)
		{
			AddDefaultAttributes(xmlElement);
		}
		return xmlElement;
	}

	public virtual XmlNode? ReadNode(XmlReader reader)
	{
		XmlNode xmlNode = null;
		try
		{
			IsLoading = true;
			return new XmlLoader().ReadCurrentNode(this, reader);
		}
		finally
		{
			IsLoading = false;
		}
	}

	private XmlTextReader SetupReader(XmlTextReader tr)
	{
		tr.XmlValidatingReaderCompatibilityMode = true;
		tr.EntityHandling = EntityHandling.ExpandCharEntities;
		if (HasSetResolver)
		{
			tr.XmlResolver = GetResolver();
		}
		return tr;
	}

	public virtual void Load(XmlReader reader)
	{
		try
		{
			IsLoading = true;
			_actualLoadingStatus = true;
			RemoveAll();
			fEntRefNodesPresent = false;
			fCDataNodesPresent = false;
			_reportValidity = true;
			new XmlLoader().Load(this, reader, _preserveWhitespace);
		}
		finally
		{
			IsLoading = false;
			_actualLoadingStatus = false;
			_reportValidity = true;
		}
	}

	public virtual void LoadXml([StringSyntax("Xml")] string xml)
	{
		XmlTextReader xmlTextReader = SetupReader(new XmlTextReader(new StringReader(xml), NameTable));
		try
		{
			Load(xmlTextReader);
		}
		finally
		{
			xmlTextReader.Close();
		}
	}

	public virtual void Save(XmlWriter w)
	{
		XmlNode xmlNode = FirstChild;
		if (xmlNode == null)
		{
			return;
		}
		if (w.WriteState == WriteState.Start)
		{
			if (xmlNode is XmlDeclaration)
			{
				if (Standalone.Length == 0)
				{
					w.WriteStartDocument();
				}
				else if (Standalone == "yes")
				{
					w.WriteStartDocument(standalone: true);
				}
				else if (Standalone == "no")
				{
					w.WriteStartDocument(standalone: false);
				}
				xmlNode = xmlNode.NextSibling;
			}
			else
			{
				w.WriteStartDocument();
			}
		}
		while (xmlNode != null)
		{
			xmlNode.WriteTo(w);
			xmlNode = xmlNode.NextSibling;
		}
		w.Flush();
	}

	public override void WriteTo(XmlWriter w)
	{
		WriteContentTo(w);
	}

	public override void WriteContentTo(XmlWriter xw)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				((XmlNode)enumerator.Current).WriteTo(xw);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	internal override XmlNodeChangedEventArgs GetEventArgs(XmlNode node, XmlNode oldParent, XmlNode newParent, string oldValue, string newValue, XmlNodeChangedAction action)
	{
		_reportValidity = false;
		switch (action)
		{
		case XmlNodeChangedAction.Insert:
			if (_onNodeInsertingDelegate == null && _onNodeInsertedDelegate == null)
			{
				return null;
			}
			break;
		case XmlNodeChangedAction.Remove:
			if (_onNodeRemovingDelegate == null && _onNodeRemovedDelegate == null)
			{
				return null;
			}
			break;
		case XmlNodeChangedAction.Change:
			if (_onNodeChangingDelegate == null && _onNodeChangedDelegate == null)
			{
				return null;
			}
			break;
		}
		return new XmlNodeChangedEventArgs(node, oldParent, newParent, oldValue, newValue, action);
	}

	internal XmlNodeChangedEventArgs GetInsertEventArgsForLoad(XmlNode node, XmlNode newParent)
	{
		if (_onNodeInsertingDelegate == null && _onNodeInsertedDelegate == null)
		{
			return null;
		}
		string value = node.Value;
		return new XmlNodeChangedEventArgs(node, null, newParent, value, value, XmlNodeChangedAction.Insert);
	}

	internal override void BeforeEvent(XmlNodeChangedEventArgs args)
	{
		if (args != null)
		{
			switch (args.Action)
			{
			case XmlNodeChangedAction.Insert:
				_onNodeInsertingDelegate?.Invoke(this, args);
				break;
			case XmlNodeChangedAction.Remove:
				_onNodeRemovingDelegate?.Invoke(this, args);
				break;
			case XmlNodeChangedAction.Change:
				_onNodeChangingDelegate?.Invoke(this, args);
				break;
			}
		}
	}

	internal override void AfterEvent(XmlNodeChangedEventArgs args)
	{
		if (args != null)
		{
			switch (args.Action)
			{
			case XmlNodeChangedAction.Insert:
				_onNodeInsertedDelegate?.Invoke(this, args);
				break;
			case XmlNodeChangedAction.Remove:
				_onNodeRemovedDelegate?.Invoke(this, args);
				break;
			case XmlNodeChangedAction.Change:
				_onNodeChangedDelegate?.Invoke(this, args);
				break;
			}
		}
	}

	internal XmlAttribute GetDefaultAttribute(XmlElement elem, string attrPrefix, string attrLocalname, string attrNamespaceURI)
	{
		SchemaInfo dtdSchemaInfo = DtdSchemaInfo;
		SchemaElementDecl schemaElementDecl = GetSchemaElementDecl(elem);
		if (schemaElementDecl != null && schemaElementDecl.AttDefs != null)
		{
			foreach (KeyValuePair<XmlQualifiedName, SchemaAttDef> attDef in schemaElementDecl.AttDefs)
			{
				SchemaAttDef value = attDef.Value;
				if ((value.Presence == SchemaDeclBase.Use.Default || value.Presence == SchemaDeclBase.Use.Fixed) && value.Name.Name == attrLocalname && ((dtdSchemaInfo.SchemaType == SchemaType.DTD && value.Name.Namespace == attrPrefix) || (dtdSchemaInfo.SchemaType != SchemaType.DTD && value.Name.Namespace == attrNamespaceURI)))
				{
					return PrepareDefaultAttribute(value, attrPrefix, attrLocalname, attrNamespaceURI);
				}
			}
		}
		return null;
	}

	internal XmlEntity GetEntityNode(string name)
	{
		if (DocumentType != null)
		{
			XmlNamedNodeMap entities = DocumentType.Entities;
			if (entities != null)
			{
				return (XmlEntity)entities.GetNamedItem(name);
			}
		}
		return null;
	}

	internal void SetBaseURI(string inBaseURI)
	{
		baseURI = inBaseURI;
	}

	internal override XmlNode AppendChildForLoad(XmlNode newChild, XmlDocument doc)
	{
		if (!IsValidChildType(newChild.NodeType))
		{
			throw new InvalidOperationException("Xdom_Node_Insert_TypeConflict");
		}
		if (!CanInsertAfter(newChild, LastChild))
		{
			throw new InvalidOperationException("Xdom_Node_Insert_Location");
		}
		XmlNodeChangedEventArgs insertEventArgsForLoad = GetInsertEventArgsForLoad(newChild, this);
		if (insertEventArgsForLoad != null)
		{
			BeforeEvent(insertEventArgsForLoad);
		}
		XmlLinkedNode xmlLinkedNode = (XmlLinkedNode)newChild;
		if (_lastChild == null)
		{
			xmlLinkedNode.next = xmlLinkedNode;
		}
		else
		{
			xmlLinkedNode.next = _lastChild.next;
			_lastChild.next = xmlLinkedNode;
		}
		_lastChild = xmlLinkedNode;
		xmlLinkedNode.SetParentForLoad(this);
		if (insertEventArgsForLoad != null)
		{
			AfterEvent(insertEventArgsForLoad);
		}
		return xmlLinkedNode;
	}
}
