using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Bumptech.Glide.Load;
using Bumptech.Glide.Load.Engine;
using Bumptech.Glide.Load.Resource.Bitmap;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Request;

[Register("com/bumptech/glide/request/RequestOptions", DoNotGenerateAcw = true)]
public class RequestOptions : BaseRequestOptions
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/request/RequestOptions", typeof(RequestOptions));

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

	public virtual RequestOptions Apply(BaseRequestOptions o)
	{
		return (RequestOptions)Apply_T(o);
	}

	public virtual RequestOptions AutoClone()
	{
		return (RequestOptions)AutoClone_T();
	}

	public virtual RequestOptions CenterCrop()
	{
		return (RequestOptions)CenterCrop_T();
	}

	public virtual RequestOptions CenterInside()
	{
		return (RequestOptions)CenterInside_T();
	}

	public virtual RequestOptions CircleCrop()
	{
		return (RequestOptions)CircleCrop_T();
	}

	public new virtual RequestOptions Clone()
	{
		return (RequestOptions)Clone_T();
	}

	public virtual RequestOptions Decode(Class resourceClass)
	{
		return (RequestOptions)Decode_T(resourceClass);
	}

	public virtual RequestOptions DisallowHardwareConfig()
	{
		return (RequestOptions)DisallowHardwareConfig_T();
	}

	public virtual RequestOptions DontAnimate()
	{
		return (RequestOptions)DontAnimate_T();
	}

	public virtual RequestOptions DontTransform()
	{
		return (RequestOptions)DontTransform_T();
	}

	public virtual RequestOptions Downsample(DownsampleStrategy strategy)
	{
		return (RequestOptions)Downsample_T(strategy);
	}

	public virtual RequestOptions EncodeFormat(Bitmap.CompressFormat format)
	{
		return (RequestOptions)EncodeFormat_T(format);
	}

	public virtual RequestOptions EncodeQuality(int quality)
	{
		return (RequestOptions)EncodeQuality_T(quality);
	}

	public virtual RequestBuilder Error(Drawable drawable)
	{
		return (RequestBuilder)Error_T(drawable);
	}

	public virtual RequestOptions Error(int resourceId)
	{
		return (RequestOptions)Error_T(resourceId);
	}

	public virtual RequestOptions Fallback(Drawable drawable)
	{
		return (RequestOptions)Fallback_T(drawable);
	}

	public virtual RequestOptions Fallback(int resourceId)
	{
		return (RequestOptions)Fallback_T(resourceId);
	}

	public virtual RequestOptions FitCenter()
	{
		return (RequestOptions)FitCenter_T();
	}

	public virtual RequestOptions Format(DecodeFormat format)
	{
		return (RequestOptions)Format_T(format);
	}

	public virtual RequestOptions Frame(long frameTimeMicros)
	{
		return (RequestOptions)Frame_T(frameTimeMicros);
	}

	public virtual RequestOptions Lock()
	{
		return (RequestOptions)Lock_T();
	}

	public virtual RequestOptions OptionalCenterCrop()
	{
		return (RequestOptions)OptionalCenterCrop_T();
	}

	public virtual RequestOptions OptionalCenterInside()
	{
		return (RequestOptions)OptionalCenterInside_T();
	}

	public virtual RequestOptions OptionalCircleCrop()
	{
		return (RequestOptions)OptionalCircleCrop_T();
	}

	public virtual RequestOptions OptionalFitCenter()
	{
		return (RequestOptions)OptionalFitCenter_T();
	}

	public virtual RequestOptions OptionalTransform(Class resourceClass, ITransformation transformation)
	{
		return (RequestOptions)OptionalTransform_T(resourceClass, transformation);
	}

	public virtual RequestOptions OptionalTransform(ITransformation transformation)
	{
		return (RequestOptions)OptionalTransform_T(transformation);
	}

	public virtual RequestOptions Override(int width, int height)
	{
		return (RequestOptions)Override_T(width, height);
	}

	public virtual RequestOptions Override(int size)
	{
		return (RequestOptions)Override_T(size);
	}

	public virtual RequestOptions Placeholder(Drawable drawable)
	{
		return (RequestOptions)Placeholder_T(drawable);
	}

	public virtual RequestOptions Placeholder(int resourceId)
	{
		return (RequestOptions)Placeholder_T(resourceId);
	}

	public virtual RequestOptions Set(Option option, Java.Lang.Object value)
	{
		return (RequestOptions)Set_T(option, value);
	}

	public virtual RequestOptions SetDiskCacheStrategy(DiskCacheStrategy strategy)
	{
		return (RequestOptions)DiskCacheStrategy_T(strategy);
	}

	public virtual RequestOptions SetOnlyRetrieveFromCache(bool flag)
	{
		return (RequestOptions)OnlyRetrieveFromCache_T(flag);
	}

	public virtual RequestOptions SetPriority(Priority priority)
	{
		return (RequestOptions)Priority_T(priority);
	}

	public virtual RequestOptions SetSignature(IKey signature)
	{
		return (RequestOptions)Signature_T(signature);
	}

	public virtual RequestOptions SetSizeMultiplier(float sizeMultiplier)
	{
		return (RequestOptions)SizeMultiplier_T(sizeMultiplier);
	}

	public virtual RequestOptions SetTheme(Resources.Theme theme)
	{
		return (RequestOptions)Theme_T(theme);
	}

	public virtual RequestOptions SetUseAnimationPool(bool flag)
	{
		return (RequestOptions)UseAnimationPool_T(flag);
	}

	public virtual RequestOptions SetUseUnlimitedSourceGeneratorsPool(bool flag)
	{
		return (RequestOptions)UseUnlimitedSourceGeneratorsPool_T(flag);
	}

	public virtual RequestOptions SkipMemoryCache(bool skip)
	{
		return (RequestOptions)SkipMemoryCache_T(skip);
	}

	public virtual RequestOptions Timeout(int timeoutMs)
	{
		return (RequestOptions)Timeout_T(timeoutMs);
	}

	public virtual RequestOptions Transform(Class resourceClass, ITransformation transformation)
	{
		return (RequestOptions)Transform_T(resourceClass, transformation);
	}

	public virtual RequestOptions Transform(params ITransformation[] transformations)
	{
		return (RequestOptions)Transform_T(transformations);
	}

	public virtual RequestOptions Transform(ITransformation transformation)
	{
		return (RequestOptions)Transform_T(transformation);
	}

	protected RequestOptions(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe RequestOptions()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register("bitmapTransform", "(Lcom/bumptech/glide/load/Transformation;)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions BitmapTransform(ITransformation transformation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((transformation == null) ? IntPtr.Zero : ((Java.Lang.Object)transformation).Handle);
			return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("bitmapTransform.(Lcom/bumptech/glide/load/Transformation;)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(transformation);
		}
	}

	[Register("centerCropTransform", "()Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions CenterCropTransform()
	{
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("centerCropTransform.()Lcom/bumptech/glide/request/RequestOptions;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("centerInsideTransform", "()Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions CenterInsideTransform()
	{
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("centerInsideTransform.()Lcom/bumptech/glide/request/RequestOptions;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("circleCropTransform", "()Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions CircleCropTransform()
	{
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("circleCropTransform.()Lcom/bumptech/glide/request/RequestOptions;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("decodeTypeOf", "(Ljava/lang/Class;)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions DecodeTypeOf(Class resourceClass)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(resourceClass?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("decodeTypeOf.(Ljava/lang/Class;)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(resourceClass);
		}
	}

	[Register("diskCacheStrategyOf", "(Lcom/bumptech/glide/load/engine/DiskCacheStrategy;)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions DiskCacheStrategyOf(DiskCacheStrategy diskCacheStrategy)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(diskCacheStrategy?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("diskCacheStrategyOf.(Lcom/bumptech/glide/load/engine/DiskCacheStrategy;)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(diskCacheStrategy);
		}
	}

	[Register("downsampleOf", "(Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy;)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions DownsampleOf(DownsampleStrategy strategy)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(strategy?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("downsampleOf.(Lcom/bumptech/glide/load/resource/bitmap/DownsampleStrategy;)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(strategy);
		}
	}

	[Register("encodeFormatOf", "(Landroid/graphics/Bitmap$CompressFormat;)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions EncodeFormatOf(Bitmap.CompressFormat format)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("encodeFormatOf.(Landroid/graphics/Bitmap$CompressFormat;)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(format);
		}
	}

	[Register("encodeQualityOf", "(I)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions EncodeQualityOf(int quality)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(quality);
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("encodeQualityOf.(I)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("errorOf", "(Landroid/graphics/drawable/Drawable;)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions ErrorOf(Drawable? errorDrawable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(errorDrawable?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("errorOf.(Landroid/graphics/drawable/Drawable;)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(errorDrawable);
		}
	}

	[Register("errorOf", "(I)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions ErrorOf(int errorId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(errorId);
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("errorOf.(I)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("fitCenterTransform", "()Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions FitCenterTransform()
	{
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("fitCenterTransform.()Lcom/bumptech/glide/request/RequestOptions;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("formatOf", "(Lcom/bumptech/glide/load/DecodeFormat;)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions FormatOf(DecodeFormat format)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(format?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("formatOf.(Lcom/bumptech/glide/load/DecodeFormat;)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(format);
		}
	}

	[Register("frameOf", "(J)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions FrameOf(long frameTimeMicros)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(frameTimeMicros);
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("frameOf.(J)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("noAnimation", "()Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions NoAnimation()
	{
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("noAnimation.()Lcom/bumptech/glide/request/RequestOptions;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("noTransformation", "()Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions NoTransformation()
	{
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("noTransformation.()Lcom/bumptech/glide/request/RequestOptions;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("option", "(Lcom/bumptech/glide/load/Option;Ljava/lang/Object;)Lcom/bumptech/glide/request/RequestOptions;", "")]
	[JavaTypeParameters(new string[] { "T" })]
	public unsafe static RequestOptions Option(Option option, Java.Lang.Object value)
	{
		nint num = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(option?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("option.(Lcom/bumptech/glide/load/Option;Ljava/lang/Object;)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(option);
			GC.KeepAlive(value);
		}
	}

	[Register("overrideOf", "(I)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions OverrideOf(int size)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(size);
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("overrideOf.(I)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("overrideOf", "(II)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions OverrideOf(int width, int height)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(width);
		ptr[1] = new JniArgumentValue(height);
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("overrideOf.(II)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("placeholderOf", "(Landroid/graphics/drawable/Drawable;)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions PlaceholderOf(Drawable? placeholder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(placeholder?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("placeholderOf.(Landroid/graphics/drawable/Drawable;)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(placeholder);
		}
	}

	[Register("placeholderOf", "(I)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions PlaceholderOf(int placeholderId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(placeholderId);
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("placeholderOf.(I)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("priorityOf", "(Lcom/bumptech/glide/Priority;)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions PriorityOf(Priority priority)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(priority?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("priorityOf.(Lcom/bumptech/glide/Priority;)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(priority);
		}
	}

	[Register("signatureOf", "(Lcom/bumptech/glide/load/Key;)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions SignatureOf(IKey signature)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((signature == null) ? IntPtr.Zero : ((Java.Lang.Object)signature).Handle);
			return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("signatureOf.(Lcom/bumptech/glide/load/Key;)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(signature);
		}
	}

	[Register("sizeMultiplierOf", "(F)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions SizeMultiplierOf(float sizeMultiplier)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(sizeMultiplier);
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("sizeMultiplierOf.(F)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("skipMemoryCacheOf", "(Z)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions SkipMemoryCacheOf(bool skipMemoryCache)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(skipMemoryCache ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("skipMemoryCacheOf.(Z)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("timeoutOf", "(I)Lcom/bumptech/glide/request/RequestOptions;", "")]
	public unsafe static RequestOptions TimeoutOf(int timeout)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(timeout);
		return Java.Lang.Object.GetObject<RequestOptions>(_members.StaticMethods.InvokeObjectMethod("timeoutOf.(I)Lcom/bumptech/glide/request/RequestOptions;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
