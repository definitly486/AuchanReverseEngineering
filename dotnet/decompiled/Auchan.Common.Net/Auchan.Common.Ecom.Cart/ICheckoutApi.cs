using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.DTO;
using Refit;

namespace Auchan.Common.Ecom.Cart;

internal interface ICheckoutApi
{
	[Post("/checkout/commit")]
	[Headers(new string[] { "X-Source: mobile_site", "Content-Type: application/json" })]
	Task<CheckoutCommitResultDto> Commit([Body] CheckoutCommitDto data, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/checkout/thanks")]
	Task<OrderDetailsDto> OrderData([Query] string orderId, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/checkout/thanks")]
	Task<OrderDetailsDto[]> OrderData([Query] string[] orderId, CancellationToken cancellationToken = default(CancellationToken));
}
