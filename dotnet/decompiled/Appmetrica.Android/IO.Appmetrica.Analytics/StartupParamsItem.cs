using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/StartupParamsItem", DoNotGenerateAcw = true)]
public sealed class StartupParamsItem : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("io/appmetrica/analytics/StartupParamsItem", typeof(StartupParamsItem));

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

	public unsafe string? ErrorDetails
	{
		[Register("getErrorDetails", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getErrorDetails.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe string? Id
	{
		[Register("getId", "()Ljava/lang/String;", "")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe StartupParamsItemStatus Status
	{
		[Register("getStatus", "()Lio/appmetrica/analytics/StartupParamsItemStatus;", "")]
		get
		{
			return Java.Lang.Object.GetObject<StartupParamsItemStatus>(_members.InstanceMethods.InvokeAbstractObjectMethod("getStatus.()Lio/appmetrica/analytics/StartupParamsItemStatus;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	internal StartupParamsItem(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljava/lang/String;Lio/appmetrica/analytics/StartupParamsItemStatus;Ljava/lang/String;)V", "")]
	public unsafe StartupParamsItem(string? id, StartupParamsItemStatus status, string? errorDetails)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(id);
		nint num2 = JNIEnv.NewString(errorDetails);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(status?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num2);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Lio/appmetrica/analytics/StartupParamsItemStatus;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Lio/appmetrica/analytics/StartupParamsItemStatus;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(status);
		}
	}
}
