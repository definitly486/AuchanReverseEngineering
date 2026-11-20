using System;
using Java.Interop;

namespace Android.Runtime;

[Obsolete("Use Java.Interop.TypeManager")]
public static class TypeManager
{
	public static string? LookupTypeMapping(string[] mappings, string javaType)
	{
		return Java.Interop.TypeManager.LookupTypeMapping(mappings, javaType);
	}

	public static void RegisterType(string java_class, Type t)
	{
		Java.Interop.TypeManager.RegisterType(java_class, t);
	}

	public static void RegisterPackage(string package, Converter<string, Type> lookup)
	{
		Java.Interop.TypeManager.RegisterPackage(package, lookup);
	}

	public static void RegisterPackages(string[] packages, Converter<string, Type>[] lookups)
	{
		Java.Interop.TypeManager.RegisterPackages(packages, lookups);
	}
}
