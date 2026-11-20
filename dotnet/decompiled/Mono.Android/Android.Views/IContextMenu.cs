using System;
using Android.Graphics.Drawables;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/ContextMenu", "", "Android.Views.IContextMenuInvoker")]
public interface IContextMenu : IMenu, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("clearHeader", "()V", "GetClearHeaderHandler:Android.Views.IContextMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void ClearHeader();

	[Register("setHeaderIcon", "(Landroid/graphics/drawable/Drawable;)Landroid/view/ContextMenu;", "GetSetHeaderIcon_Landroid_graphics_drawable_Drawable_Handler:Android.Views.IContextMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IContextMenu? SetHeaderIcon(Drawable? icon);

	[Register("setHeaderIcon", "(I)Landroid/view/ContextMenu;", "GetSetHeaderIcon_IHandler:Android.Views.IContextMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IContextMenu? SetHeaderIcon(int iconRes);

	[Register("setHeaderTitle", "(I)Landroid/view/ContextMenu;", "GetSetHeaderTitle_IHandler:Android.Views.IContextMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IContextMenu? SetHeaderTitle(int titleRes);

	[Register("setHeaderTitle", "(Ljava/lang/CharSequence;)Landroid/view/ContextMenu;", "GetSetHeaderTitle_Ljava_lang_CharSequence_Handler:Android.Views.IContextMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IContextMenu? SetHeaderTitle(ICharSequence? title);

	[Register("setHeaderView", "(Landroid/view/View;)Landroid/view/ContextMenu;", "GetSetHeaderView_Landroid_view_View_Handler:Android.Views.IContextMenuInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IContextMenu? SetHeaderView(View? view);
}
