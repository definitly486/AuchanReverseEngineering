using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record CheckoutProduct
{
	public required long OfferId { get; init; }

	public required string? ImageUrl { get; init; }

	public required decimal Qty { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CheckoutProduct(CheckoutProduct original)
	{
		OfferId = original.OfferId;
		ImageUrl = original.ImageUrl;
		Qty = original.Qty;
	}

	public CheckoutProduct()
	{
	}
}
