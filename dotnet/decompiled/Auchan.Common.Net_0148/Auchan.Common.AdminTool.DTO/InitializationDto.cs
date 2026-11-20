using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class InitializationDto
{
	[JsonProperty("udid")]
	public UdidDto UdidDto { get; set; }

	[JsonProperty("app_config")]
	public AppConfigDto AppConfigDto { get; set; }

	[JsonProperty("extra_promotions")]
	public List<ExtraPromotionDto> ExtraPromotionDtos { get; set; }
}
