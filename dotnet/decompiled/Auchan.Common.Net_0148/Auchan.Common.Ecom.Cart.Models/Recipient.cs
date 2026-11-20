using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record Recipient
{
	public required string Name { get; init; }

	public required string Phone { get; init; }

	public required string Email { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private Recipient(Recipient original)
	{
		Name = original.Name;
		Phone = original.Phone;
		Email = original.Email;
	}

	public Recipient()
	{
	}
}
