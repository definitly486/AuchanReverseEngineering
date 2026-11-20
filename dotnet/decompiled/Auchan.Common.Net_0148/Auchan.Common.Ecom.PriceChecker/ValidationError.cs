using Auchan.Common.Base.Errors.Domain;

namespace Auchan.Common.Ecom.PriceChecker;

public sealed class ValidationError : DomainError
{
	public required string Barcode { get; init; }
}
