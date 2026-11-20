using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Google.Zxing.Qrcode.Decoder;

[Register("com/google/zxing/qrcode/decoder/ErrorCorrectionLevel", DoNotGenerateAcw = true)]
public sealed class ErrorCorrectionLevel : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/qrcode/decoder/ErrorCorrectionLevel", typeof(ErrorCorrectionLevel));

	[Register("H")]
	public static ErrorCorrectionLevel? H => Java.Lang.Object.GetObject<ErrorCorrectionLevel>(_members.StaticFields.GetObjectValue("H.Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("L")]
	public static ErrorCorrectionLevel? L => Java.Lang.Object.GetObject<ErrorCorrectionLevel>(_members.StaticFields.GetObjectValue("L.Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("M")]
	public static ErrorCorrectionLevel? M => Java.Lang.Object.GetObject<ErrorCorrectionLevel>(_members.StaticFields.GetObjectValue("M.Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("Q")]
	public static ErrorCorrectionLevel? Q => Java.Lang.Object.GetObject<ErrorCorrectionLevel>(_members.StaticFields.GetObjectValue("Q.Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe int Bits
	{
		[Register("getBits", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getBits.()I", this, null);
		}
	}

	internal ErrorCorrectionLevel(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("forBits", "(I)Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;", "")]
	public unsafe static ErrorCorrectionLevel? ForBits(int bits)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(bits);
		return Java.Lang.Object.GetObject<ErrorCorrectionLevel>(_members.StaticMethods.InvokeObjectMethod("forBits.(I)Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;", "")]
	public unsafe static ErrorCorrectionLevel? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ErrorCorrectionLevel>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;", "")]
	public unsafe static ErrorCorrectionLevel[]? Values()
	{
		return (ErrorCorrectionLevel[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/zxing/qrcode/decoder/ErrorCorrectionLevel;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ErrorCorrectionLevel));
	}
}
