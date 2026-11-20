using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Runtime.Image;

[Register("com/yandex/runtime/image/ImageProvider", DoNotGenerateAcw = true)]
public abstract class ImageProvider : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/runtime/image/ImageProvider", typeof(ImageProvider));

	private static Delegate? cb_getId_GetId_Ljava_lang_String_;

	private static Delegate? cb_getImage_GetImage_Landroid_graphics_Bitmap_;

	private static Delegate? cb_isCacheable_IsCacheable_Z;

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

	public abstract Bitmap? Image
	{
		[Register("getImage", "()Landroid/graphics/Bitmap;", "GetGetImageHandler")]
		get;
	}

	public unsafe virtual bool IsCacheable
	{
		[Register("isCacheable", "()Z", "GetIsCacheableHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCacheable.()Z", this, null);
		}
	}

	protected ImageProvider(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe ImageProvider()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Z)V", "")]
	public unsafe ImageProvider(bool cacheable)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cacheable);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Z)V", this, ptr);
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
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ImageProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id);
	}

	private static Delegate GetGetImageHandler()
	{
		if ((object)cb_getImage_GetImage_Landroid_graphics_Bitmap_ == null)
		{
			cb_getImage_GetImage_Landroid_graphics_Bitmap_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImage));
		}
		return cb_getImage_GetImage_Landroid_graphics_Bitmap_;
	}

	private static nint n_GetImage(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ImageProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Image);
	}

	private static Delegate GetIsCacheableHandler()
	{
		if ((object)cb_isCacheable_IsCacheable_Z == null)
		{
			cb_isCacheable_IsCacheable_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsCacheable));
		}
		return cb_isCacheable_IsCacheable_Z;
	}

	private static bool n_IsCacheable(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ImageProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCacheable;
	}

	[Register("fromAsset", "(Landroid/content/Context;Ljava/lang/String;)Lcom/yandex/runtime/image/ImageProvider;", "")]
	public unsafe static ImageProvider? FromAsset(Context? context, string? assetName)
	{
		nint num = JNIEnv.NewString(assetName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ImageProvider>(_members.StaticMethods.InvokeObjectMethod("fromAsset.(Landroid/content/Context;Ljava/lang/String;)Lcom/yandex/runtime/image/ImageProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
		}
	}

	[Register("fromAsset", "(Landroid/content/Context;Ljava/lang/String;Z)Lcom/yandex/runtime/image/ImageProvider;", "")]
	public unsafe static ImageProvider? FromAsset(Context? context, string? assetName, bool cacheable)
	{
		nint num = JNIEnv.NewString(assetName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(cacheable);
			return Java.Lang.Object.GetObject<ImageProvider>(_members.StaticMethods.InvokeObjectMethod("fromAsset.(Landroid/content/Context;Ljava/lang/String;Z)Lcom/yandex/runtime/image/ImageProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(context);
		}
	}

	[Register("fromBitmap", "(Landroid/graphics/Bitmap;)Lcom/yandex/runtime/image/ImageProvider;", "")]
	public unsafe static ImageProvider? FromBitmap(Bitmap? bitmap)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ImageProvider>(_members.StaticMethods.InvokeObjectMethod("fromBitmap.(Landroid/graphics/Bitmap;)Lcom/yandex/runtime/image/ImageProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(bitmap);
		}
	}

	[Register("fromBitmap", "(Landroid/graphics/Bitmap;ZLjava/lang/String;)Lcom/yandex/runtime/image/ImageProvider;", "")]
	public unsafe static ImageProvider? FromBitmap(Bitmap? bitmap, bool cacheable, string? id)
	{
		nint num = JNIEnv.NewString(id);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(bitmap?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(cacheable);
			ptr[2] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ImageProvider>(_members.StaticMethods.InvokeObjectMethod("fromBitmap.(Landroid/graphics/Bitmap;ZLjava/lang/String;)Lcom/yandex/runtime/image/ImageProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(bitmap);
		}
	}

	[Register("fromFile", "(Ljava/lang/String;)Lcom/yandex/runtime/image/ImageProvider;", "")]
	public unsafe static ImageProvider? FromFile(string? fileName)
	{
		nint num = JNIEnv.NewString(fileName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ImageProvider>(_members.StaticMethods.InvokeObjectMethod("fromFile.(Ljava/lang/String;)Lcom/yandex/runtime/image/ImageProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("fromFile", "(Ljava/lang/String;Z)Lcom/yandex/runtime/image/ImageProvider;", "")]
	public unsafe static ImageProvider? FromFile(string? fileName, bool cacheable)
	{
		nint num = JNIEnv.NewString(fileName);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(cacheable);
			return Java.Lang.Object.GetObject<ImageProvider>(_members.StaticMethods.InvokeObjectMethod("fromFile.(Ljava/lang/String;Z)Lcom/yandex/runtime/image/ImageProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("fromResource", "(Landroid/content/Context;I)Lcom/yandex/runtime/image/ImageProvider;", "")]
	public unsafe static ImageProvider? FromResource(Context? context, int resourceId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resourceId);
			return Java.Lang.Object.GetObject<ImageProvider>(_members.StaticMethods.InvokeObjectMethod("fromResource.(Landroid/content/Context;I)Lcom/yandex/runtime/image/ImageProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("fromResource", "(Landroid/content/Context;IZ)Lcom/yandex/runtime/image/ImageProvider;", "")]
	public unsafe static ImageProvider? FromResource(Context? context, int resourceId, bool cacheable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resourceId);
			ptr[2] = new JniArgumentValue(cacheable);
			return Java.Lang.Object.GetObject<ImageProvider>(_members.StaticMethods.InvokeObjectMethod("fromResource.(Landroid/content/Context;IZ)Lcom/yandex/runtime/image/ImageProvider;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}
}
