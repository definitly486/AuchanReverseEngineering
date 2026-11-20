using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Geometry;

[Register("com/yandex/mapkit/geometry/Circle", DoNotGenerateAcw = true)]
public class Circle : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/geometry/Circle", typeof(Circle));

	private static Delegate? cb_getCenter_GetCenter_Lcom_yandex_mapkit_geometry_Point_;

	private static Delegate? cb_getRadius_GetRadius_F;

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

	public unsafe virtual Point Center
	{
		[Register("getCenter", "()Lcom/yandex/mapkit/geometry/Point;", "GetGetCenterHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Point>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCenter.()Lcom/yandex/mapkit/geometry/Point;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual float Radius
	{
		[Register("getRadius", "()F", "GetGetRadiusHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getRadius.()F", this, null);
		}
	}

	protected Circle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Circle()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/geometry/Point;F)V", "")]
	public unsafe Circle(Point center, float radius)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(center?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(radius);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/geometry/Point;F)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/geometry/Point;F)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(center);
		}
	}

	private static Delegate GetGetCenterHandler()
	{
		if ((object)cb_getCenter_GetCenter_Lcom_yandex_mapkit_geometry_Point_ == null)
		{
			cb_getCenter_GetCenter_Lcom_yandex_mapkit_geometry_Point_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCenter));
		}
		return cb_getCenter_GetCenter_Lcom_yandex_mapkit_geometry_Point_;
	}

	private static nint n_GetCenter(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Circle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Center);
	}

	private static Delegate GetGetRadiusHandler()
	{
		if ((object)cb_getRadius_GetRadius_F == null)
		{
			cb_getRadius_GetRadius_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetRadius));
		}
		return cb_getRadius_GetRadius_F;
	}

	private static float n_GetRadius(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<Circle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Radius;
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
		Circle? circle = Java.Lang.Object.GetObject<Circle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		circle.Serialize(archive);
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
