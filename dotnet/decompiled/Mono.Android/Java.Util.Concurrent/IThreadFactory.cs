using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Concurrent;

[Register("java/util/concurrent/ThreadFactory", "", "Java.Util.Concurrent.IThreadFactoryInvoker")]
public interface IThreadFactory : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("newThread", "(Ljava/lang/Runnable;)Ljava/lang/Thread;", "GetNewThread_Ljava_lang_Runnable_Handler:Java.Util.Concurrent.IThreadFactoryInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Thread? NewThread(IRunnable? r);
}
