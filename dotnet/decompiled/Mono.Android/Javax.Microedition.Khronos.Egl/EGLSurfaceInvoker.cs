using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Javax.Microedition.Khronos.Egl;

[Register("javax/microedition/khronos/egl/EGLSurface", DoNotGenerateAcw = true)]
internal class EGLSurfaceInvoker : EGLSurface
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/microedition/khronos/egl/EGLSurface", typeof(EGLSurfaceInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public EGLSurfaceInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
