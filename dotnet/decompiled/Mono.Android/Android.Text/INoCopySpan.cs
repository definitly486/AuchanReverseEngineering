using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Text;

[Register("android/text/NoCopySpan", "", "Android.Text.INoCopySpanInvoker")]
public interface INoCopySpan : IJavaObject, IDisposable, IJavaPeerable
{
}
