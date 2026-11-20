using Newtonsoft.Json;

namespace Auchan.Common.PersonalOffers.DTO;

public class ActivatePersonalOfferRequestDto
{
	[JsonProperty("loymax_id")]
	public string LoymaxOfferId { get; set; }

	public ActivatePersonalOfferRequestDto(string loymaxOfferId)
	{
		LoymaxOfferId = loymaxOfferId;
	}
}
