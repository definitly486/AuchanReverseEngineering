using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/WindowManager", DoNotGenerateAcw = true)]
internal class IWindowManagerInvoker : Java.Lang.Object, IWindowManager, IViewManager, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_view_ViewManager = new XAPeerMembers("android/view/ViewManager", typeof(IWindowManagerInvoker));

	private static readonly JniPeerMembers _members_android_view_WindowManager = new XAPeerMembers("android/view/WindowManager", typeof(IWindowManagerInvoker));

	private static Delegate? cb_getDefaultDisplay_GetDefaultDisplay_Landroid_view_Display_;

	private static Delegate? cb_removeViewImmediate_RemoveViewImmediate_Landroid_view_View__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_view_WindowManager;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_view_WindowManager.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_view_WindowManager.ManagedPeerType;

	public unsafe Display? DefaultDisplay => Java.Lang.Object.GetObject<Display>(_members_android_view_WindowManager.InstanceMethods.InvokeAbstractObjectMethod("getDefaultDisplay.()Landroid/view/Display;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IWindowManagerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[ObsoletedOSPlatform("android30.0")]
	private static Delegate GetGetDefaultDisplayHandler()
	{
		return new _JniMarshal_PP_L(n_GetDefaultDisplay);
	}

	[ObsoletedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDefaultDisplay(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefaultDisplay);
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

	private static Delegate GetRemoveViewImmediate_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_V(n_RemoveViewImmediate_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveViewImmediate_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowManager? windowManager = Java.Lang.Object.GetObject<IWindowManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			windowManager.RemoveViewImmediate(view);
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

	public unsafe void RemoveViewImmediate(View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			_members_android_view_WindowManager.InstanceMethods.InvokeAbstractVoidMethod("removeViewImmediate.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(view);
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
