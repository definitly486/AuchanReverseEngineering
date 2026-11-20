using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Javax.Microedition.Khronos.Opengles;

namespace Javax.Microedition.Khronos.Egl;

[Register("javax/microedition/khronos/egl/EGLContext", DoNotGenerateAcw = true)]
public abstract class EGLContext : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/microedition/khronos/egl/EGLContext", typeof(EGLContext));

	private static Delegate? cb_getGL_GetGL_Ljavax_microedition_khronos_opengles_GL_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe static IEGL? EGL => Java.Lang.Object.GetObject<IEGL>(_members.StaticMethods.InvokeObjectMethod("getEGL.()Ljavax/microedition/khronos/egl/EGL;", null).Handle, JniHandleOwnership.TransferLocalRef);

	public abstract IGL? GL { get; }

	protected EGLContext(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetGLHandler()
	{
		return new _JniMarshal_PP_L(n_GetGL);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetGL(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<EGLContext>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GL);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}
}
