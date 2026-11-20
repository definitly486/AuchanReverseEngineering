using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Xml.Schema;

namespace System.Xml.Serialization;

internal sealed class SerializableMapping : SpecialMapping
{
	private XmlSchema _schema;

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
	private Type _type;

	private bool _needSchema = true;

	private readonly MethodInfo _getSchemaMethod;

	private XmlQualifiedName _xsiType;

	private XmlSchemaType _xsdType;

	private XmlSchemaSet _schemas;

	private bool _any;

	private SerializableMapping _baseMapping;

	private SerializableMapping _derivedMappings;

	private SerializableMapping _nextDerivedMapping;

	private SerializableMapping _next;

	internal bool IsAny
	{
		get
		{
			if (_any)
			{
				return true;
			}
			if (_getSchemaMethod == null)
			{
				return false;
			}
			if (_needSchema && typeof(XmlSchemaType).IsAssignableFrom(_getSchemaMethod.ReturnType))
			{
				return false;
			}
			RetrieveSerializableSchema();
			return _any;
		}
	}

	internal SerializableMapping DerivedMappings => _derivedMappings;

	internal SerializableMapping NextDerivedMapping => _nextDerivedMapping;

	internal SerializableMapping Next
	{
		get
		{
			return _next;
		}
		set
		{
			_next = value;
		}
	}

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
	internal Type Type
	{
		get
		{
			return _type;
		}
		set
		{
			_type = value;
		}
	}

	internal XmlSchemaSet Schemas
	{
		get
		{
			RetrieveSerializableSchema();
			return _schemas;
		}
	}

	internal XmlQualifiedName XsiType
	{
		get
		{
			if (!_needSchema)
			{
				return _xsiType;
			}
			if (_getSchemaMethod == null)
			{
				return null;
			}
			if (typeof(XmlSchemaType).IsAssignableFrom(_getSchemaMethod.ReturnType))
			{
				return null;
			}
			RetrieveSerializableSchema();
			return _xsiType;
		}
	}

	internal XmlSchemaType XsdType
	{
		get
		{
			RetrieveSerializableSchema();
			return _xsdType;
		}
	}

	internal SerializableMapping()
	{
	}

	internal SerializableMapping(MethodInfo getSchemaMethod, bool any, string ns)
	{
		_getSchemaMethod = getSchemaMethod;
		_any = any;
		base.Namespace = ns;
		_needSchema = getSchemaMethod != null;
	}

	internal SerializableMapping(XmlQualifiedName xsiType, XmlSchemaSet schemas)
	{
		_xsiType = xsiType;
		_schemas = schemas;
		base.TypeName = xsiType.Name;
		base.Namespace = xsiType.Namespace;
		_needSchema = false;
	}

	internal void SetBaseMapping(SerializableMapping mapping)
	{
		_baseMapping = mapping;
		if (_baseMapping != null)
		{
			_nextDerivedMapping = _baseMapping._derivedMappings;
			_baseMapping._derivedMappings = this;
			if (this == _nextDerivedMapping)
			{
				throw new InvalidOperationException(System.SR.Format("XmlCircularDerivation", base.TypeDesc.FullName));
			}
		}
	}

	internal static void ValidationCallbackWithErrorCode(object sender, ValidationEventArgs args)
	{
		if (args.Severity == XmlSeverityType.Error)
		{
			throw new InvalidOperationException(System.SR.Format("XmlSerializableSchemaError", "IXmlSerializable", args.Message));
		}
	}

	private void RetrieveSerializableSchema()
	{
		if (!_needSchema)
		{
			return;
		}
		_needSchema = false;
		if (_getSchemaMethod != null)
		{
			if (_schemas == null)
			{
				_schemas = new XmlSchemaSet();
			}
			object obj = _getSchemaMethod.Invoke(null, new object[1] { _schemas });
			_xsiType = XmlQualifiedName.Empty;
			if (obj != null)
			{
				if (typeof(XmlSchemaType).IsAssignableFrom(_getSchemaMethod.ReturnType))
				{
					_xsdType = (XmlSchemaType)obj;
					_xsiType = _xsdType.QualifiedName;
				}
				else
				{
					if (!typeof(XmlQualifiedName).IsAssignableFrom(_getSchemaMethod.ReturnType))
					{
						throw new InvalidOperationException(System.SR.Format("XmlGetSchemaMethodReturnType", _type.Name, _getSchemaMethod.Name, "XmlSchemaProviderAttribute", typeof(XmlQualifiedName).FullName));
					}
					_xsiType = (XmlQualifiedName)obj;
					if (_xsiType.IsEmpty)
					{
						throw new InvalidOperationException(System.SR.Format("XmlGetSchemaEmptyTypeName", _type.FullName, _getSchemaMethod.Name));
					}
				}
			}
			else
			{
				_any = true;
			}
			_schemas.ValidationEventHandler += ValidationCallbackWithErrorCode;
			_schemas.Compile();
			if (!_xsiType.IsEmpty && _xsiType.Namespace != "http://www.w3.org/2001/XMLSchema")
			{
				ArrayList obj2 = (ArrayList)_schemas.Schemas(_xsiType.Namespace);
				if (obj2.Count == 0)
				{
					throw new InvalidOperationException(System.SR.Format("XmlMissingSchema", _xsiType.Namespace));
				}
				if (obj2.Count > 1)
				{
					throw new InvalidOperationException(System.SR.Format("XmlGetSchemaInclude", _xsiType.Namespace, _getSchemaMethod.DeclaringType.FullName, _getSchemaMethod.Name));
				}
				XmlSchema xmlSchema = (XmlSchema)obj2[0];
				if (xmlSchema == null)
				{
					throw new InvalidOperationException(System.SR.Format("XmlMissingSchema", _xsiType.Namespace));
				}
				_xsdType = (XmlSchemaType)xmlSchema.SchemaTypes[_xsiType];
				if (_xsdType == null)
				{
					throw new InvalidOperationException(System.SR.Format("XmlGetSchemaTypeMissing", _getSchemaMethod.DeclaringType.FullName, _getSchemaMethod.Name, _xsiType.Name, _xsiType.Namespace));
				}
				_xsdType = _xsdType.Redefined ?? _xsdType;
			}
		}
		else
		{
			IXmlSerializable xmlSerializable = (IXmlSerializable)Activator.CreateInstance(_type);
			_schema = xmlSerializable.GetSchema();
			if (_schema != null && string.IsNullOrEmpty(_schema.Id))
			{
				throw new InvalidOperationException(System.SR.Format("XmlSerializableNameMissing1", _type.FullName));
			}
		}
	}
}
