using System;
using System.Linq;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.LoyaltyProgramLoymax;

namespace Auchan.Common.Base.Errors.Custom;

public class CardEnrollError : DomainError
{
	public enum Type
	{
		Default,
		CardValidationFailed,
		CardValidationTimeout,
		CardValidationBan,
		CardMergeFailed,
		RegistrationFailed,
		BadPhoneNumber,
		BadEmailAddress,
		EmailAlreadyExists,
		BadCardNumber,
		AlreadyInLoyalty,
		CardAlreadyActivated,
		CMDTemporaryUnavailable,
		CardAlreadyAttachedToClientAccount,
		CardBlocked,
		WrongCardState
	}

	public Type ErrorType { get; private set; }

	public CardEnrollError(Type t = Type.Default)
	{
		ErrorType = t;
		SetMessage(t);
	}

	public CardEnrollError(ServiceError serviceError)
	{
		Type type = Type.Default;
		if (serviceError is IUnsuccessfulStatusCodeError<LoymaxResponseBaseDto> unsuccessfulStatusCodeError)
		{
			string text = unsuccessfulStatusCodeError.Content?.Errors?.FirstOrDefault()?.Code ?? "";
			if (!string.IsNullOrEmpty(text))
			{
				if (text.Contains("CardValidationFailed", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.CardValidationFailed;
				}
				if (text.Contains("CardValidationTimeout", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.CardValidationTimeout;
				}
				if (text.Contains("CardValidationBan", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.CardValidationBan;
				}
				if (text.Contains("CardMergeFailed", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.CardMergeFailed;
				}
				if (text.Contains("RegistrationFailed", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.RegistrationFailed;
				}
				if (text.Contains("BadPhoneNumber", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.BadPhoneNumber;
				}
				if (text.Contains("BadEmailAddress", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.BadEmailAddress;
				}
				if (text.Contains("EmailAlreadyExists", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.EmailAlreadyExists;
				}
				if (text.Contains("BadCardNumber", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.BadCardNumber;
				}
				if (text.Contains("AlreadyInLoyalty", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.AlreadyInLoyalty;
				}
				if (text.Contains("CMDTemporaryUnavailable", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.CMDTemporaryUnavailable;
				}
				if (text.Contains("CardAlreadyAttachedToClientAccount", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.CardAlreadyAttachedToClientAccount;
				}
				if (text.Contains("CardBlocked", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.CardBlocked;
				}
				if (text.Contains("WrongCardState", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.WrongCardState;
				}
				if (text.Contains("CardAlreadyActivated", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.CardAlreadyActivated;
				}
			}
		}
		ErrorType = type;
		SetMessage(type);
	}

	private void SetMessage(Type t)
	{
		base.Message = t switch
		{
			Type.RegistrationFailed => "Проверьте правильность введенных данных", 
			Type.BadPhoneNumber => "Данный номер телефона уже используется в системе", 
			Type.BadEmailAddress => "Некорректный адрес электронной почты", 
			Type.EmailAlreadyExists => "Пользователь с таким e-mail уже существует", 
			Type.BadCardNumber => "Карта не найдена. Проверьте правильность введенного номера", 
			Type.CardValidationFailed => "Некорректный номер карты или CVV-код", 
			Type.CardValidationTimeout => "Превышено количество попыток добавления карты, попробуйте позже", 
			Type.CardValidationBan => "Превышено количество попыток добавления карты. Обратитесь в службу поддержки", 
			Type.CardMergeFailed => "Не удалось добавить карту. Попробуйте еще раз или обратитесь в службу поддержки", 
			Type.AlreadyInLoyalty => "Пользователь с данным номером уже зарегистрирован. Обратитесь в службу поддержки", 
			Type.CardAlreadyAttachedToClientAccount => "Данная карта уже активирована и привязана к вашему номеру телефона", 
			Type.CardBlocked => "Данная карта заблокирована. Обратитесь в службу поддержки", 
			Type.WrongCardState => "Неверный статус карты. Попробуйте еще раз или обратитесь в службу поддержки", 
			Type.CardAlreadyActivated => "Данная карта уже активирована на другом аккаунте. Обратитесь в службу поддержки", 
			Type.CMDTemporaryUnavailable => "Произошла ошибка. Пожалуйста, повторите попытку позже", 
			_ => "Произошла ошибка. Пожалуйста, повторите попытку позже", 
		};
	}
}
