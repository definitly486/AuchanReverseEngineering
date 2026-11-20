using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Runtime.Bindings;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Images;

[Register("com/yandex/mapkit/images/ImageDataDescriptor", DoNotGenerateAcw = true)]
public class ImageDataDescriptor : Java.Lang.Object, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/images/ImageDataDescriptor", typeof(ImageDataDescriptor));

	private static Delegate? cb_getImageId_GetImageId_Ljava_lang_String_;

	private static Delegate? cb_getPrimaryColor_GetPrimaryColor_Ljava_lang_Integer_;

	private static Delegate? cb_getSecondaryColor_GetSecondaryColor_Ljava_lang_Integer_;

	private static Delegate? cb_getTertiaryColor_GetTertiaryColor_Ljava_lang_Integer_;

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

	public unsafe virtual string ImageId
	{
		[Register("getImageId", "()Ljava/lang/String;", "GetGetImageIdHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getImageId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Integer? PrimaryColor
	{
		[Register("getPrimaryColor", "()Ljava/lang/Integer;", "GetGetPrimaryColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPrimaryColor.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Integer? SecondaryColor
	{
		[Register("getSecondaryColor", "()Ljava/lang/Integer;", "GetGetSecondaryColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSecondaryColor.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Integer? TertiaryColor
	{
		[Register("getTertiaryColor", "()Ljava/lang/Integer;", "GetGetTertiaryColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTertiaryColor.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected ImageDataDescriptor(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ImageDataDescriptor()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Integer;Ljava/lang/Integer;Ljava/lang/Integer;)V", "")]
	public unsafe ImageDataDescriptor(string imageId, Integer? primaryColor, Integer? secondaryColor, Integer? tertiaryColor)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(imageId);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(primaryColor?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(secondaryColor?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(tertiaryColor?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/Integer;Ljava/lang/Integer;Ljava/lang/Integer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/Integer;Ljava/lang/Integer;Ljava/lang/Integer;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(primaryColor);
			GC.KeepAlive(secondaryColor);
			GC.KeepAlive(tertiaryColor);
		}
	}

	private static Delegate GetGetImageIdHandler()
	{
		if ((object)cb_getImageId_GetImageId_Ljava_lang_String_ == null)
		{
			cb_getImageId_GetImageId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImageId));
		}
		return cb_getImageId_GetImageId_Ljava_lang_String_;
	}

	private static nint n_GetImageId(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ImageDataDescriptor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImageId);
	}

	private static Delegate GetGetPrimaryColorHandler()
	{
		if ((object)cb_getPrimaryColor_GetPrimaryColor_Ljava_lang_Integer_ == null)
		{
			cb_getPrimaryColor_GetPrimaryColor_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPrimaryColor));
		}
		return cb_getPrimaryColor_GetPrimaryColor_Ljava_lang_Integer_;
	}

	private static nint n_GetPrimaryColor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ImageDataDescriptor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PrimaryColor);
	}

	private static Delegate GetGetSecondaryColorHandler()
	{
		if ((object)cb_getSecondaryColor_GetSecondaryColor_Ljava_lang_Integer_ == null)
		{
			cb_getSecondaryColor_GetSecondaryColor_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSecondaryColor));
		}
		return cb_getSecondaryColor_GetSecondaryColor_Ljava_lang_Integer_;
	}

	private static nint n_GetSecondaryColor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ImageDataDescriptor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SecondaryColor);
	}

	private static Delegate GetGetTertiaryColorHandler()
	{
		if ((object)cb_getTertiaryColor_GetTertiaryColor_Ljava_lang_Integer_ == null)
		{
			cb_getTertiaryColor_GetTertiaryColor_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTertiaryColor));
		}
		return cb_getTertiaryColor_GetTertiaryColor_Ljava_lang_Integer_;
	}

	private static nint n_GetTertiaryColor(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ImageDataDescriptor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TertiaryColor);
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
		ImageDataDescriptor? imageDataDescriptor = Java.Lang.Object.GetObject<ImageDataDescriptor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IArchive archive = Java.Lang.Object.GetObject<IArchive>(native_archive, JniHandleOwnership.DoNotTransfer);
		imageDataDescriptor.Serialize(archive);
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
