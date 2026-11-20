using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Gms.Tasks;

[Register("com/google/android/gms/tasks/CancellationToken", DoNotGenerateAcw = true)]
internal class CancellationTokenInvoker : CancellationToken
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/gms/tasks/CancellationToken", typeof(CancellationTokenInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override bool IsCancellationRequested
	{
		[Register("isCancellationRequested", "()Z", "GetIsCancellationRequestedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCancellationRequested.()Z", this, null);
		}
	}

	public CancellationTokenInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("onCanceledRequested", "(Lcom/google/android/gms/tasks/OnTokenCanceledListener;)Lcom/google/android/gms/tasks/CancellationToken;", "GetOnCanceledRequested_Lcom_google_android_gms_tasks_OnTokenCanceledListener_Handler")]
	public unsafe override CancellationToken OnCanceledRequested(IOnTokenCanceledListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<CancellationToken>(_members.InstanceMethods.InvokeAbstractObjectMethod("onCanceledRequested.(Lcom/google/android/gms/tasks/OnTokenCanceledListener;)Lcom/google/android/gms/tasks/CancellationToken;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
