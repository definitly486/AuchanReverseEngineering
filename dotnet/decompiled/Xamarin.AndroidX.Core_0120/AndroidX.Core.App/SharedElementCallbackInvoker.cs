using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Core.App;

[Register("androidx/core/app/SharedElementCallback", DoNotGenerateAcw = true)]
internal class SharedElementCallbackInvoker : SharedElementCallback
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/app/SharedElementCallback", typeof(SharedElementCallbackInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public SharedElementCallbackInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
