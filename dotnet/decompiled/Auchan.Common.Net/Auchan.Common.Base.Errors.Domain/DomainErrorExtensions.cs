using Auchan.Common.Base.Errors.Service;

namespace Auchan.Common.Base.Errors.Domain;

public static class DomainErrorExtensions
{
	public static ServiceError WrapIntoServiceError(this DomainError domainError)
	{
		return new PackagedDomainErrorServiceError(domainError);
	}
}
