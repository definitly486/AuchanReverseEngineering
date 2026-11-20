namespace System.Xml.Schema;

internal class BaseValidator
{
	protected static void ProcessEntity(SchemaInfo sinfo, string name, object sender, ValidationEventHandler eventhandler, string baseUri, int lineNumber, int linePosition)
	{
		XmlSchemaException ex = null;
		if (!sinfo.GeneralEntities.TryGetValue(new XmlQualifiedName(name), out var value))
		{
			ex = new XmlSchemaException("Sch_UndeclaredEntity", name, baseUri, lineNumber, linePosition);
		}
		else if (value.NData.IsEmpty)
		{
			ex = new XmlSchemaException("Sch_UnparsedEntityRef", name, baseUri, lineNumber, linePosition);
		}
		if (ex != null)
		{
			if (eventhandler == null)
			{
				throw ex;
			}
			eventhandler(sender, new ValidationEventArgs(ex));
		}
	}
}
