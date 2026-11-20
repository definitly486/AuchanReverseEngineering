using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/ViewManager", "", "Android.Views.IViewManagerInvoker")]
public interface IViewManager : IJavaObject, IDisposable, IJavaPeerable
{
	void AddView(View? view, ViewGroup.LayoutParams? @params);

	void RemoveView(View? view);

	void UpdateViewLayout(View? view, ViewGroup.LayoutParams? @params);
}
