using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PointOfView", DoNotGenerateAcw = true)]
public sealed class PointOfView : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/PointOfView", typeof(PointOfView));

	[Register("ADAPT_TO_FOCUS_POINT_HORIZONTALLY")]
	public static PointOfView? AdaptToFocusPointHorizontally => Java.Lang.Object.GetObject<PointOfView>(_members.StaticFields.GetObjectValue("ADAPT_TO_FOCUS_POINT_HORIZONTALLY.Lcom/yandex/mapkit/map/PointOfView;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("SCREEN_CENTER")]
	public static PointOfView? ScreenCenter => Java.Lang.Object.GetObject<PointOfView>(_members.StaticFields.GetObjectValue("SCREEN_CENTER.Lcom/yandex/mapkit/map/PointOfView;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal PointOfView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/map/PointOfView;", "")]
	public unsafe static PointOfView? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<PointOfView>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/map/PointOfView;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/map/PointOfView;", "")]
	public unsafe static PointOfView[]? Values()
	{
		return (PointOfView[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/map/PointOfView;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(PointOfView));
	}
}
