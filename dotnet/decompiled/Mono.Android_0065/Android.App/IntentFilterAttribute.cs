using System;
using System.Runtime.CompilerServices;

namespace Android.App;

[Serializable]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class IntentFilterAttribute : Attribute
{
	[CompilerGenerated]
	private readonly string[] _003CActions_003Ek__BackingField;

	[CompilerGenerated]
	private string[]? _003CCategories_003Ek__BackingField;

	[CompilerGenerated]
	private string[]? _003CDataHosts_003Ek__BackingField;

	[CompilerGenerated]
	private string[]? _003CDataSchemes_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CAutoVerify_003Ek__BackingField;

	public string[]? Categories
	{
		[CompilerGenerated]
		set
		{
			_003CCategories_003Ek__BackingField = value;
		}
	}

	public string[]? DataHosts
	{
		[CompilerGenerated]
		set
		{
			_003CDataHosts_003Ek__BackingField = value;
		}
	}

	public string[]? DataSchemes
	{
		[CompilerGenerated]
		set
		{
			_003CDataSchemes_003Ek__BackingField = value;
		}
	}

	public bool AutoVerify
	{
		[CompilerGenerated]
		set
		{
			_003CAutoVerify_003Ek__BackingField = value;
		}
	}

	public IntentFilterAttribute(string[] actions)
	{
		if (actions == null)
		{
			throw new ArgumentNullException("actions");
		}
		if (actions.Length < 1)
		{
			throw new ArgumentException("At least one action must be specified.", "actions");
		}
		_003CActions_003Ek__BackingField = actions;
	}
}
