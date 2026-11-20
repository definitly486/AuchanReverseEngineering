using Newtonsoft.Json;

namespace Auchan.Common.Profile.UserCards.DTO;

public class CreateTokenResponseDto : TokenListResponseDto
{
	[JsonProperty("refNumber")]
	public string RefNumber { get; set; }

	[JsonProperty("extTxnId")]
	public string ExtTxnId { get; set; }

	[JsonProperty("tokenUrl")]
	public string TokenUrl { get; set; }
}
