using Newtonsoft.Json;

namespace Auchan.Common.PersonalOffers.DTO;

public class PersonalOfferDetailsResponseDto
{
	[JsonProperty("item")]
	public PersonalOfferDto Item;
}
