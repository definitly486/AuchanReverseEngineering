using System;
using System.Collections.Generic;
using System.Linq;

namespace Auchan.Common.Ecom.Banners.Models;

public sealed class Banner : IEquatable<Banner>
{
	public required int Id { get; init; }

	public required string Name { get; init; }

	public required BannerType Type { get; init; }

	public required IBannerNavigateTo NavigateTo { get; init; }

	public required IReadOnlyList<long> CategoryIds { get; init; }

	public required long BrandId { get; init; }

	public required string Image { get; init; }

	public required string ShortImage { get; init; }

	public string? CarouselImage { get; init; }

	public required string Animation { get; init; }

	public required PromoContent PromoContent { get; init; }

	public bool Equals(Banner? other)
	{
		if (other == null)
		{
			return false;
		}
		if (Id == other.Id && Name == other.Name && Type == other.Type && CategoryIds.SequenceEqual(other.CategoryIds))
		{
			return Image.Equals(other.Image);
		}
		return false;
	}
}
