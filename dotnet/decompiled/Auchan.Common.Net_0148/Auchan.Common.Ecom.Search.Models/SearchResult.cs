using System.Collections.Generic;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Ecom.Search.Models;

public class SearchResult
{
	public IReadOnlyDictionary<string, CategoryWithProduct>? Items { get; init; }

	public IReadOnlyList<SearchFilter>? Filters { get; init; }

	public IReadOnlyDictionary<string, object>? SelectedFilters { get; init; }

	public int Count { get; init; }

	public string Sort { get; init; } = "default";
}
