using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.AppCompat.View.Menu;
using AndroidX.Core.View;
using AndroidX.Lifecycle;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.Widget;

[Register("androidx/appcompat/widget/Toolbar", DoNotGenerateAcw = true)]
public class Toolbar : ViewGroup, IJavaObject, IDisposable, IJavaPeerable
{
	internal class NavigationOnClickEventDispatcher : Java.Lang.Object, IOnClickListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private Toolbar sender;

		internal EventHandler<NavigationClickEventArgs> NavigationClick;

		public NavigationOnClickEventDispatcher(Toolbar sender)
		{
			this.sender = sender;
		}

		public void OnClick(Android.Views.View v)
		{
			NavigationClick?.Invoke(sender, new NavigationClickEventArgs
			{
				View = v
			});
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

	public class NavigationClickEventArgs : EventArgs
	{
		[CompilerGenerated]
		private Android.Views.View _003CView_003Ek__BackingField;

		internal Android.Views.View View
		{
			[CompilerGenerated]
			set
			{
				_003CView_003Ek__BackingField = value;
			}
		}
	}

	[Register("androidx/appcompat/widget/Toolbar$OnMenuItemClickListener", "", "AndroidX.AppCompat.Widget.Toolbar/IOnMenuItemClickListenerInvoker")]
	public interface IOnMenuItemClickListener : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onMenuItemClick", "(Landroid/view/MenuItem;)Z", "GetOnMenuItemClick_Landroid_view_MenuItem_Handler:AndroidX.AppCompat.Widget.Toolbar/IOnMenuItemClickListenerInvoker, Xamarin.AndroidX.AppCompat")]
		bool OnMenuItemClick(IMenuItem? item);
	}

	[Register("androidx/appcompat/widget/Toolbar$OnMenuItemClickListener", DoNotGenerateAcw = true)]
	internal class IOnMenuItemClickListenerInvoker : Java.Lang.Object, IOnMenuItemClickListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_appcompat_widget_Toolbar_OnMenuItemClickListener = new XAPeerMembers("androidx/appcompat/widget/Toolbar$OnMenuItemClickListener", typeof(IOnMenuItemClickListenerInvoker));

		private static Delegate? cb_onMenuItemClick_OnMenuItemClick_Landroid_view_MenuItem__Z;

		private static nint java_class_ref => _members_androidx_appcompat_widget_Toolbar_OnMenuItemClickListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_widget_Toolbar_OnMenuItemClickListener;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_appcompat_widget_Toolbar_OnMenuItemClickListener.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_appcompat_widget_Toolbar_OnMenuItemClickListener.ManagedPeerType;

		public IOnMenuItemClickListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnMenuItemClick_Landroid_view_MenuItem_(nint jnienv, nint native__this, nint native_item)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				IOnMenuItemClickListener? onMenuItemClickListener = Java.Lang.Object.GetObject<IOnMenuItemClickListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
				return onMenuItemClickListener.OnMenuItemClick(item) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnMenuItemClick(IMenuItem? item)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
				return _members_androidx_appcompat_widget_Toolbar_OnMenuItemClickListener.InstanceMethods.InvokeAbstractBooleanMethod("onMenuItemClick.(Landroid/view/MenuItem;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(item);
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

		[UnmanagedCallersOnly]
		private static sbyte n_OnMenuItemClick_Landroid_view_MenuItem__mm_wrapper(nint jnienv, nint native__this, nint native_item)
		{
			AndroidRuntimeInternal.WaitForBridgeProcessing();
			try
			{
				return n_OnMenuItemClick_Landroid_view_MenuItem_(jnienv, native__this, native_item);
			}
			catch (System.Exception e)
			{
				Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
				return 0;
			}
		}
	}

	public class MenuItemClickEventArgs : EventArgs
	{
		private bool handled;

		private IMenuItem? item;

		public bool Handled => handled;

		public MenuItemClickEventArgs(bool handled, IMenuItem? item)
		{
			this.handled = handled;
			this.item = item;
		}
	}

	[Register("mono/androidx/appcompat/widget/Toolbar_OnMenuItemClickListenerImplementor")]
	internal sealed class IOnMenuItemClickListenerImplementor : Java.Lang.Object, IOnMenuItemClickListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private object? sender;

		public EventHandler<MenuItemClickEventArgs>? Handler;

