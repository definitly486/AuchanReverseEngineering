using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.OS;
using Android.Runtime;
using Android.Window;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;
using Java.Util.Functions;

namespace Android.Views;

[Register("android/view/WindowManager", "", "Android.Views.IWindowManagerInvoker")]
public interface IWindowManager : IViewManager, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/WindowManager", typeof(IWindowManager), isInterface: true);

	private static Delegate? cb_getCurrentWindowMetrics_GetCurrentWindowMetrics_Landroid_view_WindowMetrics_;

	private static Delegate? cb_isCrossWindowBlurEnabled_IsCrossWindowBlurEnabled_Z;

	private static Delegate? cb_getMaximumWindowMetrics_GetMaximumWindowMetrics_Landroid_view_WindowMetrics_;

	private static Delegate? cb_addCrossWindowBlurEnabledListener_AddCrossWindowBlurEnabledListener_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer__V;

	private static Delegate? cb_addCrossWindowBlurEnabledListener_AddCrossWindowBlurEnabledListener_Ljava_util_function_Consumer__V;

	private static Delegate? cb_addProposedRotationListener_AddProposedRotationListener_Ljava_util_concurrent_Executor_Ljava_util_function_IntConsumer__V;

	private static Delegate? cb_addScreenRecordingCallback_AddScreenRecordingCallback_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer__I;

	private static Delegate? cb_registerBatchedSurfaceControlInputReceiver_RegisterBatchedSurfaceControlInputReceiver_Landroid_window_InputTransferToken_Landroid_view_SurfaceControl_Landroid_view_Choreographer_Landroid_view_SurfaceControlInputReceiver__Landroid_window_InputTransferToken_;

	private static Delegate? cb_registerTrustedPresentationListener_RegisterTrustedPresentationListener_Landroid_os_IBinder_Landroid_window_TrustedPresentationThresholds_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer__V;

	private static Delegate? cb_registerUnbatchedSurfaceControlInputReceiver_RegisterUnbatchedSurfaceControlInputReceiver_Landroid_window_InputTransferToken_Landroid_view_SurfaceControl_Landroid_os_Looper_Landroid_view_SurfaceControlInputReceiver__Landroid_window_InputTransferToken_;

	private static Delegate? cb_removeCrossWindowBlurEnabledListener_RemoveCrossWindowBlurEnabledListener_Ljava_util_function_Consumer__V;

	private static Delegate? cb_removeProposedRotationListener_RemoveProposedRotationListener_Ljava_util_function_IntConsumer__V;

	private static Delegate? cb_removeScreenRecordingCallback_RemoveScreenRecordingCallback_Ljava_util_function_Consumer__V;

	private static Delegate? cb_transferTouchGesture_TransferTouchGesture_Landroid_window_InputTransferToken_Landroid_window_InputTransferToken__Z;

	private static Delegate? cb_unregisterSurfaceControlInputReceiver_UnregisterSurfaceControlInputReceiver_Landroid_view_SurfaceControl__V;

	private static Delegate? cb_unregisterTrustedPresentationListener_UnregisterTrustedPresentationListener_Ljava_util_function_Consumer__V;

	Display? DefaultDisplay
	{
		[Register("getDefaultDisplay", "()Landroid/view/Display;", "GetGetDefaultDisplayHandler:Android.Views.IWindowManagerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[SupportedOSPlatform("android30.0")]
	unsafe WindowMetrics CurrentWindowMetrics
	{
		[Register("getCurrentWindowMetrics", "()Landroid/view/WindowMetrics;", "GetGetCurrentWindowMetricsHandler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 30)]
		get
		{
			return Java.Lang.Object.GetObject<WindowMetrics>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCurrentWindowMetrics.()Landroid/view/WindowMetrics;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[SupportedOSPlatform("android31.0")]
	unsafe bool IsCrossWindowBlurEnabled
	{
		[Register("isCrossWindowBlurEnabled", "()Z", "GetIsCrossWindowBlurEnabledHandler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 31)]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCrossWindowBlurEnabled.()Z", this, null);
		}
	}

	[SupportedOSPlatform("android30.0")]
	unsafe WindowMetrics MaximumWindowMetrics
	{
		[Register("getMaximumWindowMetrics", "()Landroid/view/WindowMetrics;", "GetGetMaximumWindowMetricsHandler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 30)]
		get
		{
			return Java.Lang.Object.GetObject<WindowMetrics>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMaximumWindowMetrics.()Landroid/view/WindowMetrics;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetGetCurrentWindowMetricsHandler()
	{
		return new _JniMarshal_PP_L(n_GetCurrentWindowMetrics);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCurrentWindowMetrics(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentWindowMetrics);
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

	[SupportedOSPlatform("android31.0")]
	private static Delegate GetIsCrossWindowBlurEnabledHandler()
	{
		return new _JniMarshal_PP_B(n_IsCrossWindowBlurEnabled);
	}

	[SupportedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCrossWindowBlurEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCrossWindowBlurEnabled ? ((sbyte)1) : ((sbyte)0);
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

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetGetMaximumWindowMetricsHandler()
	{
		return new _JniMarshal_PP_L(n_GetMaximumWindowMetrics);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMaximumWindowMetrics(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaximumWindowMetrics);
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

	[Register("removeViewImmediate", "(Landroid/view/View;)V", "GetRemoveViewImmediate_Landroid_view_View_Handler:Android.Views.IWindowManagerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RemoveViewImmediate(View? view);

	[SupportedOSPlatform("android31.0")]
	private static Delegate GetAddCrossWindowBlurEnabledListener_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer_Handler()
	{
		return new _JniMarshal_PPLL_V(n_AddCrossWindowBlurEnabledListener_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer_);
	}

	[SupportedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddCrossWindowBlurEnabledListener_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer_(nint jnienv, nint native__this, nint native_executor, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowManager? windowManager = Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor executor = Java.Lang.Object.GetObject<IExecutor>(native_executor, JniHandleOwnership.DoNotTransfer);
			IConsumer listener = Java.Lang.Object.GetObject<IConsumer>(native_listener, JniHandleOwnership.DoNotTransfer);
			windowManager.AddCrossWindowBlurEnabledListener(executor, listener);
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

	[SupportedOSPlatform("android31.0")]
	[Register("addCrossWindowBlurEnabledListener", "(Ljava/util/concurrent/Executor;Ljava/util/function/Consumer;)V", "GetAddCrossWindowBlurEnabledListener_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer_Handler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 31)]
	unsafe void AddCrossWindowBlurEnabledListener(IExecutor executor, IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addCrossWindowBlurEnabledListener.(Ljava/util/concurrent/Executor;Ljava/util/function/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(listener);
		}
	}

	[SupportedOSPlatform("android31.0")]
	private static Delegate GetAddCrossWindowBlurEnabledListener_Ljava_util_function_Consumer_Handler()
	{
		return new _JniMarshal_PPL_V(n_AddCrossWindowBlurEnabledListener_Ljava_util_function_Consumer_);
	}

	[SupportedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddCrossWindowBlurEnabledListener_Ljava_util_function_Consumer_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowManager? windowManager = Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConsumer listener = Java.Lang.Object.GetObject<IConsumer>(native_listener, JniHandleOwnership.DoNotTransfer);
			windowManager.AddCrossWindowBlurEnabledListener(listener);
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

	[SupportedOSPlatform("android31.0")]
	[Register("addCrossWindowBlurEnabledListener", "(Ljava/util/function/Consumer;)V", "GetAddCrossWindowBlurEnabledListener_Ljava_util_function_Consumer_Handler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 31)]
	unsafe void AddCrossWindowBlurEnabledListener(IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addCrossWindowBlurEnabledListener.(Ljava/util/function/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[SupportedOSPlatform("android34.0")]
	private static Delegate GetAddProposedRotationListener_Ljava_util_concurrent_Executor_Ljava_util_function_IntConsumer_Handler()
	{
		return new _JniMarshal_PPLL_V(n_AddProposedRotationListener_Ljava_util_concurrent_Executor_Ljava_util_function_IntConsumer_);
	}

	[SupportedOSPlatform("android34.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddProposedRotationListener_Ljava_util_concurrent_Executor_Ljava_util_function_IntConsumer_(nint jnienv, nint native__this, nint native_executor, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowManager? windowManager = Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor executor = Java.Lang.Object.GetObject<IExecutor>(native_executor, JniHandleOwnership.DoNotTransfer);
			IIntConsumer listener = Java.Lang.Object.GetObject<IIntConsumer>(native_listener, JniHandleOwnership.DoNotTransfer);
			windowManager.AddProposedRotationListener(executor, listener);
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

	[SupportedOSPlatform("android34.0")]
	[Register("addProposedRotationListener", "(Ljava/util/concurrent/Executor;Ljava/util/function/IntConsumer;)V", "GetAddProposedRotationListener_Ljava_util_concurrent_Executor_Ljava_util_function_IntConsumer_Handler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 34)]
	unsafe void AddProposedRotationListener(IExecutor executor, IIntConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[1] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addProposedRotationListener.(Ljava/util/concurrent/Executor;Ljava/util/function/IntConsumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(listener);
		}
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetAddScreenRecordingCallback_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer_Handler()
	{
		return new _JniMarshal_PPLL_I(n_AddScreenRecordingCallback_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer_);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_AddScreenRecordingCallback_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer_(nint jnienv, nint native__this, nint native_executor, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IWindowManager? windowManager = Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IExecutor executor = Java.Lang.Object.GetObject<IExecutor>(native_executor, JniHandleOwnership.DoNotTransfer);
			IConsumer callback = Java.Lang.Object.GetObject<IConsumer>(native__callback, JniHandleOwnership.DoNotTransfer);
			return windowManager.AddScreenRecordingCallback(executor, callback);
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

	[SupportedOSPlatform("android35.0")]
	[Register("addScreenRecordingCallback", "(Ljava/util/concurrent/Executor;Ljava/util/function/Consumer;)I", "GetAddScreenRecordingCallback_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer_Handler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	[RequiresPermission("android.permission.DETECT_SCREEN_RECORDING")]
	unsafe int AddScreenRecordingCallback(IExecutor executor, IConsumer callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return _members.InstanceMethods.InvokeVirtualInt32Method("addScreenRecordingCallback.(Ljava/util/concurrent/Executor;Ljava/util/function/Consumer;)I", this, ptr);
		}
		finally
		{
			GC.KeepAlive(executor);
			GC.KeepAlive(callback);
		}
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetRegisterBatchedSurfaceControlInputReceiver_Landroid_window_InputTransferToken_Landroid_view_SurfaceControl_Landroid_view_Choreographer_Landroid_view_SurfaceControlInputReceiver_Handler()
	{
		return new _JniMarshal_PPLLLL_L(n_RegisterBatchedSurfaceControlInputReceiver_Landroid_window_InputTransferToken_Landroid_view_SurfaceControl_Landroid_view_Choreographer_Landroid_view_SurfaceControlInputReceiver_);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_RegisterBatchedSurfaceControlInputReceiver_Landroid_window_InputTransferToken_Landroid_view_SurfaceControl_Landroid_view_Choreographer_Landroid_view_SurfaceControlInputReceiver_(nint jnienv, nint native__this, nint native_hostInputTransferToken, nint native_surfaceControl, nint native_choreographer, nint native_receiver)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IWindowManager? windowManager = Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			InputTransferToken hostInputTransferToken = Java.Lang.Object.GetObject<InputTransferToken>(native_hostInputTransferToken, JniHandleOwnership.DoNotTransfer);
			SurfaceControl surfaceControl = Java.Lang.Object.GetObject<SurfaceControl>(native_surfaceControl, JniHandleOwnership.DoNotTransfer);
			Choreographer choreographer = Java.Lang.Object.GetObject<Choreographer>(native_choreographer, JniHandleOwnership.DoNotTransfer);
			ISurfaceControlInputReceiver receiver = Java.Lang.Object.GetObject<ISurfaceControlInputReceiver>(native_receiver, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(windowManager.RegisterBatchedSurfaceControlInputReceiver(hostInputTransferToken, surfaceControl, choreographer, receiver));
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

	[SupportedOSPlatform("android35.0")]
	[Register("registerBatchedSurfaceControlInputReceiver", "(Landroid/window/InputTransferToken;Landroid/view/SurfaceControl;Landroid/view/Choreographer;Landroid/view/SurfaceControlInputReceiver;)Landroid/window/InputTransferToken;", "GetRegisterBatchedSurfaceControlInputReceiver_Landroid_window_InputTransferToken_Landroid_view_SurfaceControl_Landroid_view_Choreographer_Landroid_view_SurfaceControlInputReceiver_Handler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	unsafe InputTransferToken RegisterBatchedSurfaceControlInputReceiver(InputTransferToken hostInputTransferToken, SurfaceControl surfaceControl, Choreographer choreographer, ISurfaceControlInputReceiver receiver)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(hostInputTransferToken?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(surfaceControl?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(choreographer?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((receiver == null) ? IntPtr.Zero : ((Java.Lang.Object)receiver).Handle);
			return Java.Lang.Object.GetObject<InputTransferToken>(_members.InstanceMethods.InvokeVirtualObjectMethod("registerBatchedSurfaceControlInputReceiver.(Landroid/window/InputTransferToken;Landroid/view/SurfaceControl;Landroid/view/Choreographer;Landroid/view/SurfaceControlInputReceiver;)Landroid/window/InputTransferToken;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(hostInputTransferToken);
			GC.KeepAlive(surfaceControl);
			GC.KeepAlive(choreographer);
			GC.KeepAlive(receiver);
		}
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetRegisterTrustedPresentationListener_Landroid_os_IBinder_Landroid_window_TrustedPresentationThresholds_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer_Handler()
	{
		return new _JniMarshal_PPLLLL_V(n_RegisterTrustedPresentationListener_Landroid_os_IBinder_Landroid_window_TrustedPresentationThresholds_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer_);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RegisterTrustedPresentationListener_Landroid_os_IBinder_Landroid_window_TrustedPresentationThresholds_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer_(nint jnienv, nint native__this, nint native_window, nint native_thresholds, nint native_executor, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowManager? windowManager = Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IBinder window = Java.Lang.Object.GetObject<IBinder>(native_window, JniHandleOwnership.DoNotTransfer);
			TrustedPresentationThresholds thresholds = Java.Lang.Object.GetObject<TrustedPresentationThresholds>(native_thresholds, JniHandleOwnership.DoNotTransfer);
			IExecutor executor = Java.Lang.Object.GetObject<IExecutor>(native_executor, JniHandleOwnership.DoNotTransfer);
			IConsumer listener = Java.Lang.Object.GetObject<IConsumer>(native_listener, JniHandleOwnership.DoNotTransfer);
			windowManager.RegisterTrustedPresentationListener(window, thresholds, executor, listener);
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

	[SupportedOSPlatform("android35.0")]
	[Register("registerTrustedPresentationListener", "(Landroid/os/IBinder;Landroid/window/TrustedPresentationThresholds;Ljava/util/concurrent/Executor;Ljava/util/function/Consumer;)V", "GetRegisterTrustedPresentationListener_Landroid_os_IBinder_Landroid_window_TrustedPresentationThresholds_Ljava_util_concurrent_Executor_Ljava_util_function_Consumer_Handler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	unsafe void RegisterTrustedPresentationListener(IBinder window, TrustedPresentationThresholds thresholds, IExecutor executor, IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue((window == null) ? IntPtr.Zero : ((Java.Lang.Object)window).Handle);
			ptr[1] = new JniArgumentValue(thresholds?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
			ptr[3] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("registerTrustedPresentationListener.(Landroid/os/IBinder;Landroid/window/TrustedPresentationThresholds;Ljava/util/concurrent/Executor;Ljava/util/function/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(window);
			GC.KeepAlive(thresholds);
			GC.KeepAlive(executor);
			GC.KeepAlive(listener);
		}
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetRegisterUnbatchedSurfaceControlInputReceiver_Landroid_window_InputTransferToken_Landroid_view_SurfaceControl_Landroid_os_Looper_Landroid_view_SurfaceControlInputReceiver_Handler()
	{
		return new _JniMarshal_PPLLLL_L(n_RegisterUnbatchedSurfaceControlInputReceiver_Landroid_window_InputTransferToken_Landroid_view_SurfaceControl_Landroid_os_Looper_Landroid_view_SurfaceControlInputReceiver_);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_RegisterUnbatchedSurfaceControlInputReceiver_Landroid_window_InputTransferToken_Landroid_view_SurfaceControl_Landroid_os_Looper_Landroid_view_SurfaceControlInputReceiver_(nint jnienv, nint native__this, nint native_hostInputTransferToken, nint native_surfaceControl, nint native_looper, nint native_receiver)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IWindowManager? windowManager = Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			InputTransferToken hostInputTransferToken = Java.Lang.Object.GetObject<InputTransferToken>(native_hostInputTransferToken, JniHandleOwnership.DoNotTransfer);
			SurfaceControl surfaceControl = Java.Lang.Object.GetObject<SurfaceControl>(native_surfaceControl, JniHandleOwnership.DoNotTransfer);
			Looper looper = Java.Lang.Object.GetObject<Looper>(native_looper, JniHandleOwnership.DoNotTransfer);
			ISurfaceControlInputReceiver receiver = Java.Lang.Object.GetObject<ISurfaceControlInputReceiver>(native_receiver, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(windowManager.RegisterUnbatchedSurfaceControlInputReceiver(hostInputTransferToken, surfaceControl, looper, receiver));
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

	[SupportedOSPlatform("android35.0")]
	[Register("registerUnbatchedSurfaceControlInputReceiver", "(Landroid/window/InputTransferToken;Landroid/view/SurfaceControl;Landroid/os/Looper;Landroid/view/SurfaceControlInputReceiver;)Landroid/window/InputTransferToken;", "GetRegisterUnbatchedSurfaceControlInputReceiver_Landroid_window_InputTransferToken_Landroid_view_SurfaceControl_Landroid_os_Looper_Landroid_view_SurfaceControlInputReceiver_Handler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	unsafe InputTransferToken RegisterUnbatchedSurfaceControlInputReceiver(InputTransferToken hostInputTransferToken, SurfaceControl surfaceControl, Looper looper, ISurfaceControlInputReceiver receiver)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(hostInputTransferToken?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(surfaceControl?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(looper?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((receiver == null) ? IntPtr.Zero : ((Java.Lang.Object)receiver).Handle);
			return Java.Lang.Object.GetObject<InputTransferToken>(_members.InstanceMethods.InvokeVirtualObjectMethod("registerUnbatchedSurfaceControlInputReceiver.(Landroid/window/InputTransferToken;Landroid/view/SurfaceControl;Landroid/os/Looper;Landroid/view/SurfaceControlInputReceiver;)Landroid/window/InputTransferToken;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(hostInputTransferToken);
			GC.KeepAlive(surfaceControl);
			GC.KeepAlive(looper);
			GC.KeepAlive(receiver);
		}
	}

	[SupportedOSPlatform("android31.0")]
	private static Delegate GetRemoveCrossWindowBlurEnabledListener_Ljava_util_function_Consumer_Handler()
	{
		return new _JniMarshal_PPL_V(n_RemoveCrossWindowBlurEnabledListener_Ljava_util_function_Consumer_);
	}

	[SupportedOSPlatform("android31.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveCrossWindowBlurEnabledListener_Ljava_util_function_Consumer_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowManager? windowManager = Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConsumer listener = Java.Lang.Object.GetObject<IConsumer>(native_listener, JniHandleOwnership.DoNotTransfer);
			windowManager.RemoveCrossWindowBlurEnabledListener(listener);
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

	[SupportedOSPlatform("android31.0")]
	[Register("removeCrossWindowBlurEnabledListener", "(Ljava/util/function/Consumer;)V", "GetRemoveCrossWindowBlurEnabledListener_Ljava_util_function_Consumer_Handler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 31)]
	unsafe void RemoveCrossWindowBlurEnabledListener(IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeCrossWindowBlurEnabledListener.(Ljava/util/function/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[SupportedOSPlatform("android34.0")]
	private static Delegate GetRemoveProposedRotationListener_Ljava_util_function_IntConsumer_Handler()
	{
		return new _JniMarshal_PPL_V(n_RemoveProposedRotationListener_Ljava_util_function_IntConsumer_);
	}

	[SupportedOSPlatform("android34.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveProposedRotationListener_Ljava_util_function_IntConsumer_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowManager? windowManager = Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IIntConsumer listener = Java.Lang.Object.GetObject<IIntConsumer>(native_listener, JniHandleOwnership.DoNotTransfer);
			windowManager.RemoveProposedRotationListener(listener);
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

	[SupportedOSPlatform("android34.0")]
	[Register("removeProposedRotationListener", "(Ljava/util/function/IntConsumer;)V", "GetRemoveProposedRotationListener_Ljava_util_function_IntConsumer_Handler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 34)]
	unsafe void RemoveProposedRotationListener(IIntConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeProposedRotationListener.(Ljava/util/function/IntConsumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetRemoveScreenRecordingCallback_Ljava_util_function_Consumer_Handler()
	{
		return new _JniMarshal_PPL_V(n_RemoveScreenRecordingCallback_Ljava_util_function_Consumer_);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveScreenRecordingCallback_Ljava_util_function_Consumer_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowManager? windowManager = Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConsumer callback = Java.Lang.Object.GetObject<IConsumer>(native__callback, JniHandleOwnership.DoNotTransfer);
			windowManager.RemoveScreenRecordingCallback(callback);
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

	[SupportedOSPlatform("android35.0")]
	[Register("removeScreenRecordingCallback", "(Ljava/util/function/Consumer;)V", "GetRemoveScreenRecordingCallback_Ljava_util_function_Consumer_Handler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	[RequiresPermission("android.permission.DETECT_SCREEN_RECORDING")]
	unsafe void RemoveScreenRecordingCallback(IConsumer callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeScreenRecordingCallback.(Ljava/util/function/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetTransferTouchGesture_Landroid_window_InputTransferToken_Landroid_window_InputTransferToken_Handler()
	{
		return new _JniMarshal_PPLL_B(n_TransferTouchGesture_Landroid_window_InputTransferToken_Landroid_window_InputTransferToken_);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_TransferTouchGesture_Landroid_window_InputTransferToken_Landroid_window_InputTransferToken_(nint jnienv, nint native__this, nint native_transferFromToken, nint native_transferToToken)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IWindowManager? windowManager = Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			InputTransferToken transferFromToken = Java.Lang.Object.GetObject<InputTransferToken>(native_transferFromToken, JniHandleOwnership.DoNotTransfer);
			InputTransferToken transferToToken = Java.Lang.Object.GetObject<InputTransferToken>(native_transferToToken, JniHandleOwnership.DoNotTransfer);
			return windowManager.TransferTouchGesture(transferFromToken, transferToToken) ? ((sbyte)1) : ((sbyte)0);
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

	[SupportedOSPlatform("android35.0")]
	[Register("transferTouchGesture", "(Landroid/window/InputTransferToken;Landroid/window/InputTransferToken;)Z", "GetTransferTouchGesture_Landroid_window_InputTransferToken_Landroid_window_InputTransferToken_Handler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	unsafe bool TransferTouchGesture(InputTransferToken transferFromToken, InputTransferToken transferToToken)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(transferFromToken?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(transferToToken?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("transferTouchGesture.(Landroid/window/InputTransferToken;Landroid/window/InputTransferToken;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(transferFromToken);
			GC.KeepAlive(transferToToken);
		}
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetUnregisterSurfaceControlInputReceiver_Landroid_view_SurfaceControl_Handler()
	{
		return new _JniMarshal_PPL_V(n_UnregisterSurfaceControlInputReceiver_Landroid_view_SurfaceControl_);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UnregisterSurfaceControlInputReceiver_Landroid_view_SurfaceControl_(nint jnienv, nint native__this, nint native_surfaceControl)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowManager? windowManager = Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SurfaceControl surfaceControl = Java.Lang.Object.GetObject<SurfaceControl>(native_surfaceControl, JniHandleOwnership.DoNotTransfer);
			windowManager.UnregisterSurfaceControlInputReceiver(surfaceControl);
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

	[SupportedOSPlatform("android35.0")]
	[Register("unregisterSurfaceControlInputReceiver", "(Landroid/view/SurfaceControl;)V", "GetUnregisterSurfaceControlInputReceiver_Landroid_view_SurfaceControl_Handler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	unsafe void UnregisterSurfaceControlInputReceiver(SurfaceControl surfaceControl)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(surfaceControl?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterSurfaceControlInputReceiver.(Landroid/view/SurfaceControl;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(surfaceControl);
		}
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetUnregisterTrustedPresentationListener_Ljava_util_function_Consumer_Handler()
	{
		return new _JniMarshal_PPL_V(n_UnregisterTrustedPresentationListener_Ljava_util_function_Consumer_);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UnregisterTrustedPresentationListener_Ljava_util_function_Consumer_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowManager? windowManager = Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IConsumer listener = Java.Lang.Object.GetObject<IConsumer>(native_listener, JniHandleOwnership.DoNotTransfer);
			windowManager.UnregisterTrustedPresentationListener(listener);
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

	[SupportedOSPlatform("android35.0")]
	[Register("unregisterTrustedPresentationListener", "(Ljava/util/function/Consumer;)V", "GetUnregisterTrustedPresentationListener_Ljava_util_function_Consumer_Handler:Android.Views.IWindowManager, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 35)]
	unsafe void UnregisterTrustedPresentationListener(IConsumer listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("unregisterTrustedPresentationListener.(Ljava/util/function/Consumer;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}
}
