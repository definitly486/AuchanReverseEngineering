using Auchan.Common.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.Profile.UserCards.DTO;

public class CardDto
{
	[JsonProperty("tokenId", Required = Required.Always)]
	public int Id { get; set; }

	[JsonProperty("pan", Required = Required.Always)]
	public string Pan { get; set; }

	[JsonProperty("description", Required = Required.Default)]
	public string Description { get; set; }

	[JsonProperty("expiredCard", Required = Required.Always)]
	[JsonConverter(typeof(JsonBoolConverter))]
	public bool IsExpired { get; set; }

	[JsonConverter(typeof(StringEnumConverter))]
	[JsonProperty("scheme", Required = Required.Always)]
	public CardSchemeType Scheme { get; set; }
}
