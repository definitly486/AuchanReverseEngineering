using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/EncoderProfilesProxy", DoNotGenerateAcw = true)]
internal class IEncoderProfilesProxyInvoker : Java.Lang.Object, IEncoderProfilesProxy, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/EncoderProfilesProxy", typeof(IEncoderProfilesProxyInvoker));

	private nint class_ref;

	private static Delegate? cb_getAudioProfiles;

	private nint id_getAudioProfiles;

	private static Delegate? cb_getDefaultDurationSeconds;

	private nint id_getDefaultDurationSeconds;

	private static Delegate? cb_getRecommendedFileFormat;

	private nint id_getRecommendedFileFormat;

	private static Delegate? cb_getVideoProfiles;

	private nint id_getVideoProfiles;

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

	public IList<EncoderProfilesProxyAudioProfileProxy> AudioProfiles
	{
		get
		{
			if (id_getAudioProfiles == IntPtr.Zero)
			{
				id_getAudioProfiles = JNIEnv.GetMethodID(class_ref, "getAudioProfiles", "()Ljava/util/List;");
			}
			return JavaList<EncoderProfilesProxyAudioProfileProxy>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getAudioProfiles), JniHandleOwnership.TransferLocalRef);
		}
	}

	public int DefaultDurationSeconds
	{
		get
		{
			if (id_getDefaultDurationSeconds == IntPtr.Zero)
			{
				id_getDefaultDurationSeconds = JNIEnv.GetMethodID(class_ref, "getDefaultDurationSeconds", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getDefaultDurationSeconds);
		}
	}

	public int RecommendedFileFormat
	{
		get
		{
			if (id_getRecommendedFileFormat == IntPtr.Zero)
			{
				id_getRecommendedFileFormat = JNIEnv.GetMethodID(class_ref, "getRecommendedFileFormat", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getRecommendedFileFormat);
		}
	}

	public IList<EncoderProfilesProxyVideoProfileProxy> VideoProfiles
	{
		get
		{
			if (id_getVideoProfiles == IntPtr.Zero)
			{
				id_getVideoProfiles = JNIEnv.GetMethodID(class_ref, "getVideoProfiles", "()Ljava/util/List;");
			}
			return JavaList<EncoderProfilesProxyVideoProfileProxy>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getVideoProfiles), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static IEncoderProfilesProxy? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IEncoderProfilesProxy>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.EncoderProfilesProxy'.");
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

	public IEncoderProfilesProxyInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetAudioProfilesHandler()
	{
		if ((object)cb_getAudioProfiles == null)
		{
			cb_getAudioProfiles = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAudioProfiles));
		}
		return cb_getAudioProfiles;
	}

	private static nint n_GetAudioProfiles(nint jnienv, nint native__this)
	{
		return JavaList<EncoderProfilesProxyAudioProfileProxy>.ToLocalJniHandle(Java.Lang.Object.GetObject<IEncoderProfilesProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AudioProfiles);
	}

	private static Delegate GetGetDefaultDurationSecondsHandler()
	{
		if ((object)cb_getDefaultDurationSeconds == null)
		{
			cb_getDefaultDurationSeconds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetDefaultDurationSeconds));
		}
		return cb_getDefaultDurationSeconds;
	}

	private static int n_GetDefaultDurationSeconds(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IEncoderProfilesProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultDurationSeconds;
	}

	private static Delegate GetGetRecommendedFileFormatHandler()
	{
		if ((object)cb_getRecommendedFileFormat == null)
		{
			cb_getRecommendedFileFormat = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRecommendedFileFormat));
		}
		return cb_getRecommendedFileFormat;
	}

	private static int n_GetRecommendedFileFormat(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IEncoderProfilesProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RecommendedFileFormat;
	}

	private static Delegate GetGetVideoProfilesHandler()
	{
		if ((object)cb_getVideoProfiles == null)
		{
			cb_getVideoProfiles = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVideoProfiles));
		}
		return cb_getVideoProfiles;
	}

	private static nint n_GetVideoProfiles(nint jnienv, nint native__this)
	{
		return JavaList<EncoderProfilesProxyVideoProfileProxy>.ToLocalJniHandle(Java.Lang.Object.GetObject<IEncoderProfilesProxy>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VideoProfiles);
	}
}
