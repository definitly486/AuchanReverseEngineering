using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.Ecom.CtmShelves.DTO;
using Auchan.Common.Ecom.CtmShelves.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.UniversalLinks;
using DryIoc;

namespace Auchan.Common.Ecom.CtmShelves;

internal static class Mapper
{
	public static string Map(this ShelfPlacement @this)
	{
		if (@this == ShelfPlacement.Home)
		{
			return "home";
		}
		throw new NotImplementedException("dead code");
	}

	public static IReadOnlyList<Shelf> Map(this ShelfResponseDto @this, IResolver resolver)
	{
		resolver.Resolve<IUniversalLinksService>();
		Func<string?, CtmLink> ctmLinkFactory = resolver.Resolve<Func<string, CtmLink>>();
		return (from i in @this.Data
			where i.Container != ShelfResponseDto.ContainerDto.Unknown
			orderby i.Rank
			select new Shelf
			{
				Id = i.Id,
				Title = i.Title,
				Subtitle = i.Subtitle,
				Rank = i.Rank,
				Container = i.Container.Map(),
				SeeAllLink = ctmLinkFactory(i.SeeAllLink),
				Banner = i.Banner.Map(ctmLinkFactory),
				Products = i.Products.Select((ProductDto p) => new ProductWithAnalyticsInfo
				{
					Product = p.Map(),
					Analytics = new RecommendationAnalyticsInfo
					{
						ActionsTag = RecomendationAnalyticActionsTag.CtmShelf,
						BlockId = $"{i.Id}/{i.Title}"
					}
				}).ToImmutableList()
			}).ToImmutableList();
	}

	private static Auchan.Common.Ecom.CtmShelves.Models.Container Map(this ShelfResponseDto.ContainerDto @this)
	{
		return (Auchan.Common.Ecom.CtmShelves.Models.Container)(@this - 1);
	}

	private static ShelfBanner? Map(this ShelfResponseDto.BannerDto? @this, Func<string, CtmLink> ctmLinkFactory)
	{
		if (@this == null)
		{
			return null;
		}
		if (string.IsNullOrEmpty(@this.ImageUrl))
		{
			return null;
		}
		ShelfBannerButton button = null;
		if (!string.IsNullOrEmpty(@this.ButtonText) && !string.IsNullOrEmpty(@this.ButtonLink))
		{
			button = new ShelfBannerButton
			{
				ButtonText = @this.ButtonText,
				ButtonLink = ctmLinkFactory(@this.ButtonLink)
			};
		}
		return new ShelfBanner
		{
			ImageUrl = @this.ImageUrl,
			Button = button
		};
	}
}
