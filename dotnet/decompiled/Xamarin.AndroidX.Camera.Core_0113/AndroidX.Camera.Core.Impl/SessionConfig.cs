using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Hardware.Camera2;
using Android.Hardware.Camera2.Params;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/SessionConfig", DoNotGenerateAcw = true)]
public sealed class SessionConfig : Java.Lang.Object
{
	[Register("androidx/camera/core/impl/SessionConfig$Builder", DoNotGenerateAcw = true)]
	public class Builder : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/SessionConfig$Builder", typeof(Builder));

		private static Delegate? cb_getSingleCameraCaptureCallbacks;

		private static Delegate? cb_addAllCameraCaptureCallbacks_Ljava_util_Collection_;

		private static Delegate? cb_addAllDeviceStateCallbacks_Ljava_util_Collection_;

		private static Delegate? cb_addAllRepeatingCameraCaptureCallbacks_Ljava_util_Collection_;

		private static Delegate? cb_addAllSessionStateCallbacks_Ljava_util_List_;

		private static Delegate? cb_addCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_;

		private static Delegate? cb_addDeviceStateCallback_Landroid_hardware_camera2_CameraDevice_StateCallback_;

		private static Delegate? cb_addImplementationOptions_Landroidx_camera_core_impl_Config_;

		private static Delegate? cb_addNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_;

		private static Delegate? cb_addNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_;

		private static Delegate? cb_addOutputConfig_Landroidx_camera_core_impl_SessionConfig_OutputConfig_;

		private static Delegate? cb_addRepeatingCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_;

		private static Delegate? cb_addSessionStateCallback_Landroid_hardware_camera2_CameraCaptureSession_StateCallback_;

		private static Delegate? cb_addSurface_Landroidx_camera_core_impl_DeferrableSurface_;

		private static Delegate? cb_addSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_Ljava_lang_String_I;

		private static Delegate? cb_addTag_Ljava_lang_String_Ljava_lang_Object_;

		private static Delegate? cb_build;

		private static Delegate? cb_clearSurfaces;

		private static Delegate? cb_removeCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_;

		private static Delegate? cb_removeSurface_Landroidx_camera_core_impl_DeferrableSurface_;

		private static Delegate? cb_setErrorListener_Landroidx_camera_core_impl_SessionConfig_ErrorListener_;

		private static Delegate? cb_setExpectedFrameRateRange_Landroid_util_Range_;

		private static Delegate? cb_setImplementationOptions_Landroidx_camera_core_impl_Config_;

		private static Delegate? cb_setInputConfiguration_Landroid_hardware_camera2_params_InputConfiguration_;

		private static Delegate? cb_setPostviewSurface_Landroidx_camera_core_impl_DeferrableSurface_;

		private static Delegate? cb_setPreviewStabilization_I;

		private static Delegate? cb_setSessionType_I;

		private static Delegate? cb_setTemplateType_I;

		private static Delegate? cb_setVideoStabilization_I;

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<CameraCaptureCallback> SingleCameraCaptureCallbacks
		{
			[Register("getSingleCameraCaptureCallbacks", "()Ljava/util/List;", "GetGetSingleCameraCaptureCallbacksHandler")]
			get
			{
				return JavaList<CameraCaptureCallback>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getSingleCameraCaptureCallbacks.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected Builder(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Builder()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetSingleCameraCaptureCallbacksHandler()
		{
			if ((object)cb_getSingleCameraCaptureCallbacks == null)
			{
				cb_getSingleCameraCaptureCallbacks = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSingleCameraCaptureCallbacks));
			}
			return cb_getSingleCameraCaptureCallbacks;
		}

		private static nint n_GetSingleCameraCaptureCallbacks(nint jnienv, nint native__this)
		{
			return JavaList<CameraCaptureCallback>.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SingleCameraCaptureCallbacks);
		}

