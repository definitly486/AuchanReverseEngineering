using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.View.Menu;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("androidx/appcompat/view/menu/MenuBuilder", DoNotGenerateAcw = true)]
public class MenuBuilder : Java.Lang.Object, IMenu, IJavaObject, IDisposable, IJavaPeerable
{
	[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("androidx/appcompat/view/menu/MenuBuilder$Callback", "", "AndroidX.AppCompat.View.Menu.MenuBuilder/ICallbackInvoker")]
	public interface ICallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onMenuItemSelected", "(Landroidx/appcompat/view/menu/MenuBuilder;Landroid/view/MenuItem;)Z", "GetOnMenuItemSelected_Landroidx_appcompat_view_menu_MenuBuilder_Landroid_view_MenuItem_Handler:AndroidX.AppCompat.View.Menu.MenuBuilder/ICallbackInvoker, Xamarin.AndroidX.AppCompat")]
		bool OnMenuItemSelected(MenuBuilder p0, IMenuItem p1);

		[Register("onMenuModeChange", "(Landroidx/appcompat/view/menu/MenuBuilder;)V", "GetOnMenuModeChange_Landroidx_appcompat_view_menu_MenuBuilder_Handler:AndroidX.AppCompat.View.Menu.MenuBuilder/ICallbackInvoker, Xamarin.AndroidX.AppCompat")]
		void OnMenuModeChange(MenuBuilder p0);
	}

	[Register("androidx/appcompat/view/menu/MenuBuilder$Callback", DoNotGenerateAcw = true)]
	internal class ICallbackInvoker : Java.Lang.Object, ICallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_androidx_appcompat_view_menu_MenuBuilder_Callback = new XAPeerMembers("androidx/appcompat/view/menu/MenuBuilder$Callback", typeof(ICallbackInvoker));

		private static Delegate? cb_onMenuItemSelected_OnMenuItemSelected_Landroidx_appcompat_view_menu_MenuBuilder_Landroid_view_MenuItem__Z;

		private static Delegate? cb_onMenuModeChange_OnMenuModeChange_Landroidx_appcompat_view_menu_MenuBuilder__V;

		private static nint java_class_ref => _members_androidx_appcompat_view_menu_MenuBuilder_Callback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_view_menu_MenuBuilder_Callback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_androidx_appcompat_view_menu_MenuBuilder_Callback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_androidx_appcompat_view_menu_MenuBuilder_Callback.ManagedPeerType;

		public ICallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnMenuItemSelected_Landroidx_appcompat_view_menu_MenuBuilder_Landroid_view_MenuItem_Handler()
		{
			return new global::_JniMarshal_PPLL_B(n_OnMenuItemSelected_Landroidx_appcompat_view_menu_MenuBuilder_Landroid_view_MenuItem_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static sbyte n_OnMenuItemSelected_Landroidx_appcompat_view_menu_MenuBuilder_Landroid_view_MenuItem_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MenuBuilder p = Java.Lang.Object.GetObject<MenuBuilder>(native_p0, JniHandleOwnership.DoNotTransfer);
				IMenuItem p2 = Java.Lang.Object.GetObject<IMenuItem>(native_p1, JniHandleOwnership.DoNotTransfer);
				return callback.OnMenuItemSelected(p, p2) ? ((sbyte)1) : ((sbyte)0);
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

		public unsafe bool OnMenuItemSelected(MenuBuilder p0, IMenuItem p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				return _members_androidx_appcompat_view_menu_MenuBuilder_Callback.InstanceMethods.InvokeAbstractBooleanMethod("onMenuItemSelected.(Landroidx/appcompat/view/menu/MenuBuilder;Landroid/view/MenuItem;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetOnMenuModeChange_Landroidx_appcompat_view_menu_MenuBuilder_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnMenuModeChange_Landroidx_appcompat_view_menu_MenuBuilder_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnMenuModeChange_Landroidx_appcompat_view_menu_MenuBuilder_(nint jnienv, nint native__this, nint native_p0)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				ICallback? callback = Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				MenuBuilder p = Java.Lang.Object.GetObject<MenuBuilder>(native_p0, JniHandleOwnership.DoNotTransfer);
				callback.OnMenuModeChange(p);
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

		public unsafe void OnMenuModeChange(MenuBuilder p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members_androidx_appcompat_view_menu_MenuBuilder_Callback.InstanceMethods.InvokeAbstractVoidMethod("onMenuModeChange.(Landroidx/appcompat/view/menu/MenuBuilder;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(p0);
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/appcompat/view/menu/MenuBuilder", typeof(MenuBuilder));

	private static Delegate? cb_getActionItems_GetActionItems_Ljava_util_ArrayList_;

	private static Delegate? cb_getActionViewStatesKey_GetActionViewStatesKey_Ljava_lang_String_;

	private static Delegate? cb_getContext_GetContext_Landroid_content_Context_;

	private static Delegate? cb_getExpandedItem_GetExpandedItem_Landroidx_appcompat_view_menu_MenuItemImpl_;

	private static Delegate? cb_isGroupDividerEnabled_IsGroupDividerEnabled_Z;

	private static Delegate? cb_setGroupDividerEnabled_SetGroupDividerEnabled_Z_V;

	private static Delegate? cb_hasVisibleItems_HasVisibleItems_Z;

	private static Delegate? cb_getHeaderIcon_GetHeaderIcon_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_getHeaderTitle_GetHeaderTitle_Ljava_lang_CharSequence_;

	private static Delegate? cb_getHeaderView_GetHeaderView_Landroid_view_View_;

	private static Delegate? cb_isDispatchingItemsChanged_IsDispatchingItemsChanged_Z;

	private static Delegate? cb_getNonActionItems_GetNonActionItems_Ljava_util_ArrayList_;

	private static Delegate? cb_getRootMenu_GetRootMenu_Landroidx_appcompat_view_menu_MenuBuilder_;

	private static Delegate? cb_isShortcutsVisible_IsShortcutsVisible_Z;

	private static Delegate? cb_setShortcutsVisible_SetShortcutsVisible_Z_V;

	private static Delegate? cb_getVisibleItems_GetVisibleItems_Ljava_util_ArrayList_;

	private static Delegate? cb_add_Add_I_Landroid_view_MenuItem_;

	private static Delegate? cb_add_Add_IIII_Landroid_view_MenuItem_;

	private static Delegate? cb_add_Add_IIILjava_lang_CharSequence__Landroid_view_MenuItem_;

	private static Delegate? cb_add_Add_Ljava_lang_CharSequence__Landroid_view_MenuItem_;

	private static Delegate? cb_addIntentOptions_AddIntentOptions_IIILandroid_content_ComponentName_arrayLandroid_content_Intent_Landroid_content_Intent_IarrayLandroid_view_MenuItem__I;

	private static Delegate? cb_addInternal_AddInternal_IIILjava_lang_CharSequence__Landroid_view_MenuItem_;

	private static Delegate? cb_addMenuPresenter_AddMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter__V;

	private static Delegate? cb_addMenuPresenter_AddMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter_Landroid_content_Context__V;

	private static Delegate? cb_addSubMenu_AddSubMenu_I_Landroid_view_SubMenu_;

	private static Delegate? cb_addSubMenu_AddSubMenu_IIII_Landroid_view_SubMenu_;

	private static Delegate? cb_addSubMenu_AddSubMenu_IIILjava_lang_CharSequence__Landroid_view_SubMenu_;

	private static Delegate? cb_addSubMenu_AddSubMenu_Ljava_lang_CharSequence__Landroid_view_SubMenu_;

	private static Delegate? cb_changeMenuMode_ChangeMenuMode_V;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_clearAll_ClearAll_V;

	private static Delegate? cb_clearHeader_ClearHeader_V;

	private static Delegate? cb_close_Close_V;

	private static Delegate? cb_collapseItemActionView_CollapseItemActionView_Landroidx_appcompat_view_menu_MenuItemImpl__Z;

	private static Delegate? cb_expandItemActionView_ExpandItemActionView_Landroidx_appcompat_view_menu_MenuItemImpl__Z;

	private static Delegate? cb_findGroupIndex_FindGroupIndex_I_I;

	private static Delegate? cb_findGroupIndex_FindGroupIndex_II_I;

	private static Delegate? cb_findItem_FindItem_I_Landroid_view_MenuItem_;

	private static Delegate? cb_findItemIndex_FindItemIndex_I_I;

	private static Delegate? cb_flagActionItems_FlagActionItems_V;

	private static Delegate? cb_getItem_GetItem_I_Landroid_view_MenuItem_;

	private static Delegate? cb_isShortcutKey_IsShortcutKey_ILandroid_view_KeyEvent__Z;

	private static Delegate? cb_onItemsChanged_OnItemsChanged_Z_V;

	private static Delegate? cb_performIdentifierAction_PerformIdentifierAction_II_Z;

	private static Delegate? cb_performItemAction_PerformItemAction_Landroid_view_MenuItem_Landroidx_appcompat_view_menu_MenuPresenter_I_Z;

	private static Delegate? cb_performItemAction_PerformItemAction_Landroid_view_MenuItem_I_Z;

	private static Delegate? cb_performShortcut_PerformShortcut_ILandroid_view_KeyEvent_I_Z;

	private static Delegate? cb_removeGroup_RemoveGroup_I_V;

	private static Delegate? cb_removeItem_RemoveItem_I_V;

	private static Delegate? cb_removeItemAt_RemoveItemAt_I_V;

	private static Delegate? cb_removeMenuPresenter_RemoveMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter__V;

	private static Delegate? cb_restoreActionViewStates_RestoreActionViewStates_Landroid_os_Bundle__V;

	private static Delegate? cb_restorePresenterStates_RestorePresenterStates_Landroid_os_Bundle__V;

	private static Delegate? cb_saveActionViewStates_SaveActionViewStates_Landroid_os_Bundle__V;

	private static Delegate? cb_savePresenterStates_SavePresenterStates_Landroid_os_Bundle__V;

	private static Delegate? cb_setCallback_SetCallback_Landroidx_appcompat_view_menu_MenuBuilder_Callback__V;

	private static Delegate? cb_setCurrentMenuInfo_SetCurrentMenuInfo_Landroid_view_ContextMenu_ContextMenuInfo__V;

	private static Delegate? cb_setDefaultShowAsAction_SetDefaultShowAsAction_I_Landroidx_appcompat_view_menu_MenuBuilder_;

	private static Delegate? cb_setGroupCheckable_SetGroupCheckable_IZZ_V;

	private static Delegate? cb_setGroupEnabled_SetGroupEnabled_IZ_V;

	private static Delegate? cb_setGroupVisible_SetGroupVisible_IZ_V;

	private static Delegate? cb_setHeaderIconInt_SetHeaderIconInt_Landroid_graphics_drawable_Drawable__Landroidx_appcompat_view_menu_MenuBuilder_;

	private static Delegate? cb_setHeaderIconInt_SetHeaderIconInt_I_Landroidx_appcompat_view_menu_MenuBuilder_;

	private static Delegate? cb_setHeaderTitleInt_SetHeaderTitleInt_I_Landroidx_appcompat_view_menu_MenuBuilder_;

	private static Delegate? cb_setHeaderTitleInt_SetHeaderTitleInt_Ljava_lang_CharSequence__Landroidx_appcompat_view_menu_MenuBuilder_;

	private static Delegate? cb_setHeaderViewInt_SetHeaderViewInt_Landroid_view_View__Landroidx_appcompat_view_menu_MenuBuilder_;

	private static Delegate? cb_setOptionalIconsVisible_SetOptionalIconsVisible_Z_V;

	private static Delegate? cb_setOverrideVisibleItems_SetOverrideVisibleItems_Z_V;

	private static Delegate? cb_setQwertyMode_SetQwertyMode_Z_V;

	private static Delegate? cb_size_Size_I;

	private static Delegate? cb_startDispatchingItemsChanged_StartDispatchingItemsChanged_V;

	private static Delegate? cb_stopDispatchingItemsChanged_StopDispatchingItemsChanged_V;

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

	public unsafe virtual IList<MenuItemImpl>? ActionItems
	{
		[Register("getActionItems", "()Ljava/util/ArrayList;", "GetGetActionItemsHandler")]
		get
		{
			return JavaList<MenuItemImpl>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getActionItems.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	protected unsafe virtual string? ActionViewStatesKey
	{
		[Register("getActionViewStatesKey", "()Ljava/lang/String;", "GetGetActionViewStatesKeyHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getActionViewStatesKey.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual Context? Context
	{
		[Register("getContext", "()Landroid/content/Context;", "GetGetContextHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual MenuItemImpl? ExpandedItem
	{
		[Register("getExpandedItem", "()Landroidx/appcompat/view/menu/MenuItemImpl;", "GetGetExpandedItemHandler")]
		get
		{
			return Java.Lang.Object.GetObject<MenuItemImpl>(_members.InstanceMethods.InvokeVirtualObjectMethod("getExpandedItem.()Landroidx/appcompat/view/menu/MenuItemImpl;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool GroupDividerEnabled
	{
		[Register("isGroupDividerEnabled", "()Z", "GetIsGroupDividerEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isGroupDividerEnabled.()Z", this, null);
		}
		[Register("setGroupDividerEnabled", "(Z)V", "GetSetGroupDividerEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGroupDividerEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual bool HasVisibleItems
	{
		[Register("hasVisibleItems", "()Z", "GetHasVisibleItemsHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasVisibleItems.()Z", this, null);
		}
	}

	public unsafe virtual Drawable? HeaderIcon
	{
		[Register("getHeaderIcon", "()Landroid/graphics/drawable/Drawable;", "GetGetHeaderIconHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHeaderIcon.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual ICharSequence? HeaderTitleFormatted
	{
		[Register("getHeaderTitle", "()Ljava/lang/CharSequence;", "GetGetHeaderTitleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHeaderTitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public string? HeaderTitle
	{
		get
		{
			if (HeaderTitleFormatted != null)
			{
				return HeaderTitleFormatted.ToString();
			}
			return null;
		}
	}

	public unsafe virtual Android.Views.View? HeaderView
	{
		[Register("getHeaderView", "()Landroid/view/View;", "GetGetHeaderViewHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Android.Views.View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHeaderView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool IsDispatchingItemsChanged
	{
		[Register("isDispatchingItemsChanged", "()Z", "GetIsDispatchingItemsChangedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDispatchingItemsChanged.()Z", this, null);
		}
	}

	public unsafe virtual IList<MenuItemImpl>? NonActionItems
	{
		[Register("getNonActionItems", "()Ljava/util/ArrayList;", "GetGetNonActionItemsHandler")]
		get
		{
			return JavaList<MenuItemImpl>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getNonActionItems.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual MenuBuilder? RootMenu
	{
		[Register("getRootMenu", "()Landroidx/appcompat/view/menu/MenuBuilder;", "GetGetRootMenuHandler")]
		get
		{
			return Java.Lang.Object.GetObject<MenuBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRootMenu.()Landroidx/appcompat/view/menu/MenuBuilder;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool ShortcutsVisible
	{
		[Register("isShortcutsVisible", "()Z", "GetIsShortcutsVisibleHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isShortcutsVisible.()Z", this, null);
		}
		[Register("setShortcutsVisible", "(Z)V", "GetSetShortcutsVisible_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShortcutsVisible.(Z)V", this, ptr);
		}
	}

	public unsafe virtual IList<MenuItemImpl> VisibleItems
	{
		[Register("getVisibleItems", "()Ljava/util/ArrayList;", "GetGetVisibleItemsHandler")]
		get
		{
			return JavaList<MenuItemImpl>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getVisibleItems.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public void SetGroupDividerEnabled(bool enabled)
	{
		GroupDividerEnabled = enabled;
	}

	protected MenuBuilder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe MenuBuilder(Context? context)
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

	private static Delegate GetGetActionItemsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetActionItems);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetActionItems(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<MenuItemImpl>.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActionItems);
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

	private static Delegate GetGetActionViewStatesKeyHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetActionViewStatesKey);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetActionViewStatesKey(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActionViewStatesKey);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
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

	private static Delegate GetGetExpandedItemHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetExpandedItem);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetExpandedItem(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExpandedItem);
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

	private static Delegate GetIsGroupDividerEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsGroupDividerEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsGroupDividerEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GroupDividerEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetGroupDividerEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetGroupDividerEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGroupDividerEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool groupDividerEnabled = native_enabled != 0;
			menuBuilder.GroupDividerEnabled = groupDividerEnabled;
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

	private static Delegate GetHasVisibleItemsHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasVisibleItems);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasVisibleItems(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasVisibleItems ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetHeaderIconHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHeaderIcon);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHeaderIcon(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HeaderIcon);
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

	private static Delegate GetGetHeaderTitleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHeaderTitle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHeaderTitle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HeaderTitleFormatted);
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

	private static Delegate GetGetHeaderViewHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHeaderView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHeaderView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HeaderView);
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

	private static Delegate GetIsDispatchingItemsChangedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsDispatchingItemsChanged);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsDispatchingItemsChanged(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDispatchingItemsChanged ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetNonActionItemsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetNonActionItems);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetNonActionItems(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<MenuItemImpl>.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NonActionItems);
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

	private static Delegate GetGetRootMenuHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetRootMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRootMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RootMenu);
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

	private static Delegate GetIsShortcutsVisibleHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsShortcutsVisible);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsShortcutsVisible(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShortcutsVisible ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetShortcutsVisible_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetShortcutsVisible_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShortcutsVisible_Z(nint jnienv, nint native__this, sbyte native_shortcutsVisible)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool shortcutsVisible = native_shortcutsVisible != 0;
			menuBuilder.ShortcutsVisible = shortcutsVisible;
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

	private static Delegate GetGetVisibleItemsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetVisibleItems);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetVisibleItems(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<MenuItemImpl>.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VisibleItems);
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

	private static Delegate GetAdd_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_Add_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Add_I(nint jnienv, nint native__this, int titleRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Add(titleRes));
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

	[Register("add", "(I)Landroid/view/MenuItem;", "GetAdd_IHandler")]
	public unsafe virtual IMenuItem? Add(int titleRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(titleRes);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("add.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAdd_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_L(n_Add_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Add_IIII(nint jnienv, nint native__this, int group, int id, int categoryOrder, int title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Add(group, id, categoryOrder, title));
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

	[Register("add", "(IIII)Landroid/view/MenuItem;", "GetAdd_IIIIHandler")]
	public unsafe virtual IMenuItem? Add(int group, int id, int categoryOrder, int title)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(group);
		ptr[1] = new JniArgumentValue(id);
		ptr[2] = new JniArgumentValue(categoryOrder);
		ptr[3] = new JniArgumentValue(title);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("add.(IIII)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAdd_IIILjava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPIIIL_L(n_Add_IIILjava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Add_IIILjava_lang_CharSequence_(nint jnienv, nint native__this, int group, int id, int categoryOrder, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuBuilder.Add(group, id, categoryOrder, title));
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

	[Register("add", "(IIILjava/lang/CharSequence;)Landroid/view/MenuItem;", "GetAdd_IIILjava_lang_CharSequence_Handler")]
	public unsafe virtual IMenuItem? Add(int group, int id, int categoryOrder, ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(group);
			ptr[1] = new JniArgumentValue(id);
			ptr[2] = new JniArgumentValue(categoryOrder);
			ptr[3] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("add.(IIILjava/lang/CharSequence;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	public IMenuItem? Add(int group, int id, int categoryOrder, string? title)
	{
		Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
		IMenuItem? result = Add(group, id, categoryOrder, obj);
		obj?.Dispose();
		return result;
	}

	private static Delegate GetAdd_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_Add_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Add_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuBuilder.Add(title));
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

	[Register("add", "(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", "GetAdd_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual IMenuItem? Add(ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("add.(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	public IMenuItem? Add(string? title)
	{
		Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
		IMenuItem? result = Add(obj);
		obj?.Dispose();
		return result;
	}

	private static Delegate GetAddIntentOptions_IIILandroid_content_ComponentName_arrayLandroid_content_Intent_Landroid_content_Intent_IarrayLandroid_view_MenuItem_Handler()
	{
		return new global::_JniMarshal_PPIIILLLIL_I(n_AddIntentOptions_IIILandroid_content_ComponentName_arrayLandroid_content_Intent_Landroid_content_Intent_IarrayLandroid_view_MenuItem_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_AddIntentOptions_IIILandroid_content_ComponentName_arrayLandroid_content_Intent_Landroid_content_Intent_IarrayLandroid_view_MenuItem_(nint jnienv, nint native__this, int group, int id, int categoryOrder, nint native_caller, nint native_specifics, nint native_intent, int native_flags, nint native_outSpecificItems)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ComponentName caller = Java.Lang.Object.GetObject<ComponentName>(native_caller, JniHandleOwnership.DoNotTransfer);
			Intent[] array = (Intent[])JNIEnv.GetArray(native_specifics, JniHandleOwnership.DoNotTransfer, typeof(Intent));
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			IMenuItem[] array2 = (IMenuItem[])JNIEnv.GetArray(native_outSpecificItems, JniHandleOwnership.DoNotTransfer, typeof(IMenuItem));
			int result = menuBuilder.AddIntentOptions(group, id, categoryOrder, caller, array, intent, (MenuAppendFlags)native_flags, array2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_specifics);
			}
			if (array2 != null)
			{
				JNIEnv.CopyArray(array2, native_outSpecificItems);
			}
			return result;
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

	[Register("addIntentOptions", "(IIILandroid/content/ComponentName;[Landroid/content/Intent;Landroid/content/Intent;I[Landroid/view/MenuItem;)I", "GetAddIntentOptions_IIILandroid_content_ComponentName_arrayLandroid_content_Intent_Landroid_content_Intent_IarrayLandroid_view_MenuItem_Handler")]
	public unsafe virtual int AddIntentOptions(int group, int id, int categoryOrder, ComponentName? caller, Intent[]? specifics, Intent? intent, MenuAppendFlags flags, IMenuItem[]? outSpecificItems)
	{
		nint num = JNIEnv.NewArray(specifics);
		nint num2 = JNIEnv.NewArray(outSpecificItems);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
			*ptr = new JniArgumentValue(group);
			ptr[1] = new JniArgumentValue(id);
			ptr[2] = new JniArgumentValue(categoryOrder);
			ptr[3] = new JniArgumentValue(caller?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue(num);
			ptr[5] = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			ptr[6] = new JniArgumentValue((int)flags);
			ptr[7] = new JniArgumentValue(num2);
			return _members.InstanceMethods.InvokeVirtualInt32Method("addIntentOptions.(IIILandroid/content/ComponentName;[Landroid/content/Intent;Landroid/content/Intent;I[Landroid/view/MenuItem;)I", this, ptr);
		}
		finally
		{
			if (specifics != null)
			{
				JNIEnv.CopyArray(num, specifics);
				JNIEnv.DeleteLocalRef(num);
			}
			if (outSpecificItems != null)
			{
				JNIEnv.CopyArray(num2, outSpecificItems);
				JNIEnv.DeleteLocalRef(num2);
			}
			GC.KeepAlive(caller);
			GC.KeepAlive(specifics);
			GC.KeepAlive(intent);
			GC.KeepAlive(outSpecificItems);
		}
	}

	private static Delegate GetAddInternal_IIILjava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPIIIL_L(n_AddInternal_IIILjava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddInternal_IIILjava_lang_CharSequence_(nint jnienv, nint native__this, int group, int id, int categoryOrder, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuBuilder.AddInternal(group, id, categoryOrder, title));
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

	[Register("addInternal", "(IIILjava/lang/CharSequence;)Landroid/view/MenuItem;", "GetAddInternal_IIILjava_lang_CharSequence_Handler")]
	protected unsafe virtual IMenuItem? AddInternal(int group, int id, int categoryOrder, ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(group);
			ptr[1] = new JniArgumentValue(id);
			ptr[2] = new JniArgumentValue(categoryOrder);
			ptr[3] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("addInternal.(IIILjava/lang/CharSequence;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	protected IMenuItem? AddInternal(int group, int id, int categoryOrder, string? title)
	{
		Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
		IMenuItem? result = AddInternal(group, id, categoryOrder, obj);
		obj?.Dispose();
		return result;
	}

	private static Delegate GetAddMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter_(nint jnienv, nint native__this, nint native_presenter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuPresenter presenter = Java.Lang.Object.GetObject<IMenuPresenter>(native_presenter, JniHandleOwnership.DoNotTransfer);
			menuBuilder.AddMenuPresenter(presenter);
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

	[Register("addMenuPresenter", "(Landroidx/appcompat/view/menu/MenuPresenter;)V", "GetAddMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter_Handler")]
	public unsafe virtual void AddMenuPresenter(IMenuPresenter? presenter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((presenter == null) ? IntPtr.Zero : ((Java.Lang.Object)presenter).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addMenuPresenter.(Landroidx/appcompat/view/menu/MenuPresenter;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(presenter);
		}
	}

	private static Delegate GetAddMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter_Landroid_content_Context_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_AddMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter_Landroid_content_Context_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter_Landroid_content_Context_(nint jnienv, nint native__this, nint native_presenter, nint native_menuContext)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuPresenter presenter = Java.Lang.Object.GetObject<IMenuPresenter>(native_presenter, JniHandleOwnership.DoNotTransfer);
			Context menuContext = Java.Lang.Object.GetObject<Context>(native_menuContext, JniHandleOwnership.DoNotTransfer);
			menuBuilder.AddMenuPresenter(presenter, menuContext);
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

	[Register("addMenuPresenter", "(Landroidx/appcompat/view/menu/MenuPresenter;Landroid/content/Context;)V", "GetAddMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter_Landroid_content_Context_Handler")]
	public unsafe virtual void AddMenuPresenter(IMenuPresenter? presenter, Context? menuContext)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((presenter == null) ? IntPtr.Zero : ((Java.Lang.Object)presenter).Handle);
			ptr[1] = new JniArgumentValue(menuContext?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addMenuPresenter.(Landroidx/appcompat/view/menu/MenuPresenter;Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(presenter);
			GC.KeepAlive(menuContext);
		}
	}

	private static Delegate GetAddSubMenu_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_AddSubMenu_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddSubMenu_I(nint jnienv, nint native__this, int titleRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddSubMenu(titleRes));
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

	[Register("addSubMenu", "(I)Landroid/view/SubMenu;", "GetAddSubMenu_IHandler")]
	public unsafe virtual ISubMenu? AddSubMenu(int titleRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(titleRes);
		return Java.Lang.Object.GetObject<ISubMenu>(_members.InstanceMethods.InvokeVirtualObjectMethod("addSubMenu.(I)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAddSubMenu_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_L(n_AddSubMenu_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddSubMenu_IIII(nint jnienv, nint native__this, int group, int id, int categoryOrder, int title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddSubMenu(group, id, categoryOrder, title));
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

	[Register("addSubMenu", "(IIII)Landroid/view/SubMenu;", "GetAddSubMenu_IIIIHandler")]
	public unsafe virtual ISubMenu? AddSubMenu(int group, int id, int categoryOrder, int title)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(group);
		ptr[1] = new JniArgumentValue(id);
		ptr[2] = new JniArgumentValue(categoryOrder);
		ptr[3] = new JniArgumentValue(title);
		return Java.Lang.Object.GetObject<ISubMenu>(_members.InstanceMethods.InvokeVirtualObjectMethod("addSubMenu.(IIII)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAddSubMenu_IIILjava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPIIIL_L(n_AddSubMenu_IIILjava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddSubMenu_IIILjava_lang_CharSequence_(nint jnienv, nint native__this, int group, int id, int categoryOrder, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuBuilder.AddSubMenu(group, id, categoryOrder, title));
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

	[Register("addSubMenu", "(IIILjava/lang/CharSequence;)Landroid/view/SubMenu;", "GetAddSubMenu_IIILjava_lang_CharSequence_Handler")]
	public unsafe virtual ISubMenu? AddSubMenu(int group, int id, int categoryOrder, ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(group);
			ptr[1] = new JniArgumentValue(id);
			ptr[2] = new JniArgumentValue(categoryOrder);
			ptr[3] = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ISubMenu>(_members.InstanceMethods.InvokeVirtualObjectMethod("addSubMenu.(IIILjava/lang/CharSequence;)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	public ISubMenu? AddSubMenu(int group, int id, int categoryOrder, string? title)
	{
		Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
		ISubMenu? result = AddSubMenu(group, id, categoryOrder, obj);
		obj?.Dispose();
		return result;
	}

	private static Delegate GetAddSubMenu_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_AddSubMenu_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_AddSubMenu_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuBuilder.AddSubMenu(title));
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

	[Register("addSubMenu", "(Ljava/lang/CharSequence;)Landroid/view/SubMenu;", "GetAddSubMenu_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual ISubMenu? AddSubMenu(ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<ISubMenu>(_members.InstanceMethods.InvokeVirtualObjectMethod("addSubMenu.(Ljava/lang/CharSequence;)Landroid/view/SubMenu;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	public ISubMenu? AddSubMenu(string? title)
	{
		Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
		ISubMenu? result = AddSubMenu(obj);
		obj?.Dispose();
		return result;
	}

	private static Delegate GetChangeMenuModeHandler()
	{
		return new global::_JniMarshal_PP_V(n_ChangeMenuMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ChangeMenuMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChangeMenuMode();
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

	[Register("changeMenuMode", "()V", "GetChangeMenuModeHandler")]
	public unsafe virtual void ChangeMenuMode()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("changeMenuMode.()V", this, null);
	}

	private static Delegate GetClearHandler()
	{
		return new global::_JniMarshal_PP_V(n_Clear);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Clear(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
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

	[Register("clear", "()V", "GetClearHandler")]
	public unsafe virtual void Clear()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clear.()V", this, null);
	}

	private static Delegate GetClearAllHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearAll);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearAll(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearAll();
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

	[Register("clearAll", "()V", "GetClearAllHandler")]
	public unsafe virtual void ClearAll()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearAll.()V", this, null);
	}

	private static Delegate GetClearHeaderHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearHeader);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearHeader(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearHeader();
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

	[Register("clearHeader", "()V", "GetClearHeaderHandler")]
	public unsafe virtual void ClearHeader()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearHeader.()V", this, null);
	}

	private static Delegate GetCloseHandler()
	{
		return new global::_JniMarshal_PP_V(n_Close);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Close(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
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

	[Register("close", "()V", "GetCloseHandler")]
	public unsafe virtual void Close()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
	}

	[Register("close", "(Z)V", "")]
	public unsafe void Close(bool closeAllMenus)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(closeAllMenus ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("close.(Z)V", this, ptr);
	}

	private static Delegate GetCollapseItemActionView_Landroidx_appcompat_view_menu_MenuItemImpl_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_CollapseItemActionView_Landroidx_appcompat_view_menu_MenuItemImpl_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CollapseItemActionView_Landroidx_appcompat_view_menu_MenuItemImpl_(nint jnienv, nint native__this, nint native_item)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MenuItemImpl item = Java.Lang.Object.GetObject<MenuItemImpl>(native_item, JniHandleOwnership.DoNotTransfer);
			return menuBuilder.CollapseItemActionView(item) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("collapseItemActionView", "(Landroidx/appcompat/view/menu/MenuItemImpl;)Z", "GetCollapseItemActionView_Landroidx_appcompat_view_menu_MenuItemImpl_Handler")]
	public unsafe virtual bool CollapseItemActionView(MenuItemImpl? item)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(item?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("collapseItemActionView.(Landroidx/appcompat/view/menu/MenuItemImpl;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(item);
		}
	}

	private static Delegate GetExpandItemActionView_Landroidx_appcompat_view_menu_MenuItemImpl_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_ExpandItemActionView_Landroidx_appcompat_view_menu_MenuItemImpl_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ExpandItemActionView_Landroidx_appcompat_view_menu_MenuItemImpl_(nint jnienv, nint native__this, nint native_item)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MenuItemImpl item = Java.Lang.Object.GetObject<MenuItemImpl>(native_item, JniHandleOwnership.DoNotTransfer);
			return menuBuilder.ExpandItemActionView(item) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("expandItemActionView", "(Landroidx/appcompat/view/menu/MenuItemImpl;)Z", "GetExpandItemActionView_Landroidx_appcompat_view_menu_MenuItemImpl_Handler")]
	public unsafe virtual bool ExpandItemActionView(MenuItemImpl? item)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(item?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("expandItemActionView.(Landroidx/appcompat/view/menu/MenuItemImpl;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(item);
		}
	}

	private static Delegate GetFindGroupIndex_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_FindGroupIndex_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_FindGroupIndex_I(nint jnienv, nint native__this, int group)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindGroupIndex(group);
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

	[Register("findGroupIndex", "(I)I", "GetFindGroupIndex_IHandler")]
	public unsafe virtual int FindGroupIndex(int group)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(group);
		return _members.InstanceMethods.InvokeVirtualInt32Method("findGroupIndex.(I)I", this, ptr);
	}

	private static Delegate GetFindGroupIndex_IIHandler()
	{
		return new global::_JniMarshal_PPII_I(n_FindGroupIndex_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_FindGroupIndex_II(nint jnienv, nint native__this, int group, int start)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindGroupIndex(group, start);
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

	[Register("findGroupIndex", "(II)I", "GetFindGroupIndex_IIHandler")]
	public unsafe virtual int FindGroupIndex(int group, int start)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(group);
		ptr[1] = new JniArgumentValue(start);
		return _members.InstanceMethods.InvokeVirtualInt32Method("findGroupIndex.(II)I", this, ptr);
	}

	private static Delegate GetFindItem_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_FindItem_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_FindItem_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindItem(id));
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

	[Register("findItem", "(I)Landroid/view/MenuItem;", "GetFindItem_IHandler")]
	public unsafe virtual IMenuItem? FindItem(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("findItem.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetFindItemIndex_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_FindItemIndex_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_FindItemIndex_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindItemIndex(id);
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

	[Register("findItemIndex", "(I)I", "GetFindItemIndex_IHandler")]
	public unsafe virtual int FindItemIndex(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		return _members.InstanceMethods.InvokeVirtualInt32Method("findItemIndex.(I)I", this, ptr);
	}

	private static Delegate GetFlagActionItemsHandler()
	{
		return new global::_JniMarshal_PP_V(n_FlagActionItems);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_FlagActionItems(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlagActionItems();
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

	[Register("flagActionItems", "()V", "GetFlagActionItemsHandler")]
	public unsafe virtual void FlagActionItems()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("flagActionItems.()V", this, null);
	}

	private static Delegate GetGetItem_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_GetItem_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetItem_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItem(index));
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

	[Register("getItem", "(I)Landroid/view/MenuItem;", "GetGetItem_IHandler")]
	public unsafe virtual IMenuItem? GetItem(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItem.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetIsShortcutKey_ILandroid_view_KeyEvent_Handler()
	{
		return new global::_JniMarshal_PPIL_B(n_IsShortcutKey_ILandroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsShortcutKey_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, int native_keyCode, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return menuBuilder.IsShortcutKey((Keycode)native_keyCode, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("isShortcutKey", "(ILandroid/view/KeyEvent;)Z", "GetIsShortcutKey_ILandroid_view_KeyEvent_Handler")]
	public unsafe virtual bool IsShortcutKey(Keycode keyCode, KeyEvent? e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((int)keyCode);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isShortcutKey.(ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetOnItemsChanged_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_OnItemsChanged_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnItemsChanged_Z(nint jnienv, nint native__this, sbyte native_structureChanged)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool structureChanged = native_structureChanged != 0;
			menuBuilder.OnItemsChanged(structureChanged);
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

	[Register("onItemsChanged", "(Z)V", "GetOnItemsChanged_ZHandler")]
	public unsafe virtual void OnItemsChanged(bool structureChanged)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(structureChanged ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("onItemsChanged.(Z)V", this, ptr);
	}

	private static Delegate GetPerformIdentifierAction_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_PerformIdentifierAction_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PerformIdentifierAction_II(nint jnienv, nint native__this, int id, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PerformIdentifierAction(id, (MenuPerformFlags)native_flags) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("performIdentifierAction", "(II)Z", "GetPerformIdentifierAction_IIHandler")]
	public unsafe virtual bool PerformIdentifierAction(int id, MenuPerformFlags flags)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(id);
		ptr[1] = new JniArgumentValue((int)flags);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("performIdentifierAction.(II)Z", this, ptr);
	}

	private static Delegate GetPerformItemAction_Landroid_view_MenuItem_Landroidx_appcompat_view_menu_MenuPresenter_IHandler()
	{
		return new global::_JniMarshal_PPLLI_B(n_PerformItemAction_Landroid_view_MenuItem_Landroidx_appcompat_view_menu_MenuPresenter_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PerformItemAction_Landroid_view_MenuItem_Landroidx_appcompat_view_menu_MenuPresenter_I(nint jnienv, nint native__this, nint native_item, nint native_preferredPresenter, int flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
			IMenuPresenter preferredPresenter = Java.Lang.Object.GetObject<IMenuPresenter>(native_preferredPresenter, JniHandleOwnership.DoNotTransfer);
			return menuBuilder.PerformItemAction(item, preferredPresenter, flags) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("performItemAction", "(Landroid/view/MenuItem;Landroidx/appcompat/view/menu/MenuPresenter;I)Z", "GetPerformItemAction_Landroid_view_MenuItem_Landroidx_appcompat_view_menu_MenuPresenter_IHandler")]
	public unsafe virtual bool PerformItemAction(IMenuItem? item, IMenuPresenter? preferredPresenter, int flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
			ptr[1] = new JniArgumentValue((preferredPresenter == null) ? IntPtr.Zero : ((Java.Lang.Object)preferredPresenter).Handle);
			ptr[2] = new JniArgumentValue(flags);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("performItemAction.(Landroid/view/MenuItem;Landroidx/appcompat/view/menu/MenuPresenter;I)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(item);
			GC.KeepAlive(preferredPresenter);
		}
	}

	private static Delegate GetPerformItemAction_Landroid_view_MenuItem_IHandler()
	{
		return new global::_JniMarshal_PPLI_B(n_PerformItemAction_Landroid_view_MenuItem_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PerformItemAction_Landroid_view_MenuItem_I(nint jnienv, nint native__this, nint native_item, int flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuItem item = Java.Lang.Object.GetObject<IMenuItem>(native_item, JniHandleOwnership.DoNotTransfer);
			return menuBuilder.PerformItemAction(item, flags) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("performItemAction", "(Landroid/view/MenuItem;I)Z", "GetPerformItemAction_Landroid_view_MenuItem_IHandler")]
	public unsafe virtual bool PerformItemAction(IMenuItem? item, int flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((item == null) ? IntPtr.Zero : ((Java.Lang.Object)item).Handle);
			ptr[1] = new JniArgumentValue(flags);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("performItemAction.(Landroid/view/MenuItem;I)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(item);
		}
	}

	private static Delegate GetPerformShortcut_ILandroid_view_KeyEvent_IHandler()
	{
		return new global::_JniMarshal_PPILI_B(n_PerformShortcut_ILandroid_view_KeyEvent_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PerformShortcut_ILandroid_view_KeyEvent_I(nint jnienv, nint native__this, int native_keyCode, nint native_e, int native_flags)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return menuBuilder.PerformShortcut((Keycode)native_keyCode, e, (MenuPerformFlags)native_flags) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("performShortcut", "(ILandroid/view/KeyEvent;I)Z", "GetPerformShortcut_ILandroid_view_KeyEvent_IHandler")]
	public unsafe virtual bool PerformShortcut(Keycode keyCode, KeyEvent? e, MenuPerformFlags flags)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue((int)keyCode);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((int)flags);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("performShortcut.(ILandroid/view/KeyEvent;I)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
		}
	}

	private static Delegate GetRemoveGroup_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_RemoveGroup_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveGroup_I(nint jnienv, nint native__this, int group)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveGroup(group);
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

	[Register("removeGroup", "(I)V", "GetRemoveGroup_IHandler")]
	public unsafe virtual void RemoveGroup(int group)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(group);
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeGroup.(I)V", this, ptr);
	}

	private static Delegate GetRemoveItem_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_RemoveItem_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveItem_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveItem(id);
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

	[Register("removeItem", "(I)V", "GetRemoveItem_IHandler")]
	public unsafe virtual void RemoveItem(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeItem.(I)V", this, ptr);
	}

	private static Delegate GetRemoveItemAt_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_RemoveItemAt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveItemAt_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveItemAt(index);
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

	[Register("removeItemAt", "(I)V", "GetRemoveItemAt_IHandler")]
	public unsafe virtual void RemoveItemAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeItemAt.(I)V", this, ptr);
	}

	private static Delegate GetRemoveMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter_(nint jnienv, nint native__this, nint native_presenter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuPresenter presenter = Java.Lang.Object.GetObject<IMenuPresenter>(native_presenter, JniHandleOwnership.DoNotTransfer);
			menuBuilder.RemoveMenuPresenter(presenter);
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

	[Register("removeMenuPresenter", "(Landroidx/appcompat/view/menu/MenuPresenter;)V", "GetRemoveMenuPresenter_Landroidx_appcompat_view_menu_MenuPresenter_Handler")]
	public unsafe virtual void RemoveMenuPresenter(IMenuPresenter? presenter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((presenter == null) ? IntPtr.Zero : ((Java.Lang.Object)presenter).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeMenuPresenter.(Landroidx/appcompat/view/menu/MenuPresenter;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(presenter);
		}
	}

	private static Delegate GetRestoreActionViewStates_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RestoreActionViewStates_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RestoreActionViewStates_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_states)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle states = Java.Lang.Object.GetObject<Bundle>(native_states, JniHandleOwnership.DoNotTransfer);
			menuBuilder.RestoreActionViewStates(states);
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

	[Register("restoreActionViewStates", "(Landroid/os/Bundle;)V", "GetRestoreActionViewStates_Landroid_os_Bundle_Handler")]
	public unsafe virtual void RestoreActionViewStates(Bundle? states)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(states?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("restoreActionViewStates.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(states);
		}
	}

	private static Delegate GetRestorePresenterStates_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RestorePresenterStates_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RestorePresenterStates_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle state = Java.Lang.Object.GetObject<Bundle>(native_state, JniHandleOwnership.DoNotTransfer);
			menuBuilder.RestorePresenterStates(state);
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

	[Register("restorePresenterStates", "(Landroid/os/Bundle;)V", "GetRestorePresenterStates_Landroid_os_Bundle_Handler")]
	public unsafe virtual void RestorePresenterStates(Bundle? state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("restorePresenterStates.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetSaveActionViewStates_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SaveActionViewStates_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SaveActionViewStates_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_outStates)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle outStates = Java.Lang.Object.GetObject<Bundle>(native_outStates, JniHandleOwnership.DoNotTransfer);
			menuBuilder.SaveActionViewStates(outStates);
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

	[Register("saveActionViewStates", "(Landroid/os/Bundle;)V", "GetSaveActionViewStates_Landroid_os_Bundle_Handler")]
	public unsafe virtual void SaveActionViewStates(Bundle? outStates)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outStates?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("saveActionViewStates.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outStates);
		}
	}

	private static Delegate GetSavePresenterStates_Landroid_os_Bundle_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SavePresenterStates_Landroid_os_Bundle_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SavePresenterStates_Landroid_os_Bundle_(nint jnienv, nint native__this, nint native_outState)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Bundle outState = Java.Lang.Object.GetObject<Bundle>(native_outState, JniHandleOwnership.DoNotTransfer);
			menuBuilder.SavePresenterStates(outState);
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

	[Register("savePresenterStates", "(Landroid/os/Bundle;)V", "GetSavePresenterStates_Landroid_os_Bundle_Handler")]
	public unsafe virtual void SavePresenterStates(Bundle? outState)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(outState?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("savePresenterStates.(Landroid/os/Bundle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(outState);
		}
	}

	private static Delegate GetSetCallback_Landroidx_appcompat_view_menu_MenuBuilder_Callback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCallback_Landroidx_appcompat_view_menu_MenuBuilder_Callback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCallback_Landroidx_appcompat_view_menu_MenuBuilder_Callback_(nint jnienv, nint native__this, nint native_cb)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICallback callback = Java.Lang.Object.GetObject<ICallback>(native_cb, JniHandleOwnership.DoNotTransfer);
			menuBuilder.SetCallback(callback);
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

	[Register("setCallback", "(Landroidx/appcompat/view/menu/MenuBuilder$Callback;)V", "GetSetCallback_Landroidx_appcompat_view_menu_MenuBuilder_Callback_Handler")]
	public unsafe virtual void SetCallback(ICallback? cb)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((cb == null) ? IntPtr.Zero : ((Java.Lang.Object)cb).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCallback.(Landroidx/appcompat/view/menu/MenuBuilder$Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cb);
		}
	}

	private static Delegate GetSetCurrentMenuInfo_Landroid_view_ContextMenu_ContextMenuInfo_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCurrentMenuInfo_Landroid_view_ContextMenu_ContextMenuInfo_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCurrentMenuInfo_Landroid_view_ContextMenu_ContextMenuInfo_(nint jnienv, nint native__this, nint native_menuInfo)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IContextMenuContextMenuInfo currentMenuInfo = Java.Lang.Object.GetObject<IContextMenuContextMenuInfo>(native_menuInfo, JniHandleOwnership.DoNotTransfer);
			menuBuilder.SetCurrentMenuInfo(currentMenuInfo);
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

	[Register("setCurrentMenuInfo", "(Landroid/view/ContextMenu$ContextMenuInfo;)V", "GetSetCurrentMenuInfo_Landroid_view_ContextMenu_ContextMenuInfo_Handler")]
	public unsafe virtual void SetCurrentMenuInfo(IContextMenuContextMenuInfo? menuInfo)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((menuInfo == null) ? IntPtr.Zero : ((Java.Lang.Object)menuInfo).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCurrentMenuInfo.(Landroid/view/ContextMenu$ContextMenuInfo;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menuInfo);
		}
	}

	private static Delegate GetSetDefaultShowAsAction_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetDefaultShowAsAction_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetDefaultShowAsAction_I(nint jnienv, nint native__this, int defaultShowAsAction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDefaultShowAsAction(defaultShowAsAction));
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

	[Register("setDefaultShowAsAction", "(I)Landroidx/appcompat/view/menu/MenuBuilder;", "GetSetDefaultShowAsAction_IHandler")]
	public unsafe virtual MenuBuilder? SetDefaultShowAsAction(int defaultShowAsAction)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(defaultShowAsAction);
		return Java.Lang.Object.GetObject<MenuBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setDefaultShowAsAction.(I)Landroidx/appcompat/view/menu/MenuBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetGroupCheckable_IZZHandler()
	{
		return new global::_JniMarshal_PPIBB_V(n_SetGroupCheckable_IZZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGroupCheckable_IZZ(nint jnienv, nint native__this, int group, sbyte native_checkable, sbyte native_exclusive)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool checkable = native_checkable != 0;
			bool exclusive = native_exclusive != 0;
			menuBuilder.SetGroupCheckable(group, checkable, exclusive);
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

	[Register("setGroupCheckable", "(IZZ)V", "GetSetGroupCheckable_IZZHandler")]
	public unsafe virtual void SetGroupCheckable(int group, bool checkable, bool exclusive)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
		*ptr = new JniArgumentValue(group);
		ptr[1] = new JniArgumentValue(checkable ? ((sbyte)1) : ((sbyte)0));
		ptr[2] = new JniArgumentValue(exclusive ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setGroupCheckable.(IZZ)V", this, ptr);
	}

	private static Delegate GetSetGroupEnabled_IZHandler()
	{
		return new global::_JniMarshal_PPIB_V(n_SetGroupEnabled_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGroupEnabled_IZ(nint jnienv, nint native__this, int group, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool enabled = native_enabled != 0;
			menuBuilder.SetGroupEnabled(group, enabled);
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

	[Register("setGroupEnabled", "(IZ)V", "GetSetGroupEnabled_IZHandler")]
	public unsafe virtual void SetGroupEnabled(int group, bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(group);
		ptr[1] = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setGroupEnabled.(IZ)V", this, ptr);
	}

	private static Delegate GetSetGroupVisible_IZHandler()
	{
		return new global::_JniMarshal_PPIB_V(n_SetGroupVisible_IZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetGroupVisible_IZ(nint jnienv, nint native__this, int group, sbyte native_visible)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool visible = native_visible != 0;
			menuBuilder.SetGroupVisible(group, visible);
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

	[Register("setGroupVisible", "(IZ)V", "GetSetGroupVisible_IZHandler")]
	public unsafe virtual void SetGroupVisible(int group, bool visible)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(group);
		ptr[1] = new JniArgumentValue(visible ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setGroupVisible.(IZ)V", this, ptr);
	}

	private static Delegate GetSetHeaderIconInt_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetHeaderIconInt_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetHeaderIconInt_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable headerIconInt = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuBuilder.SetHeaderIconInt(headerIconInt));
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

	[Register("setHeaderIconInt", "(Landroid/graphics/drawable/Drawable;)Landroidx/appcompat/view/menu/MenuBuilder;", "GetSetHeaderIconInt_Landroid_graphics_drawable_Drawable_Handler")]
	protected unsafe virtual MenuBuilder? SetHeaderIconInt(Drawable? icon)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<MenuBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setHeaderIconInt.(Landroid/graphics/drawable/Drawable;)Landroidx/appcompat/view/menu/MenuBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(icon);
		}
	}

	private static Delegate GetSetHeaderIconInt_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetHeaderIconInt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetHeaderIconInt_I(nint jnienv, nint native__this, int iconRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHeaderIconInt(iconRes));
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

	[Register("setHeaderIconInt", "(I)Landroidx/appcompat/view/menu/MenuBuilder;", "GetSetHeaderIconInt_IHandler")]
	protected unsafe virtual MenuBuilder? SetHeaderIconInt(int iconRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(iconRes);
		return Java.Lang.Object.GetObject<MenuBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setHeaderIconInt.(I)Landroidx/appcompat/view/menu/MenuBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetHeaderTitleInt_IHandler()
	{
		return new global::_JniMarshal_PPI_L(n_SetHeaderTitleInt_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetHeaderTitleInt_I(nint jnienv, nint native__this, int titleRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHeaderTitleInt(titleRes));
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

	[Register("setHeaderTitleInt", "(I)Landroidx/appcompat/view/menu/MenuBuilder;", "GetSetHeaderTitleInt_IHandler")]
	protected unsafe virtual MenuBuilder? SetHeaderTitleInt(int titleRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(titleRes);
		return Java.Lang.Object.GetObject<MenuBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setHeaderTitleInt.(I)Landroidx/appcompat/view/menu/MenuBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetHeaderTitleInt_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetHeaderTitleInt_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetHeaderTitleInt_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence headerTitleInt = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuBuilder.SetHeaderTitleInt(headerTitleInt));
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

	[Register("setHeaderTitleInt", "(Ljava/lang/CharSequence;)Landroidx/appcompat/view/menu/MenuBuilder;", "GetSetHeaderTitleInt_Ljava_lang_CharSequence_Handler")]
	protected unsafe virtual MenuBuilder? SetHeaderTitleInt(ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<MenuBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setHeaderTitleInt.(Ljava/lang/CharSequence;)Landroidx/appcompat/view/menu/MenuBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	protected MenuBuilder? SetHeaderTitleInt(string? title)
	{
		Java.Lang.String obj = ((title == null) ? null : new Java.Lang.String(title));
		MenuBuilder? result = SetHeaderTitleInt(obj);
		obj?.Dispose();
		return result;
	}

	private static Delegate GetSetHeaderViewInt_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_SetHeaderViewInt_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetHeaderViewInt_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Android.Views.View headerViewInt = Java.Lang.Object.GetObject<Android.Views.View>(native_view, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuBuilder.SetHeaderViewInt(headerViewInt));
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

	[Register("setHeaderViewInt", "(Landroid/view/View;)Landroidx/appcompat/view/menu/MenuBuilder;", "GetSetHeaderViewInt_Landroid_view_View_Handler")]
	protected unsafe virtual MenuBuilder? SetHeaderViewInt(Android.Views.View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<MenuBuilder>(_members.InstanceMethods.InvokeVirtualObjectMethod("setHeaderViewInt.(Landroid/view/View;)Landroidx/appcompat/view/menu/MenuBuilder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetSetOptionalIconsVisible_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetOptionalIconsVisible_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOptionalIconsVisible_Z(nint jnienv, nint native__this, sbyte native_visible)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool optionalIconsVisible = native_visible != 0;
			menuBuilder.SetOptionalIconsVisible(optionalIconsVisible);
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

	[Register("setOptionalIconsVisible", "(Z)V", "GetSetOptionalIconsVisible_ZHandler")]
	public unsafe virtual void SetOptionalIconsVisible(bool visible)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(visible ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOptionalIconsVisible.(Z)V", this, ptr);
	}

	private static Delegate GetSetOverrideVisibleItems_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetOverrideVisibleItems_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetOverrideVisibleItems_Z(nint jnienv, nint native__this, sbyte native__override)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool overrideVisibleItems = native__override != 0;
			menuBuilder.SetOverrideVisibleItems(overrideVisibleItems);
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

	[Register("setOverrideVisibleItems", "(Z)V", "GetSetOverrideVisibleItems_ZHandler")]
	public unsafe virtual void SetOverrideVisibleItems(bool @override)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(@override ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setOverrideVisibleItems.(Z)V", this, ptr);
	}

	private static Delegate GetSetQwertyMode_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetQwertyMode_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetQwertyMode_Z(nint jnienv, nint native__this, sbyte native_isQwerty)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MenuBuilder? menuBuilder = Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool qwertyMode = native_isQwerty != 0;
			menuBuilder.SetQwertyMode(qwertyMode);
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

	[Register("setQwertyMode", "(Z)V", "GetSetQwertyMode_ZHandler")]
	public unsafe virtual void SetQwertyMode(bool isQwerty)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(isQwerty ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setQwertyMode.(Z)V", this, ptr);
	}

	private static Delegate GetSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_Size);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Size(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
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

	[Register("size", "()I", "GetSizeHandler")]
	public unsafe virtual int Size()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("size.()I", this, null);
	}

	private static Delegate GetStartDispatchingItemsChangedHandler()
	{
		return new global::_JniMarshal_PP_V(n_StartDispatchingItemsChanged);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StartDispatchingItemsChanged(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartDispatchingItemsChanged();
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

	[Register("startDispatchingItemsChanged", "()V", "GetStartDispatchingItemsChangedHandler")]
	public unsafe virtual void StartDispatchingItemsChanged()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("startDispatchingItemsChanged.()V", this, null);
	}

	private static Delegate GetStopDispatchingItemsChangedHandler()
	{
		return new global::_JniMarshal_PP_V(n_StopDispatchingItemsChanged);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_StopDispatchingItemsChanged(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MenuBuilder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopDispatchingItemsChanged();
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

	[Register("stopDispatchingItemsChanged", "()V", "GetStopDispatchingItemsChangedHandler")]
	public unsafe virtual void StopDispatchingItemsChanged()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("stopDispatchingItemsChanged.()V", this, null);
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
