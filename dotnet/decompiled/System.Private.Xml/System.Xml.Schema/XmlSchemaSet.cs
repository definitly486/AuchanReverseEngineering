using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Xml.Schema;

public class XmlSchemaSet
{
	private readonly XmlNameTable _nameTable;

	private SchemaNames _schemaNames;

	private readonly SortedList _schemas;

	private readonly ValidationEventHandler _internalEventHandler;

	private ValidationEventHandler _eventHandler;

	private bool _isCompiled;

	private readonly Hashtable _schemaLocations;

	private readonly Hashtable _chameleonSchemas;

	private readonly Hashtable _targetNamespaces;

	private bool _compileAll;

	private SchemaInfo _cachedCompiledInfo;

	private readonly XmlReaderSettings _readerSettings;

	private XmlSchema _schemaForSchema;

	private XmlSchemaCompilationSettings _compilationSettings;

	internal XmlSchemaObjectTable elements;

	internal XmlSchemaObjectTable attributes;

	internal XmlSchemaObjectTable schemaTypes;

	internal XmlSchemaObjectTable substitutionGroups;

	private XmlSchemaObjectTable _typeExtensions;

	[CompilerGenerated]
	private object _003CInternalSyncObject_003Ek__BackingField;

	internal object InternalSyncObject => _003CInternalSyncObject_003Ek__BackingField ?? Interlocked.CompareExchange(ref _003CInternalSyncObject_003Ek__BackingField, new object(), null) ?? _003CInternalSyncObject_003Ek__BackingField;

	public XmlNameTable NameTable => _nameTable;

	public bool IsCompiled => _isCompiled;

	public XmlResolver? XmlResolver
	{
		set
		{
			_readerSettings.XmlResolver = value;
		}
	}

	public XmlSchemaCompilationSettings CompilationSettings
	{
		get
		{
			return _compilationSettings;
		}
		set
		{
			_compilationSettings = value;
		}
	}

	public int Count => _schemas.Count;

	public XmlSchemaObjectTable GlobalElements => elements ?? (elements = new XmlSchemaObjectTable());

	public XmlSchemaObjectTable GlobalAttributes => attributes ?? (attributes = new XmlSchemaObjectTable());

	public XmlSchemaObjectTable GlobalTypes => schemaTypes ?? (schemaTypes = new XmlSchemaObjectTable());

	internal XmlSchemaObjectTable SubstitutionGroups => substitutionGroups ?? (substitutionGroups = new XmlSchemaObjectTable());

	internal XmlSchemaObjectTable TypeExtensions => _typeExtensions ?? (_typeExtensions = new XmlSchemaObjectTable());

	internal SortedList SortedSchemas => _schemas;

	public event ValidationEventHandler ValidationEventHandler
	{
		add
		{
			_eventHandler = (ValidationEventHandler)Delegate.Remove(_eventHandler, _internalEventHandler);
			_eventHandler = (ValidationEventHandler)Delegate.Combine(_eventHandler, value);
			if (_eventHandler == null)
			{
				_eventHandler = _internalEventHandler;
			}
		}
		remove
		{
			_eventHandler = (ValidationEventHandler)Delegate.Remove(_eventHandler, value);
			if (_eventHandler == null)
			{
				_eventHandler = _internalEventHandler;
			}
		}
	}

	public XmlSchemaSet()
		: this(new NameTable())
	{
	}

	public XmlSchemaSet(XmlNameTable nameTable)
	{
		ArgumentNullException.ThrowIfNull(nameTable, "nameTable");
		_nameTable = nameTable;
		_schemas = new SortedList();
		_schemaLocations = new Hashtable();
		_chameleonSchemas = new Hashtable();
		_targetNamespaces = new Hashtable();
		_internalEventHandler = InternalValidationCallback;
		_eventHandler = _internalEventHandler;
		_readerSettings = new XmlReaderSettings();
		if (_readerSettings.GetXmlResolver() == null)
		{
			_readerSettings.XmlResolver = XmlReaderSettings.GetDefaultPermissiveResolver();
			_readerSettings.IsXmlResolverSet = false;
		}
		_readerSettings.NameTable = nameTable;
		_readerSettings.DtdProcessing = DtdProcessing.Prohibit;
		_compilationSettings = new XmlSchemaCompilationSettings();
		_cachedCompiledInfo = new SchemaInfo();
		_compileAll = true;
	}

