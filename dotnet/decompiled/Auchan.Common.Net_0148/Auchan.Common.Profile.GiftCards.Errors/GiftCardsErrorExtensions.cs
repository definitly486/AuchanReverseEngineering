using System;
using System.Net;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Profile.GiftCards.Infrastructure;

namespace Auchan.Common.Profile.GiftCards.Errors;

public static class GiftCardsErrorExtensions
{
	public static DomainError ToGiftCardError(this ServiceError serviceError)
	{
		try
		{
			if (serviceError is IUnsuccessfulStatusCodeError<GiftCardDataDTO> unsuccessfulStatusCodeError)
			{
				if (unsuccessfulStatusCodeError.StatusCode == HttpStatusCode.BadRequest)
				{
					return new GiftCardError
					{
						Message = unsuccessfulStatusCodeError.Content.ErrorText,
						StatusCode = unsuccessfulStatusCodeError.StatusCode
					};
				}
				return new GiftCardError
				{
					Message = unsuccessfulStatusCodeError.Message,
					StatusCode = unsuccessfulStatusCodeError.StatusCode
				};
			}
		}
		catch (Exception ex)
		{
			DevAnalytics.Report("Gift cart error", ex);
		}
		return serviceError.ToBaseDomainError();
	}
}
