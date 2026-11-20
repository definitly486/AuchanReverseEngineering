using System.Runtime.Serialization;
using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public sealed class RetailRocketFeatureDto
{
	public enum CodeDto
	{
		Unknown,
		[EnumMember(Value = "personalizedCategory")]
		PersonalizedCategory
	}

	[JsonProperty("code")]
	[JsonConverter(typeof(EnumMemberJsonConverter<CodeDto>))]
	public required CodeDto Code { get; init; }

	[JsonProperty("active")]
	public bool? Active { get; init; }
}
