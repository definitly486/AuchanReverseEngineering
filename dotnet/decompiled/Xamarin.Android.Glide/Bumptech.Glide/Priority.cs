using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide;

[Register("com/bumptech/glide/Priority", DoNotGenerateAcw = true)]
public sealed class Priority : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/Priority", typeof(Priority));

	[Register("HIGH")]
	public static Priority? High => Java.Lang.Object.GetObject<Priority>(_members.StaticFields.GetObjectValue("HIGH.Lcom/bumptech/glide/Priority;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("IMMEDIATE")]
	public static Priority? Immediate => Java.Lang.Object.GetObject<Priority>(_members.StaticFields.GetObjectValue("IMMEDIATE.Lcom/bumptech/glide/Priority;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("LOW")]
	public static Priority? Low => Java.Lang.Object.GetObject<Priority>(_members.StaticFields.GetObjectValue("LOW.Lcom/bumptech/glide/Priority;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("NORMAL")]
	public static Priority? Normal => Java.Lang.Object.GetObject<Priority>(_members.StaticFields.GetObjectValue("NORMAL.Lcom/bumptech/glide/Priority;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal Priority(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/bumptech/glide/Priority;", "")]
	public unsafe static Priority? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Priority>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/bumptech/glide/Priority;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/bumptech/glide/Priority;", "")]
	public unsafe static Priority[]? Values()
	{
		return (Priority[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/bumptech/glide/Priority;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Priority));
	}
}
