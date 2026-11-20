using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Util;

[Register("android/util/Printer", "", "Android.Util.IPrinterInvoker")]
public interface IPrinter : IJavaObject, IDisposable, IJavaPeerable
{
	void Println(string? x);
}
