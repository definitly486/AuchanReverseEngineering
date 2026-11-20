using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Text;

[Register("android/text/ClipboardManager", DoNotGenerateAcw = true)]
internal class ClipboardManagerInvoker : ClipboardManager
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/ClipboardManager", typeof(ClipboardManagerInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ClipboardManagerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
