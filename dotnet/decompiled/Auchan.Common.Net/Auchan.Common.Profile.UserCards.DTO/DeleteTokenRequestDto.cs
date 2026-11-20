using Newtonsoft.Json;

namespace Auchan.Common.Profile.UserCards.DTO;

public class DeleteTokenRequestDto
{
	[JsonProperty("refNumber")]
	public string RefNumber { get; set; }

	[JsonProperty("tokenId")]
	public string TokenId { get; set; }
}
