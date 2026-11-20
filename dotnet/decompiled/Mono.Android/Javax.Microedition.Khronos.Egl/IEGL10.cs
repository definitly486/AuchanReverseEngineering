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

	[Register("eglChooseConfig", "(Ljavax/microedition/khronos/egl/EGLDisplay;[I[Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z", "GetEglChooseConfig_Ljavax_microedition_khronos_egl_EGLDisplay_arrayIarrayLjavax_microedition_khronos_egl_EGLConfig_IarrayIHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool EglChooseConfig(EGLDisplay? display, int[]? attrib_list, EGLConfig[]? configs, int config_size, int[]? num_config);

	[Register("eglCopyBuffers", "(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljava/lang/Object;)Z", "GetEglCopyBuffers_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_Ljava_lang_Object_Handler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool EglCopyBuffers(EGLDisplay? display, EGLSurface? surface, Java.Lang.Object? native_pixmap);

	[Register("eglCreateContext", "(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;Ljavax/microedition/khronos/egl/EGLContext;[I)Ljavax/microedition/khronos/egl/EGLContext;", "GetEglCreateContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljavax_microedition_khronos_egl_EGLContext_arrayIHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	EGLContext? EglCreateContext(EGLDisplay? display, EGLConfig? config, EGLContext? share_context, int[]? attrib_list);

	[Register("eglCreatePbufferSurface", "(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;[I)Ljavax/microedition/khronos/egl/EGLSurface;", "GetEglCreatePbufferSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_arrayIHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	EGLSurface? EglCreatePbufferSurface(EGLDisplay? display, EGLConfig? config, int[]? attrib_list);

	[ObsoletedOSPlatform("android26.0")]
	[Register("eglCreatePixmapSurface", "(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;Ljava/lang/Object;[I)Ljavax/microedition/khronos/egl/EGLSurface;", "GetEglCreatePixmapSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljava_lang_Object_arrayIHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	EGLSurface? EglCreatePixmapSurface(EGLDisplay? display, EGLConfig? config, Java.Lang.Object? native_pixmap, int[]? attrib_list);

	[Register("eglCreateWindowSurface", "(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;Ljava/lang/Object;[I)Ljavax/microedition/khronos/egl/EGLSurface;", "GetEglCreateWindowSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljava_lang_Object_arrayIHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	EGLSurface? EglCreateWindowSurface(EGLDisplay? display, EGLConfig? config, Java.Lang.Object? native_window, int[]? attrib_list);

	[Register("eglDestroyContext", "(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLContext;)Z", "GetEglDestroyContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLContext_Handler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool EglDestroyContext(EGLDisplay? display, EGLContext? context);

	[Register("eglDestroySurface", "(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;)Z", "GetEglDestroySurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_Handler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool EglDestroySurface(EGLDisplay? display, EGLSurface? surface);

	[Register("eglGetConfigAttrib", "(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z", "GetEglGetConfigAttrib_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_IarrayIHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool EglGetConfigAttrib(EGLDisplay? display, EGLConfig? config, int attribute, int[]? value);

	[Register("eglGetConfigs", "(Ljavax/microedition/khronos/egl/EGLDisplay;[Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z", "GetEglGetConfigs_Ljavax_microedition_khronos_egl_EGLDisplay_arrayLjavax_microedition_khronos_egl_EGLConfig_IarrayIHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool EglGetConfigs(EGLDisplay? display, EGLConfig[]? configs, int config_size, int[]? num_config);

	[Register("eglGetCurrentContext", "()Ljavax/microedition/khronos/egl/EGLContext;", "GetEglGetCurrentContextHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	EGLContext? EglGetCurrentContext();

	[Register("eglGetCurrentDisplay", "()Ljavax/microedition/khronos/egl/EGLDisplay;", "GetEglGetCurrentDisplayHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	EGLDisplay? EglGetCurrentDisplay();

	[Register("eglGetCurrentSurface", "(I)Ljavax/microedition/khronos/egl/EGLSurface;", "GetEglGetCurrentSurface_IHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	EGLSurface? EglGetCurrentSurface(int readdraw);

	[Register("eglGetDisplay", "(Ljava/lang/Object;)Ljavax/microedition/khronos/egl/EGLDisplay;", "GetEglGetDisplay_Ljava_lang_Object_Handler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	EGLDisplay? EglGetDisplay(Java.Lang.Object? native_display);

	[Register("eglGetError", "()I", "GetEglGetErrorHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int EglGetError();

	[Register("eglInitialize", "(Ljavax/microedition/khronos/egl/EGLDisplay;[I)Z", "GetEglInitialize_Ljavax_microedition_khronos_egl_EGLDisplay_arrayIHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool EglInitialize(EGLDisplay? display, int[]? major_minor);

	[Register("eglMakeCurrent", "(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z", "GetEglMakeCurrent_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_Ljavax_microedition_khronos_egl_EGLSurface_Ljavax_microedition_khronos_egl_EGLContext_Handler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool EglMakeCurrent(EGLDisplay? display, EGLSurface? draw, EGLSurface? read, EGLContext? context);

	[Register("eglQueryContext", "(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLContext;I[I)Z", "GetEglQueryContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLContext_IarrayIHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool EglQueryContext(EGLDisplay? display, EGLContext? context, int attribute, int[]? value);

	[Register("eglQueryString", "(Ljavax/microedition/khronos/egl/EGLDisplay;I)Ljava/lang/String;", "GetEglQueryString_Ljavax_microedition_khronos_egl_EGLDisplay_IHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? EglQueryString(EGLDisplay? display, int name);

	[Register("eglQuerySurface", "(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;I[I)Z", "GetEglQuerySurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_IarrayIHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool EglQuerySurface(EGLDisplay? display, EGLSurface? surface, int attribute, int[]? value);

	[Register("eglSwapBuffers", "(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;)Z", "GetEglSwapBuffers_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_Handler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool EglSwapBuffers(EGLDisplay? display, EGLSurface? surface);

	[Register("eglTerminate", "(Ljavax/microedition/khronos/egl/EGLDisplay;)Z", "GetEglTerminate_Ljavax_microedition_khronos_egl_EGLDisplay_Handler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool EglTerminate(EGLDisplay? display);

	[Register("eglWaitGL", "()Z", "GetEglWaitGLHandler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool EglWaitGL();

	[Register("eglWaitNative", "(ILjava/lang/Object;)Z", "GetEglWaitNative_ILjava_lang_Object_Handler:Javax.Microedition.Khronos.Egl.IEGL10Invoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool EglWaitNative(int engine, Java.Lang.Object? bindTarget);
}
