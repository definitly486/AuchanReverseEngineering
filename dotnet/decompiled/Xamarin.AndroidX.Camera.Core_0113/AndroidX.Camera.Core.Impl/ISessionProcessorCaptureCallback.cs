using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/SessionProcessor$CaptureCallback", "", "AndroidX.Camera.Core.Impl.ISessionProcessorCaptureCallbackInvoker")]
public interface ISessionProcessorCaptureCallback : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/SessionProcessor$CaptureCallback", typeof(ISessionProcessorCaptureCallback), isInterface: true);

	private static Delegate? cb_onCaptureCompleted_JILandroidx_camera_core_impl_CameraCaptureResult_;

	private static Delegate? cb_onCaptureFailed_I;

	private static Delegate? cb_onCaptureProcessProgressed_I;

	private static Delegate? cb_onCaptureProcessStarted_I;

	private static Delegate? cb_onCaptureSequenceAborted_I;

	private static Delegate? cb_onCaptureSequenceCompleted_I;

	private static Delegate? cb_onCaptureStarted_IJ;

	private static Delegate GetOnCaptureCompleted_JILandroidx_camera_core_impl_CameraCaptureResult_Handler()
	{
		if ((object)cb_onCaptureCompleted_JILandroidx_camera_core_impl_CameraCaptureResult_ == null)
		{
			cb_onCaptureCompleted_JILandroidx_camera_core_impl_CameraCaptureResult_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPJIL_V(n_OnCaptureCompleted_JILandroidx_camera_core_impl_CameraCaptureResult_));
		}
		return cb_onCaptureCompleted_JILandroidx_camera_core_impl_CameraCaptureResult_;
	}

	private static void n_OnCaptureCompleted_JILandroidx_camera_core_impl_CameraCaptureResult_(nint jnienv, nint native__this, long timestamp, int captureSequenceId, nint native_captureResult)
	{
		ISessionProcessorCaptureCallback? sessionProcessorCaptureCallback = Java.Lang.Object.GetObject<ISessionProcessorCaptureCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICameraCaptureResult captureResult = Java.Lang.Object.GetObject<ICameraCaptureResult>(native_captureResult, JniHandleOwnership.DoNotTransfer);
		sessionProcessorCaptureCallback.OnCaptureCompleted(timestamp, captureSequenceId, captureResult);
	}

	[Register("onCaptureCompleted", "(JILandroidx/camera/core/impl/CameraCaptureResult;)V", "GetOnCaptureCompleted_JILandroidx_camera_core_impl_CameraCaptureResult_Handler:AndroidX.Camera.Core.Impl.ISessionProcessorCaptureCallback, Xamarin.AndroidX.Camera.Core")]
	unsafe void OnCaptureCompleted(long timestamp, int captureSequenceId, ICameraCaptureResult captureResult)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(timestamp);
			ptr[1] = new JniArgumentValue(captureSequenceId);
			ptr[2] = new JniArgumentValue((captureResult == null) ? IntPtr.Zero : ((Java.Lang.Object)captureResult).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureCompleted.(JILandroidx/camera/core/impl/CameraCaptureResult;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(captureResult);
		}
	}

	private static Delegate GetOnCaptureFailed_IHandler()
	{
		if ((object)cb_onCaptureFailed_I == null)
		{
			cb_onCaptureFailed_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnCaptureFailed_I));
		}
		return cb_onCaptureFailed_I;
	}

	private static void n_OnCaptureFailed_I(nint jnienv, nint native__this, int captureSequenceId)
	{
		Java.Lang.Object.GetObject<ISessionProcessorCaptureCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureFailed(captureSequenceId);
	}

	[Register("onCaptureFailed", "(I)V", "GetOnCaptureFailed_IHandler:AndroidX.Camera.Core.Impl.ISessionProcessorCaptureCallback, Xamarin.AndroidX.Camera.Core")]
	unsafe void OnCaptureFailed(int captureSequenceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(captureSequenceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureFailed.(I)V", this, ptr);
	}

	private static Delegate GetOnCaptureProcessProgressed_IHandler()
	{
		if ((object)cb_onCaptureProcessProgressed_I == null)
		{
			cb_onCaptureProcessProgressed_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnCaptureProcessProgressed_I));
		}
		return cb_onCaptureProcessProgressed_I;
	}

	private static void n_OnCaptureProcessProgressed_I(nint jnienv, nint native__this, int progress)
	{
		Java.Lang.Object.GetObject<ISessionProcessorCaptureCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureProcessProgressed(progress);
	}

	[Register("onCaptureProcessProgressed", "(I)V", "GetOnCaptureProcessProgressed_IHandler:AndroidX.Camera.Core.Impl.ISessionProcessorCaptureCallback, Xamarin.AndroidX.Camera.Core")]
	unsafe void OnCaptureProcessProgressed(int progress)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(progress);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureProcessProgressed.(I)V", this, ptr);
	}

	private static Delegate GetOnCaptureProcessStarted_IHandler()
	{
		if ((object)cb_onCaptureProcessStarted_I == null)
		{
			cb_onCaptureProcessStarted_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnCaptureProcessStarted_I));
		}
		return cb_onCaptureProcessStarted_I;
	}

	private static void n_OnCaptureProcessStarted_I(nint jnienv, nint native__this, int captureSequenceId)
	{
		Java.Lang.Object.GetObject<ISessionProcessorCaptureCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureProcessStarted(captureSequenceId);
	}

	[Register("onCaptureProcessStarted", "(I)V", "GetOnCaptureProcessStarted_IHandler:AndroidX.Camera.Core.Impl.ISessionProcessorCaptureCallback, Xamarin.AndroidX.Camera.Core")]
	unsafe void OnCaptureProcessStarted(int captureSequenceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(captureSequenceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureProcessStarted.(I)V", this, ptr);
	}

	private static Delegate GetOnCaptureSequenceAborted_IHandler()
	{
		if ((object)cb_onCaptureSequenceAborted_I == null)
		{
			cb_onCaptureSequenceAborted_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnCaptureSequenceAborted_I));
		}
		return cb_onCaptureSequenceAborted_I;
	}

	private static void n_OnCaptureSequenceAborted_I(nint jnienv, nint native__this, int captureSequenceId)
	{
		Java.Lang.Object.GetObject<ISessionProcessorCaptureCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureSequenceAborted(captureSequenceId);
	}

	[Register("onCaptureSequenceAborted", "(I)V", "GetOnCaptureSequenceAborted_IHandler:AndroidX.Camera.Core.Impl.ISessionProcessorCaptureCallback, Xamarin.AndroidX.Camera.Core")]
	unsafe void OnCaptureSequenceAborted(int captureSequenceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(captureSequenceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureSequenceAborted.(I)V", this, ptr);
	}

	private static Delegate GetOnCaptureSequenceCompleted_IHandler()
	{
		if ((object)cb_onCaptureSequenceCompleted_I == null)
		{
			cb_onCaptureSequenceCompleted_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnCaptureSequenceCompleted_I));
		}
		return cb_onCaptureSequenceCompleted_I;
	}

	private static void n_OnCaptureSequenceCompleted_I(nint jnienv, nint native__this, int captureSequenceId)
	{
		Java.Lang.Object.GetObject<ISessionProcessorCaptureCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureSequenceCompleted(captureSequenceId);
	}

	[Register("onCaptureSequenceCompleted", "(I)V", "GetOnCaptureSequenceCompleted_IHandler:AndroidX.Camera.Core.Impl.ISessionProcessorCaptureCallback, Xamarin.AndroidX.Camera.Core")]
	unsafe void OnCaptureSequenceCompleted(int captureSequenceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(captureSequenceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureSequenceCompleted.(I)V", this, ptr);
	}

	private static Delegate GetOnCaptureStarted_IJHandler()
	{
		if ((object)cb_onCaptureStarted_IJ == null)
		{
			cb_onCaptureStarted_IJ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIJ_V(n_OnCaptureStarted_IJ));
		}
		return cb_onCaptureStarted_IJ;
	}

	private static void n_OnCaptureStarted_IJ(nint jnienv, nint native__this, int captureSequenceId, long timestamp)
	{
		Java.Lang.Object.GetObject<ISessionProcessorCaptureCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureStarted(captureSequenceId, timestamp);
	}

	[Register("onCaptureStarted", "(IJ)V", "GetOnCaptureStarted_IJHandler:AndroidX.Camera.Core.Impl.ISessionProcessorCaptureCallback, Xamarin.AndroidX.Camera.Core")]
	unsafe void OnCaptureStarted(int captureSequenceId, long timestamp)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(captureSequenceId);
		ptr[1] = new JniArgumentValue(timestamp);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureStarted.(IJ)V", this, ptr);
	}
}
