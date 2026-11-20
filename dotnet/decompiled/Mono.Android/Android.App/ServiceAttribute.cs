using System;
using System.Runtime.CompilerServices;
using Java.Interop;

namespace Android.App;

[Serializable]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class ServiceAttribute : Attribute, IJniNameProviderAttribute
{
	[CompilerGenerated]
	private string? _003CProcess_003Ek__BackingField;

	public string? Name { get; }

	public string? Process
	{
		[CompilerGenerated]
		set
		{
			_003CProcess_003Ek__BackingField = value;
		}
	}

	string IJniNameProviderAttribute.Name => Name ?? "";
}
