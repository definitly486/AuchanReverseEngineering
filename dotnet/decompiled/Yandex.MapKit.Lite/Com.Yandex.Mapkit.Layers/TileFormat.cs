using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/TileFormat", DoNotGenerateAcw = true)]
public sealed class TileFormat : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/layers/TileFormat", typeof(TileFormat));

	[Register("GEO_JSON")]
	public static TileFormat? GeoJson => Java.Lang.Object.GetObject<TileFormat>(_members.StaticFields.GetObjectValue("GEO_JSON.Lcom/yandex/mapkit/layers/TileFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("JPG")]
	public static TileFormat? Jpg => Java.Lang.Object.GetObject<TileFormat>(_members.StaticFields.GetObjectValue("JPG.Lcom/yandex/mapkit/layers/TileFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PNG")]
	public static TileFormat? Png => Java.Lang.Object.GetObject<TileFormat>(_members.StaticFields.GetObjectValue("PNG.Lcom/yandex/mapkit/layers/TileFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("VECTOR2")]
	public static TileFormat? Vector2 => Java.Lang.Object.GetObject<TileFormat>(_members.StaticFields.GetObjectValue("VECTOR2.Lcom/yandex/mapkit/layers/TileFormat;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("VECTOR3")]
	public static TileFormat? Vector3 => Java.Lang.Object.GetObject<TileFormat>(_members.StaticFields.GetObjectValue("VECTOR3.Lcom/yandex/mapkit/layers/TileFormat;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal TileFormat(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/layers/TileFormat;", "")]
	public unsafe static TileFormat? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<TileFormat>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/layers/TileFormat;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/layers/TileFormat;", "")]
	public unsafe static TileFormat[]? Values()
	{
		return (TileFormat[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/layers/TileFormat;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(TileFormat));
	}
}
