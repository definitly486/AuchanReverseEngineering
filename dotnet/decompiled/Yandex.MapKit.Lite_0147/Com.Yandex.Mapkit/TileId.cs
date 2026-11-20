using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit;

[Register("com/yandex/mapkit/TileId", DoNotGenerateAcw = true)]
public class TileId : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/TileId", typeof(TileId));

	private static Delegate? cb_getX_GetX_I;

	private static Delegate? cb_getY_GetY_I;

	private static Delegate? cb_getZ_GetZ_I;

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

	protected TileId(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe TileId()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(III)V", "")]
	public unsafe TileId(int x, int y, int z)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			ptr[2] = new JniArgumentValue(z);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(III)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(III)V", this, ptr);
		}
	}

	private static Delegate GetGetXHandler()
	{
		if ((object)cb_getX_GetX_I == null)
		{
			cb_getX_GetX_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetX));
		}
		return cb_getX_GetX_I;
	}

	private static int n_GetX(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<TileId>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetX();
	}

	[Register("getX", "()I", "GetGetXHandler")]
	public unsafe virtual int GetX()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("getX.()I", this, null);
	}

	private static Delegate GetGetYHandler()
	{
		if ((object)cb_getY_GetY_I == null)
		{
			cb_getY_GetY_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetY));
		}
		return cb_getY_GetY_I;
	}

	private static int n_GetY(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<TileId>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetY();
	}

	[Register("getY", "()I", "GetGetYHandler")]
	public unsafe virtual int GetY()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("getY.()I", this, null);
	}

	private static Delegate GetGetZHandler()
	{
		if ((object)cb_getZ_GetZ_I == null)
		{
			cb_getZ_GetZ_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetZ));
		}
		return cb_getZ_GetZ_I;
	}

	private static int n_GetZ(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<TileId>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetZ();
	}

	[Register("getZ", "()I", "GetGetZHandler")]
	public unsafe virtual int GetZ()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("getZ.()I", this, null);
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
		TileId? tileId = Java.Lang.Object.GetObject<TileId>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		tileId.Serialize(archive);
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
