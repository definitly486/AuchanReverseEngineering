using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/ViewPropertyAnimatorListener", DoNotGenerateAcw = true)]
internal class IViewPropertyAnimatorListenerInvoker : Java.Lang.Object, IViewPropertyAnimatorListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_core_view_ViewPropertyAnimatorListener = new XAPeerMembers("androidx/core/view/ViewPropertyAnimatorListener", typeof(IViewPropertyAnimatorListenerInvoker));

	private static Delegate? cb_onAnimationCancel_OnAnimationCancel_Landroid_view_View__V;

	private static Delegate? cb_onAnimationEnd_OnAnimationEnd_Landroid_view_View__V;

	private static Delegate? cb_onAnimationStart_OnAnimationStart_Landroid_view_View__V;

	private static nint java_class_ref => _members_androidx_core_view_ViewPropertyAnimatorListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_core_view_ViewPropertyAnimatorListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_core_view_ViewPropertyAnimatorListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_core_view_ViewPropertyAnimatorListener.ManagedPeerType;

	public IViewPropertyAnimatorListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnAnimationCancel_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnAnimationCancel_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAnimationCancel_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewPropertyAnimatorListener? viewPropertyAnimatorListener = Java.Lang.Object.GetObject<IViewPropertyAnimatorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			viewPropertyAnimatorListener.OnAnimationCancel(view);
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

	public unsafe void OnAnimationCancel(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members_androidx_core_view_ViewPropertyAnimatorListener.InstanceMethods.InvokeAbstractVoidMethod("onAnimationCancel.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetOnAnimationEnd_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnAnimationEnd_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAnimationEnd_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewPropertyAnimatorListener? viewPropertyAnimatorListener = Java.Lang.Object.GetObject<IViewPropertyAnimatorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			viewPropertyAnimatorListener.OnAnimationEnd(view);
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

	public unsafe void OnAnimationEnd(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members_androidx_core_view_ViewPropertyAnimatorListener.InstanceMethods.InvokeAbstractVoidMethod("onAnimationEnd.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetOnAnimationStart_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnAnimationStart_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAnimationStart_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewPropertyAnimatorListener? viewPropertyAnimatorListener = Java.Lang.Object.GetObject<IViewPropertyAnimatorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			viewPropertyAnimatorListener.OnAnimationStart(view);
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

	public unsafe void OnAnimationStart(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members_androidx_core_view_ViewPropertyAnimatorListener.InstanceMethods.InvokeAbstractVoidMethod("onAnimationStart.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
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
