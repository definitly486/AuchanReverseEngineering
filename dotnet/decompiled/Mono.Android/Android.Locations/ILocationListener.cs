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

	[Register("onLocationChanged", "(Landroid/location/Location;)V", "GetOnLocationChanged_Landroid_location_Location_Handler:Android.Locations.ILocationListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnLocationChanged(Location location);

	[Register("onProviderDisabled", "(Ljava/lang/String;)V", "GetOnProviderDisabled_Ljava_lang_String_Handler:Android.Locations.ILocationListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnProviderDisabled(string provider);

	[Register("onProviderEnabled", "(Ljava/lang/String;)V", "GetOnProviderEnabled_Ljava_lang_String_Handler:Android.Locations.ILocationListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnProviderEnabled(string provider);

	[ObsoletedOSPlatform("android29.0")]
	[Register("onStatusChanged", "(Ljava/lang/String;ILandroid/os/Bundle;)V", "GetOnStatusChanged_Ljava_lang_String_ILandroid_os_Bundle_Handler:Android.Locations.ILocationListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
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
	[Register("onFlushComplete", "(I)V", "GetOnFlushComplete_IHandler:Android.Locations.ILocationListener, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 31)]
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
