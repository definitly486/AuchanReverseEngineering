using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Runtime;

[Register("com/yandex/runtime/LocalError", "", "Com.Yandex.Runtime.ILocalErrorInvoker")]
public interface ILocalError : IError, IJavaObject, IDisposable, IJavaPeerable
{
}
