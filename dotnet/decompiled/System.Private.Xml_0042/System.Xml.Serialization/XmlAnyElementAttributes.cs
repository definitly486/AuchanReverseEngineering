using System.Collections;

namespace System.Xml.Serialization;

public class XmlAnyElementAttributes : CollectionBase
{
	public XmlAnyElementAttribute? this[int index] => (XmlAnyElementAttribute)base.List[index];

	public int Add(XmlAnyElementAttribute? attribute)
	{
		return base.List.Add(attribute);
	}
}
