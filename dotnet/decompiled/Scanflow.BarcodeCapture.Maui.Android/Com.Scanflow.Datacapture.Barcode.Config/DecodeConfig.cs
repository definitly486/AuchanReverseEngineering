using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Enums;

namespace Com.Scanflow.Datacapture.Barcode.Config;

[Register("com/scanflow/datacapture/barcode/config/DecodeConfig", DoNotGenerateAcw = true)]
public sealed class DecodeConfig : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/barcode/config/DecodeConfig", typeof(DecodeConfig));

	[Register("ANY")]
	public static DecodeConfig? Any => Java.Lang.Object.GetObject<DecodeConfig>(_members.StaticFields.GetObjectValue("ANY.Lcom/scanflow/datacapture/barcode/config/DecodeConfig;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("BARCODE")]
	public static DecodeConfig? Barcode => Java.Lang.Object.GetObject<DecodeConfig>(_members.StaticFields.GetObjectValue("BARCODE.Lcom/scanflow/datacapture/barcode/config/DecodeConfig;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("BATCH_INVENTORY")]
	public static DecodeConfig? BatchInventory => Java.Lang.Object.GetObject<DecodeConfig>(_members.StaticFields.GetObjectValue("BATCH_INVENTORY.Lcom/scanflow/datacapture/barcode/config/DecodeConfig;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("DOTMATRIX_METAL")]
	public static DecodeConfig? DotmatrixMetal => Java.Lang.Object.GetObject<DecodeConfig>(_members.StaticFields.GetObjectValue("DOTMATRIX_METAL.Lcom/scanflow/datacapture/barcode/config/DecodeConfig;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("DOTMATRIX_WHITE")]
	public static DecodeConfig? DotmatrixWhite => Java.Lang.Object.GetObject<DecodeConfig>(_members.StaticFields.GetObjectValue("DOTMATRIX_WHITE.Lcom/scanflow/datacapture/barcode/config/DecodeConfig;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("ONE_OF_MANY")]
	public static DecodeConfig? OneOfMany => Java.Lang.Object.GetObject<DecodeConfig>(_members.StaticFields.GetObjectValue("ONE_OF_MANY.Lcom/scanflow/datacapture/barcode/config/DecodeConfig;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PIVOT_VIEW")]
	public static DecodeConfig? PivotView => Java.Lang.Object.GetObject<DecodeConfig>(_members.StaticFields.GetObjectValue("PIVOT_VIEW.Lcom/scanflow/datacapture/barcode/config/DecodeConfig;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("QRCODE")]
	public static DecodeConfig? Qrcode => Java.Lang.Object.GetObject<DecodeConfig>(_members.StaticFields.GetObjectValue("QRCODE.Lcom/scanflow/datacapture/barcode/config/DecodeConfig;").Handle, JniHandleOwnership.TransferLocalRef);

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

	public unsafe static IEnumEntries Entries
	{
		[Register("getEntries", "()Lkotlin/enums/EnumEntries;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IEnumEntries>(_members.StaticMethods.InvokeObjectMethod("getEntries.()Lkotlin/enums/EnumEntries;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal DecodeConfig(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/scanflow/datacapture/barcode/config/DecodeConfig;", "")]
	public unsafe static DecodeConfig? ValueOf(string? p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<DecodeConfig>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/scanflow/datacapture/barcode/config/DecodeConfig;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/scanflow/datacapture/barcode/config/DecodeConfig;", "")]
	public unsafe static DecodeConfig[]? Values()
	{
		return (DecodeConfig[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/scanflow/datacapture/barcode/config/DecodeConfig;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(DecodeConfig));
	}
}
