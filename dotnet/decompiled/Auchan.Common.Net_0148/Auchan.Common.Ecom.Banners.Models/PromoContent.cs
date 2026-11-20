namespace Auchan.Common.Ecom.Banners.Models;

public sealed class PromoContent
{
	public required string Title { get; init; }

	public required string Description { get; init; }

	public required string Link { get; init; }

	public required string LinkText { get; init; }

	public required IBannerNavigateTo? NavigateTo { get; init; }

	public bool IsEmpty => this == Empty;

	public static PromoContent Empty { get; } = new PromoContent
	{
		Title = "",
		Description = "",
		Link = "",
		LinkText = "",
		NavigateTo = null
	};
}
