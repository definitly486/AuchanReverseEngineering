using System.Linq;
using Newtonsoft.Json;

namespace Auchan.Common.Reviews.Api.Ecom.Dto;

public class ReviewFormSettingsResponseDto : ReviewFormSettingsDataDto
{
	[JsonProperty("data")]
	public ReviewFormSettingsDataDto? Data { get; set; }

	public ReviewFormSettingsDataDto? GetPayload()
	{
		if (Data != null)
		{
			return Data;
		}
		if (base.TriggerWords?.Any() != true && string.IsNullOrWhiteSpace(base.CommentSmallText) && string.IsNullOrWhiteSpace(base.CommentLongText))
		{
			return null;
		}
		return this;
	}
}
