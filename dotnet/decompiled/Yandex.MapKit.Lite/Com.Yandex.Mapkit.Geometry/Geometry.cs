using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Geometry;

[Register("com/yandex/mapkit/geometry/Geometry", DoNotGenerateAcw = true)]
public class Geometry : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/geometry/Geometry", typeof(Geometry));

	private static Delegate? cb_getBoundingBox_GetBoundingBox_Lcom_yandex_mapkit_geometry_BoundingBox_;

	private static Delegate? cb_getCircle_GetCircle_Lcom_yandex_mapkit_geometry_Circle_;

	private static Delegate? cb_getMultiPolygon_GetMultiPolygon_Lcom_yandex_mapkit_geometry_MultiPolygon_;

	private static Delegate? cb_getPoint_GetPoint_Lcom_yandex_mapkit_geometry_Point_;

	private static Delegate? cb_getPolygon_GetPolygon_Lcom_yandex_mapkit_geometry_Polygon_;

	private static Delegate? cb_getPolyline_GetPolyline_Lcom_yandex_mapkit_geometry_Polyline_;

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

	public unsafe virtual BoundingBox? BoundingBox
	{
		[Register("getBoundingBox", "()Lcom/yandex/mapkit/geometry/BoundingBox;", "GetGetBoundingBoxHandler")]
		get
		{
			return Java.Lang.Object.GetObject<BoundingBox>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBoundingBox.()Lcom/yandex/mapkit/geometry/BoundingBox;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Circle? Circle
	{
		[Register("getCircle", "()Lcom/yandex/mapkit/geometry/Circle;", "GetGetCircleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Circle>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCircle.()Lcom/yandex/mapkit/geometry/Circle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual MultiPolygon? MultiPolygon
	{
		[Register("getMultiPolygon", "()Lcom/yandex/mapkit/geometry/MultiPolygon;", "GetGetMultiPolygonHandler")]
		get
		{
			return Java.Lang.Object.GetObject<MultiPolygon>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMultiPolygon.()Lcom/yandex/mapkit/geometry/MultiPolygon;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Point? Point
	{
		[Register("getPoint", "()Lcom/yandex/mapkit/geometry/Point;", "GetGetPointHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Point>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPoint.()Lcom/yandex/mapkit/geometry/Point;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Polygon? Polygon
	{
		[Register("getPolygon", "()Lcom/yandex/mapkit/geometry/Polygon;", "GetGetPolygonHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Polygon>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPolygon.()Lcom/yandex/mapkit/geometry/Polygon;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Polyline? Polyline
	{
		[Register("getPolyline", "()Lcom/yandex/mapkit/geometry/Polyline;", "GetGetPolylineHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Polyline>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPolyline.()Lcom/yandex/mapkit/geometry/Polyline;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Geometry(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Geometry()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetBoundingBoxHandler()
	{
		if ((object)cb_getBoundingBox_GetBoundingBox_Lcom_yandex_mapkit_geometry_BoundingBox_ == null)
		{
			cb_getBoundingBox_GetBoundingBox_Lcom_yandex_mapkit_geometry_BoundingBox_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBoundingBox));
		}
		return cb_getBoundingBox_GetBoundingBox_Lcom_yandex_mapkit_geometry_BoundingBox_;
	}

	private static nint n_GetBoundingBox(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Geometry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoundingBox);
	}

	private static Delegate GetGetCircleHandler()
	{
		if ((object)cb_getCircle_GetCircle_Lcom_yandex_mapkit_geometry_Circle_ == null)
		{
			cb_getCircle_GetCircle_Lcom_yandex_mapkit_geometry_Circle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCircle));
		}
		return cb_getCircle_GetCircle_Lcom_yandex_mapkit_geometry_Circle_;
	}

	private static nint n_GetCircle(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Geometry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Circle);
	}

	private static Delegate GetGetMultiPolygonHandler()
	{
		if ((object)cb_getMultiPolygon_GetMultiPolygon_Lcom_yandex_mapkit_geometry_MultiPolygon_ == null)
		{
			cb_getMultiPolygon_GetMultiPolygon_Lcom_yandex_mapkit_geometry_MultiPolygon_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMultiPolygon));
		}
		return cb_getMultiPolygon_GetMultiPolygon_Lcom_yandex_mapkit_geometry_MultiPolygon_;
	}

	private static nint n_GetMultiPolygon(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Geometry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MultiPolygon);
	}

	private static Delegate GetGetPointHandler()
	{
		if ((object)cb_getPoint_GetPoint_Lcom_yandex_mapkit_geometry_Point_ == null)
		{
			cb_getPoint_GetPoint_Lcom_yandex_mapkit_geometry_Point_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPoint));
		}
		return cb_getPoint_GetPoint_Lcom_yandex_mapkit_geometry_Point_;
	}

	private static nint n_GetPoint(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Geometry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Point);
	}

	private static Delegate GetGetPolygonHandler()
	{
		if ((object)cb_getPolygon_GetPolygon_Lcom_yandex_mapkit_geometry_Polygon_ == null)
		{
			cb_getPolygon_GetPolygon_Lcom_yandex_mapkit_geometry_Polygon_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPolygon));
		}
		return cb_getPolygon_GetPolygon_Lcom_yandex_mapkit_geometry_Polygon_;
	}

	private static nint n_GetPolygon(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Geometry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Polygon);
	}

	private static Delegate GetGetPolylineHandler()
	{
		if ((object)cb_getPolyline_GetPolyline_Lcom_yandex_mapkit_geometry_Polyline_ == null)
		{
			cb_getPolyline_GetPolyline_Lcom_yandex_mapkit_geometry_Polyline_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPolyline));
		}
		return cb_getPolyline_GetPolyline_Lcom_yandex_mapkit_geometry_Polyline_;
	}

	private static nint n_GetPolyline(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Geometry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Polyline);
	}

	[Register("fromBoundingBox", "(Lcom/yandex/mapkit/geometry/BoundingBox;)Lcom/yandex/mapkit/geometry/Geometry;", "")]
	public unsafe static Geometry FromBoundingBox(BoundingBox boundingBox)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(boundingBox?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Geometry>(_members.StaticMethods.InvokeObjectMethod("fromBoundingBox.(Lcom/yandex/mapkit/geometry/BoundingBox;)Lcom/yandex/mapkit/geometry/Geometry;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(boundingBox);
		}
	}

	[Register("fromCircle", "(Lcom/yandex/mapkit/geometry/Circle;)Lcom/yandex/mapkit/geometry/Geometry;", "")]
	public unsafe static Geometry FromCircle(Circle circle)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(circle?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Geometry>(_members.StaticMethods.InvokeObjectMethod("fromCircle.(Lcom/yandex/mapkit/geometry/Circle;)Lcom/yandex/mapkit/geometry/Geometry;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(circle);
		}
	}

	[Register("fromMultiPolygon", "(Lcom/yandex/mapkit/geometry/MultiPolygon;)Lcom/yandex/mapkit/geometry/Geometry;", "")]
	public unsafe static Geometry FromMultiPolygon(MultiPolygon multiPolygon)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(multiPolygon?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Geometry>(_members.StaticMethods.InvokeObjectMethod("fromMultiPolygon.(Lcom/yandex/mapkit/geometry/MultiPolygon;)Lcom/yandex/mapkit/geometry/Geometry;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(multiPolygon);
		}
	}

	[Register("fromPoint", "(Lcom/yandex/mapkit/geometry/Point;)Lcom/yandex/mapkit/geometry/Geometry;", "")]
	public unsafe static Geometry FromPoint(Point point)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(point?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Geometry>(_members.StaticMethods.InvokeObjectMethod("fromPoint.(Lcom/yandex/mapkit/geometry/Point;)Lcom/yandex/mapkit/geometry/Geometry;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(point);
		}
	}

	[Register("fromPolygon", "(Lcom/yandex/mapkit/geometry/Polygon;)Lcom/yandex/mapkit/geometry/Geometry;", "")]
	public unsafe static Geometry FromPolygon(Polygon polygon)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(polygon?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Geometry>(_members.StaticMethods.InvokeObjectMethod("fromPolygon.(Lcom/yandex/mapkit/geometry/Polygon;)Lcom/yandex/mapkit/geometry/Geometry;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(polygon);
		}
	}

	[Register("fromPolyline", "(Lcom/yandex/mapkit/geometry/Polyline;)Lcom/yandex/mapkit/geometry/Geometry;", "")]
	public unsafe static Geometry FromPolyline(Polyline polyline)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(polyline?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Geometry>(_members.StaticMethods.InvokeObjectMethod("fromPolyline.(Lcom/yandex/mapkit/geometry/Polyline;)Lcom/yandex/mapkit/geometry/Geometry;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(polyline);
		}
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
		Geometry? geometry = Java.Lang.Object.GetObject<Geometry>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		geometry.Serialize(archive);
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
