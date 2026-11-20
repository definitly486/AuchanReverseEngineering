using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Gms.Tasks;

[Register("com/google/android/gms/tasks/SuccessContinuation", "", "Android.Gms.Tasks.ISuccessContinuationInvoker")]
[JavaTypeParameters(new string[] { "TResult", "TContinuationResult" })]
public interface ISuccessContinuation : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("then", "(Ljava/lang/Object;)Lcom/google/android/gms/tasks/Task;", "GetThen_Ljava_lang_Object_Handler:Android.Gms.Tasks.ISuccessContinuationInvoker, Xamarin.GooglePlayServices.Tasks")]
	Task Then(Java.Lang.Object? result);
}
