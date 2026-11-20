using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.PersonalOffers.DTO;

public class PersonalOffersResponseDto
{
	[JsonProperty("items")]
	public List<PersonalOfferDto> Items = new List<PersonalOfferDto>();

	[JsonProperty("total")]
	public long TotalCount;
}
