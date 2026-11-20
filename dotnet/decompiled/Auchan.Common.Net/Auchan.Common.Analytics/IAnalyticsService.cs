using System.Collections.Generic;

namespace Auchan.Common.Analytics;

public interface IAnalyticsService
{
	void TrackScreen(string screenName);

	void TrackEvent(string eventName);

	void TrackEvent(string eventName, IDictionary<string, string> parameters);
}
