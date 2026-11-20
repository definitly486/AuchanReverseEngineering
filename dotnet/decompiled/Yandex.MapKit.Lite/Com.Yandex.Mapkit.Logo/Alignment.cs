using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Logo;

[Register("com/yandex/mapkit/logo/Alignment", DoNotGenerateAcw = true)]
public class Alignment : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/logo/Alignment", typeof(Alignment));

	private static Delegate? cb_getHorizontalAlignment_GetHorizontalAlignment_Lcom_yandex_mapkit_logo_HorizontalAlignment_;

	private static Delegate? cb_getVerticalAlignment_GetVerticalAlignment_Lcom_yandex_mapkit_logo_VerticalAlignment_;

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

	public unsafe virtual HorizontalAlignment HorizontalAlignment
	{
		[Register("getHorizontalAlignment", "()Lcom/yandex/mapkit/logo/HorizontalAlignment;", "GetGetHorizontalAlignmentHandler")]
		get
		{
			return Java.Lang.Object.GetObject<HorizontalAlignment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHorizontalAlignment.()Lcom/yandex/mapkit/logo/HorizontalAlignment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual VerticalAlignment VerticalAlignment
	{
		[Register("getVerticalAlignment", "()Lcom/yandex/mapkit/logo/VerticalAlignment;", "GetGetVerticalAlignmentHandler")]
		get
		{
			return Java.Lang.Object.GetObject<VerticalAlignment>(_members.InstanceMethods.InvokeVirtualObjectMethod("getVerticalAlignment.()Lcom/yandex/mapkit/logo/VerticalAlignment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Alignment(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Alignment()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Lcom/yandex/mapkit/logo/HorizontalAlignment;Lcom/yandex/mapkit/logo/VerticalAlignment;)V", "")]
	public unsafe Alignment(HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(horizontalAlignment?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(verticalAlignment?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/yandex/mapkit/logo/HorizontalAlignment;Lcom/yandex/mapkit/logo/VerticalAlignment;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/yandex/mapkit/logo/HorizontalAlignment;Lcom/yandex/mapkit/logo/VerticalAlignment;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(horizontalAlignment);
			GC.KeepAlive(verticalAlignment);
		}
	}

	private static Delegate GetGetHorizontalAlignmentHandler()
	{
		if ((object)cb_getHorizontalAlignment_GetHorizontalAlignment_Lcom_yandex_mapkit_logo_HorizontalAlignment_ == null)
		{
			cb_getHorizontalAlignment_GetHorizontalAlignment_Lcom_yandex_mapkit_logo_HorizontalAlignment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetHorizontalAlignment));
		}
		return cb_getHorizontalAlignment_GetHorizontalAlignment_Lcom_yandex_mapkit_logo_HorizontalAlignment_;
	}

	private static nint n_GetHorizontalAlignment(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Alignment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalAlignment);
	}

	private static Delegate GetGetVerticalAlignmentHandler()
	{
		if ((object)cb_getVerticalAlignment_GetVerticalAlignment_Lcom_yandex_mapkit_logo_VerticalAlignment_ == null)
		{
			cb_getVerticalAlignment_GetVerticalAlignment_Lcom_yandex_mapkit_logo_VerticalAlignment_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVerticalAlignment));
		}
		return cb_getVerticalAlignment_GetVerticalAlignment_Lcom_yandex_mapkit_logo_VerticalAlignment_;
	}

	private static nint n_GetVerticalAlignment(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Alignment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalAlignment);
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
		Alignment? alignment = Java.Lang.Object.GetObject<Alignment>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		alignment.Serialize(archive);
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
