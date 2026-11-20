using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Gms.Tasks;

[Register("com/google/android/gms/tasks/OnCanceledListener", "", "Android.Gms.Tasks.IOnCanceledListenerInvoker")]
public interface IOnCanceledListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onCanceled", "()V", "GetOnCanceledHandler:Android.Gms.Tasks.IOnCanceledListenerInvoker, Xamarin.GooglePlayServices.Tasks")]
	void OnCanceled();
}
