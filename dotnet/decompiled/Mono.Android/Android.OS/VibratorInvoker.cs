using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.OS;

[Register("android/os/Vibrator", DoNotGenerateAcw = true)]
internal class VibratorInvoker : Vibrator
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/os/Vibrator", typeof(VibratorInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public VibratorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
