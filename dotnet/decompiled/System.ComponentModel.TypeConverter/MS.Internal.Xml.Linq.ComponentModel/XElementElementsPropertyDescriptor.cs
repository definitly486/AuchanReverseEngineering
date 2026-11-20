using System.Collections.Generic;
using System.Xml.Linq;

namespace MS.Internal.Xml.Linq.ComponentModel;

internal sealed class XElementElementsPropertyDescriptor : XPropertyDescriptor<XElement, IEnumerable<XElement>>
{
	private XDeferredAxis<XElement> _value;

	public XElementElementsPropertyDescriptor()
		: base("Elements")
	{
	}

	public override object GetValue(object component)
	{
		return _value = new XDeferredAxis<XElement>((XElement e, XName n) => (!(n != null)) ? e.Elements() : e.Elements(n), component as XElement, null);
	}
}
