using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class EnergyValueDto
{
	[JsonProperty("proteins")]
	public float? Proteins { get; init; }

	[JsonProperty("fats")]
	public float? Fats { get; init; }

	[JsonProperty("carbohydrates")]
	public float? Carbs { get; init; }

	[JsonProperty("calories")]
	public float? Calories { get; init; }
}
