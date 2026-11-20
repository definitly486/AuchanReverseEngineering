using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Camera.Core;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Video;

[Register("androidx/camera/video/VideoCapabilities", DoNotGenerateAcw = true)]
internal class IVideoCapabilitiesInvoker : Java.Lang.Object, IVideoCapabilities, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/video/VideoCapabilities", typeof(IVideoCapabilitiesInvoker));

	private nint class_ref;

	private static Delegate? cb_getSupportedDynamicRanges;

	private nint id_getSupportedDynamicRanges;

	private static Delegate? cb_getSupportedQualities_Landroidx_camera_core_DynamicRange_;

	private nint id_getSupportedQualities_Landroidx_camera_core_DynamicRange_;

	private static Delegate? cb_isQualitySupported_Landroidx_camera_video_Quality_Landroidx_camera_core_DynamicRange_;

	private nint id_isQualitySupported_Landroidx_camera_video_Quality_Landroidx_camera_core_DynamicRange_;

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

	public ICollection<DynamicRange> SupportedDynamicRanges
	{
		get
		{
			if (id_getSupportedDynamicRanges == IntPtr.Zero)
			{
				id_getSupportedDynamicRanges = JNIEnv.GetMethodID(class_ref, "getSupportedDynamicRanges", "()Ljava/util/Set;");
			}
			return JavaSet<DynamicRange>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getSupportedDynamicRanges), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static IVideoCapabilities? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IVideoCapabilities>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.video.VideoCapabilities'.");
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

	public IVideoCapabilitiesInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetSupportedDynamicRangesHandler()
	{
		if ((object)cb_getSupportedDynamicRanges == null)
		{
			cb_getSupportedDynamicRanges = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportedDynamicRanges));
		}
		return cb_getSupportedDynamicRanges;
	}

	private static nint n_GetSupportedDynamicRanges(nint jnienv, nint native__this)
	{
		return JavaSet<DynamicRange>.ToLocalJniHandle(Java.Lang.Object.GetObject<IVideoCapabilities>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportedDynamicRanges);
	}

	private static Delegate GetGetSupportedQualities_Landroidx_camera_core_DynamicRange_Handler()
	{
		if ((object)cb_getSupportedQualities_Landroidx_camera_core_DynamicRange_ == null)
		{
			cb_getSupportedQualities_Landroidx_camera_core_DynamicRange_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetSupportedQualities_Landroidx_camera_core_DynamicRange_));
		}
		return cb_getSupportedQualities_Landroidx_camera_core_DynamicRange_;
	}

	private static nint n_GetSupportedQualities_Landroidx_camera_core_DynamicRange_(nint jnienv, nint native__this, nint native_p0)
	{
		IVideoCapabilities? videoCapabilities = Java.Lang.Object.GetObject<IVideoCapabilities>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		DynamicRange p = Java.Lang.Object.GetObject<DynamicRange>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JavaList<Quality>.ToLocalJniHandle(videoCapabilities.GetSupportedQualities(p));
	}

	public unsafe IList<Quality> GetSupportedQualities(DynamicRange p0)
	{
		if (id_getSupportedQualities_Landroidx_camera_core_DynamicRange_ == IntPtr.Zero)
		{
			id_getSupportedQualities_Landroidx_camera_core_DynamicRange_ = JNIEnv.GetMethodID(class_ref, "getSupportedQualities", "(Landroidx/camera/core/DynamicRange;)Ljava/util/List;");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		return JavaList<Quality>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getSupportedQualities_Landroidx_camera_core_DynamicRange_, ptr), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetIsQualitySupported_Landroidx_camera_video_Quality_Landroidx_camera_core_DynamicRange_Handler()
	{
		if ((object)cb_isQualitySupported_Landroidx_camera_video_Quality_Landroidx_camera_core_DynamicRange_ == null)
		{
			cb_isQualitySupported_Landroidx_camera_video_Quality_Landroidx_camera_core_DynamicRange_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_IsQualitySupported_Landroidx_camera_video_Quality_Landroidx_camera_core_DynamicRange_));
		}
		return cb_isQualitySupported_Landroidx_camera_video_Quality_Landroidx_camera_core_DynamicRange_;
	}

	private static bool n_IsQualitySupported_Landroidx_camera_video_Quality_Landroidx_camera_core_DynamicRange_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IVideoCapabilities? videoCapabilities = Java.Lang.Object.GetObject<IVideoCapabilities>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Quality p = Java.Lang.Object.GetObject<Quality>(native_p0, JniHandleOwnership.DoNotTransfer);
		DynamicRange p2 = Java.Lang.Object.GetObject<DynamicRange>(native_p1, JniHandleOwnership.DoNotTransfer);
		return videoCapabilities.IsQualitySupported(p, p2);
	}

	public unsafe bool IsQualitySupported(Quality p0, DynamicRange p1)
	{
		if (id_isQualitySupported_Landroidx_camera_video_Quality_Landroidx_camera_core_DynamicRange_ == IntPtr.Zero)
		{
			id_isQualitySupported_Landroidx_camera_video_Quality_Landroidx_camera_core_DynamicRange_ = JNIEnv.GetMethodID(class_ref, "isQualitySupported", "(Landroidx/camera/video/Quality;Landroidx/camera/core/DynamicRange;)Z");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
		return JNIEnv.CallBooleanMethod(base.Handle, id_isQualitySupported_Landroidx_camera_video_Quality_Landroidx_camera_core_DynamicRange_, ptr);
	}
}