		public unsafe IOnMenuItemClickListenerImplementor(object sender)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				this.sender = sender;
			}
		}

		public bool OnMenuItemClick(IMenuItem? item)
		{
			EventHandler<MenuItemClickEventArgs> handler = Handler;
			if (handler == null)
			{
				return false;
			}
			MenuItemClickEventArgs e = new MenuItemClickEventArgs(handled: true, item);
			handler(sender, e);
			return e.Handled;
		}

		internal static bool __IsEmpty(IOnMenuItemClickListenerImplementor value)
		{
			return value.Handler == null;
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

	internal WeakReference weakNavigationOnClickDispatcher;

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/widget/Toolbar", typeof(Toolbar));

	private static Delegate? cb_isBackInvokedCallbackEnabled_IsBackInvokedCallbackEnabled_Z;

	private static Delegate? cb_setBackInvokedCallbackEnabled_SetBackInvokedCallbackEnabled_Z_V;

	private static Delegate? cb_getCollapseContentDescription_GetCollapseContentDescription_Ljava_lang_CharSequence_;

	private static Delegate? cb_setCollapseContentDescription_SetCollapseContentDescription_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getCollapseIcon_GetCollapseIcon_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setCollapseIcon_SetCollapseIcon_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getContentInsetEnd_GetContentInsetEnd_I;

	private static Delegate? cb_getContentInsetEndWithActions_GetContentInsetEndWithActions_I;

	private static Delegate? cb_setContentInsetEndWithActions_SetContentInsetEndWithActions_I_V;

	private static Delegate? cb_getContentInsetLeft_GetContentInsetLeft_I;

	private static Delegate? cb_getContentInsetRight_GetContentInsetRight_I;

	private static Delegate? cb_getContentInsetStart_GetContentInsetStart_I;

	private static Delegate? cb_getContentInsetStartWithNavigation_GetContentInsetStartWithNavigation_I;

	private static Delegate? cb_setContentInsetStartWithNavigation_SetContentInsetStartWithNavigation_I_V;

	private static Delegate? cb_getCurrentContentInsetEnd_GetCurrentContentInsetEnd_I;

	private static Delegate? cb_getCurrentContentInsetLeft_GetCurrentContentInsetLeft_I;

	private static Delegate? cb_getCurrentContentInsetRight_GetCurrentContentInsetRight_I;

	private static Delegate? cb_getCurrentContentInsetStart_GetCurrentContentInsetStart_I;

	private static Delegate? cb_hasExpandedActionView_HasExpandedActionView_Z;

	private static Delegate? cb_isOverflowMenuShowPending_IsOverflowMenuShowPending_Z;

	private static Delegate? cb_isOverflowMenuShowing_IsOverflowMenuShowing_Z;

	private static Delegate? cb_isTitleTruncated_IsTitleTruncated_Z;

	private static Delegate? cb_getLogo_GetLogo_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setLogo_SetLogo_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getLogoDescription_GetLogoDescription_Ljava_lang_CharSequence_;

	private static Delegate? cb_setLogoDescription_SetLogoDescription_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getMenu_GetMenu_Landroid_view_Menu_;

	private static Delegate? cb_getNavigationContentDescription_GetNavigationContentDescription_Ljava_lang_CharSequence_;

	private static Delegate? cb_setNavigationContentDescription_SetNavigationContentDescription_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getNavigationIcon_GetNavigationIcon_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setNavigationIcon_SetNavigationIcon_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getOverflowIcon_GetOverflowIcon_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_setOverflowIcon_SetOverflowIcon_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_getPopupTheme_GetPopupTheme_I;

	private static Delegate? cb_setPopupTheme_SetPopupTheme_I_V;

	private static Delegate? cb_getSubtitle_GetSubtitle_Ljava_lang_CharSequence_;

	private static Delegate? cb_setSubtitle_SetSubtitle_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getTitle_GetTitle_Ljava_lang_CharSequence_;

	private static Delegate? cb_setTitle_SetTitle_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getTitleMarginBottom_GetTitleMarginBottom_I;

	private static Delegate? cb_setTitleMarginBottom_SetTitleMarginBottom_I_V;

	private static Delegate? cb_getTitleMarginEnd_GetTitleMarginEnd_I;

	private static Delegate? cb_setTitleMarginEnd_SetTitleMarginEnd_I_V;

	private static Delegate? cb_getTitleMarginStart_GetTitleMarginStart_I;

	private static Delegate? cb_setTitleMarginStart_SetTitleMarginStart_I_V;

	private static Delegate? cb_getTitleMarginTop_GetTitleMarginTop_I;

	private static Delegate? cb_setTitleMarginTop_SetTitleMarginTop_I_V;

	private static Delegate? cb_getWrapper_GetWrapper_Landroidx_appcompat_widget_DecorToolbar_;

	private static Delegate? cb_addMenuProvider_AddMenuProvider_Landroidx_core_view_MenuProvider__V;

	private static Delegate? cb_addMenuProvider_AddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner__V;

	private static Delegate? cb_addMenuProvider_AddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_State__V;

	private static Delegate? cb_canShowOverflowMenu_CanShowOverflowMenu_Z;

	private static Delegate? cb_collapseActionView_CollapseActionView_V;

	private static Delegate? cb_dismissPopupMenus_DismissPopupMenus_V;

	private static Delegate? cb_hideOverflowMenu_HideOverflowMenu_Z;

	private static Delegate? cb_inflateMenu_InflateMenu_I_V;

	private static Delegate? cb_invalidateMenu_InvalidateMenu_V;

	private static Delegate? cb_onLayout_OnLayout_ZIIII_V;

	private static Delegate? cb_removeMenuProvider_RemoveMenuProvider_Landroidx_core_view_MenuProvider__V;

	private static Delegate? cb_setCollapseContentDescription_SetCollapseContentDescription_I_V;

	private static Delegate? cb_setCollapseIcon_SetCollapseIcon_I_V;

	private static Delegate? cb_setCollapsible_SetCollapsible_Z_V;

	private static Delegate? cb_setContentInsetsAbsolute_SetContentInsetsAbsolute_II_V;

	private static Delegate? cb_setContentInsetsRelative_SetContentInsetsRelative_II_V;

	private static Delegate? cb_setLogo_SetLogo_I_V;

	private static Delegate? cb_setLogoDescription_SetLogoDescription_I_V;

	private static Delegate? cb_setMenuCallbacks_SetMenuCallbacks_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Landroidx_appcompat_view_menu_MenuBuilder_Callback__V;

	private static Delegate? cb_setNavigationContentDescription_SetNavigationContentDescription_I_V;

	private static Delegate? cb_setNavigationIcon_SetNavigationIcon_I_V;

	private static Delegate? cb_setNavigationOnClickListener_SetNavigationOnClickListener_Landroid_view_View_OnClickListener__V;

	private static Delegate? cb_setOnMenuItemClickListener_SetOnMenuItemClickListener_Landroidx_appcompat_widget_Toolbar_OnMenuItemClickListener__V;

	private static Delegate? cb_setSubtitle_SetSubtitle_I_V;

	private static Delegate? cb_setSubtitleTextAppearance_SetSubtitleTextAppearance_Landroid_content_Context_I_V;

	private static Delegate? cb_setSubtitleTextColor_SetSubtitleTextColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setSubtitleTextColor_SetSubtitleTextColor_I_V;

	private static Delegate? cb_setTitle_SetTitle_I_V;

	private static Delegate? cb_setTitleMargin_SetTitleMargin_IIII_V;

	private static Delegate? cb_setTitleTextAppearance_SetTitleTextAppearance_Landroid_content_Context_I_V;

	private static Delegate? cb_setTitleTextColor_SetTitleTextColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setTitleTextColor_SetTitleTextColor_I_V;

	private static Delegate? cb_showOverflowMenu_ShowOverflowMenu_Z;

	private WeakReference? weak_implementor_SetOnMenuItemClickListener;

	internal NavigationOnClickEventDispatcher NavigationOnClickDispatcher
	{
		get
		{
			if (weakNavigationOnClickDispatcher == null || !weakNavigationOnClickDispatcher.IsAlive)
			{
				NavigationOnClickEventDispatcher navigationOnClickEventDispatcher = new NavigationOnClickEventDispatcher(this);
				SetNavigationOnClickListener(navigationOnClickEventDispatcher);
				weakNavigationOnClickDispatcher = new WeakReference(navigationOnClickEventDispatcher);
			}
			return (NavigationOnClickEventDispatcher)weakNavigationOnClickDispatcher.Target;
		}
	}

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

	public unsafe virtual bool BackInvokedCallbackEnabled
	{
		[Register("isBackInvokedCallbackEnabled", "()Z", "GetIsBackInvokedCallbackEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isBackInvokedCallbackEnabled.()Z", this, null);
		}
		[Register("setBackInvokedCallbackEnabled", "(Z)V", "GetSetBackInvokedCallbackEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBackInvokedCallbackEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? CollapseContentDescriptionFormatted
	{
		[Register("getCollapseContentDescription", "()Ljava/lang/CharSequence;", "GetGetCollapseContentDescriptionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCollapseContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCollapseContentDescription", "(Ljava/lang/CharSequence;)V", "GetSetCollapseContentDescription_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCollapseContentDescription.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? CollapseContentDescription
	{
		get
		{
			if (CollapseContentDescriptionFormatted != null)
			{
				return CollapseContentDescriptionFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(CollapseContentDescriptionFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual Drawable? CollapseIcon
	{
		[Register("getCollapseIcon", "()Landroid/graphics/drawable/Drawable;", "GetGetCollapseIconHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCollapseIcon.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setCollapseIcon", "(Landroid/graphics/drawable/Drawable;)V", "GetSetCollapseIcon_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setCollapseIcon.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int ContentInsetEnd
	{
		[Register("getContentInsetEnd", "()I", "GetGetContentInsetEndHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContentInsetEnd.()I", this, null);
		}
	}

	public unsafe virtual int ContentInsetEndWithActions
	{
		[Register("getContentInsetEndWithActions", "()I", "GetGetContentInsetEndWithActionsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContentInsetEndWithActions.()I", this, null);
		}
		[Register("setContentInsetEndWithActions", "(I)V", "GetSetContentInsetEndWithActions_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setContentInsetEndWithActions.(I)V", this, ptr);
		}
	}

	public unsafe virtual int ContentInsetLeft
	{
		[Register("getContentInsetLeft", "()I", "GetGetContentInsetLeftHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContentInsetLeft.()I", this, null);
		}
	}

	public unsafe virtual int ContentInsetRight
	{
		[Register("getContentInsetRight", "()I", "GetGetContentInsetRightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContentInsetRight.()I", this, null);
		}
	}

	public unsafe virtual int ContentInsetStart
	{
		[Register("getContentInsetStart", "()I", "GetGetContentInsetStartHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContentInsetStart.()I", this, null);
		}
	}

	public unsafe virtual int ContentInsetStartWithNavigation
	{
		[Register("getContentInsetStartWithNavigation", "()I", "GetGetContentInsetStartWithNavigationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getContentInsetStartWithNavigation.()I", this, null);
		}
		[Register("setContentInsetStartWithNavigation", "(I)V", "GetSetContentInsetStartWithNavigation_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setContentInsetStartWithNavigation.(I)V", this, ptr);
		}
	}

	public unsafe virtual int CurrentContentInsetEnd
	{
		[Register("getCurrentContentInsetEnd", "()I", "GetGetCurrentContentInsetEndHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCurrentContentInsetEnd.()I", this, null);
		}
	}

	public unsafe virtual int CurrentContentInsetLeft
	{
		[Register("getCurrentContentInsetLeft", "()I", "GetGetCurrentContentInsetLeftHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCurrentContentInsetLeft.()I", this, null);
		}
	}

	public unsafe virtual int CurrentContentInsetRight
	{
		[Register("getCurrentContentInsetRight", "()I", "GetGetCurrentContentInsetRightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCurrentContentInsetRight.()I", this, null);
		}
	}

	public unsafe virtual int CurrentContentInsetStart
	{
		[Register("getCurrentContentInsetStart", "()I", "GetGetCurrentContentInsetStartHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCurrentContentInsetStart.()I", this, null);
		}
	}

	public unsafe virtual bool HasExpandedActionView
	{
		[Register("hasExpandedActionView", "()Z", "GetHasExpandedActionViewHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasExpandedActionView.()Z", this, null);
		}
	}

	public unsafe virtual bool IsOverflowMenuShowPending
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isOverflowMenuShowPending", "()Z", "GetIsOverflowMenuShowPendingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isOverflowMenuShowPending.()Z", this, null);
		}
	}

	public unsafe virtual bool IsOverflowMenuShowing
	{
		[Register("isOverflowMenuShowing", "()Z", "GetIsOverflowMenuShowingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isOverflowMenuShowing.()Z", this, null);
		}
	}

	public unsafe virtual bool IsTitleTruncated
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isTitleTruncated", "()Z", "GetIsTitleTruncatedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTitleTruncated.()Z", this, null);
		}
	}

	public unsafe virtual Drawable? Logo
	{
		[Register("getLogo", "()Landroid/graphics/drawable/Drawable;", "GetGetLogoHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLogo.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setLogo", "(Landroid/graphics/drawable/Drawable;)V", "GetSetLogo_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setLogo.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ICharSequence? LogoDescriptionFormatted
	{
		[Register("getLogoDescription", "()Ljava/lang/CharSequence;", "GetGetLogoDescriptionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getLogoDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setLogoDescription", "(Ljava/lang/CharSequence;)V", "GetSetLogoDescription_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setLogoDescription.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? LogoDescription
	{
		get
		{
			if (LogoDescriptionFormatted != null)
			{
				return LogoDescriptionFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(LogoDescriptionFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual IMenu? Menu
	{
		[Register("getMenu", "()Landroid/view/Menu;", "GetGetMenuHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IMenu>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMenu.()Landroid/view/Menu;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ICharSequence? NavigationContentDescriptionFormatted
	{
		[Register("getNavigationContentDescription", "()Ljava/lang/CharSequence;", "GetGetNavigationContentDescriptionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNavigationContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setNavigationContentDescription", "(Ljava/lang/CharSequence;)V", "GetSetNavigationContentDescription_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setNavigationContentDescription.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? NavigationContentDescription
	{
		get
		{
			if (NavigationContentDescriptionFormatted != null)
			{
				return NavigationContentDescriptionFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(NavigationContentDescriptionFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual Drawable? NavigationIcon
	{
		[Register("getNavigationIcon", "()Landroid/graphics/drawable/Drawable;", "GetGetNavigationIconHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNavigationIcon.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setNavigationIcon", "(Landroid/graphics/drawable/Drawable;)V", "GetSetNavigationIcon_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setNavigationIcon.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual Drawable? OverflowIcon
	{
		[Register("getOverflowIcon", "()Landroid/graphics/drawable/Drawable;", "GetGetOverflowIconHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOverflowIcon.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setOverflowIcon", "(Landroid/graphics/drawable/Drawable;)V", "GetSetOverflowIcon_Landroid_graphics_drawable_Drawable_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOverflowIcon.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int PopupTheme
	{
		[Register("getPopupTheme", "()I", "GetGetPopupThemeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getPopupTheme.()I", this, null);
		}
		[Register("setPopupTheme", "(I)V", "GetSetPopupTheme_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPopupTheme.(I)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? SubtitleFormatted
	{
		[Register("getSubtitle", "()Ljava/lang/CharSequence;", "GetGetSubtitleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSubtitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSubtitle", "(Ljava/lang/CharSequence;)V", "GetSetSubtitle_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSubtitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? Subtitle
	{
		get
		{
			if (SubtitleFormatted != null)
			{
				return SubtitleFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(SubtitleFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual ICharSequence? TitleFormatted
	{
		[Register("getTitle", "()Ljava/lang/CharSequence;", "GetGetTitleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTitle", "(Ljava/lang/CharSequence;)V", "GetSetTitle_Ljava_lang_CharSequence_Handler")]
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public string? Title
	{
		get
		{
			if (TitleFormatted != null)
			{
				return TitleFormatted.ToString();
			}
			return null;
		}
		set
		{
			((Java.Lang.Object)(TitleFormatted = ((value == null) ? null : new Java.Lang.String(value))))?.Dispose();
		}
	}

	public unsafe virtual int TitleMarginBottom
	{
		[Register("getTitleMarginBottom", "()I", "GetGetTitleMarginBottomHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTitleMarginBottom.()I", this, null);
		}
		[Register("setTitleMarginBottom", "(I)V", "GetSetTitleMarginBottom_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTitleMarginBottom.(I)V", this, ptr);
		}
	}

	public unsafe virtual int TitleMarginEnd
	{
		[Register("getTitleMarginEnd", "()I", "GetGetTitleMarginEndHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTitleMarginEnd.()I", this, null);
		}
		[Register("setTitleMarginEnd", "(I)V", "GetSetTitleMarginEnd_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTitleMarginEnd.(I)V", this, ptr);
		}
	}

	public unsafe virtual int TitleMarginStart
	{
		[Register("getTitleMarginStart", "()I", "GetGetTitleMarginStartHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTitleMarginStart.()I", this, null);
		}
		[Register("setTitleMarginStart", "(I)V", "GetSetTitleMarginStart_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTitleMarginStart.(I)V", this, ptr);
		}
	}

	public unsafe virtual int TitleMarginTop
	{
		[Register("getTitleMarginTop", "()I", "GetGetTitleMarginTopHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTitleMarginTop.()I", this, null);
		}
		[Register("setTitleMarginTop", "(I)V", "GetSetTitleMarginTop_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTitleMarginTop.(I)V", this, ptr);
		}
	}

	public unsafe virtual IDecorToolbar? Wrapper
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getWrapper", "()Landroidx/appcompat/widget/DecorToolbar;", "GetGetWrapperHandler")]
		get
		{
			return Java.Lang.Object.GetObject<IDecorToolbar>(_members.InstanceMethods.InvokeVirtualObjectMethod("getWrapper.()Landroidx/appcompat/widget/DecorToolbar;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public event EventHandler<NavigationClickEventArgs> NavigationClick
	{
		add
		{
			NavigationOnClickEventDispatcher navigationOnClickDispatcher = NavigationOnClickDispatcher;
			navigationOnClickDispatcher.NavigationClick = (EventHandler<NavigationClickEventArgs>)Delegate.Combine(navigationOnClickDispatcher.NavigationClick, value);
		}
		remove
		{
			NavigationOnClickEventDispatcher navigationOnClickDispatcher = NavigationOnClickDispatcher;
			navigationOnClickDispatcher.NavigationClick = (EventHandler<NavigationClickEventArgs>)Delegate.Remove(navigationOnClickDispatcher.NavigationClick, value);
		}
	}

	public event EventHandler<MenuItemClickEventArgs> MenuItemClick
	{
		add
		{
			EventHelper.AddEventHandler<IOnMenuItemClickListener, IOnMenuItemClickListenerImplementor>(ref weak_implementor_SetOnMenuItemClickListener, __CreateIOnMenuItemClickListenerImplementor, SetOnMenuItemClickListener, delegate(IOnMenuItemClickListenerImplementor __h)
			{
				__h.Handler = (EventHandler<MenuItemClickEventArgs>)Delegate.Combine(__h.Handler, value);
			});
		}
		remove
		{
			EventHelper.RemoveEventHandler<IOnMenuItemClickListener, IOnMenuItemClickListenerImplementor>(ref weak_implementor_SetOnMenuItemClickListener, IOnMenuItemClickListenerImplementor.__IsEmpty, delegate
			{
				SetOnMenuItemClickListener(null);
			}, delegate(IOnMenuItemClickListenerImplementor __h)
			{
				__h.Handler = (EventHandler<MenuItemClickEventArgs>)Delegate.Remove(__h.Handler, value);
			});
		}
	}

	protected Toolbar(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe Toolbar(Context context)
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

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe Toolbar(Context context, IAttributeSet? attrs)
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
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe Toolbar(Context context, IAttributeSet? attrs, int defStyleAttr)
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
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	private static Delegate GetIsBackInvokedCallbackEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsBackInvokedCallbackEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsBackInvokedCallbackEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BackInvokedCallbackEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetBackInvokedCallbackEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetBackInvokedCallbackEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBackInvokedCallbackEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool backInvokedCallbackEnabled = native_enabled != 0;
			toolbar.BackInvokedCallbackEnabled = backInvokedCallbackEnabled;
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

	private static Delegate GetGetCollapseContentDescriptionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCollapseContentDescription);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCollapseContentDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CollapseContentDescriptionFormatted);
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

	private static Delegate GetSetCollapseContentDescription_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCollapseContentDescription_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCollapseContentDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_description)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence collapseContentDescriptionFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_description, JniHandleOwnership.DoNotTransfer);
			toolbar.CollapseContentDescriptionFormatted = collapseContentDescriptionFormatted;
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

	private static Delegate GetGetCollapseIconHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCollapseIcon);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCollapseIcon(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CollapseIcon);
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

	private static Delegate GetSetCollapseIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCollapseIcon_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCollapseIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable collapseIcon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			toolbar.CollapseIcon = collapseIcon;
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

	private static Delegate GetGetContentInsetEndHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetContentInsetEnd);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetContentInsetEnd(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentInsetEnd;
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

	private static Delegate GetGetContentInsetEndWithActionsHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetContentInsetEndWithActions);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetContentInsetEndWithActions(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentInsetEndWithActions;
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

	private static Delegate GetSetContentInsetEndWithActions_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetContentInsetEndWithActions_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentInsetEndWithActions_I(nint jnienv, nint native__this, int insetEndWithActions)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentInsetEndWithActions = insetEndWithActions;
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

	private static Delegate GetGetContentInsetLeftHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetContentInsetLeft);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetContentInsetLeft(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentInsetLeft;
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

	private static Delegate GetGetContentInsetRightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetContentInsetRight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetContentInsetRight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentInsetRight;
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

	private static Delegate GetGetContentInsetStartHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetContentInsetStart);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetContentInsetStart(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentInsetStart;
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

	private static Delegate GetGetContentInsetStartWithNavigationHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetContentInsetStartWithNavigation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetContentInsetStartWithNavigation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentInsetStartWithNavigation;
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

	private static Delegate GetSetContentInsetStartWithNavigation_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetContentInsetStartWithNavigation_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentInsetStartWithNavigation_I(nint jnienv, nint native__this, int insetStartWithNavigation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentInsetStartWithNavigation = insetStartWithNavigation;
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

	private static Delegate GetGetCurrentContentInsetEndHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetCurrentContentInsetEnd);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCurrentContentInsetEnd(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentContentInsetEnd;
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

	private static Delegate GetGetCurrentContentInsetLeftHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetCurrentContentInsetLeft);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCurrentContentInsetLeft(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentContentInsetLeft;
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

	private static Delegate GetGetCurrentContentInsetRightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetCurrentContentInsetRight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCurrentContentInsetRight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentContentInsetRight;
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

	private static Delegate GetGetCurrentContentInsetStartHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetCurrentContentInsetStart);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCurrentContentInsetStart(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentContentInsetStart;
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

	private static Delegate GetHasExpandedActionViewHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasExpandedActionView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasExpandedActionView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasExpandedActionView ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsOverflowMenuShowPendingHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsOverflowMenuShowPending);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsOverflowMenuShowPending(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOverflowMenuShowPending ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsOverflowMenuShowingHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsOverflowMenuShowing);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsOverflowMenuShowing(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOverflowMenuShowing ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsTitleTruncatedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsTitleTruncated);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsTitleTruncated(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsTitleTruncated ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetLogoHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLogo);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLogo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Logo);
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

	private static Delegate GetSetLogo_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetLogo_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLogo_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_drawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable logo = Java.Lang.Object.GetObject<Drawable>(native_drawable, JniHandleOwnership.DoNotTransfer);
			toolbar.Logo = logo;
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

	private static Delegate GetGetLogoDescriptionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetLogoDescription);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLogoDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LogoDescriptionFormatted);
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

	private static Delegate GetSetLogoDescription_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetLogoDescription_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLogoDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_description)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence logoDescriptionFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_description, JniHandleOwnership.DoNotTransfer);
			toolbar.LogoDescriptionFormatted = logoDescriptionFormatted;
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

	private static Delegate GetGetMenuHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Menu);
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

	private static Delegate GetGetNavigationContentDescriptionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetNavigationContentDescription);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetNavigationContentDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NavigationContentDescriptionFormatted);
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

	private static Delegate GetSetNavigationContentDescription_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetNavigationContentDescription_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNavigationContentDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_description)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence navigationContentDescriptionFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_description, JniHandleOwnership.DoNotTransfer);
			toolbar.NavigationContentDescriptionFormatted = navigationContentDescriptionFormatted;
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

	private static Delegate GetGetNavigationIconHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetNavigationIcon);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetNavigationIcon(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NavigationIcon);
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

	private static Delegate GetSetNavigationIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetNavigationIcon_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNavigationIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable navigationIcon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			toolbar.NavigationIcon = navigationIcon;
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

	private static Delegate GetGetOverflowIconHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetOverflowIcon);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetOverflowIcon(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OverflowIcon);
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

	private static Delegate GetSetOverflowIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOverflowIcon_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOverflowIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable overflowIcon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			toolbar.OverflowIcon = overflowIcon;
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

	private static Delegate GetGetPopupThemeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetPopupTheme);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetPopupTheme(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PopupTheme;
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

	private static Delegate GetSetPopupTheme_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetPopupTheme_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPopupTheme_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PopupTheme = resId;
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

	private static Delegate GetGetSubtitleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSubtitle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSubtitle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubtitleFormatted);
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

	private static Delegate GetSetSubtitle_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSubtitle_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSubtitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_subtitle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence subtitleFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_subtitle, JniHandleOwnership.DoNotTransfer);
			toolbar.SubtitleFormatted = subtitleFormatted;
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

	private static Delegate GetGetTitleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTitle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTitle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleFormatted);
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
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence titleFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			toolbar.TitleFormatted = titleFormatted;
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

	private static Delegate GetGetTitleMarginBottomHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTitleMarginBottom);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTitleMarginBottom(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleMarginBottom;
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

	private static Delegate GetSetTitleMarginBottom_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTitleMarginBottom_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitleMarginBottom_I(nint jnienv, nint native__this, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleMarginBottom = margin;
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

	private static Delegate GetGetTitleMarginEndHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTitleMarginEnd);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTitleMarginEnd(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleMarginEnd;
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

	private static Delegate GetSetTitleMarginEnd_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTitleMarginEnd_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitleMarginEnd_I(nint jnienv, nint native__this, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleMarginEnd = margin;
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

	private static Delegate GetGetTitleMarginStartHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTitleMarginStart);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTitleMarginStart(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleMarginStart;
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

	private static Delegate GetSetTitleMarginStart_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTitleMarginStart_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitleMarginStart_I(nint jnienv, nint native__this, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleMarginStart = margin;
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

	private static Delegate GetGetTitleMarginTopHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTitleMarginTop);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTitleMarginTop(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleMarginTop;
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

	private static Delegate GetSetTitleMarginTop_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTitleMarginTop_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitleMarginTop_I(nint jnienv, nint native__this, int margin)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleMarginTop = margin;
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

	private static Delegate GetGetWrapperHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetWrapper);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetWrapper(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Wrapper);
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

	private static Delegate GetAddMenuProvider_Landroidx_core_view_MenuProvider_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddMenuProvider_Landroidx_core_view_MenuProvider_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddMenuProvider_Landroidx_core_view_MenuProvider_(nint jnienv, nint native__this, nint native_provider)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuProvider provider = Java.Lang.Object.GetObject<IMenuProvider>(native_provider, JniHandleOwnership.DoNotTransfer);
			toolbar.AddMenuProvider(provider);
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

	[Register("addMenuProvider", "(Landroidx/core/view/MenuProvider;)V", "GetAddMenuProvider_Landroidx_core_view_MenuProvider_Handler")]
	public unsafe virtual void AddMenuProvider(IMenuProvider provider)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((provider == null) ? IntPtr.Zero : ((Java.Lang.Object)provider).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addMenuProvider.(Landroidx/core/view/MenuProvider;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(provider);
		}
	}

	private static Delegate GetAddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_AddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_(nint jnienv, nint native__this, nint native_provider, nint native_owner)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuProvider provider = Java.Lang.Object.GetObject<IMenuProvider>(native_provider, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner owner = Java.Lang.Object.GetObject<ILifecycleOwner>(native_owner, JniHandleOwnership.DoNotTransfer);
			toolbar.AddMenuProvider(provider, owner);
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

	[Register("addMenuProvider", "(Landroidx/core/view/MenuProvider;Landroidx/lifecycle/LifecycleOwner;)V", "GetAddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_Handler")]
	public unsafe virtual void AddMenuProvider(IMenuProvider provider, ILifecycleOwner owner)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((provider == null) ? IntPtr.Zero : ((Java.Lang.Object)provider).Handle);
			ptr[1] = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addMenuProvider.(Landroidx/core/view/MenuProvider;Landroidx/lifecycle/LifecycleOwner;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(provider);
			GC.KeepAlive(owner);
		}
	}

	private static Delegate GetAddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_State_Handler()
	{
		return new global::_JniMarshal_PPLLL_V(n_AddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_State_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_State_(nint jnienv, nint native__this, nint native_provider, nint native_owner, nint native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuProvider provider = Java.Lang.Object.GetObject<IMenuProvider>(native_provider, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner owner = Java.Lang.Object.GetObject<ILifecycleOwner>(native_owner, JniHandleOwnership.DoNotTransfer);
			AndroidX.Lifecycle.Lifecycle.State state = Java.Lang.Object.GetObject<AndroidX.Lifecycle.Lifecycle.State>(native_state, JniHandleOwnership.DoNotTransfer);
			toolbar.AddMenuProvider(provider, owner, state);
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

	[Register("addMenuProvider", "(Landroidx/core/view/MenuProvider;Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Lifecycle$State;)V", "GetAddMenuProvider_Landroidx_core_view_MenuProvider_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_State_Handler")]
	public unsafe virtual void AddMenuProvider(IMenuProvider provider, ILifecycleOwner owner, AndroidX.Lifecycle.Lifecycle.State state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((provider == null) ? IntPtr.Zero : ((Java.Lang.Object)provider).Handle);
			ptr[1] = new JniArgumentValue((owner == null) ? IntPtr.Zero : ((Java.Lang.Object)owner).Handle);
			ptr[2] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addMenuProvider.(Landroidx/core/view/MenuProvider;Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Lifecycle$State;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(provider);
			GC.KeepAlive(owner);
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetCanShowOverflowMenuHandler()
	{
		return new global::_JniMarshal_PP_B(n_CanShowOverflowMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CanShowOverflowMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanShowOverflowMenu() ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("canShowOverflowMenu", "()Z", "GetCanShowOverflowMenuHandler")]
	public unsafe virtual bool CanShowOverflowMenu()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("canShowOverflowMenu.()Z", this, null);
	}

	private static Delegate GetCollapseActionViewHandler()
	{
		return new global::_JniMarshal_PP_V(n_CollapseActionView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CollapseActionView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CollapseActionView();
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

	[Register("collapseActionView", "()V", "GetCollapseActionViewHandler")]
	public unsafe virtual void CollapseActionView()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("collapseActionView.()V", this, null);
	}

	private static Delegate GetDismissPopupMenusHandler()
	{
		return new global::_JniMarshal_PP_V(n_DismissPopupMenus);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DismissPopupMenus(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DismissPopupMenus();
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

	[Register("dismissPopupMenus", "()V", "GetDismissPopupMenusHandler")]
	public unsafe virtual void DismissPopupMenus()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("dismissPopupMenus.()V", this, null);
	}

	private static Delegate GetHideOverflowMenuHandler()
	{
		return new global::_JniMarshal_PP_B(n_HideOverflowMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HideOverflowMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HideOverflowMenu() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("hideOverflowMenu", "()Z", "GetHideOverflowMenuHandler")]
	public unsafe virtual bool HideOverflowMenu()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("hideOverflowMenu.()Z", this, null);
	}

	private static Delegate GetInflateMenu_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_InflateMenu_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InflateMenu_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InflateMenu(resId);
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

	[Register("inflateMenu", "(I)V", "GetInflateMenu_IHandler")]
	public unsafe virtual void InflateMenu(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("inflateMenu.(I)V", this, ptr);
	}

	private static Delegate GetInvalidateMenuHandler()
	{
		return new global::_JniMarshal_PP_V(n_InvalidateMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InvalidateMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateMenu();
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

	[Register("invalidateMenu", "()V", "GetInvalidateMenuHandler")]
	public unsafe virtual void InvalidateMenu()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateMenu.()V", this, null);
	}

	private static Delegate GetOnLayout_ZIIIIHandler()
	{
		return new global::_JniMarshal_PPBIIII_V(n_OnLayout_ZIIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnLayout_ZIIII(nint jnienv, nint native__this, sbyte native_changed, int l, int t, int r, int b)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool changed = native_changed != 0;
			toolbar.OnLayout(changed, l, t, r, b);
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

	[Register("onLayout", "(ZIIII)V", "GetOnLayout_ZIIIIHandler")]
	protected unsafe override void OnLayout(bool changed, int l, int t, int r, int b)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
		*ptr = new JniArgumentValue(changed ? ((sbyte)1) : ((sbyte)0));
		ptr[1] = new JniArgumentValue(l);
		ptr[2] = new JniArgumentValue(t);
		ptr[3] = new JniArgumentValue(r);
		ptr[4] = new JniArgumentValue(b);
		_members.InstanceMethods.InvokeVirtualVoidMethod("onLayout.(ZIIII)V", this, ptr);
	}

	private static Delegate GetRemoveMenuProvider_Landroidx_core_view_MenuProvider_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveMenuProvider_Landroidx_core_view_MenuProvider_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveMenuProvider_Landroidx_core_view_MenuProvider_(nint jnienv, nint native__this, nint native_provider)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuProvider provider = Java.Lang.Object.GetObject<IMenuProvider>(native_provider, JniHandleOwnership.DoNotTransfer);
			toolbar.RemoveMenuProvider(provider);
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

	[Register("removeMenuProvider", "(Landroidx/core/view/MenuProvider;)V", "GetRemoveMenuProvider_Landroidx_core_view_MenuProvider_Handler")]
	public unsafe virtual void RemoveMenuProvider(IMenuProvider provider)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((provider == null) ? IntPtr.Zero : ((Java.Lang.Object)provider).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeMenuProvider.(Landroidx/core/view/MenuProvider;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(provider);
		}
	}

	private static Delegate GetSetCollapseContentDescription_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCollapseContentDescription_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCollapseContentDescription_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCollapseContentDescription(resId);
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

	[Register("setCollapseContentDescription", "(I)V", "GetSetCollapseContentDescription_IHandler")]
	public unsafe virtual void SetCollapseContentDescription(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCollapseContentDescription.(I)V", this, ptr);
	}

	private static Delegate GetSetCollapseIcon_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCollapseIcon_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCollapseIcon_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCollapseIcon(resId);
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

	[Register("setCollapseIcon", "(I)V", "GetSetCollapseIcon_IHandler")]
	public unsafe virtual void SetCollapseIcon(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCollapseIcon.(I)V", this, ptr);
	}

	private static Delegate GetSetCollapsible_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetCollapsible_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCollapsible_Z(nint jnienv, nint native__this, sbyte native_collapsible)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool collapsible = native_collapsible != 0;
			toolbar.SetCollapsible(collapsible);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("setCollapsible", "(Z)V", "GetSetCollapsible_ZHandler")]
	public unsafe virtual void SetCollapsible(bool collapsible)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(collapsible ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCollapsible.(Z)V", this, ptr);
	}

	private static Delegate GetSetContentInsetsAbsolute_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetContentInsetsAbsolute_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentInsetsAbsolute_II(nint jnienv, nint native__this, int contentInsetLeft, int contentInsetRight)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetContentInsetsAbsolute(contentInsetLeft, contentInsetRight);
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

	[Register("setContentInsetsAbsolute", "(II)V", "GetSetContentInsetsAbsolute_IIHandler")]
	public unsafe virtual void SetContentInsetsAbsolute(int contentInsetLeft, int contentInsetRight)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(contentInsetLeft);
		ptr[1] = new JniArgumentValue(contentInsetRight);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setContentInsetsAbsolute.(II)V", this, ptr);
	}

	private static Delegate GetSetContentInsetsRelative_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_SetContentInsetsRelative_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentInsetsRelative_II(nint jnienv, nint native__this, int contentInsetStart, int contentInsetEnd)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetContentInsetsRelative(contentInsetStart, contentInsetEnd);
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

	[Register("setContentInsetsRelative", "(II)V", "GetSetContentInsetsRelative_IIHandler")]
	public unsafe virtual void SetContentInsetsRelative(int contentInsetStart, int contentInsetEnd)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(contentInsetStart);
		ptr[1] = new JniArgumentValue(contentInsetEnd);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setContentInsetsRelative.(II)V", this, ptr);
	}

	private static Delegate GetSetLogo_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetLogo_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLogo_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLogo(resId);
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

	[Register("setLogo", "(I)V", "GetSetLogo_IHandler")]
	public unsafe virtual void SetLogo(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setLogo.(I)V", this, ptr);
	}

	private static Delegate GetSetLogoDescription_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetLogoDescription_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLogoDescription_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLogoDescription(resId);
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

	[Register("setLogoDescription", "(I)V", "GetSetLogoDescription_IHandler")]
	public unsafe virtual void SetLogoDescription(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setLogoDescription.(I)V", this, ptr);
	}

	private static Delegate GetSetMenuCallbacks_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Landroidx_appcompat_view_menu_MenuBuilder_Callback_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetMenuCallbacks_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Landroidx_appcompat_view_menu_MenuBuilder_Callback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMenuCallbacks_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Landroidx_appcompat_view_menu_MenuBuilder_Callback_(nint jnienv, nint native__this, nint native_pcb, nint native_mcb)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuPresenterCallback pcb = Java.Lang.Object.GetObject<IMenuPresenterCallback>(native_pcb, JniHandleOwnership.DoNotTransfer);
			MenuBuilder.ICallback mcb = Java.Lang.Object.GetObject<MenuBuilder.ICallback>(native_mcb, JniHandleOwnership.DoNotTransfer);
			toolbar.SetMenuCallbacks(pcb, mcb);
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

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("setMenuCallbacks", "(Landroidx/appcompat/view/menu/MenuPresenter$Callback;Landroidx/appcompat/view/menu/MenuBuilder$Callback;)V", "GetSetMenuCallbacks_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Landroidx_appcompat_view_menu_MenuBuilder_Callback_Handler")]
	public unsafe virtual void SetMenuCallbacks(IMenuPresenterCallback? pcb, MenuBuilder.ICallback? mcb)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((pcb == null) ? IntPtr.Zero : ((Java.Lang.Object)pcb).Handle);
			ptr[1] = new JniArgumentValue((mcb == null) ? IntPtr.Zero : ((Java.Lang.Object)mcb).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMenuCallbacks.(Landroidx/appcompat/view/menu/MenuPresenter$Callback;Landroidx/appcompat/view/menu/MenuBuilder$Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(pcb);
			GC.KeepAlive(mcb);
		}
	}

	private static Delegate GetSetNavigationContentDescription_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetNavigationContentDescription_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNavigationContentDescription_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetNavigationContentDescription(resId);
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

	[Register("setNavigationContentDescription", "(I)V", "GetSetNavigationContentDescription_IHandler")]
	public unsafe virtual void SetNavigationContentDescription(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setNavigationContentDescription.(I)V", this, ptr);
	}

	private static Delegate GetSetNavigationIcon_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetNavigationIcon_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNavigationIcon_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetNavigationIcon(resId);
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

	[Register("setNavigationIcon", "(I)V", "GetSetNavigationIcon_IHandler")]
	public unsafe virtual void SetNavigationIcon(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setNavigationIcon.(I)V", this, ptr);
	}

	private static Delegate GetSetNavigationOnClickListener_Landroid_view_View_OnClickListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetNavigationOnClickListener_Landroid_view_View_OnClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNavigationOnClickListener_Landroid_view_View_OnClickListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnClickListener navigationOnClickListener = Java.Lang.Object.GetObject<IOnClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			toolbar.SetNavigationOnClickListener(navigationOnClickListener);
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

	[Register("setNavigationOnClickListener", "(Landroid/view/View$OnClickListener;)V", "GetSetNavigationOnClickListener_Landroid_view_View_OnClickListener_Handler")]
	public unsafe virtual void SetNavigationOnClickListener(IOnClickListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setNavigationOnClickListener.(Landroid/view/View$OnClickListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetOnMenuItemClickListener_Landroidx_appcompat_widget_Toolbar_OnMenuItemClickListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetOnMenuItemClickListener_Landroidx_appcompat_widget_Toolbar_OnMenuItemClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOnMenuItemClickListener_Landroidx_appcompat_widget_Toolbar_OnMenuItemClickListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IOnMenuItemClickListener onMenuItemClickListener = Java.Lang.Object.GetObject<IOnMenuItemClickListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			toolbar.SetOnMenuItemClickListener(onMenuItemClickListener);
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

	[Register("setOnMenuItemClickListener", "(Landroidx/appcompat/widget/Toolbar$OnMenuItemClickListener;)V", "GetSetOnMenuItemClickListener_Landroidx_appcompat_widget_Toolbar_OnMenuItemClickListener_Handler")]
	public unsafe virtual void SetOnMenuItemClickListener(IOnMenuItemClickListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOnMenuItemClickListener.(Landroidx/appcompat/widget/Toolbar$OnMenuItemClickListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetSubtitle_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSubtitle_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSubtitle_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSubtitle(resId);
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

	[Register("setSubtitle", "(I)V", "GetSetSubtitle_IHandler")]
	public unsafe virtual void SetSubtitle(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSubtitle.(I)V", this, ptr);
	}

	private static Delegate GetSetSubtitleTextAppearance_Landroid_content_Context_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetSubtitleTextAppearance_Landroid_content_Context_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSubtitleTextAppearance_Landroid_content_Context_I(nint jnienv, nint native__this, nint native_context, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			toolbar.SetSubtitleTextAppearance(context, resId);
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

	[Register("setSubtitleTextAppearance", "(Landroid/content/Context;I)V", "GetSetSubtitleTextAppearance_Landroid_content_Context_IHandler")]
	public unsafe virtual void SetSubtitleTextAppearance(Context? context, int resId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSubtitleTextAppearance.(Landroid/content/Context;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetSetSubtitleTextColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSubtitleTextColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSubtitleTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList subtitleTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_color, JniHandleOwnership.DoNotTransfer);
			toolbar.SetSubtitleTextColor(subtitleTextColor);
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

	[Register("setSubtitleTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetSubtitleTextColor_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetSubtitleTextColor(ColorStateList color)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSubtitleTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(color);
		}
	}

	private static Delegate GetSetSubtitleTextColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSubtitleTextColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSubtitleTextColor_I(nint jnienv, nint native__this, int color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSubtitleTextColor(color);
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

	[Register("setSubtitleTextColor", "(I)V", "GetSetSubtitleTextColor_IHandler")]
	public unsafe virtual void SetSubtitleTextColor(int color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSubtitleTextColor.(I)V", this, ptr);
	}

	private static Delegate GetSetTitle_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTitle_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitle_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTitle(resId);
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

	[Register("setTitle", "(I)V", "GetSetTitle_IHandler")]
	public unsafe virtual void SetTitle(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTitle.(I)V", this, ptr);
	}

	private static Delegate GetSetTitleMargin_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_V(n_SetTitleMargin_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitleMargin_IIII(nint jnienv, nint native__this, int start, int top, int end, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTitleMargin(start, top, end, bottom);
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

	[Register("setTitleMargin", "(IIII)V", "GetSetTitleMargin_IIIIHandler")]
	public unsafe virtual void SetTitleMargin(int start, int top, int end, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(start);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(end);
		ptr[3] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTitleMargin.(IIII)V", this, ptr);
	}

	private static Delegate GetSetTitleTextAppearance_Landroid_content_Context_IHandler()
	{
		return new global::_JniMarshal_PPLI_V(n_SetTitleTextAppearance_Landroid_content_Context_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitleTextAppearance_Landroid_content_Context_I(nint jnienv, nint native__this, nint native_context, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			toolbar.SetTitleTextAppearance(context, resId);
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

	[Register("setTitleTextAppearance", "(Landroid/content/Context;I)V", "GetSetTitleTextAppearance_Landroid_content_Context_IHandler")]
	public unsafe virtual void SetTitleTextAppearance(Context? context, int resId)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(resId);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTitleTextAppearance.(Landroid/content/Context;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetSetTitleTextColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTitleTextColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitleTextColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Toolbar? toolbar = Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList titleTextColor = Java.Lang.Object.GetObject<ColorStateList>(native_color, JniHandleOwnership.DoNotTransfer);
			toolbar.SetTitleTextColor(titleTextColor);
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

	[Register("setTitleTextColor", "(Landroid/content/res/ColorStateList;)V", "GetSetTitleTextColor_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetTitleTextColor(ColorStateList color)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTitleTextColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(color);
		}
	}

	private static Delegate GetSetTitleTextColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTitleTextColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTitleTextColor_I(nint jnienv, nint native__this, int color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTitleTextColor(color);
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

	[Register("setTitleTextColor", "(I)V", "GetSetTitleTextColor_IHandler")]
	public unsafe virtual void SetTitleTextColor(int color)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(color);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTitleTextColor.(I)V", this, ptr);
	}

	private static Delegate GetShowOverflowMenuHandler()
	{
		return new global::_JniMarshal_PP_B(n_ShowOverflowMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ShowOverflowMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Toolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShowOverflowMenu() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("showOverflowMenu", "()Z", "GetShowOverflowMenuHandler")]
	public unsafe virtual bool ShowOverflowMenu()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("showOverflowMenu.()Z", this, null);
	}

	private IOnMenuItemClickListenerImplementor __CreateIOnMenuItemClickListenerImplementor()
	{
		return new IOnMenuItemClickListenerImplementor(this);
	}
}
