using System;
using System.Collections.Generic;
using Android.Runtime;
using Android.Util;
using AndroidX.Camera.Core;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Video;

[Register("androidx/camera/video/VideoCapabilities", "", "AndroidX.Camera.Video.IVideoCapabilitiesInvoker")]
public interface IVideoCapabilities : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/video/VideoCapabilities", typeof(IVideoCapabilities), isInterface: true);

	private static Delegate? cb_isStabilizationSupported;

	private static Delegate? cb_findNearestHigherSupportedQualityFor_Landroid_util_Size_Landroidx_camera_core_DynamicRange_;

	[Register("EMPTY")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	static IVideoCapabilities Empty => Java.Lang.Object.GetObject<IVideoCapabilities>(_members.StaticFields.GetObjectValue("EMPTY.Landroidx/camera/video/VideoCapabilities;").Handle, JniHandleOwnership.TransferLocalRef);

	ICollection<DynamicRange> SupportedDynamicRanges
	{
		[Register("getSupportedDynamicRanges", "()Ljava/util/Set;", "GetGetSupportedDynamicRangesHandler:AndroidX.Camera.Video.IVideoCapabilitiesInvoker, Xamarin.AndroidX.Camera.Video")]
		get;
	}

	unsafe bool IsStabilizationSupported
	{
		[Register("isStabilizationSupported", "()Z", "GetIsStabilizationSupportedHandler:AndroidX.Camera.Video.IVideoCapabilities, Xamarin.AndroidX.Camera.Video")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isStabilizationSupported.()Z", this, null);
		}
	}

	private static Delegate GetIsStabilizationSupportedHandler()
	{
		if ((object)cb_isStabilizationSupported == null)
		{
			cb_isStabilizationSupported = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsStabilizationSupported));
		}
		return cb_isStabilizationSupported;
	}

	private static bool n_IsStabilizationSupported(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IVideoCapabilities>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsStabilizationSupported;
	}

	[Register("getSupportedQualities", "(Landroidx/camera/core/DynamicRange;)Ljava/util/List;", "GetGetSupportedQualities_Landroidx_camera_core_DynamicRange_Handler:AndroidX.Camera.Video.IVideoCapabilitiesInvoker, Xamarin.AndroidX.Camera.Video")]
	IList<Quality> GetSupportedQualities(DynamicRange p0);

	[Register("isQualitySupported", "(Landroidx/camera/video/Quality;Landroidx/camera/core/DynamicRange;)Z", "GetIsQualitySupported_Landroidx_camera_video_Quality_Landroidx_camera_core_DynamicRange_Handler:AndroidX.Camera.Video.IVideoCapabilitiesInvoker, Xamarin.AndroidX.Camera.Video")]
	bool IsQualitySupported(Quality p0, DynamicRange p1);

	private static Delegate GetFindNearestHigherSupportedQualityFor_Landroid_util_Size_Landroidx_camera_core_DynamicRange_Handler()
	{
		if ((object)cb_findNearestHigherSupportedQualityFor_Landroid_util_Size_Landroidx_camera_core_DynamicRange_ == null)
		{
			cb_findNearestHigherSupportedQualityFor_Landroid_util_Size_Landroidx_camera_core_DynamicRange_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_FindNearestHigherSupportedQualityFor_Landroid_util_Size_Landroidx_camera_core_DynamicRange_));
		}
		return cb_findNearestHigherSupportedQualityFor_Landroid_util_Size_Landroidx_camera_core_DynamicRange_;
	}

	private static nint n_FindNearestHigherSupportedQualityFor_Landroid_util_Size_Landroidx_camera_core_DynamicRange_(nint jnienv, nint native__this, nint native_size, nint native_dynamicRange)
	{
		IVideoCapabilities? videoCapabilities = Java.Lang.Object.GetObject<IVideoCapabilities>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Size size = Java.Lang.Object.GetObject<Size>(native_size, JniHandleOwnership.DoNotTransfer);
		DynamicRange dynamicRange = Java.Lang.Object.GetObject<DynamicRange>(native_dynamicRange, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(videoCapabilities.FindNearestHigherSupportedQualityFor(size, dynamicRange));
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("findNearestHigherSupportedQualityFor", "(Landroid/util/Size;Landroidx/camera/core/DynamicRange;)Landroidx/camera/video/Quality;", "GetFindNearestHigherSupportedQualityFor_Landroid_util_Size_Landroidx_camera_core_DynamicRange_Handler:AndroidX.Camera.Video.IVideoCapabilities, Xamarin.AndroidX.Camera.Video")]
	unsafe Quality FindNearestHigherSupportedQualityFor(Size size, DynamicRange dynamicRange)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(size?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(dynamicRange?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Quality>(_members.InstanceMethods.InvokeVirtualObjectMethod("findNearestHigherSupportedQualityFor.(Landroid/util/Size;Landroidx/camera/core/DynamicRange;)Landroidx/camera/video/Quality;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(size);
			GC.KeepAlive(dynamicRange);
		}
	}
}
