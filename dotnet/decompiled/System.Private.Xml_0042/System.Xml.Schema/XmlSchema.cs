using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Serialization;

namespace System.Xml.Schema;

[XmlRoot("schema", Namespace = "http://www.w3.org/2001/XMLSchema")]
public class XmlSchema : XmlSchemaObject
{
	private XmlSchemaForm _attributeFormDefault;

	private XmlSchemaForm _elementFormDefault;

	private XmlSchemaDerivationMethod _blockDefault = XmlSchemaDerivationMethod.None;

	private XmlSchemaDerivationMethod _finalDefault = XmlSchemaDerivationMethod.None;

	private string _targetNs;

	private string _version;

	private XmlSchemaObjectCollection _includes = new XmlSchemaObjectCollection();

	private XmlSchemaObjectCollection _items = new XmlSchemaObjectCollection();

	private string _id;

	private XmlAttribute[] _moreAttributes;

	private bool _isCompiled;

	private bool _isCompiledBySet;

	private bool _isPreprocessed;

	private bool _isRedefined;

	private int _errorCount;

	private readonly XmlSchemaObjectTable _groups = new XmlSchemaObjectTable();

	private readonly XmlSchemaObjectTable _notations = new XmlSchemaObjectTable();

	private readonly XmlSchemaObjectTable _identityConstraints = new XmlSchemaObjectTable();

	private static int s_globalIdCounter = -1;

	private int _schemaId = -1;

	private Uri _baseUri;

	private bool _isChameleon;

	private readonly Hashtable _ids = new Hashtable();

	[CompilerGenerated]
	private XmlSchemaObjectTable _003CAttributes_003Ek__BackingField;

	[CompilerGenerated]
	private XmlSchemaObjectTable _003CAttributeGroups_003Ek__BackingField;

	[CompilerGenerated]
	private XmlSchemaObjectTable _003CSchemaTypes_003Ek__BackingField;

	[CompilerGenerated]
	private XmlSchemaObjectTable _003CElements_003Ek__BackingField;

	[CompilerGenerated]
	private XmlDocument _003CDocument_003Ek__BackingField;

	[CompilerGenerated]
	private ArrayList _003CImportedSchemas_003Ek__BackingField;

	[CompilerGenerated]
	private ArrayList _003CImportedNamespaces_003Ek__BackingField;

	[XmlAttribute("attributeFormDefault")]
	[DefaultValue(XmlSchemaForm.None)]
	public XmlSchemaForm AttributeFormDefault
	{
		get
		{
			return _attributeFormDefault;
		}
		set
		{
			_attributeFormDefault = value;
		}
	}

	[XmlAttribute("blockDefault")]
	[DefaultValue(XmlSchemaDerivationMethod.None)]
	public XmlSchemaDerivationMethod BlockDefault
	{
		get
		{
			return _blockDefault;
		}
		set
		{
			_blockDefault = value;
		}
	}

	[XmlAttribute("finalDefault")]
	[DefaultValue(XmlSchemaDerivationMethod.None)]
	public XmlSchemaDerivationMethod FinalDefault
	{
		get
		{
			return _finalDefault;
		}
		set
		{
			_finalDefault = value;
		}
	}

	[XmlAttribute("elementFormDefault")]
	[DefaultValue(XmlSchemaForm.None)]
	public XmlSchemaForm ElementFormDefault
	{
		get
		{
			return _elementFormDefault;
		}
		set
		{
			_elementFormDefault = value;
		}
	}

	[XmlAttribute("targetNamespace", DataType = "anyURI")]
	public string? TargetNamespace
	{
		get
		{
			return _targetNs;
		}
		set
		{
			_targetNs = value;
		}
	}

	[XmlAttribute("version", DataType = "token")]
	public string? Version
	{
		get
		{
			return _version;
		}
		set
		{
			_version = value;
		}
	}

