using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/AdType", DoNotGenerateAcw = true)]
public sealed class AdType : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/AdType", typeof(AdType));

	[Register("APP_OPEN")]
	public static AdType? AppOpen => Java.Lang.Object.GetObject<AdType>(_members.StaticFields.GetObjectValue("APP_OPEN.Lio/appmetrica/analytics/AdType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("BANNER")]
	public static AdType? Banner => Java.Lang.Object.GetObject<AdType>(_members.StaticFields.GetObjectValue("BANNER.Lio/appmetrica/analytics/AdType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("INTERSTITIAL")]
	public static AdType? Interstitial => Java.Lang.Object.GetObject<AdType>(_members.StaticFields.GetObjectValue("INTERSTITIAL.Lio/appmetrica/analytics/AdType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("MREC")]
	public static AdType? Mrec => Java.Lang.Object.GetObject<AdType>(_members.StaticFields.GetObjectValue("MREC.Lio/appmetrica/analytics/AdType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("NATIVE")]
	public static AdType? Native => Java.Lang.Object.GetObject<AdType>(_members.StaticFields.GetObjectValue("NATIVE.Lio/appmetrica/analytics/AdType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OTHER")]
	public static AdType? Other => Java.Lang.Object.GetObject<AdType>(_members.StaticFields.GetObjectValue("OTHER.Lio/appmetrica/analytics/AdType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("REWARDED")]
	public static AdType? Rewarded => Java.Lang.Object.GetObject<AdType>(_members.StaticFields.GetObjectValue("REWARDED.Lio/appmetrica/analytics/AdType;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal AdType(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lio/appmetrica/analytics/AdType;", "")]
	public unsafe static AdType? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<AdType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lio/appmetrica/analytics/AdType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lio/appmetrica/analytics/AdType;", "")]
	public unsafe static AdType[]? Values()
	{
		return (AdType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lio/appmetrica/analytics/AdType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(AdType));
	}
}
