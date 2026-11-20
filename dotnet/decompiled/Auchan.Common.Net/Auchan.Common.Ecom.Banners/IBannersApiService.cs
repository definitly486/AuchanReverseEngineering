using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Banners.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Banners;

internal interface IBannersApiService
{
	Task<Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError>> GetBanners(CancellationToken cancellationToken = default(CancellationToken));
}
