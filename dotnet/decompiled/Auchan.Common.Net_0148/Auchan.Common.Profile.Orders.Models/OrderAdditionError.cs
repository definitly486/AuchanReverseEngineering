using Auchan.Common.Base.Errors.Domain;

namespace Auchan.Common.Profile.Orders.Models;

internal sealed class OrderAdditionError : DomainError
{
	public required string? Details { get; init; }
}
