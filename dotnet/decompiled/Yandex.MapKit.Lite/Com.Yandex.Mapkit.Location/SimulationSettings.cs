using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/SimulationSettings", DoNotGenerateAcw = true)]
public class SimulationSettings : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/location/SimulationSettings", typeof(SimulationSettings));

	private static Delegate? cb_getGeometry_GetGeometry_Lcom_yandex_mapkit_geometry_Polyline_;

	private static Delegate? cb_getLocationSettings_GetLocationSettings_Lcom_yandex_mapkit_location_LocationSettings_;

	private static Delegate? cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V;

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

	public unsafe virtual Polyline Geometry
	{
		[Register("getGeometry", "()Lcom/yandex/mapkit/geometry/Polyline;", "GetGetGeometryHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Polyline>(_members.InstanceMethods.InvokeVirtualObjectMethod("getGeometry.()Lcom/yandex/mapkit/geometry/Polyline;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual LocationSettings LocationSettings
	{
		[Register("getLocationSettings", "()Lcom/yandex/mapkit/location/LocationSettings;", "GetGetLocationSettingsHandler")]
		get
		{
			return Java.Lang.Object.GetObject<LocationSettings>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLocationSettings.()Lcom/yandex/mapkit/location/LocationSettings;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe static string? NativeName
	{
		[Register("getNativeName", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getNativeName.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected SimulationSettings(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe SimulationSettings()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/geometry/Polyline;Lcom/yandex/mapkit/location/LocationSettings;)V", "")]
	public unsafe SimulationSettings(Polyline geometry, LocationSettings locationSettings)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(geometry?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(locationSettings?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/geometry/Polyline;Lcom/yandex/mapkit/location/LocationSettings;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/geometry/Polyline;Lcom/yandex/mapkit/location/LocationSettings;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(geometry);
			GC.KeepAlive(locationSettings);
		}
	}

	private static Delegate GetGetGeometryHandler()
	{
		if ((object)cb_getGeometry_GetGeometry_Lcom_yandex_mapkit_geometry_Polyline_ == null)
		{
			cb_getGeometry_GetGeometry_Lcom_yandex_mapkit_geometry_Polyline_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetGeometry));
		}
		return cb_getGeometry_GetGeometry_Lcom_yandex_mapkit_geometry_Polyline_;
	}

	private static nint n_GetGeometry(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SimulationSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Geometry);
	}

	private static Delegate GetGetLocationSettingsHandler()
	{
		if ((object)cb_getLocationSettings_GetLocationSettings_Lcom_yandex_mapkit_location_LocationSettings_ == null)
		{
			cb_getLocationSettings_GetLocationSettings_Lcom_yandex_mapkit_location_LocationSettings_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLocationSettings));
		}
		return cb_getLocationSettings_GetLocationSettings_Lcom_yandex_mapkit_location_LocationSettings_;
	}

	private static nint n_GetLocationSettings(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SimulationSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LocationSettings);
	}

	private static Delegate GetSerialize_Lcom_yandex_runtime_bindings_Archive_Handler()
	{
		if ((object)cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V == null)
		{
			cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Serialize_Lcom_yandex_runtime_bindings_Archive_));
		}
		return cb_serialize_Serialize_Lcom_yandex_runtime_bindings_Archive__V;
	}

	private static void n_Serialize_Lcom_yandex_runtime_bindings_Archive_(nint jnienv, nint native__this, nint native_archive)
	{
		SimulationSettings? simulationSettings = Java.Lang.Object.GetObject<SimulationSettings>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		simulationSettings.Serialize(archive);
	}

	[Register("serialize", "(Lcom/yandex/runtime/bindings/Archive;)V", "GetSerialize_Lcom_yandex_runtime_bindings_Archive_Handler")]
	public unsafe virtual void Serialize(IArchive? archive)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((archive == null) ? IntPtr.Zero : ((Java.Lang.Object)archive).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("serialize.(Lcom/yandex/runtime/bindings/Archive;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(archive);
		}
	}
}
