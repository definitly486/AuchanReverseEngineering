using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapType", DoNotGenerateAcw = true)]
public sealed class MapType : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/MapType", typeof(MapType));

	[Register("HYBRID")]
	public static MapType? Hybrid => Java.Lang.Object.GetObject<MapType>(_members.StaticFields.GetObjectValue("HYBRID.Lcom/yandex/mapkit/map/MapType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("MAP")]
	public static MapType? Map => Java.Lang.Object.GetObject<MapType>(_members.StaticFields.GetObjectValue("MAP.Lcom/yandex/mapkit/map/MapType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("NONE")]
	public static MapType? None => Java.Lang.Object.GetObject<MapType>(_members.StaticFields.GetObjectValue("NONE.Lcom/yandex/mapkit/map/MapType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("SATELLITE")]
	public static MapType? Satellite => Java.Lang.Object.GetObject<MapType>(_members.StaticFields.GetObjectValue("SATELLITE.Lcom/yandex/mapkit/map/MapType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("VECTOR_MAP")]
	public static MapType? VectorMap => Java.Lang.Object.GetObject<MapType>(_members.StaticFields.GetObjectValue("VECTOR_MAP.Lcom/yandex/mapkit/map/MapType;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal MapType(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/map/MapType;", "")]
	public unsafe static MapType? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<MapType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/map/MapType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/map/MapType;", "")]
	public unsafe static MapType[]? Values()
	{
		return (MapType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/map/MapType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(MapType));
	}
}
