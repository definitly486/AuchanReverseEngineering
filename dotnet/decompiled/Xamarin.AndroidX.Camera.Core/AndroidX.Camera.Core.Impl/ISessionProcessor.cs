using System;
using System.Collections.Generic;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/SessionProcessor", "", "AndroidX.Camera.Core.Impl.ISessionProcessorInvoker")]
public interface ISessionProcessor : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/SessionProcessor", typeof(ISessionProcessor), isInterface: true);

	private static Delegate? cb_getRealtimeCaptureLatency;

	private static Delegate? cb_getSupportedCameraOperations;

	private static Delegate? cb_getSupportedPostviewSize_Landroid_util_Size_;

	private static Delegate? cb_startTrigger_Landroidx_camera_core_impl_Config_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_;

	unsafe Pair? RealtimeCaptureLatency
	{
		[Register("getRealtimeCaptureLatency", "()Landroid/util/Pair;", "GetGetRealtimeCaptureLatencyHandler:AndroidX.Camera.Core.Impl.ISessionProcessor, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<Pair>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRealtimeCaptureLatency.()Landroid/util/Pair;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	unsafe ICollection<Integer> SupportedCameraOperations
	{
		[Register("getSupportedCameraOperations", "()Ljava/util/Set;", "GetGetSupportedCameraOperationsHandler:AndroidX.Camera.Core.Impl.ISessionProcessor, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return JavaSet<Integer>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportedCameraOperations.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static Delegate GetGetRealtimeCaptureLatencyHandler()
	{
		if ((object)cb_getRealtimeCaptureLatency == null)
		{
			cb_getRealtimeCaptureLatency = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRealtimeCaptureLatency));
		}
		return cb_getRealtimeCaptureLatency;
	}

	private static nint n_GetRealtimeCaptureLatency(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISessionProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RealtimeCaptureLatency);
	}

	private static Delegate GetGetSupportedCameraOperationsHandler()
	{
		if ((object)cb_getSupportedCameraOperations == null)
		{
			cb_getSupportedCameraOperations = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportedCameraOperations));
		}
		return cb_getSupportedCameraOperations;
	}

	private static nint n_GetSupportedCameraOperations(nint jnienv, nint native__this)
	{
		return JavaSet<Integer>.ToLocalJniHandle(Java.Lang.Object.GetObject<ISessionProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportedCameraOperations);
	}

	[Register("abortCapture", "(I)V", "GetAbortCapture_IHandler:AndroidX.Camera.Core.Impl.ISessionProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	void AbortCapture(int p0);

	[Register("deInitSession", "()V", "GetDeInitSessionHandler:AndroidX.Camera.Core.Impl.ISessionProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	void DeInitSession();

	[Register("initSession", "(Landroidx/camera/core/CameraInfo;Landroidx/camera/core/impl/OutputSurfaceConfiguration;)Landroidx/camera/core/impl/SessionConfig;", "GetInitSession_Landroidx_camera_core_CameraInfo_Landroidx_camera_core_impl_OutputSurfaceConfiguration_Handler:AndroidX.Camera.Core.Impl.ISessionProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	SessionConfig InitSession(ICameraInfo p0, OutputSurfaceConfiguration p1);

	[Register("onCaptureSessionEnd", "()V", "GetOnCaptureSessionEndHandler:AndroidX.Camera.Core.Impl.ISessionProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	void OnCaptureSessionEnd();

	[Register("onCaptureSessionStart", "(Landroidx/camera/core/impl/RequestProcessor;)V", "GetOnCaptureSessionStart_Landroidx_camera_core_impl_RequestProcessor_Handler:AndroidX.Camera.Core.Impl.ISessionProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	void OnCaptureSessionStart(IRequestProcessor p0);

	[Register("setParameters", "(Landroidx/camera/core/impl/Config;)V", "GetSetParameters_Landroidx_camera_core_impl_Config_Handler:AndroidX.Camera.Core.Impl.ISessionProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	void SetParameters(IConfig p0);

	[Register("startCapture", "(ZLandroidx/camera/core/impl/TagBundle;Landroidx/camera/core/impl/SessionProcessor$CaptureCallback;)I", "GetStartCapture_ZLandroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_Handler:AndroidX.Camera.Core.Impl.ISessionProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	int StartCapture(bool p0, TagBundle p1, ISessionProcessorCaptureCallback p2);

	[Register("startRepeating", "(Landroidx/camera/core/impl/TagBundle;Landroidx/camera/core/impl/SessionProcessor$CaptureCallback;)I", "GetStartRepeating_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_Handler:AndroidX.Camera.Core.Impl.ISessionProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	int StartRepeating(TagBundle p0, ISessionProcessorCaptureCallback p1);

	[Register("stopRepeating", "()V", "GetStopRepeatingHandler:AndroidX.Camera.Core.Impl.ISessionProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	void StopRepeating();

	private static Delegate GetGetSupportedPostviewSize_Landroid_util_Size_Handler()
	{
		if ((object)cb_getSupportedPostviewSize_Landroid_util_Size_ == null)
		{
			cb_getSupportedPostviewSize_Landroid_util_Size_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetSupportedPostviewSize_Landroid_util_Size_));
		}
		return cb_getSupportedPostviewSize_Landroid_util_Size_;
	}

	private static nint n_GetSupportedPostviewSize_Landroid_util_Size_(nint jnienv, nint native__this, nint native_captureSize)
	{
		ISessionProcessor? sessionProcessor = Java.Lang.Object.GetObject<ISessionProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Size captureSize = Java.Lang.Object.GetObject<Size>(native_captureSize, JniHandleOwnership.DoNotTransfer);
		return JavaDictionary<Integer, IList<Size>>.ToLocalJniHandle(sessionProcessor.GetSupportedPostviewSize(captureSize));
	}

	[Register("getSupportedPostviewSize", "(Landroid/util/Size;)Ljava/util/Map;", "GetGetSupportedPostviewSize_Landroid_util_Size_Handler:AndroidX.Camera.Core.Impl.ISessionProcessor, Xamarin.AndroidX.Camera.Core")]
	unsafe IDictionary<Integer, IList<Size>> GetSupportedPostviewSize(Size captureSize)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(captureSize?.Handle ?? IntPtr.Zero);
			return JavaDictionary<Integer, IList<Size>>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportedPostviewSize.(Landroid/util/Size;)Ljava/util/Map;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(captureSize);
		}
	}

	private static Delegate GetStartTrigger_Landroidx_camera_core_impl_Config_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_Handler()
	{
		if ((object)cb_startTrigger_Landroidx_camera_core_impl_Config_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_ == null)
		{
			cb_startTrigger_Landroidx_camera_core_impl_Config_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_I(n_StartTrigger_Landroidx_camera_core_impl_Config_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_));
		}
		return cb_startTrigger_Landroidx_camera_core_impl_Config_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_;
	}

	private static int n_StartTrigger_Landroidx_camera_core_impl_Config_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_(nint jnienv, nint native__this, nint native_config, nint native_tagBundle, nint native__callback)
	{
		ISessionProcessor? sessionProcessor = Java.Lang.Object.GetObject<ISessionProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IConfig config = Java.Lang.Object.GetObject<IConfig>(native_config, JniHandleOwnership.DoNotTransfer);
		TagBundle tagBundle = Java.Lang.Object.GetObject<TagBundle>(native_tagBundle, JniHandleOwnership.DoNotTransfer);
		ISessionProcessorCaptureCallback callback = Java.Lang.Object.GetObject<ISessionProcessorCaptureCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
		return sessionProcessor.StartTrigger(config, tagBundle, callback);
	}

	[Register("startTrigger", "(Landroidx/camera/core/impl/Config;Landroidx/camera/core/impl/TagBundle;Landroidx/camera/core/impl/SessionProcessor$CaptureCallback;)I", "GetStartTrigger_Landroidx_camera_core_impl_Config_Landroidx_camera_core_impl_TagBundle_Landroidx_camera_core_impl_SessionProcessor_CaptureCallback_Handler:AndroidX.Camera.Core.Impl.ISessionProcessor, Xamarin.AndroidX.Camera.Core")]
	unsafe int StartTrigger(IConfig config, TagBundle tagBundle, ISessionProcessorCaptureCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((config == null) ? IntPtr.Zero : ((Java.Lang.Object)config).Handle);
			ptr[1] = new JniArgumentValue(tagBundle?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return _members.InstanceMethods.InvokeVirtualInt32Method("startTrigger.(Landroidx/camera/core/impl/Config;Landroidx/camera/core/impl/TagBundle;Landroidx/camera/core/impl/SessionProcessor$CaptureCallback;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(config);
			GC.KeepAlive(tagBundle);
			GC.KeepAlive(callback);
		}
	}
}
