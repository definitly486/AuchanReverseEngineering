using Newtonsoft.Json;

namespace Auchan.Common.Feedback;

public sealed class FeedbackStore
{
	[JsonProperty("id")]
	public string Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("address")]
	public string Address { get; set; }

	public FeedbackStore(string id, string name, string address)
	{
		Id = id;
		Name = name;
		Address = address;
	}
}
