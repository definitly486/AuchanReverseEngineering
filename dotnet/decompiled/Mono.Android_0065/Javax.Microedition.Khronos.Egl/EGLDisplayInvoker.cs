using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Javax.Microedition.Khronos.Egl;

[Register("javax/microedition/khronos/egl/EGLDisplay", DoNotGenerateAcw = true)]
internal class EGLDisplayInvoker : EGLDisplay
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/microedition/khronos/egl/EGLDisplay", typeof(EGLDisplayInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public EGLDisplayInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
