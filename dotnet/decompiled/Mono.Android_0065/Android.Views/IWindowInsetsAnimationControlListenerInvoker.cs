using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/WindowInsetsAnimationControlListener", DoNotGenerateAcw = true, ApiSince = 30)]
internal class IWindowInsetsAnimationControlListenerInvoker : Java.Lang.Object, IWindowInsetsAnimationControlListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_view_WindowInsetsAnimationControlListener = new XAPeerMembers("android/view/WindowInsetsAnimationControlListener", typeof(IWindowInsetsAnimationControlListenerInvoker));

	private static Delegate? cb_onCancelled_OnCancelled_Landroid_view_WindowInsetsAnimationController__V;

	private static Delegate? cb_onFinished_OnFinished_Landroid_view_WindowInsetsAnimationController__V;

	private static Delegate? cb_onReady_OnReady_Landroid_view_WindowInsetsAnimationController_I_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_view_WindowInsetsAnimationControlListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_view_WindowInsetsAnimationControlListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_view_WindowInsetsAnimationControlListener.ManagedPeerType;

	public IWindowInsetsAnimationControlListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetOnCancelled_Landroid_view_WindowInsetsAnimationController_Handler()
	{
		return new _JniMarshal_PPL_V(n_OnCancelled_Landroid_view_WindowInsetsAnimationController_);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCancelled_Landroid_view_WindowInsetsAnimationController_(nint jnienv, nint native__this, nint native_controller)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowInsetsAnimationControlListener? windowInsetsAnimationControlListener = Java.Lang.Object.GetObject<IWindowInsetsAnimationControlListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IWindowInsetsAnimationController controller = Java.Lang.Object.GetObject<IWindowInsetsAnimationController>(native_controller, JniHandleOwnership.DoNotTransfer);
			windowInsetsAnimationControlListener.OnCancelled(controller);
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

	[SupportedOSPlatform("android30.0")]
	public unsafe void OnCancelled(IWindowInsetsAnimationController? controller)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((controller == null) ? IntPtr.Zero : ((Java.Lang.Object)controller).Handle);
			_members_android_view_WindowInsetsAnimationControlListener.InstanceMethods.InvokeAbstractVoidMethod("onCancelled.(Landroid/view/WindowInsetsAnimationController;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(controller);
		}
	}

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetOnFinished_Landroid_view_WindowInsetsAnimationController_Handler()
	{
		return new _JniMarshal_PPL_V(n_OnFinished_Landroid_view_WindowInsetsAnimationController_);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnFinished_Landroid_view_WindowInsetsAnimationController_(nint jnienv, nint native__this, nint native_controller)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowInsetsAnimationControlListener? windowInsetsAnimationControlListener = Java.Lang.Object.GetObject<IWindowInsetsAnimationControlListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IWindowInsetsAnimationController controller = Java.Lang.Object.GetObject<IWindowInsetsAnimationController>(native_controller, JniHandleOwnership.DoNotTransfer);
			windowInsetsAnimationControlListener.OnFinished(controller);
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

	[SupportedOSPlatform("android30.0")]
	public unsafe void OnFinished(IWindowInsetsAnimationController controller)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((controller == null) ? IntPtr.Zero : ((Java.Lang.Object)controller).Handle);
			_members_android_view_WindowInsetsAnimationControlListener.InstanceMethods.InvokeAbstractVoidMethod("onFinished.(Landroid/view/WindowInsetsAnimationController;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(controller);
		}
	}

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetOnReady_Landroid_view_WindowInsetsAnimationController_IHandler()
	{
		return new _JniMarshal_PPLI_V(n_OnReady_Landroid_view_WindowInsetsAnimationController_I);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnReady_Landroid_view_WindowInsetsAnimationController_I(nint jnienv, nint native__this, nint native_controller, int types)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowInsetsAnimationControlListener? windowInsetsAnimationControlListener = Java.Lang.Object.GetObject<IWindowInsetsAnimationControlListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IWindowInsetsAnimationController controller = Java.Lang.Object.GetObject<IWindowInsetsAnimationController>(native_controller, JniHandleOwnership.DoNotTransfer);
			windowInsetsAnimationControlListener.OnReady(controller, types);
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

	[SupportedOSPlatform("android30.0")]
	public unsafe void OnReady(IWindowInsetsAnimationController controller, int types)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((controller == null) ? IntPtr.Zero : ((Java.Lang.Object)controller).Handle);
			ptr[1] = new JniArgumentValue(types);
			_members_android_view_WindowInsetsAnimationControlListener.InstanceMethods.InvokeAbstractVoidMethod("onReady.(Landroid/view/WindowInsetsAnimationController;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(controller);
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
