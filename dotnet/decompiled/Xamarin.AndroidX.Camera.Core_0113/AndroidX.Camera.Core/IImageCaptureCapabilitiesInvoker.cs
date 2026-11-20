using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageCaptureCapabilities", DoNotGenerateAcw = true)]
internal class IImageCaptureCapabilitiesInvoker : Java.Lang.Object, IImageCaptureCapabilities, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/ImageCaptureCapabilities", typeof(IImageCaptureCapabilitiesInvoker));

	private nint class_ref;

	private static Delegate? cb_isCaptureProcessProgressSupported;

	private nint id_isCaptureProcessProgressSupported;

	private static Delegate? cb_isPostviewSupported;

	private nint id_isPostviewSupported;

	private static Delegate? cb_getSupportedOutputFormats;

	private nint id_getSupportedOutputFormats;

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

	public bool IsCaptureProcessProgressSupported
	{
		get
		{
			if (id_isCaptureProcessProgressSupported == IntPtr.Zero)
			{
				id_isCaptureProcessProgressSupported = JNIEnv.GetMethodID(class_ref, "isCaptureProcessProgressSupported", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_isCaptureProcessProgressSupported);
		}
	}

	public bool IsPostviewSupported
	{
		get
		{
			if (id_isPostviewSupported == IntPtr.Zero)
			{
				id_isPostviewSupported = JNIEnv.GetMethodID(class_ref, "isPostviewSupported", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_isPostviewSupported);
		}
	}

	public ICollection<Integer> SupportedOutputFormats
	{
		get
		{
			if (id_getSupportedOutputFormats == IntPtr.Zero)
			{
				id_getSupportedOutputFormats = JNIEnv.GetMethodID(class_ref, "getSupportedOutputFormats", "()Ljava/util/Set;");
			}
			return JavaSet<Integer>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getSupportedOutputFormats), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static IImageCaptureCapabilities? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IImageCaptureCapabilities>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.ImageCaptureCapabilities'.");
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

	public IImageCaptureCapabilitiesInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetIsCaptureProcessProgressSupportedHandler()
	{
		if ((object)cb_isCaptureProcessProgressSupported == null)
		{
			cb_isCaptureProcessProgressSupported = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsCaptureProcessProgressSupported));
		}
		return cb_isCaptureProcessProgressSupported;
	}

	private static bool n_IsCaptureProcessProgressSupported(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IImageCaptureCapabilities>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCaptureProcessProgressSupported;
	}

	private static Delegate GetIsPostviewSupportedHandler()
	{
		if ((object)cb_isPostviewSupported == null)
		{
			cb_isPostviewSupported = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsPostviewSupported));
		}
		return cb_isPostviewSupported;
	}

	private static bool n_IsPostviewSupported(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IImageCaptureCapabilities>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsPostviewSupported;
	}

	private static Delegate GetGetSupportedOutputFormatsHandler()
	{
		if ((object)cb_getSupportedOutputFormats == null)
		{
			cb_getSupportedOutputFormats = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSupportedOutputFormats));
		}
		return cb_getSupportedOutputFormats;
	}

	private static nint n_GetSupportedOutputFormats(nint jnienv, nint native__this)
	{
		return JavaSet<Integer>.ToLocalJniHandle(Java.Lang.Object.GetObject<IImageCaptureCapabilities>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportedOutputFormats);
	}
}
