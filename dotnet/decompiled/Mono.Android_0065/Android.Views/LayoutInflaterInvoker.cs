using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/LayoutInflater", DoNotGenerateAcw = true)]
internal class LayoutInflaterInvoker : LayoutInflater
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/LayoutInflater", typeof(LayoutInflaterInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public LayoutInflaterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
