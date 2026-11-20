using System;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/AutoCloseable", "", "Java.Lang.IAutoCloseableInvoker")]
public interface IAutoCloseable : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("close", "()V", "GetCloseHandler:Java.Lang.IAutoCloseableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Close();
}
