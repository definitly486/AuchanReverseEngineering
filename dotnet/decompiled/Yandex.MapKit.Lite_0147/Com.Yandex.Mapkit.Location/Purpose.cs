using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/Purpose", DoNotGenerateAcw = true)]
public sealed class Purpose : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/location/Purpose", typeof(Purpose));

	[Register("AUTOMOTIVE_NAVIGATION")]
	public static Purpose? AutomotiveNavigation => Java.Lang.Object.GetObject<Purpose>(_members.StaticFields.GetObjectValue("AUTOMOTIVE_NAVIGATION.Lcom/yandex/mapkit/location/Purpose;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("BICYCLE_NAVIGATION")]
	public static Purpose? BicycleNavigation => Java.Lang.Object.GetObject<Purpose>(_members.StaticFields.GetObjectValue("BICYCLE_NAVIGATION.Lcom/yandex/mapkit/location/Purpose;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("GENERAL")]
	public static Purpose? General => Java.Lang.Object.GetObject<Purpose>(_members.StaticFields.GetObjectValue("GENERAL.Lcom/yandex/mapkit/location/Purpose;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PEDESTRIAN_NAVIGATION")]
	public static Purpose? PedestrianNavigation => Java.Lang.Object.GetObject<Purpose>(_members.StaticFields.GetObjectValue("PEDESTRIAN_NAVIGATION.Lcom/yandex/mapkit/location/Purpose;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("SCOOTER_NAVIGATION")]
	public static Purpose? ScooterNavigation => Java.Lang.Object.GetObject<Purpose>(_members.StaticFields.GetObjectValue("SCOOTER_NAVIGATION.Lcom/yandex/mapkit/location/Purpose;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("STATIC_DISPLAY_LOCATION")]
	public static Purpose? StaticDisplayLocation => Java.Lang.Object.GetObject<Purpose>(_members.StaticFields.GetObjectValue("STATIC_DISPLAY_LOCATION.Lcom/yandex/mapkit/location/Purpose;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal Purpose(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/location/Purpose;", "")]
	public unsafe static Purpose? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Purpose>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/location/Purpose;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/location/Purpose;", "")]
	public unsafe static Purpose[]? Values()
	{
		return (Purpose[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/location/Purpose;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Purpose));
	}
}
