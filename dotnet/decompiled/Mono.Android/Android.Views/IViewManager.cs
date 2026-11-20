using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/ViewManager", "", "Android.Views.IViewManagerInvoker")]
public interface IViewManager : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("addView", "(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", "GetAddView_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler:Android.Views.IViewManagerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void AddView(View? view, ViewGroup.LayoutParams? @params);

	[Register("removeView", "(Landroid/view/View;)V", "GetRemoveView_Landroid_view_View_Handler:Android.Views.IViewManagerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RemoveView(View? view);

	[Register("updateViewLayout", "(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V", "GetUpdateViewLayout_Landroid_view_View_Landroid_view_ViewGroup_LayoutParams_Handler:Android.Views.IViewManagerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void UpdateViewLayout(View? view, ViewGroup.LayoutParams? @params);
}
