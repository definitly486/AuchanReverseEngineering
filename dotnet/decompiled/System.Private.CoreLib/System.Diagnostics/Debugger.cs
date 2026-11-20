using System.Runtime.CompilerServices;

namespace System.Diagnostics;

public static class Debugger
{
	public static readonly string? DefaultCategory;

	[CompilerGenerated]
	private static readonly bool _003CIsSupported_003Ek__BackingField = InitializeIsSupported();

	public static bool IsAttached => IsAttached_internal();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool IsAttached_internal();

	[Intrinsic]
	public static void Break()
	{
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern bool IsLogging();

	public static bool Launch()
	{
		throw new NotImplementedException();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Log_icall(int level, ref string category, ref string message);

	public static void Log(int level, string? category, string? message)
	{
		if (category == null)
		{
			category = string.Empty;
		}
		if (message == null)
		{
			message = string.Empty;
		}
		Log_icall(level, ref category, ref message);
	}

	public static void NotifyOfCrossThreadDependency()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void BreakForUserUnhandledException(Exception exception)
	{
	}

	private static bool InitializeIsSupported()
	{
		if (!AppContext.TryGetSwitch("System.Diagnostics.Debugger.IsSupported", out var isEnabled))
		{
			return true;
		}
		return isEnabled;
	}
}
