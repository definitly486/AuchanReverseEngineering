using Newtonsoft.Json;

namespace Auchan.Common.Feedback;

public sealed class FeedbackCategory
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("store_related")]
	public bool IsStoreRelated { get; set; }

	[JsonProperty("subjects")]
	public FeedbackSubject[]? Subjects { get; set; }

	public FeedbackCategory(int id, string name, bool isStoreRelated, FeedbackSubject[]? subjects = null)
	{
		Id = id;
		Name = name;
		IsStoreRelated = isStoreRelated;
		Subjects = subjects;
	}
}
