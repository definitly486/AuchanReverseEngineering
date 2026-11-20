using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/RotationType", DoNotGenerateAcw = true)]
public sealed class RotationType : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/map/RotationType", typeof(RotationType));

	[Register("NO_ROTATION")]
	public static RotationType? NoRotation => Java.Lang.Object.GetObject<RotationType>(_members.StaticFields.GetObjectValue("NO_ROTATION.Lcom/yandex/mapkit/map/RotationType;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("ROTATE")]
	public static RotationType? Rotate => Java.Lang.Object.GetObject<RotationType>(_members.StaticFields.GetObjectValue("ROTATE.Lcom/yandex/mapkit/map/RotationType;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal RotationType(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/map/RotationType;", "")]
	public unsafe static RotationType? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<RotationType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/map/RotationType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/map/RotationType;", "")]
	public unsafe static RotationType[]? Values()
	{
		return (RotationType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/map/RotationType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(RotationType));
	}
}
