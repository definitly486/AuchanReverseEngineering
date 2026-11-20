using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using AndroidX.AppCompat.View;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.App;

[Register("androidx/appcompat/app/AppCompatCallback", DoNotGenerateAcw = true)]
internal class IAppCompatCallbackInvoker : Java.Lang.Object, IAppCompatCallback, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_appcompat_app_AppCompatCallback = new XAPeerMembers("androidx/appcompat/app/AppCompatCallback", typeof(IAppCompatCallbackInvoker));

	private static Delegate? cb_onSupportActionModeFinished_OnSupportActionModeFinished_Landroidx_appcompat_view_ActionMode__V;

	private static Delegate? cb_onSupportActionModeStarted_OnSupportActionModeStarted_Landroidx_appcompat_view_ActionMode__V;

	private static Delegate? cb_onWindowStartingSupportActionMode_OnWindowStartingSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback__Landroidx_appcompat_view_ActionMode_;

	private static nint java_class_ref => _members_androidx_appcompat_app_AppCompatCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_app_AppCompatCallback;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_appcompat_app_AppCompatCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_appcompat_app_AppCompatCallback.ManagedPeerType;

	public IAppCompatCallbackInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnSupportActionModeFinished_Landroidx_appcompat_view_ActionMode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnSupportActionModeFinished_Landroidx_appcompat_view_ActionMode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSupportActionModeFinished_Landroidx_appcompat_view_ActionMode_(nint jnienv, nint native__this, nint native_mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IAppCompatCallback? appCompatCallback = Java.Lang.Object.GetObject<IAppCompatCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
			appCompatCallback.OnSupportActionModeFinished(mode);
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

	public unsafe void OnSupportActionModeFinished(ActionMode? mode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
			_members_androidx_appcompat_app_AppCompatCallback.InstanceMethods.InvokeAbstractVoidMethod("onSupportActionModeFinished.(Landroidx/appcompat/view/ActionMode;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(mode);
		}
	}

	private static Delegate GetOnSupportActionModeStarted_Landroidx_appcompat_view_ActionMode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnSupportActionModeStarted_Landroidx_appcompat_view_ActionMode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSupportActionModeStarted_Landroidx_appcompat_view_ActionMode_(nint jnienv, nint native__this, nint native_mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IAppCompatCallback? appCompatCallback = Java.Lang.Object.GetObject<IAppCompatCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
			appCompatCallback.OnSupportActionModeStarted(mode);
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

	public unsafe void OnSupportActionModeStarted(ActionMode? mode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
			_members_androidx_appcompat_app_AppCompatCallback.InstanceMethods.InvokeAbstractVoidMethod("onSupportActionModeStarted.(Landroidx/appcompat/view/ActionMode;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(mode);
		}
	}

	private static Delegate GetOnWindowStartingSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_OnWindowStartingSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnWindowStartingSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback_(nint jnienv, nint native__this, nint native_callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IAppCompatCallback? appCompatCallback = Java.Lang.Object.GetObject<IAppCompatCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionMode.ICallback callback_ = Java.Lang.Object.GetObject<ActionMode.ICallback>(native_callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(appCompatCallback.OnWindowStartingSupportActionMode(callback_));
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

	public unsafe ActionMode? OnWindowStartingSupportActionMode(ActionMode.ICallback? callback_)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback_ == null) ? IntPtr.Zero : ((Java.Lang.Object)callback_).Handle);
			return Java.Lang.Object.GetObject<ActionMode>(_members_androidx_appcompat_app_AppCompatCallback.InstanceMethods.InvokeAbstractObjectMethod("onWindowStartingSupportActionMode.(Landroidx/appcompat/view/ActionMode$Callback;)Landroidx/appcompat/view/ActionMode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback_);
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
