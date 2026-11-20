using System;
using System.Runtime.CompilerServices;

namespace Java.Interop;

[Serializable]
[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false, Inherited = false)]
public class ExportParameterAttribute : Attribute
{
	public ExportParameterKind Kind
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
