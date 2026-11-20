using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.PersonalCabinet.DTO;
using Refit;

namespace Auchan.Common.PersonalCabinet;

internal interface IVkAuthApi
{
	[Get("/init")]
	Task<VkInitResponseDto> InitAsync(CancellationToken cancellationToken = default(CancellationToken));

	[Post("/token")]
	Task<VkTokenResponseDto> Token([Body] VkTokenRequestDto request, CancellationToken cancellationToken = default(CancellationToken));
}
