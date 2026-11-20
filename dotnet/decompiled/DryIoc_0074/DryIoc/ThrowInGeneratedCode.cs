using System.Reflection;

namespace DryIoc;

public static class ThrowInGeneratedCode
{
	internal static readonly MethodInfo WeakRefReuseWrapperGCedMethod = typeof(ThrowInGeneratedCode).GetMethod("WeakRefReuseWrapperGCed");

	public static object WeakRefReuseWrapperGCed(this object obj)
	{
		if (obj == null)
		{
			Throw.It(Error.WeakRefReuseWrapperGCed);
		}
		return obj;
	}
}
