using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.Ecom.Banners.ViewModels;

namespace Auchan.Common.Ecom.Banners.Models;

public static class AdditionalBannerCarouselProvider
{
	public static bool UseMockAdditionalBanners { get; set; } = false;

	private static IReadOnlyList<Banner> HomeMockBanners { get; } = BuildMockBanners("home");

	private static IReadOnlyList<Banner> LoyaltyMockBanners { get; } = BuildMockBanners("loyalty");

	public static IReadOnlyList<BannerItemViewModel> GetHomeBannerItems(IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>? allBanners)
	{
		return GetBannerItems(allBanners, BannerType.HomeAdditional, HomeMockBanners);
	}

	public static IReadOnlyList<BannerItemViewModel> GetLoyaltyBannerItems(IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>? allBanners)
	{
		return GetBannerItems(allBanners, BannerType.LoyaltyAdditional, LoyaltyMockBanners);
	}

	public static IReadOnlyList<BannerItemViewModel> FilterCarouselBanners(IEnumerable<Banner> banners)
	{
		List<Banner> list = banners.ToList();
		if (list.Count <= 2)
		{
			return list.Select((Banner banner, int index) => new BannerItemViewModel(banner, index)).ToImmutableList();
		}
		if (list.Take(3).All(HasCarouselPicture))
		{
			return list.Where(HasCarouselPicture).Select((Banner banner, int index) => new BannerItemViewModel(banner, index)).ToImmutableList();
		}
		return list.Take(2).Select((Banner banner, int index) => new BannerItemViewModel(banner, index)).ToImmutableList();
	}

	private static IReadOnlyList<BannerItemViewModel> GetBannerItems(IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>? allBanners, BannerType type, IReadOnlyList<Banner> mockBanners)
	{
		if (UseMockAdditionalBanners)
		{
			return FilterCarouselBanners(mockBanners);
		}
		if (allBanners == null || !allBanners.TryGetValue(type, out IReadOnlyList<Banner> value) || value.Count == 0)
		{
			return ImmutableList<BannerItemViewModel>.Empty;
		}
		return FilterCarouselBanners(value);
	}

	private static bool HasCarouselPicture(Banner banner)
	{
		return !string.IsNullOrWhiteSpace(banner.CarouselImage);
	}

	private static IReadOnlyList<Banner> BuildMockBanners(string prefix)
	{
		return new Banner[5]
		{
			CreateMockBanner(90001, prefix, "Сезонный выбор", 1080),
			CreateMockBanner(90002, prefix, "Большие скидки", 292),
			CreateMockBanner(90003, prefix, "Кешбэк недели", 488),
			CreateMockBanner(90004, prefix, "Новинки", 431),
			CreateMockBanner(90005, prefix, "Каталоги", 823)
		};
	}

	private static Banner CreateMockBanner(int id, string prefix, string title, int imageId)
	{
		string text = $"https://picsum.photos/id/{imageId}/560/296";
		string image = $"https://picsum.photos/id/{imageId}/1120/296";
		return new Banner
		{
			Id = id,
			Name = "Mock " + prefix + " " + title,
			Type = ((prefix == "home") ? BannerType.HomeAdditional : BannerType.LoyaltyAdditional),
			NavigateTo = new BannerNoNavigation(),
			CategoryIds = Array.Empty<long>(),
			BrandId = 0L,
			Image = image,
			ShortImage = text,
			CarouselImage = text,
			Animation = string.Empty,
			PromoContent = PromoContent.Empty
		};
	}
}
