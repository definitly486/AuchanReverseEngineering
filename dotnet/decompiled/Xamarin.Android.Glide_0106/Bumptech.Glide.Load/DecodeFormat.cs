using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load;

[Register("com/bumptech/glide/load/DecodeFormat", DoNotGenerateAcw = true)]
public sealed class DecodeFormat : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/DecodeFormat", typeof(DecodeFormat));

	[Register("DEFAULT")]
	public static DecodeFormat? Default => Java.Lang.Object.GetObject<DecodeFormat>(_members.StaticFields.GetObjectValue("DEFAULT.Lcom/bumptech/glide/load/DecodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PREFER_ARGB_8888")]
	public static DecodeFormat? PreferArgb8888 => Java.Lang.Object.GetObject<DecodeFormat>(_members.StaticFields.GetObjectValue("PREFER_ARGB_8888.Lcom/bumptech/glide/load/DecodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PREFER_RGB_565")]
	public static DecodeFormat? PreferRgb565 => Java.Lang.Object.GetObject<DecodeFormat>(_members.StaticFields.GetObjectValue("PREFER_RGB_565.Lcom/bumptech/glide/load/DecodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal DecodeFormat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/bumptech/glide/load/DecodeFormat;", "")]
	public unsafe static DecodeFormat? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<DecodeFormat>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/bumptech/glide/load/DecodeFormat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/bumptech/glide/load/DecodeFormat;", "")]
	public unsafe static DecodeFormat[]? Values()
	{
		return (DecodeFormat[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/bumptech/glide/load/DecodeFormat;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(DecodeFormat));
	}
}
