using System.Linq;
using System.Net;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom.Cart.Errors;
using Auchan.Common.Ecom.DTO;

namespace Auchan.Common.Ecom.Cart;

public static class CheckoutErrorExtensions
{
	public static DomainError ToCheckoutCommitError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<CheckoutCommitResultDto> unsuccessfulStatusCodeError)
		{
			if (unsuccessfulStatusCodeError.StatusCode == HttpStatusCode.BadRequest)
			{
				switch (unsuccessfulStatusCodeError.Content?.Error)
				{
				case "express_delivery_error":
				case "express_slot_expired":
					return new ExpressDeliveryError();
				case "incorrect_address":
					return new IncorrectAddressError
					{
						Message = unsuccessfulStatusCodeError.Content.Message
					};
				}
				CheckoutCommitResultDto? content = unsuccessfulStatusCodeError.Content;
				if (content != null && content.Error?.ToLower().Contains("loyalty_no_connect") == true)
				{
					return new CheckoutNoLoyaltyError();
				}
			}
			string? httpMessage = unsuccessfulStatusCodeError.HttpMessage;
			if (httpMessage != null && httpMessage.ToLower().Contains("loyalty_no_connect"))
			{
				return new CheckoutNoLoyaltyError();
			}
			if ((unsuccessfulStatusCodeError.StatusCode == HttpStatusCode.BadRequest || unsuccessfulStatusCodeError.StatusCode == HttpStatusCode.InternalServerError) && unsuccessfulStatusCodeError.Content?.Error == "1")
			{
				return new CheckoutNoPointsPayment
				{
					Message = unsuccessfulStatusCodeError.Content.Message
				};
			}
		}
		if (serviceError is IUnsuccessfulStatusCodeError<ExpiredTimeSlotResponseDto>)
		{
			return new ExpiredTimeSlotError();
		}
		return serviceError.ToBaseDomainError();
	}

	public static DomainError ToCheckoutSegmentPointsError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<CheckoutSegmentPointsBaseResponseDto> unsuccessfulStatusCodeError)
		{
			if (unsuccessfulStatusCodeError.StatusCode == HttpStatusCode.BadRequest && (unsuccessfulStatusCodeError.Content?.Errors)?.FirstOrDefault((CheckoutSegmentResponseErrorDto er) => er.Code == "loyalty_no_connect") != null)
			{
				return new CheckoutNoLoyaltyError();
			}
			if (unsuccessfulStatusCodeError.StatusCode == HttpStatusCode.InternalServerError)
			{
				return new CheckoutNoLoyaltyError();
			}
		}
		return serviceError.ToBaseDomainError();
	}

	public static DomainError ToRecalculateError(this ServiceError error)
	{
		if (error is IUnsuccessfulStatusCodeError { StatusCode: var statusCode } unsuccessfulStatusCodeError)
		{
			switch (statusCode)
			{
			case HttpStatusCode.BadRequest:
				if (unsuccessfulStatusCodeError is IUnsuccessfulStatusCodeError<ApiV2ResponseDto> unsuccessfulStatusCodeError2 && unsuccessfulStatusCodeError2.Content?.Errors?.FirstOrDefault()?.Code == "express_delivery_error")
				{
					return new ExpressDeliveryError();
				}
				break;
			case HttpStatusCode.InternalServerError:
				return new UnknownError();
			}
		}
		if (error is IUnsuccessfulStatusCodeError<ApiV2ResponseDto> { StatusCode: HttpStatusCode.NotFound } unsuccessfulStatusCodeError3 && (unsuccessfulStatusCodeError3.Content?.Errors?.FirstOrDefault()?.Code ?? "") == "no_items")
		{
			return new NoDataError();
		}
		DomainError domainError = error.ToCheckoutFullDataError();
		if (!(domainError is NoDataError))
		{
			return domainError;
		}
		return new UnknownError
		{
			Message = domainError.Message
		};
	}

	public static DomainError ToCheckoutFullDataError(this ServiceError error)
	{
		if (error is IUnsuccessfulStatusCodeError unsuccessfulStatusCodeError && HttpStatusCode.BadRequest < unsuccessfulStatusCodeError.StatusCode && unsuccessfulStatusCodeError.StatusCode < HttpStatusCode.InternalServerError)
		{
			return new GenericCheckoutError();
		}
		if (error is IUnsuccessfulStatusCodeError<ApiV2ResponseDto> { StatusCode: HttpStatusCode.BadRequest } unsuccessfulStatusCodeError2)
		{
			ApiV2ResponseDto.ErrorDto errorDto = unsuccessfulStatusCodeError2.Content?.Errors?.FirstOrDefault();
			string text = errorDto?.Code ?? "";
			if (text == "delivery_error")
			{
				return new DeliveryError
				{
					Message = errorDto?.Message
				};
			}
			if (text == "express_delivery_error")
			{
				return new ExpressDeliveryError();
			}
		}
		return error.ToBaseDomainError();
	}
}
