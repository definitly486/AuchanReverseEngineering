using Newtonsoft.Json;

namespace Auchan.Common.Feedback;

public sealed class FeedbackAttachment
{
	[JsonProperty("id")]
	public int Id { get; set; }

	public FeedbackAttachment(int id)
	{
		Id = id;
	}
}
