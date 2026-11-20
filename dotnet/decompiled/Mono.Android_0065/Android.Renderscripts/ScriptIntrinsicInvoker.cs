using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Android.Renderscripts;

[Register("android/renderscript/ScriptIntrinsic", DoNotGenerateAcw = true)]
internal class ScriptIntrinsicInvoker : ScriptIntrinsic
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/renderscript/ScriptIntrinsic", typeof(ScriptIntrinsicInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override System.Type ThresholdType => _members.ManagedPeerType;

	public ScriptIntrinsicInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
