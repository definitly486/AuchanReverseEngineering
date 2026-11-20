using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record Replacement
{
	public required int Id { get; init; }

	public required string Name { get; init; }

	public required bool IsDefault { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private Replacement(Replacement original)
	{
		Id = original.Id;
		Name = original.Name;
		IsDefault = original.IsDefault;
	}

	public Replacement()
	{
	}
}
