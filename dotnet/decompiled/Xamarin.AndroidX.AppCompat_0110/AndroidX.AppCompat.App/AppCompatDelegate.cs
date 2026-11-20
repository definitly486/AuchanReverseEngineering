using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Window;
using AndroidX.AppCompat.View;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.OS;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.App;

[Register("androidx/appcompat/app/AppCompatDelegate", DoNotGenerateAcw = true)]
public abstract class AppCompatDelegate : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/app/AppCompatDelegate", typeof(AppCompatDelegate));

	private static Delegate? cb_getContextForDelegate_GetContextForDelegate_Landroid_content_Context_;

	private static Delegate? cb_getDrawerToggleDelegate_GetDrawerToggleDelegate_Landroidx_appcompat_app_ActionBarDrawerToggle_Delegate_;

	private static Delegate? cb_isHandleNativeActionModesEnabled_IsHandleNativeActionModesEnabled_Z;

	private static Delegate? cb_setHandleNativeActionModesEnabled_SetHandleNativeActionModesEnabled_Z_V;

	private static Delegate? cb_getLocalNightMode_GetLocalNightMode_I;

	private static Delegate? cb_getMenuInflater_GetMenuInflater_Landroid_view_MenuInflater_;

	private static Delegate? cb_getSupportActionBar_GetSupportActionBar_Landroidx_appcompat_app_ActionBar_;

	private static Delegate? cb_addContentView_AddContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams__V;

	private static Delegate? cb_applyDayNight_ApplyDayNight_Z;

	private static Delegate? cb_attachBaseContext_AttachBaseContext_Landroid_content_Context__V;

	private static Delegate? cb_attachBaseContext2_AttachBaseContext2_Landroid_content_Context__Landroid_content_Context_;

	private static Delegate? cb_createView_CreateView_Landroid_view_View_Ljava_lang_String_Landroid_content_Context_Landroid_util_AttributeSet__Landroid_view_View_;

	private static Delegate? cb_findViewById_FindViewById_I_Landroid_view_View_;

	private static Delegate? cb_hasWindowFeature_HasWindowFeature_I_Z;

	private static Delegate? cb_installViewFactory_InstallViewFactory_V;

	private static Delegate? cb_invalidateOptionsMenu_InvalidateOptionsMenu_V;

	private static Delegate? cb_onConfigurationChanged_OnConfigurationChanged_Landroid_content_res_Configuration__V;

	private static Delegate? cb_onCreate_OnCreate_Landroid_os_Bundle__V;

	private static Delegate? cb_onDestroy_OnDestroy_V;

	private static Delegate? cb_onPostCreate_OnPostCreate_Landroid_os_Bundle__V;

	private static Delegate? cb_onPostResume_OnPostResume_V;

	private static Delegate? cb_onSaveInstanceState_OnSaveInstanceState_Landroid_os_Bundle__V;

	private static Delegate? cb_onStart_OnStart_V;

	private static Delegate? cb_onStop_OnStop_V;

	private static Delegate? cb_requestWindowFeature_RequestWindowFeature_I_Z;

	private static Delegate? cb_setContentView_SetContentView_Landroid_view_View__V;

	private static Delegate? cb_setContentView_SetContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams__V;

	private static Delegate? cb_setContentView_SetContentView_I_V;

	private static Delegate? cb_setLocalNightMode_SetLocalNightMode_I_V;

	private static Delegate? cb_setOnBackInvokedDispatcher_SetOnBackInvokedDispatcher_Landroid_window_OnBackInvokedDispatcher__V;

	private static Delegate? cb_setSupportActionBar_SetSupportActionBar_Landroidx_appcompat_widget_Toolbar__V;

	private static Delegate? cb_setTheme_SetTheme_I_V;

	private static Delegate? cb_setTitle_SetTitle_Ljava_lang_CharSequence__V;

	private static Delegate? cb_startSupportActionMode_StartSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback__Landroidx_appcompat_view_ActionMode_;

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

	public unsafe static LocaleListCompat ApplicationLocales
	{
		[Register("getApplicationLocales", "()Landroidx/core/os/LocaleListCompat;", "")]
		get
		{
			return Java.Lang.Object.GetObject<LocaleListCompat>(_members.StaticMethods.InvokeObjectMethod("getApplicationLocales.()Landroidx/core/os/LocaleListCompat;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setApplicationLocales", "(Landroidx/core/os/LocaleListCompat;)V", "")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("setApplicationLocales.(Landroidx/core/os/LocaleListCompat;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe static bool CompatVectorFromResourcesEnabled
	{
		[Register("isCompatVectorFromResourcesEnabled", "()Z", "")]
		get
		{
			return _members.StaticMethods.InvokeBooleanMethod("isCompatVectorFromResourcesEnabled.()Z", null);
		}
		[Register("setCompatVectorFromResourcesEnabled", "(Z)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.StaticMethods.InvokeVoidMethod("setCompatVectorFromResourcesEnabled.(Z)V", ptr);
		}
	}

	public unsafe virtual Context? ContextForDelegate
	{
		[Register("getContextForDelegate", "()Landroid/content/Context;", "GetGetContextForDelegateHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContextForDelegate.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe static int DefaultNightMode
	{
		[Register("getDefaultNightMode", "()I", "")]
		get
		{
			return _members.StaticMethods.InvokeInt32Method("getDefaultNightMode.()I", null);
		}
		[Register("setDefaultNightMode", "(I)V", "")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.StaticMethods.InvokeVoidMethod("setDefaultNightMode.(I)V", ptr);
		}
	}

	public abstract ActionBarDrawerToggle.IDelegate? DrawerToggleDelegate
	{
		[Register("getDrawerToggleDelegate", "()Landroidx/appcompat/app/ActionBarDrawerToggle$Delegate;", "GetGetDrawerToggleDelegateHandler")]
		get;
	}

	public abstract bool HandleNativeActionModesEnabled
	{
		[Register("isHandleNativeActionModesEnabled", "()Z", "GetIsHandleNativeActionModesEnabledHandler")]
		get;
		[Register("setHandleNativeActionModesEnabled", "(Z)V", "GetSetHandleNativeActionModesEnabled_ZHandler")]
		set;
	}

	public unsafe virtual int LocalNightMode
	{
		[Register("getLocalNightMode", "()I", "GetGetLocalNightModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLocalNightMode.()I", this, null);
		}
	}

	public abstract MenuInflater? MenuInflater
	{
		[Register("getMenuInflater", "()Landroid/view/MenuInflater;", "GetGetMenuInflaterHandler")]
		get;
	}

	public abstract ActionBar? SupportActionBar
	{
		[Register("getSupportActionBar", "()Landroidx/appcompat/app/ActionBar;", "GetGetSupportActionBarHandler")]
		get;
	}

	protected AppCompatDelegate(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetContextForDelegateHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetContextForDelegate);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContextForDelegate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContextForDelegate);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawerToggleDelegate);
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

	private static Delegate GetIsHandleNativeActionModesEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsHandleNativeActionModesEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsHandleNativeActionModesEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HandleNativeActionModesEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetHandleNativeActionModesEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetHandleNativeActionModesEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHandleNativeActionModesEnabled_Z(nint jnienv, nint native__this, sbyte native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool handleNativeActionModesEnabled = native_p0 != 0;
			appCompatDelegate.HandleNativeActionModesEnabled = handleNativeActionModesEnabled;
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

	private static Delegate GetGetLocalNightModeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLocalNightMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLocalNightMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LocalNightMode;
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

	private static Delegate GetGetMenuInflaterHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetMenuInflater);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMenuInflater(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MenuInflater);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportActionBar);
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

	private static Delegate GetAddContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_AddContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_(nint jnienv, nint native__this, nint native_v, nint native_lp)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View v = Java.Lang.Object.GetObject<Android.Views.View>(native_v, JniHandleOwnership.DoNotTransfer);
			ViewGroup.LayoutParams lp = Java.Lang.Object.GetObject<ViewGroup.LayoutParams>(native_lp, JniHandleOwnership.DoNotTransfer);
			appCompatDelegate.AddContentView(v, lp);
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

	[Register("addContentView", "(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", "GetAddContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler")]
	public abstract void AddContentView(Android.Views.View? v, ViewGroup.LayoutParams? lp);

	private static Delegate GetApplyDayNightHandler()
	{
		return new global::_JniMarshal_PP_B(n_ApplyDayNight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ApplyDayNight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplyDayNight() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("applyDayNight", "()Z", "GetApplyDayNightHandler")]
	public abstract bool ApplyDayNight();

	[Obsolete]
	private static Delegate GetAttachBaseContext_Landroid_content_Context_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AttachBaseContext_Landroid_content_Context_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AttachBaseContext_Landroid_content_Context_(nint jnienv, nint native__this, nint native_context)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			appCompatDelegate.AttachBaseContext(context);
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
	[Register("attachBaseContext", "(Landroid/content/Context;)V", "GetAttachBaseContext_Landroid_content_Context_Handler")]
	public unsafe virtual void AttachBaseContext(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("attachBaseContext.(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetAttachBaseContext2_Landroid_content_Context_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_AttachBaseContext2_Landroid_content_Context_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AttachBaseContext2_Landroid_content_Context_(nint jnienv, nint native__this, nint native_context)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(appCompatDelegate.AttachBaseContext2(context));
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

	[Register("attachBaseContext2", "(Landroid/content/Context;)Landroid/content/Context;", "GetAttachBaseContext2_Landroid_content_Context_Handler")]
	public unsafe virtual Context AttachBaseContext2(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("attachBaseContext2.(Landroid/content/Context;)Landroid/content/Context;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("create", "(Landroid/app/Activity;Landroidx/appcompat/app/AppCompatCallback;)Landroidx/appcompat/app/AppCompatDelegate;", "")]
	public unsafe static AppCompatDelegate Create(Android.App.Activity activity, IAppCompatCallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<AppCompatDelegate>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/app/Activity;Landroidx/appcompat/app/AppCompatCallback;)Landroidx/appcompat/app/AppCompatDelegate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(activity);
			GC.KeepAlive(callback);
		}
	}

	[Register("create", "(Landroid/app/Dialog;Landroidx/appcompat/app/AppCompatCallback;)Landroidx/appcompat/app/AppCompatDelegate;", "")]
	public unsafe static AppCompatDelegate Create(Dialog dialog, IAppCompatCallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dialog?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<AppCompatDelegate>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/app/Dialog;Landroidx/appcompat/app/AppCompatCallback;)Landroidx/appcompat/app/AppCompatDelegate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(dialog);
			GC.KeepAlive(callback);
		}
	}

	[Register("create", "(Landroid/content/Context;Landroid/app/Activity;Landroidx/appcompat/app/AppCompatCallback;)Landroidx/appcompat/app/AppCompatDelegate;", "")]
	public unsafe static AppCompatDelegate Create(Context context, Android.App.Activity activity, IAppCompatCallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<AppCompatDelegate>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/content/Context;Landroid/app/Activity;Landroidx/appcompat/app/AppCompatCallback;)Landroidx/appcompat/app/AppCompatDelegate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(activity);
			GC.KeepAlive(callback);
		}
	}

	[Register("create", "(Landroid/content/Context;Landroid/view/Window;Landroidx/appcompat/app/AppCompatCallback;)Landroidx/appcompat/app/AppCompatDelegate;", "")]
	public unsafe static AppCompatDelegate Create(Context context, Window window, IAppCompatCallback? callback)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(window?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((callback == null) ? IntPtr.Zero : ((Java.Lang.Object)callback).Handle);
			return Java.Lang.Object.GetObject<AppCompatDelegate>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/content/Context;Landroid/view/Window;Landroidx/appcompat/app/AppCompatCallback;)Landroidx/appcompat/app/AppCompatDelegate;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(window);
			GC.KeepAlive(callback);
		}
	}

	private static Delegate GetCreateView_Landroid_view_View_Ljava_lang_String_Landroid_content_Context_Landroid_util_AttributeSet_Handler()
	{
		return new global::_JniMarshal_PPLLLL_L(n_CreateView_Landroid_view_View_Ljava_lang_String_Landroid_content_Context_Landroid_util_AttributeSet_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CreateView_Landroid_view_View_Ljava_lang_String_Landroid_content_Context_Landroid_util_AttributeSet_(nint jnienv, nint native__this, nint native_parent, nint native_name, nint native_context, nint native_attrs)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View parent = Java.Lang.Object.GetObject<Android.Views.View>(native_parent, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			IAttributeSet attrs = Java.Lang.Object.GetObject<IAttributeSet>(native_attrs, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(appCompatDelegate.CreateView(parent, name, context, attrs));
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

	[Register("createView", "(Landroid/view/View;Ljava/lang/String;Landroid/content/Context;Landroid/util/AttributeSet;)Landroid/view/View;", "GetCreateView_Landroid_view_View_Ljava_lang_String_Landroid_content_Context_Landroid_util_AttributeSet_Handler")]
	public abstract Android.Views.View? CreateView(Android.Views.View? parent, string? name, Context context, IAttributeSet attrs);

	private static Delegate GetFindViewById_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_FindViewById_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindViewById_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindViewById(id));
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

	[Register("findViewById", "(I)Landroid/view/View;", "GetFindViewById_IHandler")]
	[JavaTypeParameters(new string[] { "T extends android.view.View" })]
	public abstract Java.Lang.Object? FindViewById(int id);

	private static Delegate GetHasWindowFeature_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_HasWindowFeature_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasWindowFeature_I(nint jnienv, nint native__this, int featureId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasWindowFeature(featureId) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("hasWindowFeature", "(I)Z", "GetHasWindowFeature_IHandler")]
	public abstract bool HasWindowFeature(int featureId);

	private static Delegate GetInstallViewFactoryHandler()
	{
		return new global::_JniMarshal_PP_V(n_InstallViewFactory);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InstallViewFactory(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InstallViewFactory();
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

	[Register("installViewFactory", "()V", "GetInstallViewFactoryHandler")]
	public abstract void InstallViewFactory();

	private static Delegate GetInvalidateOptionsMenuHandler()
	{
		return new global::_JniMarshal_PP_V(n_InvalidateOptionsMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InvalidateOptionsMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateOptionsMenu();
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

	[Register("invalidateOptionsMenu", "()V", "GetInvalidateOptionsMenuHandler")]
	public abstract void InvalidateOptionsMenu();

	private static Delegate GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnConfigurationChanged_Landroid_content_res_Configuration_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnConfigurationChanged_Landroid_content_res_Configuration_(nint jnienv, nint native__this, nint native_newConfig)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Configuration newConfig = Java.Lang.Object.GetObject<Configuration>(native_newConfig, JniHandleOwnership.DoNotTransfer);
			appCompatDelegate.OnConfigurationChanged(newConfig);
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

	[Register("onConfigurationChanged", "(Landroid/content/res/Configuration;)V", "GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler")]
	public abstract void OnConfigurationChanged(Configuration? newConfig);

	private static Delegate GetOnCreate_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnCreate_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCreate_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_savedInstanceState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			appCompatDelegate.OnCreate(savedInstanceState);
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

	[Register("onCreate", "(Landroid/os/Bundle;)V", "GetOnCreate_Landroid_os_Bundle_Handler")]
	public abstract void OnCreate(Bundle? savedInstanceState);

	private static Delegate GetOnDestroyHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnDestroy);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDestroy(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDestroy();
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

	[Register("onDestroy", "()V", "GetOnDestroyHandler")]
	public abstract void OnDestroy();

	private static Delegate GetOnPostCreate_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnPostCreate_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPostCreate_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_savedInstanceState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle savedInstanceState = Java.Lang.Object.GetObject<Bundle>(native_savedInstanceState, JniHandleOwnership.DoNotTransfer);
			appCompatDelegate.OnPostCreate(savedInstanceState);
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

	[Register("onPostCreate", "(Landroid/os/Bundle;)V", "GetOnPostCreate_Landroid_os_Bundle_Handler")]
	public abstract void OnPostCreate(Bundle? savedInstanceState);

	private static Delegate GetOnPostResumeHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnPostResume);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPostResume(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnPostResume();
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

	[Register("onPostResume", "()V", "GetOnPostResumeHandler")]
	public abstract void OnPostResume();

	private static Delegate GetOnSaveInstanceState_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnSaveInstanceState_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSaveInstanceState_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_outState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle outState = Java.Lang.Object.GetObject<Bundle>(native_outState, JniHandleOwnership.DoNotTransfer);
			appCompatDelegate.OnSaveInstanceState(outState);
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

	[Register("onSaveInstanceState", "(Landroid/os/Bundle;)V", "GetOnSaveInstanceState_Landroid_os_Bundle_Handler")]
	public abstract void OnSaveInstanceState(Bundle? outState);

	private static Delegate GetOnStartHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnStart);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStart(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStart();
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

	[Register("onStart", "()V", "GetOnStartHandler")]
	public abstract void OnStart();

	private static Delegate GetOnStopHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnStop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStop();
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

	[Register("onStop", "()V", "GetOnStopHandler")]
	public abstract void OnStop();

	private static Delegate GetRequestWindowFeature_IHandler()
	{
		return new global::_JniMarshal_PPI_B(n_RequestWindowFeature_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RequestWindowFeature_I(nint jnienv, nint native__this, int featureId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequestWindowFeature(featureId) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("requestWindowFeature", "(I)Z", "GetRequestWindowFeature_IHandler")]
	public abstract bool RequestWindowFeature(int featureId);

	private static Delegate GetSetContentView_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetContentView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentView_Landroid_view_View_(nint jnienv, nint native__this, nint native_v)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View contentView = Java.Lang.Object.GetObject<Android.Views.View>(native_v, JniHandleOwnership.DoNotTransfer);
			appCompatDelegate.SetContentView(contentView);
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

	[Register("setContentView", "(Landroid/view/View;)V", "GetSetContentView_Landroid_view_View_Handler")]
	public abstract void SetContentView(Android.Views.View? v);

	private static Delegate GetSetContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_(nint jnienv, nint native__this, nint native_v, nint native_lp)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View v = Java.Lang.Object.GetObject<Android.Views.View>(native_v, JniHandleOwnership.DoNotTransfer);
			ViewGroup.LayoutParams lp = Java.Lang.Object.GetObject<ViewGroup.LayoutParams>(native_lp, JniHandleOwnership.DoNotTransfer);
			appCompatDelegate.SetContentView(v, lp);
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

	[Register("setContentView", "(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", "GetSetContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler")]
	public abstract void SetContentView(Android.Views.View? v, ViewGroup.LayoutParams? lp);

	private static Delegate GetSetContentView_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetContentView_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentView_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetContentView(resId);
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

	[Register("setContentView", "(I)V", "GetSetContentView_IHandler")]
	public abstract void SetContentView(int resId);

	private static Delegate GetSetLocalNightMode_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetLocalNightMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLocalNightMode_I(nint jnienv, nint native__this, int mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLocalNightMode(mode);
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

	[Register("setLocalNightMode", "(I)V", "GetSetLocalNightMode_IHandler")]
	public abstract void SetLocalNightMode(int mode);

	private static Delegate GetSetOnBackInvokedDispatcher_Landroid_window_OnBackInvokedDispatcher_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnBackInvokedDispatcher_Landroid_window_OnBackInvokedDispatcher_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnBackInvokedDispatcher_Landroid_window_OnBackInvokedDispatcher_(nint jnienv, nint native__this, nint native_dispatcher)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnBackInvokedDispatcher onBackInvokedDispatcher = Java.Lang.Object.GetObject<IOnBackInvokedDispatcher>(native_dispatcher, JniHandleOwnership.DoNotTransfer);
			appCompatDelegate.SetOnBackInvokedDispatcher(onBackInvokedDispatcher);
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

	[Register("setOnBackInvokedDispatcher", "(Landroid/window/OnBackInvokedDispatcher;)V", "GetSetOnBackInvokedDispatcher_Landroid_window_OnBackInvokedDispatcher_Handler")]
	public unsafe virtual void SetOnBackInvokedDispatcher(IOnBackInvokedDispatcher? dispatcher)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((dispatcher == null) ? IntPtr.Zero : ((Java.Lang.Object)dispatcher).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnBackInvokedDispatcher.(Landroid/window/OnBackInvokedDispatcher;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(dispatcher);
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
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Toolbar supportActionBar = Java.Lang.Object.GetObject<Toolbar>(native_toolbar, JniHandleOwnership.DoNotTransfer);
			appCompatDelegate.SetSupportActionBar(supportActionBar);
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
	public abstract void SetSupportActionBar(Toolbar? toolbar);

	private static Delegate GetSetTheme_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTheme_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTheme_I(nint jnienv, nint native__this, int themeResId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTheme(themeResId);
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

	[Register("setTheme", "(I)V", "GetSetTheme_IHandler")]
	public unsafe virtual void SetTheme(int themeResId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(themeResId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTheme.(I)V", this, ptr);
	}

	private static Delegate GetSetTitle_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTitle_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			appCompatDelegate.SetTitle(title);
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

	[Register("setTitle", "(Ljava/lang/CharSequence;)V", "GetSetTitle_Ljava_lang_CharSequence_Handler")]
	public abstract void SetTitle(ICharSequence? title);

	public void SetTitle(string? title)
	{
		Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
		SetTitle(obj);
		obj?.Dispose();
	}

	private static Delegate GetStartSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_StartSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_StartSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback_(nint jnienv, nint native__this, nint native_callback)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			AppCompatDelegate? appCompatDelegate = Java.Lang.Object.GetObject<AppCompatDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			AndroidX.AppCompat.View.ActionMode.ICallback callback_ = Java.Lang.Object.GetObject<AndroidX.AppCompat.View.ActionMode.ICallback>(native_callback, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(appCompatDelegate.StartSupportActionMode(callback_));
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
	public abstract AndroidX.AppCompat.View.ActionMode? StartSupportActionMode(AndroidX.AppCompat.View.ActionMode.ICallback callback_);
}
