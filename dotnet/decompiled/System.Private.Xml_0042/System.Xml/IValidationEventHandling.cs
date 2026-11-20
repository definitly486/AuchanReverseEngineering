using System.Xml.Schema;

namespace System.Xml;

internal interface IValidationEventHandling
{
	void SendEvent(Exception exception, XmlSeverityType severity);
}
