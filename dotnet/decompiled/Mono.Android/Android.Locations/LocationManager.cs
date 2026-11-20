using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Locations;

[Register("android/location/LocationManager", DoNotGenerateAcw = true)]
public class LocationManager : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/location/LocationManager", typeof(LocationManager));

	private static Delegate? cb_getBestProvider_GetBestProvider_Landroid_location_Criteria_Z_Ljava_lang_String_;

	private static Delegate? cb_getLastKnownLocation_GetLastKnownLocation_Ljava_lang_String__Landroid_location_Location_;

	private static Delegate? cb_getProviders_GetProviders_Z_Ljava_util_List_;

	private static Delegate? cb_removeUpdates_RemoveUpdates_Landroid_location_LocationListener__V;

	private static Delegate? cb_requestLocationUpdates_RequestLocationUpdates_Ljava_lang_String_JFLandroid_location_LocationListener_Landroid_os_Looper__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public static LocationManager? FromContext(Context context)
	{
		return context.GetSystemService("location") as LocationManager;
	}

	protected LocationManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android34.0")]
	private static Delegate GetGetBestProvider_Landroid_location_Criteria_ZHandler()
	{
		return new _JniMarshal_PPLB_L(n_GetBestProvider_Landroid_location_Criteria_Z);
	}

	[ObsoletedOSPlatform("android34.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBestProvider_Landroid_location_Criteria_Z(nint jnienv, nint native__this, nint native_criteria, sbyte native_enabledOnly)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LocationManager? locationManager = Java.Lang.Object.GetObject<LocationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Criteria criteria = Java.Lang.Object.GetObject<Criteria>(native_criteria, JniHandleOwnership.DoNotTransfer);
			bool enabledOnly = native_enabledOnly != 0;
			return JNIEnv.NewString(locationManager.GetBestProvider(criteria, enabledOnly));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[ObsoletedOSPlatform("android34.0")]
	[Register("getBestProvider", "(Landroid/location/Criteria;Z)Ljava/lang/String;", "GetGetBestProvider_Landroid_location_Criteria_ZHandler")]
	public unsafe virtual string? GetBestProvider(Criteria criteria, bool enabledOnly)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(criteria?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(enabledOnly ? ((sbyte)1) : ((sbyte)0));
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getBestProvider.(Landroid/location/Criteria;Z)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(criteria);
		}
	}

	private static Delegate GetGetLastKnownLocation_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPL_L(n_GetLastKnownLocation_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLastKnownLocation_Ljava_lang_String_(nint jnienv, nint native__this, nint native_provider)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LocationManager? locationManager = Java.Lang.Object.GetObject<LocationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string provider = JNIEnv.GetString(native_provider, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(locationManager.GetLastKnownLocation(provider));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getLastKnownLocation", "(Ljava/lang/String;)Landroid/location/Location;", "GetGetLastKnownLocation_Ljava_lang_String_Handler")]
	public unsafe virtual Location? GetLastKnownLocation(string provider)
	{
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Location>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLastKnownLocation.(Ljava/lang/String;)Landroid/location/Location;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetGetProviders_ZHandler()
	{
		return new _JniMarshal_PPB_L(n_GetProviders_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetProviders_Z(nint jnienv, nint native__this, sbyte native_enabledOnly)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			LocationManager? locationManager = Java.Lang.Object.GetObject<LocationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool enabledOnly = native_enabledOnly != 0;
			return JavaList<string>.ToLocalJniHandle(locationManager.GetProviders(enabledOnly));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getProviders", "(Z)Ljava/util/List;", "GetGetProviders_ZHandler")]
	public unsafe virtual IList<string> GetProviders(bool enabledOnly)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabledOnly ? ((sbyte)1) : ((sbyte)0));
		return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getProviders.(Z)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemoveUpdates_Landroid_location_LocationListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_RemoveUpdates_Landroid_location_LocationListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveUpdates_Landroid_location_LocationListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LocationManager? locationManager = Java.Lang.Object.GetObject<LocationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILocationListener listener = Java.Lang.Object.GetObject<ILocationListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			locationManager.RemoveUpdates(listener);
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

	[Register("removeUpdates", "(Landroid/location/LocationListener;)V", "GetRemoveUpdates_Landroid_location_LocationListener_Handler")]
	public unsafe virtual void RemoveUpdates(ILocationListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeUpdates.(Landroid/location/LocationListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRequestLocationUpdates_Ljava_lang_String_JFLandroid_location_LocationListener_Landroid_os_Looper_Handler()
	{
		return new _JniMarshal_PPLJFLL_V(n_RequestLocationUpdates_Ljava_lang_String_JFLandroid_location_LocationListener_Landroid_os_Looper_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RequestLocationUpdates_Ljava_lang_String_JFLandroid_location_LocationListener_Landroid_os_Looper_(nint jnienv, nint native__this, nint native_provider, long minTimeMs, float minDistanceM, nint native_listener, nint native_looper)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LocationManager? locationManager = Java.Lang.Object.GetObject<LocationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string provider = JNIEnv.GetString(native_provider, JniHandleOwnership.DoNotTransfer);
			ILocationListener listener = Java.Lang.Object.GetObject<ILocationListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			Looper looper = Java.Lang.Object.GetObject<Looper>(native_looper, JniHandleOwnership.DoNotTransfer);
			locationManager.RequestLocationUpdates(provider, minTimeMs, minDistanceM, listener, looper);
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

	[Register("requestLocationUpdates", "(Ljava/lang/String;JFLandroid/location/LocationListener;Landroid/os/Looper;)V", "GetRequestLocationUpdates_Ljava_lang_String_JFLandroid_location_LocationListener_Landroid_os_Looper_Handler")]
	public unsafe virtual void RequestLocationUpdates(string provider, long minTimeMs, float minDistanceM, ILocationListener listener, Looper? looper)
	{
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(minTimeMs);
			ptr[2] = new JniArgumentValue(minDistanceM);
			ptr[3] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			ptr[4] = new JniArgumentValue(looper?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("requestLocationUpdates.(Ljava/lang/String;JFLandroid/location/LocationListener;Landroid/os/Looper;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(listener);
			GC.KeepAlive(looper);
		}
	}
}
