using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class LoyaltyProgramQrCodeResponseDto
{
	[JsonProperty("data", Required = Required.Always)]
	public LoyaltyProgramQrDataeDto Data { get; set; }
}
