namespace System.Xml.Schema;

internal sealed class XdrValidator : BaseValidator
{
	public static void CheckDefaultValue(string value, SchemaAttDef attdef, SchemaInfo sinfo, XmlNamespaceManager nsManager, XmlNameTable NameTable, object sender, ValidationEventHandler eventhandler, string baseUri, int lineNo, int linePos)
	{
		try
		{
			XmlSchemaDatatype datatype = attdef.Datatype;
			if (datatype == null)
			{
				return;
			}
			if (datatype.TokenizedType != XmlTokenizedType.CDATA)
			{
				value = value.Trim();
			}
			if (value.Length == 0)
			{
				return;
			}
			object obj = datatype.ParseValue(value, NameTable, nsManager);
			switch (datatype.TokenizedType)
			{
			case XmlTokenizedType.ENTITY:
				if (datatype.Variety == XmlSchemaDatatypeVariety.List)
				{
					string[] array = (string[])obj;
					for (int i = 0; i < array.Length; i++)
					{
						BaseValidator.ProcessEntity(sinfo, array[i], sender, eventhandler, baseUri, lineNo, linePos);
					}
				}
				else
				{
					BaseValidator.ProcessEntity(sinfo, (string)obj, sender, eventhandler, baseUri, lineNo, linePos);
				}
				break;
			case XmlTokenizedType.ENUMERATION:
				if (!attdef.CheckEnumeration(obj))
				{
					XmlSchemaException ex = new XmlSchemaException("Sch_EnumerationValue", obj.ToString(), baseUri, lineNo, linePos);
					if (eventhandler == null)
					{
						throw ex;
					}
					eventhandler(sender, new ValidationEventArgs(ex));
				}
				break;
			}
			attdef.DefaultValueTyped = obj;
		}
		catch
		{
			XmlSchemaException ex2 = new XmlSchemaException("Sch_AttributeDefaultDataType", attdef.Name.ToString(), baseUri, lineNo, linePos);
			if (eventhandler != null)
			{
				eventhandler(sender, new ValidationEventArgs(ex2));
				return;
			}
			throw ex2;
		}
	}
}
