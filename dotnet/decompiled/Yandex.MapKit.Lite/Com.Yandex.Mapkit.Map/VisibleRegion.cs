using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/VisibleRegion", DoNotGenerateAcw = true)]
public class VisibleRegion : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/VisibleRegion", typeof(VisibleRegion));

	private static Delegate? cb_getBottomLeft_GetBottomLeft_Lcom_yandex_mapkit_geometry_Point_;

	private static Delegate? cb_getBottomRight_GetBottomRight_Lcom_yandex_mapkit_geometry_Point_;

	private static Delegate? cb_getTopLeft_GetTopLeft_Lcom_yandex_mapkit_geometry_Point_;

	private static Delegate? cb_getTopRight_GetTopRight_Lcom_yandex_mapkit_geometry_Point_;

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

	public unsafe virtual Point BottomLeft
	{
		[Register("getBottomLeft", "()Lcom/yandex/mapkit/geometry/Point;", "GetGetBottomLeftHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Point>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBottomLeft.()Lcom/yandex/mapkit/geometry/Point;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Point BottomRight
	{
		[Register("getBottomRight", "()Lcom/yandex/mapkit/geometry/Point;", "GetGetBottomRightHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Point>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBottomRight.()Lcom/yandex/mapkit/geometry/Point;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Point TopLeft
	{
		[Register("getTopLeft", "()Lcom/yandex/mapkit/geometry/Point;", "GetGetTopLeftHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Point>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTopLeft.()Lcom/yandex/mapkit/geometry/Point;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Point TopRight
	{
		[Register("getTopRight", "()Lcom/yandex/mapkit/geometry/Point;", "GetGetTopRightHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Point>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTopRight.()Lcom/yandex/mapkit/geometry/Point;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected VisibleRegion(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe VisibleRegion()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/geometry/Point;)V", "")]
	public unsafe VisibleRegion(Point topLeft, Point topRight, Point bottomLeft, Point bottomRight)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(topLeft?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(topRight?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(bottomLeft?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(bottomRight?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/geometry/Point;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/geometry/Point;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(topLeft);
			GC.KeepAlive(topRight);
			GC.KeepAlive(bottomLeft);
			GC.KeepAlive(bottomRight);
		}
	}

	private static Delegate GetGetBottomLeftHandler()
	{
		if ((object)cb_getBottomLeft_GetBottomLeft_Lcom_yandex_mapkit_geometry_Point_ == null)
		{
			cb_getBottomLeft_GetBottomLeft_Lcom_yandex_mapkit_geometry_Point_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBottomLeft));
		}
		return cb_getBottomLeft_GetBottomLeft_Lcom_yandex_mapkit_geometry_Point_;
	}

	private static nint n_GetBottomLeft(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<VisibleRegion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BottomLeft);
	}

	private static Delegate GetGetBottomRightHandler()
	{
		if ((object)cb_getBottomRight_GetBottomRight_Lcom_yandex_mapkit_geometry_Point_ == null)
		{
			cb_getBottomRight_GetBottomRight_Lcom_yandex_mapkit_geometry_Point_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBottomRight));
		}
		return cb_getBottomRight_GetBottomRight_Lcom_yandex_mapkit_geometry_Point_;
	}

	private static nint n_GetBottomRight(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<VisibleRegion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BottomRight);
	}

	private static Delegate GetGetTopLeftHandler()
	{
		if ((object)cb_getTopLeft_GetTopLeft_Lcom_yandex_mapkit_geometry_Point_ == null)
		{
			cb_getTopLeft_GetTopLeft_Lcom_yandex_mapkit_geometry_Point_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTopLeft));
		}
		return cb_getTopLeft_GetTopLeft_Lcom_yandex_mapkit_geometry_Point_;
	}

	private static nint n_GetTopLeft(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<VisibleRegion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TopLeft);
	}

	private static Delegate GetGetTopRightHandler()
	{
		if ((object)cb_getTopRight_GetTopRight_Lcom_yandex_mapkit_geometry_Point_ == null)
		{
			cb_getTopRight_GetTopRight_Lcom_yandex_mapkit_geometry_Point_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTopRight));
		}
		return cb_getTopRight_GetTopRight_Lcom_yandex_mapkit_geometry_Point_;
	}

	private static nint n_GetTopRight(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<VisibleRegion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TopRight);
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
		VisibleRegion? visibleRegion = Java.Lang.Object.GetObject<VisibleRegion>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		visibleRegion.Serialize(archive);
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
