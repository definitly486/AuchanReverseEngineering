using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Window;

[Register("android/window/OnBackInvokedDispatcher", DoNotGenerateAcw = true, ApiSince = 33)]
internal class IOnBackInvokedDispatcherInvoker : Java.Lang.Object, IOnBackInvokedDispatcher, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_window_OnBackInvokedDispatcher = new XAPeerMembers("android/window/OnBackInvokedDispatcher", typeof(IOnBackInvokedDispatcherInvoker));

	private static Delegate? cb_registerOnBackInvokedCallback_RegisterOnBackInvokedCallback_ILandroid_window_OnBackInvokedCallback__V;

	private static Delegate? cb_unregisterOnBackInvokedCallback_UnregisterOnBackInvokedCallback_Landroid_window_OnBackInvokedCallback__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_window_OnBackInvokedDispatcher;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_window_OnBackInvokedDispatcher.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_window_OnBackInvokedDispatcher.ManagedPeerType;

	public IOnBackInvokedDispatcherInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android33.0")]
	private static Delegate GetRegisterOnBackInvokedCallback_ILandroid_window_OnBackInvokedCallback_Handler()
	{
		return new _JniMarshal_PPIL_V(n_RegisterOnBackInvokedCallback_ILandroid_window_OnBackInvokedCallback_);
	}

	[SupportedOSPlatform("android33.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RegisterOnBackInvokedCallback_ILandroid_window_OnBackInvokedCallback_(nint jnienv, nint native__this, int priority, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IOnBackInvokedDispatcher? onBackInvokedDispatcher = Java.Lang.Object.GetObject<IOnBackInvokedDispatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnBackInvokedCallback callback = Java.Lang.Object.GetObject<IOnBackInvokedCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			onBackInvokedDispatcher.RegisterOnBackInvokedCallback(priority, callback);
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

	[SupportedOSPlatform("android33.0")]
	public unsafe void RegisterOnBackInvokedCallback([IntDef(Type = "Android.Window.IOnBackInvokedDispatcher", Fields = new string[] { "PriorityDefault", "PriorityOverlay", "PrioritySystemNavigationObserver" })] int priority, IOnBackInvokedCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(priority);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			_members_android_window_OnBackInvokedDispatcher.InstanceMethods.InvokeAbstractVoidMethod("registerOnBackInvokedCallback.(ILandroid/window/OnBackInvokedCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	[SupportedOSPlatform("android33.0")]
	private static Delegate GetUnregisterOnBackInvokedCallback_Landroid_window_OnBackInvokedCallback_Handler()
	{
		return new _JniMarshal_PPL_V(n_UnregisterOnBackInvokedCallback_Landroid_window_OnBackInvokedCallback_);
	}

	[SupportedOSPlatform("android33.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UnregisterOnBackInvokedCallback_Landroid_window_OnBackInvokedCallback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IOnBackInvokedDispatcher? onBackInvokedDispatcher = Java.Lang.Object.GetObject<IOnBackInvokedDispatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnBackInvokedCallback callback = Java.Lang.Object.GetObject<IOnBackInvokedCallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			onBackInvokedDispatcher.UnregisterOnBackInvokedCallback(callback);
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

	[SupportedOSPlatform("android33.0")]
	public unsafe void UnregisterOnBackInvokedCallback(IOnBackInvokedCallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			_members_android_window_OnBackInvokedDispatcher.InstanceMethods.InvokeAbstractVoidMethod("unregisterOnBackInvokedCallback.(Landroid/window/OnBackInvokedCallback;)V", this, ptr);
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
}
