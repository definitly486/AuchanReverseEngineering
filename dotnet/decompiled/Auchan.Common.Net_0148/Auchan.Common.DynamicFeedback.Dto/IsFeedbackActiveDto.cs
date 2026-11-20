using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Dto;

public class IsFeedbackActiveDto
{
	[JsonProperty("active")]
	public bool IsActive { get; set; }
}
