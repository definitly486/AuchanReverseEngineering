using System;
using Android.Animation;
using Android.Runtime;
using Java.Interop;

namespace Android.Views.Animations;

[Register("android/view/animation/Interpolator", "", "Android.Views.Animations.IInterpolatorInvoker")]
public interface IInterpolator : ITimeInterpolator, IJavaObject, IDisposable, IJavaPeerable
{
	new float GetInterpolation(float input);
}
