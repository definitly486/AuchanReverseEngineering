using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record CheckoutCar
{
	public required string? Color { get; init; }

	public required string? Brand { get; init; }

	public required string? Number { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CheckoutCar(CheckoutCar original)
	{
		Color = original.Color;
		Brand = original.Brand;
		Number = original.Number;
	}

	public CheckoutCar()
	{
	}
}
