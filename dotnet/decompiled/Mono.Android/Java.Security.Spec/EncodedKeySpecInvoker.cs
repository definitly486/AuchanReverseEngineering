using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Security.Spec;

[Register("java/security/spec/EncodedKeySpec", DoNotGenerateAcw = true)]
internal class EncodedKeySpecInvoker : EncodedKeySpec
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/security/spec/EncodedKeySpec", typeof(EncodedKeySpecInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public EncodedKeySpecInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
