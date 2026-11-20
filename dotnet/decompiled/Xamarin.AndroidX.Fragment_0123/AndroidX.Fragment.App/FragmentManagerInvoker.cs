using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/FragmentManager", DoNotGenerateAcw = true)]
internal class FragmentManagerInvoker : FragmentManager
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/FragmentManager", typeof(FragmentManagerInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public FragmentManagerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
