using System;
using System.Runtime.CompilerServices;

namespace Android.App;

[Serializable]
[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
public sealed class UsesFeatureAttribute : Attribute
{
	[CompilerGenerated]
	private string? _003CName_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CRequired_003Ek__BackingField;

	private string? Name
	{
		[CompilerGenerated]
		set
		{
			_003CName_003Ek__BackingField = value;
		}
	}

	public bool Required
	{
		[CompilerGenerated]
		set
		{
			_003CRequired_003Ek__BackingField = value;
		}
	}

	public UsesFeatureAttribute(string name)
	{
		Name = name;
	}
}
