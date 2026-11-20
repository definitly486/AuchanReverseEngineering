using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.Banners.DTO;
using Refit;

namespace Auchan.Common.Ecom.Banners;

internal interface IBannersApi
{
	[Post("/banners:search")]
	Task<IReadOnlyDictionary<string, IReadOnlyList<BannerDto>>> GetBanners([Header("X-Token-CMD")] string token80, [Header("User-Agent")] string userAgent, [Body] BannersRequestDto request, CancellationToken cancellationToken);

	[Post("/banners:search")]
	Task<IReadOnlyDictionary<string, IReadOnlyList<BannerDto>>> GetBanners([Header("User-Agent")] string userAgent, [Body] BannersRequestDto request, CancellationToken cancellationToken);
}
