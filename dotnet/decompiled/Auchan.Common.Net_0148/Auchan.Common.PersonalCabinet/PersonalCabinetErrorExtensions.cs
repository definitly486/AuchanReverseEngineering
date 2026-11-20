using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Custom;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.PersonalCabinet.DTO;
using Auchan.Common.PersonalCabinet.Errors;

namespace Auchan.Common.PersonalCabinet;

public static class PersonalCabinetErrorExtensions
{
	public static DomainError ToGetTokenError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<TokenDto> unsuccessfulStatusCodeError)
		{
			return unsuccessfulStatusCodeError.Content?.Error switch
			{
				99 => new AttributeError(), 
				302 => new IncorrectLoginOrPasswordError
				{
					Message = unsuccessfulStatusCodeError.Content.Message
				}, 
				303 => new IncorrectPinError(), 
				304 => new ExpiredPinError(), 
				305 => new BlockedAccountError(), 
				306 => new TemporarilyBlockedAccountError
				{
					Message = unsuccessfulStatusCodeError.Content.Message
				}, 
				322 => new IncorrectLoginOrPasswordError
				{
					Message = unsuccessfulStatusCodeError.Content.Message
				}, 
				_ => new UnknownError(), 
			};
		}
		return serviceError.ToBaseDomainError();
	}

	public static DomainError ToUpdateProfileError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<LoymaxResponseBaseDto>)
		{
			return new ProfileError(serviceError);
		}
		return new UnknownError
		{
			Message = "Упс! Что-то пошло не так."
		};
	}

	public static DomainError ToProfileByDeviceError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<TokenDto> unsuccessfulStatusCodeError)
		{
			int? num = unsuccessfulStatusCodeError.Content?.Error;
			if (num.HasValue && num == 101)
			{
				return new MissingToken80Error();
			}
			return new UnknownError();
		}
		return serviceError.ToBaseDomainError();
	}

	public static DomainError ToValidateTokenError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<ValidateTokenDto> unsuccessfulStatusCodeError)
		{
			_ = unsuccessfulStatusCodeError.Content?.Error;
			return new UnknownError();
		}
		return serviceError.ToBaseDomainError();
	}

	public static DomainError ToCheckAccountError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<BasePersonalCabinetResponseDto> unsuccessfulStatusCodeError)
		{
			int? num = unsuccessfulStatusCodeError.Content?.Error;
			if (num.HasValue && num == 402)
			{
				return new IncorrectLoginOrPasswordError();
			}
			return new UnknownError();
		}
		return serviceError.ToBaseDomainError();
	}

	public static DomainError ToBeginVerifyPhoneError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<BasePersonalCabinetResponseDto> unsuccessfulStatusCodeError)
		{
			int? num = unsuccessfulStatusCodeError.Content?.Error;
			if (num.HasValue && num == 201)
			{
				return new PhoneOfAnotherAccountError();
			}
			return new UnknownError();
		}
		return serviceError.ToBaseDomainError();
	}

	public static DomainError ToVerifyPhoneError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<BasePersonalCabinetResponseDto> unsuccessfulStatusCodeError)
		{
			return unsuccessfulStatusCodeError.Content?.Error switch
			{
				201 => new PhoneOfAnotherAccountError(), 
				301 => new AlreadyVerifiedPhoneError(), 
				303 => new IncorrectPinError(), 
				304 => new ExpiredPinError(), 
				_ => new UnknownError(), 
			};
		}
		return serviceError.ToBaseDomainError();
	}

	public static DomainError ToCheckPhoneError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<BasePersonalCabinetResponseDto> unsuccessfulStatusCodeError)
		{
			return unsuccessfulStatusCodeError.Content?.Error switch
			{
				99 => new AttributeError(), 
				101 => new MissingToken80Error(), 
				_ => new UnknownError(), 
			};
		}
		return serviceError.ToBaseDomainError();
	}

	public static DomainError ToRecoverPasswordError(this ServiceError serviceError)
	{
		if (serviceError is UnsuccessfulStatusCodeError<RecoverPasswordResponseDto> unsuccessfulStatusCodeError)
		{
			int? num = unsuccessfulStatusCodeError.Content?.Error;
			if (num.HasValue && num == 402)
			{
				return new NonexistentEmailPasswordRecoveryError
				{
					Message = unsuccessfulStatusCodeError.Content?.Message
				};
			}
			return new UnknownError
			{
				Message = unsuccessfulStatusCodeError.Content?.Message
			};
		}
		return serviceError.ToBaseDomainError();
	}

	public static DomainError ToChangePasswordError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<PasswordExistResponseDto> unsuccessfulStatusCodeError)
		{
			return unsuccessfulStatusCodeError.Content?.Error switch
			{
				102 => new TokenValidationError
				{
					Message = unsuccessfulStatusCodeError.Content?.Message
				}, 
				103 => new LowLevelToken
				{
					Message = unsuccessfulStatusCodeError.Content?.Message
				}, 
				302 => new IncorrectLoginOrPasswordError
				{
					Message = unsuccessfulStatusCodeError.Content?.Message
				}, 
				_ => new UnknownError
				{
					Message = unsuccessfulStatusCodeError.Content?.Message
				}, 
			};
		}
		return serviceError.ToBaseDomainError();
	}
}
