using System;
using Auchan.Common.Ecom.Cart.Models;

namespace Auchan.Common.Ecom.Cart;

public sealed class OfferUpdatedEventArgs : EventArgs
{
	public required ProductOffer Offer { get; init; }

	public required Guid RequestId { get; init; }
}
