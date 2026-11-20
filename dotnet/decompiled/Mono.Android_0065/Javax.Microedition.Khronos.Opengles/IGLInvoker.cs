using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Javax.Microedition.Khronos.Opengles;

[Register("javax/microedition/khronos/opengles/GL", DoNotGenerateAcw = true)]
internal class IGLInvoker : Java.Lang.Object, IGL, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_javax_microedition_khronos_opengles_GL = new XAPeerMembers("javax/microedition/khronos/opengles/GL", typeof(IGLInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_javax_microedition_khronos_opengles_GL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_javax_microedition_khronos_opengles_GL.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_javax_microedition_khronos_opengles_GL.ManagedPeerType;

	public IGLInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
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
