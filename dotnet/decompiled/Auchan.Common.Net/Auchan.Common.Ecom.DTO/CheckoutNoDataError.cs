using Auchan.Common.Base.Errors.Domain;

namespace Auchan.Common.Ecom.DTO;

public sealed class CheckoutNoDataError : DomainError
{
	public string? Errors { get; set; }

	public string? Link { get; set; }
}
