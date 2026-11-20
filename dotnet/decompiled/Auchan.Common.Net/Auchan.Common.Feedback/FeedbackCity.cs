using Newtonsoft.Json;

namespace Auchan.Common.Feedback;

public sealed class FeedbackCity
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("fias_id")]
	public string? FiasId { get; set; }

	public FeedbackCity(int id, string name, string? fiasId = null)
	{
		Id = id;
		Name = name;
		FiasId = fiasId;
	}
}
