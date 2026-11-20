using System;
using System.Net;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common.Binding;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.GiftCards.Errors;
using Auchan.Common.Profile.GiftCards.Infrastructure;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.GiftCards;

public class GiftCardBalanceViewModel : ScreenViewModel
{
	public enum VisualState
	{
		Default,
		InProgress,
		Error,
		CardError
	}

	private readonly GiftCardsService _service;

	public readonly int CardNumberLength = 19;

	public readonly int CardPinLength = 4;

	public readonly string CardNumberMask = "[0000] [0000] [0000] [0000] [000]";

	[CompilerGenerated]
	private UICommand _003CRetryCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CRequestCardCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CCloseCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CShowCardDataCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CShowCardBalanceCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CShowFeedbackCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<DynamicFeedbackViewModel.Parameter> _003COpenFeedbackCommand_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CRetryButtonVisible_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCardErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCardErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCardNumberText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCardNumberError_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCardPINText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCardPINError_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCardExpireTimeText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCardBalanceText_003Ek__BackingField;

	public UICommand RetryCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CRetryCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CRetryCommand_003Ek__BackingField, value))
			{
				_003CRetryCommand_003Ek__BackingField = value;
				RaisePropertyChanged("RetryCommand");
			}
		}
	} = new UICommand();

	public UICommand RequestCardCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CRequestCardCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CRequestCardCommand_003Ek__BackingField, value))
			{
				_003CRequestCardCommand_003Ek__BackingField = value;
				RaisePropertyChanged("RequestCardCommand");
			}
		}
	} = new UICommand();

	public UICommand CloseCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CCloseCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCloseCommand_003Ek__BackingField, value))
			{
				_003CCloseCommand_003Ek__BackingField = value;
				RaisePropertyChanged("CloseCommand");
			}
		}
	} = new UICommand();

	public UICommand ShowCardDataCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CShowCardDataCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CShowCardDataCommand_003Ek__BackingField, value))
			{
				_003CShowCardDataCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ShowCardDataCommand");
			}
		}
	} = new UICommand();

	public UICommand ShowCardBalanceCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CShowCardBalanceCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CShowCardBalanceCommand_003Ek__BackingField, value))
			{
				_003CShowCardBalanceCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ShowCardBalanceCommand");
			}
		}
	} = new UICommand();

	public UICommand ShowFeedbackCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CShowFeedbackCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CShowFeedbackCommand_003Ek__BackingField, value))
			{
				_003CShowFeedbackCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ShowFeedbackCommand");
			}
		}
	} = new UICommand();

	public UICommand<DynamicFeedbackViewModel.Parameter> OpenFeedbackCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenFeedbackCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenFeedbackCommand_003Ek__BackingField, value))
			{
				_003COpenFeedbackCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenFeedbackCommand");
			}
		}
	} = new UICommand<DynamicFeedbackViewModel.Parameter>(new DynamicFeedbackViewModel.Parameter(FeedbackState.WithTopicAndCategory));

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	}

	public string ErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorMessage");
			}
		}
	} = string.Empty;

	public bool RetryButtonVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CRetryButtonVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CRetryButtonVisible_003Ek__BackingField != value)
			{
				_003CRetryButtonVisible_003Ek__BackingField = value;
				RaisePropertyChanged("RetryButtonVisible");
			}
		}
	}

	public string CardErrorTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CCardErrorTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCardErrorTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCardErrorTitle_003Ek__BackingField = value;
				RaisePropertyChanged("CardErrorTitle");
			}
		}
	} = string.Empty;

	public string CardErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CCardErrorMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCardErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCardErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("CardErrorMessage");
			}
		}
	} = string.Empty;

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return _003CTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
			}
		}
	} = string.Empty;

	public string CardNumberPlaceholder => "Номер карты";

	public string CardNumberText
	{
		[CompilerGenerated]
		get
		{
			return _003CCardNumberText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CCardNumberText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCardNumberText_003Ek__BackingField = value;
				RaisePropertyChanged("CardNumberText");
			}
		}
	} = "";

	public string CardNumberError
	{
		[CompilerGenerated]
		get
		{
			return _003CCardNumberError_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCardNumberError_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCardNumberError_003Ek__BackingField = value;
				RaisePropertyChanged("CardNumberError");
			}
		}
	} = "";

	public string CardPINPlaceholder => "ПИН-код";

	public string CardPINText
	{
		[CompilerGenerated]
		get
		{
			return _003CCardPINText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CCardPINText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCardPINText_003Ek__BackingField = value;
				RaisePropertyChanged("CardPINText");
			}
		}
	} = "";

	public string CardPINError
	{
		[CompilerGenerated]
		get
		{
			return _003CCardPINError_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCardPINError_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCardPINError_003Ek__BackingField = value;
				RaisePropertyChanged("CardPINError");
			}
		}
	} = "";

	public string CheckButtonText => "Проверить баланс";

	public string CardExpireTimeTitle => "Срок действия";

	public string CardExpireTimeText
	{
		[CompilerGenerated]
		get
		{
			return _003CCardExpireTimeText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCardExpireTimeText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCardExpireTimeText_003Ek__BackingField = value;
				RaisePropertyChanged("CardExpireTimeText");
			}
		}
	} = "";

	public string CardBalanceTitle => "Остаток на карте";

	public string CardBalanceText
	{
		[CompilerGenerated]
		get
		{
			return _003CCardBalanceText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCardBalanceText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCardBalanceText_003Ek__BackingField = value;
				RaisePropertyChanged("CardBalanceText");
			}
		}
	} = "";

	public string OkButtonText => "Понятно";

	public string FeedbackButtonText => "Написать в поддержку";

	public string iOSKeyboardNextButtonText => "Далее";

	public string iOSKeyboardDoneButtonText => "Готово";

	public string RetryButtonText => "Повторить";

	public GiftCardBalanceViewModel(GiftCardsService service)
	{
		_service = service;
		RequestCardCommand.PerformDebouncingTask((Unit _) => RequestCard()).Subscribe().AddTo(base.CloseDisposable);
		RetryCommand.PerformDebouncingTask((Unit _) => RequestCard()).Subscribe().AddTo(base.CloseDisposable);
	}

	protected override Task Start()
	{
		Title = "Введите данные карты";
		return base.Start();
	}

	private async Task RequestCard()
	{
		State = VisualState.InProgress;
		string text = CardNumberText.Replace(" ", "");
		if (string.IsNullOrWhiteSpace(text) || text.Length != CardNumberLength)
		{
			CardNumberError = "Данные введены неверно. Пожалуйста, повторите попытку.";
			State = VisualState.Default;
		}
		else
		{
			CardNumberError = string.Empty;
		}
		if (string.IsNullOrWhiteSpace(CardPINText))
		{
			CardPINError = "Пожалуйста, введите пин-код подарочной карты. Продолжение без введенного пин-кода невозможно.";
			State = VisualState.Default;
		}
		else if (CardPINText.Length != CardPinLength)
		{
			CardPINError = "Данные введены неверно. Пожалуйста, повторите попытку.";
			State = VisualState.Default;
		}
		else
		{
			CardPINError = string.Empty;
		}
		if (State == VisualState.Default)
		{
			ShowFeedbackCommand.Trigger();
			return;
		}
		Result<GiftCardDataDTO, DomainError> result = await _service.GiftCardData(text, CardPINText);
		if (result.IsFailure)
		{
			if (result.Error is GiftCardError giftCardError)
			{
				if (giftCardError.StatusCode == HttpStatusCode.Unauthorized)
				{
					State = VisualState.Error;
					ErrorMessage = "Произошла ошибка, попробуйте еще раз";
					RetryButtonVisible = true;
					return;
				}
				if (giftCardError.StatusCode == HttpStatusCode.InternalServerError)
				{
					State = VisualState.CardError;
					CardErrorTitle = "Сервис недоступен";
					CardErrorMessage = giftCardError.Message ?? "Покупка и проверка баланса подарочной карты невозможны. Сервис скоро будет восстановлен.";
					return;
				}
				if (giftCardError.StatusCode == HttpStatusCode.BadRequest)
				{
					State = VisualState.Error;
					ErrorMessage = giftCardError.Message ?? "Покупка и проверка баланса подарочной карты невозможны. Сервис скоро будет восстановлен.";
					RetryButtonVisible = true;
					return;
				}
				switch (giftCardError.ErrorCode)
				{
				case 4:
					CardErrorTitle = "Сервис недоступен";
					State = VisualState.CardError;
					CardErrorMessage = giftCardError.Message ?? giftCardError.ErrorText;
					return;
				case 6:
				case 7:
				case 8:
				case 9:
					CardErrorTitle = "Ошибка!";
					State = VisualState.CardError;
					CardErrorMessage = giftCardError.Message ?? giftCardError.ErrorText;
					return;
				case 5:
					State = VisualState.Default;
					CardNumberError = giftCardError.Message ?? giftCardError.ErrorText;
					CardPINError = string.Empty;
					return;
				case 10:
					State = VisualState.Default;
					CardBalanceText = "0 ₽";
					ShowCardBalanceCommand.Trigger();
					ShowFeedbackCommand.Trigger();
					return;
				case 11:
				case 12:
					State = VisualState.Error;
					ErrorMessage = giftCardError.Message ?? giftCardError.ErrorText;
					RetryButtonVisible = giftCardError.ErrorCode == 12;
					return;
				}
			}
			CardErrorTitle = "Сервис недоступен";
			State = VisualState.CardError;
			CardErrorMessage = "Небольшие технические проблемы,\nпопробуйте обновить экран.";
		}
		else
		{
			CardExpireTimeText = $"До {result.Value.ExpiryDate:dd.MM.yy}";
			CardBalanceText = $"{result.Value.Amount:F2} ₽";
			ShowCardDataCommand.Trigger();
			ShowFeedbackCommand.Trigger();
			State = VisualState.Default;
		}
	}
}
