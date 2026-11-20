using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

public sealed class AcknowledgeDto
{
	[JsonProperty("event")]
	public string Event { get; } = "acknowledge";

	[JsonProperty("in_seq")]
	public int InSeq { get; }

	public AcknowledgeDto(int outSeq)
	{
		InSeq = outSeq;
		base._002Ector();
	}
}
