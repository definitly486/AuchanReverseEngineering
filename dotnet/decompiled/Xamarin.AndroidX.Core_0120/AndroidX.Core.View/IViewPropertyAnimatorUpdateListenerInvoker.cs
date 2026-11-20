using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/ViewPropertyAnimatorUpdateListener", DoNotGenerateAcw = true)]
internal class IViewPropertyAnimatorUpdateListenerInvoker : Java.Lang.Object, IViewPropertyAnimatorUpdateListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_core_view_ViewPropertyAnimatorUpdateListener = new XAPeerMembers("androidx/core/view/ViewPropertyAnimatorUpdateListener", typeof(IViewPropertyAnimatorUpdateListenerInvoker));

	private static Delegate? cb_onAnimationUpdate_OnAnimationUpdate_Landroid_view_View__V;

	private static nint java_class_ref => _members_androidx_core_view_ViewPropertyAnimatorUpdateListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_core_view_ViewPropertyAnimatorUpdateListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_core_view_ViewPropertyAnimatorUpdateListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_core_view_ViewPropertyAnimatorUpdateListener.ManagedPeerType;

	public IViewPropertyAnimatorUpdateListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnAnimationUpdate_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnAnimationUpdate_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnAnimationUpdate_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewPropertyAnimatorUpdateListener? viewPropertyAnimatorUpdateListener = Java.Lang.Object.GetObject<IViewPropertyAnimatorUpdateListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View view = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			viewPropertyAnimatorUpdateListener.OnAnimationUpdate(view);
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

	public unsafe void OnAnimationUpdate(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members_androidx_core_view_ViewPropertyAnimatorUpdateListener.InstanceMethods.InvokeAbstractVoidMethod("onAnimationUpdate.(Landroid/view/View;)V", this, ptr);
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
