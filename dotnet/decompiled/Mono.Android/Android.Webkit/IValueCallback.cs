using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Webkit;

[Register("android/webkit/ValueCallback", "", "Android.Webkit.IValueCallbackInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IValueCallback : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onReceiveValue", "(Ljava/lang/Object;)V", "GetOnReceiveValue_Ljava_lang_Object_Handler:Android.Webkit.IValueCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnReceiveValue(Java.Lang.Object? value);
}
