using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Runtime.Versioning;

namespace Internal.Runtime.InteropServices;

internal static class ComponentActivator
{
	public delegate int ComponentEntryPoint(nint args, int sizeBytes);

	[UnsupportedOSPlatform("android")]
	[UnsupportedOSPlatform("browser")]
	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("maccatalyst")]
	[UnsupportedOSPlatform("tvos")]
	private static readonly Dictionary<string, IsolatedComponentLoadContext> s_assemblyLoadContexts = new Dictionary<string, IsolatedComponentLoadContext>(StringComparer.InvariantCulture);

	private static readonly Dictionary<nint, Delegate> s_delegates = new Dictionary<nint, Delegate>();

	private static readonly HashSet<string> s_loadedInDefaultContext = new HashSet<string>(StringComparer.InvariantCulture);

	[CompilerGenerated]
	private static readonly bool _003CIsSupported_003Ek__BackingField;

	[FeatureSwitchDefinition("System.Runtime.InteropServices.EnableConsumingManagedCodeFromNativeHosting")]
	private static bool IsSupported
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
	} = InitializeIsSupported();

	private static bool InitializeIsSupported()
	{
		if (!AppContext.TryGetSwitch("System.Runtime.InteropServices.EnableConsumingManagedCodeFromNativeHosting", out var isEnabled))
		{
			return true;
		}
		return isEnabled;
	}

	private static string MarshalToString(nint arg, string argName)
	{
		string? text = Marshal.PtrToStringAuto(arg);
		ArgumentNullException.ThrowIfNull(text, argName);
		return text;
	}

	[RequiresDynamicCode("The native code for the method requested might not be available at runtime.")]
	[RequiresUnreferencedCode("Native hosting is not trim compatible and this warning will be seen if trimming is enabled.", Url = "https://aka.ms/dotnet-illink/nativehost")]
	[UnsupportedOSPlatform("android")]
	[UnsupportedOSPlatform("browser")]
	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("maccatalyst")]
	[UnsupportedOSPlatform("tvos")]
	[UnmanagedCallersOnly]
	public unsafe static int LoadAssemblyAndGetFunctionPointer(nint assemblyPathNative, nint typeNameNative, nint methodNameNative, nint delegateTypeNative, nint reserved, nint functionHandle)
	{
		if (functionHandle != IntPtr.Zero)
		{
			*(IntPtr*)functionHandle = (IntPtr)0;
		}
		_ = 0;
		return -2147450713;
	}

	[RequiresDynamicCode("The native code for the method requested might not be available at runtime.")]
	[UnsupportedOSPlatform("android")]
	[UnsupportedOSPlatform("browser")]
	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("maccatalyst")]
	[UnsupportedOSPlatform("tvos")]
	[UnmanagedCallersOnly]
	public static int LoadAssembly(nint assemblyPathNative, nint loadContext, nint reserved)
	{
		_ = 0;
		return -2147450713;
	}

	[RequiresUnreferencedCode("Native hosting is not trim compatible and this warning will be seen if trimming is enabled.", Url = "https://aka.ms/dotnet-illink/nativehost")]
	[UnsupportedOSPlatform("android")]
	[UnsupportedOSPlatform("browser")]
	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("maccatalyst")]
	[UnsupportedOSPlatform("tvos")]
	private static void LoadAssemblyImpl(string assemblyPath)
	{
		lock (s_loadedInDefaultContext)
		{
			if (!s_loadedInDefaultContext.Contains(assemblyPath))
			{
				AssemblyDependencyResolver resolver = new AssemblyDependencyResolver(assemblyPath);
				AssemblyLoadContext.Default.Resolving += delegate(AssemblyLoadContext context, AssemblyName assemblyName)
				{
					string text = resolver.ResolveAssemblyToPath(assemblyName);
					return (text == null) ? null : context.LoadFromAssemblyPath(text);
				};
				AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);
				s_loadedInDefaultContext.Add(assemblyPath);
			}
		}
	}

	[RequiresDynamicCode("The native code for the method requested might not be available at runtime.")]
	[UnsupportedOSPlatform("android")]
	[UnsupportedOSPlatform("browser")]
	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("maccatalyst")]
	[UnsupportedOSPlatform("tvos")]
	[UnmanagedCallersOnly]
	public unsafe static int LoadAssemblyBytes(byte* assembly, nint assemblyByteLength, byte* symbols, nint symbolsByteLength, nint loadContext, nint reserved)
	{
		_ = 0;
		return -2147450713;
	}

	[RequiresDynamicCode("The native code for the method requested might not be available at runtime.")]
	[UnmanagedCallersOnly]
	public unsafe static int GetFunctionPointer(nint typeNameNative, nint methodNameNative, nint delegateTypeNative, nint loadContext, nint reserved, nint functionHandle)
	{
		if (functionHandle != IntPtr.Zero)
		{
			*(IntPtr*)functionHandle = (IntPtr)0;
		}
		_ = 0;
		return -2147450713;
	}

	[RequiresUnreferencedCode("Native hosting is not trim compatible and this warning will be seen if trimming is enabled.", Url = "https://aka.ms/dotnet-illink/nativehost")]
	[UnsupportedOSPlatform("android")]
	[UnsupportedOSPlatform("browser")]
	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("tvos")]
	private static IsolatedComponentLoadContext GetIsolatedComponentLoadContext(string assemblyPath)
	{
		IsolatedComponentLoadContext value;
		lock (s_assemblyLoadContexts)
		{
			if (!s_assemblyLoadContexts.TryGetValue(assemblyPath, out value))
			{
				value = new IsolatedComponentLoadContext(assemblyPath);
				s_assemblyLoadContexts.Add(assemblyPath, value);
			}
		}
		return value;
	}

	[RequiresDynamicCode("The native code for the method requested might not be available at runtime.")]
	[RequiresUnreferencedCode("Native hosting is not trim compatible and this warning will be seen if trimming is enabled.", Url = "https://aka.ms/dotnet-illink/nativehost")]
	private static nint InternalGetFunctionPointer(AssemblyLoadContext alc, string typeName, string methodName, nint delegateTypeNative)
	{
		Func<AssemblyName, Assembly> assemblyResolver = alc.LoadFromAssemblyName;
		Type type = ((delegateTypeNative == IntPtr.Zero) ? typeof(ComponentEntryPoint) : ((delegateTypeNative != -1) ? Type.GetType(MarshalToString(delegateTypeNative, "delegateTypeNative"), assemblyResolver, null, throwOnError: true) : null));
		Type type2 = Type.GetType(typeName, assemblyResolver, null, throwOnError: true);
		nint num;
		if (type == null)
		{
			MethodInfo methodInfo = type2.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) ?? throw new MissingMethodException(typeName, methodName);
			if (methodInfo.GetCustomAttribute<UnmanagedCallersOnlyAttribute>() == null)
			{
				throw new InvalidOperationException("InvalidOperation_FunctionMissingUnmanagedCallersOnly");
			}
			num = methodInfo.MethodHandle.GetFunctionPointer();
		}
		else
		{
			Delegate obj = Delegate.CreateDelegate(type, type2, methodName);
			num = Marshal.GetFunctionPointerForDelegate(obj);
			lock (s_delegates)
			{
				s_delegates[num] = obj;
			}
		}
		return num;
	}
}
