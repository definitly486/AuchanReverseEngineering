using System.Collections.Generic;

namespace Auchan.Common.Ecom.Search.Models;

public class SearchAutohintsResult
{
	public required string Query { get; init; }

	public required string Correction { get; init; }

	public required IReadOnlyList<SearchAutohintPopular> Populars { get; init; }

	public required IReadOnlyList<SearchAutohintAutofill> Autofills { get; init; }

	public required IReadOnlyList<SearchAutohintCategory> Categories { get; init; }
}
