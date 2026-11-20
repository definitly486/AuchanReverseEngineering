using System;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Runnable", "", "Java.Lang.IRunnableInvoker")]
public interface IRunnable : IJavaObject, IDisposable, IJavaPeerable
{
	void Run();
}
