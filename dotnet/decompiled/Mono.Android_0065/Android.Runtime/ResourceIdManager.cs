using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Android.Runtime;

public static class ResourceIdManager
{
	private static bool id_initialized;

	public static void UpdateIdValues()
	{
		if (id_initialized)
		{
			return;
		}
		id_initialized = true;
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		Type type = ((executingAssembly != null) ? GetResourceTypeFromAssembly(executingAssembly) : null);
		if (type == null)
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				type = GetResourceTypeFromAssembly(assemblies[i]);
				if (type != null)
				{
					break;
				}
			}
		}
		if (type != null)
		{
			MethodInfo method = type.GetMethod("UpdateIdValues");
			if (method != null)
			{
				((Action)method.CreateDelegate(typeof(Action)))();
			}
		}
	}

	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
	private static Type? GetResourceTypeFromAssembly(Assembly assembly)
	{
		object[] customAttributes = assembly.GetCustomAttributes(typeof(ResourceDesignerAttribute), inherit: true);
		for (int i = 0; i < customAttributes.Length; i++)
		{
			if (customAttributes[i] is ResourceDesignerAttribute { IsApplication: not false } resourceDesignerAttribute)
			{
				Type type = AssemblyGetType(assembly, resourceDesignerAttribute.FullName);
				if (type != null)
				{
					return type;
				}
			}
		}
		return null;
		[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Resources.UpdateIdValues() methods are trimmed away by the LinkResourceDesigner trimmer step. This codepath is not called unless $(AndroidUseDesignerAssembly) is disabled.")]
		[UnconditionalSuppressMessage("Trimming", "IL2073", Justification = "Resources.UpdateIdValues() methods are trimmed away by the LinkResourceDesigner trimmer step. This codepath is not called unless $(AndroidUseDesignerAssembly) is disabled.")]
		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
		static Type AssemblyGetType(Assembly a, string name)
		{
			return a.GetType(name);
		}
	}
}
