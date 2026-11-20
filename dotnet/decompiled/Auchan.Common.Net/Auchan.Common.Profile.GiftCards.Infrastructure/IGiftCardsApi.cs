using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Auchan.Common.Profile.GiftCards.Infrastructure;

public interface IGiftCardsApi
{
	[Get("/loyalty-gift-card-service/balance")]
	Task<GiftCardDataDTO> GiftCardData([Header("access_token")] string accessToken, [Header("code")] string number, [Header("pin")] string pin, CancellationToken cancellationToken = default(CancellationToken));
}
