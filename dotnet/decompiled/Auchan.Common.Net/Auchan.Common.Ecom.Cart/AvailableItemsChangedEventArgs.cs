using System;
using System.Collections.Generic;
using Auchan.Common.Ecom.Cart.Models;

namespace Auchan.Common.Ecom.Cart;

public sealed class AvailableItemsChangedEventArgs : EventArgs
{
	public required IReadOnlyList<ProductOffer> Available { get; init; }

	public bool IsHavePendingChanges { get; init; }
}
