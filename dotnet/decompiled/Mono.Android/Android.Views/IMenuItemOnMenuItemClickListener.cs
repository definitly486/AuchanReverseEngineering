using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/MenuItem$OnMenuItemClickListener", "", "Android.Views.IMenuItemOnMenuItemClickListenerInvoker")]
public interface IMenuItemOnMenuItemClickListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onMenuItemClick", "(Landroid/view/MenuItem;)Z", "GetOnMenuItemClick_Landroid_view_MenuItem_Handler:Android.Views.IMenuItemOnMenuItemClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnMenuItemClick(IMenuItem item);
}
