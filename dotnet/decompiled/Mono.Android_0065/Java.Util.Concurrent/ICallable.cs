using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Concurrent;

[Register("java/util/concurrent/Callable", "", "Java.Util.Concurrent.ICallableInvoker")]
[JavaTypeParameters(new string[] { "V" })]
public interface ICallable : IJavaObject, IDisposable, IJavaPeerable
{
	Java.Lang.Object? Call();
}