	[XmlElement("include", typeof(XmlSchemaInclude))]
	[XmlElement("import", typeof(XmlSchemaImport))]
	[XmlElement("redefine", typeof(XmlSchemaRedefine))]
	public XmlSchemaObjectCollection Includes => _includes;

	[XmlElement("annotation", typeof(XmlSchemaAnnotation))]
	[XmlElement("attribute", typeof(XmlSchemaAttribute))]
	[XmlElement("attributeGroup", typeof(XmlSchemaAttributeGroup))]
	[XmlElement("complexType", typeof(XmlSchemaComplexType))]
	[XmlElement("simpleType", typeof(XmlSchemaSimpleType))]
	[XmlElement("element", typeof(XmlSchemaElement))]
	[XmlElement("group", typeof(XmlSchemaGroup))]
	[XmlElement("notation", typeof(XmlSchemaNotation))]
	public XmlSchemaObjectCollection Items => _items;

	[XmlIgnore]
	public bool IsCompiled
	{
		get
		{
			if (!_isCompiled)
			{
				return _isCompiledBySet;
			}
			return true;
		}
	}

	[XmlIgnore]
	internal bool IsCompiledBySet
	{
		get
		{
			return _isCompiledBySet;
		}
		set
		{
			_isCompiledBySet = value;
		}
	}

	[XmlIgnore]
	internal bool IsPreprocessed
	{
		get
		{
			return _isPreprocessed;
		}
		set
		{
			_isPreprocessed = value;
		}
	}

	[XmlIgnore]
	internal bool IsRedefined
	{
		get
		{
			return _isRedefined;
		}
		set
		{
			_isRedefined = value;
		}
	}

	[XmlIgnore]
	public XmlSchemaObjectTable Attributes => _003CAttributes_003Ek__BackingField ?? (_003CAttributes_003Ek__BackingField = new XmlSchemaObjectTable());

	[XmlIgnore]
	public XmlSchemaObjectTable AttributeGroups => _003CAttributeGroups_003Ek__BackingField ?? (_003CAttributeGroups_003Ek__BackingField = new XmlSchemaObjectTable());

	[XmlIgnore]
	public XmlSchemaObjectTable SchemaTypes => _003CSchemaTypes_003Ek__BackingField ?? (_003CSchemaTypes_003Ek__BackingField = new XmlSchemaObjectTable());

	[XmlIgnore]
	public XmlSchemaObjectTable Elements => _003CElements_003Ek__BackingField ?? (_003CElements_003Ek__BackingField = new XmlSchemaObjectTable());

	[XmlAttribute("id", DataType = "ID")]
	public string? Id
	{
		get
		{
			return _id;
		}
		set
		{
			_id = value;
		}
	}

	[XmlAnyAttribute]
	public XmlAttribute[]? UnhandledAttributes
	{
		get
		{
			return _moreAttributes;
		}
		set
		{
			_moreAttributes = value;
		}
	}

	[XmlIgnore]
	public XmlSchemaObjectTable Groups => _groups;

	[XmlIgnore]
	public XmlSchemaObjectTable Notations => _notations;

	[XmlIgnore]
	internal XmlSchemaObjectTable IdentityConstraints => _identityConstraints;

	[XmlIgnore]
	internal Uri? BaseUri
	{
		get
		{
			return _baseUri;
		}
		set
		{
			_baseUri = value;
		}
	}

	[XmlIgnore]
	internal int SchemaId
	{
		get
		{
			if (_schemaId == -1)
			{
				_schemaId = Interlocked.Increment(ref s_globalIdCounter);
			}
			return _schemaId;
		}
	}

	[XmlIgnore]
	internal bool IsChameleon
	{
		get
		{
			return _isChameleon;
		}
		set
		{
			_isChameleon = value;
		}
	}

	[XmlIgnore]
	internal Hashtable Ids => _ids;

	[XmlIgnore]
	internal XmlDocument Document => _003CDocument_003Ek__BackingField ?? (_003CDocument_003Ek__BackingField = new XmlDocument());

