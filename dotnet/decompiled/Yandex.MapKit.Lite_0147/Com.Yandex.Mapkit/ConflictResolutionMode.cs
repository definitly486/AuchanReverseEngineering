using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit;

[Register("com/yandex/mapkit/ConflictResolutionMode", DoNotGenerateAcw = true)]
public sealed class ConflictResolutionMode : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/ConflictResolutionMode", typeof(ConflictResolutionMode));

	[Register("EQUAL")]
	public static ConflictResolutionMode? Equal => Java.Lang.Object.GetObject<ConflictResolutionMode>(_members.StaticFields.GetObjectValue("EQUAL.Lcom/yandex/mapkit/ConflictResolutionMode;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("IGNORE")]
	public static ConflictResolutionMode? Ignore => Java.Lang.Object.GetObject<ConflictResolutionMode>(_members.StaticFields.GetObjectValue("IGNORE.Lcom/yandex/mapkit/ConflictResolutionMode;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("MAJOR")]
	public static ConflictResolutionMode? Major => Java.Lang.Object.GetObject<ConflictResolutionMode>(_members.StaticFields.GetObjectValue("MAJOR.Lcom/yandex/mapkit/ConflictResolutionMode;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("MINOR")]
	public static ConflictResolutionMode? Minor => Java.Lang.Object.GetObject<ConflictResolutionMode>(_members.StaticFields.GetObjectValue("MINOR.Lcom/yandex/mapkit/ConflictResolutionMode;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal ConflictResolutionMode(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/ConflictResolutionMode;", "")]
	public unsafe static ConflictResolutionMode? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ConflictResolutionMode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/ConflictResolutionMode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/ConflictResolutionMode;", "")]
	public unsafe static ConflictResolutionMode[]? Values()
	{
		return (ConflictResolutionMode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/ConflictResolutionMode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ConflictResolutionMode));
	}
}
