using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Logo;

[Register("com/yandex/mapkit/logo/HorizontalAlignment", DoNotGenerateAcw = true)]
public sealed class HorizontalAlignment : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/logo/HorizontalAlignment", typeof(HorizontalAlignment));

	[Register("CENTER")]
	public static HorizontalAlignment? Center => Java.Lang.Object.GetObject<HorizontalAlignment>(_members.StaticFields.GetObjectValue("CENTER.Lcom/yandex/mapkit/logo/HorizontalAlignment;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("LEFT")]
	public static HorizontalAlignment? Left => Java.Lang.Object.GetObject<HorizontalAlignment>(_members.StaticFields.GetObjectValue("LEFT.Lcom/yandex/mapkit/logo/HorizontalAlignment;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("RIGHT")]
	public static HorizontalAlignment? Right => Java.Lang.Object.GetObject<HorizontalAlignment>(_members.StaticFields.GetObjectValue("RIGHT.Lcom/yandex/mapkit/logo/HorizontalAlignment;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal HorizontalAlignment(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/logo/HorizontalAlignment;", "")]
	public unsafe static HorizontalAlignment? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<HorizontalAlignment>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/logo/HorizontalAlignment;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/logo/HorizontalAlignment;", "")]
	public unsafe static HorizontalAlignment[]? Values()
	{
		return (HorizontalAlignment[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/logo/HorizontalAlignment;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(HorizontalAlignment));
	}
}
