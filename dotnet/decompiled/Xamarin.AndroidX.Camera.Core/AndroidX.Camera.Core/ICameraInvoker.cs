using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Camera.Core.Impl;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/Camera", DoNotGenerateAcw = true)]
internal class ICameraInvoker : Java.Lang.Object, ICamera, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/Camera", typeof(ICameraInvoker));

	private nint class_ref;

	private static Delegate? cb_getCameraControl;

	private nint id_getCameraControl;

	private static Delegate? cb_getCameraInfo;

	private nint id_getCameraInfo;

	private static Delegate? cb_getExtendedConfig;

	private nint id_getExtendedConfig;

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

	public ICameraControl CameraControl
	{
		get
		{
			if (id_getCameraControl == IntPtr.Zero)
			{
				id_getCameraControl = JNIEnv.GetMethodID(class_ref, "getCameraControl", "()Landroidx/camera/core/CameraControl;");
			}
			return Java.Lang.Object.GetObject<ICameraControl>(JNIEnv.CallObjectMethod(base.Handle, id_getCameraControl), JniHandleOwnership.TransferLocalRef);
		}
	}

	public ICameraInfo CameraInfo
	{
		get
		{
			if (id_getCameraInfo == IntPtr.Zero)
			{
				id_getCameraInfo = JNIEnv.GetMethodID(class_ref, "getCameraInfo", "()Landroidx/camera/core/CameraInfo;");
			}
			return Java.Lang.Object.GetObject<ICameraInfo>(JNIEnv.CallObjectMethod(base.Handle, id_getCameraInfo), JniHandleOwnership.TransferLocalRef);
		}
	}

	public ICameraConfig ExtendedConfig
	{
		get
		{
			if (id_getExtendedConfig == IntPtr.Zero)
			{
				id_getExtendedConfig = JNIEnv.GetMethodID(class_ref, "getExtendedConfig", "()Landroidx/camera/core/impl/CameraConfig;");
			}
			return Java.Lang.Object.GetObject<ICameraConfig>(JNIEnv.CallObjectMethod(base.Handle, id_getExtendedConfig), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static ICamera? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ICamera>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.Camera'.");
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

	public ICameraInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetCameraControlHandler()
	{
		if ((object)cb_getCameraControl == null)
		{
			cb_getCameraControl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraControl));
		}
		return cb_getCameraControl;
	}

	private static nint n_GetCameraControl(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICamera>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraControl);
	}

	private static Delegate GetGetCameraInfoHandler()
	{
		if ((object)cb_getCameraInfo == null)
		{
			cb_getCameraInfo = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraInfo));
		}
		return cb_getCameraInfo;
	}

	private static nint n_GetCameraInfo(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICamera>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraInfo);
	}

	private static Delegate GetGetExtendedConfigHandler()
	{
		if ((object)cb_getExtendedConfig == null)
		{
			cb_getExtendedConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExtendedConfig));
		}
		return cb_getExtendedConfig;
	}

	private static nint n_GetExtendedConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICamera>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExtendedConfig);
	}
}
