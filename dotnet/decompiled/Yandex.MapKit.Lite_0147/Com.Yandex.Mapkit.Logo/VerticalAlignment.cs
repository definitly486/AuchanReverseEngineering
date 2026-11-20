using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Logo;

[Register("com/yandex/mapkit/logo/VerticalAlignment", DoNotGenerateAcw = true)]
public sealed class VerticalAlignment : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/logo/VerticalAlignment", typeof(VerticalAlignment));

	[Register("BOTTOM")]
	public static VerticalAlignment? Bottom => Java.Lang.Object.GetObject<VerticalAlignment>(_members.StaticFields.GetObjectValue("BOTTOM.Lcom/yandex/mapkit/logo/VerticalAlignment;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("TOP")]
	public static VerticalAlignment? Top => Java.Lang.Object.GetObject<VerticalAlignment>(_members.StaticFields.GetObjectValue("TOP.Lcom/yandex/mapkit/logo/VerticalAlignment;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal VerticalAlignment(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/logo/VerticalAlignment;", "")]
	public unsafe static VerticalAlignment? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<VerticalAlignment>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/logo/VerticalAlignment;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/logo/VerticalAlignment;", "")]
	public unsafe static VerticalAlignment[]? Values()
	{
		return (VerticalAlignment[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/logo/VerticalAlignment;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(VerticalAlignment));
	}
}
