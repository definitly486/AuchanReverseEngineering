namespace System.Xml.Schema;

internal sealed class DtdValidator : BaseValidator
{
	public static void SetDefaultTypedValue(SchemaAttDef attdef, IDtdParserAdapter readerAdapter)
	{
		try
		{
			string text = attdef.DefaultValueExpanded;
			XmlSchemaDatatype datatype = attdef.Datatype;
			if (datatype != null)
			{
				if (datatype.TokenizedType != XmlTokenizedType.CDATA)
				{
					text = text.Trim();
				}
				attdef.DefaultValueTyped = datatype.ParseValue(text, readerAdapter.NameTable, readerAdapter.NamespaceResolver);
			}
		}
		catch (Exception)
		{
			IValidationEventHandling validationEventHandling = ((IDtdParserAdapterWithValidation)readerAdapter).ValidationEventHandling;
			if (validationEventHandling != null)
			{
				XmlSchemaException exception = new XmlSchemaException("Sch_AttributeDefaultDataType", attdef.Name.ToString());
				validationEventHandling.SendEvent(exception, XmlSeverityType.Error);
			}
		}
	}
}
