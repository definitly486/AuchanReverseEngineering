using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record CheckoutShop
{
	public required string Address { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CheckoutShop(CheckoutShop original)
	{
		Address = original.Address;
	}

	public CheckoutShop()
	{
	}
}
