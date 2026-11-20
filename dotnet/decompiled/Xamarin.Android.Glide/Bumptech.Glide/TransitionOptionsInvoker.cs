using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide;

[Register("com/bumptech/glide/TransitionOptions", DoNotGenerateAcw = true)]
internal class TransitionOptionsInvoker : TransitionOptions
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/bumptech/glide/TransitionOptions", typeof(TransitionOptionsInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public TransitionOptionsInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