	public XmlSchema? Add(XmlSchema schema)
	{
		ArgumentNullException.ThrowIfNull(schema, "schema");
		lock (InternalSyncObject)
		{
			if (_schemas.ContainsKey(schema.SchemaId))
			{
				return schema;
			}
			return Add(schema.TargetNamespace, schema);
		}
	}

	public bool Contains(string? targetNamespace)
	{
		if (targetNamespace == null)
		{
			targetNamespace = string.Empty;
		}
		return _targetNamespaces[targetNamespace] != null;
	}

	public void Compile()
	{
		if (_isCompiled)
		{
			return;
		}
		if (_schemas.Count == 0)
		{
			ClearTables();
			_cachedCompiledInfo = new SchemaInfo();
			_isCompiled = true;
			_compileAll = false;
			return;
		}
		lock (InternalSyncObject)
		{
			if (_isCompiled)
			{
				return;
			}
			Compiler compiler = new Compiler(_nameTable, _eventHandler, _schemaForSchema, _compilationSettings);
			SchemaInfo schemaInfo = new SchemaInfo();
			int i = 0;
			if (!_compileAll)
			{
				compiler.ImportAllCompiledSchemas(this);
			}
			try
			{
				XmlSchema buildInSchema = Preprocessor.GetBuildInSchema();
				for (i = 0; i < _schemas.Count; i++)
				{
					XmlSchema xmlSchema = (XmlSchema)_schemas.GetByIndex(i);
					Monitor.Enter(xmlSchema);
					if (!xmlSchema.IsPreprocessed)
					{
						SendValidationEvent(new XmlSchemaException("Sch_SchemaNotPreprocessed", string.Empty), XmlSeverityType.Error);
						_isCompiled = false;
						return;
					}
					if (xmlSchema.IsCompiledBySet)
					{
						if (!_compileAll)
						{
							continue;
						}
						if (xmlSchema == buildInSchema)
						{
							compiler.Prepare(xmlSchema, cleanup: false);
							continue;
						}
					}
					compiler.Prepare(xmlSchema, cleanup: true);
				}
				_isCompiled = compiler.Execute(this, schemaInfo);
				if (_isCompiled)
				{
					if (!_compileAll)
					{
						schemaInfo.Add(_cachedCompiledInfo, _eventHandler);
					}
					_compileAll = false;
					_cachedCompiledInfo = schemaInfo;
				}
			}
			finally
			{
				if (i == _schemas.Count)
				{
					i--;
				}
				for (int num = i; num >= 0; num--)
				{
					XmlSchema xmlSchema2 = (XmlSchema)_schemas.GetByIndex(num);
					if (xmlSchema2 == Preprocessor.GetBuildInSchema())
					{
						Monitor.Exit(xmlSchema2);
					}
					else
					{
						xmlSchema2.IsCompiledBySet = _isCompiled;
						Monitor.Exit(xmlSchema2);
					}
				}
			}
		}
	}

