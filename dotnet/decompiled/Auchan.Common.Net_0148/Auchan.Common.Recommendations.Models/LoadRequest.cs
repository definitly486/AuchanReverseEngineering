namespace Auchan.Common.Recommendations.Models;

public sealed class LoadRequest
{
	public RecommendationSection[] Sections { get; set; }

	public bool ShowShevronButton { get; set; } = true;
}
