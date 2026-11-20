using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit;

[Register("com/yandex/mapkit/ZoomRange", DoNotGenerateAcw = true)]
public class ZoomRange : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/ZoomRange", typeof(ZoomRange));

	private static Delegate? cb_getZMax_GetZMax_I;

	private static Delegate? cb_getZMin_GetZMin_I;

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

	public unsafe virtual int ZMax
	{
		[Register("getZMax", "()I", "GetGetZMaxHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getZMax.()I", this, null);
		}
	}

	public unsafe virtual int ZMin
	{
		[Register("getZMin", "()I", "GetGetZMinHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getZMin.()I", this, null);
		}
	}

	protected ZoomRange(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ZoomRange()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(II)V", "")]
	public unsafe ZoomRange(int zMin, int zMax)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(zMin);
			ptr[1] = new JniArgumentValue(zMax);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
		}
	}

	private static Delegate GetGetZMaxHandler()
	{
		if ((object)cb_getZMax_GetZMax_I == null)
		{
			cb_getZMax_GetZMax_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetZMax));
		}
		return cb_getZMax_GetZMax_I;
	}

	private static int n_GetZMax(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ZoomRange>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZMax;
	}

	private static Delegate GetGetZMinHandler()
	{
		if ((object)cb_getZMin_GetZMin_I == null)
		{
			cb_getZMin_GetZMin_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetZMin));
		}
		return cb_getZMin_GetZMin_I;
	}

	private static int n_GetZMin(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ZoomRange>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZMin;
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
		ZoomRange? zoomRange = Java.Lang.Object.GetObject<ZoomRange>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		zoomRange.Serialize(archive);
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
