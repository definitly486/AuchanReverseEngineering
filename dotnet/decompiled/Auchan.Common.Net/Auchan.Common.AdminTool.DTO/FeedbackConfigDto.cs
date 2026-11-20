using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class FeedbackConfigDto
{
	[JsonProperty("phone_number")]
	public string PhoneNumber { get; set; }

	[JsonProperty("email")]
	public string Email { get; set; }
}
