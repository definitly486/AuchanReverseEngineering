using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using AndroidX.Camera.Core.Impl;
using AndroidX.Core.Util;
using Google.Common.Util.Concurrent;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Processing;

[Register("androidx/camera/core/processing/SurfaceEdge", DoNotGenerateAcw = true)]
public class SurfaceEdge : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/processing/SurfaceEdge", typeof(SurfaceEdge));

	private static Delegate? cb_getCropRect;

	private static Delegate? cb_getDeferrableSurface;

	private static Delegate? cb_getDeferrableSurfaceForTesting;

	private static Delegate? cb_getFormat;

	private static Delegate? cb_hasCameraTransform;

	private static Delegate? cb_hasProvider;

	private static Delegate? cb_isClosed;

	private static Delegate? cb_isMirroring;

	private static Delegate? cb_getRotationDegrees;

	private static Delegate? cb_getSensorToBufferTransform;

	private static Delegate? cb_getStreamSpec;

	private static Delegate? cb_getTargets;

	private static Delegate? cb_addOnInvalidatedListener_Ljava_lang_Runnable_;

	private static Delegate? cb_addTransformationUpdateListener_Landroidx_core_util_Consumer_;

	private static Delegate? cb_createSurfaceOutputFuture_ILandroidx_camera_core_SurfaceOutput_CameraInputInfo_Landroidx_camera_core_SurfaceOutput_CameraInputInfo_;

	private static Delegate? cb_createSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_;

	private static Delegate? cb_createSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_Z;

	private static Delegate? cb_invalidate;

	private static Delegate? cb_removeTransformationUpdateListener_Landroidx_core_util_Consumer_;

	private static Delegate? cb_setProvider_Landroidx_camera_core_impl_DeferrableSurface_;

	private static Delegate? cb_updateTransformation_I;

	private static Delegate? cb_updateTransformation_II;

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

	public unsafe virtual Rect CropRect
	{
		[Register("getCropRect", "()Landroid/graphics/Rect;", "GetGetCropRectHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Rect>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCropRect.()Landroid/graphics/Rect;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual DeferrableSurface DeferrableSurface
	{
		[Register("getDeferrableSurface", "()Landroidx/camera/core/impl/DeferrableSurface;", "GetGetDeferrableSurfaceHandler")]
		get
		{
			return Java.Lang.Object.GetObject<DeferrableSurface>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDeferrableSurface.()Landroidx/camera/core/impl/DeferrableSurface;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual DeferrableSurface DeferrableSurfaceForTesting
	{
		[Register("getDeferrableSurfaceForTesting", "()Landroidx/camera/core/impl/DeferrableSurface;", "GetGetDeferrableSurfaceForTestingHandler")]
		get
		{
			return Java.Lang.Object.GetObject<DeferrableSurface>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDeferrableSurfaceForTesting.()Landroidx/camera/core/impl/DeferrableSurface;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int Format
	{
		[Register("getFormat", "()I", "GetGetFormatHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getFormat.()I", this, null);
		}
	}

	public unsafe virtual bool HasCameraTransform
	{
		[Register("hasCameraTransform", "()Z", "GetHasCameraTransformHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasCameraTransform.()Z", this, null);
		}
	}

	public unsafe virtual bool HasProvider
	{
		[Register("hasProvider", "()Z", "GetHasProviderHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasProvider.()Z", this, null);
		}
	}

	public unsafe virtual bool IsClosed
	{
		[Register("isClosed", "()Z", "GetIsClosedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isClosed.()Z", this, null);
		}
	}

	public unsafe virtual bool IsMirroring
	{
		[Register("isMirroring", "()Z", "GetIsMirroringHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isMirroring.()Z", this, null);
		}
	}

	public unsafe virtual int RotationDegrees
	{
		[Register("getRotationDegrees", "()I", "GetGetRotationDegreesHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRotationDegrees.()I", this, null);
		}
	}

	public unsafe virtual Matrix SensorToBufferTransform
	{
		[Register("getSensorToBufferTransform", "()Landroid/graphics/Matrix;", "GetGetSensorToBufferTransformHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Matrix>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSensorToBufferTransform.()Landroid/graphics/Matrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual StreamSpec StreamSpec
	{
		[Register("getStreamSpec", "()Landroidx/camera/core/impl/StreamSpec;", "GetGetStreamSpecHandler")]
		get
		{
			return Java.Lang.Object.GetObject<StreamSpec>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStreamSpec.()Landroidx/camera/core/impl/StreamSpec;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int Targets
	{
		[Register("getTargets", "()I", "GetGetTargetsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTargets.()I", this, null);
		}
	}

	protected SurfaceEdge(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(IILandroidx/camera/core/impl/StreamSpec;Landroid/graphics/Matrix;ZLandroid/graphics/Rect;IIZ)V", "")]
	public unsafe SurfaceEdge(int targets, int format, StreamSpec streamSpec, Matrix sensorToBufferTransform, bool hasCameraTransform, Rect cropRect, int rotationDegrees, int targetRotation, bool mirroring)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
			*ptr = new JniArgumentValue(targets);
			ptr[1] = new JniArgumentValue(format);
			ptr[2] = new JniArgumentValue(streamSpec?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(sensorToBufferTransform?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(hasCameraTransform);
			ptr[5] = new JniArgumentValue(cropRect?.Handle ?? IntPtr.Zero);
			ptr[6] = new JniArgumentValue(rotationDegrees);
			ptr[7] = new JniArgumentValue(targetRotation);
			ptr[8] = new JniArgumentValue(mirroring);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(IILandroidx/camera/core/impl/StreamSpec;Landroid/graphics/Matrix;ZLandroid/graphics/Rect;IIZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(IILandroidx/camera/core/impl/StreamSpec;Landroid/graphics/Matrix;ZLandroid/graphics/Rect;IIZ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(streamSpec);
			GC.KeepAlive(sensorToBufferTransform);
			GC.KeepAlive(cropRect);
		}
	}

	private static Delegate GetGetCropRectHandler()
	{
		if ((object)cb_getCropRect == null)
		{
			cb_getCropRect = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCropRect));
		}
		return cb_getCropRect;
	}

	private static nint n_GetCropRect(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CropRect);
	}

	private static Delegate GetGetDeferrableSurfaceHandler()
	{
		if ((object)cb_getDeferrableSurface == null)
		{
			cb_getDeferrableSurface = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDeferrableSurface));
		}
		return cb_getDeferrableSurface;
	}

	private static nint n_GetDeferrableSurface(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeferrableSurface);
	}

	private static Delegate GetGetDeferrableSurfaceForTestingHandler()
	{
		if ((object)cb_getDeferrableSurfaceForTesting == null)
		{
			cb_getDeferrableSurfaceForTesting = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDeferrableSurfaceForTesting));
		}
		return cb_getDeferrableSurfaceForTesting;
	}

	private static nint n_GetDeferrableSurfaceForTesting(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeferrableSurfaceForTesting);
	}

	private static Delegate GetGetFormatHandler()
	{
		if ((object)cb_getFormat == null)
		{
			cb_getFormat = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetFormat));
		}
		return cb_getFormat;
	}

	private static int n_GetFormat(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Format;
	}

	private static Delegate GetHasCameraTransformHandler()
	{
		if ((object)cb_hasCameraTransform == null)
		{
			cb_hasCameraTransform = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasCameraTransform));
		}
		return cb_hasCameraTransform;
	}

	private static bool n_HasCameraTransform(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasCameraTransform;
	}

	private static Delegate GetHasProviderHandler()
	{
		if ((object)cb_hasProvider == null)
		{
			cb_hasProvider = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasProvider));
		}
		return cb_hasProvider;
	}

	private static bool n_HasProvider(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasProvider;
	}

	private static Delegate GetIsClosedHandler()
	{
		if ((object)cb_isClosed == null)
		{
			cb_isClosed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsClosed));
		}
		return cb_isClosed;
	}

	private static bool n_IsClosed(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsClosed;
	}

	private static Delegate GetIsMirroringHandler()
	{
		if ((object)cb_isMirroring == null)
		{
			cb_isMirroring = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsMirroring));
		}
		return cb_isMirroring;
	}

	private static bool n_IsMirroring(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsMirroring;
	}

	private static Delegate GetGetRotationDegreesHandler()
	{
		if ((object)cb_getRotationDegrees == null)
		{
			cb_getRotationDegrees = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRotationDegrees));
		}
		return cb_getRotationDegrees;
	}

	private static int n_GetRotationDegrees(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotationDegrees;
	}

	private static Delegate GetGetSensorToBufferTransformHandler()
	{
		if ((object)cb_getSensorToBufferTransform == null)
		{
			cb_getSensorToBufferTransform = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSensorToBufferTransform));
		}
		return cb_getSensorToBufferTransform;
	}

	private static nint n_GetSensorToBufferTransform(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SensorToBufferTransform);
	}

	private static Delegate GetGetStreamSpecHandler()
	{
		if ((object)cb_getStreamSpec == null)
		{
			cb_getStreamSpec = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStreamSpec));
		}
		return cb_getStreamSpec;
	}

	private static nint n_GetStreamSpec(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StreamSpec);
	}

	private static Delegate GetGetTargetsHandler()
	{
		if ((object)cb_getTargets == null)
		{
			cb_getTargets = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTargets));
		}
		return cb_getTargets;
	}

	private static int n_GetTargets(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Targets;
	}

	private static Delegate GetAddOnInvalidatedListener_Ljava_lang_Runnable_Handler()
	{
		if ((object)cb_addOnInvalidatedListener_Ljava_lang_Runnable_ == null)
		{
			cb_addOnInvalidatedListener_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddOnInvalidatedListener_Ljava_lang_Runnable_));
		}
		return cb_addOnInvalidatedListener_Ljava_lang_Runnable_;
	}

	private static void n_AddOnInvalidatedListener_Ljava_lang_Runnable_(nint jnienv, nint native__this, nint native_onInvalidated)
	{
		SurfaceEdge? surfaceEdge = Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRunnable onInvalidated = Java.Lang.Object.GetObject<IRunnable>(native_onInvalidated, JniHandleOwnership.DoNotTransfer);
		surfaceEdge.AddOnInvalidatedListener(onInvalidated);
	}

	[Register("addOnInvalidatedListener", "(Ljava/lang/Runnable;)V", "GetAddOnInvalidatedListener_Ljava_lang_Runnable_Handler")]
	public unsafe virtual void AddOnInvalidatedListener(IRunnable onInvalidated)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((onInvalidated == null) ? IntPtr.Zero : ((Java.Lang.Object)onInvalidated).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnInvalidatedListener.(Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(onInvalidated);
		}
	}

	private static Delegate GetAddTransformationUpdateListener_Landroidx_core_util_Consumer_Handler()
	{
		if ((object)cb_addTransformationUpdateListener_Landroidx_core_util_Consumer_ == null)
		{
			cb_addTransformationUpdateListener_Landroidx_core_util_Consumer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddTransformationUpdateListener_Landroidx_core_util_Consumer_));
		}
		return cb_addTransformationUpdateListener_Landroidx_core_util_Consumer_;
	}

	private static void n_AddTransformationUpdateListener_Landroidx_core_util_Consumer_(nint jnienv, nint native__this, nint native_consumer)
	{
		SurfaceEdge? surfaceEdge = Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IConsumer consumer = Java.Lang.Object.GetObject<IConsumer>(native_consumer, JniHandleOwnership.DoNotTransfer);
		surfaceEdge.AddTransformationUpdateListener(consumer);
	}

	[Register("addTransformationUpdateListener", "(Landroidx/core/util/Consumer;)V", "GetAddTransformationUpdateListener_Landroidx_core_util_Consumer_Handler")]
	public unsafe virtual void AddTransformationUpdateListener(IConsumer consumer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((consumer == null) ? IntPtr.Zero : ((Java.Lang.Object)consumer).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addTransformationUpdateListener.(Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(consumer);
		}
	}

	[Register("close", "()V", "")]
	public unsafe void Close()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("close.()V", this, null);
	}

	private static Delegate GetCreateSurfaceOutputFuture_ILandroidx_camera_core_SurfaceOutput_CameraInputInfo_Landroidx_camera_core_SurfaceOutput_CameraInputInfo_Handler()
	{
		if ((object)cb_createSurfaceOutputFuture_ILandroidx_camera_core_SurfaceOutput_CameraInputInfo_Landroidx_camera_core_SurfaceOutput_CameraInputInfo_ == null)
		{
			cb_createSurfaceOutputFuture_ILandroidx_camera_core_SurfaceOutput_CameraInputInfo_Landroidx_camera_core_SurfaceOutput_CameraInputInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILL_L(n_CreateSurfaceOutputFuture_ILandroidx_camera_core_SurfaceOutput_CameraInputInfo_Landroidx_camera_core_SurfaceOutput_CameraInputInfo_));
		}
		return cb_createSurfaceOutputFuture_ILandroidx_camera_core_SurfaceOutput_CameraInputInfo_Landroidx_camera_core_SurfaceOutput_CameraInputInfo_;
	}

	private static nint n_CreateSurfaceOutputFuture_ILandroidx_camera_core_SurfaceOutput_CameraInputInfo_Landroidx_camera_core_SurfaceOutput_CameraInputInfo_(nint jnienv, nint native__this, int format, nint native_cameraInputInfo, nint native_secondaryCameraInputInfo)
	{
		SurfaceEdge? surfaceEdge = Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SurfaceOutputCameraInputInfo cameraInputInfo = Java.Lang.Object.GetObject<SurfaceOutputCameraInputInfo>(native_cameraInputInfo, JniHandleOwnership.DoNotTransfer);
		SurfaceOutputCameraInputInfo secondaryCameraInputInfo = Java.Lang.Object.GetObject<SurfaceOutputCameraInputInfo>(native_secondaryCameraInputInfo, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(surfaceEdge.CreateSurfaceOutputFuture(format, cameraInputInfo, secondaryCameraInputInfo));
	}

	[Register("createSurfaceOutputFuture", "(ILandroidx/camera/core/SurfaceOutput$CameraInputInfo;Landroidx/camera/core/SurfaceOutput$CameraInputInfo;)Lcom/google/common/util/concurrent/ListenableFuture;", "GetCreateSurfaceOutputFuture_ILandroidx_camera_core_SurfaceOutput_CameraInputInfo_Landroidx_camera_core_SurfaceOutput_CameraInputInfo_Handler")]
	public unsafe virtual IListenableFuture CreateSurfaceOutputFuture(int format, SurfaceOutputCameraInputInfo cameraInputInfo, SurfaceOutputCameraInputInfo? secondaryCameraInputInfo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(format);
			ptr[1] = new JniArgumentValue(cameraInputInfo?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(secondaryCameraInputInfo?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeVirtualObjectMethod("createSurfaceOutputFuture.(ILandroidx/camera/core/SurfaceOutput$CameraInputInfo;Landroidx/camera/core/SurfaceOutput$CameraInputInfo;)Lcom/google/common/util/concurrent/ListenableFuture;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(cameraInputInfo);
			GC.KeepAlive(secondaryCameraInputInfo);
		}
	}

	private static Delegate GetCreateSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_Handler()
	{
		if ((object)cb_createSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_ == null)
		{
			cb_createSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CreateSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_));
		}
		return cb_createSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_;
	}

	private static nint n_CreateSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_(nint jnienv, nint native__this, nint native_cameraInternal)
	{
		SurfaceEdge? surfaceEdge = Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICameraInternal cameraInternal = Java.Lang.Object.GetObject<ICameraInternal>(native_cameraInternal, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(surfaceEdge.CreateSurfaceRequest(cameraInternal));
	}

	[Register("createSurfaceRequest", "(Landroidx/camera/core/impl/CameraInternal;)Landroidx/camera/core/SurfaceRequest;", "GetCreateSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_Handler")]
	public unsafe virtual SurfaceRequest CreateSurfaceRequest(ICameraInternal cameraInternal)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((cameraInternal == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraInternal).Handle);
			return Java.Lang.Object.GetObject<SurfaceRequest>(_members.InstanceMethods.InvokeVirtualObjectMethod("createSurfaceRequest.(Landroidx/camera/core/impl/CameraInternal;)Landroidx/camera/core/SurfaceRequest;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(cameraInternal);
		}
	}

	private static Delegate GetCreateSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_ZHandler()
	{
		if ((object)cb_createSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_Z == null)
		{
			cb_createSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZ_L(n_CreateSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_Z));
		}
		return cb_createSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_Z;
	}

	private static nint n_CreateSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_Z(nint jnienv, nint native__this, nint native_cameraInternal, bool isPrimary)
	{
		SurfaceEdge? surfaceEdge = Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICameraInternal cameraInternal = Java.Lang.Object.GetObject<ICameraInternal>(native_cameraInternal, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(surfaceEdge.CreateSurfaceRequest(cameraInternal, isPrimary));
	}

	[Register("createSurfaceRequest", "(Landroidx/camera/core/impl/CameraInternal;Z)Landroidx/camera/core/SurfaceRequest;", "GetCreateSurfaceRequest_Landroidx_camera_core_impl_CameraInternal_ZHandler")]
	public unsafe virtual SurfaceRequest CreateSurfaceRequest(ICameraInternal cameraInternal, bool isPrimary)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((cameraInternal == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraInternal).Handle);
			ptr[1] = new JniArgumentValue(isPrimary);
			return Java.Lang.Object.GetObject<SurfaceRequest>(_members.InstanceMethods.InvokeVirtualObjectMethod("createSurfaceRequest.(Landroidx/camera/core/impl/CameraInternal;Z)Landroidx/camera/core/SurfaceRequest;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(cameraInternal);
		}
	}

	[Register("disconnect", "()V", "")]
	public unsafe void Disconnect()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("disconnect.()V", this, null);
	}

	private static Delegate GetInvalidateHandler()
	{
		if ((object)cb_invalidate == null)
		{
			cb_invalidate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Invalidate));
		}
		return cb_invalidate;
	}

	private static void n_Invalidate(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Invalidate();
	}

	[Register("invalidate", "()V", "GetInvalidateHandler")]
	public unsafe virtual void Invalidate()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("invalidate.()V", this, null);
	}

	private static Delegate GetRemoveTransformationUpdateListener_Landroidx_core_util_Consumer_Handler()
	{
		if ((object)cb_removeTransformationUpdateListener_Landroidx_core_util_Consumer_ == null)
		{
			cb_removeTransformationUpdateListener_Landroidx_core_util_Consumer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveTransformationUpdateListener_Landroidx_core_util_Consumer_));
		}
		return cb_removeTransformationUpdateListener_Landroidx_core_util_Consumer_;
	}

	private static void n_RemoveTransformationUpdateListener_Landroidx_core_util_Consumer_(nint jnienv, nint native__this, nint native_consumer)
	{
		SurfaceEdge? surfaceEdge = Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IConsumer consumer = Java.Lang.Object.GetObject<IConsumer>(native_consumer, JniHandleOwnership.DoNotTransfer);
		surfaceEdge.RemoveTransformationUpdateListener(consumer);
	}

	[Register("removeTransformationUpdateListener", "(Landroidx/core/util/Consumer;)V", "GetRemoveTransformationUpdateListener_Landroidx_core_util_Consumer_Handler")]
	public unsafe virtual void RemoveTransformationUpdateListener(IConsumer consumer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((consumer == null) ? IntPtr.Zero : ((Java.Lang.Object)consumer).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeTransformationUpdateListener.(Landroidx/core/util/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(consumer);
		}
	}

	private static Delegate GetSetProvider_Landroidx_camera_core_impl_DeferrableSurface_Handler()
	{
		if ((object)cb_setProvider_Landroidx_camera_core_impl_DeferrableSurface_ == null)
		{
			cb_setProvider_Landroidx_camera_core_impl_DeferrableSurface_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetProvider_Landroidx_camera_core_impl_DeferrableSurface_));
		}
		return cb_setProvider_Landroidx_camera_core_impl_DeferrableSurface_;
	}

	private static void n_SetProvider_Landroidx_camera_core_impl_DeferrableSurface_(nint jnienv, nint native__this, nint native_provider)
	{
		SurfaceEdge? surfaceEdge = Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		DeferrableSurface provider = Java.Lang.Object.GetObject<DeferrableSurface>(native_provider, JniHandleOwnership.DoNotTransfer);
		surfaceEdge.SetProvider(provider);
	}

	[Register("setProvider", "(Landroidx/camera/core/impl/DeferrableSurface;)V", "GetSetProvider_Landroidx_camera_core_impl_DeferrableSurface_Handler")]
	public unsafe virtual void SetProvider(DeferrableSurface provider)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(provider?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setProvider.(Landroidx/camera/core/impl/DeferrableSurface;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(provider);
		}
	}

	private static Delegate GetUpdateTransformation_IHandler()
	{
		if ((object)cb_updateTransformation_I == null)
		{
			cb_updateTransformation_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_UpdateTransformation_I));
		}
		return cb_updateTransformation_I;
	}

	private static void n_UpdateTransformation_I(nint jnienv, nint native__this, int rotationDegrees)
	{
		Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UpdateTransformation(rotationDegrees);
	}

	[Register("updateTransformation", "(I)V", "GetUpdateTransformation_IHandler")]
	public unsafe virtual void UpdateTransformation(int rotationDegrees)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(rotationDegrees);
		_members.InstanceMethods.InvokeVirtualVoidMethod("updateTransformation.(I)V", this, ptr);
	}

	private static Delegate GetUpdateTransformation_IIHandler()
	{
		if ((object)cb_updateTransformation_II == null)
		{
			cb_updateTransformation_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_UpdateTransformation_II));
		}
		return cb_updateTransformation_II;
	}

	private static void n_UpdateTransformation_II(nint jnienv, nint native__this, int rotationDegrees, int targetRotation)
	{
		Java.Lang.Object.GetObject<SurfaceEdge>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UpdateTransformation(rotationDegrees, targetRotation);
	}

	[Register("updateTransformation", "(II)V", "GetUpdateTransformation_IIHandler")]
	public unsafe virtual void UpdateTransformation(int rotationDegrees, int targetRotation)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(rotationDegrees);
		ptr[1] = new JniArgumentValue(targetRotation);
		_members.InstanceMethods.InvokeVirtualVoidMethod("updateTransformation.(II)V", this, ptr);
	}
}
