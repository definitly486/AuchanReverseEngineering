using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/UseInBackground", DoNotGenerateAcw = true)]
public sealed class UseInBackground : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/location/UseInBackground", typeof(UseInBackground));

	[Register("ALLOW")]
	public static UseInBackground? Allow => Java.Lang.Object.GetObject<UseInBackground>(_members.StaticFields.GetObjectValue("ALLOW.Lcom/yandex/mapkit/location/UseInBackground;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("DISALLOW")]
	public static UseInBackground? Disallow => Java.Lang.Object.GetObject<UseInBackground>(_members.StaticFields.GetObjectValue("DISALLOW.Lcom/yandex/mapkit/location/UseInBackground;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal UseInBackground(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/location/UseInBackground;", "")]
	public unsafe static UseInBackground? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<UseInBackground>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/location/UseInBackground;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/location/UseInBackground;", "")]
	public unsafe static UseInBackground[]? Values()
	{
		return (UseInBackground[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/location/UseInBackground;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(UseInBackground));
	}
}
