using System.Collections.Generic;
using System.Collections.ObjectModel;
using Auchan.Common.Common;
using Auchan.Common.Recommendations.Models;

namespace Auchan.Common.Recommendations.ViewModels;

public sealed class SectionItemViewModel : IIdentifiable
{
	public required RecommendationsViewModel Parent { get; init; }

	public required string Title { get; init; }

	public required string Id { get; init; }

	public required IReadOnlyList<ProductWithAnalyticsInfo> Products { get; init; }

	public required bool HasCategories { get; init; }

	public required ObservableRangeCollection<RecomProductItemViewModel> Preview { get; init; }

	public required bool ShowAllButton { get; init; }

	public required bool ShowShevronButton { get; init; }

	public string ShevronAllButtonText => "Все";

	public bool IsVisible { get; set; }

	string IIdentifiable.GetId()
	{
		return "recomSection" + Id + "/" + Title;
	}
}
