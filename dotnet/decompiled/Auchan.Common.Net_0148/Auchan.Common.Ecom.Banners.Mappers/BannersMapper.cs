using System;
using System.Diagnostics.CodeAnalysis;
using Auchan.Common.Ecom.Banners.DTO;
using Auchan.Common.Ecom.Banners.Models;
using DryIoc;

namespace Auchan.Common.Ecom.Banners.Mappers;

internal static class BannersMapper
{
	public static Banner Map(this BannerDto @this, IResolver resolver)
	{
		return new Banner
		{
			Id = @this.Id,
			Name = @this.Name,
			Type = @this.Type.Map(),
			NavigateTo = @this.NavigateTo.Map(@this, resolver),
			CategoryIds = (@this.Categories ?? Array.Empty<long>()),
			BrandId = @this.BrandId,
			Image = (@this.Image ?? ""),
			ShortImage = (@this.ShortPicture ?? ""),
			CarouselImage = @this.CarouselPicture,
			Animation = (@this.Animation ?? ""),
			PromoContent = @this.PromoContent.Map(resolver)
		};
	}

	public static BannerType Map(this BannerTypeDto @this)
	{
		if (!@this.IsSupported())
		{
			throw new ArgumentException($"banner type {@this} is not supported", "this");
		}
		return (BannerType)(@this - 1);
	}

	public static IBannerNavigateTo Map(this BannerDto.NavigatedDto? @this, BannerDto banner, IResolver resolver)
	{
		if (!string.IsNullOrEmpty(@this?.ProductCode))
		{
			return resolver.Resolve<BannerNavigateToProduct>(new object[1] { @this.ProductCode });
		}
		if (@this != null && @this.CategoryId.HasValue && !string.IsNullOrEmpty(@this?.CategoryCode) && !string.IsNullOrEmpty(@this.CategoryName))
		{
			return resolver.Resolve<BannerNavigateToCategory>(new object[3]
			{
				@this.CategoryId.Value,
				@this.CategoryCode,
				@this.CategoryName
			});
		}
		if (!string.IsNullOrEmpty(@this?.Native))
		{
			return resolver.Resolve<BannerNavigateToNative>(new object[2] { banner.Name, @this.Native });
		}
		if (TryCreateUri(@this?.Url, out Uri uri))
		{
			return BannersNavigateToUrl.Resolve(banner.Name, uri, resolver);
		}
		if (TryCreateUri(@this?.Deeplink, out Uri uri2))
		{
			return BannersNavigateToUrl.Resolve(banner.Name, uri2, resolver);
		}
		return resolver.Resolve<BannerNoNavigation>();
	}

	public static PromoContent Map(this BannerDto.PromoContentDto? @this, IResolver resolver)
	{
		if (@this == null || (string.IsNullOrEmpty(@this.Title) && string.IsNullOrEmpty(@this.Description) && string.IsNullOrEmpty(@this.Link) && string.IsNullOrEmpty(@this.LinkText)))
		{
			return PromoContent.Empty;
		}
		BannersNavigateToUrl navigateTo = null;
		if (!string.IsNullOrEmpty(@this.LinkText) && TryCreateUri(@this.Link, out Uri uri))
		{
			navigateTo = resolver.Resolve<BannersNavigateToUrl>(new object[2] { @this.LinkText, uri });
		}
		return new PromoContent
		{
			Title = (@this.Title ?? ""),
			Description = (@this.Description ?? ""),
			Link = (@this.Link ?? ""),
			LinkText = (@this.LinkText ?? ""),
			NavigateTo = navigateTo
		};
	}

	private static bool TryCreateUri([NotNullWhen(true)][StringSyntax("Uri")] string? from, [NotNullWhen(true)] out Uri? uri)
	{
		uri = null;
		if (from == null)
		{
			return false;
		}
		try
		{
			UriBuilder uriBuilder = new UriBuilder(from);
			uri = uriBuilder.Uri;
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
