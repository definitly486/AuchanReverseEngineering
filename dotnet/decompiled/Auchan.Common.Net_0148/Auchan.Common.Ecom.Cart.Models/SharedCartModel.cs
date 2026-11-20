using System;
using System.Collections.Generic;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed class SharedCartModel
{
	public IReadOnlyList<ProductOffer> Available { get; init; } = Array.Empty<ProductOffer>();

	public IReadOnlyList<ProductOffer> Unavailable { get; init; } = Array.Empty<ProductOffer>();

	public int Count { get; init; }

	public bool IsAdult { get; init; }

	public decimal TotalPrice { get; init; }
}
