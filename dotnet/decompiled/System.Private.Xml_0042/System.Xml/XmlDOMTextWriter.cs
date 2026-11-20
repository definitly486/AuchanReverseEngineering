using System.IO;

namespace System.Xml;

internal sealed class XmlDOMTextWriter : XmlTextWriter
{
	public XmlDOMTextWriter(TextWriter w)
		: base(w)
	{
	}

	public override void WriteStartElement(string prefix, string localName, string ns)
	{
		if (string.IsNullOrEmpty(ns) && !string.IsNullOrEmpty(prefix))
		{
			prefix = string.Empty;
		}
		base.WriteStartElement(prefix, localName, ns);
	}

	public override void WriteStartAttribute(string prefix, string localName, string ns)
	{
		if (string.IsNullOrEmpty(ns) && !string.IsNullOrEmpty(prefix))
		{
			prefix = string.Empty;
		}
		base.WriteStartAttribute(prefix, localName, ns);
	}
}
