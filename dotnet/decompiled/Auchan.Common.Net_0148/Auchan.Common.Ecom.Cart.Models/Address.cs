using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record Address
{
	public required string AddressText { get; init; }

	public required string? Flat { get; init; }

	public required string? Floor { get; init; }

	public required string? Porch { get; init; }

	public required string? Intercom { get; init; }

	public required string? Comment { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private Address(Address original)
	{
		AddressText = original.AddressText;
		Flat = original.Flat;
		Floor = original.Floor;
		Porch = original.Porch;
		Intercom = original.Intercom;
		Comment = original.Comment;
	}

	public Address()
	{
	}
}
