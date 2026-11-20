using System;
using Android.Graphics;
using Android.Runtime;
using AndroidX.Camera.Core.Impl;
using AndroidX.Camera.Core.Impl.Utils;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageInfo", "", "AndroidX.Camera.Core.IImageInfoInvoker")]
public interface IImageInfo : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageInfo", typeof(IImageInfo), isInterface: true);

	private static Delegate? cb_getSensorToBufferTransformMatrix;

	int RotationDegrees
	{
		[Register("getRotationDegrees", "()I", "GetGetRotationDegreesHandler:AndroidX.Camera.Core.IImageInfoInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	TagBundle TagBundle
	{
		[Register("getTagBundle", "()Landroidx/camera/core/impl/TagBundle;", "GetGetTagBundleHandler:AndroidX.Camera.Core.IImageInfoInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	long Timestamp
	{
		[Register("getTimestamp", "()J", "GetGetTimestampHandler:AndroidX.Camera.Core.IImageInfoInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	unsafe Matrix SensorToBufferTransformMatrix
	{
		[Register("getSensorToBufferTransformMatrix", "()Landroid/graphics/Matrix;", "GetGetSensorToBufferTransformMatrixHandler:AndroidX.Camera.Core.IImageInfo, Xamarin.AndroidX.Camera.Core")]
		get
		{
			return Java.Lang.Object.GetObject<Matrix>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSensorToBufferTransformMatrix.()Landroid/graphics/Matrix;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static Delegate GetGetSensorToBufferTransformMatrixHandler()
	{
		if ((object)cb_getSensorToBufferTransformMatrix == null)
		{
			cb_getSensorToBufferTransformMatrix = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSensorToBufferTransformMatrix));
		}
		return cb_getSensorToBufferTransformMatrix;
	}

	private static nint n_GetSensorToBufferTransformMatrix(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SensorToBufferTransformMatrix);
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("populateExifData", "(Landroidx/camera/core/impl/utils/ExifData$Builder;)V", "GetPopulateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_Handler:AndroidX.Camera.Core.IImageInfoInvoker, Xamarin.AndroidX.Camera.Core")]
	void PopulateExifData(ExifData.Builder p0);
}
