using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang.Reflect;

[Register("java/lang/reflect/Executable", DoNotGenerateAcw = true, ApiSince = 26)]
[SupportedOSPlatform("android26.0")]
internal class ExecutableInvoker : Executable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/reflect/Executable", typeof(ExecutableInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ExecutableInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
