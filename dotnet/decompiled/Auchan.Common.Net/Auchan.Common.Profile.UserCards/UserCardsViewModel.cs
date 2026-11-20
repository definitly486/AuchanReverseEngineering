using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Navigation;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.UserCards;

[RequiresAuthorization]
public class UserCardsViewModel : ScreenViewModel
{
	private readonly Subject<CardItemViewModel> _onDeleteCard = new Subject<CardItemViewModel>();

	private readonly Subject<Unit> _onAddCard = new Subject<Unit>();

	private readonly IUserCardsService _userCardsService;

	private readonly DefaultErrorTranslator _errorTranslator;

	private readonly IInfoMessageService _infoMessageService;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private ObservableRangeCollection<CardItemViewModel> _003CCards_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CScreenTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CEmptyMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CEmptyHint_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorHint_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorActionButtonText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAddCardButtonText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CRemoveCardDialogTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CRemoveCardDialogMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CRemoveCardDialogAccept_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CRemoveCardDialogCancel_003Ek__BackingField;

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
	} = VisualState.Default;

	public ObservableRangeCollection<CardItemViewModel> Cards
	{
		[CompilerGenerated]
		get
		{
			return _003CCards_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCards_003Ek__BackingField, value))
			{
				_003CCards_003Ek__BackingField = value;
				RaisePropertyChanged("Cards");
			}
		}
	} = new ObservableRangeCollection<CardItemViewModel>();

	public string ScreenTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CScreenTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CScreenTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CScreenTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ScreenTitle");
			}
		}
	} = "Мои карты";

	public string EmptyMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CEmptyMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CEmptyMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CEmptyMessage_003Ek__BackingField = value;
				RaisePropertyChanged("EmptyMessage");
			}
		}
	} = "У вас нет сохраненных\nбанковских карт";

	public string EmptyHint
	{
		[CompilerGenerated]
		get
		{
			return _003CEmptyHint_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CEmptyHint_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CEmptyHint_003Ek__BackingField = value;
				RaisePropertyChanged("EmptyHint");
			}
		}
	} = "";

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
	} = "";

	public string ErrorHint
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorHint_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorHint_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorHint_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorHint");
			}
		}
	} = "";

	public string ErrorActionButtonText
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorActionButtonText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorActionButtonText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorActionButtonText_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorActionButtonText");
			}
		}
	} = "Повторить";

	public string AddCardButtonText
	{
		[CompilerGenerated]
		get
		{
			return _003CAddCardButtonText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CAddCardButtonText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAddCardButtonText_003Ek__BackingField = value;
				RaisePropertyChanged("AddCardButtonText");
			}
		}
	} = "Добавить карту";

	public string RemoveCardDialogTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CRemoveCardDialogTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CRemoveCardDialogTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CRemoveCardDialogTitle_003Ek__BackingField = value;
				RaisePropertyChanged("RemoveCardDialogTitle");
			}
		}
	} = "";

	public string RemoveCardDialogMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CRemoveCardDialogMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CRemoveCardDialogMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CRemoveCardDialogMessage_003Ek__BackingField = value;
				RaisePropertyChanged("RemoveCardDialogMessage");
			}
		}
	} = "Вы уверены, что хотите удалить карту?";

	public string RemoveCardDialogAccept
	{
		[CompilerGenerated]
		get
		{
			return _003CRemoveCardDialogAccept_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CRemoveCardDialogAccept_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CRemoveCardDialogAccept_003Ek__BackingField = value;
				RaisePropertyChanged("RemoveCardDialogAccept");
			}
		}
	} = "Да";

	public string RemoveCardDialogCancel
	{
		[CompilerGenerated]
		get
		{
			return _003CRemoveCardDialogCancel_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CRemoveCardDialogCancel_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CRemoveCardDialogCancel_003Ek__BackingField = value;
				RaisePropertyChanged("RemoveCardDialogCancel");
			}
		}
	} = "Отмена";

	public IObservable<CardItemViewModel> DeleteCardAskCommand => _onDeleteCard;

	public IObservable<Unit> AddCardCommand => _onAddCard.Debounce();

	public UserCardsViewModel(IUserCardsService userCardsService, DefaultErrorTranslator defaultErrorTranslator, IInfoMessageService infoMessageService)
	{
		_userCardsService = userCardsService;
		_errorTranslator = defaultErrorTranslator;
		_infoMessageService = infoMessageService;
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadCards();
	}

	public async Task LoadCards()
	{
		State = VisualState.InProgress;
		Result<List<CardModel>, DomainError> result = await _userCardsService.GetCards();
		if (result.IsFailure)
		{
			Cards.Clear();
			State = VisualState.Error;
			(ErrorMessage, ErrorHint) = _errorTranslator.Translate(result.Error);
		}
		else
		{
			SetCards(result.Value);
			if (Cards.Count == 0)
			{
				State = VisualState.Empty;
			}
			else
			{
				State = VisualState.Default;
			}
		}
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		await LoadCards();
	}

	public void AddCardClick()
	{
		_onAddCard.OnNext(Unit.Default);
	}

	public void DeleteCardClick(CardItemViewModel card)
	{
		_onDeleteCard.OnNext(card);
	}

	public void DeleteCardApprove(CardItemViewModel card)
	{
		DeleteCard(card.Id).SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task DeleteCard(int id)
	{
		State = VisualState.InProgress;
		if ((await _userCardsService.RemoveCard(id)).IsFailure)
		{
			_infoMessageService.ShowSnackbar("Произошла ошибка во время удаления карты.");
		}
		else
		{
			await LoadCards();
		}
	}

	private void SetCards(List<CardModel> cards)
	{
		Cards.ReplaceRange(from x in cards
			where x.Scheme != CardSchemeType.ACAP && x.Scheme != CardSchemeType.ACGC
			select new CardItemViewModel(x));
	}
}
