using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Auchan.Common.Ecom.ProducModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.Ecom.DTO;

public sealed record CashbackDto
{
	public enum PointsTypeDto
	{
		Unknown,
		[EnumMember(Value = "AUCH_PT")]
		Basic,
		[EnumMember(Value = "EXTRA_PT")]
		Express
	}

	[JsonProperty("point")]
	public required int? Point { get; init; }

	[JsonProperty("percent")]
	public required int? Percent { get; init; }

	[JsonConverter(typeof(StringEnumConverter))]
	[JsonProperty("limit_type")]
	public required LimitType? LimitType { get; init; }

	[JsonProperty("limit")]
	public required decimal? Limit { get; init; }

	[JsonProperty("is_delayed")]
	public required bool? IsDelayed { get; init; }

	[JsonProperty("points_type")]
	public required PointsTypeDto PointsType { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CashbackDto(CashbackDto original)
	{
		Point = original.Point;
		Percent = original.Percent;
		LimitType = original.LimitType;
		Limit = original.Limit;
		IsDelayed = original.IsDelayed;
		PointsType = original.PointsType;
	}

	public CashbackDto()
	{
	}
}
