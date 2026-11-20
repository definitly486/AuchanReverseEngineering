using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Bumptech.Glide.Load.Engine.BitmapRecycle;
using Java.Interop;
using Java.Lang;
using Java.Security;

namespace Bumptech.Glide.Load.Resource.Bitmap;

[Register("com/bumptech/glide/load/resource/bitmap/FitCenter", DoNotGenerateAcw = true)]
public class FitCenter : BitmapTransformation
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/resource/bitmap/FitCenter", typeof(FitCenter));

	private static Delegate? cb_transform_Transform_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_II_Landroid_graphics_Bitmap_;

	private static Delegate? cb_updateDiskCacheKey_UpdateDiskCacheKey_Ljava_security_MessageDigest__V;

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected FitCenter(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe FitCenter()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetTransform_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_IIHandler()
	{
		return new _JniMarshal_PPLLII_L(n_Transform_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Transform_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_II(nint jnienv, nint native__this, nint native_pool, nint native_toTransform, int outWidth, int outHeight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FitCenter? fitCenter = Java.Lang.Object.GetObject<FitCenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IBitmapPool p = Java.Lang.Object.GetObject<IBitmapPool>(native_pool, JniHandleOwnership.DoNotTransfer);
			Android.Graphics.Bitmap p2 = Java.Lang.Object.GetObject<Android.Graphics.Bitmap>(native_toTransform, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(fitCenter.Transform(p, p2, outWidth, outHeight));
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
	protected unsafe override Android.Graphics.Bitmap? Transform(IBitmapPool pool, Android.Graphics.Bitmap toTransform, int outWidth, int outHeight)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue((pool == null) ? IntPtr.Zero : ((Java.Lang.Object)pool).Handle);
			ptr[1] = new JniArgumentValue(toTransform?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(outWidth);
			ptr[3] = new JniArgumentValue(outHeight);
			return Java.Lang.Object.GetObject<Android.Graphics.Bitmap>(_members.InstanceMethods.InvokeVirtualObjectMethod("transform.(Lcom/bumptech/glide/load/engine/bitmap_recycle/BitmapPool;Landroid/graphics/Bitmap;II)Landroid/graphics/Bitmap;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(pool);
			GC.KeepAlive(toTransform);
		}
	}

	private static Delegate GetUpdateDiskCacheKey_Ljava_security_MessageDigest_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateDiskCacheKey_Ljava_security_MessageDigest_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateDiskCacheKey_Ljava_security_MessageDigest_(nint jnienv, nint native__this, nint native_messageDigest)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FitCenter? fitCenter = Java.Lang.Object.GetObject<FitCenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MessageDigest p = Java.Lang.Object.GetObject<MessageDigest>(native_messageDigest, JniHandleOwnership.DoNotTransfer);
			fitCenter.UpdateDiskCacheKey(p);
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
	public unsafe override void UpdateDiskCacheKey(MessageDigest messageDigest)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(messageDigest?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateDiskCacheKey.(Ljava/security/MessageDigest;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(messageDigest);
		}
	}
}
