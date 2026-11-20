using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.ConstraintLayout.Core.State;

[Register("androidx/constraintlayout/core/state/CorePixelDp", "", "AndroidX.ConstraintLayout.Core.State.ICorePixelDpInvoker")]
public interface ICorePixelDp : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("toPixels", "(F)F", "GetToPixels_FHandler:AndroidX.ConstraintLayout.Core.State.ICorePixelDpInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
	float ToPixels(float p0);
}
