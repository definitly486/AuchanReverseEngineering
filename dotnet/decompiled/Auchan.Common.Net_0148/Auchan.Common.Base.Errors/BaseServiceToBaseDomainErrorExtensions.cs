using Auchan.Common.AdminTool;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.PersonalCabinet.DTO;
using Auchan.Common.PersonalCabinet.Errors;

namespace Auchan.Common.Base.Errors;

public static class BaseServiceToBaseDomainErrorExtensions
{
	public static DomainError ToBaseDomainError(this ServiceError serviceError)
	{
		if (!(serviceError is Auchan.Common.Base.Errors.Service.ConnectionError connectionError))
		{
			if (!(serviceError is Auchan.Common.Base.Errors.Service.TimeoutError timeoutError))
			{
				if (!(serviceError is Auchan.Common.Base.Errors.Service.CancellationError cancellationError))
				{
					if (!(serviceError is ApiContractError apiContractError))
					{
						UnsuccessfulStatusCodeError unsuccessfulStatusCodeError2;
						if (serviceError is UnsuccessfulStatusCodeError<GenericError> unsuccessfulStatusCodeError)
						{
							GenericError content = unsuccessfulStatusCodeError.Content;
							if (content != null && content.Error == 102)
							{
								return new SessionExpiredError
								{
									Message = $"{unsuccessfulStatusCodeError.StatusCode}: {unsuccessfulStatusCodeError.Message} {unsuccessfulStatusCodeError.Exception}"
								};
							}
							unsuccessfulStatusCodeError2 = (UnsuccessfulStatusCodeError)serviceError;
						}
						else
						{
							unsuccessfulStatusCodeError2 = serviceError as UnsuccessfulStatusCodeError;
							if (unsuccessfulStatusCodeError2 == null)
							{
								if (!(serviceError is QratorError qratorError))
								{
									if (!(serviceError is VpnError vpnError))
									{
										if (!(serviceError is PackagedDomainErrorServiceError packagedDomainErrorServiceError))
										{
											if (serviceError != null)
											{
												return new UnknownError
												{
													Message = $"{serviceError.Message}: {serviceError.Exception}"
												};
											}
											global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(serviceError);
											DomainError result = default(DomainError);
											return result;
										}
										return packagedDomainErrorServiceError.DomainError;
									}
									return new DisableVpnError
									{
										Message = $"{vpnError.Message}: {vpnError.Exception}"
									};
								}
								return new UpdateRequiredError($"{qratorError.Message}: {qratorError.Exception}" ?? string.Empty);
							}
						}
						return new NoDataError
						{
							Message = $"{unsuccessfulStatusCodeError2.StatusCode}: {unsuccessfulStatusCodeError2.HttpMessage} {unsuccessfulStatusCodeError2.Message}"
						};
					}
					return new NoDataError
					{
						Message = $"{apiContractError.Message}: {apiContractError.Exception}"
					};
				}
				return new Auchan.Common.Base.Errors.Domain.CancellationError
				{
					Message = $"{cancellationError.Message}: {cancellationError.Exception}"
				};
			}
			return new Auchan.Common.Base.Errors.Domain.TimeoutError
			{
				Message = $"{timeoutError.Message}: {timeoutError.Exception}"
			};
		}
		return new Auchan.Common.Base.Errors.Domain.ConnectionError
		{
			Message = $"{connectionError.Message}: {connectionError.Exception}"
		};
	}
}
