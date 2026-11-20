using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public sealed record AdRevenue
{
	public required decimal Revenue { get; init; }

	public required string Currency { get; init; }

	public string? AdNetwork { get; init; }

	public string? AdPlacementID { get; init; }

	public string? AdPlacementName { get; init; }

	public AdType AdType { get; init; }

	public string? AdUnitID { get; init; }

	public string? AdUnitName { get; init; }

	public IReadOnlyDictionary<string, string>? Payload { get; init; }

	public string? Precision { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private AdRevenue(AdRevenue original)
	{
		Revenue = original.Revenue;
		Currency = original.Currency;
		AdNetwork = original.AdNetwork;
		AdPlacementID = original.AdPlacementID;
		AdPlacementName = original.AdPlacementName;
		AdType = original.AdType;
		AdUnitID = original.AdUnitID;
		AdUnitName = original.AdUnitName;
		Payload = original.Payload;
		Precision = original.Precision;
	}

	public AdRevenue()
	{
	}
}
