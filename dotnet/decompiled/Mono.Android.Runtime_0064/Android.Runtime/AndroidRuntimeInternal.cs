using System;
using Java.Interop;

namespace Android.Runtime;

public static class AndroidRuntimeInternal
{
	internal static readonly Action<Exception> mono_unhandled_exception;

	internal static volatile bool BridgeProcessing;

	static AndroidRuntimeInternal()
	{
		_ = 1;
		mono_unhandled_exception = MonoUnhandledException;
	}

	private static void CoreClrUnhandledException(Exception ex)
	{
	}

	private static void MonoUnhandledException(Exception ex)
	{
		RuntimeNativeMethods.monodroid_debugger_unhandled_exception(ex);
	}

	public static void WaitForBridgeProcessing()
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
	}
}
