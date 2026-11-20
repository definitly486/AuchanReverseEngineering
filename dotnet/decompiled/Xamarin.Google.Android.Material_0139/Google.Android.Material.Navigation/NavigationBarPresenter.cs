using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.View.Menu;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Navigation;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("com/google/android/material/navigation/NavigationBarPresenter", DoNotGenerateAcw = true)]
public class NavigationBarPresenter : Java.Lang.Object, IMenuPresenter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/navigation/NavigationBarPresenter", typeof(NavigationBarPresenter));

	private static Delegate? cb_getId_GetId_I;

	private static Delegate? cb_setId_SetId_I_V;

	private static Delegate? cb_collapseItemActionView_CollapseItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl__Z;

	private static Delegate? cb_expandItemActionView_ExpandItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl__Z;

	private static Delegate? cb_flagActionItems_FlagActionItems_Z;

	private static Delegate? cb_getMenuView_GetMenuView_Landroid_view_ViewGroup__Landroidx_appcompat_view_menu_MenuView_;

	private static Delegate? cb_initForMenu_InitForMenu_Landroid_content_Context_Landroidx_appcompat_view_menu_MenuBuilder__V;

	private static Delegate? cb_onCloseMenu_OnCloseMenu_Landroidx_appcompat_view_menu_MenuBuilder_Z_V;

	private static Delegate? cb_onRestoreInstanceState_OnRestoreInstanceState_Landroid_os_Parcelable__V;

	private static Delegate? cb_onSaveInstanceState_OnSaveInstanceState_Landroid_os_Parcelable_;

	private static Delegate? cb_onSubMenuSelected_OnSubMenuSelected_Landroidx_appcompat_view_menu_SubMenuBuilder__Z;

	private static Delegate? cb_setCallback_SetCallback_Landroidx_appcompat_view_menu_MenuPresenter_Callback__V;

	private static Delegate? cb_setMenuView_SetMenuView_Lcom_google_android_material_navigation_NavigationBarMenuView__V;

	private static Delegate? cb_setUpdateSuspended_SetUpdateSuspended_Z_V;

	private static Delegate? cb_updateMenuView_UpdateMenuView_Z_V;

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

	public unsafe virtual int Id
	{
		[Register("getId", "()I", "GetGetIdHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getId.()I", this, null);
		}
		[Register("setId", "(I)V", "GetSetId_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setId.(I)V", this, ptr);
		}
	}

	protected NavigationBarPresenter(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe NavigationBarPresenter()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetGetIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
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

	private static Delegate GetSetId_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetId_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetId_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id = id;
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

	private static Delegate GetCollapseItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_Handler()
	{
		return new global::_JniMarshal_PPLL_B(n_CollapseItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CollapseItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_(nint jnienv, nint native__this, nint native_menu, nint native_item)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			NavigationBarPresenter? navigationBarPresenter = Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MenuBuilder menu = Java.Lang.Object.GetObject<MenuBuilder>(native_menu, JniHandleOwnership.DoNotTransfer);
			MenuItemImpl item = Java.Lang.Object.GetObject<MenuItemImpl>(native_item, JniHandleOwnership.DoNotTransfer);
			return navigationBarPresenter.CollapseItemActionView(menu, item) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("collapseItemActionView", "(Landroidx/appcompat/view/menu/MenuBuilder;Landroidx/appcompat/view/menu/MenuItemImpl;)Z", "GetCollapseItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_Handler")]
	public unsafe virtual bool CollapseItemActionView(MenuBuilder? menu, MenuItemImpl? item)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(menu?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(item?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("collapseItemActionView.(Landroidx/appcompat/view/menu/MenuBuilder;Landroidx/appcompat/view/menu/MenuItemImpl;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
			GC.KeepAlive(item);
		}
	}

	private static Delegate GetExpandItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_Handler()
	{
		return new global::_JniMarshal_PPLL_B(n_ExpandItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ExpandItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_(nint jnienv, nint native__this, nint native_menu, nint native_item)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			NavigationBarPresenter? navigationBarPresenter = Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MenuBuilder menu = Java.Lang.Object.GetObject<MenuBuilder>(native_menu, JniHandleOwnership.DoNotTransfer);
			MenuItemImpl item = Java.Lang.Object.GetObject<MenuItemImpl>(native_item, JniHandleOwnership.DoNotTransfer);
			return navigationBarPresenter.ExpandItemActionView(menu, item) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("expandItemActionView", "(Landroidx/appcompat/view/menu/MenuBuilder;Landroidx/appcompat/view/menu/MenuItemImpl;)Z", "GetExpandItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_Handler")]
	public unsafe virtual bool ExpandItemActionView(MenuBuilder? menu, MenuItemImpl? item)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(menu?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(item?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("expandItemActionView.(Landroidx/appcompat/view/menu/MenuBuilder;Landroidx/appcompat/view/menu/MenuItemImpl;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
			GC.KeepAlive(item);
		}
	}

	private static Delegate GetFlagActionItemsHandler()
	{
		return new global::_JniMarshal_PP_B(n_FlagActionItems);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_FlagActionItems(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlagActionItems() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("flagActionItems", "()Z", "GetFlagActionItemsHandler")]
	public unsafe virtual bool FlagActionItems()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("flagActionItems.()Z", this, null);
	}

	private static Delegate GetGetMenuView_Landroid_view_ViewGroup_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetMenuView_Landroid_view_ViewGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMenuView_Landroid_view_ViewGroup_(nint jnienv, nint native__this, nint native_root)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			NavigationBarPresenter? navigationBarPresenter = Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup root = Java.Lang.Object.GetObject<ViewGroup>(native_root, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(navigationBarPresenter.GetMenuView(root));
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

	[Register("getMenuView", "(Landroid/view/ViewGroup;)Landroidx/appcompat/view/menu/MenuView;", "GetGetMenuView_Landroid_view_ViewGroup_Handler")]
	public unsafe virtual IMenuView? GetMenuView(ViewGroup? root)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(root?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuView>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMenuView.(Landroid/view/ViewGroup;)Landroidx/appcompat/view/menu/MenuView;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(root);
		}
	}

	private static Delegate GetInitForMenu_Landroid_content_Context_Landroidx_appcompat_view_menu_MenuBuilder_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_InitForMenu_Landroid_content_Context_Landroidx_appcompat_view_menu_MenuBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InitForMenu_Landroid_content_Context_Landroidx_appcompat_view_menu_MenuBuilder_(nint jnienv, nint native__this, nint native_context, nint native_menu)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarPresenter? navigationBarPresenter = Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			MenuBuilder menu = Java.Lang.Object.GetObject<MenuBuilder>(native_menu, JniHandleOwnership.DoNotTransfer);
			navigationBarPresenter.InitForMenu(context, menu);
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

	[Register("initForMenu", "(Landroid/content/Context;Landroidx/appcompat/view/menu/MenuBuilder;)V", "GetInitForMenu_Landroid_content_Context_Landroidx_appcompat_view_menu_MenuBuilder_Handler")]
	public unsafe virtual void InitForMenu(Context context, MenuBuilder menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(menu?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("initForMenu.(Landroid/content/Context;Landroidx/appcompat/view/menu/MenuBuilder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(menu);
		}
	}

	private static Delegate GetOnCloseMenu_Landroidx_appcompat_view_menu_MenuBuilder_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_OnCloseMenu_Landroidx_appcompat_view_menu_MenuBuilder_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCloseMenu_Landroidx_appcompat_view_menu_MenuBuilder_Z(nint jnienv, nint native__this, nint native_menu, sbyte native_allMenusAreClosing)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarPresenter? navigationBarPresenter = Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MenuBuilder menu = Java.Lang.Object.GetObject<MenuBuilder>(native_menu, JniHandleOwnership.DoNotTransfer);
			bool allMenusAreClosing = native_allMenusAreClosing != 0;
			navigationBarPresenter.OnCloseMenu(menu, allMenusAreClosing);
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

	[Register("onCloseMenu", "(Landroidx/appcompat/view/menu/MenuBuilder;Z)V", "GetOnCloseMenu_Landroidx_appcompat_view_menu_MenuBuilder_ZHandler")]
	public unsafe virtual void OnCloseMenu(MenuBuilder? menu, bool allMenusAreClosing)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(menu?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(allMenusAreClosing ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("onCloseMenu.(Landroidx/appcompat/view/menu/MenuBuilder;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
		}
	}

	private static Delegate GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnRestoreInstanceState_Landroid_os_Parcelable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnRestoreInstanceState_Landroid_os_Parcelable_(nint jnienv, nint native__this, nint native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarPresenter? navigationBarPresenter = Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IParcelable state = Java.Lang.Object.GetObject<IParcelable>(native_state, JniHandleOwnership.DoNotTransfer);
			navigationBarPresenter.OnRestoreInstanceState(state);
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

	[Register("onRestoreInstanceState", "(Landroid/os/Parcelable;)V", "GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler")]
	public unsafe virtual void OnRestoreInstanceState(IParcelable state)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((state == null) ? IntPtr.Zero : ((Java.Lang.Object)state).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onRestoreInstanceState.(Landroid/os/Parcelable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetOnSaveInstanceStateHandler()
	{
		return new global::_JniMarshal_PP_L(n_OnSaveInstanceState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnSaveInstanceState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSaveInstanceState());
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

	[Register("onSaveInstanceState", "()Landroid/os/Parcelable;", "GetOnSaveInstanceStateHandler")]
	public unsafe virtual IParcelable OnSaveInstanceState()
	{
		return Java.Lang.Object.GetObject<IParcelable>(_members.InstanceMethods.InvokeVirtualObjectMethod("onSaveInstanceState.()Landroid/os/Parcelable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnSubMenuSelected_Landroidx_appcompat_view_menu_SubMenuBuilder_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_OnSubMenuSelected_Landroidx_appcompat_view_menu_SubMenuBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnSubMenuSelected_Landroidx_appcompat_view_menu_SubMenuBuilder_(nint jnienv, nint native__this, nint native_subMenu)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			NavigationBarPresenter? navigationBarPresenter = Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SubMenuBuilder subMenu = Java.Lang.Object.GetObject<SubMenuBuilder>(native_subMenu, JniHandleOwnership.DoNotTransfer);
			return navigationBarPresenter.OnSubMenuSelected(subMenu) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("onSubMenuSelected", "(Landroidx/appcompat/view/menu/SubMenuBuilder;)Z", "GetOnSubMenuSelected_Landroidx_appcompat_view_menu_SubMenuBuilder_Handler")]
	public unsafe virtual bool OnSubMenuSelected(SubMenuBuilder? subMenu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(subMenu?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onSubMenuSelected.(Landroidx/appcompat/view/menu/SubMenuBuilder;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(subMenu);
		}
	}

	private static Delegate GetSetCallback_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCallback_Landroidx_appcompat_view_menu_MenuPresenter_Callback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCallback_Landroidx_appcompat_view_menu_MenuPresenter_Callback_(nint jnienv, nint native__this, nint native_cb)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarPresenter? navigationBarPresenter = Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuPresenterCallback callback = Java.Lang.Object.GetObject<IMenuPresenterCallback>(native_cb, JniHandleOwnership.DoNotTransfer);
			navigationBarPresenter.SetCallback(callback);
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

	[Register("setCallback", "(Landroidx/appcompat/view/menu/MenuPresenter$Callback;)V", "GetSetCallback_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Handler")]
	public unsafe virtual void SetCallback(IMenuPresenterCallback? cb)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((cb == null) ? IntPtr.Zero : ((Java.Lang.Object)cb).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCallback.(Landroidx/appcompat/view/menu/MenuPresenter$Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cb);
		}
	}

	private static Delegate GetSetMenuView_Lcom_google_android_material_navigation_NavigationBarMenuView_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetMenuView_Lcom_google_android_material_navigation_NavigationBarMenuView_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMenuView_Lcom_google_android_material_navigation_NavigationBarMenuView_(nint jnienv, nint native__this, nint native_menuView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarPresenter? navigationBarPresenter = Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			NavigationBarMenuView menuView = Java.Lang.Object.GetObject<NavigationBarMenuView>(native_menuView, JniHandleOwnership.DoNotTransfer);
			navigationBarPresenter.SetMenuView(menuView);
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

	[Register("setMenuView", "(Lcom/google/android/material/navigation/NavigationBarMenuView;)V", "GetSetMenuView_Lcom_google_android_material_navigation_NavigationBarMenuView_Handler")]
	public unsafe virtual void SetMenuView(NavigationBarMenuView menuView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(menuView?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMenuView.(Lcom/google/android/material/navigation/NavigationBarMenuView;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menuView);
		}
	}

	private static Delegate GetSetUpdateSuspended_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetUpdateSuspended_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetUpdateSuspended_Z(nint jnienv, nint native__this, sbyte native_updateSuspended)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarPresenter? navigationBarPresenter = Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool updateSuspended = native_updateSuspended != 0;
			navigationBarPresenter.SetUpdateSuspended(updateSuspended);
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

	[Register("setUpdateSuspended", "(Z)V", "GetSetUpdateSuspended_ZHandler")]
	public unsafe virtual void SetUpdateSuspended(bool updateSuspended)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(updateSuspended ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setUpdateSuspended.(Z)V", this, ptr);
	}

	private static Delegate GetUpdateMenuView_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_UpdateMenuView_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateMenuView_Z(nint jnienv, nint native__this, sbyte native_cleared)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			NavigationBarPresenter? navigationBarPresenter = Java.Lang.Object.GetObject<NavigationBarPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool cleared = native_cleared != 0;
			navigationBarPresenter.UpdateMenuView(cleared);
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

	[Register("updateMenuView", "(Z)V", "GetUpdateMenuView_ZHandler")]
	public unsafe virtual void UpdateMenuView(bool cleared)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(cleared ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("updateMenuView.(Z)V", this, ptr);
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
