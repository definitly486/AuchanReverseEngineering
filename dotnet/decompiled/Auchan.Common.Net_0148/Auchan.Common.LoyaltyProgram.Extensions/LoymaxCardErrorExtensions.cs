using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Custom;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.LoyaltyProgramLoymax;

namespace Auchan.Common.LoyaltyProgram.Extensions;

public static class LoymaxCardErrorExtensions
{
	public static DomainError ToCardMergeError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<LoymaxResponseBaseDto> { Content: not null })
		{
			return new CardMergeError(serviceError);
		}
		return serviceError.ToBaseDomainError();
	}

	public static DomainError ToCardEnrollError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<LoymaxResponseBaseDto> { Content: not null })
		{
			return new CardEnrollError(serviceError);
		}
		return serviceError.ToBaseDomainError();
	}
}
