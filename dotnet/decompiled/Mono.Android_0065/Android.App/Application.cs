using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.App;

[Register("android/app/Application", DoNotGenerateAcw = true)]
public class Application : ContextWrapper, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("android/app/Application$ActivityLifecycleCallbacks", "", "Android.App.Application/IActivityLifecycleCallbacksInvoker")]
	public interface IActivityLifecycleCallbacks : IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("android/app/Application$ActivityLifecycleCallbacks", typeof(IActivityLifecycleCallbacks), isInterface: true);

		private static Delegate? cb_onActivityPostCreated_OnActivityPostCreated_Landroid_app_Activity_Landroid_os_Bundle__V;

		private static Delegate? cb_onActivityPostDestroyed_OnActivityPostDestroyed_Landroid_app_Activity__V;

		private static Delegate? cb_onActivityPostPaused_OnActivityPostPaused_Landroid_app_Activity__V;

		private static Delegate? cb_onActivityPostResumed_OnActivityPostResumed_Landroid_app_Activity__V;

		private static Delegate? cb_onActivityPostSaveInstanceState_OnActivityPostSaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle__V;

		private static Delegate? cb_onActivityPostStarted_OnActivityPostStarted_Landroid_app_Activity__V;

		private static Delegate? cb_onActivityPostStopped_OnActivityPostStopped_Landroid_app_Activity__V;

		private static Delegate? cb_onActivityPreCreated_OnActivityPreCreated_Landroid_app_Activity_Landroid_os_Bundle__V;

		private static Delegate? cb_onActivityPreDestroyed_OnActivityPreDestroyed_Landroid_app_Activity__V;

		private static Delegate? cb_onActivityPrePaused_OnActivityPrePaused_Landroid_app_Activity__V;

		private static Delegate? cb_onActivityPreResumed_OnActivityPreResumed_Landroid_app_Activity__V;

		private static Delegate? cb_onActivityPreSaveInstanceState_OnActivityPreSaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle__V;

		private static Delegate? cb_onActivityPreStarted_OnActivityPreStarted_Landroid_app_Activity__V;

		private static Delegate? cb_onActivityPreStopped_OnActivityPreStopped_Landroid_app_Activity__V;

		[Register("onActivityCreated", "(Landroid/app/Activity;Landroid/os/Bundle;)V", "GetOnActivityCreated_Landroid_app_Activity_Landroid_os_Bundle_Handler:Android.App.Application/IActivityLifecycleCallbacksInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnActivityCreated(Activity activity, Bundle? savedInstanceState);

		[Register("onActivityDestroyed", "(Landroid/app/Activity;)V", "GetOnActivityDestroyed_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacksInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnActivityDestroyed(Activity activity);

		[Register("onActivityPaused", "(Landroid/app/Activity;)V", "GetOnActivityPaused_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacksInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnActivityPaused(Activity activity);

		[Register("onActivityResumed", "(Landroid/app/Activity;)V", "GetOnActivityResumed_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacksInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnActivityResumed(Activity activity);

		[Register("onActivitySaveInstanceState", "(Landroid/app/Activity;Landroid/os/Bundle;)V", "GetOnActivitySaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle_Handler:Android.App.Application/IActivityLifecycleCallbacksInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnActivitySaveInstanceState(Activity activity, Bundle outState);

		[Register("onActivityStarted", "(Landroid/app/Activity;)V", "GetOnActivityStarted_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacksInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnActivityStarted(Activity activity);

		[Register("onActivityStopped", "(Landroid/app/Activity;)V", "GetOnActivityStopped_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacksInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		void OnActivityStopped(Activity activity);

		[SupportedOSPlatform("android29.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPostCreated_Landroid_app_Activity_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_activity, nint native_savedInstanceState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPostCreated(activity, savedInstanceState);
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

		[SupportedOSPlatform("android29.0")]
		[Register("onActivityPostCreated", "(Landroid/app/Activity;Landroid/os/Bundle;)V", "GetOnActivityPostCreated_Landroid_app_Activity_Landroid_os_Bundle_Handler:Android.App.Application/IActivityLifecycleCallbacks, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		unsafe void OnActivityPostCreated(Activity activity, Bundle? savedInstanceState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityPostCreated.(Landroid/app/Activity;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(savedInstanceState);
			}
		}

		[SupportedOSPlatform("android29.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPostDestroyed_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPostDestroyed(activity);
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

		[SupportedOSPlatform("android29.0")]
		[Register("onActivityPostDestroyed", "(Landroid/app/Activity;)V", "GetOnActivityPostDestroyed_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacks, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		unsafe void OnActivityPostDestroyed(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityPostDestroyed.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[SupportedOSPlatform("android29.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPostPaused_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPostPaused(activity);
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

		[SupportedOSPlatform("android29.0")]
		[Register("onActivityPostPaused", "(Landroid/app/Activity;)V", "GetOnActivityPostPaused_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacks, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		unsafe void OnActivityPostPaused(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityPostPaused.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[SupportedOSPlatform("android29.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPostResumed_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPostResumed(activity);
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

		[SupportedOSPlatform("android29.0")]
		[Register("onActivityPostResumed", "(Landroid/app/Activity;)V", "GetOnActivityPostResumed_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacks, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		unsafe void OnActivityPostResumed(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityPostResumed.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[SupportedOSPlatform("android29.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPostSaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_activity, nint native_outState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				Bundle outState = Java.Lang.Object.GetObject<Bundle>(native_outState, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPostSaveInstanceState(activity, outState);
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

		[SupportedOSPlatform("android29.0")]
		[Register("onActivityPostSaveInstanceState", "(Landroid/app/Activity;Landroid/os/Bundle;)V", "GetOnActivityPostSaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle_Handler:Android.App.Application/IActivityLifecycleCallbacks, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		unsafe void OnActivityPostSaveInstanceState(Activity activity, Bundle outState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(outState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityPostSaveInstanceState.(Landroid/app/Activity;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(outState);
			}
		}

		[SupportedOSPlatform("android29.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPostStarted_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPostStarted(activity);
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

		[SupportedOSPlatform("android29.0")]
		[Register("onActivityPostStarted", "(Landroid/app/Activity;)V", "GetOnActivityPostStarted_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacks, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		unsafe void OnActivityPostStarted(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityPostStarted.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[SupportedOSPlatform("android29.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPostStopped_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPostStopped(activity);
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

		[SupportedOSPlatform("android29.0")]
		[Register("onActivityPostStopped", "(Landroid/app/Activity;)V", "GetOnActivityPostStopped_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacks, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		unsafe void OnActivityPostStopped(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityPostStopped.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[SupportedOSPlatform("android29.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPreCreated_Landroid_app_Activity_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_activity, nint native_savedInstanceState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPreCreated(activity, savedInstanceState);
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

		[SupportedOSPlatform("android29.0")]
		[Register("onActivityPreCreated", "(Landroid/app/Activity;Landroid/os/Bundle;)V", "GetOnActivityPreCreated_Landroid_app_Activity_Landroid_os_Bundle_Handler:Android.App.Application/IActivityLifecycleCallbacks, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		unsafe void OnActivityPreCreated(Activity activity, Bundle? savedInstanceState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityPreCreated.(Landroid/app/Activity;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(savedInstanceState);
			}
		}

		[SupportedOSPlatform("android29.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPreDestroyed_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPreDestroyed(activity);
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

		[SupportedOSPlatform("android29.0")]
		[Register("onActivityPreDestroyed", "(Landroid/app/Activity;)V", "GetOnActivityPreDestroyed_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacks, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		unsafe void OnActivityPreDestroyed(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityPreDestroyed.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[SupportedOSPlatform("android29.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPrePaused_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPrePaused(activity);
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

		[SupportedOSPlatform("android29.0")]
		[Register("onActivityPrePaused", "(Landroid/app/Activity;)V", "GetOnActivityPrePaused_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacks, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		unsafe void OnActivityPrePaused(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityPrePaused.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[SupportedOSPlatform("android29.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPreResumed_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPreResumed(activity);
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

		[SupportedOSPlatform("android29.0")]
		[Register("onActivityPreResumed", "(Landroid/app/Activity;)V", "GetOnActivityPreResumed_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacks, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		unsafe void OnActivityPreResumed(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityPreResumed.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[SupportedOSPlatform("android29.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPreSaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_activity, nint native_outState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				Bundle outState = Java.Lang.Object.GetObject<Bundle>(native_outState, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPreSaveInstanceState(activity, outState);
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

		[SupportedOSPlatform("android29.0")]
		[Register("onActivityPreSaveInstanceState", "(Landroid/app/Activity;Landroid/os/Bundle;)V", "GetOnActivityPreSaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle_Handler:Android.App.Application/IActivityLifecycleCallbacks, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		unsafe void OnActivityPreSaveInstanceState(Activity activity, Bundle outState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(outState?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityPreSaveInstanceState.(Landroid/app/Activity;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(outState);
			}
		}

		[SupportedOSPlatform("android29.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPreStarted_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPreStarted(activity);
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

		[SupportedOSPlatform("android29.0")]
		[Register("onActivityPreStarted", "(Landroid/app/Activity;)V", "GetOnActivityPreStarted_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacks, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		unsafe void OnActivityPreStarted(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityPreStarted.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[SupportedOSPlatform("android29.0")]
		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPreStopped_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPreStopped(activity);
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

		[SupportedOSPlatform("android29.0")]
		[Register("onActivityPreStopped", "(Landroid/app/Activity;)V", "GetOnActivityPreStopped_Landroid_app_Activity_Handler:Android.App.Application/IActivityLifecycleCallbacks, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		unsafe void OnActivityPreStopped(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onActivityPreStopped.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPostCreated_Landroid_app_Activity_Landroid_os_Bundle__mm_wrapper(nint jnienv, nint native__this, nint native_activity, nint native_savedInstanceState)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPostCreated_Landroid_app_Activity_Landroid_os_Bundle_(jnienv, native__this, native_activity, native_savedInstanceState);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPostDestroyed_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPostDestroyed_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPostPaused_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPostPaused_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPostResumed_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPostResumed_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPostSaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle__mm_wrapper(nint jnienv, nint native__this, nint native_activity, nint native_outState)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPostSaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle_(jnienv, native__this, native_activity, native_outState);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPostStarted_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPostStarted_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPostStopped_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPostStopped_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPreCreated_Landroid_app_Activity_Landroid_os_Bundle__mm_wrapper(nint jnienv, nint native__this, nint native_activity, nint native_savedInstanceState)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPreCreated_Landroid_app_Activity_Landroid_os_Bundle_(jnienv, native__this, native_activity, native_savedInstanceState);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPreDestroyed_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPreDestroyed_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPrePaused_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPrePaused_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPreResumed_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPreResumed_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPreSaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle__mm_wrapper(nint jnienv, nint native__this, nint native_activity, nint native_outState)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPreSaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle_(jnienv, native__this, native_activity, native_outState);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPreStarted_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPreStarted_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPreStopped_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPreStopped_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	[Register("android/app/Application$ActivityLifecycleCallbacks", DoNotGenerateAcw = true)]
	internal class IActivityLifecycleCallbacksInvoker : Java.Lang.Object, IActivityLifecycleCallbacks, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_android_app_Application_ActivityLifecycleCallbacks = new XAPeerMembers("android/app/Application$ActivityLifecycleCallbacks", typeof(IActivityLifecycleCallbacksInvoker));

		private static Delegate? cb_onActivityCreated_OnActivityCreated_Landroid_app_Activity_Landroid_os_Bundle__V;

		private static Delegate? cb_onActivityDestroyed_OnActivityDestroyed_Landroid_app_Activity__V;

		private static Delegate? cb_onActivityPaused_OnActivityPaused_Landroid_app_Activity__V;

		private static Delegate? cb_onActivityResumed_OnActivityResumed_Landroid_app_Activity__V;

		private static Delegate? cb_onActivitySaveInstanceState_OnActivitySaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle__V;

		private static Delegate? cb_onActivityStarted_OnActivityStarted_Landroid_app_Activity__V;

		private static Delegate? cb_onActivityStopped_OnActivityStopped_Landroid_app_Activity__V;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_android_app_Application_ActivityLifecycleCallbacks;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_android_app_Application_ActivityLifecycleCallbacks.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_android_app_Application_ActivityLifecycleCallbacks.ManagedPeerType;

		public IActivityLifecycleCallbacksInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityCreated_Landroid_app_Activity_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_activity, nint native_savedInstanceState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityCreated(activity, savedInstanceState);
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

		public unsafe void OnActivityCreated(Activity activity, Bundle? savedInstanceState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
				_members_android_app_Application_ActivityLifecycleCallbacks.InstanceMethods.InvokeAbstractVoidMethod("onActivityCreated.(Landroid/app/Activity;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(savedInstanceState);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityDestroyed_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityDestroyed(activity);
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

		public unsafe void OnActivityDestroyed(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members_android_app_Application_ActivityLifecycleCallbacks.InstanceMethods.InvokeAbstractVoidMethod("onActivityDestroyed.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityPaused_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityPaused(activity);
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

		public unsafe void OnActivityPaused(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members_android_app_Application_ActivityLifecycleCallbacks.InstanceMethods.InvokeAbstractVoidMethod("onActivityPaused.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityResumed_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityResumed(activity);
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

		public unsafe void OnActivityResumed(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members_android_app_Application_ActivityLifecycleCallbacks.InstanceMethods.InvokeAbstractVoidMethod("onActivityResumed.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivitySaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_activity, nint native_outState)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				Bundle outState = Java.Lang.Object.GetObject<Bundle>(native_outState, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivitySaveInstanceState(activity, outState);
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

		public unsafe void OnActivitySaveInstanceState(Activity activity, Bundle outState)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(outState?.Handle ?? IntPtr.Zero);
				_members_android_app_Application_ActivityLifecycleCallbacks.InstanceMethods.InvokeAbstractVoidMethod("onActivitySaveInstanceState.(Landroid/app/Activity;Landroid/os/Bundle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
				GC.KeepAlive(outState);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityStarted_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityStarted(activity);
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

		public unsafe void OnActivityStarted(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members_android_app_Application_ActivityLifecycleCallbacks.InstanceMethods.InvokeAbstractVoidMethod("onActivityStarted.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnActivityStopped_Landroid_app_Activity_(nint jnienv, nint native__this, nint native_activity)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IActivityLifecycleCallbacks? activityLifecycleCallbacks = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Activity activity = Java.Lang.Object.GetObject<Activity>(native_activity, JniHandleOwnership.DoNotTransfer);
				activityLifecycleCallbacks.OnActivityStopped(activity);
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

		public unsafe void OnActivityStopped(Activity activity)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
				_members_android_app_Application_ActivityLifecycleCallbacks.InstanceMethods.InvokeAbstractVoidMethod("onActivityStopped.(Landroid/app/Activity;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(activity);
			}
		}

		int IJavaPeerable.get_JniIdentityHashCode()
		{
			return base.JniIdentityHashCode;
		}

		JniObjectReference IJavaPeerable.get_PeerReference()
		{
			return base.PeerReference;
		}

		void IJavaPeerable.UnregisterFromRuntime()
		{
			UnregisterFromRuntime();
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityCreated_Landroid_app_Activity_Landroid_os_Bundle__mm_wrapper(nint jnienv, nint native__this, nint native_activity, nint native_savedInstanceState)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityCreated_Landroid_app_Activity_Landroid_os_Bundle_(jnienv, native__this, native_activity, native_savedInstanceState);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityDestroyed_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityDestroyed_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityPaused_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityPaused_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityResumed_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityResumed_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivitySaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle__mm_wrapper(nint jnienv, nint native__this, nint native_activity, nint native_outState)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivitySaveInstanceState_Landroid_app_Activity_Landroid_os_Bundle_(jnienv, native__this, native_activity, native_outState);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityStarted_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityStarted_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}

		[UnmanagedCallersOnly]
		private static void n_OnActivityStopped_Landroid_app_Activity__mm_wrapper(nint jnienv, nint native__this, nint native_activity)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				n_OnActivityStopped_Landroid_app_Activity_(jnienv, native__this, native_activity);
			}
			catch (System.Exception e)
			{
				AndroidEnvironmentInternal.UnhandledException(e);
			}
		}
	}

	private static Context? _context;

	private static SyncContext? _sync;

	private static readonly JniPeerMembers _members;

	private static Delegate? cb_onCreate_OnCreate_V;

	private static Delegate? cb_onTrimMemory_OnTrimMemory_I_V;

	private static Delegate? cb_registerActivityLifecycleCallbacks_RegisterActivityLifecycleCallbacks_Landroid_app_Application_ActivityLifecycleCallbacks__V;

	public static Context Context
	{
		get
		{
			if (_context != null)
			{
				return _context;
			}
			nint num = JNIEnv.FindClass("net/dot/android/ApplicationRegistration");
			try
			{
				nint staticFieldID = JNIEnv.GetStaticFieldID(num, "Context", "Landroid/content/Context;");
				return _context = Java.Lang.Object.GetObject<Context>(JNIEnv.GetStaticObjectField(num, staticFieldID), JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteGlobalRef(num);
			}
		}
	}

	public static SynchronizationContext SynchronizationContext
	{
		get
		{
			if (_sync == null)
			{
				_sync = new SyncContext();
			}
			return _sync;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	[SupportedOSPlatform("android28.0")]
	public unsafe static string? ProcessName => JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getProcessName.()Ljava/lang/String;", null).Handle, JniHandleOwnership.TransferLocalRef);

	static Application()
	{
		_members = new XAPeerMembers("android/app/Application", typeof(Application));
	}

	protected Application(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCreate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Application>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnCreate();
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

	public unsafe virtual void OnCreate()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onCreate.()V", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnTrimMemory_I(nint jnienv, nint native__this, int native_level)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Application>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnTrimMemory((TrimMemory)native_level);
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

	public unsafe virtual void OnTrimMemory(TrimMemory level)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)level);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onTrimMemory.(I)V", this, ptr);
	}

	private static Delegate GetRegisterActivityLifecycleCallbacks_Landroid_app_Application_ActivityLifecycleCallbacks_Handler()
	{
		return new _JniMarshal_PPL_V(n_RegisterActivityLifecycleCallbacks_Landroid_app_Application_ActivityLifecycleCallbacks_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RegisterActivityLifecycleCallbacks_Landroid_app_Application_ActivityLifecycleCallbacks_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Application? application = Java.Lang.Object.GetObject<Application>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IActivityLifecycleCallbacks callback = Java.Lang.Object.GetObject<IActivityLifecycleCallbacks>(native__callback, JniHandleOwnership.DoNotTransfer);
			application.RegisterActivityLifecycleCallbacks(callback);
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

	public unsafe virtual void RegisterActivityLifecycleCallbacks(IActivityLifecycleCallbacks? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("registerActivityLifecycleCallbacks.(Landroid/app/Application$ActivityLifecycleCallbacks;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}

	[UnmanagedCallersOnly]
	private static void n_OnCreate_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnCreate(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_OnTrimMemory_I_mm_wrapper(nint jnienv, nint native__this, int native_level)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnTrimMemory_I(jnienv, native__this, native_level);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
