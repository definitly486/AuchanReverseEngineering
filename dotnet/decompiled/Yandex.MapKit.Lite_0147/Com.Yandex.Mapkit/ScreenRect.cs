using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit;

[Register("com/yandex/mapkit/ScreenRect", DoNotGenerateAcw = true)]
public class ScreenRect : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/ScreenRect", typeof(ScreenRect));

	private static Delegate? cb_getBottomRight_GetBottomRight_Lcom_yandex_mapkit_ScreenPoint_;

	private static Delegate? cb_getTopLeft_GetTopLeft_Lcom_yandex_mapkit_ScreenPoint_;

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

	public unsafe virtual ScreenPoint BottomRight
	{
		[Register("getBottomRight", "()Lcom/yandex/mapkit/ScreenPoint;", "GetGetBottomRightHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ScreenPoint>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBottomRight.()Lcom/yandex/mapkit/ScreenPoint;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ScreenPoint TopLeft
	{
		[Register("getTopLeft", "()Lcom/yandex/mapkit/ScreenPoint;", "GetGetTopLeftHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ScreenPoint>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTopLeft.()Lcom/yandex/mapkit/ScreenPoint;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ScreenRect(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ScreenRect()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/ScreenPoint;Lcom/yandex/mapkit/ScreenPoint;)V", "")]
	public unsafe ScreenRect(ScreenPoint topLeft, ScreenPoint bottomRight)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(topLeft?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(bottomRight?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/ScreenPoint;Lcom/yandex/mapkit/ScreenPoint;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/ScreenPoint;Lcom/yandex/mapkit/ScreenPoint;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(topLeft);
			GC.KeepAlive(bottomRight);
		}
	}

	private static Delegate GetGetBottomRightHandler()
	{
		if ((object)cb_getBottomRight_GetBottomRight_Lcom_yandex_mapkit_ScreenPoint_ == null)
		{
			cb_getBottomRight_GetBottomRight_Lcom_yandex_mapkit_ScreenPoint_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBottomRight));
		}
		return cb_getBottomRight_GetBottomRight_Lcom_yandex_mapkit_ScreenPoint_;
	}

	private static nint n_GetBottomRight(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScreenRect>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BottomRight);
	}

	private static Delegate GetGetTopLeftHandler()
	{
		if ((object)cb_getTopLeft_GetTopLeft_Lcom_yandex_mapkit_ScreenPoint_ == null)
		{
			cb_getTopLeft_GetTopLeft_Lcom_yandex_mapkit_ScreenPoint_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTopLeft));
		}
		return cb_getTopLeft_GetTopLeft_Lcom_yandex_mapkit_ScreenPoint_;
	}

	private static nint n_GetTopLeft(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ScreenRect>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TopLeft);
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
		ScreenRect? screenRect = Java.Lang.Object.GetObject<ScreenRect>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		screenRect.Serialize(archive);
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
