using System.Collections.Generic;

namespace System.Xml.Schema;

internal sealed class SchemaInfo : IDtdInfo
{
	private readonly Dictionary<XmlQualifiedName, SchemaElementDecl> _elementDecls = new Dictionary<XmlQualifiedName, SchemaElementDecl>();

	private readonly Dictionary<XmlQualifiedName, SchemaElementDecl> _undeclaredElementDecls = new Dictionary<XmlQualifiedName, SchemaElementDecl>();

	private Dictionary<XmlQualifiedName, SchemaEntity> _generalEntities;

	private Dictionary<XmlQualifiedName, SchemaEntity> _parameterEntities;

	private XmlQualifiedName _docTypeName = XmlQualifiedName.Empty;

	private string _internalDtdSubset = string.Empty;

	private bool _hasNonCDataAttributes;

	private bool _hasDefaultAttributes;

	private readonly Dictionary<string, bool> _targetNamespaces = new Dictionary<string, bool>();

	private readonly Dictionary<XmlQualifiedName, SchemaAttDef> _attributeDecls = new Dictionary<XmlQualifiedName, SchemaAttDef>();

	private int _errorCount;

	private SchemaType _schemaType;

	private readonly Dictionary<XmlQualifiedName, SchemaElementDecl> _elementDeclsByType = new Dictionary<XmlQualifiedName, SchemaElementDecl>();

	private Dictionary<string, SchemaNotation> _notations;

	public XmlQualifiedName DocTypeName
	{
		set
		{
			_docTypeName = value;
		}
	}

	internal string InternalDtdSubset
	{
		set
		{
			_internalDtdSubset = value;
		}
	}

	internal Dictionary<XmlQualifiedName, SchemaElementDecl> ElementDecls => _elementDecls;

	internal Dictionary<XmlQualifiedName, SchemaElementDecl> UndeclaredElementDecls => _undeclaredElementDecls;

	internal Dictionary<XmlQualifiedName, SchemaEntity> GeneralEntities => _generalEntities ?? (_generalEntities = new Dictionary<XmlQualifiedName, SchemaEntity>());

	internal Dictionary<XmlQualifiedName, SchemaEntity> ParameterEntities => _parameterEntities ?? (_parameterEntities = new Dictionary<XmlQualifiedName, SchemaEntity>());

	internal SchemaType SchemaType
	{
		get
		{
			return _schemaType;
		}
		set
		{
			_schemaType = value;
		}
	}

	internal Dictionary<string, bool> TargetNamespaces => _targetNamespaces;

	internal Dictionary<XmlQualifiedName, SchemaElementDecl> ElementDeclsByType => _elementDeclsByType;

	internal Dictionary<XmlQualifiedName, SchemaAttDef> AttributeDecls => _attributeDecls;

	internal Dictionary<string, SchemaNotation> Notations => _notations ?? (_notations = new Dictionary<string, SchemaNotation>());

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

	bool IDtdInfo.HasDefaultAttributes => _hasDefaultAttributes;

	bool IDtdInfo.HasNonCDataAttributes => _hasNonCDataAttributes;

	XmlQualifiedName IDtdInfo.Name => _docTypeName;

	string IDtdInfo.InternalDtdSubset => _internalDtdSubset;

	internal SchemaInfo()
	{
		_schemaType = SchemaType.None;
	}

	internal void Add(SchemaInfo sinfo, ValidationEventHandler eventhandler)
	{
		if (_schemaType == SchemaType.None)
		{
			_schemaType = sinfo.SchemaType;
		}
		else if (_schemaType != sinfo.SchemaType)
		{
			eventhandler?.Invoke(this, new ValidationEventArgs(new XmlSchemaException("Sch_MixSchemaTypes", string.Empty)));
			return;
		}
		foreach (string key in sinfo.TargetNamespaces.Keys)
		{
			_targetNamespaces.TryAdd(key, value: true);
		}
		foreach (KeyValuePair<XmlQualifiedName, SchemaElementDecl> elementDecl in sinfo._elementDecls)
		{
			if (!_elementDecls.ContainsKey(elementDecl.Key))
			{
				_elementDecls.Add(elementDecl.Key, elementDecl.Value);
			}
		}
		foreach (KeyValuePair<XmlQualifiedName, SchemaElementDecl> item in sinfo._elementDeclsByType)
		{
			if (!_elementDeclsByType.ContainsKey(item.Key))
			{
				_elementDeclsByType.Add(item.Key, item.Value);
			}
		}
		foreach (SchemaAttDef value in sinfo.AttributeDecls.Values)
		{
			_attributeDecls.TryAdd(value.Name, value);
		}
		foreach (SchemaNotation value2 in sinfo.Notations.Values)
		{
			Notations.TryAdd(value2.Name.Name, value2);
		}
	}

	internal void Finish()
	{
		Dictionary<XmlQualifiedName, SchemaElementDecl> dictionary = _elementDecls;
		for (int i = 0; i < 2; i++)
		{
			foreach (SchemaElementDecl value in dictionary.Values)
			{
				if (value.HasNonCDataAttribute)
				{
					_hasNonCDataAttributes = true;
				}
				if (value.DefaultAttDefs != null)
				{
					_hasDefaultAttributes = true;
				}
			}
			dictionary = _undeclaredElementDecls;
		}
	}

	IDtdAttributeListInfo IDtdInfo.LookupAttributeList(string prefix, string localName)
	{
		XmlQualifiedName key = new XmlQualifiedName(prefix, localName);
		if (!_elementDecls.TryGetValue(key, out var value))
		{
			_undeclaredElementDecls.TryGetValue(key, out value);
		}
		return value;
	}

	IDtdEntityInfo IDtdInfo.LookupEntity(string name)
	{
		if (_generalEntities == null)
		{
			return null;
		}
		XmlQualifiedName key = new XmlQualifiedName(name);
		if (_generalEntities.TryGetValue(key, out var value))
		{
			return value;
		}
		return null;
	}
}
