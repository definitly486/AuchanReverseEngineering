using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CaptureStage", DoNotGenerateAcw = true)]
internal class ICaptureStageInvoker : Java.Lang.Object, ICaptureStage, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CaptureStage", typeof(ICaptureStageInvoker));

	private nint class_ref;

	private static Delegate? cb_getCaptureConfig;

	private nint id_getCaptureConfig;

	private static Delegate? cb_getId;

	private nint id_getId;

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

	public CaptureConfig CaptureConfig
	{
		get
		{
			if (id_getCaptureConfig == IntPtr.Zero)
			{
				id_getCaptureConfig = JNIEnv.GetMethodID(class_ref, "getCaptureConfig", "()Landroidx/camera/core/impl/CaptureConfig;");
			}
			return Java.Lang.Object.GetObject<CaptureConfig>(JNIEnv.CallObjectMethod(base.Handle, id_getCaptureConfig), JniHandleOwnership.TransferLocalRef);
		}
	}

	public int Id
	{
		get
		{
			if (id_getId == IntPtr.Zero)
			{
				id_getId = JNIEnv.GetMethodID(class_ref, "getId", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_getId);
		}
	}

	public static ICaptureStage? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ICaptureStage>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.CaptureStage'.");
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

	public ICaptureStageInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetCaptureConfigHandler()
	{
		if ((object)cb_getCaptureConfig == null)
		{
			cb_getCaptureConfig = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCaptureConfig));
		}
		return cb_getCaptureConfig;
	}

	private static nint n_GetCaptureConfig(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICaptureStage>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CaptureConfig);
	}

	private static Delegate GetGetIdHandler()
	{
		if ((object)cb_getId == null)
		{
			cb_getId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetId));
		}
		return cb_getId;
	}

	private static int n_GetId(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICaptureStage>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
	}
}