	public XmlSchema Reprocess(XmlSchema schema)
	{
		ArgumentNullException.ThrowIfNull(schema, "schema");
		if (!_schemas.ContainsKey(schema.SchemaId))
		{
			throw new ArgumentException("Sch_SchemaDoesNotExist", "schema");
		}
		XmlSchema result = schema;
		lock (InternalSyncObject)
		{
			RemoveSchemaFromGlobalTables(schema);
			RemoveSchemaFromCaches(schema);
			if (schema.BaseUri != null)
			{
				_schemaLocations.Remove(schema.BaseUri);
			}
			string targetNamespace = GetTargetNamespace(schema);
			if (Schemas(targetNamespace).Count == 0)
			{
				_targetNamespaces.Remove(targetNamespace);
			}
			_isCompiled = false;
			_compileAll = true;
			if (schema.ErrorCount != 0)
			{
				return result;
			}
			if (PreprocessSchema(ref schema, schema.TargetNamespace))
			{
				if (_targetNamespaces[targetNamespace] == null)
				{
					_targetNamespaces.Add(targetNamespace, targetNamespace);
				}
				if (_schemaForSchema == null && targetNamespace == "http://www.w3.org/2001/XMLSchema" && schema.SchemaTypes[DatatypeImplementation.QnAnyType] != null)
				{
					_schemaForSchema = schema;
				}
				for (int i = 0; i < schema.ImportedSchemas.Count; i++)
				{
					XmlSchema xmlSchema = (XmlSchema)schema.ImportedSchemas[i];
					if (!_schemas.ContainsKey(xmlSchema.SchemaId))
					{
						_schemas.Add(xmlSchema.SchemaId, xmlSchema);
					}
					targetNamespace = GetTargetNamespace(xmlSchema);
					if (_targetNamespaces[targetNamespace] == null)
					{
						_targetNamespaces.Add(targetNamespace, targetNamespace);
					}
					if (_schemaForSchema == null && targetNamespace == "http://www.w3.org/2001/XMLSchema" && schema.SchemaTypes[DatatypeImplementation.QnAnyType] != null)
					{
						_schemaForSchema = schema;
					}
				}
				return schema;
			}
			return result;
		}
	}

	public ICollection Schemas()
	{
		return _schemas.Values;
	}

	public ICollection Schemas(string? targetNamespace)
	{
		ArrayList arrayList = new ArrayList();
		if (targetNamespace == null)
		{
			targetNamespace = string.Empty;
		}
		for (int i = 0; i < _schemas.Count; i++)
		{
			XmlSchema xmlSchema = (XmlSchema)_schemas.GetByIndex(i);
			if (GetTargetNamespace(xmlSchema) == targetNamespace)
			{
				arrayList.Add(xmlSchema);
			}
		}
		return arrayList;
	}

	private XmlSchema Add(string targetNamespace, XmlSchema schema)
	{
		if (schema == null || schema.ErrorCount != 0)
		{
			return null;
		}
		if (PreprocessSchema(ref schema, targetNamespace))
		{
			AddSchemaToSet(schema);
			_isCompiled = false;
			return schema;
		}
		return null;
	}

	private void AddSchemaToSet(XmlSchema schema)
	{
		_schemas.Add(schema.SchemaId, schema);
		string targetNamespace = GetTargetNamespace(schema);
		if (_targetNamespaces[targetNamespace] == null)
		{
			_targetNamespaces.Add(targetNamespace, targetNamespace);
		}
		if (_schemaForSchema == null && targetNamespace == "http://www.w3.org/2001/XMLSchema" && schema.SchemaTypes[DatatypeImplementation.QnAnyType] != null)
		{
			_schemaForSchema = schema;
		}
		for (int i = 0; i < schema.ImportedSchemas.Count; i++)
		{
			XmlSchema xmlSchema = (XmlSchema)schema.ImportedSchemas[i];
			if (!_schemas.ContainsKey(xmlSchema.SchemaId))
			{
				_schemas.Add(xmlSchema.SchemaId, xmlSchema);
			}
			targetNamespace = GetTargetNamespace(xmlSchema);
			if (_targetNamespaces[targetNamespace] == null)
			{
				_targetNamespaces.Add(targetNamespace, targetNamespace);
			}
			if (_schemaForSchema == null && targetNamespace == "http://www.w3.org/2001/XMLSchema" && schema.SchemaTypes[DatatypeImplementation.QnAnyType] != null)
			{
				_schemaForSchema = schema;
			}
		}
	}

