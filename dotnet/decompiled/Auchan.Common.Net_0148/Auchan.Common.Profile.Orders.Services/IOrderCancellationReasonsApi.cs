using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Profile.Orders.Dto;
using Refit;

namespace Auchan.Common.Profile.Orders.Services;

public interface IOrderCancellationReasonsApi
{
	[Get("/cancellation-reasons")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<PossibleOrderCancellationReasonsDto> GetOrderCancellationReasonsAsync(CancellationToken cancellationToken = default(CancellationToken));
}
