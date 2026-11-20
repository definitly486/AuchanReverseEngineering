using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/ClassLoader", DoNotGenerateAcw = true)]
internal class ClassLoaderInvoker : ClassLoader
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/ClassLoader", typeof(ClassLoaderInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public ClassLoaderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
