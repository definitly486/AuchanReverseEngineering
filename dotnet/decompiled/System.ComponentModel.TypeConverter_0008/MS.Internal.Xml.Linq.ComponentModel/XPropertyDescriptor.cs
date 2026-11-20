using System;
using System.ComponentModel;
using System.Xml.Linq;

namespace MS.Internal.Xml.Linq.ComponentModel;

internal abstract class XPropertyDescriptor<T, TProperty> : PropertyDescriptor where T : XObject
{
	public override Type ComponentType => typeof(T);

	public override bool IsReadOnly => true;

	public override Type PropertyType => typeof(TProperty);

	public XPropertyDescriptor(string name)
		: base(name, null)
	{
	}

	public override bool CanResetValue(object component)
	{
		return false;
	}

	public override void ResetValue(object component)
	{
	}

	public override void SetValue(object component, object value)
	{
	}

	public override bool ShouldSerializeValue(object component)
	{
		return false;
	}
}
