using System;
using Android.Runtime;
using Java.Interop;

namespace Google.Android.Material.Snackbar;

[Register("com/google/android/material/snackbar/ContentViewCallback", "", "Google.Android.Material.Snackbar.IContentViewCallbackInvoker")]
public interface IContentViewCallback : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("animateContentIn", "(II)V", "GetAnimateContentIn_IIHandler:Google.Android.Material.Snackbar.IContentViewCallbackInvoker, Xamarin.Google.Android.Material")]
	void AnimateContentIn(int p0, int p1);

	[Register("animateContentOut", "(II)V", "GetAnimateContentOut_IIHandler:Google.Android.Material.Snackbar.IContentViewCallbackInvoker, Xamarin.Google.Android.Material")]
	void AnimateContentOut(int p0, int p1);
}
