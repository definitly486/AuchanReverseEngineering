using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Auchan.Common.Ecom.PriceChecker;

public interface IPriceCheckerApi
{
	[Post("/catalog/product-by-ean")]
	Task<PriceCheckerResponseDto> ProductByEan([Body] PriceCheckerRequestDto requestDto, CancellationToken token = default(CancellationToken));
}
