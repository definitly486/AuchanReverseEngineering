using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Animation;

[Register("android/animation/AnimatorListenerAdapter", DoNotGenerateAcw = true)]
internal class AnimatorListenerAdapterInvoker : AnimatorListenerAdapter
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/animation/AnimatorListenerAdapter", typeof(AnimatorListenerAdapterInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public AnimatorListenerAdapterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
