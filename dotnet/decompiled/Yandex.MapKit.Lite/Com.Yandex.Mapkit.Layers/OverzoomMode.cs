using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/OverzoomMode", DoNotGenerateAcw = true)]
public sealed class OverzoomMode : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/layers/OverzoomMode", typeof(OverzoomMode));

	[Register("DISABLED")]
	public static OverzoomMode? Disabled => Java.Lang.Object.GetObject<OverzoomMode>(_members.StaticFields.GetObjectValue("DISABLED.Lcom/yandex/mapkit/layers/OverzoomMode;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("ENABLED")]
	public static OverzoomMode? Enabled => Java.Lang.Object.GetObject<OverzoomMode>(_members.StaticFields.GetObjectValue("ENABLED.Lcom/yandex/mapkit/layers/OverzoomMode;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("WITH_PREFETCH")]
	public static OverzoomMode? WithPrefetch => Java.Lang.Object.GetObject<OverzoomMode>(_members.StaticFields.GetObjectValue("WITH_PREFETCH.Lcom/yandex/mapkit/layers/OverzoomMode;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal OverzoomMode(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/layers/OverzoomMode;", "")]
	public unsafe static OverzoomMode? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<OverzoomMode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/layers/OverzoomMode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/layers/OverzoomMode;", "")]
	public unsafe static OverzoomMode[]? Values()
	{
		return (OverzoomMode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/layers/OverzoomMode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(OverzoomMode));
	}
}
