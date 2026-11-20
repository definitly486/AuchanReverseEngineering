using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Analytics.Loymax.DTO;
using Refit;

namespace Auchan.Common.Analytics.Loymax;

public interface ILoymaxApi
{
	[Post("/communication/pushes")]
	Task<LoymaxResponseDto> CommunicationPushes([Header("X-Token-CMD")] string token80, [Body] LoymaxPushesRequestDto body, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/communication/events")]
	Task<LoymaxResponseDto> CommunicationEvents([Header("X-Token-CMD")] string token80, [Body] LoymaxEventsRequestDto body, CancellationToken cancellationToken = default(CancellationToken));
}
