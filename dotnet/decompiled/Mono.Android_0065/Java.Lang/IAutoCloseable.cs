using System;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/AutoCloseable", "", "Java.Lang.IAutoCloseableInvoker")]
public interface IAutoCloseable : IJavaObject, IDisposable, IJavaPeerable
{
	void Close();
}
