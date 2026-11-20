using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/CameraPosition", DoNotGenerateAcw = true)]
public class CameraPosition : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/CameraPosition", typeof(CameraPosition));

	private static Delegate? cb_getAzimuth_GetAzimuth_F;

	private static Delegate? cb_getTarget_GetTarget_Lcom_yandex_mapkit_geometry_Point_;

	private static Delegate? cb_getTilt_GetTilt_F;

	private static Delegate? cb_getZoom_GetZoom_F;

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

	public unsafe virtual float Azimuth
	{
		[Register("getAzimuth", "()F", "GetGetAzimuthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getAzimuth.()F", this, null);
		}
	}

	public unsafe virtual Point Target
	{
		[Register("getTarget", "()Lcom/yandex/mapkit/geometry/Point;", "GetGetTargetHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Point>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTarget.()Lcom/yandex/mapkit/geometry/Point;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual float Tilt
	{
		[Register("getTilt", "()F", "GetGetTiltHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getTilt.()F", this, null);
		}
	}

	public unsafe virtual float Zoom
	{
		[Register("getZoom", "()F", "GetGetZoomHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getZoom.()F", this, null);
		}
	}

	protected CameraPosition(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe CameraPosition()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/geometry/Point;FFF)V", "")]
	public unsafe CameraPosition(Point target, float zoom, float azimuth, float tilt)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(zoom);
			ptr[2] = new JniArgumentValue(azimuth);
			ptr[3] = new JniArgumentValue(tilt);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/geometry/Point;FFF)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/geometry/Point;FFF)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
		}
	}

	private static Delegate GetGetAzimuthHandler()
	{
		if ((object)cb_getAzimuth_GetAzimuth_F == null)
		{
			cb_getAzimuth_GetAzimuth_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetAzimuth));
		}
		return cb_getAzimuth_GetAzimuth_F;
	}

	private static float n_GetAzimuth(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Azimuth;
	}

	private static Delegate GetGetTargetHandler()
	{
		if ((object)cb_getTarget_GetTarget_Lcom_yandex_mapkit_geometry_Point_ == null)
		{
			cb_getTarget_GetTarget_Lcom_yandex_mapkit_geometry_Point_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTarget));
		}
		return cb_getTarget_GetTarget_Lcom_yandex_mapkit_geometry_Point_;
	}

	private static nint n_GetTarget(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CameraPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Target);
	}

	private static Delegate GetGetTiltHandler()
	{
		if ((object)cb_getTilt_GetTilt_F == null)
		{
			cb_getTilt_GetTilt_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetTilt));
		}
		return cb_getTilt_GetTilt_F;
	}

	private static float n_GetTilt(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Tilt;
	}

	private static Delegate GetGetZoomHandler()
	{
		if ((object)cb_getZoom_GetZoom_F == null)
		{
			cb_getZoom_GetZoom_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetZoom));
		}
		return cb_getZoom_GetZoom_F;
	}

	private static float n_GetZoom(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<CameraPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Zoom;
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
		CameraPosition? cameraPosition = Java.Lang.Object.GetObject<CameraPosition>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		cameraPosition.Serialize(archive);
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
