using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Google.Zxing.Pdf417.Encoder;

[Register("com/google/zxing/pdf417/encoder/Compaction", DoNotGenerateAcw = true)]
public sealed class Compaction : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/pdf417/encoder/Compaction", typeof(Compaction));

	[Register("AUTO")]
	public static Compaction? Auto => Java.Lang.Object.GetObject<Compaction>(_members.StaticFields.GetObjectValue("AUTO.Lcom/google/zxing/pdf417/encoder/Compaction;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("BYTE")]
	public static Compaction? Byte => Java.Lang.Object.GetObject<Compaction>(_members.StaticFields.GetObjectValue("BYTE.Lcom/google/zxing/pdf417/encoder/Compaction;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("NUMERIC")]
	public static Compaction? Numeric => Java.Lang.Object.GetObject<Compaction>(_members.StaticFields.GetObjectValue("NUMERIC.Lcom/google/zxing/pdf417/encoder/Compaction;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("TEXT")]
	public static Compaction? Text => Java.Lang.Object.GetObject<Compaction>(_members.StaticFields.GetObjectValue("TEXT.Lcom/google/zxing/pdf417/encoder/Compaction;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal Compaction(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/google/zxing/pdf417/encoder/Compaction;", "")]
	public unsafe static Compaction? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Compaction>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/zxing/pdf417/encoder/Compaction;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/google/zxing/pdf417/encoder/Compaction;", "")]
	public unsafe static Compaction[]? Values()
	{
		return (Compaction[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/zxing/pdf417/encoder/Compaction;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Compaction));
	}
}
