using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class InformersDto
{
	[JsonProperty("data")]
	public List<InformerDto> Data { get; set; } = new List<InformerDto>();
}
