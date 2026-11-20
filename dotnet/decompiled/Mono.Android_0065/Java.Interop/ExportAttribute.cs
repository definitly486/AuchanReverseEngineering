using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Java.Interop;

[Serializable]
[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
[RequiresUnreferencedCode("[ExportAttribute] uses dynamic features.")]
public class ExportAttribute : Attribute
{
	[CompilerGenerated]
	private string? _003CName_003Ek__BackingField;

	private string? Name
	{
		[CompilerGenerated]
		set
		{
			_003CName_003Ek__BackingField = value;
		}
	}

	public ExportAttribute(string name)
	{
		Name = name;
	}
}
