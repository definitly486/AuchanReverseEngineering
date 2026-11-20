using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Google.Common.Util.Concurrent;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/CameraControl", DoNotGenerateAcw = true)]
internal class ICameraControlInvoker : Java.Lang.Object, ICameraControl, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/CameraControl", typeof(ICameraControlInvoker));

	private nint class_ref;

	private static Delegate? cb_cancelFocusAndMetering;

	private nint id_cancelFocusAndMetering;

	private static Delegate? cb_enableTorch_Z;

	private nint id_enableTorch_Z;

	private static Delegate? cb_setExposureCompensationIndex_I;

	private nint id_setExposureCompensationIndex_I;

	private static Delegate? cb_setLinearZoom_F;

	private nint id_setLinearZoom_F;

	private static Delegate? cb_setZoomRatio_F;

	private nint id_setZoomRatio_F;

	private static Delegate? cb_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_;

	private nint id_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_;

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

	public static ICameraControl? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ICameraControl>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.CameraControl'.");
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

	public ICameraControlInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetCancelFocusAndMeteringHandler()
	{
		if ((object)cb_cancelFocusAndMetering == null)
		{
			cb_cancelFocusAndMetering = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CancelFocusAndMetering));
		}
		return cb_cancelFocusAndMetering;
	}

	private static nint n_CancelFocusAndMetering(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CancelFocusAndMetering());
	}

	public IListenableFuture CancelFocusAndMetering()
	{
		if (id_cancelFocusAndMetering == IntPtr.Zero)
		{
			id_cancelFocusAndMetering = JNIEnv.GetMethodID(class_ref, "cancelFocusAndMetering", "()Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_cancelFocusAndMetering), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetEnableTorch_ZHandler()
	{
		if ((object)cb_enableTorch_Z == null)
		{
			cb_enableTorch_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_L(n_EnableTorch_Z));
		}
		return cb_enableTorch_Z;
	}

	private static nint n_EnableTorch_Z(nint jnienv, nint native__this, bool p0)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnableTorch(p0));
	}

	public unsafe IListenableFuture EnableTorch(bool p0)
	{
		if (id_enableTorch_Z == IntPtr.Zero)
		{
			id_enableTorch_Z = JNIEnv.GetMethodID(class_ref, "enableTorch", "(Z)Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_enableTorch_Z, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetExposureCompensationIndex_IHandler()
	{
		if ((object)cb_setExposureCompensationIndex_I == null)
		{
			cb_setExposureCompensationIndex_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_SetExposureCompensationIndex_I));
		}
		return cb_setExposureCompensationIndex_I;
	}

	private static nint n_SetExposureCompensationIndex_I(nint jnienv, nint native__this, int p0)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetExposureCompensationIndex(p0));
	}

	public unsafe IListenableFuture SetExposureCompensationIndex(int p0)
	{
		if (id_setExposureCompensationIndex_I == IntPtr.Zero)
		{
			id_setExposureCompensationIndex_I = JNIEnv.GetMethodID(class_ref, "setExposureCompensationIndex", "(I)Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_setExposureCompensationIndex_I, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetLinearZoom_FHandler()
	{
		if ((object)cb_setLinearZoom_F == null)
		{
			cb_setLinearZoom_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_L(n_SetLinearZoom_F));
		}
		return cb_setLinearZoom_F;
	}

	private static nint n_SetLinearZoom_F(nint jnienv, nint native__this, float p0)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLinearZoom(p0));
	}

	public unsafe IListenableFuture SetLinearZoom(float p0)
	{
		if (id_setLinearZoom_F == IntPtr.Zero)
		{
			id_setLinearZoom_F = JNIEnv.GetMethodID(class_ref, "setLinearZoom", "(F)Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_setLinearZoom_F, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetZoomRatio_FHandler()
	{
		if ((object)cb_setZoomRatio_F == null)
		{
			cb_setZoomRatio_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_L(n_SetZoomRatio_F));
		}
		return cb_setZoomRatio_F;
	}

	private static nint n_SetZoomRatio_F(nint jnienv, nint native__this, float p0)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraControl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetZoomRatio(p0));
	}

	public unsafe IListenableFuture SetZoomRatio(float p0)
	{
		if (id_setZoomRatio_F == IntPtr.Zero)
		{
			id_setZoomRatio_F = JNIEnv.GetMethodID(class_ref, "setZoomRatio", "(F)Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_setZoomRatio_F, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetStartFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_Handler()
	{
		if ((object)cb_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_ == null)
		{
			cb_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_StartFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_));
		}
		return cb_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_;
	}

	private static nint n_StartFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_(nint jnienv, nint native__this, nint native_p0)
	{
		ICameraControl? cameraControl = Java.Lang.Object.GetObject<ICameraControl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		FocusMeteringAction p = Java.Lang.Object.GetObject<FocusMeteringAction>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(cameraControl.StartFocusAndMetering(p));
	}

	public unsafe IListenableFuture StartFocusAndMetering(FocusMeteringAction p0)
	{
		if (id_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_ == IntPtr.Zero)
		{
			id_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_ = JNIEnv.GetMethodID(class_ref, "startFocusAndMetering", "(Landroidx/camera/core/FocusMeteringAction;)Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_startFocusAndMetering_Landroidx_camera_core_FocusMeteringAction_, ptr), JniHandleOwnership.TransferLocalRef);
	}
}
