using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.PersonalOffers.DTO;
using Refit;

namespace Auchan.Common.PersonalOffers;

public interface IPersonalOffersApi
{
	[Post("/lk/loyalty/personal-promotional-offers")]
	Task<AIlOffersResponseDto> AIPersonalOffers([Header("X-Token-CMD")] string token, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/lk/loyalty/personal-suggestions")]
	[Headers(new string[] { "Content-Type: application/json" })]
	Task<PersonalOffersResponseDto> PersonalOffers([Header("X-Token-CMD")] string token, [Body] string body, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/lk/loyalty/personal-suggestions/{code}")]
	Task<PersonalOfferDetailsResponseDto> PersonalOfferDetails([Header("X-Token-CMD")] string token, string code, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/lk/loyalty/personal-promotional-offers/{code}")]
	Task<AIOfferDetailsResponseDto> AIPersonalOfferDetails([Header("X-Token-CMD")] string token, string code, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/lk/loyalty/personal-suggestions:activate")]
	Task<object> ActivatePersonalOffer([Header("X-Token-CMD")] string token, [Body] ActivatePersonalOfferRequestDto body, CancellationToken cancellationToken = default(CancellationToken));
}
