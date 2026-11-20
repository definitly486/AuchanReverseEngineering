using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime.Image;

[Register("com/yandex/runtime/image/AnimatedImageProvider", DoNotGenerateAcw = true)]
public abstract class AnimatedImageProvider : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/runtime/image/AnimatedImageProvider", typeof(AnimatedImageProvider));

	private static Delegate? cb_getId_GetId_Ljava_lang_String_;

	private static Delegate? cb_getImage_GetImage_Ljava_lang_Object_;

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

	public abstract string? Id
	{
		[Register("getId", "()Ljava/lang/String;", "GetGetIdHandler")]
		get;
	}

	public abstract Java.Lang.Object? Image
	{
		[Register("getImage", "()Ljava/lang/Object;", "GetGetImageHandler")]
		get;
	}

	protected AnimatedImageProvider(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe AnimatedImageProvider()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetIdHandler()
	{
		if ((object)cb_getId_GetId_Ljava_lang_String_ == null)
		{
			cb_getId_GetId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetId));
		}
		return cb_getId_GetId_Ljava_lang_String_;
	}

	private static nint n_GetId(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<AnimatedImageProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id);
	}

	private static Delegate GetGetImageHandler()
	{
		if ((object)cb_getImage_GetImage_Ljava_lang_Object_ == null)
		{
			cb_getImage_GetImage_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImage));
		}
		return cb_getImage_GetImage_Ljava_lang_Object_;
	}

	private static nint n_GetImage(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AnimatedImageProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Image);
	}

	[Register("fromAnimatedImage", "(Lcom/yandex/runtime/image/AnimatedImage;)Lcom/yandex/runtime/image/AnimatedImageProvider;", "")]
	public unsafe static AnimatedImageProvider? FromAnimatedImage(AnimatedImage? image)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(image?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<AnimatedImageProvider>(_members.StaticMethods.InvokeObjectMethod("fromAnimatedImage.(Lcom/yandex/runtime/image/AnimatedImage;)Lcom/yandex/runtime/image/AnimatedImageProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(image);
		}
	}

	[Register("fromAsset", "(Landroid/content/Context;Ljava/lang/String;)Lcom/yandex/runtime/image/AnimatedImageProvider;", "")]
	public unsafe static AnimatedImageProvider? FromAsset(Context? context, string? assetName)
	{
		nint num = JNIEnv.NewString(assetName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<AnimatedImageProvider>(_members.StaticMethods.InvokeObjectMethod("fromAsset.(Landroid/content/Context;Ljava/lang/String;)Lcom/yandex/runtime/image/AnimatedImageProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
		}
	}

	[Register("fromByteArray", "([B)Lcom/yandex/runtime/image/AnimatedImageProvider;", "")]
	public unsafe static AnimatedImageProvider? FromByteArray(byte[]? image)
	{
		nint num = JNIEnv.NewArray(image);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<AnimatedImageProvider>(_members.StaticMethods.InvokeObjectMethod("fromByteArray.([B)Lcom/yandex/runtime/image/AnimatedImageProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (image != null)
			{
				JNIEnv.CopyArray(num, image);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(image);
		}
	}

	[Register("fromFile", "(Ljava/lang/String;)Lcom/yandex/runtime/image/AnimatedImageProvider;", "")]
	public unsafe static AnimatedImageProvider? FromFile(string? fileName)
	{
		nint num = JNIEnv.NewString(fileName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<AnimatedImageProvider>(_members.StaticMethods.InvokeObjectMethod("fromFile.(Ljava/lang/String;)Lcom/yandex/runtime/image/AnimatedImageProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("fromResource", "(Landroid/content/Context;I)Lcom/yandex/runtime/image/AnimatedImageProvider;", "")]
	public unsafe static AnimatedImageProvider? FromResource(Context? context, int resourceId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resourceId);
			return Java.Lang.Object.GetObject<AnimatedImageProvider>(_members.StaticMethods.InvokeObjectMethod("fromResource.(Landroid/content/Context;I)Lcom/yandex/runtime/image/AnimatedImageProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}
}
