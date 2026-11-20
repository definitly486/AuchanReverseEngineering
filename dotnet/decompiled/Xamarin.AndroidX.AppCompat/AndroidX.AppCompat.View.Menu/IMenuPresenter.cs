using System;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace AndroidX.AppCompat.View.Menu;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("androidx/appcompat/view/menu/MenuPresenter", "", "AndroidX.AppCompat.View.Menu.IMenuPresenterInvoker")]
public interface IMenuPresenter : IJavaObject, IDisposable, IJavaPeerable
{
	int Id
	{
		[Register("getId", "()I", "GetGetIdHandler:AndroidX.AppCompat.View.Menu.IMenuPresenterInvoker, Xamarin.AndroidX.AppCompat")]
		get;
	}

	[Register("collapseItemActionView", "(Landroidx/appcompat/view/menu/MenuBuilder;Landroidx/appcompat/view/menu/MenuItemImpl;)Z", "GetCollapseItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_Handler:AndroidX.AppCompat.View.Menu.IMenuPresenterInvoker, Xamarin.AndroidX.AppCompat")]
	bool CollapseItemActionView(MenuBuilder? p0, MenuItemImpl? p1);

	[Register("expandItemActionView", "(Landroidx/appcompat/view/menu/MenuBuilder;Landroidx/appcompat/view/menu/MenuItemImpl;)Z", "GetExpandItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_Handler:AndroidX.AppCompat.View.Menu.IMenuPresenterInvoker, Xamarin.AndroidX.AppCompat")]
	bool ExpandItemActionView(MenuBuilder? p0, MenuItemImpl? p1);

	[Register("flagActionItems", "()Z", "GetFlagActionItemsHandler:AndroidX.AppCompat.View.Menu.IMenuPresenterInvoker, Xamarin.AndroidX.AppCompat")]
	bool FlagActionItems();

	[Register("getMenuView", "(Landroid/view/ViewGroup;)Landroidx/appcompat/view/menu/MenuView;", "GetGetMenuView_Landroid_view_ViewGroup_Handler:AndroidX.AppCompat.View.Menu.IMenuPresenterInvoker, Xamarin.AndroidX.AppCompat")]
	IMenuView? GetMenuView(ViewGroup? p0);

	[Register("initForMenu", "(Landroid/content/Context;Landroidx/appcompat/view/menu/MenuBuilder;)V", "GetInitForMenu_Landroid_content_Context_Landroidx_appcompat_view_menu_MenuBuilder_Handler:AndroidX.AppCompat.View.Menu.IMenuPresenterInvoker, Xamarin.AndroidX.AppCompat")]
	void InitForMenu(Context? p0, MenuBuilder? p1);

	[Register("onCloseMenu", "(Landroidx/appcompat/view/menu/MenuBuilder;Z)V", "GetOnCloseMenu_Landroidx_appcompat_view_menu_MenuBuilder_ZHandler:AndroidX.AppCompat.View.Menu.IMenuPresenterInvoker, Xamarin.AndroidX.AppCompat")]
	void OnCloseMenu(MenuBuilder? p0, bool p1);

	[Register("onRestoreInstanceState", "(Landroid/os/Parcelable;)V", "GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler:AndroidX.AppCompat.View.Menu.IMenuPresenterInvoker, Xamarin.AndroidX.AppCompat")]
	void OnRestoreInstanceState(IParcelable? p0);

	[Register("onSaveInstanceState", "()Landroid/os/Parcelable;", "GetOnSaveInstanceStateHandler:AndroidX.AppCompat.View.Menu.IMenuPresenterInvoker, Xamarin.AndroidX.AppCompat")]
	IParcelable? OnSaveInstanceState();

	[Register("onSubMenuSelected", "(Landroidx/appcompat/view/menu/SubMenuBuilder;)Z", "GetOnSubMenuSelected_Landroidx_appcompat_view_menu_SubMenuBuilder_Handler:AndroidX.AppCompat.View.Menu.IMenuPresenterInvoker, Xamarin.AndroidX.AppCompat")]
	bool OnSubMenuSelected(SubMenuBuilder? p0);

	[Register("setCallback", "(Landroidx/appcompat/view/menu/MenuPresenter$Callback;)V", "GetSetCallback_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Handler:AndroidX.AppCompat.View.Menu.IMenuPresenterInvoker, Xamarin.AndroidX.AppCompat")]
	void SetCallback(IMenuPresenterCallback? p0);

	[Register("updateMenuView", "(Z)V", "GetUpdateMenuView_ZHandler:AndroidX.AppCompat.View.Menu.IMenuPresenterInvoker, Xamarin.AndroidX.AppCompat")]
	void UpdateMenuView(bool p0);
}
