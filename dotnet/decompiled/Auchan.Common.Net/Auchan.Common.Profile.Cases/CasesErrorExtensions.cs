using System.Net;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;

namespace Auchan.Common.Profile.Cases;

public static class CasesErrorExtensions
{
	public static DomainError ToCasesDomainError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError unsuccessfulStatusCodeError)
		{
			if (unsuccessfulStatusCodeError.StatusCode == HttpStatusCode.NotFound)
			{
				return new NoDataError
				{
					Message = $"{unsuccessfulStatusCodeError.StatusCode}: {unsuccessfulStatusCodeError.HttpMessage} {unsuccessfulStatusCodeError.Message}"
				};
			}
			return new UnknownError
			{
				Message = $"{unsuccessfulStatusCodeError.StatusCode}: {unsuccessfulStatusCodeError.HttpMessage} {unsuccessfulStatusCodeError.Message}"
			};
		}
		return serviceError.ToBaseDomainError();
	}

	public static DomainError ToCaseDetailsDomainError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError unsuccessfulStatusCodeError)
		{
			string message = $"{unsuccessfulStatusCodeError.StatusCode}: {unsuccessfulStatusCodeError.HttpMessage} {unsuccessfulStatusCodeError.Message}";
			if (unsuccessfulStatusCodeError.StatusCode == HttpStatusCode.NotFound)
			{
				if (ContainsAccessError(unsuccessfulStatusCodeError))
				{
					return new CaseDetailsAccessDeniedError
					{
						Message = message
					};
				}
				return new NoDataError
				{
					Message = message
				};
			}
			return new UnknownError
			{
				Message = message
			};
		}
		return serviceError.ToBaseDomainError();
	}

	private static bool ContainsAccessError(IUnsuccessfulStatusCodeError error)
	{
		string? httpMessage = error.HttpMessage;
		if (httpMessage == null || !httpMessage.ContainsIgnoreCase("AccessError"))
		{
			return error.Message?.ContainsIgnoreCase("AccessError") ?? false;
		}
		return true;
	}
}
