using System;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Manager;

[Register("com/bumptech/glide/manager/Lifecycle", "", "Bumptech.Glide.Manager.ILifecycleInvoker")]
public interface ILifecycle : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("addListener", "(Lcom/bumptech/glide/manager/LifecycleListener;)V", "GetAddListener_Lcom_bumptech_glide_manager_LifecycleListener_Handler:Bumptech.Glide.Manager.ILifecycleInvoker, Xamarin.Android.Glide")]
	void AddListener(ILifecycleListener p0);

	[Register("removeListener", "(Lcom/bumptech/glide/manager/LifecycleListener;)V", "GetRemoveListener_Lcom_bumptech_glide_manager_LifecycleListener_Handler:Bumptech.Glide.Manager.ILifecycleInvoker, Xamarin.Android.Glide")]
	void RemoveListener(ILifecycleListener p0);
}
