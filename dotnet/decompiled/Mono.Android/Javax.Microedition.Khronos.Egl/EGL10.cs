using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Javax.Microedition.Khronos.Egl;

[Register("mono/internal/javax/microedition/khronos/egl/EGL10", DoNotGenerateAcw = true)]
[Obsolete("Use the 'Javax.Microedition.Khronos.Egl.IEGL10' type. This class will be removed in a future release.")]
public abstract class EGL10 : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/microedition/khronos/egl/EGL10", typeof(EGL10));

	[Register("EGL_DEFAULT_DISPLAY")]
	[Obsolete("Use 'Javax.Microedition.Khronos.Egl.IEGL10.EglDefaultDisplay'. This class will be removed in a future release.")]
	public static Java.Lang.Object? EglDefaultDisplay => Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticFields.GetObjectValue("EGL_DEFAULT_DISPLAY.Ljava/lang/Object;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("EGL_NO_CONTEXT")]
	[Obsolete("Use 'Javax.Microedition.Khronos.Egl.IEGL10.EglNoContext'. This class will be removed in a future release.")]
	public static EGLContext? EglNoContext => Java.Lang.Object.GetObject<EGLContext>(_members.StaticFields.GetObjectValue("EGL_NO_CONTEXT.Ljavax/microedition/khronos/egl/EGLContext;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("EGL_NO_DISPLAY")]
	[Obsolete("Use 'Javax.Microedition.Khronos.Egl.IEGL10.EglNoDisplay'. This class will be removed in a future release.")]
	public static EGLDisplay? EglNoDisplay => Java.Lang.Object.GetObject<EGLDisplay>(_members.StaticFields.GetObjectValue("EGL_NO_DISPLAY.Ljavax/microedition/khronos/egl/EGLDisplay;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("EGL_NO_SURFACE")]
	[Obsolete("Use 'Javax.Microedition.Khronos.Egl.IEGL10.EglNoSurface'. This class will be removed in a future release.")]
	public static EGLSurface? EglNoSurface => Java.Lang.Object.GetObject<EGLSurface>(_members.StaticFields.GetObjectValue("EGL_NO_SURFACE.Ljavax/microedition/khronos/egl/EGLSurface;").Handle, JniHandleOwnership.TransferLocalRef);
}
