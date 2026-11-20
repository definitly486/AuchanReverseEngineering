using System;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Runnable", "", "Java.Lang.IRunnableInvoker")]
public interface IRunnable : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("run", "()V", "GetRunHandler:Java.Lang.IRunnableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Run();
}
