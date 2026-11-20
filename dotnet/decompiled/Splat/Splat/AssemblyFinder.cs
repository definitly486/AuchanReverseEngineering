using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Splat;

internal static class AssemblyFinder
{
	[RequiresUnreferencedCode("Calls AssemblyFinder.AttemptToLoadType<T>(string)")]
	[RequiresDynamicCode("Calls AssemblyFinder.AttemptToLoadType<T>(string)")]
	public static T? AttemptToLoadType<T>(string fullTypeName)
	{
		Type typeFromHandle = typeof(AssemblyFinder);
		string assemblyQualifiedName = typeFromHandle.AssemblyQualifiedName;
		if (assemblyQualifiedName == null)
		{
			return default(T);
		}
		AssemblyName[] array = new string[2]
		{
			assemblyQualifiedName.Replace(typeFromHandle.FullName + ", ", string.Empty, StringComparison.CurrentCulture),
			assemblyQualifiedName.Replace(typeFromHandle.FullName + ", ", string.Empty, StringComparison.CurrentCulture).Replace(".Portable", string.Empty, StringComparison.CurrentCulture)
		}.Select((string x) => new AssemblyName(x)).ToArray();
		foreach (AssemblyName assemblyName in array)
		{
			Type type = Type.GetType(fullTypeName + ", " + assemblyName.FullName, throwOnError: false);
			if ((object)type != null)
			{
				GC.KeepAlive(type);
				return (T)Activator.CreateInstance(type);
			}
		}
		return default(T);
	}
}
