using Newtonsoft.Json;

namespace Auchan.Common.Cashback.Wallet.DTO;

public class PassCheckAndroidDTO
{
	[JsonProperty("code")]
	public int Code { get; set; }

	[JsonProperty("message")]
	public string Message { get; set; }

	[JsonProperty("can_add")]
	public bool CanAdd { get; set; }
}
