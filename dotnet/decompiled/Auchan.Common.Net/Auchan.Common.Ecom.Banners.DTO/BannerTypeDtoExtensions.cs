namespace Auchan.Common.Ecom.Banners.DTO;

internal static class BannerTypeDtoExtensions
{
	public static bool IsSupported(this BannerTypeDto @this)
	{
		return @this > BannerTypeDto.Unknown;
	}
}
