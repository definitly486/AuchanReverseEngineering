using Newtonsoft.Json;

namespace Auchan.Common.InfoPages.DTO;

public class InfoResponseError
{
	[JsonProperty("code")]
	public string Code { get; set; }

	[JsonProperty("message")]
	public string Message { get; set; }

	public InfoResponseError(string code, string message)
	{
		Code = code;
		Message = message;
	}
}
