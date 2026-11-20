using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.PersonalOffers.DTO;

public class AIOfferDetailsResponseDto
{
	[JsonProperty("items")]
	public List<AIPersOfferDto> Items = new List<AIPersOfferDto>();
}
