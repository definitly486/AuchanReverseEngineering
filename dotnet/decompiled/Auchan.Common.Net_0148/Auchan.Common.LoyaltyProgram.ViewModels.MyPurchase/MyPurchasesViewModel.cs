using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.Services;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration.DataProviders;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.Navigation;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;

public sealed class MyPurchasesViewModel : FeedViewModel<FeedItemViewModel>
{
	public enum FiltersIds
	{
		Default = 0,
		Order = 1,
		Purchase = 2,
		PointsTransfer = 3,
		PointsCorrection = 4,
		PointsBurning = 5,
		Stamps = 6,
		Delayed = 661,
		PointsExpiration = 662
	}

	public class Parameter
	{
		public FiltersIds OpenOnStartup { get; init; }
	}

	private static readonly IReadOnlyList<FiltersIds> WITH_FILTER = new global::_003C_003Ez__ReadOnlyArray<FiltersIds>(new FiltersIds[5]
	{
		FiltersIds.Default,
		FiltersIds.Order,
		FiltersIds.Purchase,
		FiltersIds.PointsCorrection,
		FiltersIds.Delayed
	});

	private readonly Subject<OperationDetailsViewModel.Parameter> _openOperationDetails = new Subject<OperationDetailsViewModel.Parameter>();

	private readonly Subject<PurchaseDetailsViewModel.Parameter> _openPurchaseDetails = new Subject<PurchaseDetailsViewModel.Parameter>();

	private readonly Parameter _parameter;

	private readonly ILoyaltyPurchasesRepository _purchasesRepository;

	private readonly ILoyaltyExpirationPointsDataProvider _pointsExpirationDataProvider;

	private readonly ILoyaltyManager _loyaltyManager;

	private readonly IAdminContext _adminContext;

	private readonly UrlNavigationHandler _urlNavigationHandler;

	private readonly IInfoMessageService _infoMessageService;

	private readonly ILoyaltyPointsExpirationService _loyaltyPointsExpirationService;

	private PagedDataLoader<LoyaltyProgramPurchase> _pagedHistoryItems;

	private PagedDataLoader<DelayedPointsEntryEntity> _pagedDelayedPoints;

	private PagedDataLoader<FeedItemViewModel> _pagedPointsExpiration;

	[CompilerGenerated]
	private HeaderViewModel _003CFiltersPane_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	public bool _lockVisualState;

	private readonly LoyaltyCurrencyDto[] _currencyList = new LoyaltyCurrencyDto[2]
	{
		new LoyaltyCurrencyDto
		{
			Id = 1L,
			Code = "AUCH_PT"
		},
		new LoyaltyCurrencyDto
		{
			Id = 4L,
			Code = "EXTRA_PT"
		}
	};

	private bool _needShowPointsExpirationFilter;

	private bool _needShowDelayedPointsFilter;

	public string ScreenTitle => "Мои покупки";

	public string ProgressTitle => "Загружаем вашу историю…";

	public string EmptyHistoryTitle => "Тут появится история ваших покупок";

	public string EmptyHistoryDescription => "Совершайте покупки в магазинах\nАШАН, получайте и списывайте баллы";

	public string ConnectionErrorText => _loyaltyManager.ConnectionErrorText;

	public string ConnectionErrorImage => _loyaltyManager.ConnectionErrorImage;

