using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Views.Animations;

[Register("android/view/animation/Animation", DoNotGenerateAcw = true)]
internal class AnimationInvoker : Animation
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/animation/Animation", typeof(AnimationInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public AnimationInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
