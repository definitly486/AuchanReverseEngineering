using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CameraCaptureResult", DoNotGenerateAcw = true)]
internal class ICameraCaptureResultInvoker : Java.Lang.Object, ICameraCaptureResult, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraCaptureResult", typeof(ICameraCaptureResultInvoker));

	private nint class_ref;

	private static Delegate? cb_getAeMode;

	private nint id_getAeMode;

	private static Delegate? cb_getAeState;

	private nint id_getAeState;

	private static Delegate? cb_getAfMode;

	private nint id_getAfMode;

	private static Delegate? cb_getAfState;

	private nint id_getAfState;

	private static Delegate? cb_getAwbMode;

	private nint id_getAwbMode;

	private static Delegate? cb_getAwbState;

	private nint id_getAwbState;

	private static Delegate? cb_getFlashState;

	private nint id_getFlashState;

	private static Delegate? cb_getTagBundle;

	private nint id_getTagBundle;

	private static Delegate? cb_getTimestamp;

	private nint id_getTimestamp;

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

	public CameraCaptureMetaData.AeMode AeMode
	{
		get
		{
			if (id_getAeMode == IntPtr.Zero)
			{
				id_getAeMode = JNIEnv.GetMethodID(class_ref, "getAeMode", "()Landroidx/camera/core/impl/CameraCaptureMetaData$AeMode;");
			}
			return Java.Lang.Object.GetObject<CameraCaptureMetaData.AeMode>(JNIEnv.CallObjectMethod(base.Handle, id_getAeMode), JniHandleOwnership.TransferLocalRef);
		}
	}

	public CameraCaptureMetaData.AeState AeState
	{
		get
		{
			if (id_getAeState == IntPtr.Zero)
			{
				id_getAeState = JNIEnv.GetMethodID(class_ref, "getAeState", "()Landroidx/camera/core/impl/CameraCaptureMetaData$AeState;");
			}
			return Java.Lang.Object.GetObject<CameraCaptureMetaData.AeState>(JNIEnv.CallObjectMethod(base.Handle, id_getAeState), JniHandleOwnership.TransferLocalRef);
		}
	}

	public CameraCaptureMetaData.AfMode AfMode
	{
		get
		{
			if (id_getAfMode == IntPtr.Zero)
			{
				id_getAfMode = JNIEnv.GetMethodID(class_ref, "getAfMode", "()Landroidx/camera/core/impl/CameraCaptureMetaData$AfMode;");
			}
			return Java.Lang.Object.GetObject<CameraCaptureMetaData.AfMode>(JNIEnv.CallObjectMethod(base.Handle, id_getAfMode), JniHandleOwnership.TransferLocalRef);
		}
	}

	public CameraCaptureMetaData.AfState AfState
	{
		get
		{
			if (id_getAfState == IntPtr.Zero)
			{
				id_getAfState = JNIEnv.GetMethodID(class_ref, "getAfState", "()Landroidx/camera/core/impl/CameraCaptureMetaData$AfState;");
			}
			return Java.Lang.Object.GetObject<CameraCaptureMetaData.AfState>(JNIEnv.CallObjectMethod(base.Handle, id_getAfState), JniHandleOwnership.TransferLocalRef);
		}
	}

	public CameraCaptureMetaData.AwbMode AwbMode
	{
		get
		{
			if (id_getAwbMode == IntPtr.Zero)
			{
				id_getAwbMode = JNIEnv.GetMethodID(class_ref, "getAwbMode", "()Landroidx/camera/core/impl/CameraCaptureMetaData$AwbMode;");
			}
			return Java.Lang.Object.GetObject<CameraCaptureMetaData.AwbMode>(JNIEnv.CallObjectMethod(base.Handle, id_getAwbMode), JniHandleOwnership.TransferLocalRef);
		}
	}

	public CameraCaptureMetaData.AwbState AwbState
	{
		get
		{
			if (id_getAwbState == IntPtr.Zero)
			{
				id_getAwbState = JNIEnv.GetMethodID(class_ref, "getAwbState", "()Landroidx/camera/core/impl/CameraCaptureMetaData$AwbState;");
			}
			return Java.Lang.Object.GetObject<CameraCaptureMetaData.AwbState>(JNIEnv.CallObjectMethod(base.Handle, id_getAwbState), JniHandleOwnership.TransferLocalRef);
		}
	}

	public CameraCaptureMetaData.FlashState FlashState
	{
		get
		{
			if (id_getFlashState == IntPtr.Zero)
			{
				id_getFlashState = JNIEnv.GetMethodID(class_ref, "getFlashState", "()Landroidx/camera/core/impl/CameraCaptureMetaData$FlashState;");
			}
			return Java.Lang.Object.GetObject<CameraCaptureMetaData.FlashState>(JNIEnv.CallObjectMethod(base.Handle, id_getFlashState), JniHandleOwnership.TransferLocalRef);
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

	public static ICameraCaptureResult? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ICameraCaptureResult>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.CameraCaptureResult'.");
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

	public ICameraCaptureResultInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetAeModeHandler()
	{
		if ((object)cb_getAeMode == null)
		{
			cb_getAeMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAeMode));
		}
		return cb_getAeMode;
	}

	private static nint n_GetAeMode(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraCaptureResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AeMode);
	}

	private static Delegate GetGetAeStateHandler()
	{
		if ((object)cb_getAeState == null)
		{
			cb_getAeState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAeState));
		}
		return cb_getAeState;
	}

	private static nint n_GetAeState(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraCaptureResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AeState);
	}

	private static Delegate GetGetAfModeHandler()
	{
		if ((object)cb_getAfMode == null)
		{
			cb_getAfMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAfMode));
		}
		return cb_getAfMode;
	}

	private static nint n_GetAfMode(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraCaptureResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AfMode);
	}

	private static Delegate GetGetAfStateHandler()
	{
		if ((object)cb_getAfState == null)
		{
			cb_getAfState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAfState));
		}
		return cb_getAfState;
	}

	private static nint n_GetAfState(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraCaptureResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AfState);
	}

	private static Delegate GetGetAwbModeHandler()
	{
		if ((object)cb_getAwbMode == null)
		{
			cb_getAwbMode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAwbMode));
		}
		return cb_getAwbMode;
	}

	private static nint n_GetAwbMode(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraCaptureResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AwbMode);
	}

	private static Delegate GetGetAwbStateHandler()
	{
		if ((object)cb_getAwbState == null)
		{
			cb_getAwbState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAwbState));
		}
		return cb_getAwbState;
	}

	private static nint n_GetAwbState(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraCaptureResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AwbState);
	}

	private static Delegate GetGetFlashStateHandler()
	{
		if ((object)cb_getFlashState == null)
		{
			cb_getFlashState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFlashState));
		}
		return cb_getFlashState;
	}

	private static nint n_GetFlashState(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraCaptureResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlashState);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraCaptureResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TagBundle);
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
		return Java.Lang.Object.GetObject<ICameraCaptureResult>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Timestamp;
	}
}
