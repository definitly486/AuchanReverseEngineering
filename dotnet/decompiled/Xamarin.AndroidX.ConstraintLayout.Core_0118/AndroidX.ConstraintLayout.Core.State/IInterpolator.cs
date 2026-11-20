using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.ConstraintLayout.Core.State;

[Register("androidx/constraintlayout/core/state/Interpolator", "", "AndroidX.ConstraintLayout.Core.State.IInterpolatorInvoker")]
public interface IInterpolator : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("getInterpolation", "(F)F", "GetGetInterpolation_FHandler:AndroidX.ConstraintLayout.Core.State.IInterpolatorInvoker, Xamarin.AndroidX.ConstraintLayout.Core")]
	float GetInterpolation(float p0);
}
