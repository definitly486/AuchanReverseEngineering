using System;
using Android.Runtime;
using Auchan.Common.Analytics;
using IO.Appmetrica.Analytics;
using Java.Interop;
using Java.Lang;

namespace Auchan.Android.AppAnalytics.YandexMetrica;

internal class YandexMetricaDeviceIdListener : Java.Lang.Object, IStartupParamsCallback, IJavaObject, IDisposable, IJavaPeerable
{
	public void OnReceive(IStartupParamsCallback.Result? p0)
	{
		string text = p0?.DeviceIdHash;
		if (!string.IsNullOrEmpty(text))
		{
			Auchan.Common.Analytics.AppAnalytics.AppMetrica.SetDeviceId(text);
		}
	}

	public void OnRequestError(IStartupParamsCallback.Reason p0, IStartupParamsCallback.Result? p1)
	{
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
