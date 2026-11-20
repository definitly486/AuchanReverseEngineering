using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Graphics.Drawable;
using AndroidX.AppCompat.Widget;
using AndroidX.DrawerLayout.Widget;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.App;

[Register("androidx/appcompat/app/ActionBarDrawerToggle", DoNotGenerateAcw = true)]
public class ActionBarDrawerToggle : Java.Lang.Object, AndroidX.DrawerLayout.Widget.DrawerLayout.IDrawerListener, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("androidx/appcompat/app/ActionBarDrawerToggle$Delegate", "", "AndroidX.AppCompat.App.ActionBarDrawerToggle/IDelegateInvoker")]
	public interface IDelegate : IJavaObject, IDisposable, IJavaPeerable
	{
		Context? ActionBarThemedContext
		{
			[Register("getActionBarThemedContext", "()Landroid/content/Context;", "GetGetActionBarThemedContextHandler:AndroidX.AppCompat.App.ActionBarDrawerToggle/IDelegateInvoker, Xamarin.AndroidX.AppCompat")]
			get;
		}

		bool IsNavigationVisible
		{
			[Register("isNavigationVisible", "()Z", "GetIsNavigationVisibleHandler:AndroidX.AppCompat.App.ActionBarDrawerToggle/IDelegateInvoker, Xamarin.AndroidX.AppCompat")]
			get;
		}

		Drawable? ThemeUpIndicator
		{
			[Register("getThemeUpIndicator", "()Landroid/graphics/drawable/Drawable;", "GetGetThemeUpIndicatorHandler:AndroidX.AppCompat.App.ActionBarDrawerToggle/IDelegateInvoker, Xamarin.AndroidX.AppCompat")]
			get;
		}

		[Register("setActionBarDescription", "(I)V", "GetSetActionBarDescription_IHandler:AndroidX.AppCompat.App.ActionBarDrawerToggle/IDelegateInvoker, Xamarin.AndroidX.AppCompat")]
		void SetActionBarDescription(int contentDescRes);

		[Register("setActionBarUpIndicator", "(Landroid/graphics/drawable/Drawable;I)V", "GetSetActionBarUpIndicator_Landroid_graphics_drawable_Drawable_IHandler:AndroidX.AppCompat.App.ActionBarDrawerToggle/IDelegateInvoker, Xamarin.AndroidX.AppCompat")]
		void SetActionBarUpIndicator(Drawable? upDrawable, int contentDescRes);
	}

	[Register("androidx/appcompat/app/ActionBarDrawerToggle$Delegate", DoNotGenerateAcw = true)]
	internal class IDelegateInvoker : Java.Lang.Object, IDelegate, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_appcompat_app_ActionBarDrawerToggle_Delegate = new XAPeerMembers("androidx/appcompat/app/ActionBarDrawerToggle$Delegate", typeof(IDelegateInvoker));

		private static Delegate? cb_getActionBarThemedContext_GetActionBarThemedContext_Landroid_content_Context_;

		private static Delegate? cb_isNavigationVisible_IsNavigationVisible_Z;

		private static Delegate? cb_getThemeUpIndicator_GetThemeUpIndicator_Landroid_graphics_drawable_Drawable_;

		private static Delegate? cb_setActionBarDescription_SetActionBarDescription_I_V;

		private static Delegate? cb_setActionBarUpIndicator_SetActionBarUpIndicator_Landroid_graphics_drawable_Drawable_I_V;

		private static nint java_class_ref => _members_androidx_appcompat_app_ActionBarDrawerToggle_Delegate.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_app_ActionBarDrawerToggle_Delegate;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_appcompat_app_ActionBarDrawerToggle_Delegate.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_appcompat_app_ActionBarDrawerToggle_Delegate.ManagedPeerType;

		public unsafe Context? ActionBarThemedContext => Java.Lang.Object.GetObject<Context>(_members_androidx_appcompat_app_ActionBarDrawerToggle_Delegate.InstanceMethods.InvokeAbstractObjectMethod("getActionBarThemedContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

		public unsafe bool IsNavigationVisible => _members_androidx_appcompat_app_ActionBarDrawerToggle_Delegate.InstanceMethods.InvokeAbstractBooleanMethod("isNavigationVisible.()Z", this, null);

		public unsafe Drawable? ThemeUpIndicator => Java.Lang.Object.GetObject<Drawable>(_members_androidx_appcompat_app_ActionBarDrawerToggle_Delegate.InstanceMethods.InvokeAbstractObjectMethod("getThemeUpIndicator.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

		public IDelegateInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetGetActionBarThemedContextHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetActionBarThemedContext);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetActionBarThemedContext(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActionBarThemedContext);
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

		private static Delegate GetIsNavigationVisibleHandler()
		{
			return new global::_JniMarshal_PP_B(n_IsNavigationVisible);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_IsNavigationVisible(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return Java.Lang.Object.GetObject<IDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsNavigationVisible ? ((sbyte)1) : ((sbyte)0);
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

		private static Delegate GetGetThemeUpIndicatorHandler()
		{
			return new global::_JniMarshal_PP_L(n_GetThemeUpIndicator);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_GetThemeUpIndicator(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThemeUpIndicator);
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

		private static Delegate GetSetActionBarDescription_IHandler()
		{
			return new global::_JniMarshal_PPI_V(n_SetActionBarDescription_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetActionBarDescription_I(nint jnienv, nint native__this, int contentDescRes)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				Java.Lang.Object.GetObject<IDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetActionBarDescription(contentDescRes);
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

		public unsafe void SetActionBarDescription(int contentDescRes)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(contentDescRes);
			_members_androidx_appcompat_app_ActionBarDrawerToggle_Delegate.InstanceMethods.InvokeAbstractVoidMethod("setActionBarDescription.(I)V", this, ptr);
		}

		private static Delegate GetSetActionBarUpIndicator_Landroid_graphics_drawable_Drawable_IHandler()
		{
			return new global::_JniMarshal_PPLI_V(n_SetActionBarUpIndicator_Landroid_graphics_drawable_Drawable_I);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_SetActionBarUpIndicator_Landroid_graphics_drawable_Drawable_I(nint jnienv, nint native__this, nint native_upDrawable, int contentDescRes)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				IDelegate? obj = Java.Lang.Object.GetObject<IDelegate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Drawable upDrawable = Java.Lang.Object.GetObject<Drawable>(native_upDrawable, JniHandleOwnership.DoNotTransfer);
				obj.SetActionBarUpIndicator(upDrawable, contentDescRes);
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

		public unsafe void SetActionBarUpIndicator(Drawable? upDrawable, int contentDescRes)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(upDrawable?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(contentDescRes);
				_members_androidx_appcompat_app_ActionBarDrawerToggle_Delegate.InstanceMethods.InvokeAbstractVoidMethod("setActionBarUpIndicator.(Landroid/graphics/drawable/Drawable;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(upDrawable);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/app/ActionBarDrawerToggle", typeof(ActionBarDrawerToggle));

	private static Delegate? cb_getDrawerArrowDrawable_GetDrawerArrowDrawable_Landroidx_appcompat_graphics_drawable_DrawerArrowDrawable_;

	private static Delegate? cb_setDrawerArrowDrawable_SetDrawerArrowDrawable_Landroidx_appcompat_graphics_drawable_DrawerArrowDrawable__V;

	private static Delegate? cb_isDrawerIndicatorEnabled_IsDrawerIndicatorEnabled_Z;

	private static Delegate? cb_setDrawerIndicatorEnabled_SetDrawerIndicatorEnabled_Z_V;

	private static Delegate? cb_isDrawerSlideAnimationEnabled_IsDrawerSlideAnimationEnabled_Z;

	private static Delegate? cb_setDrawerSlideAnimationEnabled_SetDrawerSlideAnimationEnabled_Z_V;

	private static Delegate? cb_getToolbarNavigationClickListener_GetToolbarNavigationClickListener_Landroid_view_View_OnClickListener_;

	private static Delegate? cb_setToolbarNavigationClickListener_SetToolbarNavigationClickListener_Landroid_view_View_OnClickListener__V;

	private static Delegate? cb_onConfigurationChanged_OnConfigurationChanged_Landroid_content_res_Configuration__V;

	private static Delegate? cb_onDrawerClosed_OnDrawerClosed_Landroid_view_View__V;

	private static Delegate? cb_onDrawerOpened_OnDrawerOpened_Landroid_view_View__V;

	private static Delegate? cb_onDrawerSlide_OnDrawerSlide_Landroid_view_View_F_V;

	private static Delegate? cb_onDrawerStateChanged_OnDrawerStateChanged_I_V;

	private static Delegate? cb_onOptionsItemSelected_OnOptionsItemSelected_Landroid_view_MenuItem__Z;

	private static Delegate? cb_setHomeAsUpIndicator_SetHomeAsUpIndicator_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setHomeAsUpIndicator_SetHomeAsUpIndicator_I_V;

	private static Delegate? cb_syncState_SyncState_V;

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

	public unsafe virtual DrawerArrowDrawable DrawerArrowDrawable
	{
		[Register("getDrawerArrowDrawable", "()Landroidx/appcompat/graphics/drawable/DrawerArrowDrawable;", "GetGetDrawerArrowDrawableHandler")]
		get
		{
			return Java.Lang.Object.GetObject<DrawerArrowDrawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDrawerArrowDrawable.()Landroidx/appcompat/graphics/drawable/DrawerArrowDrawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setDrawerArrowDrawable", "(Landroidx/appcompat/graphics/drawable/DrawerArrowDrawable;)V", "GetSetDrawerArrowDrawable_Landroidx_appcompat_graphics_drawable_DrawerArrowDrawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerArrowDrawable.(Landroidx/appcompat/graphics/drawable/DrawerArrowDrawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool DrawerIndicatorEnabled
	{
		[Register("isDrawerIndicatorEnabled", "()Z", "GetIsDrawerIndicatorEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDrawerIndicatorEnabled.()Z", this, null);
		}
		[Register("setDrawerIndicatorEnabled", "(Z)V", "GetSetDrawerIndicatorEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerIndicatorEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool DrawerSlideAnimationEnabled
	{
		[Register("isDrawerSlideAnimationEnabled", "()Z", "GetIsDrawerSlideAnimationEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDrawerSlideAnimationEnabled.()Z", this, null);
		}
		[Register("setDrawerSlideAnimationEnabled", "(Z)V", "GetSetDrawerSlideAnimationEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDrawerSlideAnimationEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual Android.Views.View.IOnClickListener? ToolbarNavigationClickListener
	{
		[Register("getToolbarNavigationClickListener", "()Landroid/view/View$OnClickListener;", "GetGetToolbarNavigationClickListenerHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Views.View.IOnClickListener>(_members.InstanceMethods.InvokeVirtualObjectMethod("getToolbarNavigationClickListener.()Landroid/view/View$OnClickListener;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setToolbarNavigationClickListener", "(Landroid/view/View$OnClickListener;)V", "GetSetToolbarNavigationClickListener_Landroid_view_View_OnClickListener_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setToolbarNavigationClickListener.(Landroid/view/View$OnClickListener;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	protected ActionBarDrawerToggle(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/app/Activity;Landroidx/drawerlayout/widget/DrawerLayout;Landroidx/appcompat/widget/Toolbar;II)V", "")]
	public unsafe ActionBarDrawerToggle(Android.App.Activity? activity, AndroidX.DrawerLayout.Widget.DrawerLayout? drawerLayout, Toolbar? toolbar, int openDrawerContentDescRes, int closeDrawerContentDescRes)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(drawerLayout?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(toolbar?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(openDrawerContentDescRes);
			ptr[4] = new JniArgumentValue(closeDrawerContentDescRes);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Activity;Landroidx/drawerlayout/widget/DrawerLayout;Landroidx/appcompat/widget/Toolbar;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Activity;Landroidx/drawerlayout/widget/DrawerLayout;Landroidx/appcompat/widget/Toolbar;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
			GC.KeepAlive(drawerLayout);
			GC.KeepAlive(toolbar);
		}
	}

	[Register(".ctor", "(Landroid/app/Activity;Landroidx/drawerlayout/widget/DrawerLayout;II)V", "")]
	public unsafe ActionBarDrawerToggle(Android.App.Activity? activity, AndroidX.DrawerLayout.Widget.DrawerLayout? drawerLayout, int openDrawerContentDescRes, int closeDrawerContentDescRes)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(activity?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(drawerLayout?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(openDrawerContentDescRes);
			ptr[3] = new JniArgumentValue(closeDrawerContentDescRes);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/app/Activity;Landroidx/drawerlayout/widget/DrawerLayout;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/app/Activity;Landroidx/drawerlayout/widget/DrawerLayout;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(activity);
			GC.KeepAlive(drawerLayout);
		}
	}

	private static Delegate GetGetDrawerArrowDrawableHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetDrawerArrowDrawable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetDrawerArrowDrawable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawerArrowDrawable);
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

	private static Delegate GetSetDrawerArrowDrawable_Landroidx_appcompat_graphics_drawable_DrawerArrowDrawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetDrawerArrowDrawable_Landroidx_appcompat_graphics_drawable_DrawerArrowDrawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDrawerArrowDrawable_Landroidx_appcompat_graphics_drawable_DrawerArrowDrawable_(nint jnienv, nint native__this, nint native_drawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBarDrawerToggle? actionBarDrawerToggle = Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DrawerArrowDrawable drawerArrowDrawable = Java.Lang.Object.GetObject<DrawerArrowDrawable>(native_drawable, JniHandleOwnership.DoNotTransfer);
			actionBarDrawerToggle.DrawerArrowDrawable = drawerArrowDrawable;
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

	private static Delegate GetIsDrawerIndicatorEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsDrawerIndicatorEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDrawerIndicatorEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawerIndicatorEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetDrawerIndicatorEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetDrawerIndicatorEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDrawerIndicatorEnabled_Z(nint jnienv, nint native__this, sbyte native_enable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBarDrawerToggle? actionBarDrawerToggle = Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool drawerIndicatorEnabled = native_enable != 0;
			actionBarDrawerToggle.DrawerIndicatorEnabled = drawerIndicatorEnabled;
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

	private static Delegate GetIsDrawerSlideAnimationEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsDrawerSlideAnimationEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDrawerSlideAnimationEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DrawerSlideAnimationEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetDrawerSlideAnimationEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetDrawerSlideAnimationEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDrawerSlideAnimationEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBarDrawerToggle? actionBarDrawerToggle = Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool drawerSlideAnimationEnabled = native_enabled != 0;
			actionBarDrawerToggle.DrawerSlideAnimationEnabled = drawerSlideAnimationEnabled;
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

	private static Delegate GetGetToolbarNavigationClickListenerHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetToolbarNavigationClickListener);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetToolbarNavigationClickListener(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToolbarNavigationClickListener);
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

	private static Delegate GetSetToolbarNavigationClickListener_Landroid_view_View_OnClickListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetToolbarNavigationClickListener_Landroid_view_View_OnClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetToolbarNavigationClickListener_Landroid_view_View_OnClickListener_(nint jnienv, nint native__this, nint native_onToolbarNavigationClickListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBarDrawerToggle? actionBarDrawerToggle = Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View.IOnClickListener toolbarNavigationClickListener = Java.Lang.Object.GetObject<Android.Views.View.IOnClickListener>(native_onToolbarNavigationClickListener, JniHandleOwnership.DoNotTransfer);
			actionBarDrawerToggle.ToolbarNavigationClickListener = toolbarNavigationClickListener;
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
			ActionBarDrawerToggle? actionBarDrawerToggle = Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Configuration newConfig = Java.Lang.Object.GetObject<Configuration>(native_newConfig, JniHandleOwnership.DoNotTransfer);
			actionBarDrawerToggle.OnConfigurationChanged(newConfig);
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
	public unsafe virtual void OnConfigurationChanged(Configuration? newConfig)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(newConfig?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onConfigurationChanged.(Landroid/content/res/Configuration;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(newConfig);
		}
	}

	private static Delegate GetOnDrawerClosed_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnDrawerClosed_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDrawerClosed_Landroid_view_View_(nint jnienv, nint native__this, nint native_drawerView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBarDrawerToggle? actionBarDrawerToggle = Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View drawerView = Java.Lang.Object.GetObject<Android.Views.View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			actionBarDrawerToggle.OnDrawerClosed(drawerView);
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

	[Register("onDrawerClosed", "(Landroid/view/View;)V", "GetOnDrawerClosed_Landroid_view_View_Handler")]
	public unsafe virtual void OnDrawerClosed(Android.Views.View? drawerView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDrawerClosed.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawerView);
		}
	}

	private static Delegate GetOnDrawerOpened_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnDrawerOpened_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDrawerOpened_Landroid_view_View_(nint jnienv, nint native__this, nint native_drawerView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBarDrawerToggle? actionBarDrawerToggle = Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View drawerView = Java.Lang.Object.GetObject<Android.Views.View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			actionBarDrawerToggle.OnDrawerOpened(drawerView);
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

	[Register("onDrawerOpened", "(Landroid/view/View;)V", "GetOnDrawerOpened_Landroid_view_View_Handler")]
	public unsafe virtual void OnDrawerOpened(Android.Views.View? drawerView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDrawerOpened.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawerView);
		}
	}

	private static Delegate GetOnDrawerSlide_Landroid_view_View_FHandler()
	{
		return new global::_JniMarshal_PPLF_V(n_OnDrawerSlide_Landroid_view_View_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDrawerSlide_Landroid_view_View_F(nint jnienv, nint native__this, nint native_drawerView, float slideOffset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBarDrawerToggle? actionBarDrawerToggle = Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View drawerView = Java.Lang.Object.GetObject<Android.Views.View>(native_drawerView, JniHandleOwnership.DoNotTransfer);
			actionBarDrawerToggle.OnDrawerSlide(drawerView, slideOffset);
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

	[Register("onDrawerSlide", "(Landroid/view/View;F)V", "GetOnDrawerSlide_Landroid_view_View_FHandler")]
	public unsafe virtual void OnDrawerSlide(Android.Views.View? drawerView, float slideOffset)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(drawerView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(slideOffset);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onDrawerSlide.(Landroid/view/View;F)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawerView);
		}
	}

	private static Delegate GetOnDrawerStateChanged_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_OnDrawerStateChanged_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnDrawerStateChanged_I(nint jnienv, nint native__this, int newState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDrawerStateChanged(newState);
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

	[Register("onDrawerStateChanged", "(I)V", "GetOnDrawerStateChanged_IHandler")]
	public unsafe virtual void OnDrawerStateChanged(int newState)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(newState);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onDrawerStateChanged.(I)V", this, ptr);
	}

	private static Delegate GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_OnOptionsItemSelected_Landroid_view_MenuItem_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnOptionsItemSelected_Landroid_view_MenuItem_(nint jnienv, nint native__this, nint native_item)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ActionBarDrawerToggle? actionBarDrawerToggle = Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
			return actionBarDrawerToggle.OnOptionsItemSelected(item) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onOptionsItemSelected", "(Landroid/view/MenuItem;)Z", "GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler")]
	public unsafe virtual bool OnOptionsItemSelected(IMenuItem? item)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onOptionsItemSelected.(Landroid/view/MenuItem;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(item);
		}
	}

	private static Delegate GetSetHomeAsUpIndicator_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetHomeAsUpIndicator_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHomeAsUpIndicator_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_indicator)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ActionBarDrawerToggle? actionBarDrawerToggle = Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable homeAsUpIndicator = Java.Lang.Object.GetObject<Drawable>(native_indicator, JniHandleOwnership.DoNotTransfer);
			actionBarDrawerToggle.SetHomeAsUpIndicator(homeAsUpIndicator);
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

	[Register("setHomeAsUpIndicator", "(Landroid/graphics/drawable/Drawable;)V", "GetSetHomeAsUpIndicator_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void SetHomeAsUpIndicator(Drawable? indicator)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(indicator?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHomeAsUpIndicator.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(indicator);
		}
	}

	private static Delegate GetSetHomeAsUpIndicator_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHomeAsUpIndicator_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHomeAsUpIndicator_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHomeAsUpIndicator(resId);
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

	[Register("setHomeAsUpIndicator", "(I)V", "GetSetHomeAsUpIndicator_IHandler")]
	public unsafe virtual void SetHomeAsUpIndicator(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHomeAsUpIndicator.(I)V", this, ptr);
	}

	private static Delegate GetSyncStateHandler()
	{
		return new global::_JniMarshal_PP_V(n_SyncState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SyncState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ActionBarDrawerToggle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SyncState();
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

	[Register("syncState", "()V", "GetSyncStateHandler")]
	public unsafe virtual void SyncState()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("syncState.()V", this, null);
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
