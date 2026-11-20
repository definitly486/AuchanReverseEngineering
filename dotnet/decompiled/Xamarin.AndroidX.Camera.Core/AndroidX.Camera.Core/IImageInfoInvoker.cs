using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.Camera.Core.Impl;
using AndroidX.Camera.Core.Impl.Utils;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageInfo", DoNotGenerateAcw = true)]
internal class IImageInfoInvoker : Java.Lang.Object, IImageInfo, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageInfo", typeof(IImageInfoInvoker));

	private nint class_ref;

	private static Delegate? cb_getRotationDegrees;

	private nint id_getRotationDegrees;

	private static Delegate? cb_getTagBundle;

	private nint id_getTagBundle;

	private static Delegate? cb_getTimestamp;

	private nint id_getTimestamp;

	private static Delegate? cb_populateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_;

	private nint id_populateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_;

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

	public int RotationDegrees
	{
		get
		{
			if (id_getRotationDegrees == IntPtr.Zero)
			{
				id_getRotationDegrees = JNIEnv.GetMethodID(class_ref, "getRotationDegrees", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getRotationDegrees);
		}
	}

	public TagBundle TagBundle
	{
		get
		{
			if (id_getTagBundle == IntPtr.Zero)
			{
				id_getTagBundle = JNIEnv.GetMethodID(class_ref, "getTagBundle", "()Landroidx/camera/core/impl/TagBundle;");
			}
			return Java.Lang.Object.GetObject<TagBundle>(JNIEnv.CallObjectMethod(base.Handle, id_getTagBundle), JniHandleOwnership.TransferLocalRef);
		}
	}

	public long Timestamp
	{
		get
		{
			if (id_getTimestamp == IntPtr.Zero)
			{
				id_getTimestamp = JNIEnv.GetMethodID(class_ref, "getTimestamp", "()J");
			}
			return JNIEnv.CallLongMethod(base.Handle, id_getTimestamp);
		}
	}

	public static IImageInfo? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IImageInfo>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.ImageInfo'.");
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

	public IImageInfoInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
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
		return Java.Lang.Object.GetObject<IImageInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotationDegrees;
	}

	private static Delegate GetGetTagBundleHandler()
	{
		if ((object)cb_getTagBundle == null)
		{
			cb_getTagBundle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTagBundle));
		}
		return cb_getTagBundle;
	}

	private static nint n_GetTagBundle(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TagBundle);
	}

	private static Delegate GetGetTimestampHandler()
	{
		if ((object)cb_getTimestamp == null)
		{
			cb_getTimestamp = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetTimestamp));
		}
		return cb_getTimestamp;
	}

	private static long n_GetTimestamp(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IImageInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Timestamp;
	}

	private static Delegate GetPopulateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_Handler()
	{
		if ((object)cb_populateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_ == null)
		{
			cb_populateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_PopulateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_));
		}
		return cb_populateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_;
	}

	private static void n_PopulateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_(nint jnienv, nint native__this, nint native_p0)
	{
		IImageInfo? imageInfo = Java.Lang.Object.GetObject<IImageInfo>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ExifData.Builder p = Java.Lang.Object.GetObject<ExifData.Builder>(native_p0, JniHandleOwnership.DoNotTransfer);
		imageInfo.PopulateExifData(p);
	}

	public unsafe void PopulateExifData(ExifData.Builder p0)
	{
		if (id_populateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_ == IntPtr.Zero)
		{
			id_populateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_ = JNIEnv.GetMethodID(class_ref, "populateExifData", "(Landroidx/camera/core/impl/utils/ExifData$Builder;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_populateExifData_Landroidx_camera_core_impl_utils_ExifData_Builder_, ptr);
	}
}
