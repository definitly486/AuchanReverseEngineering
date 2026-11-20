using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/LiveData", DoNotGenerateAcw = true)]
internal class LiveDataInvoker : LiveData
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/LiveData", typeof(LiveDataInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public LiveDataInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
