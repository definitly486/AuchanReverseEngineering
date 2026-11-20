using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using AndroidX.Activity;
using AndroidX.AppCompat.View;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.App;

[Register("androidx/appcompat/app/AppCompatDialog", DoNotGenerateAcw = true)]
public class AppCompatDialog : ComponentDialog, IAppCompatCallback, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/app/AppCompatDialog", typeof(AppCompatDialog));

	private static Delegate? cb_getDelegate_GetDelegate_Landroidx_appcompat_app_AppCompatDelegate_;

	private static Delegate? cb_getSupportActionBar_GetSupportActionBar_Landroidx_appcompat_app_ActionBar_;

	private static Delegate? cb_onSupportActionModeFinished_OnSupportActionModeFinished_Landroidx_appcompat_view_ActionMode__V;

	private static Delegate? cb_onSupportActionModeStarted_OnSupportActionModeStarted_Landroidx_appcompat_view_ActionMode__V;

	private static Delegate? cb_onWindowStartingSupportActionMode_OnWindowStartingSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback__Landroidx_appcompat_view_ActionMode_;

	private static Delegate? cb_supportRequestWindowFeature_SupportRequestWindowFeature_I_Z;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual AppCompatDelegate Delegate
	{
		[Register("getDelegate", "()Landroidx/appcompat/app/AppCompatDelegate;", "GetGetDelegateHandler")]
		get
		{
			return Java.Lang.Object.GetObject<AppCompatDelegate>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDelegate.()Landroidx/appcompat/app/AppCompatDelegate;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ActionBar? SupportActionBar
	{
		[Register("getSupportActionBar", "()Landroidx/appcompat/app/ActionBar;", "GetGetSupportActionBarHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ActionBar>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportActionBar.()Landroidx/appcompat/app/ActionBar;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected AppCompatDialog(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe AppCompatDialog(Context context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;ZLandroid/content/DialogInterface$OnCancelListener;)V", "")]
	protected unsafe AppCompatDialog(Context context, bool cancelable, IDialogInterfaceOnCancelListener? cancelListener)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(cancelable ? ((sbyte)1) : ((sbyte)0));
			ptr[2] = new JniArgumentValue((cancelListener == null) ? IntPtr.Zero : ((Java.Lang.Object)cancelListener).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;ZLandroid/content/DialogInterface$OnCancelListener;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;ZLandroid/content/DialogInterface$OnCancelListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(cancelListener);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;I)V", "")]
	public unsafe AppCompatDialog(Context context, int theme)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(theme);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetGetDelegateHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDelegate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDelegate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Delegate);
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

	private static Delegate GetGetSupportActionBarHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupportActionBar);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupportActionBar(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportActionBar);
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
			AppCompatDialog? appCompatDialog = Java.Lang.Object.GetObject<AppCompatDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
			appCompatDialog.OnSupportActionModeFinished(mode);
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

	[Register("onSupportActionModeFinished", "(Landroidx/appcompat/view/ActionMode;)V", "GetOnSupportActionModeFinished_Landroidx_appcompat_view_ActionMode_Handler")]
	public unsafe virtual void OnSupportActionModeFinished(ActionMode? mode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onSupportActionModeFinished.(Landroidx/appcompat/view/ActionMode;)V", this, ptr);
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
			AppCompatDialog? appCompatDialog = Java.Lang.Object.GetObject<AppCompatDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionMode mode = Java.Lang.Object.GetObject<ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
			appCompatDialog.OnSupportActionModeStarted(mode);
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

	[Register("onSupportActionModeStarted", "(Landroidx/appcompat/view/ActionMode;)V", "GetOnSupportActionModeStarted_Landroidx_appcompat_view_ActionMode_Handler")]
	public unsafe virtual void OnSupportActionModeStarted(ActionMode? mode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(mode?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onSupportActionModeStarted.(Landroidx/appcompat/view/ActionMode;)V", this, ptr);
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
	private static nint n_OnWindowStartingSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AppCompatDialog? appCompatDialog = Java.Lang.Object.GetObject<AppCompatDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionMode.ICallback callback = Java.Lang.Object.GetObject<ActionMode.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(appCompatDialog.OnWindowStartingSupportActionMode(callback));
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

	[Register("onWindowStartingSupportActionMode", "(Landroidx/appcompat/view/ActionMode$Callback;)Landroidx/appcompat/view/ActionMode;", "GetOnWindowStartingSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback_Handler")]
	public unsafe virtual ActionMode? OnWindowStartingSupportActionMode(ActionMode.ICallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<ActionMode>(_members.InstanceMethods.InvokeVirtualObjectMethod("onWindowStartingSupportActionMode.(Landroidx/appcompat/view/ActionMode$Callback;)Landroidx/appcompat/view/ActionMode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetSupportRequestWindowFeature_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_SupportRequestWindowFeature_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SupportRequestWindowFeature_I(nint jnienv, nint native__this, int featureId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AppCompatDialog>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportRequestWindowFeature(featureId) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("supportRequestWindowFeature", "(I)Z", "GetSupportRequestWindowFeature_IHandler")]
	public unsafe virtual bool SupportRequestWindowFeature(int featureId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(featureId);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("supportRequestWindowFeature.(I)Z", this, ptr);
	}
}
