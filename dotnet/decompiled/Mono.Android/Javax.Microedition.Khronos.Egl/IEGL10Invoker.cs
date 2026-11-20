using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Javax.Microedition.Khronos.Egl;

[Register("javax/microedition/khronos/egl/EGL10", DoNotGenerateAcw = true)]
internal class IEGL10Invoker : Java.Lang.Object, IEGL10, IEGL, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_javax_microedition_khronos_egl_EGL = new XAPeerMembers("javax/microedition/khronos/egl/EGL", typeof(IEGL10Invoker));

	private static readonly JniPeerMembers _members_javax_microedition_khronos_egl_EGL10 = new XAPeerMembers("javax/microedition/khronos/egl/EGL10", typeof(IEGL10Invoker));

	private static Delegate? cb_eglChooseConfig_EglChooseConfig_Ljavax_microedition_khronos_egl_EGLDisplay_arrayIarrayLjavax_microedition_khronos_egl_EGLConfig_IarrayI_Z;

	private static Delegate? cb_eglCopyBuffers_EglCopyBuffers_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_Ljava_lang_Object__Z;

	private static Delegate? cb_eglCreateContext_EglCreateContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljavax_microedition_khronos_egl_EGLContext_arrayI_Ljavax_microedition_khronos_egl_EGLContext_;

	private static Delegate? cb_eglCreatePbufferSurface_EglCreatePbufferSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_arrayI_Ljavax_microedition_khronos_egl_EGLSurface_;

	private static Delegate? cb_eglCreatePixmapSurface_EglCreatePixmapSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljava_lang_Object_arrayI_Ljavax_microedition_khronos_egl_EGLSurface_;

	private static Delegate? cb_eglCreateWindowSurface_EglCreateWindowSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljava_lang_Object_arrayI_Ljavax_microedition_khronos_egl_EGLSurface_;

	private static Delegate? cb_eglDestroyContext_EglDestroyContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLContext__Z;

	private static Delegate? cb_eglDestroySurface_EglDestroySurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface__Z;

	private static Delegate? cb_eglGetConfigAttrib_EglGetConfigAttrib_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_IarrayI_Z;

	private static Delegate? cb_eglGetConfigs_EglGetConfigs_Ljavax_microedition_khronos_egl_EGLDisplay_arrayLjavax_microedition_khronos_egl_EGLConfig_IarrayI_Z;

	private static Delegate? cb_eglGetCurrentContext_EglGetCurrentContext_Ljavax_microedition_khronos_egl_EGLContext_;

	private static Delegate? cb_eglGetCurrentDisplay_EglGetCurrentDisplay_Ljavax_microedition_khronos_egl_EGLDisplay_;

	private static Delegate? cb_eglGetCurrentSurface_EglGetCurrentSurface_I_Ljavax_microedition_khronos_egl_EGLSurface_;

	private static Delegate? cb_eglGetDisplay_EglGetDisplay_Ljava_lang_Object__Ljavax_microedition_khronos_egl_EGLDisplay_;

	private static Delegate? cb_eglGetError_EglGetError_I;

	private static Delegate? cb_eglInitialize_EglInitialize_Ljavax_microedition_khronos_egl_EGLDisplay_arrayI_Z;

	private static Delegate? cb_eglMakeCurrent_EglMakeCurrent_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_Ljavax_microedition_khronos_egl_EGLSurface_Ljavax_microedition_khronos_egl_EGLContext__Z;

	private static Delegate? cb_eglQueryContext_EglQueryContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLContext_IarrayI_Z;

	private static Delegate? cb_eglQueryString_EglQueryString_Ljavax_microedition_khronos_egl_EGLDisplay_I_Ljava_lang_String_;

	private static Delegate? cb_eglQuerySurface_EglQuerySurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_IarrayI_Z;

	private static Delegate? cb_eglSwapBuffers_EglSwapBuffers_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface__Z;

	private static Delegate? cb_eglTerminate_EglTerminate_Ljavax_microedition_khronos_egl_EGLDisplay__Z;

	private static Delegate? cb_eglWaitGL_EglWaitGL_Z;

	private static Delegate? cb_eglWaitNative_EglWaitNative_ILjava_lang_Object__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_javax_microedition_khronos_egl_EGL10;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_javax_microedition_khronos_egl_EGL10.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_javax_microedition_khronos_egl_EGL10.ManagedPeerType;

	public IEGL10Invoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetEglChooseConfig_Ljavax_microedition_khronos_egl_EGLDisplay_arrayIarrayLjavax_microedition_khronos_egl_EGLConfig_IarrayIHandler()
	{
		return new _JniMarshal_PPLLLIL_B(n_EglChooseConfig_Ljavax_microedition_khronos_egl_EGLDisplay_arrayIarrayLjavax_microedition_khronos_egl_EGLConfig_IarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_EglChooseConfig_Ljavax_microedition_khronos_egl_EGLDisplay_arrayIarrayLjavax_microedition_khronos_egl_EGLConfig_IarrayI(nint jnienv, nint native__this, nint native_display, nint native_attrib_list, nint native_configs, int config_size, nint native_num_config)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_attrib_list, JniHandleOwnership.DoNotTransfer, typeof(int));
			EGLConfig[] array2 = (EGLConfig[])JNIEnv.GetArray(native_configs, JniHandleOwnership.DoNotTransfer, typeof(EGLConfig));
			int[] array3 = (int[])JNIEnv.GetArray(native_num_config, JniHandleOwnership.DoNotTransfer, typeof(int));
			sbyte result = (iEGL.EglChooseConfig(display, array, array2, config_size, array3) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attrib_list);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_configs);
			}
			if (array3 != null)
			{
				JNIEnv.CopyArray(array3, native_num_config);
			}
			return result;
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

	public unsafe bool EglChooseConfig(EGLDisplay? display, int[]? attrib_list, EGLConfig[]? configs, int config_size, int[]? num_config)
	{
		nint num = JNIEnv.NewArray(attrib_list);
		nint num2 = JNIEnv.NewArray(configs);
		nint num3 = JNIEnv.NewArray(num_config);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(num2);
			ptr[3] = new JniArgumentValue(config_size);
			ptr[4] = new JniArgumentValue(num3);
			return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractBooleanMethod("eglChooseConfig.(Ljavax/microedition/khronos/egl/EGLDisplay;[I[Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z", this, ptr);
		}
		finally
		{
			if (attrib_list != null)
			{
				JNIEnv.CopyArray(num, attrib_list);
				JNIEnv.DeleteLocalRef(num);
			}
			if (configs != null)
			{
				JNIEnv.CopyArray(num2, configs);
				JNIEnv.DeleteLocalRef(num2);
			}
			if (num_config != null)
			{
				JNIEnv.CopyArray(num3, num_config);
				JNIEnv.DeleteLocalRef(num3);
			}
			GC.KeepAlive(display);
			GC.KeepAlive(attrib_list);
			GC.KeepAlive(configs);
			GC.KeepAlive(num_config);
		}
	}

	private static Delegate GetEglCopyBuffers_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPLLL_B(n_EglCopyBuffers_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_EglCopyBuffers_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_display, nint native_surface, nint native_native_pixmap)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			EGLSurface surface = Java.Lang.Object.GetObject<EGLSurface>(native_surface, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object native_pixmap = Java.Lang.Object.GetObject<Java.Lang.Object>(native_native_pixmap, JniHandleOwnership.DoNotTransfer);
			return iEGL.EglCopyBuffers(display, surface, native_pixmap) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool EglCopyBuffers(EGLDisplay? display, EGLSurface? surface, Java.Lang.Object? native_pixmap)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(native_pixmap?.Handle ?? IntPtr.Zero);
			return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractBooleanMethod("eglCopyBuffers.(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(display);
			GC.KeepAlive(surface);
			GC.KeepAlive(native_pixmap);
		}
	}

	private static Delegate GetEglCreateContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljavax_microedition_khronos_egl_EGLContext_arrayIHandler()
	{
		return new _JniMarshal_PPLLLL_L(n_EglCreateContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljavax_microedition_khronos_egl_EGLContext_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_EglCreateContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljavax_microedition_khronos_egl_EGLContext_arrayI(nint jnienv, nint native__this, nint native_display, nint native_config, nint native_share_context, nint native_attrib_list)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			EGLConfig config = Java.Lang.Object.GetObject<EGLConfig>(native_config, JniHandleOwnership.DoNotTransfer);
			EGLContext share_context = Java.Lang.Object.GetObject<EGLContext>(native_share_context, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_attrib_list, JniHandleOwnership.DoNotTransfer, typeof(int));
			nint result = JNIEnv.ToLocalJniHandle(iEGL.EglCreateContext(display, config, share_context, array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attrib_list);
			}
			return result;
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

	public unsafe EGLContext? EglCreateContext(EGLDisplay? display, EGLConfig? config, EGLContext? share_context, int[]? attrib_list)
	{
		nint num = JNIEnv.NewArray(attrib_list);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(share_context?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<EGLContext>(_members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractObjectMethod("eglCreateContext.(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;Ljavax/microedition/khronos/egl/EGLContext;[I)Ljavax/microedition/khronos/egl/EGLContext;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (attrib_list != null)
			{
				JNIEnv.CopyArray(num, attrib_list);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(display);
			GC.KeepAlive(config);
			GC.KeepAlive(share_context);
			GC.KeepAlive(attrib_list);
		}
	}

	private static Delegate GetEglCreatePbufferSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_arrayIHandler()
	{
		return new _JniMarshal_PPLLL_L(n_EglCreatePbufferSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_EglCreatePbufferSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_arrayI(nint jnienv, nint native__this, nint native_display, nint native_config, nint native_attrib_list)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			EGLConfig config = Java.Lang.Object.GetObject<EGLConfig>(native_config, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_attrib_list, JniHandleOwnership.DoNotTransfer, typeof(int));
			nint result = JNIEnv.ToLocalJniHandle(iEGL.EglCreatePbufferSurface(display, config, array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attrib_list);
			}
			return result;
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

	public unsafe EGLSurface? EglCreatePbufferSurface(EGLDisplay? display, EGLConfig? config, int[]? attrib_list)
	{
		nint num = JNIEnv.NewArray(attrib_list);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<EGLSurface>(_members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractObjectMethod("eglCreatePbufferSurface.(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;[I)Ljavax/microedition/khronos/egl/EGLSurface;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (attrib_list != null)
			{
				JNIEnv.CopyArray(num, attrib_list);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(display);
			GC.KeepAlive(config);
			GC.KeepAlive(attrib_list);
		}
	}

	[ObsoletedOSPlatform("android26.0")]
	private static Delegate GetEglCreatePixmapSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljava_lang_Object_arrayIHandler()
	{
		return new _JniMarshal_PPLLLL_L(n_EglCreatePixmapSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljava_lang_Object_arrayI);
	}

	[ObsoletedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_EglCreatePixmapSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljava_lang_Object_arrayI(nint jnienv, nint native__this, nint native_display, nint native_config, nint native_native_pixmap, nint native_attrib_list)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			EGLConfig config = Java.Lang.Object.GetObject<EGLConfig>(native_config, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object native_pixmap = Java.Lang.Object.GetObject<Java.Lang.Object>(native_native_pixmap, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_attrib_list, JniHandleOwnership.DoNotTransfer, typeof(int));
			nint result = JNIEnv.ToLocalJniHandle(iEGL.EglCreatePixmapSurface(display, config, native_pixmap, array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attrib_list);
			}
			return result;
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

	public unsafe EGLSurface? EglCreatePixmapSurface(EGLDisplay? display, EGLConfig? config, Java.Lang.Object? native_pixmap, int[]? attrib_list)
	{
		nint num = JNIEnv.NewArray(attrib_list);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(native_pixmap?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<EGLSurface>(_members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractObjectMethod("eglCreatePixmapSurface.(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;Ljava/lang/Object;[I)Ljavax/microedition/khronos/egl/EGLSurface;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (attrib_list != null)
			{
				JNIEnv.CopyArray(num, attrib_list);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(display);
			GC.KeepAlive(config);
			GC.KeepAlive(native_pixmap);
			GC.KeepAlive(attrib_list);
		}
	}

	private static Delegate GetEglCreateWindowSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljava_lang_Object_arrayIHandler()
	{
		return new _JniMarshal_PPLLLL_L(n_EglCreateWindowSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljava_lang_Object_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_EglCreateWindowSurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_Ljava_lang_Object_arrayI(nint jnienv, nint native__this, nint native_display, nint native_config, nint native_native_window, nint native_attrib_list)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			EGLConfig config = Java.Lang.Object.GetObject<EGLConfig>(native_config, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object native_window = Java.Lang.Object.GetObject<Java.Lang.Object>(native_native_window, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_attrib_list, JniHandleOwnership.DoNotTransfer, typeof(int));
			nint result = JNIEnv.ToLocalJniHandle(iEGL.EglCreateWindowSurface(display, config, native_window, array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_attrib_list);
			}
			return result;
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

	public unsafe EGLSurface? EglCreateWindowSurface(EGLDisplay? display, EGLConfig? config, Java.Lang.Object? native_window, int[]? attrib_list)
	{
		nint num = JNIEnv.NewArray(attrib_list);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(native_window?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<EGLSurface>(_members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractObjectMethod("eglCreateWindowSurface.(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;Ljava/lang/Object;[I)Ljavax/microedition/khronos/egl/EGLSurface;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (attrib_list != null)
			{
				JNIEnv.CopyArray(num, attrib_list);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(display);
			GC.KeepAlive(config);
			GC.KeepAlive(native_window);
			GC.KeepAlive(attrib_list);
		}
	}

	private static Delegate GetEglDestroyContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLContext_Handler()
	{
		return new _JniMarshal_PPLL_B(n_EglDestroyContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLContext_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_EglDestroyContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLContext_(nint jnienv, nint native__this, nint native_display, nint native_context)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			EGLContext context = Java.Lang.Object.GetObject<EGLContext>(native_context, JniHandleOwnership.DoNotTransfer);
			return iEGL.EglDestroyContext(display, context) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool EglDestroyContext(EGLDisplay? display, EGLContext? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractBooleanMethod("eglDestroyContext.(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLContext;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(display);
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetEglDestroySurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_Handler()
	{
		return new _JniMarshal_PPLL_B(n_EglDestroySurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_EglDestroySurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_(nint jnienv, nint native__this, nint native_display, nint native_surface)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			EGLSurface surface = Java.Lang.Object.GetObject<EGLSurface>(native_surface, JniHandleOwnership.DoNotTransfer);
			return iEGL.EglDestroySurface(display, surface) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool EglDestroySurface(EGLDisplay? display, EGLSurface? surface)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
			return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractBooleanMethod("eglDestroySurface.(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(display);
			GC.KeepAlive(surface);
		}
	}

	private static Delegate GetEglGetConfigAttrib_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_IarrayIHandler()
	{
		return new _JniMarshal_PPLLIL_B(n_EglGetConfigAttrib_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_IarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_EglGetConfigAttrib_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLConfig_IarrayI(nint jnienv, nint native__this, nint native_display, nint native_config, int attribute, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			EGLConfig config = Java.Lang.Object.GetObject<EGLConfig>(native_config, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(int));
			sbyte result = (iEGL.EglGetConfigAttrib(display, config, attribute, array) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_value);
			}
			return result;
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

	public unsafe bool EglGetConfigAttrib(EGLDisplay? display, EGLConfig? config, int attribute, int[]? value)
	{
		nint num = JNIEnv.NewArray(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(config?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(attribute);
			ptr[3] = new JniArgumentValue(num);
			return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractBooleanMethod("eglGetConfigAttrib.(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z", this, ptr);
		}
		finally
		{
			if (value != null)
			{
				JNIEnv.CopyArray(num, value);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(display);
			GC.KeepAlive(config);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetEglGetConfigs_Ljavax_microedition_khronos_egl_EGLDisplay_arrayLjavax_microedition_khronos_egl_EGLConfig_IarrayIHandler()
	{
		return new _JniMarshal_PPLLIL_B(n_EglGetConfigs_Ljavax_microedition_khronos_egl_EGLDisplay_arrayLjavax_microedition_khronos_egl_EGLConfig_IarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_EglGetConfigs_Ljavax_microedition_khronos_egl_EGLDisplay_arrayLjavax_microedition_khronos_egl_EGLConfig_IarrayI(nint jnienv, nint native__this, nint native_display, nint native_configs, int config_size, nint native_num_config)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			EGLConfig[] array = (EGLConfig[])JNIEnv.GetArray(native_configs, JniHandleOwnership.DoNotTransfer, typeof(EGLConfig));
			int[] array2 = (int[])JNIEnv.GetArray(native_num_config, JniHandleOwnership.DoNotTransfer, typeof(int));
			sbyte result = (iEGL.EglGetConfigs(display, array, config_size, array2) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_configs);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_num_config);
			}
			return result;
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

	public unsafe bool EglGetConfigs(EGLDisplay? display, EGLConfig[]? configs, int config_size, int[]? num_config)
	{
		nint num = JNIEnv.NewArray(configs);
		nint num2 = JNIEnv.NewArray(num_config);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(config_size);
			ptr[3] = new JniArgumentValue(num2);
			return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractBooleanMethod("eglGetConfigs.(Ljavax/microedition/khronos/egl/EGLDisplay;[Ljavax/microedition/khronos/egl/EGLConfig;I[I)Z", this, ptr);
		}
		finally
		{
			if (configs != null)
			{
				JNIEnv.CopyArray(num, configs);
				JNIEnv.DeleteLocalRef(num);
			}
			if (num_config != null)
			{
				JNIEnv.CopyArray(num2, num_config);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(display);
			GC.KeepAlive(configs);
			GC.KeepAlive(num_config);
		}
	}

	private static Delegate GetEglGetCurrentContextHandler()
	{
		return new _JniMarshal_PP_L(n_EglGetCurrentContext);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_EglGetCurrentContext(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EglGetCurrentContext());
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

	public unsafe EGLContext? EglGetCurrentContext()
	{
		return Java.Lang.Object.GetObject<EGLContext>(_members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractObjectMethod("eglGetCurrentContext.()Ljavax/microedition/khronos/egl/EGLContext;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetEglGetCurrentDisplayHandler()
	{
		return new _JniMarshal_PP_L(n_EglGetCurrentDisplay);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_EglGetCurrentDisplay(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EglGetCurrentDisplay());
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

	public unsafe EGLDisplay? EglGetCurrentDisplay()
	{
		return Java.Lang.Object.GetObject<EGLDisplay>(_members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractObjectMethod("eglGetCurrentDisplay.()Ljavax/microedition/khronos/egl/EGLDisplay;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetEglGetCurrentSurface_IHandler()
	{
		return new _JniMarshal_PPI_L(n_EglGetCurrentSurface_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_EglGetCurrentSurface_I(nint jnienv, nint native__this, int readdraw)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EglGetCurrentSurface(readdraw));
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

	public unsafe EGLSurface? EglGetCurrentSurface(int readdraw)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(readdraw);
		return Java.Lang.Object.GetObject<EGLSurface>(_members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractObjectMethod("eglGetCurrentSurface.(I)Ljavax/microedition/khronos/egl/EGLSurface;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetEglGetDisplay_Ljava_lang_Object_Handler()
	{
		return new _JniMarshal_PPL_L(n_EglGetDisplay_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_EglGetDisplay_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_native_display)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object native_display = Java.Lang.Object.GetObject<Java.Lang.Object>(native_native_display, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(iEGL.EglGetDisplay(native_display));
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

	public unsafe EGLDisplay? EglGetDisplay(Java.Lang.Object? native_display)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(native_display?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<EGLDisplay>(_members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractObjectMethod("eglGetDisplay.(Ljava/lang/Object;)Ljavax/microedition/khronos/egl/EGLDisplay;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(native_display);
		}
	}

	private static Delegate GetEglGetErrorHandler()
	{
		return new _JniMarshal_PP_I(n_EglGetError);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_EglGetError(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EglGetError();
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

	public unsafe int EglGetError()
	{
		return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractInt32Method("eglGetError.()I", this, null);
	}

	private static Delegate GetEglInitialize_Ljavax_microedition_khronos_egl_EGLDisplay_arrayIHandler()
	{
		return new _JniMarshal_PPLL_B(n_EglInitialize_Ljavax_microedition_khronos_egl_EGLDisplay_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_EglInitialize_Ljavax_microedition_khronos_egl_EGLDisplay_arrayI(nint jnienv, nint native__this, nint native_display, nint native_major_minor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_major_minor, JniHandleOwnership.DoNotTransfer, typeof(int));
			sbyte result = (iEGL.EglInitialize(display, array) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_major_minor);
			}
			return result;
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

	public unsafe bool EglInitialize(EGLDisplay? display, int[]? major_minor)
	{
		nint num = JNIEnv.NewArray(major_minor);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractBooleanMethod("eglInitialize.(Ljavax/microedition/khronos/egl/EGLDisplay;[I)Z", this, ptr);
		}
		finally
		{
			if (major_minor != null)
			{
				JNIEnv.CopyArray(num, major_minor);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(display);
			GC.KeepAlive(major_minor);
		}
	}

	private static Delegate GetEglMakeCurrent_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_Ljavax_microedition_khronos_egl_EGLSurface_Ljavax_microedition_khronos_egl_EGLContext_Handler()
	{
		return new _JniMarshal_PPLLLL_B(n_EglMakeCurrent_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_Ljavax_microedition_khronos_egl_EGLSurface_Ljavax_microedition_khronos_egl_EGLContext_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_EglMakeCurrent_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_Ljavax_microedition_khronos_egl_EGLSurface_Ljavax_microedition_khronos_egl_EGLContext_(nint jnienv, nint native__this, nint native_display, nint native_draw, nint native_read, nint native_context)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			EGLSurface draw = Java.Lang.Object.GetObject<EGLSurface>(native_draw, JniHandleOwnership.DoNotTransfer);
			EGLSurface read = Java.Lang.Object.GetObject<EGLSurface>(native_read, JniHandleOwnership.DoNotTransfer);
			EGLContext context = Java.Lang.Object.GetObject<EGLContext>(native_context, JniHandleOwnership.DoNotTransfer);
			return iEGL.EglMakeCurrent(display, draw, read, context) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool EglMakeCurrent(EGLDisplay? display, EGLSurface? draw, EGLSurface? read, EGLContext? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(draw?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(read?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractBooleanMethod("eglMakeCurrent.(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLSurface;Ljavax/microedition/khronos/egl/EGLContext;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(display);
			GC.KeepAlive(draw);
			GC.KeepAlive(read);
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetEglQueryContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLContext_IarrayIHandler()
	{
		return new _JniMarshal_PPLLIL_B(n_EglQueryContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLContext_IarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_EglQueryContext_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLContext_IarrayI(nint jnienv, nint native__this, nint native_display, nint native_context, int attribute, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			EGLContext context = Java.Lang.Object.GetObject<EGLContext>(native_context, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(int));
			sbyte result = (iEGL.EglQueryContext(display, context, attribute, array) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_value);
			}
			return result;
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

	public unsafe bool EglQueryContext(EGLDisplay? display, EGLContext? context, int attribute, int[]? value)
	{
		nint num = JNIEnv.NewArray(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(attribute);
			ptr[3] = new JniArgumentValue(num);
			return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractBooleanMethod("eglQueryContext.(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLContext;I[I)Z", this, ptr);
		}
		finally
		{
			if (value != null)
			{
				JNIEnv.CopyArray(num, value);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(display);
			GC.KeepAlive(context);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetEglQueryString_Ljavax_microedition_khronos_egl_EGLDisplay_IHandler()
	{
		return new _JniMarshal_PPLI_L(n_EglQueryString_Ljavax_microedition_khronos_egl_EGLDisplay_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_EglQueryString_Ljavax_microedition_khronos_egl_EGLDisplay_I(nint jnienv, nint native__this, nint native_display, int name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(iEGL.EglQueryString(display, name));
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

	public unsafe string? EglQueryString(EGLDisplay? display, int name)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(name);
			return JNIEnv.GetString(_members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractObjectMethod("eglQueryString.(Ljavax/microedition/khronos/egl/EGLDisplay;I)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(display);
		}
	}

	private static Delegate GetEglQuerySurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_IarrayIHandler()
	{
		return new _JniMarshal_PPLLIL_B(n_EglQuerySurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_IarrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_EglQuerySurface_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_IarrayI(nint jnienv, nint native__this, nint native_display, nint native_surface, int attribute, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			EGLSurface surface = Java.Lang.Object.GetObject<EGLSurface>(native_surface, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_value, JniHandleOwnership.DoNotTransfer, typeof(int));
			sbyte result = (iEGL.EglQuerySurface(display, surface, attribute, array) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_value);
			}
			return result;
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

	public unsafe bool EglQuerySurface(EGLDisplay? display, EGLSurface? surface, int attribute, int[]? value)
	{
		nint num = JNIEnv.NewArray(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(attribute);
			ptr[3] = new JniArgumentValue(num);
			return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractBooleanMethod("eglQuerySurface.(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;I[I)Z", this, ptr);
		}
		finally
		{
			if (value != null)
			{
				JNIEnv.CopyArray(num, value);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(display);
			GC.KeepAlive(surface);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetEglSwapBuffers_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_Handler()
	{
		return new _JniMarshal_PPLL_B(n_EglSwapBuffers_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_EglSwapBuffers_Ljavax_microedition_khronos_egl_EGLDisplay_Ljavax_microedition_khronos_egl_EGLSurface_(nint jnienv, nint native__this, nint native_display, nint native_surface)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			EGLSurface surface = Java.Lang.Object.GetObject<EGLSurface>(native_surface, JniHandleOwnership.DoNotTransfer);
			return iEGL.EglSwapBuffers(display, surface) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool EglSwapBuffers(EGLDisplay? display, EGLSurface? surface)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
			return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractBooleanMethod("eglSwapBuffers.(Ljavax/microedition/khronos/egl/EGLDisplay;Ljavax/microedition/khronos/egl/EGLSurface;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(display);
			GC.KeepAlive(surface);
		}
	}

	private static Delegate GetEglTerminate_Ljavax_microedition_khronos_egl_EGLDisplay_Handler()
	{
		return new _JniMarshal_PPL_B(n_EglTerminate_Ljavax_microedition_khronos_egl_EGLDisplay_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_EglTerminate_Ljavax_microedition_khronos_egl_EGLDisplay_(nint jnienv, nint native__this, nint native_display)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			EGLDisplay display = Java.Lang.Object.GetObject<EGLDisplay>(native_display, JniHandleOwnership.DoNotTransfer);
			return iEGL.EglTerminate(display) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool EglTerminate(EGLDisplay? display)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(display?.Handle ?? IntPtr.Zero);
			return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractBooleanMethod("eglTerminate.(Ljavax/microedition/khronos/egl/EGLDisplay;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(display);
		}
	}

	private static Delegate GetEglWaitGLHandler()
	{
		return new _JniMarshal_PP_B(n_EglWaitGL);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_EglWaitGL(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EglWaitGL() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool EglWaitGL()
	{
		return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractBooleanMethod("eglWaitGL.()Z", this, null);
	}

	private static Delegate GetEglWaitNative_ILjava_lang_Object_Handler()
	{
		return new _JniMarshal_PPIL_B(n_EglWaitNative_ILjava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_EglWaitNative_ILjava_lang_Object_(nint jnienv, nint native__this, int engine, nint native_bindTarget)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IEGL10? iEGL = Java.Lang.Object.GetObject<IEGL10>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object bindTarget = Java.Lang.Object.GetObject<Java.Lang.Object>(native_bindTarget, JniHandleOwnership.DoNotTransfer);
			return iEGL.EglWaitNative(engine, bindTarget) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool EglWaitNative(int engine, Java.Lang.Object? bindTarget)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(engine);
			ptr[1] = new JniArgumentValue(bindTarget?.Handle ?? IntPtr.Zero);
			return _members_javax_microedition_khronos_egl_EGL10.InstanceMethods.InvokeAbstractBooleanMethod("eglWaitNative.(ILjava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bindTarget);
		}
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
