namespace Auchan.Common.Recommendations.Models;

public sealed class RecommendationAnalyticsInfo
{
	public required string BlockId { get; init; }

	public string? ProductPlacementContentId { get; init; }

	public required RecomendationAnalyticActionsTag ActionsTag { get; init; }

	public bool IsEmpty => this == Empty;

	public static RecommendationAnalyticsInfo Empty { get; } = new RecommendationAnalyticsInfo
	{
		BlockId = "",
		ActionsTag = RecomendationAnalyticActionsTag.Generic
	};
}
