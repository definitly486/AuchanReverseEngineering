using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record CheckoutTime
{
	public required string Id { get; init; }

	public required string Slot { get; init; }

	public required string Name { get; init; }

	public required decimal? Price { get; init; }

	public required bool HasSurge { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CheckoutTime(CheckoutTime original)
	{
		Id = original.Id;
		Slot = original.Slot;
		Name = original.Name;
		Price = original.Price;
		HasSurge = original.HasSurge;
	}

	public CheckoutTime()
	{
	}
}
