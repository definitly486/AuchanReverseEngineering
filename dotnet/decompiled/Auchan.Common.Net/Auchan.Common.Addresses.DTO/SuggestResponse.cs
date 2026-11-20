using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Addresses.DTO;

public class SuggestResponse
{
	[JsonProperty("suggestions")]
	public List<SuggestionDto> Suggestions { get; set; }
}
