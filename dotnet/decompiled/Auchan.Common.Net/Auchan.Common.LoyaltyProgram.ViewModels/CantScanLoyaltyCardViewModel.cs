using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Feedback;
using Auchan.Common.Navigation;
using Microsoft.Maui.Devices;

namespace Auchan.Common.LoyaltyProgram.ViewModels;

public class CantScanLoyaltyCardViewModel : ScreenViewModel
{
	private readonly IInfoMessageService _infoMessageService;

	private readonly INavigationService _navigationService;

	private readonly IFeedbackContactsProvider _feedbackContactsProvider;

	public string ScreenTitle => "Карта не считывается?";

	public string MessageText => "Если на кассе не могут считать карту, то сообщите нам об этом любым удобным способом.";

	public string WriteMessageButtonLabel => "Написать";

	public string CallButtonLabel => "Позвонить";

	protected override string ScreenName => "loyality_csrd_is_not_read";

	public CantScanLoyaltyCardViewModel(IInfoMessageService infoMessageService, INavigationService navigationService, IFeedbackContactsProvider feedbackContactsProvider)
	{
		_navigationService = navigationService;
		_feedbackContactsProvider = feedbackContactsProvider;
		_infoMessageService = infoMessageService;
	}

	public void WriteMessage()
	{
		_navigationService.WriteFeedback();
	}

	public async Task DoPhoneCallAsync()
	{
		if (DeviceInfo.Platform == DevicePlatform.Android)
		{
			AlertButton obj = await _infoMessageService.ShowAlertAsync(string.Empty, _feedbackContactsProvider.Phone.GetPhoneNumberFormatted(withDashes: true), new AlertButton[2]
			{
				new AlertButton
				{
					Title = "Вызов",
					Type = ActionType.Positive
				},
				new AlertButton
				{
					Title = "Отмена",
					Type = ActionType.Negative
				}
			});
			if ((object)obj == null || obj.Type != ActionType.Positive)
			{
				return;
			}
		}
		_navigationService.CallToAuchanSupport();
	}
}
