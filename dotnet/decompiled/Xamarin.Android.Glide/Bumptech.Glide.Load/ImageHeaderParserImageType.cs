using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load;

[Register("com/bumptech/glide/load/ImageHeaderParser$ImageType", DoNotGenerateAcw = true)]
public sealed class ImageHeaderParserImageType : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/ImageHeaderParser$ImageType", typeof(ImageHeaderParserImageType));

	[Register("ANIMATED_AVIF")]
	public static ImageHeaderParserImageType? AnimatedAvif => Java.Lang.Object.GetObject<ImageHeaderParserImageType>(_members.StaticFields.GetObjectValue("ANIMATED_AVIF.Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("ANIMATED_WEBP")]
	public static ImageHeaderParserImageType? AnimatedWebp => Java.Lang.Object.GetObject<ImageHeaderParserImageType>(_members.StaticFields.GetObjectValue("ANIMATED_WEBP.Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("AVIF")]
	public static ImageHeaderParserImageType? Avif => Java.Lang.Object.GetObject<ImageHeaderParserImageType>(_members.StaticFields.GetObjectValue("AVIF.Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("GIF")]
	public static ImageHeaderParserImageType? Gif => Java.Lang.Object.GetObject<ImageHeaderParserImageType>(_members.StaticFields.GetObjectValue("GIF.Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("JPEG")]
	public static ImageHeaderParserImageType? Jpeg => Java.Lang.Object.GetObject<ImageHeaderParserImageType>(_members.StaticFields.GetObjectValue("JPEG.Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PNG")]
	public static ImageHeaderParserImageType? Png => Java.Lang.Object.GetObject<ImageHeaderParserImageType>(_members.StaticFields.GetObjectValue("PNG.Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PNG_A")]
	public static ImageHeaderParserImageType? PngA => Java.Lang.Object.GetObject<ImageHeaderParserImageType>(_members.StaticFields.GetObjectValue("PNG_A.Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("RAW")]
	public static ImageHeaderParserImageType? Raw => Java.Lang.Object.GetObject<ImageHeaderParserImageType>(_members.StaticFields.GetObjectValue("RAW.Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("UNKNOWN")]
	public static ImageHeaderParserImageType? Unknown => Java.Lang.Object.GetObject<ImageHeaderParserImageType>(_members.StaticFields.GetObjectValue("UNKNOWN.Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("WEBP")]
	public static ImageHeaderParserImageType? Webp => Java.Lang.Object.GetObject<ImageHeaderParserImageType>(_members.StaticFields.GetObjectValue("WEBP.Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("WEBP_A")]
	public static ImageHeaderParserImageType? WebpA => Java.Lang.Object.GetObject<ImageHeaderParserImageType>(_members.StaticFields.GetObjectValue("WEBP_A.Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe bool HasAlpha
	{
		[Register("hasAlpha", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasAlpha.()Z", this, null);
		}
	}

	public unsafe bool IsWebp
	{
		[Register("isWebp", "()Z", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isWebp.()Z", this, null);
		}
	}

	internal ImageHeaderParserImageType(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;", "")]
	public unsafe static ImageHeaderParserImageType? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ImageHeaderParserImageType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;", "")]
	public unsafe static ImageHeaderParserImageType[]? Values()
	{
		return (ImageHeaderParserImageType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/bumptech/glide/load/ImageHeaderParser$ImageType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ImageHeaderParserImageType));
	}
}
