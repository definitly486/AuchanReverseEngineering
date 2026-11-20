namespace Auchan.Common.AdminTool;

public class AppMetricaLimitedEvent
{
	public string EventName { get; }

	public int Limit { get; }

	public AppMetricaLimitedEvent(string eventName, int limit)
	{
		EventName = eventName;
		Limit = limit;
	}
}
