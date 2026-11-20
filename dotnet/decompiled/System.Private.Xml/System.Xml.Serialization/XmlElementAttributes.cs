using System.Collections;

namespace System.Xml.Serialization;

public class XmlElementAttributes : CollectionBase
{
	public XmlElementAttribute? this[int index] => (XmlElementAttribute)base.List[index];

	public int Add(XmlElementAttribute? attribute)
	{
		return base.List.Add(attribute);
	}
}
