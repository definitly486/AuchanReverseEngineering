using System;
using System.Runtime.CompilerServices;

namespace Android.Runtime;

[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
public class RequiresPermissionAttribute : Attribute
{
	[CompilerGenerated]
	private string _003CValue_003Ek__BackingField;

	public string Value
	{
		[CompilerGenerated]
		set
		{
			_003CValue_003Ek__BackingField = value;
		}
	}

	public RequiresPermissionAttribute(string value)
	{
		Value = value;
	}
}
