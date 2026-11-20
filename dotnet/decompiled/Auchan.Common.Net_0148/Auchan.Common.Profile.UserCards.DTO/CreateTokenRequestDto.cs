using Newtonsoft.Json;

namespace Auchan.Common.Profile.UserCards.DTO;

public class CreateTokenRequestDto
{
	[JsonProperty("refNumber")]
	public string RefNumber { get; set; }

	[JsonProperty("signed_date_time")]
	public string SignedDateTime { get; set; }

	[JsonProperty("thansactionType")]
	public string TransactionType { get; set; }

	[JsonProperty("callbackUrl")]
	public string CallbackUrl { get; set; }
}
