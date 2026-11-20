using System;
using System.Runtime.CompilerServices;
using Java.Interop;

namespace Android.Content;

[Serializable]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class BroadcastReceiverAttribute : Attribute, IJniNameProviderAttribute
{
	[CompilerGenerated]
	private bool _003CEnabled_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CExported_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CLabel_003Ek__BackingField;

	public bool Enabled
	{
		[CompilerGenerated]
		set
		{
			_003CEnabled_003Ek__BackingField = value;
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

	public string? Name { get; }

	string IJniNameProviderAttribute.Name => Name ?? "";
}
