using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

internal sealed record ChatConfigurationResponseDto
{
	public sealed record DataDto
	{
		[JsonProperty("file_service_connector_address_mobile")]
		public required string FileServiceConnector { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private DataDto(DataDto original)
		{
			FileServiceConnector = original.FileServiceConnector;
		}

		public DataDto()
		{
		}
	}

	[JsonProperty("data")]
	public required DataDto Data { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ChatConfigurationResponseDto(ChatConfigurationResponseDto original)
	{
		Data = original.Data;
	}

	public ChatConfigurationResponseDto()
	{
	}
}
