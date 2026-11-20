using Newtonsoft.Json;

namespace Auchan.Common.Profile.UserCards.DTO;

public class DeleteTokenResponseDto : TokenListResponseDto
{
	[JsonProperty("refNumber")]
	public string RefNumber { get; set; }
}
