using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Geometry;

[Register("com/yandex/mapkit/geometry/Subpolyline", DoNotGenerateAcw = true)]
public class Subpolyline : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/geometry/Subpolyline", typeof(Subpolyline));

	private static Delegate? cb_getBegin_GetBegin_Lcom_yandex_mapkit_geometry_PolylinePosition_;

	private static Delegate? cb_getEnd_GetEnd_Lcom_yandex_mapkit_geometry_PolylinePosition_;

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

	public unsafe virtual PolylinePosition Begin
	{
		[Register("getBegin", "()Lcom/yandex/mapkit/geometry/PolylinePosition;", "GetGetBeginHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PolylinePosition>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBegin.()Lcom/yandex/mapkit/geometry/PolylinePosition;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual PolylinePosition End
	{
		[Register("getEnd", "()Lcom/yandex/mapkit/geometry/PolylinePosition;", "GetGetEndHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PolylinePosition>(_members.InstanceMethods.InvokeVirtualObjectMethod("getEnd.()Lcom/yandex/mapkit/geometry/PolylinePosition;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Subpolyline(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Subpolyline()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/geometry/PolylinePosition;Lcom/yandex/mapkit/geometry/PolylinePosition;)V", "")]
	public unsafe Subpolyline(PolylinePosition begin, PolylinePosition end)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(begin?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(end?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/geometry/PolylinePosition;Lcom/yandex/mapkit/geometry/PolylinePosition;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/geometry/PolylinePosition;Lcom/yandex/mapkit/geometry/PolylinePosition;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(begin);
			GC.KeepAlive(end);
		}
	}

	private static Delegate GetGetBeginHandler()
	{
		if ((object)cb_getBegin_GetBegin_Lcom_yandex_mapkit_geometry_PolylinePosition_ == null)
		{
			cb_getBegin_GetBegin_Lcom_yandex_mapkit_geometry_PolylinePosition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBegin));
		}
		return cb_getBegin_GetBegin_Lcom_yandex_mapkit_geometry_PolylinePosition_;
	}

	private static nint n_GetBegin(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Subpolyline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Begin);
	}

	private static Delegate GetGetEndHandler()
	{
		if ((object)cb_getEnd_GetEnd_Lcom_yandex_mapkit_geometry_PolylinePosition_ == null)
		{
			cb_getEnd_GetEnd_Lcom_yandex_mapkit_geometry_PolylinePosition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetEnd));
		}
		return cb_getEnd_GetEnd_Lcom_yandex_mapkit_geometry_PolylinePosition_;
	}

	private static nint n_GetEnd(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Subpolyline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).End);
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
		Subpolyline? subpolyline = Java.Lang.Object.GetObject<Subpolyline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		subpolyline.Serialize(archive);
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
