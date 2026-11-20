using Newtonsoft.Json;

namespace Auchan.Common.PersonalOffers.DTO;

public class PersonalOffersRequestDto
{
	[JsonProperty("page")]
	public long Page;

	[JsonProperty("perPage")]
	public long PerPage;
}
