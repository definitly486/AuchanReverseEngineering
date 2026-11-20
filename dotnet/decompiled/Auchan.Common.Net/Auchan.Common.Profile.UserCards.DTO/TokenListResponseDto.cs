using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.UserCards.DTO;

public class TokenListResponseDto : BaseProcessingResponseDto
{
	[JsonProperty("tokens", Required = Required.Default)]
	public List<CardDto>? Cards { get; set; }
}
