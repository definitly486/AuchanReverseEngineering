using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Offline_cache;

[Register("com/yandex/mapkit/offline_cache/RegionState", DoNotGenerateAcw = true)]
public sealed class RegionState : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/yandex/mapkit/offline_cache/RegionState", typeof(RegionState));

	[Register("AVAILABLE")]
	public static RegionState? Available => Java.Lang.Object.GetObject<RegionState>(_members.StaticFields.GetObjectValue("AVAILABLE.Lcom/yandex/mapkit/offline_cache/RegionState;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("COMPLETED")]
	public static RegionState? Completed => Java.Lang.Object.GetObject<RegionState>(_members.StaticFields.GetObjectValue("COMPLETED.Lcom/yandex/mapkit/offline_cache/RegionState;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("DOWNLOADING")]
	public static RegionState? Downloading => Java.Lang.Object.GetObject<RegionState>(_members.StaticFields.GetObjectValue("DOWNLOADING.Lcom/yandex/mapkit/offline_cache/RegionState;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("NEED_UPDATE")]
	public static RegionState? NeedUpdate => Java.Lang.Object.GetObject<RegionState>(_members.StaticFields.GetObjectValue("NEED_UPDATE.Lcom/yandex/mapkit/offline_cache/RegionState;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("OUTDATED")]
	public static RegionState? Outdated => Java.Lang.Object.GetObject<RegionState>(_members.StaticFields.GetObjectValue("OUTDATED.Lcom/yandex/mapkit/offline_cache/RegionState;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PAUSED")]
	public static RegionState? Paused => Java.Lang.Object.GetObject<RegionState>(_members.StaticFields.GetObjectValue("PAUSED.Lcom/yandex/mapkit/offline_cache/RegionState;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("UNSUPPORTED")]
	public static RegionState? Unsupported => Java.Lang.Object.GetObject<RegionState>(_members.StaticFields.GetObjectValue("UNSUPPORTED.Lcom/yandex/mapkit/offline_cache/RegionState;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal RegionState(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Lcom/yandex/mapkit/offline_cache/RegionState;", "")]
	public unsafe static RegionState? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<RegionState>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lcom/yandex/mapkit/offline_cache/RegionState;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Lcom/yandex/mapkit/offline_cache/RegionState;", "")]
	public unsafe static RegionState[]? Values()
	{
		return (RegionState[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lcom/yandex/mapkit/offline_cache/RegionState;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(RegionState));
	}
}
