using System;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Request.Target;

[Register("com/bumptech/glide/request/target/SizeReadyCallback", "", "Bumptech.Glide.Request.Target.ISizeReadyCallbackInvoker")]
public interface ISizeReadyCallback : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onSizeReady", "(II)V", "GetOnSizeReady_IIHandler:Bumptech.Glide.Request.Target.ISizeReadyCallbackInvoker, Xamarin.Android.Glide")]
	void OnSizeReady(int p0, int p1);
}
