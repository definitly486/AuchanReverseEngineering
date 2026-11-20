namespace System;

[AttributeUsage(AttributeTargets.Class, Inherited = true)]
public sealed class AttributeUsageAttribute : Attribute
{
	private readonly AttributeTargets _attributeTarget;

	private bool _allowMultiple;

	private bool _inherited;

	public AttributeTargets ValidOn => _attributeTarget;

	public bool AllowMultiple
	{
		get
		{
			return _allowMultiple;
		}
		set
		{
			_allowMultiple = value;
		}
	}

	public bool Inherited
	{
		get
		{
			return _inherited;
		}
		set
		{
			_inherited = value;
		}
	}

	public AttributeUsageAttribute(AttributeTargets validOn)
	{
		_attributeTarget = validOn;
		_inherited = true;
	}
}
