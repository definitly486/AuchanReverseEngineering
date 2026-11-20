using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.View.Menu;
using AndroidX.Core.View;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.Widget;

[Register("androidx/appcompat/widget/DecorToolbar", DoNotGenerateAcw = true)]
internal class IDecorToolbarInvoker : Java.Lang.Object, IDecorToolbar, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_appcompat_widget_DecorToolbar = new XAPeerMembers("androidx/appcompat/widget/DecorToolbar", typeof(IDecorToolbarInvoker));

	private static Delegate? cb_getContext_GetContext_Landroid_content_Context_;

	private static Delegate? cb_getCustomView_GetCustomView_Landroid_view_View_;

	private static Delegate? cb_setCustomView_SetCustomView_Landroid_view_View__V;

	private static Delegate? cb_getDisplayOptions_GetDisplayOptions_I;

	private static Delegate? cb_setDisplayOptions_SetDisplayOptions_I_V;

	private static Delegate? cb_getDropdownItemCount_GetDropdownItemCount_I;

	private static Delegate? cb_getDropdownSelectedPosition_GetDropdownSelectedPosition_I;

	private static Delegate? cb_setDropdownSelectedPosition_SetDropdownSelectedPosition_I_V;

	private static Delegate? cb_hasEmbeddedTabs_HasEmbeddedTabs_Z;

	private static Delegate? cb_hasExpandedActionView_HasExpandedActionView_Z;

	private static Delegate? cb_hasIcon_HasIcon_Z;

	private static Delegate? cb_hasLogo_HasLogo_Z;

	private static Delegate? cb_getHeight_GetHeight_I;

	private static Delegate? cb_isOverflowMenuShowPending_IsOverflowMenuShowPending_Z;

	private static Delegate? cb_isOverflowMenuShowing_IsOverflowMenuShowing_Z;

	private static Delegate? cb_isTitleTruncated_IsTitleTruncated_Z;

	private static Delegate? cb_getMenu_GetMenu_Landroid_view_Menu_;

	private static Delegate? cb_getNavigationMode_GetNavigationMode_I;

	private static Delegate? cb_setNavigationMode_SetNavigationMode_I_V;

	private static Delegate? cb_getSubtitle_GetSubtitle_Ljava_lang_CharSequence_;

	private static Delegate? cb_setSubtitle_SetSubtitle_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getTitle_GetTitle_Ljava_lang_CharSequence_;

	private static Delegate? cb_setTitle_SetTitle_Ljava_lang_CharSequence__V;

	private static Delegate? cb_getViewGroup_GetViewGroup_Landroid_view_ViewGroup_;

	private static Delegate? cb_getVisibility_GetVisibility_I;

	private static Delegate? cb_setVisibility_SetVisibility_I_V;

	private static Delegate? cb_animateToVisibility_AnimateToVisibility_I_V;

	private static Delegate? cb_canShowOverflowMenu_CanShowOverflowMenu_Z;

	private static Delegate? cb_collapseActionView_CollapseActionView_V;

	private static Delegate? cb_dismissPopupMenus_DismissPopupMenus_V;

	private static Delegate? cb_hideOverflowMenu_HideOverflowMenu_Z;

	private static Delegate? cb_initIndeterminateProgress_InitIndeterminateProgress_V;

	private static Delegate? cb_initProgress_InitProgress_V;

	private static Delegate? cb_restoreHierarchyState_RestoreHierarchyState_Landroid_util_SparseArray__V;

	private static Delegate? cb_saveHierarchyState_SaveHierarchyState_Landroid_util_SparseArray__V;

	private static Delegate? cb_setBackgroundDrawable_SetBackgroundDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setCollapsible_SetCollapsible_Z_V;

	private static Delegate? cb_setDefaultNavigationContentDescription_SetDefaultNavigationContentDescription_I_V;

	private static Delegate? cb_setDefaultNavigationIcon_SetDefaultNavigationIcon_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setDropdownParams_SetDropdownParams_Landroid_widget_SpinnerAdapter_Landroid_widget_AdapterView_OnItemSelectedListener__V;

	private static Delegate? cb_setEmbeddedTabView_SetEmbeddedTabView_Landroidx_appcompat_widget_ScrollingTabContainerView__V;

	private static Delegate? cb_setHomeButtonEnabled_SetHomeButtonEnabled_Z_V;

	private static Delegate? cb_setIcon_SetIcon_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setIcon_SetIcon_I_V;

	private static Delegate? cb_setLogo_SetLogo_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setLogo_SetLogo_I_V;

	private static Delegate? cb_setMenu_SetMenu_Landroid_view_Menu_Landroidx_appcompat_view_menu_MenuPresenter_Callback__V;

	private static Delegate? cb_setMenuCallbacks_SetMenuCallbacks_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Landroidx_appcompat_view_menu_MenuBuilder_Callback__V;

	private static Delegate? cb_setMenuPrepared_SetMenuPrepared_V;

	private static Delegate? cb_setNavigationContentDescription_SetNavigationContentDescription_I_V;

	private static Delegate? cb_setNavigationContentDescription_SetNavigationContentDescription_Ljava_lang_CharSequence__V;

	private static Delegate? cb_setNavigationIcon_SetNavigationIcon_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setNavigationIcon_SetNavigationIcon_I_V;

	private static Delegate? cb_setWindowCallback_SetWindowCallback_Landroid_view_Window_Callback__V;

	private static Delegate? cb_setWindowTitle_SetWindowTitle_Ljava_lang_CharSequence__V;

	private static Delegate? cb_setupAnimatorToVisibility_SetupAnimatorToVisibility_IJ_Landroidx_core_view_ViewPropertyAnimatorCompat_;

	private static Delegate? cb_showOverflowMenu_ShowOverflowMenu_Z;

	private static nint java_class_ref => _members_androidx_appcompat_widget_DecorToolbar.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_widget_DecorToolbar;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_appcompat_widget_DecorToolbar.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_appcompat_widget_DecorToolbar.ManagedPeerType;

	public unsafe Context? Context => Java.Lang.Object.GetObject<Context>(_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe Android.Views.View? CustomView
	{
		get
		{
			return Java.Lang.Object.GetObject<Android.Views.View>(_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractObjectMethod("getCustomView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setCustomView.(Landroid/view/View;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe int DisplayOptions
	{
		get
		{
			return _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractInt32Method("getDisplayOptions.()I", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setDisplayOptions.(I)V", this, ptr);
		}
	}

	public unsafe int DropdownItemCount => _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractInt32Method("getDropdownItemCount.()I", this, null);

	public unsafe int DropdownSelectedPosition
	{
		get
		{
			return _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractInt32Method("getDropdownSelectedPosition.()I", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setDropdownSelectedPosition.(I)V", this, ptr);
		}
	}

	public unsafe bool HasEmbeddedTabs => _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractBooleanMethod("hasEmbeddedTabs.()Z", this, null);

	public unsafe bool HasExpandedActionView => _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractBooleanMethod("hasExpandedActionView.()Z", this, null);

	public unsafe bool HasIcon => _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractBooleanMethod("hasIcon.()Z", this, null);

	public unsafe bool HasLogo => _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractBooleanMethod("hasLogo.()Z", this, null);

	public unsafe int Height => _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractInt32Method("getHeight.()I", this, null);

	public unsafe bool IsOverflowMenuShowPending => _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractBooleanMethod("isOverflowMenuShowPending.()Z", this, null);

	public unsafe bool IsOverflowMenuShowing => _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractBooleanMethod("isOverflowMenuShowing.()Z", this, null);

	public unsafe bool IsTitleTruncated => _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractBooleanMethod("isTitleTruncated.()Z", this, null);

	public unsafe IMenu? Menu => Java.Lang.Object.GetObject<IMenu>(_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractObjectMethod("getMenu.()Landroid/view/Menu;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe int NavigationMode
	{
		get
		{
			return _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractInt32Method("getNavigationMode.()I", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setNavigationMode.(I)V", this, ptr);
		}
	}

	public unsafe ICharSequence? SubtitleFormatted
	{
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractObjectMethod("getSubtitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setSubtitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe ICharSequence? TitleFormatted
	{
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractObjectMethod("getTitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			nint num = CharSequence.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setTitle.(Ljava/lang/CharSequence;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe ViewGroup? ViewGroup => Java.Lang.Object.GetObject<ViewGroup>(_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractObjectMethod("getViewGroup.()Landroid/view/ViewGroup;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe int Visibility
	{
		get
		{
			return _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractInt32Method("getVisibility.()I", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setVisibility.(I)V", this, ptr);
		}
	}

	public IDecorToolbarInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetContextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetContext);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContext(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
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

	private static Delegate GetGetCustomViewHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCustomView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCustomView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CustomView);
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

	private static Delegate GetSetCustomView_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCustomView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomView_Landroid_view_View_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View customView = Java.Lang.Object.GetObject<Android.Views.View>(native_p0, JniHandleOwnership.DoNotTransfer);
			decorToolbar.CustomView = customView;
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

	private static Delegate GetGetDisplayOptionsHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDisplayOptions);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDisplayOptions(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisplayOptions;
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

	private static Delegate GetSetDisplayOptions_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetDisplayOptions_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDisplayOptions_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisplayOptions = p0;
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

	private static Delegate GetGetDropdownItemCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDropdownItemCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDropdownItemCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DropdownItemCount;
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

	private static Delegate GetGetDropdownSelectedPositionHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetDropdownSelectedPosition);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetDropdownSelectedPosition(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DropdownSelectedPosition;
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

	private static Delegate GetSetDropdownSelectedPosition_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetDropdownSelectedPosition_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDropdownSelectedPosition_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DropdownSelectedPosition = p0;
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

	private static Delegate GetHasEmbeddedTabsHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasEmbeddedTabs);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasEmbeddedTabs(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasEmbeddedTabs ? ((sbyte)1) : ((sbyte)0);
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
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasExpandedActionView ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetHasIconHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasIcon);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasIcon(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasIcon ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetHasLogoHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasLogo);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasLogo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasLogo ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height;
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
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOverflowMenuShowPending ? ((sbyte)1) : ((sbyte)0);
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
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOverflowMenuShowing ? ((sbyte)1) : ((sbyte)0);
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
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsTitleTruncated ? ((sbyte)1) : ((sbyte)0);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Menu);
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

	private static Delegate GetGetNavigationModeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetNavigationMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetNavigationMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NavigationMode;
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

	private static Delegate GetSetNavigationMode_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetNavigationMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNavigationMode_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NavigationMode = p0;
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
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubtitleFormatted);
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
	private static void n_SetSubtitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence subtitleFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_p0, JniHandleOwnership.DoNotTransfer);
			decorToolbar.SubtitleFormatted = subtitleFormatted;
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
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleFormatted);
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
	private static void n_SetTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence titleFormatted = Java.Lang.Object.GetObject<ICharSequence>(native_p0, JniHandleOwnership.DoNotTransfer);
			decorToolbar.TitleFormatted = titleFormatted;
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

	private static Delegate GetGetViewGroupHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetViewGroup);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetViewGroup(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ViewGroup);
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

	private static Delegate GetGetVisibilityHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetVisibility);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetVisibility(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visibility;
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

	private static Delegate GetSetVisibility_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetVisibility_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVisibility_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visibility = p0;
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

	private static Delegate GetAnimateToVisibility_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_AnimateToVisibility_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AnimateToVisibility_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnimateToVisibility(p0);
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

	public unsafe void AnimateToVisibility(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("animateToVisibility.(I)V", this, ptr);
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
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CanShowOverflowMenu() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool CanShowOverflowMenu()
	{
		return _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractBooleanMethod("canShowOverflowMenu.()Z", this, null);
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
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CollapseActionView();
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

	public unsafe void CollapseActionView()
	{
		_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("collapseActionView.()V", this, null);
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
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DismissPopupMenus();
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

	public unsafe void DismissPopupMenus()
	{
		_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("dismissPopupMenus.()V", this, null);
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
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HideOverflowMenu() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool HideOverflowMenu()
	{
		return _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractBooleanMethod("hideOverflowMenu.()Z", this, null);
	}

	private static Delegate GetInitIndeterminateProgressHandler()
	{
		return new global::_JniMarshal_PP_V(n_InitIndeterminateProgress);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InitIndeterminateProgress(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InitIndeterminateProgress();
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

	public unsafe void InitIndeterminateProgress()
	{
		_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("initIndeterminateProgress.()V", this, null);
	}

	private static Delegate GetInitProgressHandler()
	{
		return new global::_JniMarshal_PP_V(n_InitProgress);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InitProgress(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InitProgress();
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

	public unsafe void InitProgress()
	{
		_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("initProgress.()V", this, null);
	}

	private static Delegate GetRestoreHierarchyState_Landroid_util_SparseArray_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RestoreHierarchyState_Landroid_util_SparseArray_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RestoreHierarchyState_Landroid_util_SparseArray_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SparseArray p = Java.Lang.Object.GetObject<SparseArray>(native_p0, JniHandleOwnership.DoNotTransfer);
			decorToolbar.RestoreHierarchyState(p);
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

	public unsafe void RestoreHierarchyState(SparseArray? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("restoreHierarchyState.(Landroid/util/SparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSaveHierarchyState_Landroid_util_SparseArray_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SaveHierarchyState_Landroid_util_SparseArray_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SaveHierarchyState_Landroid_util_SparseArray_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SparseArray p = Java.Lang.Object.GetObject<SparseArray>(native_p0, JniHandleOwnership.DoNotTransfer);
			decorToolbar.SaveHierarchyState(p);
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

	public unsafe void SaveHierarchyState(SparseArray? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("saveHierarchyState.(Landroid/util/SparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetBackgroundDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetBackgroundDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBackgroundDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable backgroundDrawable = Java.Lang.Object.GetObject<Drawable>(native_p0, JniHandleOwnership.DoNotTransfer);
			decorToolbar.SetBackgroundDrawable(backgroundDrawable);
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

	public unsafe void SetBackgroundDrawable(Drawable? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setBackgroundDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetCollapsible_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetCollapsible_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCollapsible_Z(nint jnienv, nint native__this, sbyte native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool collapsible = native_p0 != 0;
			decorToolbar.SetCollapsible(collapsible);
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

	public unsafe void SetCollapsible(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0 ? ((sbyte)1) : ((sbyte)0));
		_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setCollapsible.(Z)V", this, ptr);
	}

	private static Delegate GetSetDefaultNavigationContentDescription_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetDefaultNavigationContentDescription_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDefaultNavigationContentDescription_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDefaultNavigationContentDescription(p0);
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

	public unsafe void SetDefaultNavigationContentDescription(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setDefaultNavigationContentDescription.(I)V", this, ptr);
	}

	private static Delegate GetSetDefaultNavigationIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetDefaultNavigationIcon_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDefaultNavigationIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable defaultNavigationIcon = Java.Lang.Object.GetObject<Drawable>(native_p0, JniHandleOwnership.DoNotTransfer);
			decorToolbar.SetDefaultNavigationIcon(defaultNavigationIcon);
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

	public unsafe void SetDefaultNavigationIcon(Drawable? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setDefaultNavigationIcon.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetDropdownParams_Landroid_widget_SpinnerAdapter_Landroid_widget_AdapterView_OnItemSelectedListener_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetDropdownParams_Landroid_widget_SpinnerAdapter_Landroid_widget_AdapterView_OnItemSelectedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetDropdownParams_Landroid_widget_SpinnerAdapter_Landroid_widget_AdapterView_OnItemSelectedListener_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISpinnerAdapter p = Java.Lang.Object.GetObject<ISpinnerAdapter>(native_p0, JniHandleOwnership.DoNotTransfer);
			AdapterView.IOnItemSelectedListener p2 = Java.Lang.Object.GetObject<AdapterView.IOnItemSelectedListener>(native_p1, JniHandleOwnership.DoNotTransfer);
			decorToolbar.SetDropdownParams(p, p2);
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

	public unsafe void SetDropdownParams(ISpinnerAdapter? p0, AdapterView.IOnItemSelectedListener? p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setDropdownParams.(Landroid/widget/SpinnerAdapter;Landroid/widget/AdapterView$OnItemSelectedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetEmbeddedTabView_Landroidx_appcompat_widget_ScrollingTabContainerView_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetEmbeddedTabView_Landroidx_appcompat_widget_ScrollingTabContainerView_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEmbeddedTabView_Landroidx_appcompat_widget_ScrollingTabContainerView_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ScrollingTabContainerView embeddedTabView = Java.Lang.Object.GetObject<ScrollingTabContainerView>(native_p0, JniHandleOwnership.DoNotTransfer);
			decorToolbar.SetEmbeddedTabView(embeddedTabView);
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

	public unsafe void SetEmbeddedTabView(ScrollingTabContainerView? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setEmbeddedTabView.(Landroidx/appcompat/widget/ScrollingTabContainerView;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetHomeButtonEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetHomeButtonEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHomeButtonEnabled_Z(nint jnienv, nint native__this, sbyte native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool homeButtonEnabled = native_p0 != 0;
			decorToolbar.SetHomeButtonEnabled(homeButtonEnabled);
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

	public unsafe void SetHomeButtonEnabled(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0 ? ((sbyte)1) : ((sbyte)0));
		_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setHomeButtonEnabled.(Z)V", this, ptr);
	}

	private static Delegate GetSetIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetIcon_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable icon = Java.Lang.Object.GetObject<Drawable>(native_p0, JniHandleOwnership.DoNotTransfer);
			decorToolbar.SetIcon(icon);
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

	public unsafe void SetIcon(Drawable? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setIcon.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetIcon_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetIcon_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetIcon_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIcon(p0);
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

	public unsafe void SetIcon(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setIcon.(I)V", this, ptr);
	}

	private static Delegate GetSetLogo_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetLogo_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLogo_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable logo = Java.Lang.Object.GetObject<Drawable>(native_p0, JniHandleOwnership.DoNotTransfer);
			decorToolbar.SetLogo(logo);
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

	public unsafe void SetLogo(Drawable? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setLogo.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetLogo_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetLogo_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLogo_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLogo(p0);
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

	public unsafe void SetLogo(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setLogo.(I)V", this, ptr);
	}

	private static Delegate GetSetMenu_Landroid_view_Menu_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetMenu_Landroid_view_Menu_Landroidx_appcompat_view_menu_MenuPresenter_Callback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMenu_Landroid_view_Menu_Landroidx_appcompat_view_menu_MenuPresenter_Callback_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenu p = Java.Lang.Object.GetObject<IMenu>(native_p0, JniHandleOwnership.DoNotTransfer);
			IMenuPresenterCallback p2 = Java.Lang.Object.GetObject<IMenuPresenterCallback>(native_p1, JniHandleOwnership.DoNotTransfer);
			decorToolbar.SetMenu(p, p2);
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

	public unsafe void SetMenu(IMenu? p0, IMenuPresenterCallback? p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setMenu.(Landroid/view/Menu;Landroidx/appcompat/view/menu/MenuPresenter$Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetMenuCallbacks_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Landroidx_appcompat_view_menu_MenuBuilder_Callback_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_SetMenuCallbacks_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Landroidx_appcompat_view_menu_MenuBuilder_Callback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMenuCallbacks_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Landroidx_appcompat_view_menu_MenuBuilder_Callback_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuPresenterCallback p = Java.Lang.Object.GetObject<IMenuPresenterCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			MenuBuilder.ICallback p2 = Java.Lang.Object.GetObject<MenuBuilder.ICallback>(native_p1, JniHandleOwnership.DoNotTransfer);
			decorToolbar.SetMenuCallbacks(p, p2);
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

	public unsafe void SetMenuCallbacks(IMenuPresenterCallback? p0, MenuBuilder.ICallback? p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setMenuCallbacks.(Landroidx/appcompat/view/menu/MenuPresenter$Callback;Landroidx/appcompat/view/menu/MenuBuilder$Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetMenuPreparedHandler()
	{
		return new global::_JniMarshal_PP_V(n_SetMenuPrepared);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMenuPrepared(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMenuPrepared();
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

	public unsafe void SetMenuPrepared()
	{
		_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setMenuPrepared.()V", this, null);
	}

	private static Delegate GetSetNavigationContentDescription_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetNavigationContentDescription_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNavigationContentDescription_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetNavigationContentDescription(p0);
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

	public unsafe void SetNavigationContentDescription(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setNavigationContentDescription.(I)V", this, ptr);
	}

	private static Delegate GetSetNavigationContentDescription_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetNavigationContentDescription_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNavigationContentDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence navigationContentDescription = Java.Lang.Object.GetObject<ICharSequence>(native_p0, JniHandleOwnership.DoNotTransfer);
			decorToolbar.SetNavigationContentDescription(navigationContentDescription);
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

	public unsafe void SetNavigationContentDescription(ICharSequence? p0)
	{
		nint num = CharSequence.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setNavigationContentDescription.(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetNavigationIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetNavigationIcon_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNavigationIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable navigationIcon = Java.Lang.Object.GetObject<Drawable>(native_p0, JniHandleOwnership.DoNotTransfer);
			decorToolbar.SetNavigationIcon(navigationIcon);
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

	public unsafe void SetNavigationIcon(Drawable? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setNavigationIcon.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetNavigationIcon_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetNavigationIcon_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNavigationIcon_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetNavigationIcon(p0);
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

	public unsafe void SetNavigationIcon(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setNavigationIcon.(I)V", this, ptr);
	}

	private static Delegate GetSetWindowCallback_Landroid_view_Window_Callback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetWindowCallback_Landroid_view_Window_Callback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetWindowCallback_Landroid_view_Window_Callback_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Window.ICallback windowCallback = Java.Lang.Object.GetObject<Window.ICallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			decorToolbar.SetWindowCallback(windowCallback);
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

	public unsafe void SetWindowCallback(Window.ICallback? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setWindowCallback.(Landroid/view/Window$Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetWindowTitle_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetWindowTitle_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetWindowTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IDecorToolbar? decorToolbar = Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence windowTitle = Java.Lang.Object.GetObject<ICharSequence>(native_p0, JniHandleOwnership.DoNotTransfer);
			decorToolbar.SetWindowTitle(windowTitle);
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

	public unsafe void SetWindowTitle(ICharSequence? p0)
	{
		nint num = CharSequence.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractVoidMethod("setWindowTitle.(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetupAnimatorToVisibility_IJHandler()
	{
		return new _JniMarshal_PPIJ_L(n_SetupAnimatorToVisibility_IJ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetupAnimatorToVisibility_IJ(nint jnienv, nint native__this, int p0, long p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetupAnimatorToVisibility(p0, p1));
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

	public unsafe ViewPropertyAnimatorCompat? SetupAnimatorToVisibility(int p0, long p1)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(p0);
		ptr[1] = new JniArgumentValue(p1);
		return Java.Lang.Object.GetObject<ViewPropertyAnimatorCompat>(_members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractObjectMethod("setupAnimatorToVisibility.(IJ)Landroidx/core/view/ViewPropertyAnimatorCompat;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			return Java.Lang.Object.GetObject<IDecorToolbar>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShowOverflowMenu() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool ShowOverflowMenu()
	{
		return _members_androidx_appcompat_widget_DecorToolbar.InstanceMethods.InvokeAbstractBooleanMethod("showOverflowMenu.()Z", this, null);
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
