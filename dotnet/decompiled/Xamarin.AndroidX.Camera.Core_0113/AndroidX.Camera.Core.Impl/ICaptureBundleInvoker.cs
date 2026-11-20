using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CaptureBundle", DoNotGenerateAcw = true)]
internal class ICaptureBundleInvoker : Java.Lang.Object, ICaptureBundle, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CaptureBundle", typeof(ICaptureBundleInvoker));

	private nint class_ref;

	private static Delegate? cb_getCaptureStages;

	private nint id_getCaptureStages;

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

	public IList<ICaptureStage>? CaptureStages
	{
		get
		{
			if (id_getCaptureStages == IntPtr.Zero)
			{
				id_getCaptureStages = JNIEnv.GetMethodID(class_ref, "getCaptureStages", "()Ljava/util/List;");
			}
			return JavaList<ICaptureStage>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getCaptureStages), JniHandleOwnership.TransferLocalRef);
		}
	}

	public static ICaptureBundle? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ICaptureBundle>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.CaptureBundle'.");
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

	public ICaptureBundleInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetGetCaptureStagesHandler()
	{
		if ((object)cb_getCaptureStages == null)
		{
			cb_getCaptureStages = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCaptureStages));
		}
		return cb_getCaptureStages;
	}

	private static nint n_GetCaptureStages(nint jnienv, nint native__this)
	{
		return JavaList<ICaptureStage>.ToLocalJniHandle(Java.Lang.Object.GetObject<ICaptureBundle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CaptureStages);
	}
}