	public HeaderViewModel FiltersPane
	{
		[CompilerGenerated]
		get
		{
			return _003CFiltersPane_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CFiltersPane_003Ek__BackingField, value))
			{
				_003CFiltersPane_003Ek__BackingField = value;
				RaisePropertyChanged("FiltersPane");
			}
		}
	}

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

	public IObservable<OperationDetailsViewModel.Parameter> OpenOperationDetailsCommand => _openOperationDetails.Debounce();

	public IObservable<PurchaseDetailsViewModel.Parameter> OpenPurchaseDetailsCommand => _openPurchaseDetails.Debounce();

	public UICommand ResetCollectionCommand { get; } = new UICommand();

	public UICommand ShowDelayedPointsInfoCommand { get; } = new UICommand();

	public MyPurchasesViewModel(Parameter parameter, IAdminContext adminContext, ILoyaltyPurchasesRepository purchasesRepository, ILoyaltyManager loyaltyManager, UrlNavigationHandler urlNavigationHandler, IInfoMessageService infoMessageService, ILoyaltyExpirationPointsDataProvider pointsExpirationDataProvider, ILoyaltyPointsExpirationService loyaltyPointsExpirationService)
	{
		_parameter = parameter;
		_adminContext = adminContext;
		_purchasesRepository = purchasesRepository;
		_loyaltyManager = loyaltyManager;
		_urlNavigationHandler = urlNavigationHandler;
		_infoMessageService = infoMessageService;
		_pointsExpirationDataProvider = pointsExpirationDataProvider;
		_loyaltyPointsExpirationService = loyaltyPointsExpirationService;
		FiltersPane = new HeaderViewModel();
		_pagedHistoryItems = ResetHistoryDataLoader();
		_pagedDelayedPoints = ResetDelayedPointsLoader();
		_pagedPointsExpiration = ResetPointsExpirationLoader();
	}

	private PagedDataLoader<LoyaltyProgramPurchase> ResetHistoryDataLoader()
	{
		if (_pagedHistoryItems != null)
		{
			_pagedHistoryItems.Loaded -= OnHistoryItemsUpdated;
		}
		_pagedHistoryItems = new PagedDataLoader<LoyaltyProgramPurchase>(LoadNextHistoryItemsAsync);
		_pagedHistoryItems.Loaded += OnHistoryItemsUpdated;
		return _pagedHistoryItems;
	}

	private PagedDataLoader<DelayedPointsEntryEntity> ResetDelayedPointsLoader()
	{
		if (_pagedDelayedPoints != null)
		{
			_pagedDelayedPoints.Loaded -= OnDelayedItemsUpdated;
		}
		_pagedDelayedPoints = new PagedDataLoader<DelayedPointsEntryEntity>(LoadNextDelayedPointsAsync)
		{
			ItemsPerPage = 100
		};
		_pagedDelayedPoints.Loaded += OnDelayedItemsUpdated;
		return _pagedDelayedPoints;
	}

	private PagedDataLoader<FeedItemViewModel> ResetPointsExpirationLoader()
	{
		if (_pagedPointsExpiration != null)
		{
			_pagedPointsExpiration.Loaded -= OnPointsExpirationUpdated;
		}
		_pagedPointsExpiration = new PagedDataLoader<FeedItemViewModel>(LoadNextPointsExpirationAsync)
		{
			ItemsPerPage = 100
		};
		_pagedPointsExpiration.Loaded += OnPointsExpirationUpdated;
		return _pagedPointsExpiration;
	}

	protected override async Task Start()
	{
		await base.Start();
		_lockVisualState = true;
		DomainError error;
		if (_parameter.OpenOnStartup == FiltersIds.Delayed)
		{
			Result<(IReadOnlyList<DelayedPointsEntryEntity>, int), DomainError> operationsDP = await _pagedDelayedPoints.LoadFirst();
			error = (operationsDP.IsFailure ? operationsDP.Error : null);
			if (operationsDP.IsSuccess)
			{
				Result<(IReadOnlyList<LoyaltyProgramPurchase>, int), DomainError> res = await _pagedHistoryItems.LoadFirst();
				Result<(IReadOnlyList<FeedItemViewModel>, int), DomainError> result = await _pagedPointsExpiration.LoadFirst();
				_needShowDelayedPointsFilter = res.IsSuccess && operationsDP.IsSuccess && operationsDP.Value.Item1.Any();
				_needShowPointsExpirationFilter = res.IsSuccess && result.IsSuccess && result.Value.Item1.Any();
				error = (res.IsFailure ? res.Error : null);
			}
			else
			{
				_needShowDelayedPointsFilter = false;
				_needShowPointsExpirationFilter = false;
			}
		}
		else
		{
			Result<(IReadOnlyList<LoyaltyProgramPurchase>, int), DomainError> res = await _pagedHistoryItems.LoadFirst();
			error = (res.IsFailure ? res.Error : null);
			if (res.IsSuccess)
			{
				Result<(IReadOnlyList<DelayedPointsEntryEntity>, int), DomainError> operationsDP = await _pagedDelayedPoints.LoadFirst();
				Result<(IReadOnlyList<FeedItemViewModel>, int), DomainError> result2 = await _pagedPointsExpiration.LoadFirst();
				_needShowDelayedPointsFilter = res.IsSuccess && operationsDP.IsSuccess && operationsDP.Value.Item1.Any();
				_needShowPointsExpirationFilter = res.IsSuccess && result2.IsSuccess && result2.Value.Item1.Any();
			}
			else
			{
				_needShowDelayedPointsFilter = false;
				_needShowPointsExpirationFilter = false;
			}
		}
		AddDelayedPointsFilterIfNeeded();
		AddPointsExpirationFilterIfNeeded();
		FilterItemViewModel filterItemViewModel = FiltersPane.Filters.FirstOrDefault((FilterItemViewModel f) => f.Filter.Id == (int)_parameter.OpenOnStartup);
		if (filterItemViewModel == null || (filterItemViewModel != null && filterItemViewModel.IsSelected))
		{
			await Task.Delay(500);
			_lockVisualState = false;
			UpdateVisualStateIfNeeded(error);
		}
		else if (filterItemViewModel != null && !filterItemViewModel.IsSelected)
		{
			_lockVisualState = false;
			SetActiveFilter(filterItemViewModel);
			await LoadPurchasesByType();
		}
	}

	public void RetryLoadPurchasesByType()
	{
		LoadPurchasesByType().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async void OnFilterItemsSelected(FilterItemViewModel filterItem, int position)
	{
		if (filterItem == null || FiltersPane.ActiveFilter == filterItem)
		{
			return;
		}
		try
		{
			ResetCollectionCommand.Trigger();
			SetActiveFilter(filterItem);
			await LoadPurchasesByType();
		}
		catch (Exception)
		{
		}
	}

	public void OnPurchaseItemsSelected(FeedItemViewModel feedItem, int position)
	{
		if (!(feedItem is DelayedPointsItemViewModel))
		{
			if (feedItem is PurchaseItemViewModel { OperationType: var operationType } purchaseItemViewModel)
			{
				if (operationType == QualifiedLoyaltyOperationType.Purchase || (uint)(operationType - 10) <= 1u || operationType == QualifiedLoyaltyOperationType.Refund)
				{
					PurchaseItemViewModel purchaseItemViewModel2 = feedItem as PurchaseItemViewModel;
					purchaseItemViewModel2.ShouldDisplayStamps = _adminContext.StampsConfig?.ShowStampsInHistory ?? false;
					_openPurchaseDetails.OnNext(new PurchaseDetailsViewModel.Parameter(purchaseItemViewModel2, null));
				}
				else
				{
					_openOperationDetails.OnNext(new OperationDetailsViewModel.Parameter(purchaseItemViewModel));
				}
			}
		}
		else
		{
			DelayedPointsItemViewModel delayedPointsItemViewModel = feedItem as DelayedPointsItemViewModel;
			if (!string.IsNullOrEmpty(delayedPointsItemViewModel?.ChequeNumber))
			{
				_openPurchaseDetails.OnNext(new PurchaseDetailsViewModel.Parameter(null, delayedPointsItemViewModel?.ChequeNumber));
			}
		}
	}

	private async Task<Result<(IReadOnlyList<LoyaltyProgramPurchase>, int), DomainError>> LoadNextHistoryItemsAsync(int offset, int limit)
	{
		bool valueOrDefault = _adminContext.StampsConfig?.ShowStampsInHistory == true;
		HistoryFilter historyFilter = FiltersPane.ActiveFilter?.Filter;
		if (historyFilter != null && historyFilter.Id == 661)
		{
			historyFilter = null;
		}
		Result<(IEnumerable<LoyaltyProgramPurchase>, int, HistoryFilter[]), DomainError> result = await _purchasesRepository.GetHistoryAsync(historyFilter, offset, limit, valueOrDefault);
		if (!result.IsSuccess)
		{
			return result.Error;
		}
		var (source, item, array) = result.Value;
		AddHistoryFiltersIfNeeded(array ?? Array.Empty<HistoryFilter>());
		return (source.ToImmutableList(), item);
	}

	private async Task<Result<(IReadOnlyList<DelayedPointsEntryEntity>, int), DomainError>> LoadNextDelayedPointsAsync(int offset, int limit)
	{
		Result<(IEnumerable<DelayedPointsEntryEntity>, int), DomainError> result = await _loyaltyManager.GetDelayedPoints(_currencyList, offset, limit);
		if (!result.IsSuccess)
		{
			return result.Error;
		}
		var (source, item) = result.Value;
		AddDelayedPointsFilterIfNeeded();
		return (source.ToImmutableList(), item);
	}

	private async Task<Result<(IReadOnlyList<FeedItemViewModel>, int), DomainError>> LoadNextPointsExpirationAsync(int offset, int limit)
	{
		Result<(IEnumerable<FeedItemViewModel>, int), DomainError> result = await _pointsExpirationDataProvider.GetHistoryAsync(_currencyList, offset, limit);
		if (!result.IsSuccess)
		{
			return Result.Failure<(IReadOnlyList<FeedItemViewModel>, int), DomainError>(result.Error);
		}
		var (source, item) = result.Value;
		AddPointsExpirationFilterIfNeeded();
		return Result.Success<(IReadOnlyList<FeedItemViewModel>, int), DomainError>((source.ToImmutableList(), item));
	}

	public void LoadNext()
	{
		if (FiltersPane.ActiveFilter != null && FiltersPane.ActiveFilter.Filter.Id == 661)
		{
			_pagedDelayedPoints.LoadMore();
			return;
		}
		FilterItemViewModel activeFilter = FiltersPane.ActiveFilter;
		if (activeFilter != null)
		{
			HistoryFilter filter = activeFilter.Filter;
			if (filter != null && filter.Id == 662)
			{
				_pagedPointsExpiration.LoadMore();
				return;
			}
		}
		_pagedHistoryItems.LoadMore();
	}

	private void OnHistoryItemsUpdated(DomainError? error)
	{
		if (_parameter.OpenOnStartup == FiltersIds.Delayed && FiltersPane.ActiveFilter == null)
		{
			return;
		}
		FilterItemViewModel? activeFilter = FiltersPane.ActiveFilter;
		if (activeFilter == null || activeFilter.Filter.Id != 661)
		{
			bool valueOrDefault = _adminContext.StampsConfig?.ShowStampsInHistory == true;
			base.ItemsCollection.ReplaceRange(AddHeaderAndDateItems(_pagedHistoryItems.Select((LoyaltyProgramPurchase p) => new PurchaseItemViewModel(p)).FilterStamps(valueOrDefault)));
			UpdateVisualStateIfNeeded(error);
		}
	}

	private void OnDelayedItemsUpdated(DomainError? error)
	{
		if (FiltersPane.ActiveFilter == null || FiltersPane.ActiveFilter.Filter.Id == 661)
		{
			base.ItemsCollection.ReplaceRange(AddHeaderAndDateItems(_pagedDelayedPoints.Select((DelayedPointsEntryEntity p) => new DelayedPointsItemViewModel(p))));
			UpdateVisualStateIfNeeded(error);
		}
	}

	private void OnPointsExpirationUpdated(DomainError? error)
	{
		if ((_parameter.OpenOnStartup != FiltersIds.Delayed || FiltersPane.ActiveFilter != null) && (FiltersPane.ActiveFilter == null || FiltersPane.ActiveFilter.Filter.Id == 662))
		{
			base.ItemsCollection.ReplaceRange(AddHeaderAndDateItems(_pagedPointsExpiration));
			UpdateVisualStateIfNeeded(error);
		}
	}

	private void UpdateVisualStateIfNeeded(DomainError? error)
	{
		if (_lockVisualState)
		{
			return;
		}
		if (!base.ItemsCollection.Any())
		{
			State = ((error != null && !(error is NoDataError)) ? VisualState.Error : VisualState.Empty);
			return;
		}
		State = VisualState.Default;
		if (error != null && !(error is NoDataError))
		{
			_infoMessageService.ShowSnackbar("Не удалось загрузить данные.");
		}
	}

	private IEnumerable<FeedItemViewModel> AddHeaderAndDateItems(IEnumerable<FeedItemViewModel> items)
	{
		DateTime dateOfOperation = default(DateTime);
		int value = FiltersPane.ActiveFilter?.Filter.Id ?? 0;
		if (items.Any() && WITH_FILTER.Contains((FiltersIds)value))
		{
			yield return new DeleayedPointsInformerItemViewModel(ShowDelayedPointsInfoCommand);
		}
		foreach (FeedItemViewModel item in items)
		{
			if (item is ILoyaltyOperation { OperationDate: var operationDate } loyaltyOperation)
			{
				if (operationDate.Date != dateOfOperation)
				{
					dateOfOperation = loyaltyOperation.OperationDate.Date;
					yield return new DateItemViewModel(dateOfOperation);
				}
				yield return item;
			}
		}
	}

	private async Task LoadPurchasesByType()
	{
		State = VisualState.InProgress;
		_pagedHistoryItems = ResetHistoryDataLoader();
		base.ItemsCollection.Clear();
		if (FiltersPane.ActiveFilter != null && FiltersPane.ActiveFilter.Filter.Id == 661)
		{
			OnDelayedItemsUpdated(null);
		}
		else if (FiltersPane.ActiveFilter == null || FiltersPane.ActiveFilter.Filter.Id != 662)
		{
			await _pagedHistoryItems.LoadFirst();
		}
		else
		{
			OnPointsExpirationUpdated(null);
		}
	}

	private void AddPointsExpirationFilterIfNeeded()
	{
		if (_needShowPointsExpirationFilter && !FiltersPane.Filters.Any((FilterItemViewModel f) => f.Filter.Id == 662))
		{
			FilterItemViewModel item = new FilterItemViewModel(OnFilterItemsSelected, new HistoryFilter
			{
				Id = 662,
				Name = "Скоро сгорят"
			});
			List<FilterItemViewModel> list = FiltersPane.Filters.ToList();
			list.Add(item);
			FiltersPane.Filters = list;
		}
	}

	private void AddDelayedPointsFilterIfNeeded()
	{
		if (_needShowDelayedPointsFilter && !FiltersPane.Filters.Any((FilterItemViewModel f) => f.Filter.Id == 661))
		{
			FilterItemViewModel filterItemViewModel = new FilterItemViewModel(OnFilterItemsSelected, new HistoryFilter
			{
				Id = 661,
				Name = "Неактивные баллы"
			});
			List<FilterItemViewModel> list = FiltersPane.Filters.ToList();
			list.Add(filterItemViewModel);
			FiltersPane.Filters = list;
			if (_parameter.OpenOnStartup == FiltersIds.Delayed || FiltersPane.Filters.Count() == 1)
			{
				FiltersPane.ActiveFilter = filterItemViewModel;
				filterItemViewModel.IsSelected = true;
			}
		}
	}

	private void AddHistoryFiltersIfNeeded(HistoryFilter[] newFilters)
	{
		if (FiltersPane.Filters.Any((FilterItemViewModel f) => f.Filter.Id == 0))
		{
			return;
		}
		List<FilterItemViewModel> list = FiltersPane.Filters.ToList();
		FilterItemViewModel filterItemViewModel = new FilterItemViewModel(OnFilterItemsSelected, new HistoryFilter
		{
			Id = 0,
			Name = "Все"
		});
		list.Insert(0, filterItemViewModel);
		if (_adminContext.StampsConfig?.ShowStampsInHistory != true)
		{
			newFilters = newFilters.Where((HistoryFilter f) => f.Id != 6).ToArray();
		}
		list.InsertRange(1, newFilters.Select((HistoryFilter f) => new FilterItemViewModel(OnFilterItemsSelected, f)));
		FiltersPane.Filters = list;
		if (_parameter.OpenOnStartup != FiltersIds.Delayed && !FiltersPane.Filters.Any((FilterItemViewModel f) => f.IsSelected))
		{
			FiltersPane.ActiveFilter = filterItemViewModel;
			filterItemViewModel.IsSelected = true;
		}
		else
		{
			FiltersPane.ScrollToActiveFilter();
		}
	}

	private void SetActiveFilter(FilterItemViewModel filter)
	{
		foreach (FilterItemViewModel item in FiltersPane.Filters.Where((FilterItemViewModel f) => f.IsSelected))
		{
			item.IsSelected = false;
		}
		filter.IsSelected = true;
		FiltersPane.ActiveFilter = filter;
	}

	public void HandleLink(string url)
	{
		_urlNavigationHandler.HandleUrl(url);
	}
}
