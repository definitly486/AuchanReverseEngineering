namespace Auchan.Common.Ecom.CtmShelves.Models;

public sealed class ShelfBanner
{
	public required string ImageUrl { get; init; }

	public required ShelfBannerButton? Button { get; init; }
}
