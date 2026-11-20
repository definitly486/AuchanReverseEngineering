using System;
using System.Collections.Generic;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;
using Auchan.Common.LoyaltyProgramLoymax;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;

public class LoyaltyPurchases
{
	public IEnumerable<FeedItemViewModel> Items { get; }

	public DateTime FetchTime { get; }

	public bool FromCache { get; }

	public HistoryFilter[]? AvailableFilters { get; }

	public int TotalCount { get; }

	public LoyaltyPurchases(IEnumerable<FeedItemViewModel> items, DateTime fetchTime, int total, HistoryFilter[]? filters)
	{
		Items = items;
		FetchTime = fetchTime;
		FromCache = false;
		TotalCount = total;
		AvailableFilters = filters;
	}
}
