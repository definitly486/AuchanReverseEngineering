using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Google.Zxing;

[Register("com/google/zxing/EncodeHintType", DoNotGenerateAcw = true)]
public sealed class EncodeHintType : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/zxing/EncodeHintType", typeof(EncodeHintType));

	[Register("AZTEC_LAYERS")]
	public static EncodeHintType? AztecLayers => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("AZTEC_LAYERS.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("CHARACTER_SET")]
	public static EncodeHintType? CharacterSet => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("CHARACTER_SET.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("CODE128_COMPACT")]
	public static EncodeHintType? Code128Compact => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("CODE128_COMPACT.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("DATA_MATRIX_COMPACT")]
	public static EncodeHintType? DataMatrixCompact => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("DATA_MATRIX_COMPACT.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("DATA_MATRIX_SHAPE")]
	public static EncodeHintType? DataMatrixShape => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("DATA_MATRIX_SHAPE.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("ERROR_CORRECTION")]
	public static EncodeHintType? ErrorCorrection => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("ERROR_CORRECTION.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("FORCE_C40")]
	public static EncodeHintType? ForceC40 => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("FORCE_C40.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("FORCE_CODE_SET")]
	public static EncodeHintType? ForceCodeSet => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("FORCE_CODE_SET.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("GS1_FORMAT")]
	public static EncodeHintType? Gs1Format => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("GS1_FORMAT.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("MARGIN")]
	public static EncodeHintType? Margin => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("MARGIN.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("MAX_SIZE")]
	[Obsolete("deprecated")]
	public static EncodeHintType? MaxSize => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("MAX_SIZE.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("MIN_SIZE")]
	[Obsolete("deprecated")]
	public static EncodeHintType? MinSize => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("MIN_SIZE.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PDF417_AUTO_ECI")]
	public static EncodeHintType? Pdf417AutoEci => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("PDF417_AUTO_ECI.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PDF417_COMPACT")]
	public static EncodeHintType? Pdf417Compact => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("PDF417_COMPACT.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PDF417_COMPACTION")]
	public static EncodeHintType? Pdf417Compaction => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("PDF417_COMPACTION.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PDF417_DIMENSIONS")]
	public static EncodeHintType? Pdf417Dimensions => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("PDF417_DIMENSIONS.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("QR_COMPACT")]
	public static EncodeHintType? QrCompact => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("QR_COMPACT.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("QR_MASK_PATTERN")]
	public static EncodeHintType? QrMaskPattern => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("QR_MASK_PATTERN.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("QR_VERSION")]
	public static EncodeHintType? QrVersion => Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticFields.GetObjectValue("QR_VERSION.Lcom/google/zxing/EncodeHintType;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal EncodeHintType(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/google/zxing/EncodeHintType;", "")]
	public unsafe static EncodeHintType? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<EncodeHintType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/google/zxing/EncodeHintType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/google/zxing/EncodeHintType;", "")]
	public unsafe static EncodeHintType[]? Values()
	{
		return (EncodeHintType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/google/zxing/EncodeHintType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(EncodeHintType));
	}
}
