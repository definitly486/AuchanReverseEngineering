using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Common.AdminTool.DTO;

public sealed record StageUrlConfigDto
{
	public enum EnvironmentDto
	{
		Unknown,
		[EnumMember(Value = "Production")]
		Production,
		[EnumMember(Value = "Preproduction")]
		Preproduction,
		[EnumMember(Value = "Stage_1")]
		Stage_1,
		[EnumMember(Value = "Stage_2")]
		Stage_2,
		[EnumMember(Value = "Stage_3")]
		Stage_3,
		[EnumMember(Value = "Stage_4")]
		Stage_4,
		[EnumMember(Value = "Stage_5")]
		Stage_5,
		[EnumMember(Value = "Stage_6")]
		Stage_6,
		[EnumMember(Value = "Stage_7")]
		Stage_7,
		[EnumMember(Value = "Stage_8")]
		Stage_8,
		[EnumMember(Value = "Stage_9")]
		Stage_9,
		[EnumMember(Value = "Stage_10")]
		Stage_10,
		[EnumMember(Value = "Stage_11")]
		Stage_11,
		[EnumMember(Value = "Stage_12")]
		Stage_12,
		[EnumMember(Value = "Stage_13")]
		Stage_13,
		[EnumMember(Value = "Stage_14")]
		Stage_14,
		[EnumMember(Value = "Stage_15")]
		Stage_15,
		[EnumMember(Value = "Stage_16")]
		Stage_16,
		[EnumMember(Value = "Stage_17")]
		Stage_17,
		[EnumMember(Value = "Stage_18")]
		Stage_18,
		[EnumMember(Value = "Stage_19")]
		Stage_19,
		[EnumMember(Value = "Stage_20")]
		Stage_20,
		[EnumMember(Value = "Stage_21")]
		Stage_21,
		[EnumMember(Value = "Stage_22")]
		Stage_22,
		[EnumMember(Value = "Stage_23")]
		Stage_23,
		[EnumMember(Value = "Stage_24")]
		Stage_24,
		[EnumMember(Value = "Stage_25")]
		Stage_25
	}

	[JsonProperty("key")]
	[JsonConverter(typeof(EnumMemberJsonConverter<EnvironmentDto>))]
	public required EnvironmentDto Environment { get; init; }

	[JsonProperty("chatbot_file_service_connector_address")]
	public required string Address { get; init; }

	[JsonProperty("chatbot_websocket_auth_key")]
	public required string WebsocketKey { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private StageUrlConfigDto(StageUrlConfigDto original)
	{
		Environment = original.Environment;
		Address = original.Address;
		WebsocketKey = original.WebsocketKey;
	}

	public StageUrlConfigDto()
	{
	}
}
