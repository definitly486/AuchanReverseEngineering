using System;

namespace Auchan.Common.Profile.Stores.Models;

public class StoreScheduleModel
{
	public ScheduleType ScheduleType { get; set; }

	public TimeSpan OpenTime { get; set; }

	public TimeSpan CloseTime { get; set; }

	public bool IsAroundTheClock { get; set; }
}
