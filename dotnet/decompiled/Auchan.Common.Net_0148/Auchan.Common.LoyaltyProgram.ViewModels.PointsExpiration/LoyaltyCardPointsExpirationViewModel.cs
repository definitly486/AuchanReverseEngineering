using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;
using Auchan.Common.LoyaltyProgram.ViewModels.NewLoyaltyCard;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration.DataProviders;
using Auchan.Common.LoyaltyProgramLoymax;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration;

public class LoyaltyCardPointsExpirationViewModel : FeedViewModel<FeedItemViewModel>
{
	public class Parameter
	{
		public LoyaltyCurrencyDto[] Currencies { get; }

		public Parameter(LoyaltyCurrencyDto[] currencies)
		{
			Currencies = currencies;
		}
	}

	public enum VisualState
	{
		Default,
		Error,
		Empty,
		InProgress
	}

	private readonly Parameter _parameter;

	private readonly Subject<Unit> _onRetry = new Subject<Unit>();

	private readonly ILoyaltyExpirationPointsDataProvider _expirationPointsDataProvider;

	private readonly IErrorTranslator _errorTranslator;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorDescription_003Ek__BackingField;

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
	} = VisualState.InProgress;

	public string EmptyTitle => "Пока вы не накопили ни одного балла ;(";

	public string EmptyDescription => "Пора это исправить — вперед за покупками!";

	public string ErrorTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorTitle");
			}
		}
	} = "";

	public string ErrorDescription
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorDescription_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorDescription");
			}
		}
	} = "";

	public string RetryButtonText => "Повторить";

	public string ScreenTitle => "Срок действия баллов";

	public string BasicPointsText => "Базовые баллы";

	public string ExpressPointsText => "Экспресс-баллы";

	public string HintText => "Следите за балансом. Успейте потратить баллы.";

	public NewLoyaltyBalanceItemViewModel NewLoyaltyCardBalanceItemViewModel { get; }

	public LoyaltyCardPointsExpirationViewModel(Parameter parameter, ILoyaltyExpirationPointsDataProvider expirationPointsDataProvider, NewLoyaltyBalanceItemViewModel newLoyaltyCardBalanceItemViewModel, DefaultErrorTranslator defaultErrorTranslator)
	{
		_parameter = parameter;
		_expirationPointsDataProvider = expirationPointsDataProvider;
		_errorTranslator = defaultErrorTranslator;
		NewLoyaltyCardBalanceItemViewModel = newLoyaltyCardBalanceItemViewModel;
		_onRetry.PerformDebouncingTask(LoadData).Subscribe().AddTo(base.CloseDisposable);
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadData();
	}

	private async Task LoadData()
	{
		State = VisualState.InProgress;
		Task task = NewLoyaltyCardBalanceItemViewModel.InitializeAsync(BalanceControlType.Balance);
		Task<Result<IEnumerable<FeedItemViewModel>, DomainError>> historyTask = _expirationPointsDataProvider.GetHistoryAsync(_parameter.Currencies);
		await Task.WhenAll(task, historyTask);
		if (historyTask.Result.IsFailure)
		{
			State = VisualState.Error;
			(ErrorTitle, ErrorDescription) = _errorTranslator.Translate(historyTask.Result.Error);
		}
		else if (!historyTask.Result.Value.Any())
		{
			State = VisualState.Empty;
			base.ItemsCollection.Clear();
			base.IsDataLoaded = true;
			RaisePropertyChanged("IsEmpty");
		}
		else
		{
			base.ItemsCollection.AddRange(historyTask.Result.Value);
			base.IsDataLoaded = true;
			RaisePropertyChanged("IsEmpty");
			State = VisualState.Default;
		}
	}

	public void Retry()
	{
		_onRetry.OnNext(Unit.Default);
	}
}
