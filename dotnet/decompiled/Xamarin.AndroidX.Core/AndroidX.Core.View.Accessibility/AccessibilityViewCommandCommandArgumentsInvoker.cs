using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Core.View.Accessibility;

[Register("androidx/core/view/accessibility/AccessibilityViewCommand$CommandArguments", DoNotGenerateAcw = true)]
internal class AccessibilityViewCommandCommandArgumentsInvoker : AccessibilityViewCommandCommandArguments
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/accessibility/AccessibilityViewCommand$CommandArguments", typeof(AccessibilityViewCommandCommandArgumentsInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public AccessibilityViewCommandCommandArgumentsInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
