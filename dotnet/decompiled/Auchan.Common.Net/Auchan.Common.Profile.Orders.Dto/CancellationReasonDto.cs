using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

public sealed class CancellationReasonDto
{
	[JsonProperty("cancellation_reason_id", Required = Required.Default)]
	public int Id { get; set; }

	[JsonProperty("cancellation_reason")]
	public string Reason { get; set; }

	[JsonProperty("obligatory_of_comment")]
	public bool IsCommentaryObligatory { get; set; }
}
