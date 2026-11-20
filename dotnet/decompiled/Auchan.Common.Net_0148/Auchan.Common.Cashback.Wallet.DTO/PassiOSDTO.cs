using System.IO;
using Newtonsoft.Json;

namespace Auchan.Common.Cashback.Wallet.DTO;

public class PassiOSDTO
{
	[JsonProperty("code")]
	public int Code { get; set; }

	[JsonProperty("message")]
	public string Message { get; set; }

	[JsonIgnore]
	public Stream FileStream { get; set; }
}
