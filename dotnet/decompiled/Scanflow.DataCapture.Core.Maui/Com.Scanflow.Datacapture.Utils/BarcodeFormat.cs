using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Scanflow.Datacapture.Utils;

[Register("com/scanflow/datacapture/utils/BarcodeFormat", DoNotGenerateAcw = true)]
public sealed class BarcodeFormat : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/utils/BarcodeFormat", typeof(BarcodeFormat));

	[Register("AZTEC")]
	public static BarcodeFormat Aztec => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("AZTEC.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("CODABAR")]
	public static BarcodeFormat Codabar => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("CODABAR.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("CODE_128")]
	public static BarcodeFormat Code128 => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("CODE_128.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("CODE_39")]
	public static BarcodeFormat Code39 => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("CODE_39.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("CODE_93")]
	public static BarcodeFormat Code93 => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("CODE_93.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("DATA_MATRIX")]
	public static BarcodeFormat DataMatrix => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("DATA_MATRIX.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("EAN_13")]
	public static BarcodeFormat Ean13 => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("EAN_13.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("EAN_8")]
	public static BarcodeFormat Ean8 => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("EAN_8.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("ITF")]
	public static BarcodeFormat Itf => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("ITF.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("MAXICODE")]
	public static BarcodeFormat Maxicode => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("MAXICODE.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PDF_417")]
	public static BarcodeFormat Pdf417 => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("PDF_417.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("QR_CODE")]
	public static BarcodeFormat QrCode => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("QR_CODE.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("RSS_14")]
	public static BarcodeFormat Rss14 => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("RSS_14.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("RSS_EXPANDED")]
	public static BarcodeFormat RssExpanded => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("RSS_EXPANDED.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("UPC_A")]
	public static BarcodeFormat UpcA => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("UPC_A.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("UPC_E")]
	public static BarcodeFormat UpcE => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("UPC_E.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("UPC_EAN_EXTENSION")]
	public static BarcodeFormat UpcEanExtension => Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticFields.GetObjectValue("UPC_EAN_EXTENSION.Lcom/scanflow/datacapture/utils/BarcodeFormat;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal BarcodeFormat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/scanflow/datacapture/utils/BarcodeFormat;", "")]
	public unsafe static BarcodeFormat ValueOf(string p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<BarcodeFormat>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/scanflow/datacapture/utils/BarcodeFormat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/scanflow/datacapture/utils/BarcodeFormat;", "")]
	public unsafe static BarcodeFormat[] Values()
	{
		return (BarcodeFormat[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/scanflow/datacapture/utils/BarcodeFormat;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(BarcodeFormat));
	}
}
