using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Bumptech.Glide.Load;
using Bumptech.Glide.Load.Engine;
using Bumptech.Glide.Load.Engine.BitmapRecycle;
using Java.Interop;
using Java.Lang;
using Java.Security;

namespace JP.Wasabeef.Glide.Transformations;

[Register("jp/wasabeef/glide/transformations/BitmapTransformation", DoNotGenerateAcw = true)]
public abstract class BitmapTransformation : Java.Lang.Object, ITransformation, Bumptech.Glide.Load.IKey, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("jp/wasabeef/glide/transformations/BitmapTransformation", typeof(BitmapTransformation));

	private static Delegate? cb_equals_Ljava_lang_Object_;

	private static Delegate? cb_hashCode;

	private static Delegate? cb_transform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_II;

	private static Delegate? cb_updateDiskCacheKey_Ljava_security_MessageDigest_;

	internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected BitmapTransformation(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe BitmapTransformation()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetEquals_Ljava_lang_Object_Handler()
	{
		if ((object)cb_equals_Ljava_lang_Object_ == null)
		{
			cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
		}
		return cb_equals_Ljava_lang_Object_;
	}

	private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_o)
	{
		BitmapTransformation? bitmapTransformation = Java.Lang.Object.GetObject<BitmapTransformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object o = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o, JniHandleOwnership.DoNotTransfer);
		return bitmapTransformation.Equals(o);
	}

	[Register("equals", "(Ljava/lang/Object;)Z", "GetEquals_Ljava_lang_Object_Handler")]
	public new abstract bool Equals(Java.Lang.Object? o);

	private static Delegate GetGetHashCodeHandler()
	{
		if ((object)cb_hashCode == null)
		{
			cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
		}
		return cb_hashCode;
	}

	private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
	{
		return Java.Lang.Object.GetObject<BitmapTransformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
	}

	[Register("hashCode", "()I", "GetGetHashCodeHandler")]
	public new abstract int GetHashCode();

	private static Delegate GetTransform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_IIHandler()
	{
		if ((object)cb_transform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_II == null)
		{
			cb_transform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_II = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLII_L(n_Transform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_II));
		}
		return cb_transform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_II;
	}

	private static IntPtr n_Transform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_II(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_pool, IntPtr native_toTransform, int outWidth, int outHeight)
	{
		BitmapTransformation? bitmapTransformation = Java.Lang.Object.GetObject<BitmapTransformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
		IBitmapPool pool = Java.Lang.Object.GetObject<IBitmapPool>(native_pool, JniHandleOwnership.DoNotTransfer);
		Bitmap toTransform = Java.Lang.Object.GetObject<Bitmap>(native_toTransform, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(bitmapTransformation.Transform(context, pool, toTransform, outWidth, outHeight));
	}

	[Register("transform", "(Landroid/content/Context;Lcom/bumptech/glide/load/engine/bitmap_recycle/BitmapPool;Landroid/graphics/Bitmap;II)Landroid/graphics/Bitmap;", "GetTransform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_IIHandler")]
	protected abstract Bitmap? Transform(Context context, IBitmapPool pool, Bitmap toTransform, int outWidth, int outHeight);

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

	private static Delegate GetUpdateDiskCacheKey_Ljava_security_MessageDigest_Handler()
	{
		if ((object)cb_updateDiskCacheKey_Ljava_security_MessageDigest_ == null)
		{
			cb_updateDiskCacheKey_Ljava_security_MessageDigest_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdateDiskCacheKey_Ljava_security_MessageDigest_));
		}
		return cb_updateDiskCacheKey_Ljava_security_MessageDigest_;
	}

	private static void n_UpdateDiskCacheKey_Ljava_security_MessageDigest_(IntPtr jnienv, IntPtr native__this, IntPtr native_messageDigest)
	{
		BitmapTransformation? bitmapTransformation = Java.Lang.Object.GetObject<BitmapTransformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		MessageDigest messageDigest = Java.Lang.Object.GetObject<MessageDigest>(native_messageDigest, JniHandleOwnership.DoNotTransfer);
		bitmapTransformation.UpdateDiskCacheKey(messageDigest);
	}

	[Register("updateDiskCacheKey", "(Ljava/security/MessageDigest;)V", "GetUpdateDiskCacheKey_Ljava_security_MessageDigest_Handler")]
	public abstract void UpdateDiskCacheKey(MessageDigest messageDigest);
}
