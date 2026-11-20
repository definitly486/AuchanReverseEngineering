using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/Observer", "", "AndroidX.Lifecycle.IObserverInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IObserver : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onChanged", "(Ljava/lang/Object;)V", "GetOnChanged_Ljava_lang_Object_Handler:AndroidX.Lifecycle.IObserverInvoker, Xamarin.AndroidX.Lifecycle.LiveData.Core")]
	void OnChanged(Java.Lang.Object? value);
}
