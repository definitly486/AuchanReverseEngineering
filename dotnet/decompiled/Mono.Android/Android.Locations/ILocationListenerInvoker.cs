using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Locations;

[Register("android/location/LocationListener", DoNotGenerateAcw = true)]
internal class ILocationListenerInvoker : Java.Lang.Object, ILocationListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_location_LocationListener = new XAPeerMembers("android/location/LocationListener", typeof(ILocationListenerInvoker));

	private static Delegate? cb_onLocationChanged_OnLocationChanged_Landroid_location_Location__V;

	private static Delegate? cb_onProviderDisabled_OnProviderDisabled_Ljava_lang_String__V;

	private static Delegate? cb_onProviderEnabled_OnProviderEnabled_Ljava_lang_String__V;

	private static Delegate? cb_onStatusChanged_OnStatusChanged_Ljava_lang_String_ILandroid_os_Bundle__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_location_LocationListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_location_LocationListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_location_LocationListener.ManagedPeerType;

	public ILocationListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLocationChanged_Landroid_location_Location_(nint jnienv, nint native__this, nint native_location)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ILocationListener? locationListener = Java.Lang.Object.GetObject<ILocationListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Location location = Java.Lang.Object.GetObject<Location>(native_location, JniHandleOwnership.DoNotTransfer);
			locationListener.OnLocationChanged(location);
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

	public unsafe void OnLocationChanged(Location location)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(location?.Handle ?? IntPtr.Zero);
			_members_android_location_LocationListener.InstanceMethods.InvokeAbstractVoidMethod("onLocationChanged.(Landroid/location/Location;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(location);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnProviderDisabled_Ljava_lang_String_(nint jnienv, nint native__this, nint native_provider)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ILocationListener? locationListener = Java.Lang.Object.GetObject<ILocationListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string provider = JNIEnv.GetString(native_provider, JniHandleOwnership.DoNotTransfer);
			locationListener.OnProviderDisabled(provider);
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

	public unsafe void OnProviderDisabled(string provider)
	{
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_android_location_LocationListener.InstanceMethods.InvokeAbstractVoidMethod("onProviderDisabled.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnProviderEnabled_Ljava_lang_String_(nint jnienv, nint native__this, nint native_provider)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ILocationListener? locationListener = Java.Lang.Object.GetObject<ILocationListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string provider = JNIEnv.GetString(native_provider, JniHandleOwnership.DoNotTransfer);
			locationListener.OnProviderEnabled(provider);
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

	public unsafe void OnProviderEnabled(string provider)
	{
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_android_location_LocationListener.InstanceMethods.InvokeAbstractVoidMethod("onProviderEnabled.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[ObsoletedOSPlatform("android29.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStatusChanged_Ljava_lang_String_ILandroid_os_Bundle_(nint jnienv, nint native__this, nint native_provider, int native_status, nint native_extras)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ILocationListener? locationListener = Java.Lang.Object.GetObject<ILocationListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string provider = JNIEnv.GetString(native_provider, JniHandleOwnership.DoNotTransfer);
			Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
			locationListener.OnStatusChanged(provider, (Availability)native_status, extras);
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

	public unsafe void OnStatusChanged(string? provider, Availability status, Bundle? extras)
	{
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue((int)status);
			ptr[2] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			_members_android_location_LocationListener.InstanceMethods.InvokeAbstractVoidMethod("onStatusChanged.(Ljava/lang/String;ILandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(extras);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}

	[UnmanagedCallersOnly]
	private static void n_OnLocationChanged_Landroid_location_Location__mm_wrapper(nint jnienv, nint native__this, nint native_location)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnLocationChanged_Landroid_location_Location_(jnienv, native__this, native_location);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnProviderDisabled_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_provider)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnProviderDisabled_Ljava_lang_String_(jnienv, native__this, native_provider);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnProviderEnabled_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_provider)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnProviderEnabled_Ljava_lang_String_(jnienv, native__this, native_provider);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnStatusChanged_Ljava_lang_String_ILandroid_os_Bundle__mm_wrapper(nint jnienv, nint native__this, nint native_provider, int native_status, nint native_extras)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnStatusChanged_Ljava_lang_String_ILandroid_os_Bundle_(jnienv, native__this, native_provider, native_status, native_extras);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
