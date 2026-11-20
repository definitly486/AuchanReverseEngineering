namespace System.Xml.Serialization;

public class XmlNodeEventArgs : EventArgs
{
	private readonly object _o;

	private readonly XmlNode _xmlNode;

	private readonly int _lineNumber;

	private readonly int _linePosition;

	internal XmlNodeEventArgs(XmlNode xmlNode, int lineNumber, int linePosition, object o)
	{
		_o = o;
		_xmlNode = xmlNode;
		_lineNumber = lineNumber;
		_linePosition = linePosition;
	}
}
