using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Javax.Microedition.Khronos.Egl;

[Register("javax/microedition/khronos/egl/EGL10", "", "Javax.Microedition.Khronos.Egl.IEGL10Invoker")]
public interface IEGL10 : IEGL, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/microedition/khronos/egl/EGL10", typeof(IEGL10), isInterface: true);

	[Register("EGL_DEFAULT_DISPLAY")]
	static Java.Lang.Object? EglDefaultDisplay => Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticFields.GetObjectValue("EGL_DEFAULT_DISPLAY.Ljava/lang/Object;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("EGL_NO_CONTEXT")]
	static EGLContext? EglNoContext => Java.Lang.Object.GetObject<EGLContext>(_members.StaticFields.GetObjectValue("EGL_NO_CONTEXT.Ljavax/microedition/khronos/egl/EGLContext;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("EGL_NO_DISPLAY")]
	static EGLDisplay? EglNoDisplay => Java.Lang.Object.GetObject<EGLDisplay>(_members.StaticFields.GetObjectValue("EGL_NO_DISPLAY.Ljavax/microedition/khronos/egl/EGLDisplay;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("EGL_NO_SURFACE")]
	static EGLSurface? EglNoSurface => Java.Lang.Object.GetObject<EGLSurface>(_members.StaticFields.GetObjectValue("EGL_NO_SURFACE.Ljavax/microedition/khronos/egl/EGLSurface;").Handle, JniHandleOwnership.TransferLocalRef);

	bool EglChooseConfig(EGLDisplay? display, int[]? attrib_list, EGLConfig[]? configs, int config_size, int[]? num_config);

	bool EglCopyBuffers(EGLDisplay? display, EGLSurface? surface, Java.Lang.Object? native_pixmap);

	EGLContext? EglCreateContext(EGLDisplay? display, EGLConfig? config, EGLContext? share_context, int[]? attrib_list);

	EGLSurface? EglCreatePbufferSurface(EGLDisplay? display, EGLConfig? config, int[]? attrib_list);

	[ObsoletedOSPlatform("android26.0")]
	EGLSurface? EglCreatePixmapSurface(EGLDisplay? display, EGLConfig? config, Java.Lang.Object? native_pixmap, int[]? attrib_list);

	EGLSurface? EglCreateWindowSurface(EGLDisplay? display, EGLConfig? config, Java.Lang.Object? native_window, int[]? attrib_list);

	bool EglDestroyContext(EGLDisplay? display, EGLContext? context);

	bool EglDestroySurface(EGLDisplay? display, EGLSurface? surface);

	bool EglGetConfigAttrib(EGLDisplay? display, EGLConfig? config, int attribute, int[]? value);

	bool EglGetConfigs(EGLDisplay? display, EGLConfig[]? configs, int config_size, int[]? num_config);

	EGLContext? EglGetCurrentContext();

	EGLDisplay? EglGetCurrentDisplay();

	EGLSurface? EglGetCurrentSurface(int readdraw);

	EGLDisplay? EglGetDisplay(Java.Lang.Object? native_display);

	int EglGetError();

	bool EglInitialize(EGLDisplay? display, int[]? major_minor);

	bool EglMakeCurrent(EGLDisplay? display, EGLSurface? draw, EGLSurface? read, EGLContext? context);

	bool EglQueryContext(EGLDisplay? display, EGLContext? context, int attribute, int[]? value);

	string? EglQueryString(EGLDisplay? display, int name);

	bool EglQuerySurface(EGLDisplay? display, EGLSurface? surface, int attribute, int[]? value);

	bool EglSwapBuffers(EGLDisplay? display, EGLSurface? surface);

	bool EglTerminate(EGLDisplay? display);

	bool EglWaitGL();

	bool EglWaitNative(int engine, Java.Lang.Object? bindTarget);
}
