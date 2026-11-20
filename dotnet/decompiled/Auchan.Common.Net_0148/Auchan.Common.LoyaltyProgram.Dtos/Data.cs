using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class Data
{
	[JsonProperty("incoming_id")]
	public int IncomingId { get; set; }

	[JsonProperty("outcoming_id")]
	public int OutcomingId { get; set; }
}
