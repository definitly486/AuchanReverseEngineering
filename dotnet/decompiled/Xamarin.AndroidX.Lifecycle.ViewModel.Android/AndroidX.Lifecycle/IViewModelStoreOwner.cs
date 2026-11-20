using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/ViewModelStoreOwner", "", "AndroidX.Lifecycle.IViewModelStoreOwnerInvoker")]
public interface IViewModelStoreOwner : IJavaObject, IDisposable, IJavaPeerable
{
	ViewModelStore ViewModelStore
	{
		[Register("getViewModelStore", "()Landroidx/lifecycle/ViewModelStore;", "GetGetViewModelStoreHandler:AndroidX.Lifecycle.IViewModelStoreOwnerInvoker, Xamarin.AndroidX.Lifecycle.ViewModel.Android")]
		get;
	}
}
