using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Text.Method;

[Register("android/text/method/MetaKeyKeyListener", DoNotGenerateAcw = true)]
internal class MetaKeyKeyListenerInvoker : MetaKeyKeyListener
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/text/method/MetaKeyKeyListener", typeof(MetaKeyKeyListenerInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public MetaKeyKeyListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
