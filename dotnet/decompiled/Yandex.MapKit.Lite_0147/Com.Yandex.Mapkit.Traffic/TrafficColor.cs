using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Traffic;

[Register("com/yandex/mapkit/traffic/TrafficColor", DoNotGenerateAcw = true)]
public sealed class TrafficColor : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/traffic/TrafficColor", typeof(TrafficColor));

	[Register("GREEN")]
	public static TrafficColor? Green => Java.Lang.Object.GetObject<TrafficColor>(_members.StaticFields.GetObjectValue("GREEN.Lcom/yandex/mapkit/traffic/TrafficColor;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("RED")]
	public static TrafficColor? Red => Java.Lang.Object.GetObject<TrafficColor>(_members.StaticFields.GetObjectValue("RED.Lcom/yandex/mapkit/traffic/TrafficColor;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("YELLOW")]
	public static TrafficColor? Yellow => Java.Lang.Object.GetObject<TrafficColor>(_members.StaticFields.GetObjectValue("YELLOW.Lcom/yandex/mapkit/traffic/TrafficColor;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal TrafficColor(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/traffic/TrafficColor;", "")]
	public unsafe static TrafficColor? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<TrafficColor>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/traffic/TrafficColor;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/traffic/TrafficColor;", "")]
	public unsafe static TrafficColor[]? Values()
	{
		return (TrafficColor[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/traffic/TrafficColor;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(TrafficColor));
	}
}
