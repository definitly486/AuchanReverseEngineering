using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.InfoPages;

namespace Auchan.Common.Profile.GiftCards;

public class GiftCardsViewModel : ScreenViewModel
{
	[CompilerGenerated]
	private UICommand<DynamicFeedbackViewModel.Parameter> _003COpenDynamicFeedbackCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<InfoPageViewModel.Parameter> _003COpenGiftCardRulesCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<InfoPageViewModel.Parameter> _003COpenGiftCardFAQCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003COpenGiftCardBalanceCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<WebViewModel.Parameter> _003COpenGiftCardShopCommand_003Ek__BackingField;

	public string Title => "Электронные подарочные карты";

	public string GiftCardTitle => "Подарок, который точно понравится";

	public string GiftCardDescription => "Купите карту на любую сумму* и подарите всего в несколько кликов";

	public string BuyButtonText => "Купить карту";

	public string CheckBalanceButtonText => "Проверить баланс";

	public string GiftCardSumRangeText => "*от 250 ₽ до 15 000 ₽";

	public string GiftCardPlasticDescription => "Пластиковую подарочную карту Вы можете приобрести в любом магазине сети АШАН";

	public string GiftCardRulesText => "Правила программы";

	public string FAQText => "Вопросы и ответы";

	public string FeedbackText => "Связаться с нами";

	public UICommand<DynamicFeedbackViewModel.Parameter> OpenDynamicFeedbackCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenDynamicFeedbackCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenDynamicFeedbackCommand_003Ek__BackingField, value))
			{
				_003COpenDynamicFeedbackCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenDynamicFeedbackCommand");
			}
		}
	} = new UICommand<DynamicFeedbackViewModel.Parameter>(new DynamicFeedbackViewModel.Parameter(FeedbackState.WithTopicAndCategory));

	public UICommand<InfoPageViewModel.Parameter> OpenGiftCardRulesCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenGiftCardRulesCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenGiftCardRulesCommand_003Ek__BackingField, value))
			{
				_003COpenGiftCardRulesCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenGiftCardRulesCommand");
			}
		}
	} = new UICommand<InfoPageViewModel.Parameter>(new InfoPageViewModel.Parameter(InfoType.GiftCardRules));

	public UICommand<InfoPageViewModel.Parameter> OpenGiftCardFAQCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenGiftCardFAQCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenGiftCardFAQCommand_003Ek__BackingField, value))
			{
				_003COpenGiftCardFAQCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenGiftCardFAQCommand");
			}
		}
	} = new UICommand<InfoPageViewModel.Parameter>(new InfoPageViewModel.Parameter(InfoType.GiftCardFAQ));

	public UICommand OpenGiftCardBalanceCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenGiftCardBalanceCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenGiftCardBalanceCommand_003Ek__BackingField, value))
			{
				_003COpenGiftCardBalanceCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenGiftCardBalanceCommand");
			}
		}
	} = new UICommand();

	public UICommand<WebViewModel.Parameter> OpenGiftCardShopCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenGiftCardShopCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenGiftCardShopCommand_003Ek__BackingField, value))
			{
				_003COpenGiftCardShopCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenGiftCardShopCommand");
			}
		}
	} = new UICommand<WebViewModel.Parameter>(new WebViewModel.Parameter
	{
		Url = "https://auchan.digift.ru/"
	});
}
