using System;
using Newtonsoft.Json;

namespace Auchan.Common.Analytics.Loymax.DTO;

public sealed class WebEventRequestDto
{
	public sealed class ContextDto
	{
		[JsonProperty("MERCHANT_ID")]
		public string? MerchantId { get; set; }
	}

	[JsonProperty("client_id")]
	public required string ClientId { get; init; }

	[JsonProperty("source_code")]
	public string SourceCode => "mobile";

	[JsonProperty("session_id")]
	public required string SessionId { get; init; }

	[JsonProperty("date")]
	public required DateTimeOffset Date { get; init; }

	[JsonProperty("name")]
	public required string Name { get; init; }

	[JsonProperty("category_id")]
	public string? CategoryId { get; set; }

	[JsonProperty("product_id")]
	public string? ProductId { get; set; }

	[JsonProperty("quantity")]
	public decimal? Quantity { get; set; }

	[JsonProperty("price")]
	public decimal? Price { get; set; }

	[JsonProperty("container")]
	public string? Container { get; set; }

	[JsonProperty("context")]
	public ContextDto? Context { get; set; }
}
