using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class LoyaltyProgramQrDataeDto
{
	[JsonProperty("qr", Required = Required.Always)]
	public string QrCode { get; set; } = "";

	[JsonProperty("card_number", Required = Required.Always)]
	public string CardNumber { get; set; } = "";
}
