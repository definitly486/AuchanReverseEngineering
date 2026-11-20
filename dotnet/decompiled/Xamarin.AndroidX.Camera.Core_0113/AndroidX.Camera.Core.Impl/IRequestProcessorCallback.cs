using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/RequestProcessor$Callback", "", "AndroidX.Camera.Core.Impl.IRequestProcessorCallbackInvoker")]
public interface IRequestProcessorCallback : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/RequestProcessor$Callback", typeof(IRequestProcessorCallback), isInterface: true);

	private static Delegate? cb_onCaptureBufferLost_Landroidx_camera_core_impl_RequestProcessor_Request_JI;

	private static Delegate? cb_onCaptureCompleted_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_;

	private static Delegate? cb_onCaptureFailed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureFailure_;

	private static Delegate? cb_onCaptureProgressed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_;

	private static Delegate? cb_onCaptureSequenceAborted_I;

	private static Delegate? cb_onCaptureSequenceCompleted_IJ;

	private static Delegate? cb_onCaptureStarted_Landroidx_camera_core_impl_RequestProcessor_Request_JJ;

	private static Delegate GetOnCaptureBufferLost_Landroidx_camera_core_impl_RequestProcessor_Request_JIHandler()
	{
		if ((object)cb_onCaptureBufferLost_Landroidx_camera_core_impl_RequestProcessor_Request_JI == null)
		{
			cb_onCaptureBufferLost_Landroidx_camera_core_impl_RequestProcessor_Request_JI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLJI_V(n_OnCaptureBufferLost_Landroidx_camera_core_impl_RequestProcessor_Request_JI));
		}
		return cb_onCaptureBufferLost_Landroidx_camera_core_impl_RequestProcessor_Request_JI;
	}

	private static void n_OnCaptureBufferLost_Landroidx_camera_core_impl_RequestProcessor_Request_JI(nint jnienv, nint native__this, nint native_request, long frameNumber, int outputConfigId)
	{
		IRequestProcessorCallback? requestProcessorCallback = Java.Lang.Object.GetObject<IRequestProcessorCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRequestProcessorRequest request = Java.Lang.Object.GetObject<IRequestProcessorRequest>(native_request, JniHandleOwnership.DoNotTransfer);
		requestProcessorCallback.OnCaptureBufferLost(request, frameNumber, outputConfigId);
	}

	[Register("onCaptureBufferLost", "(Landroidx/camera/core/impl/RequestProcessor$Request;JI)V", "GetOnCaptureBufferLost_Landroidx_camera_core_impl_RequestProcessor_Request_JIHandler:AndroidX.Camera.Core.Impl.IRequestProcessorCallback, Xamarin.AndroidX.Camera.Core")]
	unsafe void OnCaptureBufferLost(IRequestProcessorRequest request, long frameNumber, int outputConfigId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((request == null) ? IntPtr.Zero : ((Java.Lang.Object)request).Handle);
			ptr[1] = new JniArgumentValue(frameNumber);
			ptr[2] = new JniArgumentValue(outputConfigId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureBufferLost.(Landroidx/camera/core/impl/RequestProcessor$Request;JI)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(request);
		}
	}

	private static Delegate GetOnCaptureCompleted_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_Handler()
	{
		if ((object)cb_onCaptureCompleted_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_ == null)
		{
			cb_onCaptureCompleted_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnCaptureCompleted_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_));
		}
		return cb_onCaptureCompleted_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_;
	}

	private static void n_OnCaptureCompleted_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_(nint jnienv, nint native__this, nint native_request, nint native_captureResult)
	{
		IRequestProcessorCallback? requestProcessorCallback = Java.Lang.Object.GetObject<IRequestProcessorCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRequestProcessorRequest request = Java.Lang.Object.GetObject<IRequestProcessorRequest>(native_request, JniHandleOwnership.DoNotTransfer);
		ICameraCaptureResult captureResult = Java.Lang.Object.GetObject<ICameraCaptureResult>(native_captureResult, JniHandleOwnership.DoNotTransfer);
		requestProcessorCallback.OnCaptureCompleted(request, captureResult);
	}

	[Register("onCaptureCompleted", "(Landroidx/camera/core/impl/RequestProcessor$Request;Landroidx/camera/core/impl/CameraCaptureResult;)V", "GetOnCaptureCompleted_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_Handler:AndroidX.Camera.Core.Impl.IRequestProcessorCallback, Xamarin.AndroidX.Camera.Core")]
	unsafe void OnCaptureCompleted(IRequestProcessorRequest request, ICameraCaptureResult captureResult)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((request == null) ? IntPtr.Zero : ((Java.Lang.Object)request).Handle);
			ptr[1] = new JniArgumentValue((captureResult == null) ? IntPtr.Zero : ((Java.Lang.Object)captureResult).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureCompleted.(Landroidx/camera/core/impl/RequestProcessor$Request;Landroidx/camera/core/impl/CameraCaptureResult;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(request);
			GC.KeepAlive(captureResult);
		}
	}

	private static Delegate GetOnCaptureFailed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureFailure_Handler()
	{
		if ((object)cb_onCaptureFailed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureFailure_ == null)
		{
			cb_onCaptureFailed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureFailure_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnCaptureFailed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureFailure_));
		}
		return cb_onCaptureFailed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureFailure_;
	}

	private static void n_OnCaptureFailed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureFailure_(nint jnienv, nint native__this, nint native_request, nint native_captureFailure)
	{
		IRequestProcessorCallback? requestProcessorCallback = Java.Lang.Object.GetObject<IRequestProcessorCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRequestProcessorRequest request = Java.Lang.Object.GetObject<IRequestProcessorRequest>(native_request, JniHandleOwnership.DoNotTransfer);
		CameraCaptureFailure captureFailure = Java.Lang.Object.GetObject<CameraCaptureFailure>(native_captureFailure, JniHandleOwnership.DoNotTransfer);
		requestProcessorCallback.OnCaptureFailed(request, captureFailure);
	}

	[Register("onCaptureFailed", "(Landroidx/camera/core/impl/RequestProcessor$Request;Landroidx/camera/core/impl/CameraCaptureFailure;)V", "GetOnCaptureFailed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureFailure_Handler:AndroidX.Camera.Core.Impl.IRequestProcessorCallback, Xamarin.AndroidX.Camera.Core")]
	unsafe void OnCaptureFailed(IRequestProcessorRequest request, CameraCaptureFailure captureFailure)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((request == null) ? IntPtr.Zero : ((Java.Lang.Object)request).Handle);
			ptr[1] = new JniArgumentValue(captureFailure?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureFailed.(Landroidx/camera/core/impl/RequestProcessor$Request;Landroidx/camera/core/impl/CameraCaptureFailure;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(request);
			GC.KeepAlive(captureFailure);
		}
	}

	private static Delegate GetOnCaptureProgressed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_Handler()
	{
		if ((object)cb_onCaptureProgressed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_ == null)
		{
			cb_onCaptureProgressed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnCaptureProgressed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_));
		}
		return cb_onCaptureProgressed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_;
	}

	private static void n_OnCaptureProgressed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_(nint jnienv, nint native__this, nint native_request, nint native_captureResult)
	{
		IRequestProcessorCallback? requestProcessorCallback = Java.Lang.Object.GetObject<IRequestProcessorCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRequestProcessorRequest request = Java.Lang.Object.GetObject<IRequestProcessorRequest>(native_request, JniHandleOwnership.DoNotTransfer);
		ICameraCaptureResult captureResult = Java.Lang.Object.GetObject<ICameraCaptureResult>(native_captureResult, JniHandleOwnership.DoNotTransfer);
		requestProcessorCallback.OnCaptureProgressed(request, captureResult);
	}

	[Register("onCaptureProgressed", "(Landroidx/camera/core/impl/RequestProcessor$Request;Landroidx/camera/core/impl/CameraCaptureResult;)V", "GetOnCaptureProgressed_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_CameraCaptureResult_Handler:AndroidX.Camera.Core.Impl.IRequestProcessorCallback, Xamarin.AndroidX.Camera.Core")]
	unsafe void OnCaptureProgressed(IRequestProcessorRequest request, ICameraCaptureResult captureResult)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((request == null) ? IntPtr.Zero : ((Java.Lang.Object)request).Handle);
			ptr[1] = new JniArgumentValue((captureResult == null) ? IntPtr.Zero : ((Java.Lang.Object)captureResult).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureProgressed.(Landroidx/camera/core/impl/RequestProcessor$Request;Landroidx/camera/core/impl/CameraCaptureResult;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(request);
			GC.KeepAlive(captureResult);
		}
	}

	private static Delegate GetOnCaptureSequenceAborted_IHandler()
	{
		if ((object)cb_onCaptureSequenceAborted_I == null)
		{
			cb_onCaptureSequenceAborted_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnCaptureSequenceAborted_I));
		}
		return cb_onCaptureSequenceAborted_I;
	}

	private static void n_OnCaptureSequenceAborted_I(nint jnienv, nint native__this, int sequenceId)
	{
		Java.Lang.Object.GetObject<IRequestProcessorCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureSequenceAborted(sequenceId);
	}

	[Register("onCaptureSequenceAborted", "(I)V", "GetOnCaptureSequenceAborted_IHandler:AndroidX.Camera.Core.Impl.IRequestProcessorCallback, Xamarin.AndroidX.Camera.Core")]
	unsafe void OnCaptureSequenceAborted(int sequenceId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(sequenceId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureSequenceAborted.(I)V", this, ptr);
	}

	private static Delegate GetOnCaptureSequenceCompleted_IJHandler()
	{
		if ((object)cb_onCaptureSequenceCompleted_IJ == null)
		{
			cb_onCaptureSequenceCompleted_IJ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIJ_V(n_OnCaptureSequenceCompleted_IJ));
		}
		return cb_onCaptureSequenceCompleted_IJ;
	}

	private static void n_OnCaptureSequenceCompleted_IJ(nint jnienv, nint native__this, int sequenceId, long frameNumber)
	{
		Java.Lang.Object.GetObject<IRequestProcessorCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCaptureSequenceCompleted(sequenceId, frameNumber);
	}

	[Register("onCaptureSequenceCompleted", "(IJ)V", "GetOnCaptureSequenceCompleted_IJHandler:AndroidX.Camera.Core.Impl.IRequestProcessorCallback, Xamarin.AndroidX.Camera.Core")]
	unsafe void OnCaptureSequenceCompleted(int sequenceId, long frameNumber)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(sequenceId);
		ptr[1] = new JniArgumentValue(frameNumber);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureSequenceCompleted.(IJ)V", this, ptr);
	}

	private static Delegate GetOnCaptureStarted_Landroidx_camera_core_impl_RequestProcessor_Request_JJHandler()
	{
		if ((object)cb_onCaptureStarted_Landroidx_camera_core_impl_RequestProcessor_Request_JJ == null)
		{
			cb_onCaptureStarted_Landroidx_camera_core_impl_RequestProcessor_Request_JJ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLJJ_V(n_OnCaptureStarted_Landroidx_camera_core_impl_RequestProcessor_Request_JJ));
		}
		return cb_onCaptureStarted_Landroidx_camera_core_impl_RequestProcessor_Request_JJ;
	}

	private static void n_OnCaptureStarted_Landroidx_camera_core_impl_RequestProcessor_Request_JJ(nint jnienv, nint native__this, nint native_request, long frameNumber, long timestamp)
	{
		IRequestProcessorCallback? requestProcessorCallback = Java.Lang.Object.GetObject<IRequestProcessorCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRequestProcessorRequest request = Java.Lang.Object.GetObject<IRequestProcessorRequest>(native_request, JniHandleOwnership.DoNotTransfer);
		requestProcessorCallback.OnCaptureStarted(request, frameNumber, timestamp);
	}

	[Register("onCaptureStarted", "(Landroidx/camera/core/impl/RequestProcessor$Request;JJ)V", "GetOnCaptureStarted_Landroidx_camera_core_impl_RequestProcessor_Request_JJHandler:AndroidX.Camera.Core.Impl.IRequestProcessorCallback, Xamarin.AndroidX.Camera.Core")]
	unsafe void OnCaptureStarted(IRequestProcessorRequest request, long frameNumber, long timestamp)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((request == null) ? IntPtr.Zero : ((Java.Lang.Object)request).Handle);
			ptr[1] = new JniArgumentValue(frameNumber);
			ptr[2] = new JniArgumentValue(timestamp);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCaptureStarted.(Landroidx/camera/core/impl/RequestProcessor$Request;JJ)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(request);
		}
	}
}
