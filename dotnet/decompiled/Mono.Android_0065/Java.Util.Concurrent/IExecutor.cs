using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Concurrent;

[Register("java/util/concurrent/Executor", "", "Java.Util.Concurrent.IExecutorInvoker")]
public interface IExecutor : IJavaObject, IDisposable, IJavaPeerable
{
	void Execute(IRunnable? command);
}
