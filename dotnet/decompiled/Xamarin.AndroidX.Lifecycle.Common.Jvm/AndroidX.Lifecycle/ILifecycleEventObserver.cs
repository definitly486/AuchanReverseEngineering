using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/LifecycleEventObserver", "", "AndroidX.Lifecycle.ILifecycleEventObserverInvoker")]
public interface ILifecycleEventObserver : ILifecycleObserver, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onStateChanged", "(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Lifecycle$Event;)V", "GetOnStateChanged_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_Event_Handler:AndroidX.Lifecycle.ILifecycleEventObserverInvoker, Xamarin.AndroidX.Lifecycle.Common.Jvm")]
	void OnStateChanged(ILifecycleOwner source, Lifecycle.Event e);
}
