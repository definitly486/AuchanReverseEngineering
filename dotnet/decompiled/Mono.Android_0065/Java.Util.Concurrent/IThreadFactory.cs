using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Concurrent;

[Register("java/util/concurrent/ThreadFactory", "", "Java.Util.Concurrent.IThreadFactoryInvoker")]
public interface IThreadFactory : IJavaObject, IDisposable, IJavaPeerable
{
	Thread? NewThread(IRunnable? r);
}
