using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos.Triggers;

public class LoyaltyDto
{
	[JsonProperty("step_one")]
	public StepOneDto? StepOne { get; set; }

	[JsonProperty("step_two")]
	public StepTwoDto? StepTwo { get; set; }
}
