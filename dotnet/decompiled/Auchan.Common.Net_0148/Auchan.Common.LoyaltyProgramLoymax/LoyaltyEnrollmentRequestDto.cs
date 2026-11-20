using System.Runtime.Serialization;
using Auchan.Common.PersonalCabinet.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class LoyaltyEnrollmentRequestDto
{
	public enum ChannelDto
	{
		[EnumMember(Value = "MobileApplication")]
		MobileApplication,
		[EnumMember(Value = "VK")]
		VK
	}

	[JsonProperty("profile")]
	public required ProfileSnackCaseDto Profile { get; init; }

	[JsonProperty("card_number")]
	public string? CardNumber { get; init; }

	[JsonProperty("cvc_code")]
	public string? CvcCode { get; init; }

	[JsonProperty("channel")]
	[JsonConverter(typeof(StringEnumConverter))]
	public required ChannelDto Channel { get; init; }
}
