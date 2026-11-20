using System.Xml.Linq;

namespace MS.Internal.Xml.Linq.ComponentModel;

internal sealed class XElementAttributePropertyDescriptor : XPropertyDescriptor<XElement, object>
{
	private XDeferredSingleton<XAttribute> _value;

	public XElementAttributePropertyDescriptor()
		: base("Attribute")
	{
	}

	public override object GetValue(object component)
	{
		return _value = new XDeferredSingleton<XAttribute>((XElement e, XName n) => e.Attribute(n), component as XElement, null);
	}
}
