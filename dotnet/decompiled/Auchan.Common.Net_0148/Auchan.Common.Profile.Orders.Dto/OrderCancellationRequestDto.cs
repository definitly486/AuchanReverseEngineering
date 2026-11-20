using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

public sealed class OrderCancellationRequestDto
{
	[JsonProperty("cancellation_reason_id")]
	public int Id { get; }

	[JsonProperty("comment")]
	public string? Comment { get; }

	public OrderCancellationRequestDto(int id, string? comment = null)
	{
		Id = id;
		Comment = comment;
	}
}
