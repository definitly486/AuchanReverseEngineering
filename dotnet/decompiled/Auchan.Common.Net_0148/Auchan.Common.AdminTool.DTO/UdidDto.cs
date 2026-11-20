using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class UdidDto
{
	[JsonProperty("user_id", Required = Required.Always)]
	public string UserId { get; set; }

	[JsonProperty("key", Required = Required.Always)]
	public string Key { get; set; }
}
