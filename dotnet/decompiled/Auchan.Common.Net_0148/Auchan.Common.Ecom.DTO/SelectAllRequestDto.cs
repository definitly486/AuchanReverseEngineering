using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class SelectAllRequestDto
{
	[JsonProperty("is_selected")]
	public required bool IsSelected { get; init; }
}
