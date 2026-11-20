using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace Android.Widget;

[Register("android/widget/SpinnerAdapter", "", "Android.Widget.ISpinnerAdapterInvoker")]
public interface ISpinnerAdapter : IAdapter, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("getDropDownView", "(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;", "GetGetDropDownView_ILandroid_view_View_Landroid_view_ViewGroup_Handler:Android.Widget.ISpinnerAdapterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	View? GetDropDownView(int position, View? convertView, ViewGroup? parent);
}
