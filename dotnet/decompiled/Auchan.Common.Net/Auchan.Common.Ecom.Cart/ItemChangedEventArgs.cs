using System;
using Auchan.Common.Ecom.Cart.Models;

namespace Auchan.Common.Ecom.Cart;

public sealed class ItemChangedEventArgs : EventArgs
{
	public required ProductOffer Offer { get; init; }

	public required ProductOfferChange Change { get; init; }

	public required Guid RequestId { get; init; }

	public required ItemChangedEventType EventType { get; init; }
}
