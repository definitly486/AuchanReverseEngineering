using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom.Cart.Errors;
using Auchan.Common.Ecom.Cart.Models;

namespace Auchan.Common.Ecom.DTO;

public static class ShareCartResponseMapper
{
	public static ShareCartModel ToModel(this ShareCartResponseDto dto)
	{
		return new ShareCartModel
		{
			Token = dto.Data.Token,
			Payload = dto.Data.Title
		};
	}

	public static DomainError ToSharedCartError(this ServiceError @this)
	{
		if (@this is IUnsuccessfulStatusCodeError<SharedCartErrorDto> { Content: not null } unsuccessfulStatusCodeError)
		{
			return new SharedCartDomainError
			{
				Message = unsuccessfulStatusCodeError.Content.Message,
				Code = unsuccessfulStatusCodeError.Content.Code
			};
		}
		return @this.ToBaseDomainError();
	}
}
