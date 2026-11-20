using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Google.Common.Util.Concurrent;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Observable", DoNotGenerateAcw = true)]
internal class IObservableInvoker : Java.Lang.Object, IObservable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/Observable", typeof(IObservableInvoker));

	private nint class_ref;

	private static Delegate? cb_addObserver_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_Observable_Observer_;

	private nint id_addObserver_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_Observable_Observer_;

	private static Delegate? cb_fetchData;

	private nint id_fetchData;

	private static Delegate? cb_removeObserver_Landroidx_camera_core_impl_Observable_Observer_;

	private nint id_removeObserver_Landroidx_camera_core_impl_Observable_Observer_;

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

	public static IObservable? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IObservable>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.Observable'.");
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

	public IObservableInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetAddObserver_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_Observable_Observer_Handler()
	{
		if ((object)cb_addObserver_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_Observable_Observer_ == null)
		{
			cb_addObserver_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_Observable_Observer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_AddObserver_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_Observable_Observer_));
		}
		return cb_addObserver_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_Observable_Observer_;
	}

	private static void n_AddObserver_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_Observable_Observer_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IObservable? observable = Java.Lang.Object.GetObject<IObservable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IExecutor p = Java.Lang.Object.GetObject<IExecutor>(native_p0, JniHandleOwnership.DoNotTransfer);
		IObservableObserver p2 = Java.Lang.Object.GetObject<IObservableObserver>(native_p1, JniHandleOwnership.DoNotTransfer);
		observable.AddObserver(p, p2);
	}

	public unsafe void AddObserver(IExecutor p0, IObservableObserver p1)
	{
		if (id_addObserver_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_Observable_Observer_ == IntPtr.Zero)
		{
			id_addObserver_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_Observable_Observer_ = JNIEnv.GetMethodID(class_ref, "addObserver", "(Ljava/util/concurrent/Executor;Landroidx/camera/core/impl/Observable$Observer;)V");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
		JNIEnv.CallVoidMethod(base.Handle, id_addObserver_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_Observable_Observer_, ptr);
	}

	private static Delegate GetFetchDataHandler()
	{
		if ((object)cb_fetchData == null)
		{
			cb_fetchData = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_FetchData));
		}
		return cb_fetchData;
	}

	private static nint n_FetchData(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IObservable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FetchData());
	}

	public IListenableFuture FetchData()
	{
		if (id_fetchData == IntPtr.Zero)
		{
			id_fetchData = JNIEnv.GetMethodID(class_ref, "fetchData", "()Lcom/google/common/util/concurrent/ListenableFuture;");
		}
		return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_fetchData), JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemoveObserver_Landroidx_camera_core_impl_Observable_Observer_Handler()
	{
		if ((object)cb_removeObserver_Landroidx_camera_core_impl_Observable_Observer_ == null)
		{
			cb_removeObserver_Landroidx_camera_core_impl_Observable_Observer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveObserver_Landroidx_camera_core_impl_Observable_Observer_));
		}
		return cb_removeObserver_Landroidx_camera_core_impl_Observable_Observer_;
	}

	private static void n_RemoveObserver_Landroidx_camera_core_impl_Observable_Observer_(nint jnienv, nint native__this, nint native_p0)
	{
		IObservable? observable = Java.Lang.Object.GetObject<IObservable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IObservableObserver p = Java.Lang.Object.GetObject<IObservableObserver>(native_p0, JniHandleOwnership.DoNotTransfer);
		observable.RemoveObserver(p);
	}

	public unsafe void RemoveObserver(IObservableObserver p0)
	{
		if (id_removeObserver_Landroidx_camera_core_impl_Observable_Observer_ == IntPtr.Zero)
		{
			id_removeObserver_Landroidx_camera_core_impl_Observable_Observer_ = JNIEnv.GetMethodID(class_ref, "removeObserver", "(Landroidx/camera/core/impl/Observable$Observer;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
		JNIEnv.CallVoidMethod(base.Handle, id_removeObserver_Landroidx_camera_core_impl_Observable_Observer_, ptr);
	}
}
