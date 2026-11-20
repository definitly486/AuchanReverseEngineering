namespace System.Xml.Schema;

internal sealed class Datatype_union : Datatype_anySimpleType
{
	private readonly XmlSchemaSimpleType[] _types;

	public override Type ValueType => typeof(object);

	public override XmlTypeCode TypeCode => XmlTypeCode.AnyAtomicType;

	internal override FacetsChecker FacetsChecker => DatatypeImplementation.unionFacetsChecker;

	internal override Type ListValueType => typeof(object[]);

	internal override RestrictionFlags ValidRestrictionFlags => RestrictionFlags.Pattern | RestrictionFlags.Enumeration;

	internal XmlSchemaSimpleType[] BaseMemberTypes => _types;

	internal override XmlValueConverter CreateValueConverter(XmlSchemaType schemaType)
	{
		return XmlUnionConverter.Create(schemaType);
	}

	internal Datatype_union(XmlSchemaSimpleType[] types)
	{
		_types = types;
	}

	internal override int Compare(object value1, object value2)
	{
		XsdSimpleValue xsdSimpleValue = value1 as XsdSimpleValue;
		XsdSimpleValue xsdSimpleValue2 = value2 as XsdSimpleValue;
		if (xsdSimpleValue == null || xsdSimpleValue2 == null)
		{
			return -1;
		}
		XmlSchemaType xmlType = xsdSimpleValue.XmlType;
		XmlSchemaType xmlType2 = xsdSimpleValue2.XmlType;
		if (xmlType == xmlType2)
		{
			return xmlType.Datatype.Compare(xsdSimpleValue.TypedValue, xsdSimpleValue2.TypedValue);
		}
		return -1;
	}

	internal bool HasAtomicMembers()
	{
		for (int i = 0; i < _types.Length; i++)
		{
			if (_types[i].Datatype.Variety == XmlSchemaDatatypeVariety.List)
			{
				return false;
			}
		}
		return true;
	}

	internal bool IsUnionBaseOf(DatatypeImplementation derivedType)
	{
		for (int i = 0; i < _types.Length; i++)
		{
			if (derivedType.IsDerivedFrom(_types[i].Datatype))
			{
				return true;
			}
		}
		return false;
	}

	internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue)
	{
		XmlSchemaSimpleType xmlSchemaSimpleType = null;
		typedValue = null;
		Exception ex = DatatypeImplementation.unionFacetsChecker.CheckLexicalFacets(ref s, this);
		if (ex == null)
		{
			for (int i = 0; i < _types.Length; i++)
			{
				ex = _types[i].Datatype.TryParseValue(s, nameTable, nsmgr, out typedValue);
				if (ex == null)
				{
					xmlSchemaSimpleType = _types[i];
					break;
				}
			}
			if (xmlSchemaSimpleType == null)
			{
				ex = new XmlSchemaException("Sch_UnionFailedEx", s);
			}
			else
			{
				typedValue = new XsdSimpleValue(xmlSchemaSimpleType, typedValue);
				ex = DatatypeImplementation.unionFacetsChecker.CheckValueFacets(typedValue, this);
				if (ex == null)
				{
					return null;
				}
			}
		}
		return ex;
	}
}
