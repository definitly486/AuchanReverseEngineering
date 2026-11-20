using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/LifecycleOwner", "", "AndroidX.Lifecycle.ILifecycleOwnerInvoker")]
public interface ILifecycleOwner : IJavaObject, IDisposable, IJavaPeerable
{
	Lifecycle Lifecycle
	{
		[Register("getLifecycle", "()Landroidx/lifecycle/Lifecycle;", "GetGetLifecycleHandler:AndroidX.Lifecycle.ILifecycleOwnerInvoker, Xamarin.AndroidX.Lifecycle.Common.Jvm")]
		get;
	}
}
