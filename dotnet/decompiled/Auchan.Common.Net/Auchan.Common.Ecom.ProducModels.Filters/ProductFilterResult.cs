using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Auchan.Common.Ecom.ProducModels.Filters;

public sealed class ProductFilterResult
{
	public required IReadOnlyList<ProductFilter> Filters { get; init; }

	public required IReadOnlyList<RequestRedirect> RequiredRedirects { get; init; }

	public required int ProductCount { get; init; }

	public required IReadOnlyDictionary<string, object> SelectedFilters { get; init; }

	public bool IsFiltersSelected => SelectedFilters.Where<KeyValuePair<string, object>>((KeyValuePair<string, object> f) => f.Key != "is_adult").Any();

	public static ProductFilterResult Empty()
	{
		return new ProductFilterResult
		{
			Filters = ImmutableList<ProductFilter>.Empty,
			RequiredRedirects = ImmutableList<RequestRedirect>.Empty,
			ProductCount = 0,
			SelectedFilters = ImmutableDictionary<string, object>.Empty
		};
	}

	public IReadOnlyDictionary<string, object> GetSelectedFiltersForRequest()
	{
		ImmutableDictionary<string, object>.Builder builder = ImmutableDictionary.CreateBuilder<string, object>();
		builder.AddRange(SelectedFilters.Join<KeyValuePair<string, object>, ProductFilter, string, KeyValuePair<string, object>>(Filters, delegate(KeyValuePair<string, object> i)
		{
			KeyValuePair<string, object> keyValuePair = i;
			return keyValuePair.Key;
		}, (ProductFilter j) => j.Code, delegate(KeyValuePair<string, object> i, ProductFilter j)
		{
			string? key = j.Url ?? j.Code;
			KeyValuePair<string, object> keyValuePair = i;
			return new KeyValuePair<string, object>(key, keyValuePair.Value);
		}));
		return builder.ToImmutable();
	}
}
