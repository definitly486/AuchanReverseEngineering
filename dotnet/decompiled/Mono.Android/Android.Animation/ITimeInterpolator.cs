using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Animation;

[Register("android/animation/TimeInterpolator", "", "Android.Animation.ITimeInterpolatorInvoker")]
public interface ITimeInterpolator : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("getInterpolation", "(F)F", "GetGetInterpolation_FHandler:Android.Animation.ITimeInterpolatorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	float GetInterpolation(float input);
}
