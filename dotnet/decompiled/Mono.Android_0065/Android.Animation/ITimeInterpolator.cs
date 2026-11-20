using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Animation;

[Register("android/animation/TimeInterpolator", "", "Android.Animation.ITimeInterpolatorInvoker")]
public interface ITimeInterpolator : IJavaObject, IDisposable, IJavaPeerable
{
	float GetInterpolation(float input);
}
