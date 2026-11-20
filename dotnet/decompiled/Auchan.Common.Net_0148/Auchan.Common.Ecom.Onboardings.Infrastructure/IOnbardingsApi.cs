using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.Onboardings.DTO;
using Refit;

namespace Auchan.Common.Ecom.Onboardings.Infrastructure;

internal interface IOnbardingsApi
{
	[Post("/onboardings:search")]
	Task<OnboardingsResponseDto> GetOnboardingsAsync([Header("X-Token-CMD")] string? token, [Body] OnboardingsRequestDto body, CancellationToken cancellationToken = default(CancellationToken));
}
