using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Locations;

[Register("android/location/LocationListener", "", "Android.Locations.ILocationListenerInvoker")]
public interface ILocationListener : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/location/LocationListener", typeof(ILocationListener), isInterface: true);

	private static Delegate? cb_onFlushComplete_OnFlushComplete_I_V;

	void OnLocationChanged(Location location);

	void OnProviderDisabled(string provider);

	void OnProviderEnabled(string provider);

	[ObsoletedOSPlatform("android29.0")]
	void OnStatusChanged(string? provider, Availability status, Bundle? extras);

	[SupportedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnFlushComplete_I(nint jnienv, nint native__this, int requestCode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ILocationListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnFlushComplete(requestCode);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android31.0")]
	unsafe void OnFlushComplete(int requestCode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(requestCode);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onFlushComplete.(I)V", this, ptr);
	}

	[UnmanagedCallersOnly]
	private static void n_OnFlushComplete_I_mm_wrapper(nint jnienv, nint native__this, int requestCode)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnFlushComplete_I(jnienv, native__this, requestCode);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
