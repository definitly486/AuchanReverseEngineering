using System;
using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Dto;

public class FeedbackRespondDto
{
	[JsonProperty("MobilePhone")]
	public string? MobilePhone { get; set; }

	[JsonProperty("GivenName")]
	public string? GivenName { get; set; }

	[JsonProperty("siteCRMId")]
	public Guid SiteCrmId { get; set; }

	[JsonProperty("topic_id")]
	public long TopicId { get; set; }

	[JsonProperty("category_id")]
	public long CategoryId { get; set; }

	[JsonProperty("city_id")]
	public long CityId { get; set; }

	[JsonProperty("site_id")]
	public long SiteId { get; set; }
}
