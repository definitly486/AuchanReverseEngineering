using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Splat;

namespace Akavache;

[RequiresUnreferencedCode("Registrations for Akavache.Core")]
[RequiresDynamicCode("Registrations for Akavache.Core")]
public static class DependencyResolverMixin
{
	public static void InitializeAkavache(this IMutableDependencyResolver resolver, IReadonlyDependencyResolver readonlyDependencyResolver)
	{
		string[] obj = new string[7] { "Akavache", "Akavache.Core", "Akavache.Mac", "Akavache.Deprecated", "Akavache.Mobile", "Akavache.Sqlite3", "Akavache.Drawing" };
		Type typeFromHandle = typeof(DependencyResolverMixin);
		if (typeFromHandle?.AssemblyQualifiedName == null)
		{
			throw new InvalidOperationException("Cannot find valid assembly name for the DependencyResolverMixin class.");
		}
		AssemblyName assemblyName = new AssemblyName(typeFromHandle.AssemblyQualifiedName.Replace(typeFromHandle.FullName + ", ", string.Empty));
		if (assemblyName.Name == null)
		{
			throw new InvalidOperationException("Could not find a valid name for assembly");
		}
		string[] array = obj;
		foreach (string text in array)
		{
			Type type = Type.GetType(string.Concat(text + ".Registrations", ", ", assemblyName.FullName.Replace(assemblyName.Name, text)), throwOnError: false);
			if ((object)type != null)
			{
				((IWantsToRegisterStuff)Activator.CreateInstance(type))?.Register(resolver, readonlyDependencyResolver);
			}
		}
	}
}
