using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/MenuItem$OnActionExpandListener", "", "Android.Views.IMenuItemOnActionExpandListenerInvoker")]
public interface IMenuItemOnActionExpandListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onMenuItemActionCollapse", "(Landroid/view/MenuItem;)Z", "GetOnMenuItemActionCollapse_Landroid_view_MenuItem_Handler:Android.Views.IMenuItemOnActionExpandListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnMenuItemActionCollapse(IMenuItem item);

	[Register("onMenuItemActionExpand", "(Landroid/view/MenuItem;)Z", "GetOnMenuItemActionExpand_Landroid_view_MenuItem_Handler:Android.Views.IMenuItemOnActionExpandListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnMenuItemActionExpand(IMenuItem item);
}
