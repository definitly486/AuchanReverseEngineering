using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Webkit;

[Register("android/webkit/ValueCallback", "", "Android.Webkit.IValueCallbackInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IValueCallback : IJavaObject, IDisposable, IJavaPeerable
{
	void OnReceiveValue(Java.Lang.Object? value);
}
