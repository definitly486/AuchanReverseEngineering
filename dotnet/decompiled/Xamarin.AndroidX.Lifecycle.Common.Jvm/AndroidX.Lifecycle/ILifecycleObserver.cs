using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/LifecycleObserver", "", "AndroidX.Lifecycle.ILifecycleObserverInvoker")]
public interface ILifecycleObserver : IJavaObject, IDisposable, IJavaPeerable
{
}
