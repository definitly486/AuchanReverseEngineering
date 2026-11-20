using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

internal sealed record ChipsStructMessageReceivedWSDTO : StructMessageReceivedWSDTO
{
	internal sealed record DataDto
	{
		[JsonProperty("purchases")]
		public required IReadOnlyList<PurchaseDto> Purchases { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private DataDto(DataDto original)
		{
			Purchases = original.Purchases;
		}

		public DataDto()
		{
		}
	}

	internal sealed record PurchaseDto
	{
		[JsonProperty("name")]
		public required string Name { get; init; }

		[JsonProperty("store")]
		public required string? Store { get; init; }

		[JsonProperty("qnt")]
		public required int? Quantity { get; init; }

		[JsonProperty("amount")]
		public required decimal? Amount { get; init; }

		[JsonProperty("status")]
		public required string? Status { get; init; }

		[JsonProperty("status_text_color")]
		public required string? StatusForeground { get; init; }

		[JsonProperty("status_bg_color")]
		public required string? StatusBackground { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private PurchaseDto(PurchaseDto original)
		{
			Name = original.Name;
			Store = original.Store;
			Quantity = original.Quantity;
			Amount = original.Amount;
			Status = original.Status;
			StatusForeground = original.StatusForeground;
			StatusBackground = original.StatusBackground;
		}

		public PurchaseDto()
		{
		}
	}

	[JsonIgnore]
	public override CacheMessageType CacheMessageType => CacheMessageType.StructChips;

	[JsonProperty("data")]
	public required DataDto Data { get; init; }

	public const string PREFIX = "[STRUCT=Chips]";

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ChipsStructMessageReceivedWSDTO(ChipsStructMessageReceivedWSDTO original)
		: base(original)
	{
		Data = original.Data;
	}

	public ChipsStructMessageReceivedWSDTO()
	{
	}
}
