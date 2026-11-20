using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/WindowInsetsAnimationControlListenerCompat", DoNotGenerateAcw = true)]
internal class IWindowInsetsAnimationControlListenerCompatInvoker : Java.Lang.Object, IWindowInsetsAnimationControlListenerCompat, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_core_view_WindowInsetsAnimationControlListenerCompat = new XAPeerMembers("androidx/core/view/WindowInsetsAnimationControlListenerCompat", typeof(IWindowInsetsAnimationControlListenerCompatInvoker));

	private static Delegate? cb_onCancelled_OnCancelled_Landroidx_core_view_WindowInsetsAnimationControllerCompat__V;

	private static Delegate? cb_onFinished_OnFinished_Landroidx_core_view_WindowInsetsAnimationControllerCompat__V;

	private static Delegate? cb_onReady_OnReady_Landroidx_core_view_WindowInsetsAnimationControllerCompat_I_V;

	private static nint java_class_ref => _members_androidx_core_view_WindowInsetsAnimationControlListenerCompat.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_core_view_WindowInsetsAnimationControlListenerCompat;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_core_view_WindowInsetsAnimationControlListenerCompat.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_core_view_WindowInsetsAnimationControlListenerCompat.ManagedPeerType;

	public IWindowInsetsAnimationControlListenerCompatInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnCancelled_Landroidx_core_view_WindowInsetsAnimationControllerCompat_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnCancelled_Landroidx_core_view_WindowInsetsAnimationControllerCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCancelled_Landroidx_core_view_WindowInsetsAnimationControllerCompat_(nint jnienv, nint native__this, nint native_controller)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowInsetsAnimationControlListenerCompat? windowInsetsAnimationControlListenerCompat = Java.Lang.Object.GetObject<IWindowInsetsAnimationControlListenerCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WindowInsetsAnimationControllerCompat controller = Java.Lang.Object.GetObject<WindowInsetsAnimationControllerCompat>(native_controller, JniHandleOwnership.DoNotTransfer);
			windowInsetsAnimationControlListenerCompat.OnCancelled(controller);
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

	public unsafe void OnCancelled(WindowInsetsAnimationControllerCompat? controller)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(controller?.Handle ?? IntPtr.Zero);
			_members_androidx_core_view_WindowInsetsAnimationControlListenerCompat.InstanceMethods.InvokeAbstractVoidMethod("onCancelled.(Landroidx/core/view/WindowInsetsAnimationControllerCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(controller);
		}
	}

	private static Delegate GetOnFinished_Landroidx_core_view_WindowInsetsAnimationControllerCompat_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnFinished_Landroidx_core_view_WindowInsetsAnimationControllerCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnFinished_Landroidx_core_view_WindowInsetsAnimationControllerCompat_(nint jnienv, nint native__this, nint native_controller)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowInsetsAnimationControlListenerCompat? windowInsetsAnimationControlListenerCompat = Java.Lang.Object.GetObject<IWindowInsetsAnimationControlListenerCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WindowInsetsAnimationControllerCompat controller = Java.Lang.Object.GetObject<WindowInsetsAnimationControllerCompat>(native_controller, JniHandleOwnership.DoNotTransfer);
			windowInsetsAnimationControlListenerCompat.OnFinished(controller);
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

	public unsafe void OnFinished(WindowInsetsAnimationControllerCompat? controller)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(controller?.Handle ?? IntPtr.Zero);
			_members_androidx_core_view_WindowInsetsAnimationControlListenerCompat.InstanceMethods.InvokeAbstractVoidMethod("onFinished.(Landroidx/core/view/WindowInsetsAnimationControllerCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(controller);
		}
	}

	private static Delegate GetOnReady_Landroidx_core_view_WindowInsetsAnimationControllerCompat_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_OnReady_Landroidx_core_view_WindowInsetsAnimationControllerCompat_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnReady_Landroidx_core_view_WindowInsetsAnimationControllerCompat_I(nint jnienv, nint native__this, nint native_controller, int types)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowInsetsAnimationControlListenerCompat? windowInsetsAnimationControlListenerCompat = Java.Lang.Object.GetObject<IWindowInsetsAnimationControlListenerCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WindowInsetsAnimationControllerCompat controller = Java.Lang.Object.GetObject<WindowInsetsAnimationControllerCompat>(native_controller, JniHandleOwnership.DoNotTransfer);
			windowInsetsAnimationControlListenerCompat.OnReady(controller, types);
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

	public unsafe void OnReady(WindowInsetsAnimationControllerCompat? controller, int types)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(controller?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(types);
			_members_androidx_core_view_WindowInsetsAnimationControlListenerCompat.InstanceMethods.InvokeAbstractVoidMethod("onReady.(Landroidx/core/view/WindowInsetsAnimationControllerCompat;I)V", this, ptr);
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
