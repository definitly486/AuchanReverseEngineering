using Newtonsoft.Json;

namespace Auchan.Common.Cashback.Wallet.DTO;

public class PassAndroidDTO
{
	[JsonProperty("code")]
	public int Code { get; set; }

	[JsonProperty("message")]
	public string Message { get; set; }

	[JsonProperty("add_url")]
	public string AddUrl { get; set; }
}
