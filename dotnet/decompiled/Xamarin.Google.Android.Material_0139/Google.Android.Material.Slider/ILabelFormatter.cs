using System;
using Android.Runtime;
using Java.Interop;

namespace Google.Android.Material.Slider;

[Register("com/google/android/material/slider/LabelFormatter", "", "Google.Android.Material.Slider.ILabelFormatterInvoker")]
public interface ILabelFormatter : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("getFormattedValue", "(F)Ljava/lang/String;", "GetGetFormattedValue_FHandler:Google.Android.Material.Slider.ILabelFormatterInvoker, Xamarin.Google.Android.Material")]
	string GetFormattedValue(float p0);
}
