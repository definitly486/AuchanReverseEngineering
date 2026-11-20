using System.Collections.Immutable;

namespace Auchan.Common.AdminTool.Models;

public class Initialization
{
	public AppConfig AppConfig { get; }

	public Udid Udid { get; }

	public ImmutableList<ExtraPromotion> ExtraPromotions { get; }

	public Initialization(Udid udid, AppConfig appConfig, ImmutableList<ExtraPromotion> extraPromotions)
	{
		Udid = udid;
		AppConfig = appConfig;
		ExtraPromotions = extraPromotions;
	}
}
