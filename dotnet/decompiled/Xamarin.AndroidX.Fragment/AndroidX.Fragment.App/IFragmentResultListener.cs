using System;
using Android.OS;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Fragment.App;

[Register("androidx/fragment/app/FragmentResultListener", "", "AndroidX.Fragment.App.IFragmentResultListenerInvoker")]
public interface IFragmentResultListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onFragmentResult", "(Ljava/lang/String;Landroid/os/Bundle;)V", "GetOnFragmentResult_Ljava_lang_String_Landroid_os_Bundle_Handler:AndroidX.Fragment.App.IFragmentResultListenerInvoker, Xamarin.AndroidX.Fragment")]
	void OnFragmentResult(string p0, Bundle p1);
}
