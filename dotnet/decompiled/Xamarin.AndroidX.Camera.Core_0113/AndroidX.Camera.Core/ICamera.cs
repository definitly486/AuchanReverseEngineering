using System;
using Android.Runtime;
using AndroidX.Camera.Core.Impl;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/Camera", "", "AndroidX.Camera.Core.ICameraInvoker")]
public interface ICamera : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/Camera", typeof(ICamera), isInterface: true);

	private static Delegate? cb_isUseCasesCombinationSupported_arrayLandroidx_camera_core_UseCase_;

	private static Delegate? cb_isUseCasesCombinationSupported_ZarrayLandroidx_camera_core_UseCase_;

	private static Delegate? cb_isUseCasesCombinationSupportedByFramework_arrayLandroidx_camera_core_UseCase_;

	ICameraControl CameraControl
	{
		[Register("getCameraControl", "()Landroidx/camera/core/CameraControl;", "GetGetCameraControlHandler:AndroidX.Camera.Core.ICameraInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	ICameraInfo CameraInfo
	{
		[Register("getCameraInfo", "()Landroidx/camera/core/CameraInfo;", "GetGetCameraInfoHandler:AndroidX.Camera.Core.ICameraInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	ICameraConfig ExtendedConfig
	{
		[Register("getExtendedConfig", "()Landroidx/camera/core/impl/CameraConfig;", "GetGetExtendedConfigHandler:AndroidX.Camera.Core.ICameraInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	private static Delegate GetIsUseCasesCombinationSupported_arrayLandroidx_camera_core_UseCase_Handler()
	{
		if ((object)cb_isUseCasesCombinationSupported_arrayLandroidx_camera_core_UseCase_ == null)
		{
			cb_isUseCasesCombinationSupported_arrayLandroidx_camera_core_UseCase_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsUseCasesCombinationSupported_arrayLandroidx_camera_core_UseCase_));
		}
		return cb_isUseCasesCombinationSupported_arrayLandroidx_camera_core_UseCase_;
	}

	private static bool n_IsUseCasesCombinationSupported_arrayLandroidx_camera_core_UseCase_(nint jnienv, nint native__this, nint native_useCases)
	{
		ICamera? camera = Java.Lang.Object.GetObject<ICamera>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		UseCase[] array = (UseCase[])JNIEnv.GetArray(native_useCases, JniHandleOwnership.DoNotTransfer, typeof(UseCase));
		bool result = camera.IsUseCasesCombinationSupported(array);
		if (array != null)
		{
			JNIEnv.CopyArray(array, native_useCases);
		}
		return result;
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("isUseCasesCombinationSupported", "([Landroidx/camera/core/UseCase;)Z", "GetIsUseCasesCombinationSupported_arrayLandroidx_camera_core_UseCase_Handler:AndroidX.Camera.Core.ICamera, Xamarin.AndroidX.Camera.Core")]
	unsafe bool IsUseCasesCombinationSupported(params UseCase[] useCases)
	{
		nint num = JNIEnv.NewArray(useCases);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isUseCasesCombinationSupported.([Landroidx/camera/core/UseCase;)Z", this, ptr);
		}
		finally
		{
			if (useCases != null)
			{
				JNIEnv.CopyArray(num, useCases);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(useCases);
		}
	}

	private static Delegate GetIsUseCasesCombinationSupported_ZarrayLandroidx_camera_core_UseCase_Handler()
	{
		if ((object)cb_isUseCasesCombinationSupported_ZarrayLandroidx_camera_core_UseCase_ == null)
		{
			cb_isUseCasesCombinationSupported_ZarrayLandroidx_camera_core_UseCase_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZL_Z(n_IsUseCasesCombinationSupported_ZarrayLandroidx_camera_core_UseCase_));
		}
		return cb_isUseCasesCombinationSupported_ZarrayLandroidx_camera_core_UseCase_;
	}

	private static bool n_IsUseCasesCombinationSupported_ZarrayLandroidx_camera_core_UseCase_(nint jnienv, nint native__this, bool withStreamSharing, nint native_useCases)
	{
		ICamera? camera = Java.Lang.Object.GetObject<ICamera>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		UseCase[] array = (UseCase[])JNIEnv.GetArray(native_useCases, JniHandleOwnership.DoNotTransfer, typeof(UseCase));
		bool result = camera.IsUseCasesCombinationSupported(withStreamSharing, array);
		if (array != null)
		{
			JNIEnv.CopyArray(array, native_useCases);
		}
		return result;
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("isUseCasesCombinationSupported", "(Z[Landroidx/camera/core/UseCase;)Z", "GetIsUseCasesCombinationSupported_ZarrayLandroidx_camera_core_UseCase_Handler:AndroidX.Camera.Core.ICamera, Xamarin.AndroidX.Camera.Core")]
	unsafe bool IsUseCasesCombinationSupported(bool withStreamSharing, params UseCase[] useCases)
	{
		nint num = JNIEnv.NewArray(useCases);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(withStreamSharing);
			ptr[1] = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isUseCasesCombinationSupported.(Z[Landroidx/camera/core/UseCase;)Z", this, ptr);
		}
		finally
		{
			if (useCases != null)
			{
				JNIEnv.CopyArray(num, useCases);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(useCases);
		}
	}

	private static Delegate GetIsUseCasesCombinationSupportedByFramework_arrayLandroidx_camera_core_UseCase_Handler()
	{
		if ((object)cb_isUseCasesCombinationSupportedByFramework_arrayLandroidx_camera_core_UseCase_ == null)
		{
			cb_isUseCasesCombinationSupportedByFramework_arrayLandroidx_camera_core_UseCase_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsUseCasesCombinationSupportedByFramework_arrayLandroidx_camera_core_UseCase_));
		}
		return cb_isUseCasesCombinationSupportedByFramework_arrayLandroidx_camera_core_UseCase_;
	}

	private static bool n_IsUseCasesCombinationSupportedByFramework_arrayLandroidx_camera_core_UseCase_(nint jnienv, nint native__this, nint native_useCases)
	{
		ICamera? camera = Java.Lang.Object.GetObject<ICamera>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		UseCase[] array = (UseCase[])JNIEnv.GetArray(native_useCases, JniHandleOwnership.DoNotTransfer, typeof(UseCase));
		bool result = camera.IsUseCasesCombinationSupportedByFramework(array);
		if (array != null)
		{
			JNIEnv.CopyArray(array, native_useCases);
		}
		return result;
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("isUseCasesCombinationSupportedByFramework", "([Landroidx/camera/core/UseCase;)Z", "GetIsUseCasesCombinationSupportedByFramework_arrayLandroidx_camera_core_UseCase_Handler:AndroidX.Camera.Core.ICamera, Xamarin.AndroidX.Camera.Core")]
	unsafe bool IsUseCasesCombinationSupportedByFramework(params UseCase[] useCases)
	{
		nint num = JNIEnv.NewArray(useCases);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isUseCasesCombinationSupportedByFramework.([Landroidx/camera/core/UseCase;)Z", this, ptr);
		}
		finally
		{
			if (useCases != null)
			{
				JNIEnv.CopyArray(num, useCases);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(useCases);
		}
	}
}
