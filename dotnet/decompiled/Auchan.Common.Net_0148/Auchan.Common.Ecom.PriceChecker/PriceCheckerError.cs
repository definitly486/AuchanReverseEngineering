using Auchan.Common.Base.Errors.Domain;

namespace Auchan.Common.Ecom.PriceChecker;

public sealed class PriceCheckerError : DomainError
{
	public required DomainError InnerError { get; init; }

	public required int StatusCode { get; init; }
}
