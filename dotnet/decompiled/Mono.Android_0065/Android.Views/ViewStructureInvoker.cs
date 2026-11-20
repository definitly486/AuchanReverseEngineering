using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/ViewStructure", DoNotGenerateAcw = true, ApiSince = 23)]
[SupportedOSPlatform("android23.0")]
internal class ViewStructureInvoker : ViewStructure
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/ViewStructure", typeof(ViewStructureInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ViewStructureInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
