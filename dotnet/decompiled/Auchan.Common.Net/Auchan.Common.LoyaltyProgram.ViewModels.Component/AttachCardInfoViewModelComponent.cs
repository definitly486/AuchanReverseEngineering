using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Models;

namespace Auchan.Common.LoyaltyProgram.ViewModels.Component;

public class AttachCardInfoViewModelComponent
{
	private const int CardNumberValidLenght = 13;

	private const int CardCvcValidLenght = 3;

	private const int StartIndexForValidation = 3;

	public LoyaltyCardEntity Entity { get; set; } = new LoyaltyCardEntity();

	public string CardNumberTitle => "Номер карты";

	public string CardNumberText { get; set; } = string.Empty;

	public bool IsCardNumberEntered => !string.IsNullOrEmpty(CardNumberText);

	public string CardNumberValidationHint => "Номер карты должен содержать 13 цифр";

	public bool IsCardNumberValid { get; private set; } = true;

	public string CardCvcTitle => "Код CVV";

	public string CardCvcText { get; set; } = string.Empty;

	public bool IsCardCvcEntered => !string.IsNullOrEmpty(CardCvcText);

	public string CardCvcValidationHint => "Код содержит 3 цифры";

	public bool IsCardCvcValid { get; private set; } = true;

	public string CardCvcHintPopupTitle => "CVV-код находится на задней стороне карты и состоит из 3х цифр";

	public void OnFinishCardNumberInput()
	{
		string text = CardNumberText.Trim();
		text = text.Replace(" ", string.Empty);
		IsCardNumberValid = text.Length == 13 || text.Length == 0;
		CardNumberText = text.GetCardNumberFormatted();
		Entity.CardNumber = text;
	}

	public void OnFinishCardCvcInput()
	{
		string text = CardCvcText.Trim();
		IsCardCvcValid = text.Length == 3 || text.Length == 0;
		Entity.Cvc = text;
	}
}
