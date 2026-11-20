using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.PriceChecker.Dto;
using Refit;

namespace Auchan.Common.Ecom.PriceChecker;

public interface IPriceCheckerEventsApi
{
	[Post("/events")]
	Task<object> Events([Header("access_token")] string token, [Body] PriceCheckerMiddleWareEventDto requestDto, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/events")]
	Task<object> Events([Header("access_token")] string token, [Body] PriceCheckerMiddleWareEventDtoAfterOpenPricechecker requestDto, CancellationToken cancellationToken = default(CancellationToken));
}
