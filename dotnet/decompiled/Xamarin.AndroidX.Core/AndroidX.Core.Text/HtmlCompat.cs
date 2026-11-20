using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Text;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.Text;

[Register("androidx/core/text/HtmlCompat", DoNotGenerateAcw = true)]
public sealed class HtmlCompat : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/text/HtmlCompat", typeof(HtmlCompat));

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

	internal HtmlCompat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("fromHtml", "(Ljava/lang/String;I)Landroid/text/Spanned;", "")]
	public unsafe static ISpanned? FromHtml(string? source, int flags)
	{
		nint num = JNIEnv.NewString(source);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(flags);
			return Java.Lang.Object.GetObject<ISpanned>(_members.StaticMethods.InvokeObjectMethod("fromHtml.(Ljava/lang/String;I)Landroid/text/Spanned;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("fromHtml", "(Ljava/lang/String;ILandroid/text/Html$ImageGetter;Landroid/text/Html$TagHandler;)Landroid/text/Spanned;", "")]
	public unsafe static ISpanned? FromHtml(string? source, int flags, Html.IImageGetter? imageGetter, Html.ITagHandler? tagHandler)
	{
		nint num = JNIEnv.NewString(source);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(flags);
			ptr[2] = new JniArgumentValue((imageGetter == null) ? IntPtr.Zero : ((Java.Lang.Object)imageGetter).Handle);
			ptr[3] = new JniArgumentValue((tagHandler == null) ? IntPtr.Zero : ((Java.Lang.Object)tagHandler).Handle);
			return Java.Lang.Object.GetObject<ISpanned>(_members.StaticMethods.InvokeObjectMethod("fromHtml.(Ljava/lang/String;ILandroid/text/Html$ImageGetter;Landroid/text/Html$TagHandler;)Landroid/text/Spanned;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(imageGetter);
			GC.KeepAlive(tagHandler);
		}
	}

	[Register("toHtml", "(Landroid/text/Spanned;I)Ljava/lang/String;", "")]
	public unsafe static string? ToHtml(ISpanned? text, int options)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((text == null) ? IntPtr.Zero : ((Java.Lang.Object)text).Handle);
			ptr[1] = new JniArgumentValue(options);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("toHtml.(Landroid/text/Spanned;I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(text);
		}
	}
}
