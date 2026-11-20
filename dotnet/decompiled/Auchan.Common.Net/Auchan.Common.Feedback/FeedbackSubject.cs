using Newtonsoft.Json;

namespace Auchan.Common.Feedback;

public sealed class FeedbackSubject
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("options")]
	public string[] Flags { get; set; }

	public FeedbackSubject(int id, string name, string[] flags)
	{
		Id = id;
		Name = name;
		Flags = flags;
	}
}
