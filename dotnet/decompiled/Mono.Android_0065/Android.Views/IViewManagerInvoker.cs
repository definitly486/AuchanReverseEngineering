using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/ViewManager", DoNotGenerateAcw = true)]
internal class IViewManagerInvoker : Java.Lang.Object, IViewManager, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_view_ViewManager = new XAPeerMembers("android/view/ViewManager", typeof(IViewManagerInvoker));

	private static Delegate? cb_addView_AddView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams__V;

	private static Delegate? cb_removeView_RemoveView_Landroid_view_View__V;

	private static Delegate? cb_updateViewLayout_UpdateViewLayout_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_view_ViewManager;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_view_ViewManager.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_view_ViewManager.ManagedPeerType;

	public IViewManagerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetAddView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler()
	{
		return new _JniMarshal_PPLL_V(n_AddView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_(nint jnienv, nint native__this, nint native_view, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewManager? viewManager = Java.Lang.Object.GetObject<IViewManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			ViewGroup.LayoutParams layoutParams = Java.Lang.Object.GetObject<ViewGroup.LayoutParams>(native__params, JniHandleOwnership.DoNotTransfer);
			viewManager.AddView(view, layoutParams);
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

	public unsafe void AddView(View? view, ViewGroup.LayoutParams? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members_android_view_ViewManager.InstanceMethods.InvokeAbstractVoidMethod("addView.(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(@params);
		}
	}

	private static Delegate GetRemoveView_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_V(n_RemoveView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewManager? viewManager = Java.Lang.Object.GetObject<IViewManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			viewManager.RemoveView(view);
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

	public unsafe void RemoveView(View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members_android_view_ViewManager.InstanceMethods.InvokeAbstractVoidMethod("removeView.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetUpdateViewLayout_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler()
	{
		return new _JniMarshal_PPLL_V(n_UpdateViewLayout_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateViewLayout_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_(nint jnienv, nint native__this, nint native_view, nint native__params)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IViewManager? viewManager = Java.Lang.Object.GetObject<IViewManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			ViewGroup.LayoutParams layoutParams = Java.Lang.Object.GetObject<ViewGroup.LayoutParams>(native__params, JniHandleOwnership.DoNotTransfer);
			viewManager.UpdateViewLayout(view, layoutParams);
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

	public unsafe void UpdateViewLayout(View? view, ViewGroup.LayoutParams? @params)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(@params?.Handle ?? IntPtr.Zero);
			_members_android_view_ViewManager.InstanceMethods.InvokeAbstractVoidMethod("updateViewLayout.(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
			GC.KeepAlive(@params);
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
