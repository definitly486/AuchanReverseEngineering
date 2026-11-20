using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Gms.Tasks;

[Register("com/google/android/gms/tasks/OnTokenCanceledListener", "", "Android.Gms.Tasks.IOnTokenCanceledListenerInvoker")]
public interface IOnTokenCanceledListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onCanceled", "()V", "GetOnCanceledHandler:Android.Gms.Tasks.IOnTokenCanceledListenerInvoker, Xamarin.GooglePlayServices.Tasks")]
	void OnCanceled();
}
