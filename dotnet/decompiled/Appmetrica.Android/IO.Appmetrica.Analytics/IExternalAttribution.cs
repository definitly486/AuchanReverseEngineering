using System;
using Android.Runtime;
using Java.Interop;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/ExternalAttribution", "", "IO.Appmetrica.Analytics.IExternalAttributionInvoker")]
public interface IExternalAttribution : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("toBytes", "()[B", "GetToBytesHandler:IO.Appmetrica.Analytics.IExternalAttributionInvoker, Appmetrica.Android")]
	byte[]? ToBytes();
}
