using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Auchan.Common.StoreReview;

public interface ICustomerFlagApi
{
	[Get("/customers/flags")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<CustomerFlagsResponseDto> GetCustomerFlags([Header("X-Token-CMD")] string token80, CancellationToken cancellationToken = default(CancellationToken));

	[Patch("/customers/flags")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<CustomerFlagsResponseDto> UpdateCustomerFlags([Header("X-Token-CMD")] string token80, [Body] UpdateCustomerFlagsRequestDto request, CancellationToken cancellationToken = default(CancellationToken));
}
