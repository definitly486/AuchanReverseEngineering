using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load;

[Register("com/bumptech/glide/load/EncodeStrategy", DoNotGenerateAcw = true)]
public sealed class EncodeStrategy : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/load/EncodeStrategy", typeof(EncodeStrategy));

	[Register("NONE")]
	public static EncodeStrategy? None => Java.Lang.Object.GetObject<EncodeStrategy>(_members.StaticFields.GetObjectValue("NONE.Lcom/bumptech/glide/load/EncodeStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("SOURCE")]
	public static EncodeStrategy? Source => Java.Lang.Object.GetObject<EncodeStrategy>(_members.StaticFields.GetObjectValue("SOURCE.Lcom/bumptech/glide/load/EncodeStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("TRANSFORMED")]
	public static EncodeStrategy? Transformed => Java.Lang.Object.GetObject<EncodeStrategy>(_members.StaticFields.GetObjectValue("TRANSFORMED.Lcom/bumptech/glide/load/EncodeStrategy;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal EncodeStrategy(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/bumptech/glide/load/EncodeStrategy;", "")]
	public unsafe static EncodeStrategy? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<EncodeStrategy>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/bumptech/glide/load/EncodeStrategy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/bumptech/glide/load/EncodeStrategy;", "")]
	public unsafe static EncodeStrategy[]? Values()
	{
		return (EncodeStrategy[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/bumptech/glide/load/EncodeStrategy;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(EncodeStrategy));
	}
}
