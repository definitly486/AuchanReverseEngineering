using Auchan.Common.Extensions;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public static class FirstOpenReporter
{
	private const string FIRST_OPEN_KEY = "first_open_sent";

	public static void ReportFirstOpen()
	{
		if (PreferencesEx.GetBool("first_open_sent") != true)
		{
			PreferencesEx.SetBool("first_open_sent", value: true);
			AppAnalytics.AppMetrica.TrackEvent("first_open");
		}
	}
}
