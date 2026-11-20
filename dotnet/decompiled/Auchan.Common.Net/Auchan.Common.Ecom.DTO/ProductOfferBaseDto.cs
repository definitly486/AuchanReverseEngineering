using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class ProductOfferBaseDto
{
	[JsonProperty("offerId", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
	public long? OfferId { get; set; }

	[JsonProperty("productId", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
	public long? ProductId { get; set; }

	[JsonProperty("selectedModifications", NullValueHandling = NullValueHandling.Ignore)]
	public IReadOnlyList<SelectedModificationDto>? SelectedModifications { get; set; }

	[JsonProperty("comment")]
	public string? Comment { get; set; }
}
