using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public class UdidPayload
{
	[JsonProperty("udid")]
	public string Value { get; }

	public UdidPayload(string value)
	{
		Value = value;
	}

	public static implicit operator UdidPayload(string udid)
	{
		return new UdidPayload(udid);
	}
}
