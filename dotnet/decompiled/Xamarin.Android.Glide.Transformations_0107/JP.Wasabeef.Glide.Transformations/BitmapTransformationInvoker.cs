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

[Register("jp/wasabeef/glide/transformations/BitmapTransformation", DoNotGenerateAcw = true)]
internal class BitmapTransformationInvoker : BitmapTransformation
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("jp/wasabeef/glide/transformations/BitmapTransformation", typeof(BitmapTransformationInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public BitmapTransformationInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("equals", "(Ljava/lang/Object;)Z", "GetEquals_Ljava_lang_Object_Handler")]
	public unsafe override bool Equals(Java.Lang.Object? o)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(o);
		}
	}

	[Register("hashCode", "()I", "GetGetHashCodeHandler")]
	public unsafe override int GetHashCode()
	{
		return _members.InstanceMethods.InvokeAbstractInt32Method("hashCode.()I", this, null);
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
			return Java.Lang.Object.GetObject<Bitmap>(_members.InstanceMethods.InvokeAbstractObjectMethod("transform.(Landroid/content/Context;Lcom/bumptech/glide/load/engine/bitmap_recycle/BitmapPool;Landroid/graphics/Bitmap;II)Landroid/graphics/Bitmap;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(pool);
			GC.KeepAlive(toTransform);
		}
	}

	[Register("updateDiskCacheKey", "(Ljava/security/MessageDigest;)V", "GetUpdateDiskCacheKey_Ljava_security_MessageDigest_Handler")]
	public unsafe override void UpdateDiskCacheKey(MessageDigest messageDigest)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(messageDigest?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("updateDiskCacheKey.(Ljava/security/MessageDigest;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(messageDigest);
		}
	}
}
