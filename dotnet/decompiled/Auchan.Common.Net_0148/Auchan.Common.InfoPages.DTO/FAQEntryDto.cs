using Newtonsoft.Json;

namespace Auchan.Common.InfoPages.DTO;

public class FAQEntryDto
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("question")]
	public string Question { get; set; }

	[JsonProperty("answer")]
	public string Answer { get; set; }

	public FAQEntryDto(int id, string question, string answer)
	{
		Id = id;
		Question = question;
		Answer = answer;
	}
}