	[XmlIgnore]
	internal int ErrorCount
	{
		get
		{
			return _errorCount;
		}
		set
		{
			_errorCount = value;
		}
	}

	[XmlIgnore]
	internal override string? IdAttribute
	{
		get
		{
			return Id;
		}
		set
		{
			Id = value;
		}
	}

	internal ArrayList ImportedSchemas => _003CImportedSchemas_003Ek__BackingField ?? (_003CImportedSchemas_003Ek__BackingField = new ArrayList());

	internal ArrayList ImportedNamespaces => _003CImportedNamespaces_003Ek__BackingField ?? (_003CImportedNamespaces_003Ek__BackingField = new ArrayList());

	public static XmlSchema? Read(XmlReader reader, ValidationEventHandler? validationEventHandler)
	{
		ArgumentNullException.ThrowIfNull(reader, "reader");
		XmlNameTable nameTable = reader.NameTable;
		Parser parser = new Parser(SchemaType.XSD, nameTable, new SchemaNames(nameTable), validationEventHandler);
		try
		{
			parser.Parse(reader, null);
		}
		catch (XmlSchemaException ex)
		{
			if (validationEventHandler != null)
			{
				validationEventHandler(null, new ValidationEventArgs(ex));
				return null;
			}
			throw;
		}
		return parser.XmlSchema;
	}

	internal void CompileSchemaInSet(XmlNameTable nameTable, ValidationEventHandler eventHandler, XmlSchemaCompilationSettings compilationSettings)
	{
		Compiler compiler = new Compiler(nameTable, eventHandler, null, compilationSettings);
		compiler.Prepare(this, cleanup: true);
		_isCompiledBySet = compiler.Compile();
	}

	internal XmlSchema DeepClone()
	{
		XmlSchema xmlSchema = new XmlSchema();
		xmlSchema._attributeFormDefault = _attributeFormDefault;
		xmlSchema._elementFormDefault = _elementFormDefault;
		xmlSchema._blockDefault = _blockDefault;
		xmlSchema._finalDefault = _finalDefault;
		xmlSchema._targetNs = _targetNs;
		xmlSchema._version = _version;
		xmlSchema._isPreprocessed = _isPreprocessed;
		for (int i = 0; i < _items.Count; i++)
		{
			XmlSchemaObject item = ((_items[i] is XmlSchemaComplexType xmlSchemaComplexType) ? xmlSchemaComplexType.Clone(this) : ((_items[i] is XmlSchemaElement xmlSchemaElement) ? xmlSchemaElement.Clone(this) : ((!(_items[i] is XmlSchemaGroup xmlSchemaGroup)) ? _items[i].Clone() : xmlSchemaGroup.Clone(this))));
			xmlSchema.Items.Add(item);
		}
		for (int j = 0; j < _includes.Count; j++)
		{
			XmlSchemaExternal item2 = (XmlSchemaExternal)_includes[j].Clone();
			xmlSchema.Includes.Add(item2);
		}
		xmlSchema.Namespaces = base.Namespaces;
		xmlSchema.BaseUri = BaseUri;
		return xmlSchema;
	}

	internal override void SetUnhandledAttributes(XmlAttribute[] moreAttributes)
	{
		_moreAttributes = moreAttributes;
	}

	internal override void AddAnnotation(XmlSchemaAnnotation annotation)
	{
		_items.Add(annotation);
	}

	internal static void GetExternalSchemasList(IList extList, XmlSchema schema)
	{
		if (extList.Contains(schema))
		{
			return;
		}
		extList.Add(schema);
		for (int i = 0; i < schema.Includes.Count; i++)
		{
			XmlSchemaExternal xmlSchemaExternal = (XmlSchemaExternal)schema.Includes[i];
			if (xmlSchemaExternal.Schema != null)
			{
				GetExternalSchemasList(extList, xmlSchemaExternal.Schema);
			}
		}
	}
}
