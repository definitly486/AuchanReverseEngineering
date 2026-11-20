using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Reviews.Api.Ecom.Dto;

public class ReviewFormSettingsDataDto
{
	[JsonProperty("trigger_words")]
	public IReadOnlyList<ReviewFormSettingsTriggerWordDto>? TriggerWords { get; set; }

	[JsonProperty("comment_small_text")]
	public string? CommentSmallText { get; set; }

	[JsonProperty("comment_long_text")]
	public string? CommentLongText { get; set; }
}
