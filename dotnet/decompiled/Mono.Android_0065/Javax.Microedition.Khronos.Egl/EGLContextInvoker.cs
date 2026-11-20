using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Javax.Microedition.Khronos.Opengles;

namespace Javax.Microedition.Khronos.Egl;

[Register("javax/microedition/khronos/egl/EGLContext", DoNotGenerateAcw = true)]
internal class EGLContextInvoker : EGLContext
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/microedition/khronos/egl/EGLContext", typeof(EGLContextInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override IGL? GL => Java.Lang.Object.GetObject<IGL>(_members.InstanceMethods.InvokeAbstractObjectMethod("getGL.()Ljavax/microedition/khronos/opengles/GL;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public EGLContextInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}
}
