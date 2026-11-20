using System;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Manager;

[Register("com/bumptech/glide/manager/LifecycleListener", "", "Bumptech.Glide.Manager.ILifecycleListenerInvoker")]
public interface ILifecycleListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onDestroy", "()V", "GetOnDestroyHandler:Bumptech.Glide.Manager.ILifecycleListenerInvoker, Xamarin.Android.Glide")]
	void OnDestroy();

	[Register("onStart", "()V", "GetOnStartHandler:Bumptech.Glide.Manager.ILifecycleListenerInvoker, Xamarin.Android.Glide")]
	void OnStart();

	[Register("onStop", "()V", "GetOnStopHandler:Bumptech.Glide.Manager.ILifecycleListenerInvoker, Xamarin.Android.Glide")]
	void OnStop();
}
