using Newtonsoft.Json;

namespace Auchan.Common.Reviews.Api.Ecom.Dto;

public sealed class ProductsPopupResponseDto
{
	public sealed class DataDto
	{
		[JsonProperty("popup_is_needed")]
		public bool PopupNeeded { get; init; }
	}

	[JsonProperty("data")]
	public DataDto? Data { get; init; }
}
