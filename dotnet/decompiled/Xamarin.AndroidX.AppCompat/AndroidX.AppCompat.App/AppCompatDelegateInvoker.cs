using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.AppCompat.View;
using AndroidX.AppCompat.Widget;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.App;

[Register("androidx/appcompat/app/AppCompatDelegate", DoNotGenerateAcw = true)]
internal class AppCompatDelegateInvoker : AppCompatDelegate
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/app/AppCompatDelegate", typeof(AppCompatDelegateInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override ActionBarDrawerToggle.IDelegate? DrawerToggleDelegate
	{
		[Register("getDrawerToggleDelegate", "()Landroidx/appcompat/app/ActionBarDrawerToggle$Delegate;", "GetGetDrawerToggleDelegateHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ActionBarDrawerToggle.IDelegate>(_members.InstanceMethods.InvokeAbstractObjectMethod("getDrawerToggleDelegate.()Landroidx/appcompat/app/ActionBarDrawerToggle$Delegate;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override bool HandleNativeActionModesEnabled
	{
		[Register("isHandleNativeActionModesEnabled", "()Z", "GetIsHandleNativeActionModesEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("isHandleNativeActionModesEnabled.()Z", this, null);
		}
		[Register("setHandleNativeActionModesEnabled", "(Z)V", "GetSetHandleNativeActionModesEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeAbstractVoidMethod("setHandleNativeActionModesEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe override MenuInflater? MenuInflater
	{
		[Register("getMenuInflater", "()Landroid/view/MenuInflater;", "GetGetMenuInflaterHandler")]
		get
		{
			return Java.Lang.Object.GetObject<MenuInflater>(_members.InstanceMethods.InvokeAbstractObjectMethod("getMenuInflater.()Landroid/view/MenuInflater;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe override ActionBar? SupportActionBar
	{
		[Register("getSupportActionBar", "()Landroidx/appcompat/app/ActionBar;", "GetGetSupportActionBarHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ActionBar>(_members.InstanceMethods.InvokeAbstractObjectMethod("getSupportActionBar.()Landroidx/appcompat/app/ActionBar;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public AppCompatDelegateInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("addContentView", "(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", "GetAddContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler")]
	public unsafe override void AddContentView(Android.Views.View? v, ViewGroup.LayoutParams? lp)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(lp?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addContentView.(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(v);
			GC.KeepAlive(lp);
		}
	}

	[Register("applyDayNight", "()Z", "GetApplyDayNightHandler")]
	public unsafe override bool ApplyDayNight()
	{
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("applyDayNight.()Z", this, null);
	}

	[Register("createView", "(Landroid/view/View;Ljava/lang/String;Landroid/content/Context;Landroid/util/AttributeSet;)Landroid/view/View;", "GetCreateView_Landroid_view_View_Ljava_lang_String_Landroid_content_Context_Landroid_util_AttributeSet_Handler")]
	public unsafe override Android.Views.View? CreateView(Android.Views.View? parent, string? name, Context context, IAttributeSet attrs)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			ptr[2] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			return Java.Lang.Object.GetObject<Android.Views.View>(_members.InstanceMethods.InvokeAbstractObjectMethod("createView.(Landroid/view/View;Ljava/lang/String;Landroid/content/Context;Landroid/util/AttributeSet;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(parent);
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register("findViewById", "(I)Landroid/view/View;", "GetFindViewById_IHandler")]
	[JavaTypeParameters(new string[] { "T extends android.view.View" })]
	public unsafe override Java.Lang.Object? FindViewById(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("findViewById.(I)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("hasWindowFeature", "(I)Z", "GetHasWindowFeature_IHandler")]
	public unsafe override bool HasWindowFeature(int featureId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(featureId);
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasWindowFeature.(I)Z", this, ptr);
	}

	[Register("installViewFactory", "()V", "GetInstallViewFactoryHandler")]
	public unsafe override void InstallViewFactory()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("installViewFactory.()V", this, null);
	}

	[Register("invalidateOptionsMenu", "()V", "GetInvalidateOptionsMenuHandler")]
	public unsafe override void InvalidateOptionsMenu()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("invalidateOptionsMenu.()V", this, null);
	}

	[Register("onConfigurationChanged", "(Landroid/content/res/Configuration;)V", "GetOnConfigurationChanged_Landroid_content_res_Configuration_Handler")]
	public unsafe override void OnConfigurationChanged(Configuration? newConfig)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(newConfig?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onConfigurationChanged.(Landroid/content/res/Configuration;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(newConfig);
		}
	}

	[Register("onCreate", "(Landroid/os/Bundle;)V", "GetOnCreate_Landroid_os_Bundle_Handler")]
	public unsafe override void OnCreate(Bundle? savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onCreate.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(savedInstanceState);
		}
	}

	[Register("onDestroy", "()V", "GetOnDestroyHandler")]
	public unsafe override void OnDestroy()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("onDestroy.()V", this, null);
	}

	[Register("onPostCreate", "(Landroid/os/Bundle;)V", "GetOnPostCreate_Landroid_os_Bundle_Handler")]
	public unsafe override void OnPostCreate(Bundle? savedInstanceState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(savedInstanceState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onPostCreate.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(savedInstanceState);
		}
	}

	[Register("onPostResume", "()V", "GetOnPostResumeHandler")]
	public unsafe override void OnPostResume()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("onPostResume.()V", this, null);
	}

	[Register("onSaveInstanceState", "(Landroid/os/Bundle;)V", "GetOnSaveInstanceState_Landroid_os_Bundle_Handler")]
	public unsafe override void OnSaveInstanceState(Bundle? outState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("onSaveInstanceState.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outState);
		}
	}

	[Register("onStart", "()V", "GetOnStartHandler")]
	public unsafe override void OnStart()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("onStart.()V", this, null);
	}

	[Register("onStop", "()V", "GetOnStopHandler")]
	public unsafe override void OnStop()
	{
		_members.InstanceMethods.InvokeAbstractVoidMethod("onStop.()V", this, null);
	}

	[Register("requestWindowFeature", "(I)Z", "GetRequestWindowFeature_IHandler")]
	public unsafe override bool RequestWindowFeature(int featureId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(featureId);
		return _members.InstanceMethods.InvokeAbstractBooleanMethod("requestWindowFeature.(I)Z", this, ptr);
	}

	[Register("setContentView", "(Landroid/view/View;)V", "GetSetContentView_Landroid_view_View_Handler")]
	public unsafe override void SetContentView(Android.Views.View? v)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setContentView.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(v);
		}
	}

	[Register("setContentView", "(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", "GetSetContentView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler")]
	public unsafe override void SetContentView(Android.Views.View? v, ViewGroup.LayoutParams? lp)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(v?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(lp?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setContentView.(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(v);
			GC.KeepAlive(lp);
		}
	}

	[Register("setContentView", "(I)V", "GetSetContentView_IHandler")]
	public unsafe override void SetContentView(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setContentView.(I)V", this, ptr);
	}

	[Register("setLocalNightMode", "(I)V", "GetSetLocalNightMode_IHandler")]
	public unsafe override void SetLocalNightMode(int mode)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(mode);
		_members.InstanceMethods.InvokeAbstractVoidMethod("setLocalNightMode.(I)V", this, ptr);
	}

	[Register("setSupportActionBar", "(Landroidx/appcompat/widget/Toolbar;)V", "GetSetSupportActionBar_Landroidx_appcompat_widget_Toolbar_Handler")]
	public unsafe override void SetSupportActionBar(Toolbar? toolbar)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(toolbar?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setSupportActionBar.(Landroidx/appcompat/widget/Toolbar;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(toolbar);
		}
	}

	[Register("setTitle", "(Ljava/lang/CharSequence;)V", "GetSetTitle_Ljava_lang_CharSequence_Handler")]
	public unsafe override void SetTitle(ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setTitle.(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	[Register("startSupportActionMode", "(Landroidx/appcompat/view/ActionMode$Callback;)Landroidx/appcompat/view/ActionMode;", "GetStartSupportActionMode_Landroidx_appcompat_view_ActionMode_Callback_Handler")]
	public unsafe override AndroidX.AppCompat.View.ActionMode? StartSupportActionMode(AndroidX.AppCompat.View.ActionMode.ICallback callback_)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((callback_ == null) ? IntPtr.Zero : ((Java.Lang.Object)callback_).Handle);
			return Java.Lang.Object.GetObject<AndroidX.AppCompat.View.ActionMode>(_members.InstanceMethods.InvokeAbstractObjectMethod("startSupportActionMode.(Landroidx/appcompat/view/ActionMode$Callback;)Landroidx/appcompat/view/ActionMode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(callback_);
		}
	}
}
