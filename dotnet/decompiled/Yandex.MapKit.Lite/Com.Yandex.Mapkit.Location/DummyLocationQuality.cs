using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/DummyLocationQuality", DoNotGenerateAcw = true)]
public sealed class DummyLocationQuality : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/location/DummyLocationQuality", typeof(DummyLocationQuality));

	[Register("HIGH")]
	public static DummyLocationQuality? High => Java.Lang.Object.GetObject<DummyLocationQuality>(_members.StaticFields.GetObjectValue("HIGH.Lcom/yandex/mapkit/location/DummyLocationQuality;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("LOW")]
	public static DummyLocationQuality? Low => Java.Lang.Object.GetObject<DummyLocationQuality>(_members.StaticFields.GetObjectValue("LOW.Lcom/yandex/mapkit/location/DummyLocationQuality;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal DummyLocationQuality(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/location/DummyLocationQuality;", "")]
	public unsafe static DummyLocationQuality? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<DummyLocationQuality>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/location/DummyLocationQuality;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/location/DummyLocationQuality;", "")]
	public unsafe static DummyLocationQuality[]? Values()
	{
		return (DummyLocationQuality[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/location/DummyLocationQuality;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(DummyLocationQuality));
	}
}
