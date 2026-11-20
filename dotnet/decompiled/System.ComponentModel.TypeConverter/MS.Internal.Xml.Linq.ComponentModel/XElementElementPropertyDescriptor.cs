using System.Xml.Linq;

namespace MS.Internal.Xml.Linq.ComponentModel;

internal sealed class XElementElementPropertyDescriptor : XPropertyDescriptor<XElement, object>
{
	private XDeferredSingleton<XElement> _value;

	public XElementElementPropertyDescriptor()
		: base("Element")
	{
	}

	public override object GetValue(object component)
	{
		return _value = new XDeferredSingleton<XElement>((XElement e, XName n) => e.Element(n), component as XElement, null);
	}
}
