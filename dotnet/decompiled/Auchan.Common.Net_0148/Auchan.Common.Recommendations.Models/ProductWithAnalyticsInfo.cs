using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Recommendations.Models;

public sealed class ProductWithAnalyticsInfo
{
	public required Product Product { get; init; }

	public required RecommendationAnalyticsInfo Analytics { get; init; }
}
