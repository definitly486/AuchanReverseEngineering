using System;

namespace Auchan.Common.Recommendations;

internal static class RecommendationConfiguration
{
	public static readonly TimeSpan MaxCacheTime = TimeSpan.FromMinutes(2L);
}
