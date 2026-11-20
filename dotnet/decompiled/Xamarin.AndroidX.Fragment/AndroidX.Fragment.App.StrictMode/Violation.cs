using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Fragment.App.StrictMode;

[Register("androidx/fragment/app/strictmode/Violation", DoNotGenerateAcw = true)]
public abstract class Violation : RuntimeException
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/fragment/app/strictmode/Violation", typeof(Violation));

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe Fragment Fragment
	{
		[Register("getFragment", "()Landroidx/fragment/app/Fragment;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Fragment>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getFragment.()Landroidx/fragment/app/Fragment;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected Violation(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
