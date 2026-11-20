using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/Build", DoNotGenerateAcw = true)]
public class Build : Java.Lang.Object
{
	[Register("android/os/Build$VERSION", DoNotGenerateAcw = true)]
	public class VERSION : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/os/Build$VERSION", typeof(VERSION));

		[Register("RELEASE")]
		public static string? Release => JNIEnv.GetString(_members.StaticFields.GetObjectValue("RELEASE.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SDK_INT")]
		public static BuildVersionCodes SdkInt => (BuildVersionCodes)_members.StaticFields.GetInt32Value("SDK_INT.I");

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected VERSION(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("android/os/Build", typeof(Build));

	[Register("BOARD")]
	public static string? Board => JNIEnv.GetString(_members.StaticFields.GetObjectValue("BOARD.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("BRAND")]
	public static string? Brand => JNIEnv.GetString(_members.StaticFields.GetObjectValue("BRAND.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("DEVICE")]
	public static string? Device => JNIEnv.GetString(_members.StaticFields.GetObjectValue("DEVICE.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("FINGERPRINT")]
	public static string? Fingerprint => JNIEnv.GetString(_members.StaticFields.GetObjectValue("FINGERPRINT.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("HOST")]
	public static string? Host => JNIEnv.GetString(_members.StaticFields.GetObjectValue("HOST.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("MANUFACTURER")]
	public static string? Manufacturer => JNIEnv.GetString(_members.StaticFields.GetObjectValue("MANUFACTURER.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("MODEL")]
	public static string? Model => JNIEnv.GetString(_members.StaticFields.GetObjectValue("MODEL.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("PRODUCT")]
	public static string? Product => JNIEnv.GetString(_members.StaticFields.GetObjectValue("PRODUCT.Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Build(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
