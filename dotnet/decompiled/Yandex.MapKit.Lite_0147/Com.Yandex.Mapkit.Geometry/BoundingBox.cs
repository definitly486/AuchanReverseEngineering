using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Geometry;

[Register("com/yandex/mapkit/geometry/BoundingBox", DoNotGenerateAcw = true)]
public class BoundingBox : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/geometry/BoundingBox", typeof(BoundingBox));

	private static Delegate? cb_getNorthEast_GetNorthEast_Lcom_yandex_mapkit_geometry_Point_;

	private static Delegate? cb_getSouthWest_GetSouthWest_Lcom_yandex_mapkit_geometry_Point_;

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

	public unsafe virtual Point NorthEast
	{
		[Register("getNorthEast", "()Lcom/yandex/mapkit/geometry/Point;", "GetGetNorthEastHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Point>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNorthEast.()Lcom/yandex/mapkit/geometry/Point;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Point SouthWest
	{
		[Register("getSouthWest", "()Lcom/yandex/mapkit/geometry/Point;", "GetGetSouthWestHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Point>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSouthWest.()Lcom/yandex/mapkit/geometry/Point;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected BoundingBox(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe BoundingBox()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/geometry/Point;)V", "")]
	public unsafe BoundingBox(Point southWest, Point northEast)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(southWest?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(northEast?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/geometry/Point;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/mapkit/geometry/Point;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(southWest);
			GC.KeepAlive(northEast);
		}
	}

	private static Delegate GetGetNorthEastHandler()
	{
		if ((object)cb_getNorthEast_GetNorthEast_Lcom_yandex_mapkit_geometry_Point_ == null)
		{
			cb_getNorthEast_GetNorthEast_Lcom_yandex_mapkit_geometry_Point_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetNorthEast));
		}
		return cb_getNorthEast_GetNorthEast_Lcom_yandex_mapkit_geometry_Point_;
	}

	private static nint n_GetNorthEast(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BoundingBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NorthEast);
	}

	private static Delegate GetGetSouthWestHandler()
	{
		if ((object)cb_getSouthWest_GetSouthWest_Lcom_yandex_mapkit_geometry_Point_ == null)
		{
			cb_getSouthWest_GetSouthWest_Lcom_yandex_mapkit_geometry_Point_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSouthWest));
		}
		return cb_getSouthWest_GetSouthWest_Lcom_yandex_mapkit_geometry_Point_;
	}

	private static nint n_GetSouthWest(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BoundingBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SouthWest);
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
		BoundingBox? boundingBox = Java.Lang.Object.GetObject<BoundingBox>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		boundingBox.Serialize(archive);
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
