using System;
using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Responses;

public class Shop
{
	[JsonProperty("id")]
	public long Id { get; set; }

	[JsonProperty("site_crm_id")]
	public Guid SiteCrmId { get; set; }

	[JsonProperty("city_id")]
	public long CityId { get; set; }

	[JsonProperty("site")]
	public string? Site { get; set; }

	[JsonProperty("site_label")]
	public string? SiteLabel { get; set; }

	[JsonProperty("site_alias")]
	public string? SiteAlias { get; set; }
}
