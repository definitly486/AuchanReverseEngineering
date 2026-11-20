using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Processing;

[Register("androidx/camera/core/processing/SurfaceProcessorInternal", DoNotGenerateAcw = true)]
internal class ISurfaceProcessorInternalInvoker : Java.Lang.Object, ISurfaceProcessorInternal, ISurfaceProcessor, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/processing/SurfaceProcessorInternal", typeof(ISurfaceProcessorInternalInvoker));

	private nint class_ref;

	private static Delegate? cb_release;

	private nint id_release;

	private static Delegate? cb_onInputSurface_Landroidx_camera_core_SurfaceRequest_;

	private nint id_onInputSurface_Landroidx_camera_core_SurfaceRequest_;

	private static Delegate? cb_onOutputSurface_Landroidx_camera_core_SurfaceOutput_;

	private nint id_onOutputSurface_Landroidx_camera_core_SurfaceOutput_;

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

	public static ISurfaceProcessorInternal? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<ISurfaceProcessorInternal>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.processing.SurfaceProcessorInternal'.");
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

	public ISurfaceProcessorInternalInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetReleaseHandler()
	{
		if ((object)cb_release == null)
		{
			cb_release = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Release));
		}
		return cb_release;
	}

	private static void n_Release(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ISurfaceProcessorInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Release();
	}

	public void Release()
	{
		if (id_release == IntPtr.Zero)
		{
			id_release = JNIEnv.GetMethodID(class_ref, "release", "()V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_release);
	}

	private static Delegate GetOnInputSurface_Landroidx_camera_core_SurfaceRequest_Handler()
	{
		if ((object)cb_onInputSurface_Landroidx_camera_core_SurfaceRequest_ == null)
		{
			cb_onInputSurface_Landroidx_camera_core_SurfaceRequest_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnInputSurface_Landroidx_camera_core_SurfaceRequest_));
		}
		return cb_onInputSurface_Landroidx_camera_core_SurfaceRequest_;
	}

	private static void n_OnInputSurface_Landroidx_camera_core_SurfaceRequest_(nint jnienv, nint native__this, nint native_p0)
	{
		ISurfaceProcessorInternal? surfaceProcessorInternal = Java.Lang.Object.GetObject<ISurfaceProcessorInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SurfaceRequest p = Java.Lang.Object.GetObject<SurfaceRequest>(native_p0, JniHandleOwnership.DoNotTransfer);
		surfaceProcessorInternal.OnInputSurface(p);
	}

	public unsafe void OnInputSurface(SurfaceRequest p0)
	{
		if (id_onInputSurface_Landroidx_camera_core_SurfaceRequest_ == IntPtr.Zero)
		{
			id_onInputSurface_Landroidx_camera_core_SurfaceRequest_ = JNIEnv.GetMethodID(class_ref, "onInputSurface", "(Landroidx/camera/core/SurfaceRequest;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_onInputSurface_Landroidx_camera_core_SurfaceRequest_, ptr);
	}

	private static Delegate GetOnOutputSurface_Landroidx_camera_core_SurfaceOutput_Handler()
	{
		if ((object)cb_onOutputSurface_Landroidx_camera_core_SurfaceOutput_ == null)
		{
			cb_onOutputSurface_Landroidx_camera_core_SurfaceOutput_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnOutputSurface_Landroidx_camera_core_SurfaceOutput_));
		}
		return cb_onOutputSurface_Landroidx_camera_core_SurfaceOutput_;
	}

	private static void n_OnOutputSurface_Landroidx_camera_core_SurfaceOutput_(nint jnienv, nint native__this, nint native_p0)
	{
		ISurfaceProcessorInternal? surfaceProcessorInternal = Java.Lang.Object.GetObject<ISurfaceProcessorInternal>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ISurfaceOutput p = Java.Lang.Object.GetObject<ISurfaceOutput>(native_p0, JniHandleOwnership.DoNotTransfer);
		surfaceProcessorInternal.OnOutputSurface(p);
	}

	public unsafe void OnOutputSurface(ISurfaceOutput p0)
	{
		if (id_onOutputSurface_Landroidx_camera_core_SurfaceOutput_ == IntPtr.Zero)
		{
			id_onOutputSurface_Landroidx_camera_core_SurfaceOutput_ = JNIEnv.GetMethodID(class_ref, "onOutputSurface", "(Landroidx/camera/core/SurfaceOutput;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		JNIEnv.CallVoidMethod(base.Handle, id_onOutputSurface_Landroidx_camera_core_SurfaceOutput_, ptr);
	}
}
