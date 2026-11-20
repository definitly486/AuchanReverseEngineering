using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record ChangeItemsResult
{
	public required IReadOnlyList<ProductOfferChange> Items { get; init; }

	public required IReadOnlyList<ChangedItem> Changes { get; init; }

	public static ChangeItemsResult Empty { get; } = new ChangeItemsResult
	{
		Items = Array.Empty<ProductOfferChange>(),
		Changes = Array.Empty<ChangedItem>()
	};

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ChangeItemsResult(ChangeItemsResult original)
	{
		Items = original.Items;
		Changes = original.Changes;
	}

	public ChangeItemsResult()
	{
	}
}
