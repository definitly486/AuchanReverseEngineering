using Auchan.Common.Profile.Orders.Enums;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

public sealed record PaymentDto
{
	[JsonProperty("payment_method")]
	public PaymentMethod PaymentMethod { get; init; }
}
