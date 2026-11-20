using System;
using System.Runtime.CompilerServices;

namespace Java.Interop;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface, AllowMultiple = false)]
public sealed class JavaTypeParametersAttribute : Attribute
{
	[CompilerGenerated]
	private readonly string[] _003CTypeParameters_003Ek__BackingField;

	public JavaTypeParametersAttribute(string[] typeParameters)
	{
		_003CTypeParameters_003Ek__BackingField = typeParameters;
	}
}
