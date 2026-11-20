using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Bumptech.Glide.Load.Engine.BitmapRecycle;
using Java.Interop;
using Java.Lang;
using Java.Security;

namespace JP.Wasabeef.Glide.Transformations;

[Register("jp/wasabeef/glide/transformations/BlurTransformation", DoNotGenerateAcw = true)]
public class BlurTransformation : BitmapTransformation
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("jp/wasabeef/glide/transformations/BlurTransformation", typeof(BlurTransformation));

	private static Delegate? cb_equals_Ljava_lang_Object_;

	private static Delegate? cb_hashCode;

	private static Delegate? cb_transform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_II;

	private static Delegate? cb_updateDiskCacheKey_Ljava_security_MessageDigest_;

	internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected BlurTransformation(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe BlurTransformation()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe BlurTransformation(int radius)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(radius);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
		}
	}

	[Register(".ctor", "(II)V", "")]
	public unsafe BlurTransformation(int radius, int sampling)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(radius);
			ptr[1] = new JniArgumentValue(sampling);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
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
		BlurTransformation? blurTransformation = Java.Lang.Object.GetObject<BlurTransformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object o = Java.Lang.Object.GetObject<Java.Lang.Object>(native_o, JniHandleOwnership.DoNotTransfer);
		return blurTransformation.Equals(o);
	}

	[Register("equals", "(Ljava/lang/Object;)Z", "GetEquals_Ljava_lang_Object_Handler")]
	public unsafe override bool Equals(Java.Lang.Object? o)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

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
		return Java.Lang.Object.GetObject<BlurTransformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
	}

	[Register("hashCode", "()I", "GetGetHashCodeHandler")]
	public unsafe override int GetHashCode()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("hashCode.()I", this, null);
	}

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
		BlurTransformation? blurTransformation = Java.Lang.Object.GetObject<BlurTransformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
		IBitmapPool pool = Java.Lang.Object.GetObject<IBitmapPool>(native_pool, JniHandleOwnership.DoNotTransfer);
		Bitmap toTransform = Java.Lang.Object.GetObject<Bitmap>(native_toTransform, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(blurTransformation.Transform(context, pool, toTransform, outWidth, outHeight));
	}

	[Register("transform", "(Landroid/content/Context;Lcom/bumptech/glide/load/engine/bitmap_recycle/BitmapPool;Landroid/graphics/Bitmap;II)Landroid/graphics/Bitmap;", "GetTransform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_bitmap_recycle_BitmapPool_Landroid_graphics_Bitmap_IIHandler")]
	protected unsafe override Bitmap? Transform(Context context, IBitmapPool pool, Bitmap toTransform, int outWidth, int outHeight)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((pool == null) ? IntPtr.Zero : ((Java.Lang.Object)pool).Handle);
			ptr[2] = new JniArgumentValue(toTransform?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(outWidth);
			ptr[4] = new JniArgumentValue(outHeight);
			return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeVirtualObjectMethod("transform.(Landroid/content/Context;Lcom/bumptech/glide/load/engine/bitmap_recycle/BitmapPool;Landroid/graphics/Bitmap;II)Landroid/graphics/Bitmap;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(pool);
			GC.KeepAlive(toTransform);
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
		BlurTransformation? blurTransformation = Java.Lang.Object.GetObject<BlurTransformation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		MessageDigest messageDigest = Java.Lang.Object.GetObject<MessageDigest>(native_messageDigest, JniHandleOwnership.DoNotTransfer);
		blurTransformation.UpdateDiskCacheKey(messageDigest);
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
