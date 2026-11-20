using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Ecom.PriceChecker;

public sealed class ValidationResult
{
	public required Product Product { get; init; }

	public required bool IsOnline { get; init; }

	public required string Barcode { get; init; }
}
