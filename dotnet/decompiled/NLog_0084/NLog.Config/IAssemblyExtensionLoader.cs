using System.Reflection;

namespace NLog.Config;

internal interface IAssemblyExtensionLoader
{
	void ScanForAutoLoadExtensions(ConfigurationItemFactory factory);

	void LoadAssemblyFromPath(ConfigurationItemFactory factory, string assemblyFileName, string? baseDirectory, string itemNamePrefix);

	void LoadAssemblyFromName(ConfigurationItemFactory factory, string assemblyName, string itemNamePrefix);

	void LoadTypeFromName(ConfigurationItemFactory factory, string typeName, string itemNamePrefix);

	void LoadAssembly(ConfigurationItemFactory factory, Assembly assembly, string itemNamePrefix);
}
