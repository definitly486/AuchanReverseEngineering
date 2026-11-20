using Auchan.Common.Home.MainMyOffers;

namespace Auchan.Common.AdminTool.Models;

public class AppConfigMyOffer
{
	public MainMyOfferType Code { get; }

	public int Priority { get; }

	public int Limit { get; }

	public AppConfigMyOffer(MainMyOfferType code, int priority, int limit)
	{
		Code = code;
		Priority = priority;
		Limit = limit;
	}
}
