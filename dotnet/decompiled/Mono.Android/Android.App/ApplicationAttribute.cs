using System;
using System.Runtime.CompilerServices;
using Java.Interop;

namespace Android.App;

[Serializable]
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class ApplicationAttribute : Attribute, IJniNameProviderAttribute
{
	[CompilerGenerated]
	private bool _003CAllowBackup_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CHardwareAccelerated_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CLabel_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CLargeHeap_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CNetworkSecurityConfig_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CSupportsRtl_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CTheme_003Ek__BackingField;

	public bool AllowBackup
	{
		[CompilerGenerated]
		set
		{
			_003CAllowBackup_003Ek__BackingField = value;
		}
	}

	public bool HardwareAccelerated
	{
		[CompilerGenerated]
		set
		{
			_003CHardwareAccelerated_003Ek__BackingField = value;
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

	public bool LargeHeap
	{
		[CompilerGenerated]
		set
		{
			_003CLargeHeap_003Ek__BackingField = value;
		}
	}

	public string? Name { get; }

	public string? NetworkSecurityConfig
	{
		[CompilerGenerated]
		set
		{
			_003CNetworkSecurityConfig_003Ek__BackingField = value;
		}
	}

	public bool SupportsRtl
	{
		[CompilerGenerated]
		set
		{
			_003CSupportsRtl_003Ek__BackingField = value;
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

	string IJniNameProviderAttribute.Name => Name ?? "";
}
