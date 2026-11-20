using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Runtime.Bindings;

[Register("com/yandex/runtime/bindings/ArchivingHandler", "", "Com.Yandex.Runtime.Bindings.IArchivingHandlerInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IArchivingHandler : IJavaObject, IDisposable, IJavaPeerable
{
}
