using Auchan.Common.Base.Errors.Domain;

namespace Auchan.Common.Base.Errors.Service;

public class PackagedDomainErrorServiceError : ServiceError
{
	public DomainError DomainError { get; }

	public PackagedDomainErrorServiceError(DomainError domainError)
	{
		DomainError = domainError;
	}
}
