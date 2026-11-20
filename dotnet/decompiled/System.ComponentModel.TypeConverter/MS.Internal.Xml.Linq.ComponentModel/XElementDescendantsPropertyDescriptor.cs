using System.Collections.Generic;
using System.Xml.Linq;

namespace MS.Internal.Xml.Linq.ComponentModel;

internal sealed class XElementDescendantsPropertyDescriptor : XPropertyDescriptor<XElement, IEnumerable<XElement>>
{
	private XDeferredAxis<XElement> _value;

	public XElementDescendantsPropertyDescriptor()
		: base("Descendants")
	{
	}

	public override object GetValue(object component)
	{
		return _value = new XDeferredAxis<XElement>((XElement e, XName n) => (!(n != null)) ? e.Descendants() : e.Descendants(n), component as XElement, null);
	}
}
