using System;
using Android.Runtime;
using Java.Interop;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/AnrListener", "", "IO.Appmetrica.Analytics.IAnrListenerInvoker")]
public interface IAnrListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onAppNotResponding", "()V", "GetOnAppNotRespondingHandler:IO.Appmetrica.Analytics.IAnrListenerInvoker, Appmetrica.Android")]
	void OnAppNotResponding();
}
