using System;
using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Common.PersonalOffers.DTO;

public class PersonalOfferDto
{
	[JsonProperty("date_end")]
	public DateTime? EndsOn { get; set; }

	[JsonProperty("title", Required = Required.Always)]
	public string Title { get; set; }

	[JsonProperty("subtitle", Required = Required.Always)]
	public string Subtitle { get; set; }

	[JsonProperty("mobile_text", Required = Required.Default)]
	public string Text { get; set; } = "";

	[JsonProperty("code", Required = Required.Always)]
	public string Code { get; set; }

	[JsonProperty("loymax_id", Required = Required.Always)]
	public string LoymaxId { get; set; } = "";

	[JsonProperty("mobile_preview_file_url", Required = Required.Always)]
	public string Image { get; set; }

	[JsonProperty("mobile_preview_file_id", Required = Required.Default)]
	public long ImageId { get; set; }

	[JsonProperty("accepted", Required = Required.Default)]
	public bool Accepted { get; set; }

	[JsonProperty("background", Required = Required.Always)]
	public string BackgroundHex { get; set; }

	[JsonProperty("type_preference")]
	[JsonConverter(typeof(EnumMemberJsonConverter<PersOfferType>))]
	public PersOfferType OfferType { get; set; }
}
