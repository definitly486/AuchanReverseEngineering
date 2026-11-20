using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/ICrashTransformer", "", "IO.Appmetrica.Analytics.ICrashTransformerInvoker")]
public interface ICrashTransformer : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("process", "(Ljava/lang/Throwable;)Ljava/lang/Throwable;", "GetProcess_Ljava_lang_Throwable_Handler:IO.Appmetrica.Analytics.ICrashTransformerInvoker, Appmetrica.Android")]
	Throwable? Process(Throwable p0);
}
