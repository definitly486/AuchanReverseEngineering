using System;
using System.Linq;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.LoyaltyProgramLoymax;

namespace Auchan.Common.Base.Errors.Custom;

public class CardMergeError : DomainError
{
	public enum Type
	{
		Default,
		CardValidationFailed,
		CardValidationTimeout,
		CardValidationBan,
		CardMergeFailed,
		CardAlreadyAttachedToClientAccount,
		CardBlocked,
		CardAlreadyActivated,
		BadCardNumber,
		WrongCardState
	}

	public Type ErrorType { get; private set; }

	public CardMergeError(Type t = Type.Default)
	{
		ErrorType = t;
		SetMessage(t);
	}

	public CardMergeError(ServiceError serviceError)
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
				if (text.Contains("CardAlreadyAttachedToClientAccount", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.CardAlreadyAttachedToClientAccount;
				}
				if (text.Contains("CardAlreadyActivated", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.CardAlreadyActivated;
				}
				if (text.Contains("CardBlocked", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.CardBlocked;
				}
				if (text.Contains("WrongCardState", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.WrongCardState;
				}
				if (text.Contains("BadCardNumber", StringComparison.OrdinalIgnoreCase))
				{
					type = Type.BadCardNumber;
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
			Type.CardValidationFailed => "Некорректный номер карты или CVV-код", 
			Type.CardValidationTimeout => "Превышено количество попыток добавления карты, попробуйте позже", 
			Type.CardValidationBan => "Превышено количество попыток добавления карты. Обратитесь в службу поддержки", 
			Type.CardMergeFailed => "Не удалось добавить карту. Попробуйте еще раз или обратитесь в службу поддержки", 
			Type.CardAlreadyAttachedToClientAccount => "Данная карта уже активирована и привязана к вашему номеру телефона", 
			Type.CardAlreadyActivated => "Данная карта уже активирована на другом аккаунте. Обратитесь в службу поддержки", 
			Type.CardBlocked => "Данная карта заблокирована. Обратитесь в службу поддержки", 
			Type.WrongCardState => "Неверный статус карты. Попробуйте еще раз или обратитесь в службу поддержки", 
			Type.BadCardNumber => "Карта не найдена. Проверьте правильность введенного номера", 
			_ => "Что-то пошло не так…", 
		};
	}
}
