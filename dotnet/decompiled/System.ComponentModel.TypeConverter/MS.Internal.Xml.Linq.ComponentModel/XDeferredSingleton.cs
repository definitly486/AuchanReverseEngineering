using System;
using System.Reflection;
using System.Xml.Linq;

namespace MS.Internal.Xml.Linq.ComponentModel;

[DefaultMember("Item")]
internal sealed class XDeferredSingleton<T> where T : XObject
{
	private readonly Func<XElement, XName, T> _func;

	internal XElement element;

	internal XName name;

	public XDeferredSingleton(Func<XElement, XName, T> func, XElement element, XName name)
	{
		ArgumentNullException.ThrowIfNull(func, "func");
		ArgumentNullException.ThrowIfNull(element, "element");
		_func = func;
		this.element = element;
		this.name = name;
	}
}
