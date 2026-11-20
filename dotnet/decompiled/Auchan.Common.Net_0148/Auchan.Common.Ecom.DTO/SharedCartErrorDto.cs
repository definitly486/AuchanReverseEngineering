using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class SharedCartErrorDto
{
	[JsonProperty("errors")]
	public string Message { get; init; } = "";

	[JsonProperty("code")]
	public SharedCartError Code { get; init; }
}
