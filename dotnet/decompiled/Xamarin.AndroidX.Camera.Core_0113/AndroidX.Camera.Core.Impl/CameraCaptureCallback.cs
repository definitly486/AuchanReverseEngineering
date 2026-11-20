using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/CameraCaptureCallback", DoNotGenerateAcw = true)]
public abstract class CameraCaptureCallback : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/CameraCaptureCallback", typeof(CameraCaptureCallback));

	private static Delegate? cb_onCaptureCancelled_I;

	private static Delegate? cb_onCaptureCompleted_ILandroidx_camera_core_impl_CameraCaptureResult_;

	private static Delegate? cb_onCaptureFailed_ILandroidx_camera_core_impl_CameraCaptureFailure_;

	private static Delegate? cb_onCaptureProcessProgressed_II;

	private static Delegate? cb_onCaptureStarted_I;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected CameraCaptureCallback(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe CameraCaptureCallback()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetOnCaptureCancelled_IHandler()
	{
		if ((object)cb_onCaptureCancelled_I == null)
		{
			cb_onCaptureCancelled_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnCaptureCancelled_I));
		}
		return cb_onCaptureCancelled_I;
	}

	private static void n_OnCaptureCancelled_I(nint jnienv, nint native__this, int captureConfigId)
	{
		Java.Lang.Object.GetObject<CameraCaptureCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureCancelled(captureConfigId);
	}

	[Register("onCaptureCancelled", "(I)V", "GetOnCaptureCancelled_IHandler")]
	public unsafe virtual void OnCaptureCancelled(int captureConfigId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(captureConfigId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureCancelled.(I)V", this, ptr);
	}

	private static Delegate GetOnCaptureCompleted_ILandroidx_camera_core_impl_CameraCaptureResult_Handler()
	{
		if ((object)cb_onCaptureCompleted_ILandroidx_camera_core_impl_CameraCaptureResult_ == null)
		{
			cb_onCaptureCompleted_ILandroidx_camera_core_impl_CameraCaptureResult_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_OnCaptureCompleted_ILandroidx_camera_core_impl_CameraCaptureResult_));
		}
		return cb_onCaptureCompleted_ILandroidx_camera_core_impl_CameraCaptureResult_;
	}

	private static void n_OnCaptureCompleted_ILandroidx_camera_core_impl_CameraCaptureResult_(nint jnienv, nint native__this, int captureConfigId, nint native_cameraCaptureResult)
	{
		CameraCaptureCallback? cameraCaptureCallback = Java.Lang.Object.GetObject<CameraCaptureCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICameraCaptureResult cameraCaptureResult = Java.Lang.Object.GetObject<ICameraCaptureResult>(native_cameraCaptureResult, JniHandleOwnership.DoNotTransfer);
		cameraCaptureCallback.OnCaptureCompleted(captureConfigId, cameraCaptureResult);
	}

	[Register("onCaptureCompleted", "(ILandroidx/camera/core/impl/CameraCaptureResult;)V", "GetOnCaptureCompleted_ILandroidx_camera_core_impl_CameraCaptureResult_Handler")]
	public unsafe virtual void OnCaptureCompleted(int captureConfigId, ICameraCaptureResult cameraCaptureResult)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(captureConfigId);
			ptr[1] = new JniArgumentValue((cameraCaptureResult == null) ? IntPtr.Zero : ((Java.Lang.Object)cameraCaptureResult).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureCompleted.(ILandroidx/camera/core/impl/CameraCaptureResult;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cameraCaptureResult);
		}
	}

	private static Delegate GetOnCaptureFailed_ILandroidx_camera_core_impl_CameraCaptureFailure_Handler()
	{
		if ((object)cb_onCaptureFailed_ILandroidx_camera_core_impl_CameraCaptureFailure_ == null)
		{
			cb_onCaptureFailed_ILandroidx_camera_core_impl_CameraCaptureFailure_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_OnCaptureFailed_ILandroidx_camera_core_impl_CameraCaptureFailure_));
		}
		return cb_onCaptureFailed_ILandroidx_camera_core_impl_CameraCaptureFailure_;
	}

	private static void n_OnCaptureFailed_ILandroidx_camera_core_impl_CameraCaptureFailure_(nint jnienv, nint native__this, int captureConfigId, nint native_failure)
	{
		CameraCaptureCallback? cameraCaptureCallback = Java.Lang.Object.GetObject<CameraCaptureCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CameraCaptureFailure failure = Java.Lang.Object.GetObject<CameraCaptureFailure>(native_failure, JniHandleOwnership.DoNotTransfer);
		cameraCaptureCallback.OnCaptureFailed(captureConfigId, failure);
	}

	[Register("onCaptureFailed", "(ILandroidx/camera/core/impl/CameraCaptureFailure;)V", "GetOnCaptureFailed_ILandroidx_camera_core_impl_CameraCaptureFailure_Handler")]
	public unsafe virtual void OnCaptureFailed(int captureConfigId, CameraCaptureFailure failure)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(captureConfigId);
			ptr[1] = new JniArgumentValue(failure?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureFailed.(ILandroidx/camera/core/impl/CameraCaptureFailure;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(failure);
		}
	}

	private static Delegate GetOnCaptureProcessProgressed_IIHandler()
	{
		if ((object)cb_onCaptureProcessProgressed_II == null)
		{
			cb_onCaptureProcessProgressed_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_OnCaptureProcessProgressed_II));
		}
		return cb_onCaptureProcessProgressed_II;
	}

	private static void n_OnCaptureProcessProgressed_II(nint jnienv, nint native__this, int captureConfigId, int progress)
	{
		Java.Lang.Object.GetObject<CameraCaptureCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureProcessProgressed(captureConfigId, progress);
	}

	[Register("onCaptureProcessProgressed", "(II)V", "GetOnCaptureProcessProgressed_IIHandler")]
	public unsafe virtual void OnCaptureProcessProgressed(int captureConfigId, int progress)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(captureConfigId);
		ptr[1] = new JniArgumentValue(progress);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureProcessProgressed.(II)V", this, ptr);
	}

	private static Delegate GetOnCaptureStarted_IHandler()
	{
		if ((object)cb_onCaptureStarted_I == null)
		{
			cb_onCaptureStarted_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnCaptureStarted_I));
		}
		return cb_onCaptureStarted_I;
	}

	private static void n_OnCaptureStarted_I(nint jnienv, nint native__this, int captureConfigId)
	{
		Java.Lang.Object.GetObject<CameraCaptureCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureStarted(captureConfigId);
	}

	[Register("onCaptureStarted", "(I)V", "GetOnCaptureStarted_IHandler")]
	public unsafe virtual void OnCaptureStarted(int captureConfigId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(captureConfigId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureStarted.(I)V", this, ptr);
	}
}
