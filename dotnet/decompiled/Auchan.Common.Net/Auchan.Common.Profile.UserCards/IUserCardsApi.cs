using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Profile.UserCards.DTO;
using Refit;

namespace Auchan.Common.Profile.UserCards;

public interface IUserCardsApi
{
	[Get("/getTokenList?customerId={magentoAccountId}")]
	Task<TokenListResponseDto> Tokens(string magentoAccountId, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/createTokenValidate")]
	Task<CreateTokenResponseDto> CreateTokenValidate([Body] CreateTokenRequestDto requestDto, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/deleteToken")]
	Task<DeleteTokenResponseDto> DeleteToken([Body] DeleteTokenRequestDto request, CancellationToken cancellationToken = default(CancellationToken));
}
