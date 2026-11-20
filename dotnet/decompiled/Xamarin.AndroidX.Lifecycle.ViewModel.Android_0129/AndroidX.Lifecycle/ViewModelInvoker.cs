using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/ViewModel", DoNotGenerateAcw = true)]
internal class ViewModelInvoker : ViewModel
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/ViewModel", typeof(ViewModelInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ViewModelInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
