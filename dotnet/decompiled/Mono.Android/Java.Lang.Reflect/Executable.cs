using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang.Reflect;

[SupportedOSPlatform("android26.0")]
[Register("java/lang/reflect/Executable", DoNotGenerateAcw = true, ApiSince = 26)]
public abstract class Executable : AccessibleObject, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/reflect/Executable", typeof(Executable));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Executable(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
