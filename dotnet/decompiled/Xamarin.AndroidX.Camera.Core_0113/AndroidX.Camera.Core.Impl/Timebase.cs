using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Timebase", DoNotGenerateAcw = true)]
public sealed class Timebase : Java.Lang.Enum
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/Timebase", typeof(Timebase));

	[Register("REALTIME")]
	public static Timebase? Realtime => Java.Lang.Object.GetObject<Timebase>(_members.StaticFields.GetObjectValue("REALTIME.Landroidx/camera/core/impl/Timebase;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("UPTIME")]
	public static Timebase? Uptime => Java.Lang.Object.GetObject<Timebase>(_members.StaticFields.GetObjectValue("UPTIME.Landroidx/camera/core/impl/Timebase;").Handle, JniHandleOwnership.TransferLocalRef);

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

	internal Timebase(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/core/impl/Timebase;", "")]
	public unsafe static Timebase? ValueOf(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Timebase>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/core/impl/Timebase;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[Register("values", "()[Landroidx/camera/core/impl/Timebase;", "")]
	public unsafe static Timebase[]? Values()
	{
		return (Timebase[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/core/impl/Timebase;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Timebase));
	}
}
