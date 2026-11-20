using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/CameraUpdateReason", DoNotGenerateAcw = true)]
public sealed class CameraUpdateReason : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/CameraUpdateReason", typeof(CameraUpdateReason));

	[Register("APPLICATION")]
	public static CameraUpdateReason? Application => Java.Lang.Object.GetObject<CameraUpdateReason>(_members.StaticFields.GetObjectValue("APPLICATION.Lcom/yandex/mapkit/map/CameraUpdateReason;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("GESTURES")]
	public static CameraUpdateReason? Gestures => Java.Lang.Object.GetObject<CameraUpdateReason>(_members.StaticFields.GetObjectValue("GESTURES.Lcom/yandex/mapkit/map/CameraUpdateReason;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal CameraUpdateReason(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/map/CameraUpdateReason;", "")]
	public unsafe static CameraUpdateReason? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<CameraUpdateReason>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/map/CameraUpdateReason;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/map/CameraUpdateReason;", "")]
	public unsafe static CameraUpdateReason[]? Values()
	{
		return (CameraUpdateReason[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/map/CameraUpdateReason;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(CameraUpdateReason));
	}
}
