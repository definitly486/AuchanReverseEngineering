using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Lifecycle;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/CameraInfo", DoNotGenerateAcw = true)]
internal class ICameraInfoInvoker : Java.Lang.Object, ICameraInfo, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/CameraInfo", typeof(ICameraInfoInvoker));

	private nint class_ref;

	private static Delegate? cb_getCameraSelector;

	private nint id_getCameraSelector;

	private static Delegate? cb_getCameraState;

	private nint id_getCameraState;

	private static Delegate? cb_getExposureState;

	private nint id_getExposureState;

	private static Delegate? cb_hasFlashUnit;

	private nint id_hasFlashUnit;

	private static Delegate? cb_getImplementationType;

	private nint id_getImplementationType;

	private static Delegate? cb_getSensorRotationDegrees;

	private nint id_getSensorRotationDegrees;

	private static Delegate? cb_getTorchState;

	private nint id_getTorchState;

	private static Delegate? cb_getZoomState;

	private nint id_getZoomState;

	private static Delegate? cb_getSensorRotationDegrees_I;

	private nint id_getSensorRotationDegrees_I;

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

	public CameraSelector CameraSelector
	{
		get
		{
			if (id_getCameraSelector == IntPtr.Zero)
			{
				id_getCameraSelector = JNIEnv.GetMethodID(class_ref, "getCameraSelector", "()Landroidx/camera/core/CameraSelector;");
			}
			return Java.Lang.Object.GetObject<CameraSelector>(JNIEnv.CallObjectMethod(base.Handle, id_getCameraSelector), JniHandleOwnership.TransferLocalRef);
		}
	}

	public LiveData CameraState
	{
		get
		{
			if (id_getCameraState == IntPtr.Zero)
			{
				id_getCameraState = JNIEnv.GetMethodID(class_ref, "getCameraState", "()Landroidx/lifecycle/LiveData;");
			}
			return Java.Lang.Object.GetObject<LiveData>(JNIEnv.CallObjectMethod(base.Handle, id_getCameraState), JniHandleOwnership.TransferLocalRef);
		}
	}

	public IExposureState ExposureState
	{
		get
		{
			if (id_getExposureState == IntPtr.Zero)
			{
				id_getExposureState = JNIEnv.GetMethodID(class_ref, "getExposureState", "()Landroidx/camera/core/ExposureState;");
			}
			return Java.Lang.Object.GetObject<IExposureState>(JNIEnv.CallObjectMethod(base.Handle, id_getExposureState), JniHandleOwnership.TransferLocalRef);
		}
	}

	public bool HasFlashUnit
	{
		get
		{
			if (id_hasFlashUnit == IntPtr.Zero)
			{
				id_hasFlashUnit = JNIEnv.GetMethodID(class_ref, "hasFlashUnit", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_hasFlashUnit);
		}
	}

	public string ImplementationType
	{
		get
		{
			if (id_getImplementationType == IntPtr.Zero)
			{
				id_getImplementationType = JNIEnv.GetMethodID(class_ref, "getImplementationType", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_getImplementationType), JniHandleOwnership.TransferLocalRef);
		}
	}

	public int SensorRotationDegrees
	{
		get
		{
			if (id_getSensorRotationDegrees == IntPtr.Zero)
			{
				id_getSensorRotationDegrees = JNIEnv.GetMethodID(class_ref, "getSensorRotationDegrees", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getSensorRotationDegrees);
		}
	}

	public LiveData TorchState
	{
		get
		{
			if (id_getTorchState == IntPtr.Zero)
			{
				id_getTorchState = JNIEnv.GetMethodID(class_ref, "getTorchState", "()Landroidx/lifecycle/LiveData;");
			}
			return Java.Lang.Object.GetObject<LiveData>(JNIEnv.CallObjectMethod(base.Handle, id_getTorchState), JniHandleOwnership.TransferLocalRef);
		}
	}

	public LiveData ZoomState
	{
		get
		{
			if (id_getZoomState == IntPtr.Zero)
			{
				id_getZoomState = JNIEnv.GetMethodID(class_ref, "getZoomState", "()Landroidx/lifecycle/LiveData;");
			}
			return Java.Lang.Object.GetObject<LiveData>(JNIEnv.CallObjectMethod(base.Handle, id_getZoomState), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static ICameraInfo? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ICameraInfo>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.CameraInfo'.");
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

	public ICameraInfoInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetCameraSelectorHandler()
	{
		if ((object)cb_getCameraSelector == null)
		{
			cb_getCameraSelector = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraSelector));
		}
		return cb_getCameraSelector;
	}

	private static nint n_GetCameraSelector(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraSelector);
	}

	private static Delegate GetGetCameraStateHandler()
	{
		if ((object)cb_getCameraState == null)
		{
			cb_getCameraState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraState));
		}
		return cb_getCameraState;
	}

	private static nint n_GetCameraState(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraState);
	}

	private static Delegate GetGetExposureStateHandler()
	{
		if ((object)cb_getExposureState == null)
		{
			cb_getExposureState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExposureState));
		}
		return cb_getExposureState;
	}

	private static nint n_GetExposureState(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExposureState);
	}

	private static Delegate GetHasFlashUnitHandler()
	{
		if ((object)cb_hasFlashUnit == null)
		{
			cb_hasFlashUnit = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasFlashUnit));
		}
		return cb_hasFlashUnit;
	}

	private static bool n_HasFlashUnit(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasFlashUnit;
	}

	private static Delegate GetGetImplementationTypeHandler()
	{
		if ((object)cb_getImplementationType == null)
		{
			cb_getImplementationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImplementationType));
		}
		return cb_getImplementationType;
	}

	private static nint n_GetImplementationType(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ImplementationType);
	}

	private static Delegate GetGetSensorRotationDegreesHandler()
	{
		if ((object)cb_getSensorRotationDegrees == null)
		{
			cb_getSensorRotationDegrees = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetSensorRotationDegrees));
		}
		return cb_getSensorRotationDegrees;
	}

	private static int n_GetSensorRotationDegrees(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SensorRotationDegrees;
	}

	private static Delegate GetGetTorchStateHandler()
	{
		if ((object)cb_getTorchState == null)
		{
			cb_getTorchState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTorchState));
		}
		return cb_getTorchState;
	}

	private static nint n_GetTorchState(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TorchState);
	}

	private static Delegate GetGetZoomStateHandler()
	{
		if ((object)cb_getZoomState == null)
		{
			cb_getZoomState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetZoomState));
		}
		return cb_getZoomState;
	}

	private static nint n_GetZoomState(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZoomState);
	}

	private static Delegate GetGetSensorRotationDegrees_IHandler()
	{
		if ((object)cb_getSensorRotationDegrees_I == null)
		{
			cb_getSensorRotationDegrees_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetSensorRotationDegrees_I));
		}
		return cb_getSensorRotationDegrees_I;
	}

	private static int n_GetSensorRotationDegrees_I(nint jnienv, nint native__this, int p0)
	{
		return Java.Lang.Object.GetObject<ICameraInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetSensorRotationDegrees(p0);
	}

	public unsafe int GetSensorRotationDegrees(int p0)
	{
		if (id_getSensorRotationDegrees_I == IntPtr.Zero)
		{
			id_getSensorRotationDegrees_I = JNIEnv.GetMethodID(class_ref, "getSensorRotationDegrees", "(I)I");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0);
		return JNIEnv.CallIntMethod(base.Handle, id_getSensorRotationDegrees_I, ptr);
	}
}
