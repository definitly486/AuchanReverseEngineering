using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using NLog.Common;

namespace NLog.Internal;

internal static class AssemblyHelpers
{
	[UnconditionalSuppressMessage("Returns empty string for assemblies embedded in a single-file app", "IL3000")]
	public static string GetAssemblyFileLocation(Assembly assembly)
	{
		return assembly?.Location ?? string.Empty;
	}

	public static void LogAssemblyVersion(Assembly assembly)
	{
		try
		{
			if (InternalLogger.IsInfoEnabled)
			{
				string text = assembly.GetFirstCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
				string text2 = assembly.GetFirstCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
				bool flag = false;
				InternalLogger.Info("{0}. File version: {1}. Product version: {2}. GlobalAssemblyCache: {3}", new ReadOnlySpan<object>(new object[4] { assembly.FullName, text, text2, flag }));
			}
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "Error logging version of assembly {0}.", new ReadOnlySpan<object>(new object[1] { assembly?.FullName }));
		}
	}
}
