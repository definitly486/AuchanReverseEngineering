using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Analytics.Loymax.DTO;
using Refit;

namespace Auchan.Common.Analytics.Loymax;

[Headers(new string[] { "Authorization: Basic Z3M6Z3M=" })]
internal interface ILoymaxAnalyticsApi
{
	[Post("/communication/web-event")]
	Task<LoymaxResponseDto> WebEventAsync([Header("X-Token-CMD")] string token80, [Body] WebEventRequestDto webEventRequestDto, CancellationToken cancellationToken = default(CancellationToken));
}
