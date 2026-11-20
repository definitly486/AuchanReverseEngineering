using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Gms.Tasks;

[Register("com/google/android/gms/tasks/OnFailureListener", "", "Android.Gms.Tasks.IOnFailureListenerInvoker")]
public interface IOnFailureListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onFailure", "(Ljava/lang/Exception;)V", "GetOnFailure_Ljava_lang_Exception_Handler:Android.Gms.Tasks.IOnFailureListenerInvoker, Xamarin.GooglePlayServices.Tasks")]
	void OnFailure(Java.Lang.Exception e);
}
