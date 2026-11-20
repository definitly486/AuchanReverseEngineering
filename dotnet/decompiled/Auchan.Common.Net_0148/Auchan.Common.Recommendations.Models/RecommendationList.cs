using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Recommendations.Models;

public sealed record RecommendationList
{
	public sealed record Item
	{
		public required string GimaId { get; init; }

		public required RecommendationAnalyticsInfo AnalyticsInfo { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private Item(Item original)
		{
			GimaId = original.GimaId;
			AnalyticsInfo = original.AnalyticsInfo;
		}

		public Item()
		{
		}
	}

	public required IReadOnlyList<Item> Items { get; init; }

	public TimeSpan CacheTime { get; set; }

	public bool HasCacheControl => CacheTime > TimeSpan.Zero;

	public RecommendationList MergeWith(RecommendationList other)
	{
		HashSet<string> hashSet = new HashSet<string>();
		int num = 0;
		ImmutableList<Item>.Builder builder = ImmutableList.CreateBuilder<Item>();
		foreach (Item item in Items.Concat(other.Items))
		{
			if (hashSet.Contains(item.GimaId))
			{
				num++;
				continue;
			}
			hashSet.Add(item.GimaId);
			builder.Add(item);
		}
		TimeSpan cacheTime = TimeSpan.Zero;
		if (CacheTime > TimeSpan.Zero && other.CacheTime > TimeSpan.Zero)
		{
			cacheTime = ((CacheTime > other.CacheTime) ? other.CacheTime : CacheTime);
		}
		else if (CacheTime > TimeSpan.Zero)
		{
			cacheTime = CacheTime;
		}
		else if (other.CacheTime > TimeSpan.Zero)
		{
			cacheTime = other.CacheTime;
		}
		return new RecommendationList
		{
			Items = builder.ToImmutable(),
			CacheTime = cacheTime
		};
	}

	[CompilerGenerated]
	[SetsRequiredMembers]
	private RecommendationList(RecommendationList original)
	{
		Items = original.Items;
		CacheTime = original.CacheTime;
	}

	public RecommendationList()
	{
	}
}
