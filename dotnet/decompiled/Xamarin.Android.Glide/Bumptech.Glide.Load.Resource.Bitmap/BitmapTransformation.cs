using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Bumptech.Glide.Load.Engine;
using Bumptech.Glide.Load.Engine.BitmapRecycle;
using Java.Interop;
using Java.Lang;
using Java.Security;

namespace Bumptech.Glide.Load.Resource.Bitmap;

[Register("com/bumptech/glide/load/resource/bitmap/BitmapTransformation", DoNotGenerateAcw = true)]
public abstract class BitmapTransformation : Java.Lang.Object, ITransformation, IKey, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/resource/bitmap/BitmapTransformation", typeof(BitmapTransformation));

	private static Delegate? cb_transform_Transform_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_II_Landroid_graphics_Bitmap_;

	private static Delegate? cb_updateDiskCacheKey_UpdateDiskCacheKey_Ljava_security_MessageDigest__V;

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

	protected BitmapTransformation(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe BitmapTransformation()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("transform", "(Landroid/content/Context;Lcom/bumptech/glide/load/engine/Resource;II)Lcom/bumptech/glide/load/engine/Resource;", "")]
	public unsafe IResource Transform(Context context, IResource resource, int outWidth, int outHeight)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((resource == null) ? IntPtr.Zero : ((Java.Lang.Object)resource).Handle);
			ptr[2] = new JniArgumentValue(outWidth);
			ptr[3] = new JniArgumentValue(outHeight);
			return Java.Lang.Object.GetObject<IResource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("transform.(Landroid/content/Context;Lcom/bumptech/glide/load/engine/Resource;II)Lcom/bumptech/glide/load/engine/Resource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(resource);
		}
	}

	private static Delegate GetTransform_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_IIHandler()
	{
		return new _JniMarshal_PPLLII_L(n_Transform_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Transform_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_II(nint jnienv, nint native__this, nint native_p0, nint native_p1, int p2, int p3)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BitmapTransformation? bitmapTransformation = Java.Lang.Object.GetObject<BitmapTransformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IBitmapPool p4 = Java.Lang.Object.GetObject<IBitmapPool>(native_p0, JniHandleOwnership.DoNotTransfer);
			Android.Graphics.Bitmap p5 = Java.Lang.Object.GetObject<Android.Graphics.Bitmap>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bitmapTransformation.Transform(p4, p5, p2, p3));
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("transform", "(Lcom/bumptech/glide/load/engine/bitmap_recycle/BitmapPool;Landroid/graphics/Bitmap;II)Landroid/graphics/Bitmap;", "GetTransform_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_IIHandler")]
	protected abstract Android.Graphics.Bitmap? Transform(IBitmapPool p0, Android.Graphics.Bitmap p1, int p2, int p3);

	private static Delegate GetUpdateDiskCacheKey_Ljava_security_MessageDigest_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateDiskCacheKey_Ljava_security_MessageDigest_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateDiskCacheKey_Ljava_security_MessageDigest_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BitmapTransformation? bitmapTransformation = Java.Lang.Object.GetObject<BitmapTransformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MessageDigest p = Java.Lang.Object.GetObject<MessageDigest>(native_p0, JniHandleOwnership.DoNotTransfer);
			bitmapTransformation.UpdateDiskCacheKey(p);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("updateDiskCacheKey", "(Ljava/security/MessageDigest;)V", "GetUpdateDiskCacheKey_Ljava_security_MessageDigest_Handler")]
	public abstract void UpdateDiskCacheKey(MessageDigest p0);

	IResource ITransformation.Transform(Context p0, IResource p1, int p2, int p3)
	{
		return JavaObjectExtensions.JavaCast<IResource>(Transform(p0, JavaObjectExtensions.JavaCast<IResource>(p1), p2, p3));
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
