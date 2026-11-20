using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/StartupParamsItemStatus", DoNotGenerateAcw = true)]
public sealed class StartupParamsItemStatus : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/StartupParamsItemStatus", typeof(StartupParamsItemStatus));

	[Register("FEATURE_DISABLED")]
	public static StartupParamsItemStatus? FeatureDisabled => Java.Lang.Object.GetObject<StartupParamsItemStatus>(_members.StaticFields.GetObjectValue("FEATURE_DISABLED.Lio/appmetrica/analytics/StartupParamsItemStatus;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("FORBIDDEN_BY_CLIENT_CONFIG")]
	public static StartupParamsItemStatus? ForbiddenByClientConfig => Java.Lang.Object.GetObject<StartupParamsItemStatus>(_members.StaticFields.GetObjectValue("FORBIDDEN_BY_CLIENT_CONFIG.Lio/appmetrica/analytics/StartupParamsItemStatus;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("INVALID_VALUE_FROM_PROVIDER")]
	public static StartupParamsItemStatus? InvalidValueFromProvider => Java.Lang.Object.GetObject<StartupParamsItemStatus>(_members.StaticFields.GetObjectValue("INVALID_VALUE_FROM_PROVIDER.Lio/appmetrica/analytics/StartupParamsItemStatus;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OK")]
	public static StartupParamsItemStatus? Ok => Java.Lang.Object.GetObject<StartupParamsItemStatus>(_members.StaticFields.GetObjectValue("OK.Lio/appmetrica/analytics/StartupParamsItemStatus;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PROVIDER_UNAVAILABLE")]
	public static StartupParamsItemStatus? ProviderUnavailable => Java.Lang.Object.GetObject<StartupParamsItemStatus>(_members.StaticFields.GetObjectValue("PROVIDER_UNAVAILABLE.Lio/appmetrica/analytics/StartupParamsItemStatus;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("UNKNOWN_ERROR")]
	public static StartupParamsItemStatus? UnknownError => Java.Lang.Object.GetObject<StartupParamsItemStatus>(_members.StaticFields.GetObjectValue("UNKNOWN_ERROR.Lio/appmetrica/analytics/StartupParamsItemStatus;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal StartupParamsItemStatus(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lio/appmetrica/analytics/StartupParamsItemStatus;", "")]
	public unsafe static StartupParamsItemStatus? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<StartupParamsItemStatus>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lio/appmetrica/analytics/StartupParamsItemStatus;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lio/appmetrica/analytics/StartupParamsItemStatus;", "")]
	public unsafe static StartupParamsItemStatus[]? Values()
	{
		return (StartupParamsItemStatus[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lio/appmetrica/analytics/StartupParamsItemStatus;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(StartupParamsItemStatus));
	}
}
