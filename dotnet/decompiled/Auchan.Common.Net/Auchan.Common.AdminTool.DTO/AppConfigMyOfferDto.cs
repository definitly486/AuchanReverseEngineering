using Auchan.Common.Common;
using Auchan.Common.Home.MainMyOffers;
using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class AppConfigMyOfferDto
{
	[JsonProperty("code")]
	[JsonConverter(typeof(EnumMemberJsonConverter<MainMyOfferType>))]
	public MainMyOfferType Code { get; set; }

	[JsonProperty("active")]
	public bool Active { get; set; }

	[JsonProperty("rang")]
	public int Priority { get; set; }

	[JsonProperty("limit")]
	public int? Limit { get; set; }
}
