using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit;

[Register("com/yandex/mapkit/ScreenPoint", DoNotGenerateAcw = true)]
public class ScreenPoint : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/ScreenPoint", typeof(ScreenPoint));

	private static Delegate? cb_getX_GetX_F;

	private static Delegate? cb_getY_GetY_F;

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

	protected ScreenPoint(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ScreenPoint()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(FF)V", "")]
	public unsafe ScreenPoint(float x, float y)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(FF)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(FF)V", this, ptr);
		}
	}

	private static Delegate GetGetXHandler()
	{
		if ((object)cb_getX_GetX_F == null)
		{
			cb_getX_GetX_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetX));
		}
		return cb_getX_GetX_F;
	}

	private static float n_GetX(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ScreenPoint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetX();
	}

	[Register("getX", "()F", "GetGetXHandler")]
	public unsafe virtual float GetX()
	{
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getX.()F", this, null);
	}

	private static Delegate GetGetYHandler()
	{
		if ((object)cb_getY_GetY_F == null)
		{
			cb_getY_GetY_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetY));
		}
		return cb_getY_GetY_F;
	}

	private static float n_GetY(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ScreenPoint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetY();
	}

	[Register("getY", "()F", "GetGetYHandler")]
	public unsafe virtual float GetY()
	{
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getY.()F", this, null);
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
		ScreenPoint? screenPoint = Java.Lang.Object.GetObject<ScreenPoint>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		screenPoint.Serialize(archive);
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
