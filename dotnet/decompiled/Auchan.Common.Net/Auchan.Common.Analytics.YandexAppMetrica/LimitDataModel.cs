using System;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public class LimitDataModel
{
	public int RequestLimit { get; set; }

	public int RequestsCount { get; set; }

	public DateTime? FirstRequestTime { get; set; }
}
