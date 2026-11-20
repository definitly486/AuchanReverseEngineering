using System;
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

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("androidx/appcompat/widget/DecorToolbar", "", "AndroidX.AppCompat.Widget.IDecorToolbarInvoker")]
public interface IDecorToolbar : IJavaObject, IDisposable, IJavaPeerable
{
	Context? Context
	{
		[Register("getContext", "()Landroid/content/Context;", "GetGetContextHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
	}

	Android.Views.View? CustomView
	{
		[Register("getCustomView", "()Landroid/view/View;", "GetGetCustomViewHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
		[Register("setCustomView", "(Landroid/view/View;)V", "GetSetCustomView_Landroid_view_View_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		set;
	}

	int DisplayOptions
	{
		[Register("getDisplayOptions", "()I", "GetGetDisplayOptionsHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
		[Register("setDisplayOptions", "(I)V", "GetSetDisplayOptions_IHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		set;
	}

	int DropdownItemCount
	{
		[Register("getDropdownItemCount", "()I", "GetGetDropdownItemCountHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
	}

	int DropdownSelectedPosition
	{
		[Register("getDropdownSelectedPosition", "()I", "GetGetDropdownSelectedPositionHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
		[Register("setDropdownSelectedPosition", "(I)V", "GetSetDropdownSelectedPosition_IHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		set;
	}

	bool HasEmbeddedTabs
	{
		[Register("hasEmbeddedTabs", "()Z", "GetHasEmbeddedTabsHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
	}

	bool HasExpandedActionView
	{
		[Register("hasExpandedActionView", "()Z", "GetHasExpandedActionViewHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
	}

	bool HasIcon
	{
		[Register("hasIcon", "()Z", "GetHasIconHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
	}

	bool HasLogo
	{
		[Register("hasLogo", "()Z", "GetHasLogoHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
	}

	int Height
	{
		[Register("getHeight", "()I", "GetGetHeightHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
	}

	bool IsOverflowMenuShowPending
	{
		[Register("isOverflowMenuShowPending", "()Z", "GetIsOverflowMenuShowPendingHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
	}

	bool IsOverflowMenuShowing
	{
		[Register("isOverflowMenuShowing", "()Z", "GetIsOverflowMenuShowingHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
	}

	bool IsTitleTruncated
	{
		[Register("isTitleTruncated", "()Z", "GetIsTitleTruncatedHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
	}

	IMenu? Menu
	{
		[Register("getMenu", "()Landroid/view/Menu;", "GetGetMenuHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
	}

	int NavigationMode
	{
		[Register("getNavigationMode", "()I", "GetGetNavigationModeHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
		[Register("setNavigationMode", "(I)V", "GetSetNavigationMode_IHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		set;
	}

	ICharSequence? SubtitleFormatted
	{
		[Register("getSubtitle", "()Ljava/lang/CharSequence;", "GetGetSubtitleHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
		[Register("setSubtitle", "(Ljava/lang/CharSequence;)V", "GetSetSubtitle_Ljava_lang_CharSequence_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		set;
	}

	ICharSequence? TitleFormatted
	{
		[Register("getTitle", "()Ljava/lang/CharSequence;", "GetGetTitleHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
		[Register("setTitle", "(Ljava/lang/CharSequence;)V", "GetSetTitle_Ljava_lang_CharSequence_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		set;
	}

	ViewGroup? ViewGroup
	{
		[Register("getViewGroup", "()Landroid/view/ViewGroup;", "GetGetViewGroupHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
	}

	int Visibility
	{
		[Register("getVisibility", "()I", "GetGetVisibilityHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		get;
		[Register("setVisibility", "(I)V", "GetSetVisibility_IHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
		set;
	}

	[Register("animateToVisibility", "(I)V", "GetAnimateToVisibility_IHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void AnimateToVisibility(int p0);

	[Register("canShowOverflowMenu", "()Z", "GetCanShowOverflowMenuHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	bool CanShowOverflowMenu();

	[Register("collapseActionView", "()V", "GetCollapseActionViewHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void CollapseActionView();

	[Register("dismissPopupMenus", "()V", "GetDismissPopupMenusHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void DismissPopupMenus();

	[Register("hideOverflowMenu", "()Z", "GetHideOverflowMenuHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	bool HideOverflowMenu();

	[Register("initIndeterminateProgress", "()V", "GetInitIndeterminateProgressHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void InitIndeterminateProgress();

	[Register("initProgress", "()V", "GetInitProgressHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void InitProgress();

	[Register("restoreHierarchyState", "(Landroid/util/SparseArray;)V", "GetRestoreHierarchyState_Landroid_util_SparseArray_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void RestoreHierarchyState(SparseArray? p0);

	[Register("saveHierarchyState", "(Landroid/util/SparseArray;)V", "GetSaveHierarchyState_Landroid_util_SparseArray_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SaveHierarchyState(SparseArray? p0);

	[Register("setBackgroundDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetBackgroundDrawable_Landroid_graphics_drawable_Drawable_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetBackgroundDrawable(Drawable? p0);

	[Register("setCollapsible", "(Z)V", "GetSetCollapsible_ZHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetCollapsible(bool p0);

	[Register("setDefaultNavigationContentDescription", "(I)V", "GetSetDefaultNavigationContentDescription_IHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetDefaultNavigationContentDescription(int p0);

	[Register("setDefaultNavigationIcon", "(Landroid/graphics/drawable/Drawable;)V", "GetSetDefaultNavigationIcon_Landroid_graphics_drawable_Drawable_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetDefaultNavigationIcon(Drawable? p0);

	[Register("setDropdownParams", "(Landroid/widget/SpinnerAdapter;Landroid/widget/AdapterView$OnItemSelectedListener;)V", "GetSetDropdownParams_Landroid_widget_SpinnerAdapter_Landroid_widget_AdapterView_OnItemSelectedListener_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetDropdownParams(ISpinnerAdapter? p0, AdapterView.IOnItemSelectedListener? p1);

	[Register("setEmbeddedTabView", "(Landroidx/appcompat/widget/ScrollingTabContainerView;)V", "GetSetEmbeddedTabView_Landroidx_appcompat_widget_ScrollingTabContainerView_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetEmbeddedTabView(ScrollingTabContainerView? p0);

	[Register("setHomeButtonEnabled", "(Z)V", "GetSetHomeButtonEnabled_ZHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetHomeButtonEnabled(bool p0);

	[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)V", "GetSetIcon_Landroid_graphics_drawable_Drawable_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetIcon(Drawable? p0);

	[Register("setIcon", "(I)V", "GetSetIcon_IHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetIcon(int p0);

	[Register("setLogo", "(Landroid/graphics/drawable/Drawable;)V", "GetSetLogo_Landroid_graphics_drawable_Drawable_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetLogo(Drawable? p0);

	[Register("setLogo", "(I)V", "GetSetLogo_IHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetLogo(int p0);

	[Register("setMenu", "(Landroid/view/Menu;Landroidx/appcompat/view/menu/MenuPresenter$Callback;)V", "GetSetMenu_Landroid_view_Menu_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetMenu(IMenu? p0, IMenuPresenterCallback? p1);

	[Register("setMenuCallbacks", "(Landroidx/appcompat/view/menu/MenuPresenter$Callback;Landroidx/appcompat/view/menu/MenuBuilder$Callback;)V", "GetSetMenuCallbacks_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Landroidx_appcompat_view_menu_MenuBuilder_Callback_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetMenuCallbacks(IMenuPresenterCallback? p0, MenuBuilder.ICallback? p1);

	[Register("setMenuPrepared", "()V", "GetSetMenuPreparedHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetMenuPrepared();

	[Register("setNavigationContentDescription", "(I)V", "GetSetNavigationContentDescription_IHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetNavigationContentDescription(int p0);

	[Register("setNavigationContentDescription", "(Ljava/lang/CharSequence;)V", "GetSetNavigationContentDescription_Ljava_lang_CharSequence_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetNavigationContentDescription(ICharSequence? p0);

	[Register("setNavigationIcon", "(Landroid/graphics/drawable/Drawable;)V", "GetSetNavigationIcon_Landroid_graphics_drawable_Drawable_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetNavigationIcon(Drawable? p0);

	[Register("setNavigationIcon", "(I)V", "GetSetNavigationIcon_IHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetNavigationIcon(int p0);

	[Register("setWindowCallback", "(Landroid/view/Window$Callback;)V", "GetSetWindowCallback_Landroid_view_Window_Callback_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetWindowCallback(Window.ICallback? p0);

	[Register("setWindowTitle", "(Ljava/lang/CharSequence;)V", "GetSetWindowTitle_Ljava_lang_CharSequence_Handler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	void SetWindowTitle(ICharSequence? p0);

	[Register("setupAnimatorToVisibility", "(IJ)Landroidx/core/view/ViewPropertyAnimatorCompat;", "GetSetupAnimatorToVisibility_IJHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	ViewPropertyAnimatorCompat? SetupAnimatorToVisibility(int p0, long p1);

	[Register("showOverflowMenu", "()Z", "GetShowOverflowMenuHandler:AndroidX.AppCompat.Widget.IDecorToolbarInvoker, Xamarin.AndroidX.AppCompat")]
	bool ShowOverflowMenu();
}
