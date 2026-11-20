using System;
using Android.Runtime;
using Java.Interop;

namespace Java.IO;

[Register("java/io/Closeable", "", "Java.IO.ICloseableInvoker")]
public interface ICloseable : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("close", "()V", "GetCloseHandler:Java.IO.ICloseableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Close();
}