	private void ClearTables()
	{
		GlobalElements.Clear();
		GlobalAttributes.Clear();
		GlobalTypes.Clear();
		SubstitutionGroups.Clear();
		TypeExtensions.Clear();
	}

	internal bool PreprocessSchema(ref XmlSchema schema, string targetNamespace)
	{
		Preprocessor preprocessor = new Preprocessor(_nameTable, GetSchemaNames(_nameTable), _eventHandler, _compilationSettings);
		preprocessor.XmlResolver = _readerSettings.GetXmlResolver_CheckConfig();
		preprocessor.ReaderSettings = _readerSettings;
		preprocessor.SchemaLocations = _schemaLocations;
		preprocessor.ChameleonSchemas = _chameleonSchemas;
		bool result = preprocessor.Execute(schema, targetNamespace, loadExternals: true);
		schema = preprocessor.RootSchema;
		return result;
	}

	internal SchemaNames GetSchemaNames(XmlNameTable nt)
	{
		if (_nameTable != nt)
		{
			return new SchemaNames(nt);
		}
		return _schemaNames ?? (_schemaNames = new SchemaNames(_nameTable));
	}

	internal static string GetTargetNamespace(XmlSchema schema)
	{
		return schema.TargetNamespace ?? string.Empty;
	}

	private void RemoveSchemaFromCaches(XmlSchema schema)
	{
		List<XmlSchema> list = new List<XmlSchema>();
		XmlSchema.GetExternalSchemasList(list, schema);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].BaseUri != null && list[i].BaseUri.OriginalString.Length != 0)
			{
				_schemaLocations.Remove(list[i].BaseUri);
			}
			ICollection keys = _chameleonSchemas.Keys;
			ArrayList arrayList = new ArrayList();
			foreach (ChameleonKey item in keys)
			{
				if (item.chameleonLocation.Equals(list[i].BaseUri) && (item.originalSchema == null || item.originalSchema == list[i]))
				{
					arrayList.Add(item);
				}
			}
			for (int j = 0; j < arrayList.Count; j++)
			{
				_chameleonSchemas.Remove(arrayList[j]);
			}
		}
	}

	private void RemoveSchemaFromGlobalTables(XmlSchema schema)
	{
		if (_schemas.Count == 0)
		{
			return;
		}
		VerifyTables();
		foreach (XmlSchemaElement value in schema.Elements.Values)
		{
			if ((XmlSchemaElement)elements[value.QualifiedName] == value)
			{
				elements.Remove(value.QualifiedName);
			}
		}
		foreach (XmlSchemaAttribute value2 in schema.Attributes.Values)
		{
			if ((XmlSchemaAttribute)attributes[value2.QualifiedName] == value2)
			{
				attributes.Remove(value2.QualifiedName);
			}
		}
		foreach (XmlSchemaType value3 in schema.SchemaTypes.Values)
		{
			if ((XmlSchemaType)schemaTypes[value3.QualifiedName] == value3)
			{
				schemaTypes.Remove(value3.QualifiedName);
			}
		}
	}

	private void VerifyTables()
	{
		if (elements == null)
		{
			elements = new XmlSchemaObjectTable();
		}
		if (attributes == null)
		{
			attributes = new XmlSchemaObjectTable();
		}
		if (schemaTypes == null)
		{
			schemaTypes = new XmlSchemaObjectTable();
		}
		if (substitutionGroups == null)
		{
			substitutionGroups = new XmlSchemaObjectTable();
		}
	}

	private void InternalValidationCallback(object sender, ValidationEventArgs e)
	{
		if (e.Severity == XmlSeverityType.Error)
		{
			throw e.Exception;
		}
	}

	private void SendValidationEvent(XmlSchemaException e, XmlSeverityType severity)
	{
		if (_eventHandler != null)
		{
			_eventHandler(this, new ValidationEventArgs(e, severity));
			return;
		}
		throw e;
	}
}
