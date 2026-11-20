using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Logo;

[Register("com/yandex/mapkit/logo/Padding", DoNotGenerateAcw = true)]
public class Padding : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/logo/Padding", typeof(Padding));

	private static Delegate? cb_getHorizontalPadding_GetHorizontalPadding_I;

	private static Delegate? cb_getVerticalPadding_GetVerticalPadding_I;

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

	public unsafe virtual int HorizontalPadding
	{
		[Register("getHorizontalPadding", "()I", "GetGetHorizontalPaddingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHorizontalPadding.()I", this, null);
		}
	}

	public unsafe virtual int VerticalPadding
	{
		[Register("getVerticalPadding", "()I", "GetGetVerticalPaddingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getVerticalPadding.()I", this, null);
		}
	}

	protected Padding(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Padding()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(II)V", "")]
	public unsafe Padding(int horizontalPadding, int verticalPadding)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(horizontalPadding);
			ptr[1] = new JniArgumentValue(verticalPadding);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
		}
	}

	private static Delegate GetGetHorizontalPaddingHandler()
	{
		if ((object)cb_getHorizontalPadding_GetHorizontalPadding_I == null)
		{
			cb_getHorizontalPadding_GetHorizontalPadding_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHorizontalPadding));
		}
		return cb_getHorizontalPadding_GetHorizontalPadding_I;
	}

	private static int n_GetHorizontalPadding(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<Padding>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalPadding;
	}

	private static Delegate GetGetVerticalPaddingHandler()
	{
		if ((object)cb_getVerticalPadding_GetVerticalPadding_I == null)
		{
			cb_getVerticalPadding_GetVerticalPadding_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetVerticalPadding));
		}
		return cb_getVerticalPadding_GetVerticalPadding_I;
	}

	private static int n_GetVerticalPadding(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<Padding>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalPadding;
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
		Padding? padding = Java.Lang.Object.GetObject<Padding>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		padding.Serialize(archive);
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
