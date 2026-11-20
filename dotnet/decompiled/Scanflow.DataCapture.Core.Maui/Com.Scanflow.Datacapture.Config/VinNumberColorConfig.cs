using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Enums;

namespace Com.Scanflow.Datacapture.Config;

[Register("com/scanflow/datacapture/config/VinNumberColorConfig", DoNotGenerateAcw = true)]
public sealed class VinNumberColorConfig : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/scanflow/datacapture/config/VinNumberColorConfig", typeof(VinNumberColorConfig));

	[Register("BLACK")]
	public static VinNumberColorConfig Black => Java.Lang.Object.GetObject<VinNumberColorConfig>(_members.StaticFields.GetObjectValue("BLACK.Lcom/scanflow/datacapture/config/VinNumberColorConfig;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("SILVER")]
	public static VinNumberColorConfig Silver => Java.Lang.Object.GetObject<VinNumberColorConfig>(_members.StaticFields.GetObjectValue("SILVER.Lcom/scanflow/datacapture/config/VinNumberColorConfig;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal VinNumberColorConfig(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/scanflow/datacapture/config/VinNumberColorConfig;", "")]
	public unsafe static VinNumberColorConfig ValueOf(string p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<VinNumberColorConfig>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/scanflow/datacapture/config/VinNumberColorConfig;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/scanflow/datacapture/config/VinNumberColorConfig;", "")]
	public unsafe static VinNumberColorConfig[] Values()
	{
		return (VinNumberColorConfig[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/scanflow/datacapture/config/VinNumberColorConfig;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(VinNumberColorConfig));
	}
}
