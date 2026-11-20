using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/WindowInsetsAnimationControlListener", "", "Android.Views.IWindowInsetsAnimationControlListenerInvoker", ApiSince = 30)]
public interface IWindowInsetsAnimationControlListener : IJavaObject, IDisposable, IJavaPeerable
{
	[SupportedOSPlatform("android30.0")]
	void OnCancelled(IWindowInsetsAnimationController? controller);

	[SupportedOSPlatform("android30.0")]
	void OnFinished(IWindowInsetsAnimationController controller);

	[SupportedOSPlatform("android30.0")]
	void OnReady(IWindowInsetsAnimationController controller, int types);
}
