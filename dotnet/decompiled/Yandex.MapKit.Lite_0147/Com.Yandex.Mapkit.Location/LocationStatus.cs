using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/LocationStatus", DoNotGenerateAcw = true)]
public sealed class LocationStatus : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/location/LocationStatus", typeof(LocationStatus));

	[Register("AVAILABLE")]
	public static LocationStatus? Available => Java.Lang.Object.GetObject<LocationStatus>(_members.StaticFields.GetObjectValue("AVAILABLE.Lcom/yandex/mapkit/location/LocationStatus;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("NOT_AVAILABLE")]
	public static LocationStatus? NotAvailable => Java.Lang.Object.GetObject<LocationStatus>(_members.StaticFields.GetObjectValue("NOT_AVAILABLE.Lcom/yandex/mapkit/location/LocationStatus;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("RESET")]
	public static LocationStatus? Reset => Java.Lang.Object.GetObject<LocationStatus>(_members.StaticFields.GetObjectValue("RESET.Lcom/yandex/mapkit/location/LocationStatus;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal LocationStatus(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/location/LocationStatus;", "")]
	public unsafe static LocationStatus? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<LocationStatus>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/location/LocationStatus;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/location/LocationStatus;", "")]
	public unsafe static LocationStatus[]? Values()
	{
		return (LocationStatus[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/location/LocationStatus;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(LocationStatus));
	}
}
