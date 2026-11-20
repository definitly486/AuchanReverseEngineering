using System;
using System.Collections.Generic;
using System.Diagnostics;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Location;

[Register("androidx/core/location/LocationListenerCompat", "", "AndroidX.Core.Location.ILocationListenerCompatInvoker")]
public interface ILocationListenerCompat : ILocationListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/location/LocationListenerCompat", typeof(ILocationListenerCompat), isInterface: true);

	private static Delegate? cb_onFlushComplete_OnFlushComplete_I_V;

	private static Delegate? cb_onLocationChanged_OnLocationChanged_Ljava_util_List__V;

	private static Delegate? cb_onProviderDisabled_OnProviderDisabled_Ljava_lang_String__V;

	private static Delegate? cb_onProviderEnabled_OnProviderEnabled_Ljava_lang_String__V;

	private static Delegate? cb_onStatusChanged_OnStatusChanged_Ljava_lang_String_ILandroid_os_Bundle__V;

	private static Delegate GetOnFlushComplete_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_OnFlushComplete_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnFlushComplete_I(nint jnienv, nint native__this, int requestCode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ILocationListenerCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnFlushComplete(requestCode);
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

	[Register("onFlushComplete", "(I)V", "GetOnFlushComplete_IHandler:AndroidX.Core.Location.ILocationListenerCompat, Xamarin.AndroidX.Core")]
	unsafe void ILocationListener.OnFlushComplete(int requestCode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(requestCode);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onFlushComplete.(I)V", this, ptr);
	}

	private static Delegate GetOnLocationChanged_Ljava_util_List_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnLocationChanged_Ljava_util_List_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLocationChanged_Ljava_util_List_(nint jnienv, nint native__this, nint native_locations)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ILocationListenerCompat? locationListenerCompat = Java.Lang.Object.GetObject<ILocationListenerCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<Android.Locations.Location> locations = JavaList<Android.Locations.Location>.FromJniHandle(native_locations, JniHandleOwnership.DoNotTransfer);
			locationListenerCompat.OnLocationChanged(locations);
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

	[Register("onLocationChanged", "(Ljava/util/List;)V", "GetOnLocationChanged_Ljava_util_List_Handler:AndroidX.Core.Location.ILocationListenerCompat, Xamarin.AndroidX.Core")]
	unsafe void OnLocationChanged(IList<Android.Locations.Location>? locations)
	{
		nint num = JavaList<Android.Locations.Location>.ToLocalJniHandle(locations);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onLocationChanged.(Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(locations);
		}
	}

	private static Delegate GetOnProviderDisabled_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnProviderDisabled_Ljava_lang_String_);
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
			ILocationListenerCompat? locationListenerCompat = Java.Lang.Object.GetObject<ILocationListenerCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string provider = JNIEnv.GetString(native_provider, JniHandleOwnership.DoNotTransfer);
			locationListenerCompat.OnProviderDisabled(provider);
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

	[Register("onProviderDisabled", "(Ljava/lang/String;)V", "GetOnProviderDisabled_Ljava_lang_String_Handler:AndroidX.Core.Location.ILocationListenerCompat, Xamarin.AndroidX.Core")]
	unsafe void ILocationListener.OnProviderDisabled(string? provider)
	{
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onProviderDisabled.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetOnProviderEnabled_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnProviderEnabled_Ljava_lang_String_);
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
			ILocationListenerCompat? locationListenerCompat = Java.Lang.Object.GetObject<ILocationListenerCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string provider = JNIEnv.GetString(native_provider, JniHandleOwnership.DoNotTransfer);
			locationListenerCompat.OnProviderEnabled(provider);
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

	[Register("onProviderEnabled", "(Ljava/lang/String;)V", "GetOnProviderEnabled_Ljava_lang_String_Handler:AndroidX.Core.Location.ILocationListenerCompat, Xamarin.AndroidX.Core")]
	unsafe void ILocationListener.OnProviderEnabled(string? provider)
	{
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onProviderEnabled.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetOnStatusChanged_Ljava_lang_String_ILandroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPLIL_V(n_OnStatusChanged_Ljava_lang_String_ILandroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStatusChanged_Ljava_lang_String_ILandroid_os_Bundle_(nint jnienv, nint native__this, nint native_provider, int status, nint native_extras)
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
			locationListenerCompat.OnStatusChanged(provider, status, extras);
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

	[Register("onStatusChanged", "(Ljava/lang/String;ILandroid/os/Bundle;)V", "GetOnStatusChanged_Ljava_lang_String_ILandroid_os_Bundle_Handler:AndroidX.Core.Location.ILocationListenerCompat, Xamarin.AndroidX.Core")]
	unsafe void OnStatusChanged(string? provider, int status, Bundle? extras)
	{
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(status);
			ptr[2] = new JniArgumentValue(extras?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStatusChanged.(Ljava/lang/String;ILandroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(extras);
		}
	}
}
