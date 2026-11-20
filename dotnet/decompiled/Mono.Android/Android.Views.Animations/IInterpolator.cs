using System;
using Android.Animation;
using Android.Runtime;
using Java.Interop;

namespace Android.Views.Animations;

[Register("android/view/animation/Interpolator", "", "Android.Views.Animations.IInterpolatorInvoker")]
public interface IInterpolator : ITimeInterpolator, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("getInterpolation", "(F)F", "GetGetInterpolation_FHandler:Android.Views.Animations.IInterpolatorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	new float GetInterpolation(float input);
}
