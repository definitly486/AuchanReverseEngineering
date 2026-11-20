using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace MS.Internal.Xml.Linq.ComponentModel;

[DefaultMember("Item")]
internal sealed class XDeferredAxis<T> : IEnumerable<T>, IEnumerable where T : XObject
{
	private readonly Func<XElement, XName, IEnumerable<T>> _func;

	internal XElement element;

	internal XName name;

	public XDeferredAxis(Func<XElement, XName, IEnumerable<T>> func, XElement element, XName name)
	{
		ArgumentNullException.ThrowIfNull(func, "func");
		ArgumentNullException.ThrowIfNull(element, "element");
		_func = func;
		this.element = element;
		this.name = name;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _func(element, name).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
