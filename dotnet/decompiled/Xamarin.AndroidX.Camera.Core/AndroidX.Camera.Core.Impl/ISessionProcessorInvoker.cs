using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/SessionProcessor", DoNotGenerateAcw = true)]
internal class ISessionProcessorInvoker : Java.Lang.Object, ISessionProcessor, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/SessionProcessor", typeof(ISessionProcessorInvoker));

	private nint class_ref;

	private static Delegate? cb_abortCapture_I;

	private nint id_abortCapture_I;

	private static Delegate? cb_deInitSession;

	private nint id_deInitSession;

	private static Delegate? cb_initSession_Landroidx_camera_core_CameraInfo_Landroidx_camera_core_impl_OutputSurfaceConfiguration_;

	private nint id_initSession_Landroidx_camera_core_CameraInfo_Landroidx_camera_core_impl_OutputSurfaceConfiguration_;

	private static Delegate? cb_onCaptureSessionEnd;

	private nint id_onCaptureSessionEnd;

	private static Delegate? cb_onCaptureSessionStart_Landroidx_camera_core_impl_RequestProcessor_;

	private nint id_onCaptureSessionStart_Landroidx_camera_core_impl_RequestProcessor_;

	private static Delegate? cb_setParameters_Landroidx_camera_core_impl_Config_;

	private nint id_setParameters_Landroidx_camera_core_impl_Config_;

	private static Delegate? cb_startCapture_ZLandroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_;

	private nint id_startCapture_ZLandroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_;

	private static Delegate? cb_startRepeating_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_;

	private nint id_startRepeating_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_;

	private static Delegate? cb_stopRepeating;

	private nint id_stopRepeating;

	private static nint java_class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => class_ref;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public static ISessionProcessor? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ISessionProcessor>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.SessionProcessor'.");
		}
		return handle;
	}

	protected override void Dispose(bool disposing)
	{
		if (class_ref != IntPtr.Zero)
		{
			JNIEnv.DeleteGlobalRef(class_ref);
		}
		class_ref = IntPtr.Zero;
		base.Dispose(disposing);
	}

	public ISessionProcessorInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetAbortCapture_IHandler()
	{
		if ((object)cb_abortCapture_I == null)
		{
			cb_abortCapture_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_AbortCapture_I));
		}
		return cb_abortCapture_I;
	}

	private static void n_AbortCapture_I(nint jnienv, nint native__this, int p0)
	{
		Java.Lang.Object.GetObject<ISessionProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AbortCapture(p0);
	}

	public unsafe void AbortCapture(int p0)
	{
		if (id_abortCapture_I == IntPtr.Zero)
		{
			id_abortCapture_I = JNIEnv.GetMethodID(class_ref, "abortCapture", "(I)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		JNIEnv.CallVoidMethod(base.Handle, id_abortCapture_I, ptr);
	}

	private static Delegate GetDeInitSessionHandler()
	{
		if ((object)cb_deInitSession == null)
		{
			cb_deInitSession = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_DeInitSession));
		}
		return cb_deInitSession;
	}

	private static void n_DeInitSession(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ISessionProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeInitSession();
	}

	public void DeInitSession()
	{
		if (id_deInitSession == IntPtr.Zero)
		{
			id_deInitSession = JNIEnv.GetMethodID(class_ref, "deInitSession", "()V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_deInitSession);
	}

	private static Delegate GetInitSession_Landroidx_camera_core_CameraInfo_Landroidx_camera_core_impl_OutputSurfaceConfiguration_Handler()
	{
		if ((object)cb_initSession_Landroidx_camera_core_CameraInfo_Landroidx_camera_core_impl_OutputSurfaceConfiguration_ == null)
		{
			cb_initSession_Landroidx_camera_core_CameraInfo_Landroidx_camera_core_impl_OutputSurfaceConfiguration_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_InitSession_Landroidx_camera_core_CameraInfo_Landroidx_camera_core_impl_OutputSurfaceConfiguration_));
		}
		return cb_initSession_Landroidx_camera_core_CameraInfo_Landroidx_camera_core_impl_OutputSurfaceConfiguration_;
	}

	private static nint n_InitSession_Landroidx_camera_core_CameraInfo_Landroidx_camera_core_impl_OutputSurfaceConfiguration_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		ISessionProcessor? sessionProcessor = Java.Lang.Object.GetObject<ISessionProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICameraInfo p = Java.Lang.Object.GetObject<ICameraInfo>(native_p0, JniHandleOwnership.DoNotTransfer);
		OutputSurfaceConfiguration p2 = Java.Lang.Object.GetObject<OutputSurfaceConfiguration>(native_p1, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(sessionProcessor.InitSession(p, p2));
	}

	public unsafe SessionConfig InitSession(ICameraInfo p0, OutputSurfaceConfiguration p1)
	{
		if (id_initSession_Landroidx_camera_core_CameraInfo_Landroidx_camera_core_impl_OutputSurfaceConfiguration_ == IntPtr.Zero)
		{
			id_initSession_Landroidx_camera_core_CameraInfo_Landroidx_camera_core_impl_OutputSurfaceConfiguration_ = JNIEnv.GetMethodID(class_ref, "initSession", "(Landroidx/camera/core/CameraInfo;Landroidx/camera/core/impl/OutputSurfaceConfiguration;)Landroidx/camera/core/impl/SessionConfig;");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<SessionConfig>(JNIEnv.CallObjectMethod(base.Handle, id_initSession_Landroidx_camera_core_CameraInfo_Landroidx_camera_core_impl_OutputSurfaceConfiguration_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnCaptureSessionEndHandler()
	{
		if ((object)cb_onCaptureSessionEnd == null)
		{
			cb_onCaptureSessionEnd = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnCaptureSessionEnd));
		}
		return cb_onCaptureSessionEnd;
	}

	private static void n_OnCaptureSessionEnd(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ISessionProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureSessionEnd();
	}

	public void OnCaptureSessionEnd()
	{
		if (id_onCaptureSessionEnd == IntPtr.Zero)
		{
			id_onCaptureSessionEnd = JNIEnv.GetMethodID(class_ref, "onCaptureSessionEnd", "()V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_onCaptureSessionEnd);
	}

	private static Delegate GetOnCaptureSessionStart_Landroidx_camera_core_impl_RequestProcessor_Handler()
	{
		if ((object)cb_onCaptureSessionStart_Landroidx_camera_core_impl_RequestProcessor_ == null)
		{
			cb_onCaptureSessionStart_Landroidx_camera_core_impl_RequestProcessor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCaptureSessionStart_Landroidx_camera_core_impl_RequestProcessor_));
		}
		return cb_onCaptureSessionStart_Landroidx_camera_core_impl_RequestProcessor_;
	}

	private static void n_OnCaptureSessionStart_Landroidx_camera_core_impl_RequestProcessor_(nint jnienv, nint native__this, nint native_p0)
	{
		ISessionProcessor? sessionProcessor = Java.Lang.Object.GetObject<ISessionProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRequestProcessor p = Java.Lang.Object.GetObject<IRequestProcessor>(native_p0, JniHandleOwnership.DoNotTransfer);
		sessionProcessor.OnCaptureSessionStart(p);
	}

	public unsafe void OnCaptureSessionStart(IRequestProcessor p0)
	{
		if (id_onCaptureSessionStart_Landroidx_camera_core_impl_RequestProcessor_ == IntPtr.Zero)
		{
			id_onCaptureSessionStart_Landroidx_camera_core_impl_RequestProcessor_ = JNIEnv.GetMethodID(class_ref, "onCaptureSessionStart", "(Landroidx/camera/core/impl/RequestProcessor;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		JNIEnv.CallVoidMethod(base.Handle, id_onCaptureSessionStart_Landroidx_camera_core_impl_RequestProcessor_, ptr);
	}

	private static Delegate GetSetParameters_Landroidx_camera_core_impl_Config_Handler()
	{
		if ((object)cb_setParameters_Landroidx_camera_core_impl_Config_ == null)
		{
			cb_setParameters_Landroidx_camera_core_impl_Config_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetParameters_Landroidx_camera_core_impl_Config_));
		}
		return cb_setParameters_Landroidx_camera_core_impl_Config_;
	}

	private static void n_SetParameters_Landroidx_camera_core_impl_Config_(nint jnienv, nint native__this, nint native_p0)
	{
		ISessionProcessor? sessionProcessor = Java.Lang.Object.GetObject<ISessionProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IConfig parameters = Java.Lang.Object.GetObject<IConfig>(native_p0, JniHandleOwnership.DoNotTransfer);
		sessionProcessor.SetParameters(parameters);
	}

	public unsafe void SetParameters(IConfig p0)
	{
		if (id_setParameters_Landroidx_camera_core_impl_Config_ == IntPtr.Zero)
		{
			id_setParameters_Landroidx_camera_core_impl_Config_ = JNIEnv.GetMethodID(class_ref, "setParameters", "(Landroidx/camera/core/impl/Config;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		JNIEnv.CallVoidMethod(base.Handle, id_setParameters_Landroidx_camera_core_impl_Config_, ptr);
	}

	private static Delegate GetStartCapture_ZLandroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_Handler()
	{
		if ((object)cb_startCapture_ZLandroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_ == null)
		{
			cb_startCapture_ZLandroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZLL_I(n_StartCapture_ZLandroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_));
		}
		return cb_startCapture_ZLandroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_;
	}

	private static int n_StartCapture_ZLandroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_(nint jnienv, nint native__this, bool p0, nint native_p1, nint native_p2)
	{
		ISessionProcessor? sessionProcessor = Java.Lang.Object.GetObject<ISessionProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		TagBundle p1 = Java.Lang.Object.GetObject<TagBundle>(native_p1, JniHandleOwnership.DoNotTransfer);
		ISessionProcessorCaptureCallback p2 = Java.Lang.Object.GetObject<ISessionProcessorCaptureCallback>(native_p2, JniHandleOwnership.DoNotTransfer);
		return sessionProcessor.StartCapture(p0, p1, p2);
	}

	public unsafe int StartCapture(bool p0, TagBundle p1, ISessionProcessorCaptureCallback p2)
	{
		if (id_startCapture_ZLandroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_ == IntPtr.Zero)
		{
			id_startCapture_ZLandroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_ = JNIEnv.GetMethodID(class_ref, "startCapture", "(ZLandroidx/camera/core/impl/TagBundle;Landroidx/camera/core/impl/SessionProcessor$CaptureCallback;)I");
		}
		JValue* ptr = stackalloc JValue[3];
		*ptr = new JValue(p0);
		ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
		ptr[2] = new JValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
		return JNIEnv.CallIntMethod(base.Handle, id_startCapture_ZLandroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_, ptr);
	}

	private static Delegate GetStartRepeating_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_Handler()
	{
		if ((object)cb_startRepeating_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_ == null)
		{
			cb_startRepeating_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_I(n_StartRepeating_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_));
		}
		return cb_startRepeating_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_;
	}

	private static int n_StartRepeating_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		ISessionProcessor? sessionProcessor = Java.Lang.Object.GetObject<ISessionProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		TagBundle p = Java.Lang.Object.GetObject<TagBundle>(native_p0, JniHandleOwnership.DoNotTransfer);
		ISessionProcessorCaptureCallback p2 = Java.Lang.Object.GetObject<ISessionProcessorCaptureCallback>(native_p1, JniHandleOwnership.DoNotTransfer);
		return sessionProcessor.StartRepeating(p, p2);
	}

	public unsafe int StartRepeating(TagBundle p0, ISessionProcessorCaptureCallback p1)
	{
		if (id_startRepeating_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_ == IntPtr.Zero)
		{
			id_startRepeating_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_ = JNIEnv.GetMethodID(class_ref, "startRepeating", "(Landroidx/camera/core/impl/TagBundle;Landroidx/camera/core/impl/SessionProcessor$CaptureCallback;)I");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
		return JNIEnv.CallIntMethod(base.Handle, id_startRepeating_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_, ptr);
	}

	private static Delegate GetStopRepeatingHandler()
	{
		if ((object)cb_stopRepeating == null)
		{
			cb_stopRepeating = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_StopRepeating));
		}
		return cb_stopRepeating;
	}

	private static void n_StopRepeating(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ISessionProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopRepeating();
	}

	public void StopRepeating()
	{
		if (id_stopRepeating == IntPtr.Zero)
		{
			id_stopRepeating = JNIEnv.GetMethodID(class_ref, "stopRepeating", "()V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_stopRepeating);
	}
}
