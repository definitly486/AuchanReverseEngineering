using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.DTO;
using Refit;

namespace Auchan.Common.Ecom.Cart;

internal interface ICheckoutApiV2
{
	[Post("/checkout/full-data")]
	Task<IApiResponse<CheckoutDataResponseDto>> FullDataAsync([Body] CheckoutFullDataRequestDto body, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/checkout/recalculate")]
	Task<RecalculateResponseDto> RecalculateAsync([Body] RecalculateRequestDto body, CancellationToken cancellationToken = default(CancellationToken));
}
