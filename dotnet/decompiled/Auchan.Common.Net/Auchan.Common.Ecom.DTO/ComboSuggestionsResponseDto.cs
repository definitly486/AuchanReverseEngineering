using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record ComboSuggestionsResponseDto
{
	public sealed record DataDto
	{
		[JsonProperty("combo_status")]
		public required StatusDto Status { get; init; }

		[JsonProperty("tooltip_text_mobile")]
		public required string Tooltip { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private DataDto(DataDto original)
		{
			Status = original.Status;
			Tooltip = original.Tooltip;
		}

		public DataDto()
		{
		}
	}

	public enum StatusDto
	{
		Unknown,
		[EnumMember(Value = "partial")]
		Partial,
		[EnumMember(Value = "fulfilled")]
		Fulfilled
	}

	[JsonProperty("data")]
	public required DataDto Data { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ComboSuggestionsResponseDto(ComboSuggestionsResponseDto original)
	{
		Data = original.Data;
	}

	public ComboSuggestionsResponseDto()
	{
	}
}
