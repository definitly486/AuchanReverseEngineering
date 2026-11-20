using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.InfoPages.DTO;

public class FAQResponseDto
{
	[JsonProperty("id")]
	public int Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("entries")]
	public List<FAQEntryDto> Entries { get; set; }

	public FAQResponseDto(int id, string name, List<FAQEntryDto> entries)
	{
		Id = id;
		Name = name;
		Entries = entries;
	}
}
