using System;
using System.Runtime.CompilerServices;

namespace Android.Runtime;

[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
public class StringDefAttribute : Attribute
{
	[CompilerGenerated]
	private string? _003CType_003Ek__BackingField;

	[CompilerGenerated]
	private string[]? _003CFields_003Ek__BackingField;

	public string? Type
	{
		[CompilerGenerated]
		set
		{
			_003CType_003Ek__BackingField = value;
		}
	}

	public string[]? Fields
	{
		[CompilerGenerated]
		set
		{
			_003CFields_003Ek__BackingField = value;
		}
	}
}
