using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.PersonalOffers.DTO;

public class AIlOffersResponseDto
{
	[JsonProperty("items")]
	public List<AIPersOfferDto> Items = new List<AIPersOfferDto>();

	[JsonProperty("total")]
	public long TotalCount;
}
