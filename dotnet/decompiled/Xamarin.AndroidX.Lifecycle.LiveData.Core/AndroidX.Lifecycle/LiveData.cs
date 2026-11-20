using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/LiveData", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "T" })]
public abstract class LiveData : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/LiveData", typeof(LiveData));

	private static Delegate? cb_hasActiveObservers_HasActiveObservers_Z;

	private static Delegate? cb_hasObservers_HasObservers_Z;

	private static Delegate? cb_isInitialized_IsInitialized_Z;

	private static Delegate? cb_getValue_GetValue_Ljava_lang_Object_;

	private static Delegate? cb_observe_Observe_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Observer__V;

	private static Delegate? cb_observeForever_ObserveForever_Landroidx_lifecycle_Observer__V;

	private static Delegate? cb_onActive_OnActive_V;

	private static Delegate? cb_onInactive_OnInactive_V;

	private static Delegate? cb_postValue_PostValue_Ljava_lang_Object__V;

	private static Delegate? cb_removeObserver_RemoveObserver_Landroidx_lifecycle_Observer__V;

	private static Delegate? cb_removeObservers_RemoveObservers_Landroidx_lifecycle_LifecycleOwner__V;

	private static Delegate? cb_setValue_SetValue_Ljava_lang_Object__V;

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

	public unsafe virtual bool HasActiveObservers
	{
		[Register("hasActiveObservers", "()Z", "GetHasActiveObserversHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasActiveObservers.()Z", this, null);
		}
	}

	public unsafe virtual bool HasObservers
	{
		[Register("hasObservers", "()Z", "GetHasObserversHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasObservers.()Z", this, null);
		}
	}

	public unsafe virtual bool IsInitialized
	{
		[Register("isInitialized", "()Z", "GetIsInitializedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInitialized.()Z", this, null);
		}
	}

	public unsafe virtual Java.Lang.Object? Value
	{
		[Register("getValue", "()Ljava/lang/Object;", "GetGetValueHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getValue.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected LiveData(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe LiveData()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Ljava/lang/Object;)V", "")]
	public unsafe LiveData(Java.Lang.Object? value)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Object;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetHasActiveObserversHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasActiveObservers);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasActiveObservers(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasActiveObservers ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetHasObserversHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasObservers);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasObservers(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasObservers ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsInitializedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsInitialized);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsInitialized(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsInitialized ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetValueHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetObserve_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Observer_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_Observe_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Observer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Observe_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Observer_(nint jnienv, nint native__this, nint native_owner, nint native_observer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LiveData? liveData = Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner owner = Java.Lang.Object.GetObject<ILifecycleOwner>(native_owner, JniHandleOwnership.DoNotTransfer);
			IObserver observer = Java.Lang.Object.GetObject<IObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			liveData.Observe(owner, observer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("observe", "(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Observer;)V", "GetObserve_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Observer_Handler")]
	public unsafe virtual void Observe(ILifecycleOwner? owner, IObserver? observer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			ptr[1] = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("observe.(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Observer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(owner);
			GC.KeepAlive(observer);
		}
	}

	private static Delegate GetObserveForever_Landroidx_lifecycle_Observer_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_ObserveForever_Landroidx_lifecycle_Observer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ObserveForever_Landroidx_lifecycle_Observer_(nint jnienv, nint native__this, nint native_observer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LiveData? liveData = Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IObserver observer = Java.Lang.Object.GetObject<IObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			liveData.ObserveForever(observer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("observeForever", "(Landroidx/lifecycle/Observer;)V", "GetObserveForever_Landroidx_lifecycle_Observer_Handler")]
	public unsafe virtual void ObserveForever(IObserver? observer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("observeForever.(Landroidx/lifecycle/Observer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(observer);
		}
	}

	private static Delegate GetOnActiveHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnActive);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnActive(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnActive();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onActive", "()V", "GetOnActiveHandler")]
	protected unsafe virtual void OnActive()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onActive.()V", this, null);
	}

	private static Delegate GetOnInactiveHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnInactive);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnInactive(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnInactive();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onInactive", "()V", "GetOnInactiveHandler")]
	protected unsafe virtual void OnInactive()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onInactive.()V", this, null);
	}

	private static Delegate GetPostValue_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_PostValue_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PostValue_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LiveData? liveData = Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			liveData.PostValue(value);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("postValue", "(Ljava/lang/Object;)V", "GetPostValue_Ljava_lang_Object_Handler")]
	protected unsafe virtual void PostValue(Java.Lang.Object? value)
	{
		nint num = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("postValue.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetRemoveObserver_Landroidx_lifecycle_Observer_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveObserver_Landroidx_lifecycle_Observer_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveObserver_Landroidx_lifecycle_Observer_(nint jnienv, nint native__this, nint native_observer)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LiveData? liveData = Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IObserver observer = Java.Lang.Object.GetObject<IObserver>(native_observer, JniHandleOwnership.DoNotTransfer);
			liveData.RemoveObserver(observer);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("removeObserver", "(Landroidx/lifecycle/Observer;)V", "GetRemoveObserver_Landroidx_lifecycle_Observer_Handler")]
	public unsafe virtual void RemoveObserver(IObserver? observer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeObserver.(Landroidx/lifecycle/Observer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(observer);
		}
	}

	private static Delegate GetRemoveObservers_Landroidx_lifecycle_LifecycleOwner_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveObservers_Landroidx_lifecycle_LifecycleOwner_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveObservers_Landroidx_lifecycle_LifecycleOwner_(nint jnienv, nint native__this, nint native_owner)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LiveData? liveData = Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner owner = Java.Lang.Object.GetObject<ILifecycleOwner>(native_owner, JniHandleOwnership.DoNotTransfer);
			liveData.RemoveObservers(owner);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("removeObservers", "(Landroidx/lifecycle/LifecycleOwner;)V", "GetRemoveObservers_Landroidx_lifecycle_LifecycleOwner_Handler")]
	public unsafe virtual void RemoveObservers(ILifecycleOwner? owner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeObservers.(Landroidx/lifecycle/LifecycleOwner;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(owner);
		}
	}

	private static Delegate GetSetValue_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetValue_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetValue_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			LiveData? liveData = Java.Lang.Object.GetObject<LiveData>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			liveData.SetValue(value);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setValue", "(Ljava/lang/Object;)V", "GetSetValue_Ljava_lang_Object_Handler")]
	protected unsafe virtual void SetValue(Java.Lang.Object? value)
	{
		nint num = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setValue.(Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
	}
}
