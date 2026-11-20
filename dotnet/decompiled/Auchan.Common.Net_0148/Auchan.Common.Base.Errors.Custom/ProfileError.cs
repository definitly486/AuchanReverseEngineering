using System;
using System.Linq;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.LoyaltyProgramLoymax;

namespace Auchan.Common.Base.Errors.Custom;

public sealed class ProfileError : DomainError
{
	public enum Type
	{
		Default,
		BadEmailAddress,
		EmailAlreadyExists
	}

	public Type ErrorType { get; private set; }

	public ProfileError(ServiceError serviceError)
	{
		Type errorType = Type.Default;
		base.Message = "Упс! Что-то пошло не так.";
		if (serviceError is IUnsuccessfulStatusCodeError<LoymaxResponseBaseDto> unsuccessfulStatusCodeError)
		{
			LoymaxErrorDto? obj = unsuccessfulStatusCodeError.Content?.Errors?.FirstOrDefault();
			string text = obj?.Message ?? "";
			if (!string.IsNullOrEmpty(text))
			{
				base.Message = text;
			}
			string text2 = obj?.Code ?? "";
			if (!string.IsNullOrEmpty(text2))
			{
				if (text2.Contains("BadEmailAddress", StringComparison.OrdinalIgnoreCase))
				{
					errorType = Type.BadEmailAddress;
				}
				if (text2.Contains("EmailAlreadyExists", StringComparison.OrdinalIgnoreCase))
				{
					errorType = Type.EmailAlreadyExists;
				}
			}
		}
		ErrorType = errorType;
	}
}
