using System.Collections.Generic;
using Auchan.Common.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.InfoPages.DTO;

public class InfoResponseDto
{
	[JsonProperty("kind")]
	[JsonConverter(typeof(StringEnumConverter))]
	public InfoContentType ContentType { get; set; }

	[JsonProperty("position")]
	[JsonConverter(typeof(StringEnumConverter))]
	public InfoPagePosition Position { get; set; }

	[JsonProperty("url")]
	public string? Url { get; set; }

	[JsonProperty("name")]
	public string? Title { get; set; }

	[JsonProperty("description")]
	public string? Content { get; set; }

	[JsonProperty("bannerUrl")]
	public string? BannerUrl { get; set; }

	[JsonProperty("iconUrl")]
	public string? IconUrl { get; set; }

	[JsonProperty("slug")]
	public string Slug { get; set; }

	[JsonProperty("non_field_errors")]
	public List<InfoResponseError>? Errors { get; set; }

	[JsonProperty("audience")]
	[JsonConverter(typeof(EnumMemberJsonConverter<AudienceType>))]
	public AudienceType Audience { get; set; }

	public InfoResponseDto(InfoContentType infoContentType, string? url, string? title, string? content, string? bannerUrl, string? iconUrl, string slug)
	{
		ContentType = infoContentType;
		Url = url;
		Title = title;
		Content = content;
		BannerUrl = bannerUrl;
		IconUrl = iconUrl;
		Slug = slug;
	}
}
