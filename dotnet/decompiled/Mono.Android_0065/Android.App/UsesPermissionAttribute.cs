using System;
using System.Runtime.CompilerServices;

namespace Android.App;

[Serializable]
[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
public sealed class UsesPermissionAttribute : Attribute
{
	[CompilerGenerated]
	private string? _003CName_003Ek__BackingField;

	public string? Name
	{
		[CompilerGenerated]
		set
		{
			_003CName_003Ek__BackingField = value;
		}
	}

	public UsesPermissionAttribute(string name)
	{
		Name = name;
	}
}
