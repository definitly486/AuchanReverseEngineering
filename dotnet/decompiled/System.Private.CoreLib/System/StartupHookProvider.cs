using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace System;

internal static class StartupHookProvider
{
	private struct StartupHookNameOrPath
	{
		public AssemblyName AssemblyName;

		public string Path;
	}

	[FeatureSwitchDefinition("System.StartupHookProvider.IsSupported")]
	private static bool IsSupported => false;

	private static void ProcessStartupHooks(string diagnosticStartupHooks)
	{
		_ = 0;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "An ILLink warning when trimming an app with System.StartupHookProvider.IsSupported=true already exists for ProcessStartupHooks.")]
	private unsafe static void CallStartupHook(char* pStartupHookPart)
	{
		_ = 0;
	}

	private static void ParseStartupHook(ref StartupHookNameOrPath startupHook, string startupHookPart)
	{
		_003C_003Ey__InlineArray4<char> buffer = default(_003C_003Ey__InlineArray4<char>);
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<char>, char>(ref buffer, 0) = Path.DirectorySeparatorChar;
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<char>, char>(ref buffer, 1) = Path.AltDirectorySeparatorChar;
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<char>, char>(ref buffer, 2) = ' ';
		_003CPrivateImplementationDetails_003E.InlineArrayElementRef<_003C_003Ey__InlineArray4<char>, char>(ref buffer, 3) = ',';
		ReadOnlySpan<char> readOnlySpan = _003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<_003C_003Ey__InlineArray4<char>, char>(in buffer, 4);
		if (string.IsNullOrEmpty(startupHookPart))
		{
			return;
		}
		if (Path.IsPathFullyQualified(startupHookPart))
		{
			startupHook.Path = startupHookPart;
			return;
		}
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			if (startupHookPart.Contains(readOnlySpan[i]))
			{
				throw new ArgumentException(SR.Format("Argument_InvalidStartupHookSimpleAssemblyName", startupHookPart));
			}
		}
		if (startupHookPart.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
		{
			throw new ArgumentException(SR.Format("Argument_InvalidStartupHookSimpleAssemblyName", startupHookPart));
		}
		try
		{
			startupHook.AssemblyName = new AssemblyName(startupHookPart);
		}
		catch (Exception innerException)
		{
			throw new ArgumentException(SR.Format("Argument_InvalidStartupHookSimpleAssemblyName", startupHookPart), innerException);
		}
	}

	[RequiresUnreferencedCode("The StartupHookSupport feature switch has been enabled for this app which is being trimmed. Startup hook code is not observable by the trimmer and so required assemblies, types and members may be removed")]
	private static void CallStartupHook(StartupHookNameOrPath startupHook)
	{
		Assembly assembly;
		try
		{
			if (startupHook.Path != null)
			{
				assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(startupHook.Path);
			}
			else
			{
				if (startupHook.AssemblyName == null)
				{
					return;
				}
				assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(startupHook.AssemblyName);
			}
		}
		catch (Exception innerException)
		{
			throw new ArgumentException(SR.Format("Argument_StartupHookAssemblyLoadFailed", startupHook.Path ?? startupHook.AssemblyName.ToString()), innerException);
		}
		Type type = assembly.GetType("StartupHook", throwOnError: true);
		MethodInfo method = type.GetMethod("Initialize", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
		if (method == null)
		{
			try
			{
				if ((object)type.GetMethod("Initialize", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) == null)
				{
					throw new MissingMethodException("StartupHook", "Initialize");
				}
			}
			catch (AmbiguousMatchException)
			{
			}
		}
		if (method == null || method.ReturnType != typeof(void))
		{
			throw new ArgumentException(SR.Format("Argument_InvalidStartupHookSignature", "StartupHook" + Type.Delimiter + "Initialize", startupHook.Path ?? startupHook.AssemblyName.ToString()));
		}
		method.Invoke(null, null);
	}
}
