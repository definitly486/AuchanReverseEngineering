using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Observable$Observer", "", "AndroidX.Camera.Core.Impl.IObservableObserverInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IObservableObserver : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onError", "(Ljava/lang/Throwable;)V", "GetOnError_Ljava_lang_Throwable_Handler:AndroidX.Camera.Core.Impl.IObservableObserverInvoker, Xamarin.AndroidX.Camera.Core")]
	void OnError(Throwable p0);

	[Register("onNewData", "(Ljava/lang/Object;)V", "GetOnNewData_Ljava_lang_Object_Handler:AndroidX.Camera.Core.Impl.IObservableObserverInvoker, Xamarin.AndroidX.Camera.Core")]
	void OnNewData(Java.Lang.Object? p0);
}
