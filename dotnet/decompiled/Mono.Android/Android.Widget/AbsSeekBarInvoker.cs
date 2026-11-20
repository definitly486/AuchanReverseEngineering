using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Widget;

[Register("android/widget/AbsSeekBar", DoNotGenerateAcw = true)]
internal class AbsSeekBarInvoker : AbsSeekBar
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/widget/AbsSeekBar", typeof(AbsSeekBarInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public AbsSeekBarInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
