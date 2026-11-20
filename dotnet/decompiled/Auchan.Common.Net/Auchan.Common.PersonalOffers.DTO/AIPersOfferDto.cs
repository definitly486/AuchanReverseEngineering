using System;
using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Common.PersonalOffers.DTO;

public class AIPersOfferDto
{
	[JsonProperty("code", Required = Required.Always)]
	public string Code { get; set; }

	[JsonProperty("title_listing", Required = Required.Always)]
	public string Title { get; set; }

	[JsonProperty("subtitle_listing", Required = Required.Always)]
	public string Subtitle { get; set; }

	[JsonProperty("mobile_preview_file_url", Required = Required.Always)]
	public string Image { get; set; }

	[JsonProperty("background", Required = Required.Always)]
	public string BackgroundHex { get; set; }

	[JsonProperty("gima_id")]
	public string GimaIds { get; set; } = "";

	[JsonProperty("date_end")]
	public DateTime? EndsOn { get; set; }

	[JsonProperty("loymax_offer_type")]
	[JsonConverter(typeof(EnumMemberJsonConverter<LoymaxOfferType>))]
	public LoymaxOfferType LoymaxOfferType { get; set; }

	[JsonProperty("title_detail")]
	public string DetailsTitle { get; set; }

	[JsonProperty("description")]
	public string DetailsDescription { get; set; }
}
