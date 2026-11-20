using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record PromocodeCondition
{
	public required bool IsSuccess { get; init; }

	public required string PromoCode { get; init; }

	public required string? Message { get; init; }

	public required string? LinkName { get; init; }

	public required string? Slug { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private PromocodeCondition(PromocodeCondition original)
	{
		IsSuccess = original.IsSuccess;
		PromoCode = original.PromoCode;
		Message = original.Message;
		LinkName = original.LinkName;
		Slug = original.Slug;
	}

	public PromocodeCondition()
	{
	}
}
