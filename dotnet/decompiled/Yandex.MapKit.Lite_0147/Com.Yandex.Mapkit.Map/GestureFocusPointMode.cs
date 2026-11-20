using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/GestureFocusPointMode", DoNotGenerateAcw = true)]
public sealed class GestureFocusPointMode : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/GestureFocusPointMode", typeof(GestureFocusPointMode));

	[Register("AFFECTS_ALL_GESTURES")]
	public static GestureFocusPointMode? AffectsAllGestures => Java.Lang.Object.GetObject<GestureFocusPointMode>(_members.StaticFields.GetObjectValue("AFFECTS_ALL_GESTURES.Lcom/yandex/mapkit/map/GestureFocusPointMode;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("AFFECTS_TAP_GESTURES")]
	public static GestureFocusPointMode? AffectsTapGestures => Java.Lang.Object.GetObject<GestureFocusPointMode>(_members.StaticFields.GetObjectValue("AFFECTS_TAP_GESTURES.Lcom/yandex/mapkit/map/GestureFocusPointMode;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal GestureFocusPointMode(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/map/GestureFocusPointMode;", "")]
	public unsafe static GestureFocusPointMode? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<GestureFocusPointMode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/map/GestureFocusPointMode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/map/GestureFocusPointMode;", "")]
	public unsafe static GestureFocusPointMode[]? Values()
	{
		return (GestureFocusPointMode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/map/GestureFocusPointMode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(GestureFocusPointMode));
	}
}
