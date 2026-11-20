using System;
using System.Collections.Generic;
using Auchan.Common.Ecom.Cart.Models;

namespace Auchan.Common.Ecom.Cart;

public sealed class CartChangedEventArgs : EventArgs
{
	public required IReadOnlyList<ProductOffer> Available { get; init; }

	public required IReadOnlyList<ProductOffer> Unavailable { get; init; }

	public required bool IsHavePendingChanges { get; init; }
}
