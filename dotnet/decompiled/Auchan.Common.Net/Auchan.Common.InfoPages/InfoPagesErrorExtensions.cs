using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.InfoPages.DomainErrors;
using Auchan.Common.InfoPages.ServiceErrors;

namespace Auchan.Common.InfoPages;

public static class InfoPagesErrorExtensions
{
	public static DomainError ToNoFAQDataError(this ServiceError serviceError)
	{
		if (serviceError is Auchan.Common.InfoPages.ServiceErrors.NoFaqDataError)
		{
			return new Auchan.Common.InfoPages.DomainErrors.NoFaqDataError();
		}
		return serviceError.ToBaseDomainError();
	}

	public static DomainError ToNoTutorialsDataError(this ServiceError serviceError)
	{
		if (serviceError is Auchan.Common.InfoPages.ServiceErrors.NoTutorialsDataError)
		{
			return new Auchan.Common.InfoPages.DomainErrors.NoTutorialsDataError();
		}
		return serviceError.ToBaseDomainError();
	}
}
