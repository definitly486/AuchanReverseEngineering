using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using AndroidX.Core.OS;
using AndroidX.Core.Util;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Core.Location;

[Register("androidx/core/location/LocationManagerCompat", DoNotGenerateAcw = true)]
public sealed class LocationManagerCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/location/LocationManagerCompat", typeof(LocationManagerCompat));

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	internal LocationManagerCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("getCurrentLocation", "(Landroid/location/LocationManager;Ljava/lang/String;Landroid/os/CancellationSignal;Ljava/util/concurrent/Executor;Landroidx/core/util/Consumer;)V", "")]
	public unsafe static void GetCurrentLocation(LocationManager? locationManager, string? provider, Android.OS.CancellationSignal? cancellationSignal, IExecutor? executor, IConsumer? consumer)
	{
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(cancellationSignal?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[4] = new JniArgumentValue((consumer == null) ? IntPtr.Zero : ((Java.Lang.Object)consumer).Handle);
			_members.StaticMethods.InvokeVoidMethod("getCurrentLocation.(Landroid/location/LocationManager;Ljava/lang/String;Landroid/os/CancellationSignal;Ljava/util/concurrent/Executor;Landroidx/core/util/Consumer;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(locationManager);
			GC.KeepAlive(cancellationSignal);
			GC.KeepAlive(executor);
			GC.KeepAlive(consumer);
		}
	}

	[Obsolete("deprecated")]
	[Register("getCurrentLocation", "(Landroid/location/LocationManager;Ljava/lang/String;Landroidx/core/os/CancellationSignal;Ljava/util/concurrent/Executor;Landroidx/core/util/Consumer;)V", "")]
	public unsafe static void GetCurrentLocation(LocationManager? locationManager, string? provider, AndroidX.Core.OS.CancellationSignal? cancellationSignal, IExecutor? executor, IConsumer? consumer)
	{
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(cancellationSignal?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[4] = new JniArgumentValue((consumer == null) ? IntPtr.Zero : ((Java.Lang.Object)consumer).Handle);
			_members.StaticMethods.InvokeVoidMethod("getCurrentLocation.(Landroid/location/LocationManager;Ljava/lang/String;Landroidx/core/os/CancellationSignal;Ljava/util/concurrent/Executor;Landroidx/core/util/Consumer;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(locationManager);
			GC.KeepAlive(cancellationSignal);
			GC.KeepAlive(executor);
			GC.KeepAlive(consumer);
		}
	}

	[Register("getGnssHardwareModelName", "(Landroid/location/LocationManager;)Ljava/lang/String;", "")]
	public unsafe static string? GetGnssHardwareModelName(LocationManager? locationManager)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getGnssHardwareModelName.(Landroid/location/LocationManager;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(locationManager);
		}
	}

	[Register("getGnssYearOfHardware", "(Landroid/location/LocationManager;)I", "")]
	public unsafe static int GetGnssYearOfHardware(LocationManager? locationManager)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeInt32Method("getGnssYearOfHardware.(Landroid/location/LocationManager;)I", ptr);
		}
		finally
		{
			GC.KeepAlive(locationManager);
		}
	}

	[Register("hasProvider", "(Landroid/location/LocationManager;Ljava/lang/String;)Z", "")]
	public unsafe static bool HasProvider(LocationManager? locationManager, string? provider)
	{
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return _members.StaticMethods.InvokeBooleanMethod("hasProvider.(Landroid/location/LocationManager;Ljava/lang/String;)Z", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(locationManager);
		}
	}

	[Register("isLocationEnabled", "(Landroid/location/LocationManager;)Z", "")]
	public unsafe static bool IsLocationEnabled(LocationManager? locationManager)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("isLocationEnabled.(Landroid/location/LocationManager;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(locationManager);
		}
	}

	[Register("registerGnssMeasurementsCallback", "(Landroid/location/LocationManager;Landroid/location/GnssMeasurementsEvent$Callback;Landroid/os/Handler;)Z", "")]
	public unsafe static bool RegisterGnssMeasurementsCallback(LocationManager? locationManager, GnssMeasurementsEvent.Callback? callback, Handler? handler)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(handler?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("registerGnssMeasurementsCallback.(Landroid/location/LocationManager;Landroid/location/GnssMeasurementsEvent$Callback;Landroid/os/Handler;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(locationManager);
			GC.KeepAlive(callback);
			GC.KeepAlive(handler);
		}
	}

	[Register("registerGnssMeasurementsCallback", "(Landroid/location/LocationManager;Ljava/util/concurrent/Executor;Landroid/location/GnssMeasurementsEvent$Callback;)Z", "")]
	public unsafe static bool RegisterGnssMeasurementsCallback(LocationManager? locationManager, IExecutor? executor, GnssMeasurementsEvent.Callback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[2] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("registerGnssMeasurementsCallback.(Landroid/location/LocationManager;Ljava/util/concurrent/Executor;Landroid/location/GnssMeasurementsEvent$Callback;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(locationManager);
			GC.KeepAlive(executor);
			GC.KeepAlive(callback);
		}
	}

	[Register("registerGnssStatusCallback", "(Landroid/location/LocationManager;Landroidx/core/location/GnssStatusCompat$Callback;Landroid/os/Handler;)Z", "")]
	public unsafe static bool RegisterGnssStatusCallback(LocationManager? locationManager, GnssStatusCompat.Callback? callback, Handler? handler)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(handler?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("registerGnssStatusCallback.(Landroid/location/LocationManager;Landroidx/core/location/GnssStatusCompat$Callback;Landroid/os/Handler;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(locationManager);
			GC.KeepAlive(callback);
			GC.KeepAlive(handler);
		}
	}

	[Register("registerGnssStatusCallback", "(Landroid/location/LocationManager;Ljava/util/concurrent/Executor;Landroidx/core/location/GnssStatusCompat$Callback;)Z", "")]
	public unsafe static bool RegisterGnssStatusCallback(LocationManager? locationManager, IExecutor? executor, GnssStatusCompat.Callback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[2] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			return _members.StaticMethods.InvokeBooleanMethod("registerGnssStatusCallback.(Landroid/location/LocationManager;Ljava/util/concurrent/Executor;Landroidx/core/location/GnssStatusCompat$Callback;)Z", ptr);
		}
		finally
		{
			GC.KeepAlive(locationManager);
			GC.KeepAlive(executor);
			GC.KeepAlive(callback);
		}
	}

	[Register("removeUpdates", "(Landroid/location/LocationManager;Landroidx/core/location/LocationListenerCompat;)V", "")]
	public unsafe static void RemoveUpdates(LocationManager? locationManager, ILocationListenerCompat? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.StaticMethods.InvokeVoidMethod("removeUpdates.(Landroid/location/LocationManager;Landroidx/core/location/LocationListenerCompat;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(locationManager);
			GC.KeepAlive(listener);
		}
	}

	[Register("requestLocationUpdates", "(Landroid/location/LocationManager;Ljava/lang/String;Landroidx/core/location/LocationRequestCompat;Landroidx/core/location/LocationListenerCompat;Landroid/os/Looper;)V", "")]
	public unsafe static void RequestLocationUpdates(LocationManager? locationManager, string? provider, LocationRequestCompat? locationRequest, ILocationListenerCompat? listener, Looper? looper)
	{
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(locationRequest?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			ptr[4] = new JniArgumentValue(looper?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("requestLocationUpdates.(Landroid/location/LocationManager;Ljava/lang/String;Landroidx/core/location/LocationRequestCompat;Landroidx/core/location/LocationListenerCompat;Landroid/os/Looper;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(locationManager);
			GC.KeepAlive(locationRequest);
			GC.KeepAlive(listener);
			GC.KeepAlive(looper);
		}
	}

	[Register("requestLocationUpdates", "(Landroid/location/LocationManager;Ljava/lang/String;Landroidx/core/location/LocationRequestCompat;Ljava/util/concurrent/Executor;Landroidx/core/location/LocationListenerCompat;)V", "")]
	public unsafe static void RequestLocationUpdates(LocationManager? locationManager, string? provider, LocationRequestCompat? locationRequest, IExecutor? executor, ILocationListenerCompat? listener)
	{
		nint num = JNIEnv.NewString(provider);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(locationRequest?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[4] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.StaticMethods.InvokeVoidMethod("requestLocationUpdates.(Landroid/location/LocationManager;Ljava/lang/String;Landroidx/core/location/LocationRequestCompat;Ljava/util/concurrent/Executor;Landroidx/core/location/LocationListenerCompat;)V", ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(locationManager);
			GC.KeepAlive(locationRequest);
			GC.KeepAlive(executor);
			GC.KeepAlive(listener);
		}
	}

	[Register("unregisterGnssMeasurementsCallback", "(Landroid/location/LocationManager;Landroid/location/GnssMeasurementsEvent$Callback;)V", "")]
	public unsafe static void UnregisterGnssMeasurementsCallback(LocationManager? locationManager, GnssMeasurementsEvent.Callback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("unregisterGnssMeasurementsCallback.(Landroid/location/LocationManager;Landroid/location/GnssMeasurementsEvent$Callback;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(locationManager);
			GC.KeepAlive(callback);
		}
	}

	[Register("unregisterGnssStatusCallback", "(Landroid/location/LocationManager;Landroidx/core/location/GnssStatusCompat$Callback;)V", "")]
	public unsafe static void UnregisterGnssStatusCallback(LocationManager? locationManager, GnssStatusCompat.Callback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(locationManager?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(callback?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("unregisterGnssStatusCallback.(Landroid/location/LocationManager;Landroidx/core/location/GnssStatusCompat$Callback;)V", ptr);
		}
		finally
		{
			GC.KeepAlive(locationManager);
			GC.KeepAlive(callback);
		}
	}
}
