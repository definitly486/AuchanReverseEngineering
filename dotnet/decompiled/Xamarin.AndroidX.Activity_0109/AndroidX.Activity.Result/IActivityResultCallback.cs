using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity.Result;

[Register("androidx/activity/result/ActivityResultCallback", "", "AndroidX.Activity.Result.IActivityResultCallbackInvoker")]
[JavaTypeParameters(new string[] { "O" })]
public interface IActivityResultCallback : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onActivityResult", "(Ljava/lang/Object;)V", "GetOnActivityResult_Ljava_lang_Object_Handler:AndroidX.Activity.Result.IActivityResultCallbackInvoker, Xamarin.AndroidX.Activity")]
	void OnActivityResult(Java.Lang.Object? result);
}
