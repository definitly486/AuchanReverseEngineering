using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Text.Method;

[Register("android/text/method/LinkMovementMethod", DoNotGenerateAcw = true)]
public class LinkMovementMethod : ScrollingMovementMethod
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/method/LinkMovementMethod", typeof(LinkMovementMethod));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe static IMovementMethod? Instance => Java.Lang.Object.GetObject<IMovementMethod>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Landroid/text/method/MovementMethod;", null).Handle, JniHandleOwnership.TransferLocalRef);

	protected LinkMovementMethod(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}
}
