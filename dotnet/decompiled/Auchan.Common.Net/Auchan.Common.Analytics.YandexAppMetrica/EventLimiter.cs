using System;
using Auchan.Common.Extensions;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public class EventLimiter
{
	public bool IsInSendingWindow()
	{
		DateTime dateTime = DateTime.UtcNow.UTCToMoscow();
		TimeSpan timeSpan = new TimeSpan(11, 30, 0);
		TimeSpan timeSpan2 = new TimeSpan(12, 30, 0);
		if (dateTime.TimeOfDay >= timeSpan)
		{
			return dateTime.TimeOfDay <= timeSpan2;
		}
		return false;
	}
}
