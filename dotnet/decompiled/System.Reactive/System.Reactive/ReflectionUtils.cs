using System.Reflection;

namespace System.Reactive;

internal static class ReflectionUtils
{
	public static TDelegate CreateDelegate<TDelegate>(object o, MethodInfo method)
	{
		return (TDelegate)(object)method.CreateDelegate(typeof(TDelegate), o);
	}
}
