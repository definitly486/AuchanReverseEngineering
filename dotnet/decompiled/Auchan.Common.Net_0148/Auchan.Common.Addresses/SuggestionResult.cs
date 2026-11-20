using System;
using System.Collections.Generic;

namespace Auchan.Common.Addresses;

public sealed record SuggestionResult
{
	public bool IsNeedHouse { get; init; }

	public bool IsSuccess { get; init; }

	public IReadOnlyList<Suggestion> Suggestions { get; init; } = Array.Empty<Suggestion>();
}
