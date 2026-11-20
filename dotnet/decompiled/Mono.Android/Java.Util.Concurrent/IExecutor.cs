using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.Util.Concurrent;

[Register("java/util/concurrent/Executor", "", "Java.Util.Concurrent.IExecutorInvoker")]
public interface IExecutor : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("execute", "(Ljava/lang/Runnable;)V", "GetExecute_Ljava_lang_Runnable_Handler:Java.Util.Concurrent.IExecutorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Execute(IRunnable? command);
}
