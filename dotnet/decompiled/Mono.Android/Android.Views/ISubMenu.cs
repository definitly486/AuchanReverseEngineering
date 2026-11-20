using System;
using Android.Graphics.Drawables;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/SubMenu", "", "Android.Views.ISubMenuInvoker")]
public interface ISubMenu : IMenu, IJavaObject, IDisposable, IJavaPeerable
{
	IMenuItem? Item
	{
		[Register("getItem", "()Landroid/view/MenuItem;", "GetGetItemHandler:Android.Views.ISubMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("clearHeader", "()V", "GetClearHeaderHandler:Android.Views.ISubMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void ClearHeader();

	[Register("setHeaderIcon", "(Landroid/graphics/drawable/Drawable;)Landroid/view/SubMenu;", "GetSetHeaderIcon_Landroid_graphics_drawable_Drawable_Handler:Android.Views.ISubMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISubMenu? SetHeaderIcon(Drawable? icon);

	[Register("setHeaderIcon", "(I)Landroid/view/SubMenu;", "GetSetHeaderIcon_IHandler:Android.Views.ISubMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISubMenu? SetHeaderIcon(int iconRes);

	[Register("setHeaderTitle", "(I)Landroid/view/SubMenu;", "GetSetHeaderTitle_IHandler:Android.Views.ISubMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISubMenu? SetHeaderTitle(int titleRes);

	[Register("setHeaderTitle", "(Ljava/lang/CharSequence;)Landroid/view/SubMenu;", "GetSetHeaderTitle_Ljava_lang_CharSequence_Handler:Android.Views.ISubMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISubMenu? SetHeaderTitle(ICharSequence? title);

	[Register("setHeaderView", "(Landroid/view/View;)Landroid/view/SubMenu;", "GetSetHeaderView_Landroid_view_View_Handler:Android.Views.ISubMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISubMenu? SetHeaderView(View? view);

	[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)Landroid/view/SubMenu;", "GetSetIcon_Landroid_graphics_drawable_Drawable_Handler:Android.Views.ISubMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISubMenu? SetIcon(Drawable? icon);

	[Register("setIcon", "(I)Landroid/view/SubMenu;", "GetSetIcon_IHandler:Android.Views.ISubMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISubMenu? SetIcon(int iconRes);
}
