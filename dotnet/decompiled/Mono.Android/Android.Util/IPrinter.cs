using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Util;

[Register("android/util/Printer", "", "Android.Util.IPrinterInvoker")]
public interface IPrinter : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("println", "(Ljava/lang/String;)V", "GetPrintln_Ljava_lang_String_Handler:Android.Util.IPrinterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Println(string? x);
}
