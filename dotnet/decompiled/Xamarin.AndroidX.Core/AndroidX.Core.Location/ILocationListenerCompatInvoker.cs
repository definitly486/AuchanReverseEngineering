using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Location;

[Register("androidx/core/location/LocationListenerCompat", DoNotGenerateAcw = true)]
internal class ILocationListenerCompatInvoker : Java.Lang.Object, ILocationListenerCompat, ILocationListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_location_LocationListener = new XAPeerMembers("android/location/LocationListener", typeof(ILocationListenerCompatInvoker));

	private static readonly JniPeerMembers _members_Android_Runtime_IJavaObject = new XAPeerMembers("Android/Runtime/IJavaObject", typeof(ILocationListenerCompatInvoker));

	private static readonly JniPeerMembers _members_androidx_core_location_LocationListenerCompat = new XAPeerMembers("androidx/core/location/LocationListenerCompat", typeof(ILocationListenerCompatInvoker));

	private static readonly JniPeerMembers _members_Java_Interop_IJavaPeerable = new XAPeerMembers("Java/Interop/IJavaPeerable", typeof(ILocationListenerCompatInvoker));

	private static readonly JniPeerMembers _members_System_IDisposable = new XAPeerMembers("System/IDisposable", typeof(ILocationListenerCompatInvoker));

	private static Delegate? cb_onLocationChanged_OnLocationChanged_Landroid_location_Location__V;

	private static Delegate? cb_onStatusChanged_OnStatusChanged_Ljava_lang_String_ILandroid_os_Bundle__V;

	private static nint java_class_ref => _members_androidx_core_location_LocationListenerCompat.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_core_location_LocationListenerCompat;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_core_location_LocationListenerCompat.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_core_location_LocationListenerCompat.ManagedPeerType;

	public ILocationListenerCompatInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnLocationChanged_Landroid_location_Location_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnLocationChanged_Landroid_location_Location_);
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
			ILocationListenerCompat? locationListenerCompat = Java.Lang.Object.GetObject<ILocationListenerCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Locations.Location location = Java.Lang.Object.GetObject<Android.Locations.Location>(native_location, JniHandleOwnership.DoNotTransfer);
			locationListenerCompat.OnLocationChanged(location);
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

	public unsafe void OnLocationChanged(Android.Locations.Location location)
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

	private static Delegate GetOnStatusChanged_Ljava_lang_String_ILandroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPLIL_V(n_OnStatusChanged_Ljava_lang_String_ILandroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStatusChanged_Ljava_lang_String_ILandroid_os_Bundle_(nint jnienv, nint native__this, nint native_provider, int native_status, nint native_extras)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ILocationListenerCompat? locationListenerCompat = Java.Lang.Object.GetObject<ILocationListenerCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string provider = JNIEnv.GetString(native_provider, JniHandleOwnership.DoNotTransfer);
			Bundle extras = Java.Lang.Object.GetObject<Bundle>(native_extras, JniHandleOwnership.DoNotTransfer);
			locationListenerCompat.OnStatusChanged(provider, (Availability)native_status, extras);
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
}
