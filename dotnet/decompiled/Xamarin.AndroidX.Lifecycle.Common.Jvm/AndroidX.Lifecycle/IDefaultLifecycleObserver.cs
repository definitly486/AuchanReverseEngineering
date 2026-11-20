using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/DefaultLifecycleObserver", "", "AndroidX.Lifecycle.IDefaultLifecycleObserverInvoker")]
public interface IDefaultLifecycleObserver : ILifecycleObserver, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/DefaultLifecycleObserver", typeof(IDefaultLifecycleObserver), isInterface: true);

	private static Delegate? cb_onCreate_OnCreate_Landroidx_lifecycle_LifecycleOwner__V;

	private static Delegate? cb_onDestroy_OnDestroy_Landroidx_lifecycle_LifecycleOwner__V;

	private static Delegate? cb_onPause_OnPause_Landroidx_lifecycle_LifecycleOwner__V;

	private static Delegate? cb_onResume_OnResume_Landroidx_lifecycle_LifecycleOwner__V;

	private static Delegate? cb_onStart_OnStart_Landroidx_lifecycle_LifecycleOwner__V;

	private static Delegate? cb_onStop_OnStop_Landroidx_lifecycle_LifecycleOwner__V;

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCreate_Landroidx_lifecycle_LifecycleOwner_(nint jnienv, nint native__this, nint native_owner)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDefaultLifecycleObserver? defaultLifecycleObserver = Java.Lang.Object.GetObject<IDefaultLifecycleObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner owner = Java.Lang.Object.GetObject<ILifecycleOwner>(native_owner, JniHandleOwnership.DoNotTransfer);
			defaultLifecycleObserver.OnCreate(owner);
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

	[Register("onCreate", "(Landroidx/lifecycle/LifecycleOwner;)V", "GetOnCreate_Landroidx_lifecycle_LifecycleOwner_Handler:AndroidX.Lifecycle.IDefaultLifecycleObserver, Xamarin.AndroidX.Lifecycle.Common.Jvm")]
	unsafe void OnCreate(ILifecycleOwner owner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCreate.(Landroidx/lifecycle/LifecycleOwner;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(owner);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDestroy_Landroidx_lifecycle_LifecycleOwner_(nint jnienv, nint native__this, nint native_owner)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDefaultLifecycleObserver? defaultLifecycleObserver = Java.Lang.Object.GetObject<IDefaultLifecycleObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner owner = Java.Lang.Object.GetObject<ILifecycleOwner>(native_owner, JniHandleOwnership.DoNotTransfer);
			defaultLifecycleObserver.OnDestroy(owner);
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

	[Register("onDestroy", "(Landroidx/lifecycle/LifecycleOwner;)V", "GetOnDestroy_Landroidx_lifecycle_LifecycleOwner_Handler:AndroidX.Lifecycle.IDefaultLifecycleObserver, Xamarin.AndroidX.Lifecycle.Common.Jvm")]
	unsafe void OnDestroy(ILifecycleOwner owner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDestroy.(Landroidx/lifecycle/LifecycleOwner;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(owner);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPause_Landroidx_lifecycle_LifecycleOwner_(nint jnienv, nint native__this, nint native_owner)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDefaultLifecycleObserver? defaultLifecycleObserver = Java.Lang.Object.GetObject<IDefaultLifecycleObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner owner = Java.Lang.Object.GetObject<ILifecycleOwner>(native_owner, JniHandleOwnership.DoNotTransfer);
			defaultLifecycleObserver.OnPause(owner);
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

	[Register("onPause", "(Landroidx/lifecycle/LifecycleOwner;)V", "GetOnPause_Landroidx_lifecycle_LifecycleOwner_Handler:AndroidX.Lifecycle.IDefaultLifecycleObserver, Xamarin.AndroidX.Lifecycle.Common.Jvm")]
	unsafe void OnPause(ILifecycleOwner owner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPause.(Landroidx/lifecycle/LifecycleOwner;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(owner);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnResume_Landroidx_lifecycle_LifecycleOwner_(nint jnienv, nint native__this, nint native_owner)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDefaultLifecycleObserver? defaultLifecycleObserver = Java.Lang.Object.GetObject<IDefaultLifecycleObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner owner = Java.Lang.Object.GetObject<ILifecycleOwner>(native_owner, JniHandleOwnership.DoNotTransfer);
			defaultLifecycleObserver.OnResume(owner);
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

	[Register("onResume", "(Landroidx/lifecycle/LifecycleOwner;)V", "GetOnResume_Landroidx_lifecycle_LifecycleOwner_Handler:AndroidX.Lifecycle.IDefaultLifecycleObserver, Xamarin.AndroidX.Lifecycle.Common.Jvm")]
	unsafe void OnResume(ILifecycleOwner owner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onResume.(Landroidx/lifecycle/LifecycleOwner;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(owner);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStart_Landroidx_lifecycle_LifecycleOwner_(nint jnienv, nint native__this, nint native_owner)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDefaultLifecycleObserver? defaultLifecycleObserver = Java.Lang.Object.GetObject<IDefaultLifecycleObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner owner = Java.Lang.Object.GetObject<ILifecycleOwner>(native_owner, JniHandleOwnership.DoNotTransfer);
			defaultLifecycleObserver.OnStart(owner);
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

	[Register("onStart", "(Landroidx/lifecycle/LifecycleOwner;)V", "GetOnStart_Landroidx_lifecycle_LifecycleOwner_Handler:AndroidX.Lifecycle.IDefaultLifecycleObserver, Xamarin.AndroidX.Lifecycle.Common.Jvm")]
	unsafe void OnStart(ILifecycleOwner owner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStart.(Landroidx/lifecycle/LifecycleOwner;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(owner);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStop_Landroidx_lifecycle_LifecycleOwner_(nint jnienv, nint native__this, nint native_owner)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDefaultLifecycleObserver? defaultLifecycleObserver = Java.Lang.Object.GetObject<IDefaultLifecycleObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner owner = Java.Lang.Object.GetObject<ILifecycleOwner>(native_owner, JniHandleOwnership.DoNotTransfer);
			defaultLifecycleObserver.OnStop(owner);
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

	[Register("onStop", "(Landroidx/lifecycle/LifecycleOwner;)V", "GetOnStop_Landroidx_lifecycle_LifecycleOwner_Handler:AndroidX.Lifecycle.IDefaultLifecycleObserver, Xamarin.AndroidX.Lifecycle.Common.Jvm")]
	unsafe void OnStop(ILifecycleOwner owner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStop.(Landroidx/lifecycle/LifecycleOwner;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(owner);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnCreate_Landroidx_lifecycle_LifecycleOwner__mm_wrapper(nint jnienv, nint native__this, nint native_owner)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnCreate_Landroidx_lifecycle_LifecycleOwner_(jnienv, native__this, native_owner);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnDestroy_Landroidx_lifecycle_LifecycleOwner__mm_wrapper(nint jnienv, nint native__this, nint native_owner)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnDestroy_Landroidx_lifecycle_LifecycleOwner_(jnienv, native__this, native_owner);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnPause_Landroidx_lifecycle_LifecycleOwner__mm_wrapper(nint jnienv, nint native__this, nint native_owner)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnPause_Landroidx_lifecycle_LifecycleOwner_(jnienv, native__this, native_owner);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnResume_Landroidx_lifecycle_LifecycleOwner__mm_wrapper(nint jnienv, nint native__this, nint native_owner)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnResume_Landroidx_lifecycle_LifecycleOwner_(jnienv, native__this, native_owner);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnStart_Landroidx_lifecycle_LifecycleOwner__mm_wrapper(nint jnienv, nint native__this, nint native_owner)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnStart_Landroidx_lifecycle_LifecycleOwner_(jnienv, native__this, native_owner);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnStop_Landroidx_lifecycle_LifecycleOwner__mm_wrapper(nint jnienv, nint native__this, nint native_owner)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnStop_Landroidx_lifecycle_LifecycleOwner_(jnienv, native__this, native_owner);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
