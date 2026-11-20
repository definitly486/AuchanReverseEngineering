using System;
using System.Runtime.CompilerServices;

namespace Android.App;

[Serializable]
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class MetaDataAttribute : Attribute
{
	[CompilerGenerated]
	private string _003CName_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CResource_003Ek__BackingField;

	private string Name
	{
		[CompilerGenerated]
		set
		{
			_003CName_003Ek__BackingField = value;
		}
	}

	public string? Resource
	{
		[CompilerGenerated]
		set
		{
			_003CResource_003Ek__BackingField = value;
		}
	}

	public MetaDataAttribute(string name)
	{
		Name = name;
	}
}
