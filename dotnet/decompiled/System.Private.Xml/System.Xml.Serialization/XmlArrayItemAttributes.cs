using System.Collections;

namespace System.Xml.Serialization;

public class XmlArrayItemAttributes : CollectionBase
{
	public XmlArrayItemAttribute? this[int index] => (XmlArrayItemAttribute)base.List[index];

	public int Add(XmlArrayItemAttribute? attribute)
	{
		return base.List.Add(attribute);
	}
}
