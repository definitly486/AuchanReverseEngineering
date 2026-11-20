using Auchan.Common.Ecom.DTO;
using Newtonsoft.Json;

namespace Auchan.Common.Reviews.Api.Ecom.Dto;

public class UnreviewedProductDto
{
	[JsonProperty("code")]
	public string? Code { get; set; }

	[JsonProperty("gima_id")]
	public string? GimaId { get; set; }

	[JsonProperty("title")]
	public string? Title { get; set; }

	[JsonProperty("imageUrl")]
	public string? ImageUrl { get; set; }

	[JsonProperty("stickers")]
	public ReviewRewardStickerDto? ReviewRewardSticker { get; set; }
}
