using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Runtime;

[Register("com/yandex/runtime/Error", "", "Com.Yandex.Runtime.IErrorInvoker")]
public interface IError : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Runtime.IErrorInvoker, Yandex.MapKit.Lite")]
		get;
	}
}
