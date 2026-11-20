using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapMode", DoNotGenerateAcw = true)]
public sealed class MapMode : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/MapMode", typeof(MapMode));

	[Register("ADMIN")]
	public static MapMode? Admin => Java.Lang.Object.GetObject<MapMode>(_members.StaticFields.GetObjectValue("ADMIN.Lcom/yandex/mapkit/map/MapMode;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("DRIVING")]
	public static MapMode? Driving => Java.Lang.Object.GetObject<MapMode>(_members.StaticFields.GetObjectValue("DRIVING.Lcom/yandex/mapkit/map/MapMode;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("FUTURE_MAP")]
	public static MapMode? FutureMap => Java.Lang.Object.GetObject<MapMode>(_members.StaticFields.GetObjectValue("FUTURE_MAP.Lcom/yandex/mapkit/map/MapMode;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("LEGACY_MAP")]
	public static MapMode? LegacyMap => Java.Lang.Object.GetObject<MapMode>(_members.StaticFields.GetObjectValue("LEGACY_MAP.Lcom/yandex/mapkit/map/MapMode;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("MAP")]
	public static MapMode? Map => Java.Lang.Object.GetObject<MapMode>(_members.StaticFields.GetObjectValue("MAP.Lcom/yandex/mapkit/map/MapMode;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("TRANSIT")]
	public static MapMode? Transit => Java.Lang.Object.GetObject<MapMode>(_members.StaticFields.GetObjectValue("TRANSIT.Lcom/yandex/mapkit/map/MapMode;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal MapMode(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/map/MapMode;", "")]
	public unsafe static MapMode? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<MapMode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/map/MapMode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/map/MapMode;", "")]
	public unsafe static MapMode[]? Values()
	{
		return (MapMode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/map/MapMode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(MapMode));
	}
}
