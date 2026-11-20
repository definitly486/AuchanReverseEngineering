using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Observable$Observer", DoNotGenerateAcw = true)]
internal class IObservableObserverInvoker : Java.Lang.Object, IObservableObserver, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/Observable$Observer", typeof(IObservableObserverInvoker));

	private nint class_ref;

	private static Delegate? cb_onError_Ljava_lang_Throwable_;

	private nint id_onError_Ljava_lang_Throwable_;

	private static Delegate? cb_onNewData_Ljava_lang_Object_;

	private nint id_onNewData_Ljava_lang_Object_;

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

	public static IObservableObserver? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IObservableObserver>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.impl.Observable.Observer'.");
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

	public IObservableObserverInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetOnError_Ljava_lang_Throwable_Handler()
	{
		if ((object)cb_onError_Ljava_lang_Throwable_ == null)
		{
			cb_onError_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnError_Ljava_lang_Throwable_));
		}
		return cb_onError_Ljava_lang_Throwable_;
	}

	private static void n_OnError_Ljava_lang_Throwable_(nint jnienv, nint native__this, nint native_p0)
	{
		IObservableObserver? observableObserver = Java.Lang.Object.GetObject<IObservableObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
		observableObserver.OnError(p);
	}

	public unsafe void OnError(Throwable p0)
	{
		if (id_onError_Ljava_lang_Throwable_ == IntPtr.Zero)
		{
			id_onError_Ljava_lang_Throwable_ = JNIEnv.GetMethodID(class_ref, "onError", "(Ljava/lang/Throwable;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_onError_Ljava_lang_Throwable_, ptr);
	}

	private static Delegate GetOnNewData_Ljava_lang_Object_Handler()
	{
		if ((object)cb_onNewData_Ljava_lang_Object_ == null)
		{
			cb_onNewData_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnNewData_Ljava_lang_Object_));
		}
		return cb_onNewData_Ljava_lang_Object_;
	}

	private static void n_OnNewData_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_p0)
	{
		IObservableObserver? observableObserver = Java.Lang.Object.GetObject<IObservableObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
		observableObserver.OnNewData(p);
	}

	public unsafe void OnNewData(Java.Lang.Object? p0)
	{
		if (id_onNewData_Ljava_lang_Object_ == IntPtr.Zero)
		{
			id_onNewData_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "onNewData", "(Ljava/lang/Object;)V");
		}
		nint num = JNIEnv.ToLocalJniHandle(p0);
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(num);
		JNIEnv.CallVoidMethod(base.Handle, id_onNewData_Ljava_lang_Object_, ptr);
		JNIEnv.DeleteLocalRef(num);
	}
}