		private static Delegate GetAddAllCameraCaptureCallbacks_Ljava_util_Collection_Handler()
		{
			if ((object)cb_addAllCameraCaptureCallbacks_Ljava_util_Collection_ == null)
			{
				cb_addAllCameraCaptureCallbacks_Ljava_util_Collection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddAllCameraCaptureCallbacks_Ljava_util_Collection_));
			}
			return cb_addAllCameraCaptureCallbacks_Ljava_util_Collection_;
		}

		private static nint n_AddAllCameraCaptureCallbacks_Ljava_util_Collection_(nint jnienv, nint native__this, nint native_cameraCaptureCallbacks)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICollection<CameraCaptureCallback> cameraCaptureCallbacks = JavaCollection<CameraCaptureCallback>.FromJniHandle(native_cameraCaptureCallbacks, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddAllCameraCaptureCallbacks(cameraCaptureCallbacks));
		}

		[Register("addAllCameraCaptureCallbacks", "(Ljava/util/Collection;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddAllCameraCaptureCallbacks_Ljava_util_Collection_Handler")]
		public unsafe virtual Builder AddAllCameraCaptureCallbacks(ICollection<CameraCaptureCallback> cameraCaptureCallbacks)
		{
			nint num = JavaCollection<CameraCaptureCallback>.ToLocalJniHandle(cameraCaptureCallbacks);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addAllCameraCaptureCallbacks.(Ljava/util/Collection;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(cameraCaptureCallbacks);
			}
		}

		private static Delegate GetAddAllDeviceStateCallbacks_Ljava_util_Collection_Handler()
		{
			if ((object)cb_addAllDeviceStateCallbacks_Ljava_util_Collection_ == null)
			{
				cb_addAllDeviceStateCallbacks_Ljava_util_Collection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddAllDeviceStateCallbacks_Ljava_util_Collection_));
			}
			return cb_addAllDeviceStateCallbacks_Ljava_util_Collection_;
		}

		private static nint n_AddAllDeviceStateCallbacks_Ljava_util_Collection_(nint jnienv, nint native__this, nint native_deviceStateCallbacks)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICollection<CameraDevice.StateCallback> deviceStateCallbacks = JavaCollection<CameraDevice.StateCallback>.FromJniHandle(native_deviceStateCallbacks, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddAllDeviceStateCallbacks(deviceStateCallbacks));
		}

		[Register("addAllDeviceStateCallbacks", "(Ljava/util/Collection;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddAllDeviceStateCallbacks_Ljava_util_Collection_Handler")]
		public unsafe virtual Builder AddAllDeviceStateCallbacks(ICollection<CameraDevice.StateCallback> deviceStateCallbacks)
		{
			nint num = JavaCollection<CameraDevice.StateCallback>.ToLocalJniHandle(deviceStateCallbacks);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addAllDeviceStateCallbacks.(Ljava/util/Collection;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(deviceStateCallbacks);
			}
		}

		private static Delegate GetAddAllRepeatingCameraCaptureCallbacks_Ljava_util_Collection_Handler()
		{
			if ((object)cb_addAllRepeatingCameraCaptureCallbacks_Ljava_util_Collection_ == null)
			{
				cb_addAllRepeatingCameraCaptureCallbacks_Ljava_util_Collection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddAllRepeatingCameraCaptureCallbacks_Ljava_util_Collection_));
			}
			return cb_addAllRepeatingCameraCaptureCallbacks_Ljava_util_Collection_;
		}

		private static nint n_AddAllRepeatingCameraCaptureCallbacks_Ljava_util_Collection_(nint jnienv, nint native__this, nint native_cameraCaptureCallbacks)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICollection<CameraCaptureCallback> cameraCaptureCallbacks = JavaCollection<CameraCaptureCallback>.FromJniHandle(native_cameraCaptureCallbacks, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddAllRepeatingCameraCaptureCallbacks(cameraCaptureCallbacks));
		}

		[Register("addAllRepeatingCameraCaptureCallbacks", "(Ljava/util/Collection;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddAllRepeatingCameraCaptureCallbacks_Ljava_util_Collection_Handler")]
		public unsafe virtual Builder AddAllRepeatingCameraCaptureCallbacks(ICollection<CameraCaptureCallback> cameraCaptureCallbacks)
		{
			nint num = JavaCollection<CameraCaptureCallback>.ToLocalJniHandle(cameraCaptureCallbacks);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addAllRepeatingCameraCaptureCallbacks.(Ljava/util/Collection;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(cameraCaptureCallbacks);
			}
		}

		private static Delegate GetAddAllSessionStateCallbacks_Ljava_util_List_Handler()
		{
			if ((object)cb_addAllSessionStateCallbacks_Ljava_util_List_ == null)
			{
				cb_addAllSessionStateCallbacks_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddAllSessionStateCallbacks_Ljava_util_List_));
			}
			return cb_addAllSessionStateCallbacks_Ljava_util_List_;
		}

		private static nint n_AddAllSessionStateCallbacks_Ljava_util_List_(nint jnienv, nint native__this, nint native_sessionStateCallbacks)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<CameraCaptureSession.StateCallback> sessionStateCallbacks = JavaList<CameraCaptureSession.StateCallback>.FromJniHandle(native_sessionStateCallbacks, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddAllSessionStateCallbacks(sessionStateCallbacks));
		}

		[Register("addAllSessionStateCallbacks", "(Ljava/util/List;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddAllSessionStateCallbacks_Ljava_util_List_Handler")]
		public unsafe virtual Builder AddAllSessionStateCallbacks(IList<CameraCaptureSession.StateCallback> sessionStateCallbacks)
		{
			nint num = JavaList<CameraCaptureSession.StateCallback>.ToLocalJniHandle(sessionStateCallbacks);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addAllSessionStateCallbacks.(Ljava/util/List;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(sessionStateCallbacks);
			}
		}

		private static Delegate GetAddCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_Handler()
		{
			if ((object)cb_addCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_ == null)
			{
				cb_addCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_));
			}
			return cb_addCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_;
		}

		private static nint n_AddCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_(nint jnienv, nint native__this, nint native_cameraCaptureCallback)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CameraCaptureCallback cameraCaptureCallback = Java.Lang.Object.GetObject<CameraCaptureCallback>(native_cameraCaptureCallback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddCameraCaptureCallback(cameraCaptureCallback));
		}

		[Register("addCameraCaptureCallback", "(Landroidx/camera/core/impl/CameraCaptureCallback;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_Handler")]
		public unsafe virtual Builder AddCameraCaptureCallback(CameraCaptureCallback cameraCaptureCallback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cameraCaptureCallback?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addCameraCaptureCallback.(Landroidx/camera/core/impl/CameraCaptureCallback;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cameraCaptureCallback);
			}
		}

		private static Delegate GetAddDeviceStateCallback_Landroid_hardware_camera2_CameraDevice_StateCallback_Handler()
		{
			if ((object)cb_addDeviceStateCallback_Landroid_hardware_camera2_CameraDevice_StateCallback_ == null)
			{
				cb_addDeviceStateCallback_Landroid_hardware_camera2_CameraDevice_StateCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddDeviceStateCallback_Landroid_hardware_camera2_CameraDevice_StateCallback_));
			}
			return cb_addDeviceStateCallback_Landroid_hardware_camera2_CameraDevice_StateCallback_;
		}

		private static nint n_AddDeviceStateCallback_Landroid_hardware_camera2_CameraDevice_StateCallback_(nint jnienv, nint native__this, nint native_deviceStateCallback)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CameraDevice.StateCallback deviceStateCallback = Java.Lang.Object.GetObject<CameraDevice.StateCallback>(native_deviceStateCallback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddDeviceStateCallback(deviceStateCallback));
		}

		[Register("addDeviceStateCallback", "(Landroid/hardware/camera2/CameraDevice$StateCallback;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddDeviceStateCallback_Landroid_hardware_camera2_CameraDevice_StateCallback_Handler")]
		public unsafe virtual Builder AddDeviceStateCallback(CameraDevice.StateCallback deviceStateCallback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(deviceStateCallback?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addDeviceStateCallback.(Landroid/hardware/camera2/CameraDevice$StateCallback;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(deviceStateCallback);
			}
		}

		private static Delegate GetAddImplementationOptions_Landroidx_camera_core_impl_Config_Handler()
		{
			if ((object)cb_addImplementationOptions_Landroidx_camera_core_impl_Config_ == null)
			{
				cb_addImplementationOptions_Landroidx_camera_core_impl_Config_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddImplementationOptions_Landroidx_camera_core_impl_Config_));
			}
			return cb_addImplementationOptions_Landroidx_camera_core_impl_Config_;
		}

		private static nint n_AddImplementationOptions_Landroidx_camera_core_impl_Config_(nint jnienv, nint native__this, nint native_config)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConfig config = Java.Lang.Object.GetObject<IConfig>(native_config, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddImplementationOptions(config));
		}

		[Register("addImplementationOptions", "(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddImplementationOptions_Landroidx_camera_core_impl_Config_Handler")]
		public unsafe virtual Builder AddImplementationOptions(IConfig config)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((config == null) ? IntPtr.Zero : ((Java.Lang.Object)config).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addImplementationOptions.(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(config);
			}
		}

		private static Delegate GetAddNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_Handler()
		{
			if ((object)cb_addNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_ == null)
			{
				cb_addNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_));
			}
			return cb_addNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_;
		}

		private static nint n_AddNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_(nint jnienv, nint native__this, nint native_surface)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DeferrableSurface surface = Java.Lang.Object.GetObject<DeferrableSurface>(native_surface, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddNonRepeatingSurface(surface));
		}

		[Register("addNonRepeatingSurface", "(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_Handler")]
		public unsafe virtual Builder AddNonRepeatingSurface(DeferrableSurface surface)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addNonRepeatingSurface.(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(surface);
			}
		}

		private static Delegate GetAddNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_Handler()
		{
			if ((object)cb_addNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_ == null)
			{
				cb_addNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_));
			}
			return cb_addNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_;
		}

		private static nint n_AddNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_(nint jnienv, nint native__this, nint native_surface, nint native_dynamicRange)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DeferrableSurface surface = Java.Lang.Object.GetObject<DeferrableSurface>(native_surface, JniHandleOwnership.DoNotTransfer);
			DynamicRange dynamicRange = Java.Lang.Object.GetObject<DynamicRange>(native_dynamicRange, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddNonRepeatingSurface(surface, dynamicRange));
		}

		[Register("addNonRepeatingSurface", "(Landroidx/camera/core/impl/DeferrableSurface;Landroidx/camera/core/DynamicRange;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddNonRepeatingSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_Handler")]
		public unsafe virtual Builder AddNonRepeatingSurface(DeferrableSurface surface, DynamicRange dynamicRange)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(dynamicRange?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addNonRepeatingSurface.(Landroidx/camera/core/impl/DeferrableSurface;Landroidx/camera/core/DynamicRange;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(surface);
				GC.KeepAlive(dynamicRange);
			}
		}

		private static Delegate GetAddOutputConfig_Landroidx_camera_core_impl_SessionConfig_OutputConfig_Handler()
		{
			if ((object)cb_addOutputConfig_Landroidx_camera_core_impl_SessionConfig_OutputConfig_ == null)
			{
				cb_addOutputConfig_Landroidx_camera_core_impl_SessionConfig_OutputConfig_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddOutputConfig_Landroidx_camera_core_impl_SessionConfig_OutputConfig_));
			}
			return cb_addOutputConfig_Landroidx_camera_core_impl_SessionConfig_OutputConfig_;
		}

		private static nint n_AddOutputConfig_Landroidx_camera_core_impl_SessionConfig_OutputConfig_(nint jnienv, nint native__this, nint native_outputConfig)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OutputConfig outputConfig = Java.Lang.Object.GetObject<OutputConfig>(native_outputConfig, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddOutputConfig(outputConfig));
		}

		[Register("addOutputConfig", "(Landroidx/camera/core/impl/SessionConfig$OutputConfig;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddOutputConfig_Landroidx_camera_core_impl_SessionConfig_OutputConfig_Handler")]
		public unsafe virtual Builder AddOutputConfig(OutputConfig outputConfig)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(outputConfig?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addOutputConfig.(Landroidx/camera/core/impl/SessionConfig$OutputConfig;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(outputConfig);
			}
		}

		private static Delegate GetAddRepeatingCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_Handler()
		{
			if ((object)cb_addRepeatingCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_ == null)
			{
				cb_addRepeatingCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddRepeatingCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_));
			}
			return cb_addRepeatingCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_;
		}

		private static nint n_AddRepeatingCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_(nint jnienv, nint native__this, nint native_cameraCaptureCallback)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CameraCaptureCallback cameraCaptureCallback = Java.Lang.Object.GetObject<CameraCaptureCallback>(native_cameraCaptureCallback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddRepeatingCameraCaptureCallback(cameraCaptureCallback));
		}

		[Register("addRepeatingCameraCaptureCallback", "(Landroidx/camera/core/impl/CameraCaptureCallback;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddRepeatingCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_Handler")]
		public unsafe virtual Builder AddRepeatingCameraCaptureCallback(CameraCaptureCallback cameraCaptureCallback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cameraCaptureCallback?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addRepeatingCameraCaptureCallback.(Landroidx/camera/core/impl/CameraCaptureCallback;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cameraCaptureCallback);
			}
		}

		private static Delegate GetAddSessionStateCallback_Landroid_hardware_camera2_CameraCaptureSession_StateCallback_Handler()
		{
			if ((object)cb_addSessionStateCallback_Landroid_hardware_camera2_CameraCaptureSession_StateCallback_ == null)
			{
				cb_addSessionStateCallback_Landroid_hardware_camera2_CameraCaptureSession_StateCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddSessionStateCallback_Landroid_hardware_camera2_CameraCaptureSession_StateCallback_));
			}
			return cb_addSessionStateCallback_Landroid_hardware_camera2_CameraCaptureSession_StateCallback_;
		}

		private static nint n_AddSessionStateCallback_Landroid_hardware_camera2_CameraCaptureSession_StateCallback_(nint jnienv, nint native__this, nint native_sessionStateCallback)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CameraCaptureSession.StateCallback sessionStateCallback = Java.Lang.Object.GetObject<CameraCaptureSession.StateCallback>(native_sessionStateCallback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddSessionStateCallback(sessionStateCallback));
		}

		[Register("addSessionStateCallback", "(Landroid/hardware/camera2/CameraCaptureSession$StateCallback;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddSessionStateCallback_Landroid_hardware_camera2_CameraCaptureSession_StateCallback_Handler")]
		public unsafe virtual Builder AddSessionStateCallback(CameraCaptureSession.StateCallback sessionStateCallback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(sessionStateCallback?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addSessionStateCallback.(Landroid/hardware/camera2/CameraCaptureSession$StateCallback;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sessionStateCallback);
			}
		}

		private static Delegate GetAddSurface_Landroidx_camera_core_impl_DeferrableSurface_Handler()
		{
			if ((object)cb_addSurface_Landroidx_camera_core_impl_DeferrableSurface_ == null)
			{
				cb_addSurface_Landroidx_camera_core_impl_DeferrableSurface_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddSurface_Landroidx_camera_core_impl_DeferrableSurface_));
			}
			return cb_addSurface_Landroidx_camera_core_impl_DeferrableSurface_;
		}

		private static nint n_AddSurface_Landroidx_camera_core_impl_DeferrableSurface_(nint jnienv, nint native__this, nint native_surface)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DeferrableSurface surface = Java.Lang.Object.GetObject<DeferrableSurface>(native_surface, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddSurface(surface));
		}

		[Register("addSurface", "(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddSurface_Landroidx_camera_core_impl_DeferrableSurface_Handler")]
		public unsafe virtual Builder AddSurface(DeferrableSurface surface)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addSurface.(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(surface);
			}
		}

		private static Delegate GetAddSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_Ljava_lang_String_IHandler()
		{
			if ((object)cb_addSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_Ljava_lang_String_I == null)
			{
				cb_addSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLI_L(n_AddSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_Ljava_lang_String_I));
			}
			return cb_addSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_Ljava_lang_String_I;
		}

		private static nint n_AddSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_Ljava_lang_String_I(nint jnienv, nint native__this, nint native_surface, nint native_dynamicRange, nint native_physicalCameraId, int mirrorMode)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DeferrableSurface surface = Java.Lang.Object.GetObject<DeferrableSurface>(native_surface, JniHandleOwnership.DoNotTransfer);
			DynamicRange dynamicRange = Java.Lang.Object.GetObject<DynamicRange>(native_dynamicRange, JniHandleOwnership.DoNotTransfer);
			string physicalCameraId = JNIEnv.GetString(native_physicalCameraId, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddSurface(surface, dynamicRange, physicalCameraId, mirrorMode));
		}

		[Register("addSurface", "(Landroidx/camera/core/impl/DeferrableSurface;Landroidx/camera/core/DynamicRange;Ljava/lang/String;I)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddSurface_Landroidx_camera_core_impl_DeferrableSurface_Landroidx_camera_core_DynamicRange_Ljava_lang_String_IHandler")]
		public unsafe virtual Builder AddSurface(DeferrableSurface surface, DynamicRange dynamicRange, string? physicalCameraId, int mirrorMode)
		{
			nint num = JNIEnv.NewString(physicalCameraId);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(dynamicRange?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(num);
				ptr[3] = new JniArgumentValue(mirrorMode);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addSurface.(Landroidx/camera/core/impl/DeferrableSurface;Landroidx/camera/core/DynamicRange;Ljava/lang/String;I)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(surface);
				GC.KeepAlive(dynamicRange);
			}
		}

		private static Delegate GetAddTag_Ljava_lang_String_Ljava_lang_Object_Handler()
		{
			if ((object)cb_addTag_Ljava_lang_String_Ljava_lang_Object_ == null)
			{
				cb_addTag_Ljava_lang_String_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddTag_Ljava_lang_String_Ljava_lang_Object_));
			}
			return cb_addTag_Ljava_lang_String_Ljava_lang_Object_;
		}

		private static nint n_AddTag_Ljava_lang_String_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_key, nint native_tag)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string key = JNIEnv.GetString(native_key, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object tag = Java.Lang.Object.GetObject<Java.Lang.Object>(native_tag, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.AddTag(key, tag));
		}

		[Register("addTag", "(Ljava/lang/String;Ljava/lang/Object;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetAddTag_Ljava_lang_String_Ljava_lang_Object_Handler")]
		public unsafe virtual Builder AddTag(string key, Java.Lang.Object tag)
		{
			nint num = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(num);
				ptr[1] = new JniArgumentValue(tag?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("addTag.(Ljava/lang/String;Ljava/lang/Object;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(tag);
			}
		}

		private static Delegate GetBuildHandler()
		{
			if ((object)cb_build == null)
			{
				cb_build = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
			}
			return cb_build;
		}

		private static nint n_Build(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
		}

		[Register("build", "()Landroidx/camera/core/impl/SessionConfig;", "GetBuildHandler")]
		public unsafe virtual SessionConfig Build()
		{
			return Java.Lang.Object.GetObject<SessionConfig>(_members.InstanceMethods.InvokeVirtualObjectMethod("build.()Landroidx/camera/core/impl/SessionConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetClearSurfacesHandler()
		{
			if ((object)cb_clearSurfaces == null)
			{
				cb_clearSurfaces = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ClearSurfaces));
			}
			return cb_clearSurfaces;
		}

		private static nint n_ClearSurfaces(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearSurfaces());
		}

		[Register("clearSurfaces", "()Landroidx/camera/core/impl/SessionConfig$Builder;", "GetClearSurfacesHandler")]
		public unsafe virtual Builder ClearSurfaces()
		{
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("clearSurfaces.()Landroidx/camera/core/impl/SessionConfig$Builder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("createFrom", "(Landroidx/camera/core/impl/UseCaseConfig;Landroid/util/Size;)Landroidx/camera/core/impl/SessionConfig$Builder;", "")]
		public unsafe static Builder CreateFrom(IUseCaseConfig config, Size resolution)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((config == null) ? IntPtr.Zero : ((Java.Lang.Object)config).Handle);
				ptr[1] = new JniArgumentValue(resolution?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("createFrom.(Landroidx/camera/core/impl/UseCaseConfig;Landroid/util/Size;)Landroidx/camera/core/impl/SessionConfig$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(config);
				GC.KeepAlive(resolution);
			}
		}

		private static Delegate GetRemoveCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_Handler()
		{
			if ((object)cb_removeCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_ == null)
			{
				cb_removeCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_RemoveCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_));
			}
			return cb_removeCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_;
		}

		private static bool n_RemoveCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_(nint jnienv, nint native__this, nint native_cameraCaptureCallback)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CameraCaptureCallback cameraCaptureCallback = Java.Lang.Object.GetObject<CameraCaptureCallback>(native_cameraCaptureCallback, JniHandleOwnership.DoNotTransfer);
			return builder.RemoveCameraCaptureCallback(cameraCaptureCallback);
		}

		[Register("removeCameraCaptureCallback", "(Landroidx/camera/core/impl/CameraCaptureCallback;)Z", "GetRemoveCameraCaptureCallback_Landroidx_camera_core_impl_CameraCaptureCallback_Handler")]
		public unsafe virtual bool RemoveCameraCaptureCallback(CameraCaptureCallback cameraCaptureCallback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cameraCaptureCallback?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("removeCameraCaptureCallback.(Landroidx/camera/core/impl/CameraCaptureCallback;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cameraCaptureCallback);
			}
		}

		private static Delegate GetRemoveSurface_Landroidx_camera_core_impl_DeferrableSurface_Handler()
		{
			if ((object)cb_removeSurface_Landroidx_camera_core_impl_DeferrableSurface_ == null)
			{
				cb_removeSurface_Landroidx_camera_core_impl_DeferrableSurface_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RemoveSurface_Landroidx_camera_core_impl_DeferrableSurface_));
			}
			return cb_removeSurface_Landroidx_camera_core_impl_DeferrableSurface_;
		}

		private static nint n_RemoveSurface_Landroidx_camera_core_impl_DeferrableSurface_(nint jnienv, nint native__this, nint native_surface)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DeferrableSurface surface = Java.Lang.Object.GetObject<DeferrableSurface>(native_surface, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.RemoveSurface(surface));
		}

		[Register("removeSurface", "(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetRemoveSurface_Landroidx_camera_core_impl_DeferrableSurface_Handler")]
		public unsafe virtual Builder RemoveSurface(DeferrableSurface surface)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("removeSurface.(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(surface);
			}
		}

		private static Delegate GetSetErrorListener_Landroidx_camera_core_impl_SessionConfig_ErrorListener_Handler()
		{
			if ((object)cb_setErrorListener_Landroidx_camera_core_impl_SessionConfig_ErrorListener_ == null)
			{
				cb_setErrorListener_Landroidx_camera_core_impl_SessionConfig_ErrorListener_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetErrorListener_Landroidx_camera_core_impl_SessionConfig_ErrorListener_));
			}
			return cb_setErrorListener_Landroidx_camera_core_impl_SessionConfig_ErrorListener_;
		}

		private static nint n_SetErrorListener_Landroidx_camera_core_impl_SessionConfig_ErrorListener_(nint jnienv, nint native__this, nint native_errorListener)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IErrorListener errorListener = Java.Lang.Object.GetObject<IErrorListener>(native_errorListener, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.SetErrorListener(errorListener));
		}

		[Register("setErrorListener", "(Landroidx/camera/core/impl/SessionConfig$ErrorListener;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetSetErrorListener_Landroidx_camera_core_impl_SessionConfig_ErrorListener_Handler")]
		public unsafe virtual Builder SetErrorListener(IErrorListener errorListener)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((errorListener == null) ? IntPtr.Zero : ((Java.Lang.Object)errorListener).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setErrorListener.(Landroidx/camera/core/impl/SessionConfig$ErrorListener;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(errorListener);
			}
		}

		private static Delegate GetSetExpectedFrameRateRange_Landroid_util_Range_Handler()
		{
			if ((object)cb_setExpectedFrameRateRange_Landroid_util_Range_ == null)
			{
				cb_setExpectedFrameRateRange_Landroid_util_Range_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetExpectedFrameRateRange_Landroid_util_Range_));
			}
			return cb_setExpectedFrameRateRange_Landroid_util_Range_;
		}

		private static nint n_SetExpectedFrameRateRange_Landroid_util_Range_(nint jnienv, nint native__this, nint native_expectedFrameRateRange)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Util.Range expectedFrameRateRange = Java.Lang.Object.GetObject<Android.Util.Range>(native_expectedFrameRateRange, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.SetExpectedFrameRateRange(expectedFrameRateRange));
		}

		[Register("setExpectedFrameRateRange", "(Landroid/util/Range;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetSetExpectedFrameRateRange_Landroid_util_Range_Handler")]
		public unsafe virtual Builder SetExpectedFrameRateRange(Android.Util.Range expectedFrameRateRange)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(expectedFrameRateRange?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setExpectedFrameRateRange.(Landroid/util/Range;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(expectedFrameRateRange);
			}
		}

		private static Delegate GetSetImplementationOptions_Landroidx_camera_core_impl_Config_Handler()
		{
			if ((object)cb_setImplementationOptions_Landroidx_camera_core_impl_Config_ == null)
			{
				cb_setImplementationOptions_Landroidx_camera_core_impl_Config_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetImplementationOptions_Landroidx_camera_core_impl_Config_));
			}
			return cb_setImplementationOptions_Landroidx_camera_core_impl_Config_;
		}

		private static nint n_SetImplementationOptions_Landroidx_camera_core_impl_Config_(nint jnienv, nint native__this, nint native_config)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConfig implementationOptions = Java.Lang.Object.GetObject<IConfig>(native_config, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.SetImplementationOptions(implementationOptions));
		}

		[Register("setImplementationOptions", "(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetSetImplementationOptions_Landroidx_camera_core_impl_Config_Handler")]
		public unsafe virtual Builder SetImplementationOptions(IConfig config)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((config == null) ? IntPtr.Zero : ((Java.Lang.Object)config).Handle);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setImplementationOptions.(Landroidx/camera/core/impl/Config;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(config);
			}
		}

		private static Delegate GetSetInputConfiguration_Landroid_hardware_camera2_params_InputConfiguration_Handler()
		{
			if ((object)cb_setInputConfiguration_Landroid_hardware_camera2_params_InputConfiguration_ == null)
			{
				cb_setInputConfiguration_Landroid_hardware_camera2_params_InputConfiguration_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetInputConfiguration_Landroid_hardware_camera2_params_InputConfiguration_));
			}
			return cb_setInputConfiguration_Landroid_hardware_camera2_params_InputConfiguration_;
		}

		private static nint n_SetInputConfiguration_Landroid_hardware_camera2_params_InputConfiguration_(nint jnienv, nint native__this, nint native_inputConfiguration)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			InputConfiguration inputConfiguration = Java.Lang.Object.GetObject<InputConfiguration>(native_inputConfiguration, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.SetInputConfiguration(inputConfiguration));
		}

		[Register("setInputConfiguration", "(Landroid/hardware/camera2/params/InputConfiguration;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetSetInputConfiguration_Landroid_hardware_camera2_params_InputConfiguration_Handler")]
		public unsafe virtual Builder SetInputConfiguration(InputConfiguration? inputConfiguration)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(inputConfiguration?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setInputConfiguration.(Landroid/hardware/camera2/params/InputConfiguration;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(inputConfiguration);
			}
		}

		private static Delegate GetSetPostviewSurface_Landroidx_camera_core_impl_DeferrableSurface_Handler()
		{
			if ((object)cb_setPostviewSurface_Landroidx_camera_core_impl_DeferrableSurface_ == null)
			{
				cb_setPostviewSurface_Landroidx_camera_core_impl_DeferrableSurface_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetPostviewSurface_Landroidx_camera_core_impl_DeferrableSurface_));
			}
			return cb_setPostviewSurface_Landroidx_camera_core_impl_DeferrableSurface_;
		}

		private static nint n_SetPostviewSurface_Landroidx_camera_core_impl_DeferrableSurface_(nint jnienv, nint native__this, nint native_surface)
		{
			Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DeferrableSurface postviewSurface = Java.Lang.Object.GetObject<DeferrableSurface>(native_surface, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(builder.SetPostviewSurface(postviewSurface));
		}

		[Register("setPostviewSurface", "(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetSetPostviewSurface_Landroidx_camera_core_impl_DeferrableSurface_Handler")]
		public unsafe virtual Builder SetPostviewSurface(DeferrableSurface surface)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPostviewSurface.(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(surface);
			}
		}

		private static Delegate GetSetPreviewStabilization_IHandler()
		{
			if ((object)cb_setPreviewStabilization_I == null)
			{
				cb_setPreviewStabilization_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetPreviewStabilization_I));
			}
			return cb_setPreviewStabilization_I;
		}

		private static nint n_SetPreviewStabilization_I(nint jnienv, nint native__this, int mode)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPreviewStabilization(mode));
		}

		[Register("setPreviewStabilization", "(I)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetSetPreviewStabilization_IHandler")]
		public unsafe virtual Builder SetPreviewStabilization(int mode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mode);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setPreviewStabilization.(I)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetSessionType_IHandler()
		{
			if ((object)cb_setSessionType_I == null)
			{
				cb_setSessionType_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetSessionType_I));
			}
			return cb_setSessionType_I;
		}

		private static nint n_SetSessionType_I(nint jnienv, nint native__this, int sessionType)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSessionType(sessionType));
		}

		[Register("setSessionType", "(I)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetSetSessionType_IHandler")]
		public unsafe virtual Builder SetSessionType(int sessionType)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(sessionType);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setSessionType.(I)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetTemplateType_IHandler()
		{
			if ((object)cb_setTemplateType_I == null)
			{
				cb_setTemplateType_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetTemplateType_I));
			}
			return cb_setTemplateType_I;
		}

		private static nint n_SetTemplateType_I(nint jnienv, nint native__this, int templateType)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTemplateType(templateType));
		}

		[Register("setTemplateType", "(I)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetSetTemplateType_IHandler")]
		public unsafe virtual Builder SetTemplateType(int templateType)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(templateType);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTemplateType.(I)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSetVideoStabilization_IHandler()
		{
			if ((object)cb_setVideoStabilization_I == null)
			{
				cb_setVideoStabilization_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetVideoStabilization_I));
			}
			return cb_setVideoStabilization_I;
		}

		private static nint n_SetVideoStabilization_I(nint jnienv, nint native__this, int mode)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVideoStabilization(mode));
		}

		[Register("setVideoStabilization", "(I)Landroidx/camera/core/impl/SessionConfig$Builder;", "GetSetVideoStabilization_IHandler")]
		public unsafe virtual Builder SetVideoStabilization(int mode)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mode);
			return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setVideoStabilization.(I)Landroidx/camera/core/impl/SessionConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[Register("androidx/camera/core/impl/SessionConfig$ErrorListener", "", "AndroidX.Camera.Core.Impl.SessionConfig/IErrorListenerInvoker")]
	public interface IErrorListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onError", "(Landroidx/camera/core/impl/SessionConfig;Landroidx/camera/core/impl/SessionConfig$SessionError;)V", "GetOnError_Landroidx_camera_core_impl_SessionConfig_Landroidx_camera_core_impl_SessionConfig_SessionError_Handler:AndroidX.Camera.Core.Impl.SessionConfig/IErrorListenerInvoker, Xamarin.AndroidX.Camera.Core")]
		void OnError(SessionConfig p0, SessionError p1);
	}

	[Register("androidx/camera/core/impl/SessionConfig$ErrorListener", DoNotGenerateAcw = true)]
	internal class IErrorListenerInvoker : Java.Lang.Object, IErrorListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/SessionConfig$ErrorListener", typeof(IErrorListenerInvoker));

		private nint class_ref;

		private static Delegate? cb_onError_Landroidx_camera_core_impl_SessionConfig_Landroidx_camera_core_impl_SessionConfig_SessionError_;

		private nint id_onError_Landroidx_camera_core_impl_SessionConfig_Landroidx_camera_core_impl_SessionConfig_SessionError_;

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

		public static IErrorListener? GetObject(nint handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IErrorListener>(handle, transfer);
		}

		private static nint Validate(nint handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.SessionConfig.ErrorListener'.");
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

		public IErrorListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			nint objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnError_Landroidx_camera_core_impl_SessionConfig_Landroidx_camera_core_impl_SessionConfig_SessionError_Handler()
		{
			if ((object)cb_onError_Landroidx_camera_core_impl_SessionConfig_Landroidx_camera_core_impl_SessionConfig_SessionError_ == null)
			{
				cb_onError_Landroidx_camera_core_impl_SessionConfig_Landroidx_camera_core_impl_SessionConfig_SessionError_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnError_Landroidx_camera_core_impl_SessionConfig_Landroidx_camera_core_impl_SessionConfig_SessionError_));
			}
			return cb_onError_Landroidx_camera_core_impl_SessionConfig_Landroidx_camera_core_impl_SessionConfig_SessionError_;
		}

		private static void n_OnError_Landroidx_camera_core_impl_SessionConfig_Landroidx_camera_core_impl_SessionConfig_SessionError_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
		{
			IErrorListener? errorListener = Java.Lang.Object.GetObject<IErrorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SessionConfig p = Java.Lang.Object.GetObject<SessionConfig>(native_p0, JniHandleOwnership.DoNotTransfer);
			SessionError p2 = Java.Lang.Object.GetObject<SessionError>(native_p1, JniHandleOwnership.DoNotTransfer);
			errorListener.OnError(p, p2);
		}

		public unsafe void OnError(SessionConfig p0, SessionError p1)
		{
			if (id_onError_Landroidx_camera_core_impl_SessionConfig_Landroidx_camera_core_impl_SessionConfig_SessionError_ == IntPtr.Zero)
			{
				id_onError_Landroidx_camera_core_impl_SessionConfig_Landroidx_camera_core_impl_SessionConfig_SessionError_ = JNIEnv.GetMethodID(class_ref, "onError", "(Landroidx/camera/core/impl/SessionConfig;Landroidx/camera/core/impl/SessionConfig$SessionError;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_onError_Landroidx_camera_core_impl_SessionConfig_Landroidx_camera_core_impl_SessionConfig_SessionError_, ptr);
		}
	}

	[Register("androidx/camera/core/impl/SessionConfig$OptionUnpacker", "", "AndroidX.Camera.Core.Impl.SessionConfig/IOptionUnpackerInvoker")]
	public interface IOptionUnpacker : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("unpack", "(Landroid/util/Size;Landroidx/camera/core/impl/UseCaseConfig;Landroidx/camera/core/impl/SessionConfig$Builder;)V", "GetUnpack_Landroid_util_Size_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_SessionConfig_Builder_Handler:AndroidX.Camera.Core.Impl.SessionConfig/IOptionUnpackerInvoker, Xamarin.AndroidX.Camera.Core")]
		void Unpack(Size p0, IUseCaseConfig p1, Builder p2);
	}

	[Register("androidx/camera/core/impl/SessionConfig$OptionUnpacker", DoNotGenerateAcw = true)]
	internal class IOptionUnpackerInvoker : Java.Lang.Object, IOptionUnpacker, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/SessionConfig$OptionUnpacker", typeof(IOptionUnpackerInvoker));

		private nint class_ref;

		private static Delegate? cb_unpack_Landroid_util_Size_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_SessionConfig_Builder_;

		private nint id_unpack_Landroid_util_Size_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_SessionConfig_Builder_;

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

		public static IOptionUnpacker? GetObject(nint handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOptionUnpacker>(handle, transfer);
		}

		private static nint Validate(nint handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.SessionConfig.OptionUnpacker'.");
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

		public IOptionUnpackerInvoker(nint handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			nint objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetUnpack_Landroid_util_Size_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_SessionConfig_Builder_Handler()
		{
			if ((object)cb_unpack_Landroid_util_Size_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_SessionConfig_Builder_ == null)
			{
				cb_unpack_Landroid_util_Size_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_SessionConfig_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_Unpack_Landroid_util_Size_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_SessionConfig_Builder_));
			}
			return cb_unpack_Landroid_util_Size_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_SessionConfig_Builder_;
		}

		private static void n_Unpack_Landroid_util_Size_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_SessionConfig_Builder_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
		{
			IOptionUnpacker? optionUnpacker = Java.Lang.Object.GetObject<IOptionUnpacker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Size p = Java.Lang.Object.GetObject<Size>(native_p0, JniHandleOwnership.DoNotTransfer);
			IUseCaseConfig p2 = Java.Lang.Object.GetObject<IUseCaseConfig>(native_p1, JniHandleOwnership.DoNotTransfer);
			Builder p3 = Java.Lang.Object.GetObject<Builder>(native_p2, JniHandleOwnership.DoNotTransfer);
			optionUnpacker.Unpack(p, p2, p3);
		}

		public unsafe void Unpack(Size p0, IUseCaseConfig p1, Builder p2)
		{
			if (id_unpack_Landroid_util_Size_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_SessionConfig_Builder_ == IntPtr.Zero)
			{
				id_unpack_Landroid_util_Size_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_SessionConfig_Builder_ = JNIEnv.GetMethodID(class_ref, "unpack", "(Landroid/util/Size;Landroidx/camera/core/impl/UseCaseConfig;Landroidx/camera/core/impl/SessionConfig$Builder;)V");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			ptr[2] = new JValue(p2?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_unpack_Landroid_util_Size_Landroidx_camera_core_impl_UseCaseConfig_Landroidx_camera_core_impl_SessionConfig_Builder_, ptr);
		}
	}

	[Register("androidx/camera/core/impl/SessionConfig$OutputConfig", DoNotGenerateAcw = true)]
	public abstract class OutputConfig : Java.Lang.Object
	{
		[Register("androidx/camera/core/impl/SessionConfig$OutputConfig$Builder", DoNotGenerateAcw = true)]
		public abstract class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/SessionConfig$OutputConfig$Builder", typeof(Builder));

			private static Delegate? cb_build;

			private static Delegate? cb_setDynamicRange_Landroidx_camera_core_DynamicRange_;

			private static Delegate? cb_setMirrorMode_I;

			private static Delegate? cb_setPhysicalCameraId_Ljava_lang_String_;

			private static Delegate? cb_setSharedSurfaces_Ljava_util_List_;

			private static Delegate? cb_setSurface_Landroidx_camera_core_impl_DeferrableSurface_;

			private static Delegate? cb_setSurfaceGroupId_I;

			internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			protected Builder(nint javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Builder()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle == IntPtr.Zero)
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetBuildHandler()
			{
				if ((object)cb_build == null)
				{
					cb_build = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Build));
				}
				return cb_build;
			}

			private static nint n_Build(nint jnienv, nint native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Build());
			}

			[Register("build", "()Landroidx/camera/core/impl/SessionConfig$OutputConfig;", "GetBuildHandler")]
			public abstract OutputConfig Build();

			private static Delegate GetSetDynamicRange_Landroidx_camera_core_DynamicRange_Handler()
			{
				if ((object)cb_setDynamicRange_Landroidx_camera_core_DynamicRange_ == null)
				{
					cb_setDynamicRange_Landroidx_camera_core_DynamicRange_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetDynamicRange_Landroidx_camera_core_DynamicRange_));
				}
				return cb_setDynamicRange_Landroidx_camera_core_DynamicRange_;
			}

			private static nint n_SetDynamicRange_Landroidx_camera_core_DynamicRange_(nint jnienv, nint native__this, nint native_p0)
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				DynamicRange dynamicRange = Java.Lang.Object.GetObject<DynamicRange>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetDynamicRange(dynamicRange));
			}

			[Register("setDynamicRange", "(Landroidx/camera/core/DynamicRange;)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", "GetSetDynamicRange_Landroidx_camera_core_DynamicRange_Handler")]
			public abstract Builder SetDynamicRange(DynamicRange p0);

			private static Delegate GetSetMirrorMode_IHandler()
			{
				if ((object)cb_setMirrorMode_I == null)
				{
					cb_setMirrorMode_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetMirrorMode_I));
				}
				return cb_setMirrorMode_I;
			}

			private static nint n_SetMirrorMode_I(nint jnienv, nint native__this, int p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMirrorMode(p0));
			}

			[Register("setMirrorMode", "(I)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", "GetSetMirrorMode_IHandler")]
			public abstract Builder SetMirrorMode(int p0);

			private static Delegate GetSetPhysicalCameraId_Ljava_lang_String_Handler()
			{
				if ((object)cb_setPhysicalCameraId_Ljava_lang_String_ == null)
				{
					cb_setPhysicalCameraId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetPhysicalCameraId_Ljava_lang_String_));
				}
				return cb_setPhysicalCameraId_Ljava_lang_String_;
			}

			private static nint n_SetPhysicalCameraId_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string physicalCameraId = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetPhysicalCameraId(physicalCameraId));
			}

			[Register("setPhysicalCameraId", "(Ljava/lang/String;)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", "GetSetPhysicalCameraId_Ljava_lang_String_Handler")]
			public abstract Builder SetPhysicalCameraId(string? p0);

			private static Delegate GetSetSharedSurfaces_Ljava_util_List_Handler()
			{
				if ((object)cb_setSharedSurfaces_Ljava_util_List_ == null)
				{
					cb_setSharedSurfaces_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSharedSurfaces_Ljava_util_List_));
				}
				return cb_setSharedSurfaces_Ljava_util_List_;
			}

			private static nint n_SetSharedSurfaces_Ljava_util_List_(nint jnienv, nint native__this, nint native_p0)
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IList<DeferrableSurface> sharedSurfaces = JavaList<DeferrableSurface>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetSharedSurfaces(sharedSurfaces));
			}

			[Register("setSharedSurfaces", "(Ljava/util/List;)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", "GetSetSharedSurfaces_Ljava_util_List_Handler")]
			public abstract Builder SetSharedSurfaces(IList<DeferrableSurface> p0);

			private static Delegate GetSetSurface_Landroidx_camera_core_impl_DeferrableSurface_Handler()
			{
				if ((object)cb_setSurface_Landroidx_camera_core_impl_DeferrableSurface_ == null)
				{
					cb_setSurface_Landroidx_camera_core_impl_DeferrableSurface_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetSurface_Landroidx_camera_core_impl_DeferrableSurface_));
				}
				return cb_setSurface_Landroidx_camera_core_impl_DeferrableSurface_;
			}

			private static nint n_SetSurface_Landroidx_camera_core_impl_DeferrableSurface_(nint jnienv, nint native__this, nint native_p0)
			{
				Builder? builder = Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				DeferrableSurface surface = Java.Lang.Object.GetObject<DeferrableSurface>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle(builder.SetSurface(surface));
			}

			[Register("setSurface", "(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", "GetSetSurface_Landroidx_camera_core_impl_DeferrableSurface_Handler")]
			public abstract Builder SetSurface(DeferrableSurface p0);

			private static Delegate GetSetSurfaceGroupId_IHandler()
			{
				if ((object)cb_setSurfaceGroupId_I == null)
				{
					cb_setSurfaceGroupId_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetSurfaceGroupId_I));
				}
				return cb_setSurfaceGroupId_I;
			}

			private static nint n_SetSurfaceGroupId_I(nint jnienv, nint native__this, int p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSurfaceGroupId(p0));
			}

			[Register("setSurfaceGroupId", "(I)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", "GetSetSurfaceGroupId_IHandler")]
			public abstract Builder SetSurfaceGroupId(int p0);
		}

		[Register("androidx/camera/core/impl/SessionConfig$OutputConfig$Builder", DoNotGenerateAcw = true)]
		internal class BuilderInvoker : Builder
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/SessionConfig$OutputConfig$Builder", typeof(BuilderInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public BuilderInvoker(nint handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			[Register("build", "()Landroidx/camera/core/impl/SessionConfig$OutputConfig;", "GetBuildHandler")]
			public unsafe override OutputConfig Build()
			{
				return Java.Lang.Object.GetObject<OutputConfig>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Landroidx/camera/core/impl/SessionConfig$OutputConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setDynamicRange", "(Landroidx/camera/core/DynamicRange;)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", "GetSetDynamicRange_Landroidx_camera_core_DynamicRange_Handler")]
			public unsafe override Builder SetDynamicRange(DynamicRange p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDynamicRange.(Landroidx/camera/core/DynamicRange;)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("setMirrorMode", "(I)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", "GetSetMirrorMode_IHandler")]
			public unsafe override Builder SetMirrorMode(int p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setMirrorMode.(I)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setPhysicalCameraId", "(Ljava/lang/String;)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", "GetSetPhysicalCameraId_Ljava_lang_String_Handler")]
			public unsafe override Builder SetPhysicalCameraId(string? p0)
			{
				nint num = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setPhysicalCameraId.(Ljava/lang/String;)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
				}
			}

			[Register("setSharedSurfaces", "(Ljava/util/List;)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", "GetSetSharedSurfaces_Ljava_util_List_Handler")]
			public unsafe override Builder SetSharedSurfaces(IList<DeferrableSurface> p0)
			{
				nint num = JavaList<DeferrableSurface>.ToLocalJniHandle(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(num);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSharedSurfaces.(Ljava/util/List;)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(num);
					GC.KeepAlive(p0);
				}
			}

			[Register("setSurface", "(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", "GetSetSurface_Landroidx_camera_core_impl_DeferrableSurface_Handler")]
			public unsafe override Builder SetSurface(DeferrableSurface p0)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSurface.(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(p0);
				}
			}

			[Register("setSurfaceGroupId", "(I)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", "GetSetSurfaceGroupId_IHandler")]
			public unsafe override Builder SetSurfaceGroupId(int p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setSurfaceGroupId.(I)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/SessionConfig$OutputConfig", typeof(OutputConfig));

		private static Delegate? cb_getDynamicRange;

		private static Delegate? cb_getMirrorMode;

		private static Delegate? cb_getPhysicalCameraId;

		private static Delegate? cb_getSharedSurfaces;

		private static Delegate? cb_getSurface;

		private static Delegate? cb_getSurfaceGroupId;

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public abstract DynamicRange DynamicRange
		{
			[Register("getDynamicRange", "()Landroidx/camera/core/DynamicRange;", "GetGetDynamicRangeHandler")]
			get;
		}

		public abstract int MirrorMode
		{
			[Register("getMirrorMode", "()I", "GetGetMirrorModeHandler")]
			get;
		}

		public abstract string? PhysicalCameraId
		{
			[Register("getPhysicalCameraId", "()Ljava/lang/String;", "GetGetPhysicalCameraIdHandler")]
			get;
		}

		public abstract IList<DeferrableSurface> SharedSurfaces
		{
			[Register("getSharedSurfaces", "()Ljava/util/List;", "GetGetSharedSurfacesHandler")]
			get;
		}

		public abstract DeferrableSurface Surface
		{
			[Register("getSurface", "()Landroidx/camera/core/impl/DeferrableSurface;", "GetGetSurfaceHandler")]
			get;
		}

		public abstract int SurfaceGroupId
		{
			[Register("getSurfaceGroupId", "()I", "GetGetSurfaceGroupIdHandler")]
			get;
		}

		protected OutputConfig(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OutputConfig()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetDynamicRangeHandler()
		{
			if ((object)cb_getDynamicRange == null)
			{
				cb_getDynamicRange = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDynamicRange));
			}
			return cb_getDynamicRange;
		}

		private static nint n_GetDynamicRange(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OutputConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DynamicRange);
		}

		private static Delegate GetGetMirrorModeHandler()
		{
			if ((object)cb_getMirrorMode == null)
			{
				cb_getMirrorMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMirrorMode));
			}
			return cb_getMirrorMode;
		}

		private static int n_GetMirrorMode(nint jnienv, nint native__this)
		{
			return Java.Lang.Object.GetObject<OutputConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MirrorMode;
		}

		private static Delegate GetGetPhysicalCameraIdHandler()
		{
			if ((object)cb_getPhysicalCameraId == null)
			{
				cb_getPhysicalCameraId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPhysicalCameraId));
			}
			return cb_getPhysicalCameraId;
		}

		private static nint n_GetPhysicalCameraId(nint jnienv, nint native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<OutputConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PhysicalCameraId);
		}

		private static Delegate GetGetSharedSurfacesHandler()
		{
			if ((object)cb_getSharedSurfaces == null)
			{
				cb_getSharedSurfaces = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSharedSurfaces));
			}
			return cb_getSharedSurfaces;
		}

		private static nint n_GetSharedSurfaces(nint jnienv, nint native__this)
		{
			return JavaList<DeferrableSurface>.ToLocalJniHandle(Java.Lang.Object.GetObject<OutputConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SharedSurfaces);
		}

		private static Delegate GetGetSurfaceHandler()
		{
			if ((object)cb_getSurface == null)
			{
				cb_getSurface = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSurface));
			}
			return cb_getSurface;
		}

		private static nint n_GetSurface(nint jnienv, nint native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<OutputConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Surface);
		}

		private static Delegate GetGetSurfaceGroupIdHandler()
		{
			if ((object)cb_getSurfaceGroupId == null)
			{
				cb_getSurfaceGroupId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetSurfaceGroupId));
			}
			return cb_getSurfaceGroupId;
		}

		private static int n_GetSurfaceGroupId(nint jnienv, nint native__this)
		{
			return Java.Lang.Object.GetObject<OutputConfig>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SurfaceGroupId;
		}

		[Register("builder", "(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", "")]
		public unsafe static Builder InvokeBuilder(DeferrableSurface surface)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(surface?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Builder>(_members.StaticMethods.InvokeObjectMethod("builder.(Landroidx/camera/core/impl/DeferrableSurface;)Landroidx/camera/core/impl/SessionConfig$OutputConfig$Builder;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(surface);
			}
		}
	}

	[Register("androidx/camera/core/impl/SessionConfig$OutputConfig", DoNotGenerateAcw = true)]
	internal class OutputConfigInvoker : OutputConfig
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/SessionConfig$OutputConfig", typeof(OutputConfigInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override DynamicRange DynamicRange
		{
			[Register("getDynamicRange", "()Landroidx/camera/core/DynamicRange;", "GetGetDynamicRangeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<DynamicRange>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDynamicRange.()Landroidx/camera/core/DynamicRange;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override int MirrorMode
		{
			[Register("getMirrorMode", "()I", "GetGetMirrorModeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMirrorMode.()I", this, null);
			}
		}

		public unsafe override string? PhysicalCameraId
		{
			[Register("getPhysicalCameraId", "()Ljava/lang/String;", "GetGetPhysicalCameraIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getPhysicalCameraId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override IList<DeferrableSurface> SharedSurfaces
		{
			[Register("getSharedSurfaces", "()Ljava/util/List;", "GetGetSharedSurfacesHandler")]
			get
			{
				return JavaList<DeferrableSurface>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getSharedSurfaces.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override DeferrableSurface Surface
		{
			[Register("getSurface", "()Landroidx/camera/core/impl/DeferrableSurface;", "GetGetSurfaceHandler")]
			get
			{
				return Java.Lang.Object.GetObject<DeferrableSurface>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSurface.()Landroidx/camera/core/impl/DeferrableSurface;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override int SurfaceGroupId
		{
			[Register("getSurfaceGroupId", "()I", "GetGetSurfaceGroupIdHandler")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getSurfaceGroupId.()I", this, null);
			}
		}

		public OutputConfigInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	[Register("androidx/camera/core/impl/SessionConfig$SessionError", DoNotGenerateAcw = true)]
	public sealed class SessionError : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/SessionConfig$SessionError", typeof(SessionError));

		[Register("SESSION_ERROR_SURFACE_NEEDS_RESET")]
		public static SessionError? SessionErrorSurfaceNeedsReset => Java.Lang.Object.GetObject<SessionError>(_members.StaticFields.GetObjectValue("SESSION_ERROR_SURFACE_NEEDS_RESET.Landroidx/camera/core/impl/SessionConfig$SessionError;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SESSION_ERROR_UNKNOWN")]
		public static SessionError? SessionErrorUnknown => Java.Lang.Object.GetObject<SessionError>(_members.StaticFields.GetObjectValue("SESSION_ERROR_UNKNOWN.Landroidx/camera/core/impl/SessionConfig$SessionError;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal SessionError(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/camera/core/impl/SessionConfig$SessionError;", "")]
		public unsafe static SessionError? ValueOf(string? name)
		{
			nint num = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				return Java.Lang.Object.GetObject<SessionError>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/camera/core/impl/SessionConfig$SessionError;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}

		[Register("values", "()[Landroidx/camera/core/impl/SessionConfig$SessionError;", "")]
		public unsafe static SessionError[]? Values()
		{
			return (SessionError[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/camera/core/impl/SessionConfig$SessionError;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(SessionError));
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/SessionConfig", typeof(SessionConfig));

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe IList<CameraDevice.StateCallback> DeviceStateCallbacks
	{
		[Register("getDeviceStateCallbacks", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<CameraDevice.StateCallback>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getDeviceStateCallbacks.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe IErrorListener? ErrorListener
	{
		[Register("getErrorListener", "()Landroidx/camera/core/impl/SessionConfig$ErrorListener;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IErrorListener>(_members.InstanceMethods.InvokeAbstractObjectMethod("getErrorListener.()Landroidx/camera/core/impl/SessionConfig$ErrorListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe Android.Util.Range ExpectedFrameRateRange
	{
		[Register("getExpectedFrameRateRange", "()Landroid/util/Range;", "")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Util.Range>(_members.InstanceMethods.InvokeAbstractObjectMethod("getExpectedFrameRateRange.()Landroid/util/Range;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe IConfig ImplementationOptions
	{
		[Register("getImplementationOptions", "()Landroidx/camera/core/impl/Config;", "")]
		get
		{
			return Java.Lang.Object.GetObject<IConfig>(_members.InstanceMethods.InvokeAbstractObjectMethod("getImplementationOptions.()Landroidx/camera/core/impl/Config;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe InputConfiguration? InputConfiguration
	{
		[Register("getInputConfiguration", "()Landroid/hardware/camera2/params/InputConfiguration;", "")]
		get
		{
			return Java.Lang.Object.GetObject<InputConfiguration>(_members.InstanceMethods.InvokeAbstractObjectMethod("getInputConfiguration.()Landroid/hardware/camera2/params/InputConfiguration;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe IList<OutputConfig> OutputConfigs
	{
		[Register("getOutputConfigs", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<OutputConfig>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getOutputConfigs.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe OutputConfig? PostviewOutputConfig
	{
		[Register("getPostviewOutputConfig", "()Landroidx/camera/core/impl/SessionConfig$OutputConfig;", "")]
		get
		{
			return Java.Lang.Object.GetObject<OutputConfig>(_members.InstanceMethods.InvokeAbstractObjectMethod("getPostviewOutputConfig.()Landroidx/camera/core/impl/SessionConfig$OutputConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe IList<CameraCaptureCallback> RepeatingCameraCaptureCallbacks
	{
		[Register("getRepeatingCameraCaptureCallbacks", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<CameraCaptureCallback>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getRepeatingCameraCaptureCallbacks.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe CaptureConfig RepeatingCaptureConfig
	{
		[Register("getRepeatingCaptureConfig", "()Landroidx/camera/core/impl/CaptureConfig;", "")]
		get
		{
			return Java.Lang.Object.GetObject<CaptureConfig>(_members.InstanceMethods.InvokeAbstractObjectMethod("getRepeatingCaptureConfig.()Landroidx/camera/core/impl/CaptureConfig;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe IList<CameraCaptureSession.StateCallback> SessionStateCallbacks
	{
		[Register("getSessionStateCallbacks", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<CameraCaptureSession.StateCallback>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getSessionStateCallbacks.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int SessionType
	{
		[Register("getSessionType", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSessionType.()I", this, null);
		}
	}

	public unsafe IList<CameraCaptureCallback> SingleCameraCaptureCallbacks
	{
		[Register("getSingleCameraCaptureCallbacks", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<CameraCaptureCallback>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getSingleCameraCaptureCallbacks.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe IList<DeferrableSurface> Surfaces
	{
		[Register("getSurfaces", "()Ljava/util/List;", "")]
		get
		{
			return JavaList<DeferrableSurface>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getSurfaces.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe int TemplateType
	{
		[Register("getTemplateType", "()I", "")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getTemplateType.()I", this, null);
		}
	}

	internal SessionConfig(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register("defaultEmptySessionConfig", "()Landroidx/camera/core/impl/SessionConfig;", "")]
	public unsafe static SessionConfig DefaultEmptySessionConfig()
	{
		return Java.Lang.Object.GetObject<SessionConfig>(_members.StaticMethods.InvokeObjectMethod("defaultEmptySessionConfig.()Landroidx/camera/core/impl/SessionConfig;", null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("getHigherPriorityTemplateType", "(II)I", "")]
	public unsafe static int GetHigherPriorityTemplateType(int type1, int type2)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(type1);
		ptr[1] = new JniArgumentValue(type2);
		return _members.StaticMethods.InvokeInt32Method("getHigherPriorityTemplateType.(II)I", ptr);
	}
}
