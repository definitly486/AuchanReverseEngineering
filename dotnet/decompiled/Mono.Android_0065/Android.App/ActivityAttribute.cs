using System;
using System.Runtime.CompilerServices;
using Android.Content.PM;
using Android.Views;
using Java.Interop;

namespace Android.App;

[Serializable]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class ActivityAttribute : Attribute, IJniNameProviderAttribute
{
	[CompilerGenerated]
	private ConfigChanges _003CConfigurationChanges_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CExported_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CLabel_003Ek__BackingField;

	[CompilerGenerated]
	private LaunchMode _003CLaunchMode_003Ek__BackingField;

	[CompilerGenerated]
	private ScreenOrientation _003CScreenOrientation_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CTheme_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CMainLauncher_003Ek__BackingField;

	public ConfigChanges ConfigurationChanges
	{
		[CompilerGenerated]
		set
		{
			_003CConfigurationChanges_003Ek__BackingField = value;
		}
	}

	public bool Exported
	{
		[CompilerGenerated]
		set
		{
			_003CExported_003Ek__BackingField = value;
		}
	}

	public string? Label
	{
		[CompilerGenerated]
		set
		{
			_003CLabel_003Ek__BackingField = value;
		}
	}

	public LaunchMode LaunchMode
	{
		[CompilerGenerated]
		set
		{
			_003CLaunchMode_003Ek__BackingField = value;
		}
	}

	public string? Name { get; set; }

	public ScreenOrientation ScreenOrientation
	{
		[CompilerGenerated]
		set
		{
			_003CScreenOrientation_003Ek__BackingField = value;
		}
	}

	public string? Theme
	{
		[CompilerGenerated]
		set
		{
			_003CTheme_003Ek__BackingField = value;
		}
	}

	public SoftInput WindowSoftInputMode { get; set; }

	string IJniNameProviderAttribute.Name => Name ?? "";

	public bool MainLauncher
	{
		[CompilerGenerated]
		set
		{
			_003CMainLauncher_003Ek__BackingField = value;
		}
	}
}
