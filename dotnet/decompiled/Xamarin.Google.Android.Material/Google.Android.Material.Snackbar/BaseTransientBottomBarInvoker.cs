using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Google.Android.Material.Snackbar;

[Register("com/google/android/material/snackbar/BaseTransientBottomBar", DoNotGenerateAcw = true)]
internal class BaseTransientBottomBarInvoker : BaseTransientBottomBar
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/snackbar/BaseTransientBottomBar", typeof(BaseTransientBottomBarInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public BaseTransientBottomBarInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
