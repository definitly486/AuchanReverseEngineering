using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class AppConfigError
{
	[JsonProperty("code")]
	public string Code { get; set; }

	[JsonProperty("message")]
	public string Message { get; set; }

	[JsonProperty("update_id")]
	public string UpdateId { get; set; }

	public AppConfigError(string code, string message, string updateId)
	{
		Code = code;
		Message = message;
		UpdateId = updateId;
	}
}
