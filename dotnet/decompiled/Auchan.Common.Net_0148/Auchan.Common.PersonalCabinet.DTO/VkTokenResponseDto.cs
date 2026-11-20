using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Auchan.Common.Ecom.DTO;
using Newtonsoft.Json;

namespace Auchan.Common.PersonalCabinet.DTO;

internal sealed record VkTokenResponseDto : ApiV2ResponseDto
{
	public sealed record DataDto
	{
		[JsonProperty("profile")]
		public required ProfileSnackCaseDto Profile { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private DataDto(DataDto original)
		{
			Profile = original.Profile;
		}

		public DataDto()
		{
		}
	}

	public enum StatusDto
	{
		[EnumMember(Value = "unregistered")]
		Unregistered,
		[EnumMember(Value = "unchanged")]
		Unchanged,
		[EnumMember(Value = "updated")]
		Updated
	}

	[JsonProperty("data")]
	public required DataDto Data { get; init; }

	[JsonProperty("token")]
	public required string Token { get; init; }

	[JsonProperty("user_data_status")]
	public required StatusDto Status { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private VkTokenResponseDto(VkTokenResponseDto original)
		: base(original)
	{
		Data = original.Data;
		Token = original.Token;
		Status = original.Status;
	}

	public VkTokenResponseDto()
	{
	}
}
