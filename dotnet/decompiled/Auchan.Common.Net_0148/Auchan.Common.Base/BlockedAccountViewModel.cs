using Auchan.Common.Extensions;
using Auchan.Common.Feedback;

namespace Auchan.Common.Base;

public class BlockedAccountViewModel : ScreenViewModel
{
	private readonly IFeedbackContactsProvider _feedbackContactsProvider;

	public string Title => "Аккаунт заблокирован";

	public virtual string DescriptionString => "Мы временно заблокировали доступ\nв ваш аккаунт";

	public string ContactWithUsString => "Пожалуйста, свяжитесь с нами по телефону горячей линии, чтобы восстановить доступ";

	public string PhoneString => _feedbackContactsProvider.Phone.GetPhoneNumberFormatted();

	public string FreeString => "Звонок по России бесплатный";

	public string GoHomeButtonTitle => "На Главную";

	public BlockedAccountViewModel(IFeedbackContactsProvider feedbackContactsProvider)
	{
		_feedbackContactsProvider = feedbackContactsProvider;
	}
}
