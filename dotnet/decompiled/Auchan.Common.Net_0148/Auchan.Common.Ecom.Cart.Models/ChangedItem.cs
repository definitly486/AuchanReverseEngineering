using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record ChangedItem
{
	public required bool IsAdded { get; init; }

	public required long OfferId { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ChangedItem(ChangedItem original)
	{
		IsAdded = original.IsAdded;
		OfferId = original.OfferId;
	}

	public ChangedItem()
	{
	}
}
