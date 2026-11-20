using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.Ecom.Onboardings.DTO;

internal sealed class OnboardingsRequestDto
{
	public sealed class FilterDto
	{
		[JsonProperty("merchant_id")]
		public required long MerchantId { get; init; }

		[JsonProperty("os")]
		[JsonConverter(typeof(StringEnumConverter))]
		public required OperatingSystemDto OperatingSystem { get; init; }
	}

	public enum OperatingSystemDto
	{
		[EnumMember(Value = "i")]
		IOS,
		[EnumMember(Value = "a")]
		Android
	}

	[JsonProperty("filter")]
	public required FilterDto Filter { get; init; }
}
