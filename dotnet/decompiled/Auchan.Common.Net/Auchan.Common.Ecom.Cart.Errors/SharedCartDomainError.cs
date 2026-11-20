using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.DTO;

namespace Auchan.Common.Ecom.Cart.Errors;

public sealed class SharedCartDomainError : DomainError
{
	public required SharedCartError Code { get; init; }
}
