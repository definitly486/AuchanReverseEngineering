using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class SuggestGeocodeResponseDto
{
	public sealed class DataDto
	{
		public sealed record Suggest
		{
			[JsonProperty("region_id")]
			public int? RegionId { get; init; }

			[JsonProperty("is_full")]
			public bool IsFull { get; init; }

			[JsonProperty("address")]
			public UserAddress? Address { get; init; }

			[JsonProperty("uri")]
			public string? Uri { get; init; }
		}

		[JsonProperty("need_house")]
		public bool IsNeedHouse { get; init; }

		[JsonProperty("success")]
		public bool Success { get; init; }

		[JsonProperty("suggests")]
		public IReadOnlyList<Suggest>? Suggests { get; init; }
	}

	[JsonProperty("data")]
	public DataDto? Data { get; init; }
}
