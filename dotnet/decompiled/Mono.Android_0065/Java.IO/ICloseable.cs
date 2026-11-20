using System;
using Android.Runtime;
using Java.Interop;

namespace Java.IO;

[Register("java/io/Closeable", "", "Java.IO.ICloseableInvoker")]
public interface ICloseable : IJavaObject, IDisposable, IJavaPeerable
{
	void Close();
}
