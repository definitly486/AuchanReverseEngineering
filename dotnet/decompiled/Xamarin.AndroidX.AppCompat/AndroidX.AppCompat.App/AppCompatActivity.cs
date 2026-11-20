using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.View;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.App;
using AndroidX.Core.OS;
using AndroidX.Fragment.App;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.App;

[Register("androidx/appcompat/app/AppCompatActivity", DoNotGenerateAcw = true)]
public class AppCompatActivity : FragmentActivity, IJavaObject, IDisposable, IJavaPeerable, IAppCompatCallback
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/app/AppCompatActivity", typeof(AppCompatActivity));

	private static Delegate? cb_getDelegate_GetDelegate_Landroidx_appcompat_app_AppCompatDelegate_;

	private static Delegate? cb_getDrawerToggleDelegate_GetDrawerToggleDelegate_Landroidx_appcompat_app_ActionBarDrawerToggle_Delegate_;

	private static Delegate? cb_getSupportActionBar_GetSupportActionBar_Landroidx_appcompat_app_ActionBar_;

	private static Delegate? cb_getSupportParentActivityIntent_GetSupportParentActivityIntent_Landroid_content_Intent_;

	private static Delegate? cb_onCreateSupportNavigateUpTaskStack_OnCreateSupportNavigateUpTaskStack_Landroidx_core_app_TaskStackBuilder__V;

	private static Delegate? cb_onLocalesChanged_OnLocalesChanged_Landroidx_core_os_LocaleListCompat__V;

	private static Delegate? cb_onNightModeChanged_OnNightModeChanged_I_V;

	private static Delegate? cb_onPrepareSupportNavigateUpTaskStack_OnPrepareSupportNavigateUpTaskStack_Landroidx_core_app_TaskStackBuilder__V;

	private static Delegate? cb_onSupportActionModeFinished_OnSupportActionModeFinished_Landroidx_appcompat_view_ActionMode__V;

	private static Delegate? cb_onSupportActionModeStarted_OnSupportActionModeStarted_Landroidx_appcompat_view_ActionMode__V;

	private static Delegate? cb_onSupportContentChanged_OnSupportContentChanged_V;

	private static Delegate? cb_onSupportNavigateUp_OnSupportNavigateUp_Z;

	private static Delegate? cb_onWindowStartingSupportActionMode_OnWindowStartingSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback__Landroidx_appcompat_view_ActionMode_;

	private static Delegate? cb_setSupportActionBar_SetSupportActionBar_Landroidx_appcompat_widget_Toolbar__V;

	private static Delegate? cb_setSupportProgress_SetSupportProgress_I_V;

	private static Delegate? cb_setSupportProgressBarIndeterminate_SetSupportProgressBarIndeterminate_Z_V;

	private static Delegate? cb_setSupportProgressBarIndeterminateVisibility_SetSupportProgressBarIndeterminateVisibility_Z_V;

	private static Delegate? cb_setSupportProgressBarVisibility_SetSupportProgressBarVisibility_Z_V;

	private static Delegate? cb_startSupportActionMode_StartSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback__Landroidx_appcompat_view_ActionMode_;

	private static Delegate? cb_supportNavigateUpTo_SupportNavigateUpTo_Landroid_content_Intent__V;

	private static Delegate? cb_supportRequestWindowFeature_SupportRequestWindowFeature_I_Z;

	private static Delegate? cb_supportShouldUpRecreateTask_SupportShouldUpRecreateTask_Landroid_content_Intent__Z;

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

	public unsafe virtual ActionBarDrawerToggle.IDelegate? DrawerToggleDelegate
	{
		[Register("getDrawerToggleDelegate", "()Landroidx/appcompat/app/ActionBarDrawerToggle$Delegate;", "GetGetDrawerToggleDelegateHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ActionBarDrawerToggle.IDelegate>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDrawerToggleDelegate.()Landroidx/appcompat/app/ActionBarDrawerToggle$Delegate;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe virtual Intent? SupportParentActivityIntent
	{
		[Register("getSupportParentActivityIntent", "()Landroid/content/Intent;", "GetGetSupportParentActivityIntentHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Intent>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportParentActivityIntent.()Landroid/content/Intent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected AppCompatActivity(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe AppCompatActivity()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe AppCompatActivity(int contentLayoutId)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(contentLayoutId);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Delegate);
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

	private static Delegate GetGetDrawerToggleDelegateHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDrawerToggleDelegate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDrawerToggleDelegate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawerToggleDelegate);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportActionBar);
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

	private static Delegate GetGetSupportParentActivityIntentHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupportParentActivityIntent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupportParentActivityIntent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportParentActivityIntent);
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

	private static Delegate GetOnCreateSupportNavigateUpTaskStack_Landroidx_core_app_TaskStackBuilder_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnCreateSupportNavigateUpTaskStack_Landroidx_core_app_TaskStackBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCreateSupportNavigateUpTaskStack_Landroidx_core_app_TaskStackBuilder_(nint jnienv, nint native__this, nint native_builder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatActivity? appCompatActivity = Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TaskStackBuilder builder = Java.Lang.Object.GetObject<TaskStackBuilder>(native_builder, JniHandleOwnership.DoNotTransfer);
			appCompatActivity.OnCreateSupportNavigateUpTaskStack(builder);
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

	[Register("onCreateSupportNavigateUpTaskStack", "(Landroidx/core/app/TaskStackBuilder;)V", "GetOnCreateSupportNavigateUpTaskStack_Landroidx_core_app_TaskStackBuilder_Handler")]
	public unsafe virtual void OnCreateSupportNavigateUpTaskStack(TaskStackBuilder builder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCreateSupportNavigateUpTaskStack.(Landroidx/core/app/TaskStackBuilder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(builder);
		}
	}

	private static Delegate GetOnLocalesChanged_Landroidx_core_os_LocaleListCompat_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnLocalesChanged_Landroidx_core_os_LocaleListCompat_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLocalesChanged_Landroidx_core_os_LocaleListCompat_(nint jnienv, nint native__this, nint native_locales)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatActivity? appCompatActivity = Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LocaleListCompat locales = Java.Lang.Object.GetObject<LocaleListCompat>(native_locales, JniHandleOwnership.DoNotTransfer);
			appCompatActivity.OnLocalesChanged(locales);
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

	[Register("onLocalesChanged", "(Landroidx/core/os/LocaleListCompat;)V", "GetOnLocalesChanged_Landroidx_core_os_LocaleListCompat_Handler")]
	protected unsafe virtual void OnLocalesChanged(LocaleListCompat locales)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(locales?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onLocalesChanged.(Landroidx/core/os/LocaleListCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(locales);
		}
	}

	[Register("onMenuItemSelected", "(ILandroid/view/MenuItem;)Z", "")]
	public unsafe sealed override bool OnMenuItemSelected(int featureId, IMenuItem item)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(featureId);
			ptr[1] = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("onMenuItemSelected.(ILandroid/view/MenuItem;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(item);
		}
	}

	private static Delegate GetOnNightModeChanged_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_OnNightModeChanged_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnNightModeChanged_I(nint jnienv, nint native__this, int mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnNightModeChanged(mode);
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

	[Register("onNightModeChanged", "(I)V", "GetOnNightModeChanged_IHandler")]
	protected unsafe virtual void OnNightModeChanged(int mode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(mode);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onNightModeChanged.(I)V", this, ptr);
	}

	private static Delegate GetOnPrepareSupportNavigateUpTaskStack_Landroidx_core_app_TaskStackBuilder_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnPrepareSupportNavigateUpTaskStack_Landroidx_core_app_TaskStackBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPrepareSupportNavigateUpTaskStack_Landroidx_core_app_TaskStackBuilder_(nint jnienv, nint native__this, nint native_builder)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatActivity? appCompatActivity = Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TaskStackBuilder builder = Java.Lang.Object.GetObject<TaskStackBuilder>(native_builder, JniHandleOwnership.DoNotTransfer);
			appCompatActivity.OnPrepareSupportNavigateUpTaskStack(builder);
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

	[Register("onPrepareSupportNavigateUpTaskStack", "(Landroidx/core/app/TaskStackBuilder;)V", "GetOnPrepareSupportNavigateUpTaskStack_Landroidx_core_app_TaskStackBuilder_Handler")]
	public unsafe virtual void OnPrepareSupportNavigateUpTaskStack(TaskStackBuilder builder)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(builder?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPrepareSupportNavigateUpTaskStack.(Landroidx/core/app/TaskStackBuilder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(builder);
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
			AppCompatActivity? appCompatActivity = Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AndroidX.AppCompat.View.ActionMode mode = Java.Lang.Object.GetObject<AndroidX.AppCompat.View.ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
			appCompatActivity.OnSupportActionModeFinished(mode);
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
	public unsafe virtual void OnSupportActionModeFinished(AndroidX.AppCompat.View.ActionMode mode)
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
			AppCompatActivity? appCompatActivity = Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AndroidX.AppCompat.View.ActionMode mode = Java.Lang.Object.GetObject<AndroidX.AppCompat.View.ActionMode>(native_mode, JniHandleOwnership.DoNotTransfer);
			appCompatActivity.OnSupportActionModeStarted(mode);
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
	public unsafe virtual void OnSupportActionModeStarted(AndroidX.AppCompat.View.ActionMode mode)
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

	[Obsolete]
	private static Delegate GetOnSupportContentChangedHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnSupportContentChanged);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSupportContentChanged(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSupportContentChanged();
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

	[Obsolete("deprecated")]
	[Register("onSupportContentChanged", "()V", "GetOnSupportContentChangedHandler")]
	public unsafe virtual void OnSupportContentChanged()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onSupportContentChanged.()V", this, null);
	}

	private static Delegate GetOnSupportNavigateUpHandler()
	{
		return new global::_JniMarshal_PP_B(n_OnSupportNavigateUp);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnSupportNavigateUp(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSupportNavigateUp() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onSupportNavigateUp", "()Z", "GetOnSupportNavigateUpHandler")]
	public unsafe virtual bool OnSupportNavigateUp()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("onSupportNavigateUp.()Z", this, null);
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
			AppCompatActivity? appCompatActivity = Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AndroidX.AppCompat.View.ActionMode.ICallback callback = Java.Lang.Object.GetObject<AndroidX.AppCompat.View.ActionMode.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(appCompatActivity.OnWindowStartingSupportActionMode(callback));
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
	public unsafe virtual AndroidX.AppCompat.View.ActionMode? OnWindowStartingSupportActionMode(AndroidX.AppCompat.View.ActionMode.ICallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<AndroidX.AppCompat.View.ActionMode>(_members.InstanceMethods.InvokeVirtualObjectMethod("onWindowStartingSupportActionMode.(Landroidx/appcompat/view/ActionMode$Callback;)Landroidx/appcompat/view/ActionMode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetSetSupportActionBar_Landroidx_appcompat_widget_Toolbar_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSupportActionBar_Landroidx_appcompat_widget_Toolbar_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportActionBar_Landroidx_appcompat_widget_Toolbar_(nint jnienv, nint native__this, nint native_toolbar)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatActivity? appCompatActivity = Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Toolbar supportActionBar = Java.Lang.Object.GetObject<Toolbar>(native_toolbar, JniHandleOwnership.DoNotTransfer);
			appCompatActivity.SetSupportActionBar(supportActionBar);
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

	[Register("setSupportActionBar", "(Landroidx/appcompat/widget/Toolbar;)V", "GetSetSupportActionBar_Landroidx_appcompat_widget_Toolbar_Handler")]
	public unsafe virtual void SetSupportActionBar(Toolbar? toolbar)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(toolbar?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportActionBar.(Landroidx/appcompat/widget/Toolbar;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(toolbar);
		}
	}

	[Obsolete]
	private static Delegate GetSetSupportProgress_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSupportProgress_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportProgress_I(nint jnienv, nint native__this, int progress)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSupportProgress(progress);
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

	[Obsolete("deprecated")]
	[Register("setSupportProgress", "(I)V", "GetSetSupportProgress_IHandler")]
	public unsafe virtual void SetSupportProgress(int progress)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(progress);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportProgress.(I)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetSetSupportProgressBarIndeterminate_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetSupportProgressBarIndeterminate_Z);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportProgressBarIndeterminate_Z(nint jnienv, nint native__this, sbyte native_indeterminate)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatActivity? appCompatActivity = Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool supportProgressBarIndeterminate = native_indeterminate != 0;
			appCompatActivity.SetSupportProgressBarIndeterminate(supportProgressBarIndeterminate);
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

	[Obsolete("deprecated")]
	[Register("setSupportProgressBarIndeterminate", "(Z)V", "GetSetSupportProgressBarIndeterminate_ZHandler")]
	public unsafe virtual void SetSupportProgressBarIndeterminate(bool indeterminate)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(indeterminate ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportProgressBarIndeterminate.(Z)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetSetSupportProgressBarIndeterminateVisibility_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetSupportProgressBarIndeterminateVisibility_Z);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportProgressBarIndeterminateVisibility_Z(nint jnienv, nint native__this, sbyte native_visible)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatActivity? appCompatActivity = Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool supportProgressBarIndeterminateVisibility = native_visible != 0;
			appCompatActivity.SetSupportProgressBarIndeterminateVisibility(supportProgressBarIndeterminateVisibility);
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

	[Obsolete("deprecated")]
	[Register("setSupportProgressBarIndeterminateVisibility", "(Z)V", "GetSetSupportProgressBarIndeterminateVisibility_ZHandler")]
	public unsafe virtual void SetSupportProgressBarIndeterminateVisibility(bool visible)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(visible ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportProgressBarIndeterminateVisibility.(Z)V", this, ptr);
	}

	[Obsolete]
	private static Delegate GetSetSupportProgressBarVisibility_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetSupportProgressBarVisibility_Z);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportProgressBarVisibility_Z(nint jnienv, nint native__this, sbyte native_visible)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatActivity? appCompatActivity = Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool supportProgressBarVisibility = native_visible != 0;
			appCompatActivity.SetSupportProgressBarVisibility(supportProgressBarVisibility);
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

	[Obsolete("deprecated")]
	[Register("setSupportProgressBarVisibility", "(Z)V", "GetSetSupportProgressBarVisibility_ZHandler")]
	public unsafe virtual void SetSupportProgressBarVisibility(bool visible)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(visible ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportProgressBarVisibility.(Z)V", this, ptr);
	}

	private static Delegate GetStartSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_StartSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_StartSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback_(nint jnienv, nint native__this, nint native__callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AppCompatActivity? appCompatActivity = Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AndroidX.AppCompat.View.ActionMode.ICallback callback = Java.Lang.Object.GetObject<AndroidX.AppCompat.View.ActionMode.ICallback>(native__callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(appCompatActivity.StartSupportActionMode(callback));
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

	[Register("startSupportActionMode", "(Landroidx/appcompat/view/ActionMode$Callback;)Landroidx/appcompat/view/ActionMode;", "GetStartSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback_Handler")]
	public unsafe virtual AndroidX.AppCompat.View.ActionMode? StartSupportActionMode(AndroidX.AppCompat.View.ActionMode.ICallback callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<AndroidX.AppCompat.View.ActionMode>(_members.InstanceMethods.InvokeVirtualObjectMethod("startSupportActionMode.(Landroidx/appcompat/view/ActionMode$Callback;)Landroidx/appcompat/view/ActionMode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetSupportNavigateUpTo_Landroid_content_Intent_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SupportNavigateUpTo_Landroid_content_Intent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SupportNavigateUpTo_Landroid_content_Intent_(nint jnienv, nint native__this, nint native_upIntent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatActivity? appCompatActivity = Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent upIntent = Java.Lang.Object.GetObject<Intent>(native_upIntent, JniHandleOwnership.DoNotTransfer);
			appCompatActivity.SupportNavigateUpTo(upIntent);
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

	[Register("supportNavigateUpTo", "(Landroid/content/Intent;)V", "GetSupportNavigateUpTo_Landroid_content_Intent_Handler")]
	public unsafe virtual void SupportNavigateUpTo(Intent upIntent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(upIntent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("supportNavigateUpTo.(Landroid/content/Intent;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(upIntent);
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
			return Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportRequestWindowFeature(featureId) ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSupportShouldUpRecreateTask_Landroid_content_Intent_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_SupportShouldUpRecreateTask_Landroid_content_Intent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SupportShouldUpRecreateTask_Landroid_content_Intent_(nint jnienv, nint native__this, nint native_targetIntent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AppCompatActivity? appCompatActivity = Java.Lang.Object.GetObject<AppCompatActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent targetIntent = Java.Lang.Object.GetObject<Intent>(native_targetIntent, JniHandleOwnership.DoNotTransfer);
			return appCompatActivity.SupportShouldUpRecreateTask(targetIntent) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("supportShouldUpRecreateTask", "(Landroid/content/Intent;)Z", "GetSupportShouldUpRecreateTask_Landroid_content_Intent_Handler")]
	public unsafe virtual bool SupportShouldUpRecreateTask(Intent targetIntent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(targetIntent?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("supportShouldUpRecreateTask.(Landroid/content/Intent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(targetIntent);
		}
	}
}
