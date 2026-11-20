using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/RequestProcessor", DoNotGenerateAcw = true)]
internal class IRequestProcessorInvoker : Java.Lang.Object, IRequestProcessor, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/RequestProcessor", typeof(IRequestProcessorInvoker));

	private nint class_ref;

	private static Delegate? cb_abortCaptures;

	private nint id_abortCaptures;

	private static Delegate? cb_setRepeating_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_;

	private nint id_setRepeating_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_;

	private static Delegate? cb_stopRepeating;

	private nint id_stopRepeating;

	private static Delegate? cb_submit_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_;

	private nint id_submit_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_;

	private static Delegate? cb_submit_Ljava_util_List_Landroidx_camera_core_impl_RequestProcessor_Callback_;

	private nint id_submit_Ljava_util_List_Landroidx_camera_core_impl_RequestProcessor_Callback_;

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

	public static IRequestProcessor? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IRequestProcessor>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.RequestProcessor'.");
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

	public IRequestProcessorInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetAbortCapturesHandler()
	{
		if ((object)cb_abortCaptures == null)
		{
			cb_abortCaptures = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_AbortCaptures));
		}
		return cb_abortCaptures;
	}

	private static void n_AbortCaptures(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IRequestProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AbortCaptures();
	}

	public void AbortCaptures()
	{
		if (id_abortCaptures == IntPtr.Zero)
		{
			id_abortCaptures = JNIEnv.GetMethodID(class_ref, "abortCaptures", "()V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_abortCaptures);
	}

	private static Delegate GetSetRepeating_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_Handler()
	{
		if ((object)cb_setRepeating_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_ == null)
		{
			cb_setRepeating_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_I(n_SetRepeating_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_));
		}
		return cb_setRepeating_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_;
	}

	private static int n_SetRepeating_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IRequestProcessor? requestProcessor = Java.Lang.Object.GetObject<IRequestProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRequestProcessorRequest p = Java.Lang.Object.GetObject<IRequestProcessorRequest>(native_p0, JniHandleOwnership.DoNotTransfer);
		IRequestProcessorCallback p2 = Java.Lang.Object.GetObject<IRequestProcessorCallback>(native_p1, JniHandleOwnership.DoNotTransfer);
		return requestProcessor.SetRepeating(p, p2);
	}

	public unsafe int SetRepeating(IRequestProcessorRequest p0, IRequestProcessorCallback p1)
	{
		if (id_setRepeating_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_ == IntPtr.Zero)
		{
			id_setRepeating_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_ = JNIEnv.GetMethodID(class_ref, "setRepeating", "(Landroidx/camera/core/impl/RequestProcessor$Request;Landroidx/camera/core/impl/RequestProcessor$Callback;)I");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
		return JNIEnv.CallIntMethod(base.Handle, id_setRepeating_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_, ptr);
	}

	private static Delegate GetStopRepeatingHandler()
	{
		if ((object)cb_stopRepeating == null)
		{
			cb_stopRepeating = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_StopRepeating));
		}
		return cb_stopRepeating;
	}

	private static void n_StopRepeating(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IRequestProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopRepeating();
	}

	public void StopRepeating()
	{
		if (id_stopRepeating == IntPtr.Zero)
		{
			id_stopRepeating = JNIEnv.GetMethodID(class_ref, "stopRepeating", "()V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_stopRepeating);
	}

	private static Delegate GetSubmit_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_Handler()
	{
		if ((object)cb_submit_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_ == null)
		{
			cb_submit_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_I(n_Submit_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_));
		}
		return cb_submit_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_;
	}

	private static int n_Submit_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IRequestProcessor? requestProcessor = Java.Lang.Object.GetObject<IRequestProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IRequestProcessorRequest p = Java.Lang.Object.GetObject<IRequestProcessorRequest>(native_p0, JniHandleOwnership.DoNotTransfer);
		IRequestProcessorCallback p2 = Java.Lang.Object.GetObject<IRequestProcessorCallback>(native_p1, JniHandleOwnership.DoNotTransfer);
		return requestProcessor.Submit(p, p2);
	}

	public unsafe int Submit(IRequestProcessorRequest p0, IRequestProcessorCallback p1)
	{
		if (id_submit_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_ == IntPtr.Zero)
		{
			id_submit_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_ = JNIEnv.GetMethodID(class_ref, "submit", "(Landroidx/camera/core/impl/RequestProcessor$Request;Landroidx/camera/core/impl/RequestProcessor$Callback;)I");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
		return JNIEnv.CallIntMethod(base.Handle, id_submit_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_, ptr);
	}

	private static Delegate GetSubmit_Ljava_util_List_Landroidx_camera_core_impl_RequestProcessor_Callback_Handler()
	{
		if ((object)cb_submit_Ljava_util_List_Landroidx_camera_core_impl_RequestProcessor_Callback_ == null)
		{
			cb_submit_Ljava_util_List_Landroidx_camera_core_impl_RequestProcessor_Callback_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_I(n_Submit_Ljava_util_List_Landroidx_camera_core_impl_RequestProcessor_Callback_));
		}
		return cb_submit_Ljava_util_List_Landroidx_camera_core_impl_RequestProcessor_Callback_;
	}

	private static int n_Submit_Ljava_util_List_Landroidx_camera_core_impl_RequestProcessor_Callback_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IRequestProcessor? requestProcessor = Java.Lang.Object.GetObject<IRequestProcessor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<IRequestProcessorRequest> p = JavaList<IRequestProcessorRequest>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		IRequestProcessorCallback p2 = Java.Lang.Object.GetObject<IRequestProcessorCallback>(native_p1, JniHandleOwnership.DoNotTransfer);
		return requestProcessor.Submit(p, p2);
	}

	public unsafe int Submit(IList<IRequestProcessorRequest> p0, IRequestProcessorCallback p1)
	{
		if (id_submit_Ljava_util_List_Landroidx_camera_core_impl_RequestProcessor_Callback_ == IntPtr.Zero)
		{
			id_submit_Ljava_util_List_Landroidx_camera_core_impl_RequestProcessor_Callback_ = JNIEnv.GetMethodID(class_ref, "submit", "(Ljava/util/List;Landroidx/camera/core/impl/RequestProcessor$Callback;)I");
		}
		nint num = JavaList<IRequestProcessorRequest>.ToLocalJniHandle(p0);
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(num);
		ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
		int result = JNIEnv.CallIntMethod(base.Handle, id_submit_Ljava_util_List_Landroidx_camera_core_impl_RequestProcessor_Callback_, ptr);
		JNIEnv.DeleteLocalRef(num);
		return result;
	}
}
