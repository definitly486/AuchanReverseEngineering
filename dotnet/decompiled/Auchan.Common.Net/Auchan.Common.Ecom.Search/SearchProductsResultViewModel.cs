using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Ecom.Search.FilterViewModels;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Ecom.Search.Models;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Logs;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.Reviews;
using Auchan.Common.StoreReview;
using CSharpFunctionalExtensions;
using EBind;

namespace Auchan.Common.Ecom.Search;

public class SearchProductsResultViewModel : ScreenViewModel, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public sealed class Parameter
	{
		public string? Query { get; init; }
	}

	private int _lastSearchStoreId;

	private Parameter? _parameter;

	private readonly SearchProductsManager _searchManager;

	private readonly ILogService _logService;

	private readonly SearchProductsRepository _searchRepository;

	private readonly SearchAutohintsService _autohintsService;

	private readonly Lazy<Auchan.Common.StoreReview.StoreReview> _storeReview;

	private readonly Func<Product, ProductRecommendationsViewModel, ICollection<IDisposable>, ProductItemViewModel> _viewModelFactory;

	private readonly Func<RecommendationBuilder> _recommendationBuilderFactory;

	private readonly IEcomContext _ecomContext;

	private readonly CompositeDisposable _pauseDisposables = new CompositeDisposable();

	private readonly CompositeDisposable _searchResultsDisposables = new CompositeDisposable();

	private bool _storeChanged;

	[CompilerGenerated]
	private IReadOnlyList<ProductItemViewModel> _003CSearchProductResults_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<BaseItemViewModel> _003CItemsForView_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<ProductDetailsViewModel.Parameter> _003CNavigateToDetailsCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<SearchProductsFormViewModel.Parameter, string?> _003COpenSearchFormCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003COpenSearchFormWithClearCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003COpenSearchSortsCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003COpenSearchFiltersCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CCloseCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CResetSearchCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CFullCloseCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<string> _003CLoadRecommendationsCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CLoadEmptyRecommendationsCommand_003Ek__BackingField;

	[CompilerGenerated]
	private ProductRecommendationsViewModel _003CProductRecommendationsViewModel_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CProductCountText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CFiltersAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CFiltersSelected_003Ek__BackingField;

	public string SearchPlaceholder => "Найти в АШАН";

	public string EmptySearchTitle => "Ничего не найдено";

	public string EmptySearchSubtitle => "Попробуйте изменить условия поиска";

	public string EmptySearchButton => "Изменить запрос";

	public string CancelButton => "Отменить";

	public string ProgressTitle => "Ищем нужные товары…";

	protected override string ScreenName => "Item_list_search";

	public bool AutofillsAvailable => Autofills.Count > 0;

	public ObservableRangeCollection<SearchAutofillItemViewModel> Autofills => _autohintsService.Autofills;

	public UICommand<SearchAutofillItemViewModel> SelectAutofillItemCommand { get; } = new UICommand<SearchAutofillItemViewModel>();

	public IReadOnlyList<ProductItemViewModel> SearchProductResults
	{
		[CompilerGenerated]
		get
		{
			return _003CSearchProductResults_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSearchProductResults_003Ek__BackingField, value))
			{
				_003CSearchProductResults_003Ek__BackingField = value;
				RaisePropertyChanged("SearchProductResults");
			}
		}
	} = new List<ProductItemViewModel>();

	public IReadOnlyList<BaseItemViewModel> ItemsForView
	{
		[CompilerGenerated]
		get
		{
			return _003CItemsForView_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CItemsForView_003Ek__BackingField, value))
			{
				_003CItemsForView_003Ek__BackingField = value;
				RaisePropertyChanged("ItemsForView");
			}
		}
	} = new List<BaseItemViewModel>();

	public UICommand<ProductDetailsViewModel.Parameter> NavigateToDetailsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CNavigateToDetailsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CNavigateToDetailsCommand_003Ek__BackingField, value))
			{
				_003CNavigateToDetailsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("NavigateToDetailsCommand");
			}
		}
	} = new UICommand<ProductDetailsViewModel.Parameter>();

	public UICommand<ProductItemViewModel> ShowQtyDialogCommand { get; } = new UICommand<ProductItemViewModel>();

	public UICommand<ProductReviewsViewModel.Parameter> OpenReviewsCommand { get; } = new UICommand<ProductReviewsViewModel.Parameter>();

	public UICommand<SearchProductsFormViewModel.Parameter, string?> OpenSearchFormCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenSearchFormCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenSearchFormCommand_003Ek__BackingField, value))
			{
				_003COpenSearchFormCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenSearchFormCommand");
			}
		}
	} = new UICommand<SearchProductsFormViewModel.Parameter, string>((string? query) => new SearchProductsFormViewModel.Parameter(query));

	public UICommand OpenSearchFormWithClearCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenSearchFormWithClearCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenSearchFormWithClearCommand_003Ek__BackingField, value))
			{
				_003COpenSearchFormWithClearCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenSearchFormWithClearCommand");
			}
		}
	} = new UICommand();

	public UICommand OpenSearchSortsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenSearchSortsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenSearchSortsCommand_003Ek__BackingField, value))
			{
				_003COpenSearchSortsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenSearchSortsCommand");
			}
		}
	} = new UICommand();

	public UICommand OpenSearchFiltersCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenSearchFiltersCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenSearchFiltersCommand_003Ek__BackingField, value))
			{
				_003COpenSearchFiltersCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenSearchFiltersCommand");
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

	public UICommand ResetSearchCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CResetSearchCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CResetSearchCommand_003Ek__BackingField, value))
			{
				_003CResetSearchCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ResetSearchCommand");
			}
		}
	} = new UICommand();

	public UICommand FullCloseCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CFullCloseCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CFullCloseCommand_003Ek__BackingField, value))
			{
				_003CFullCloseCommand_003Ek__BackingField = value;
				RaisePropertyChanged("FullCloseCommand");
			}
		}
	} = new UICommand();

	private UICommand<string> LoadRecommendationsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CLoadRecommendationsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CLoadRecommendationsCommand_003Ek__BackingField, value))
			{
				_003CLoadRecommendationsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("LoadRecommendationsCommand");
			}
		}
	} = new UICommand<string>();

	private UICommand LoadEmptyRecommendationsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CLoadEmptyRecommendationsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CLoadEmptyRecommendationsCommand_003Ek__BackingField, value))
			{
				_003CLoadEmptyRecommendationsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("LoadEmptyRecommendationsCommand");
			}
		}
	} = new UICommand();

	public RecommendationsViewModel Recommendations { get; }

	public RecommendationsViewModel EmptyRecommendations { get; }

	public ProductRecommendationsViewModel ProductRecommendationsViewModel
	{
		[CompilerGenerated]
		get
		{
			return _003CProductRecommendationsViewModel_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CProductRecommendationsViewModel_003Ek__BackingField, value))
			{
				_003CProductRecommendationsViewModel_003Ek__BackingField = value;
				RaisePropertyChanged("ProductRecommendationsViewModel");
			}
		}
	}

	public IObservable<bool> WhenEmptyState => from x in _searchRepository.OnPropertyChanges((SearchProductsRepository x) => x.CurrentSearchState).StartWith(_searchRepository.CurrentSearchState)
		select x == SearchVisualState.NotFound;

	public IObservable<bool> WhenContentState => from x in _searchRepository.OnPropertyChanges((SearchProductsRepository x) => x.CurrentSearchState).StartWith(_searchRepository.CurrentSearchState)
		select x == SearchVisualState.Content;

	public SearchVisualState SearchState => _searchRepository.CurrentSearchState;

	public string SearchQuery => _searchRepository.CurrentSearchQuery;

	public string ProductCountText
	{
		[CompilerGenerated]
		get
		{
			return _003CProductCountText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CProductCountText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CProductCountText_003Ek__BackingField = value;
				RaisePropertyChanged("ProductCountText");
			}
		}
	} = string.Empty;

	public bool FiltersAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CFiltersAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CFiltersAvailable_003Ek__BackingField != value)
			{
				_003CFiltersAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("FiltersAvailable");
			}
		}
	}

	public bool FiltersSelected
	{
		[CompilerGenerated]
		get
		{
			return _003CFiltersSelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CFiltersSelected_003Ek__BackingField != value)
			{
				_003CFiltersSelected_003Ek__BackingField = value;
				RaisePropertyChanged("FiltersSelected");
			}
		}
	}

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "Searchlist";

	string IYandexMetricaScreenViewModel.ScreenName => "Searchlist";

	public string FiltersText => "Фильтры";

	public string SortTypeName => _searchRepository.CurrentSearchSorts.FirstOrDefault((SortItemViewModel x) => x.IsSelected)?.Title ?? ProductSortTypes.DefaultSort.Name;

	public SearchProductsResultViewModel(Parameter parameter, SearchProductsManager productsManager, ILogService logService, Func<Product, ProductRecommendationsViewModel, ICollection<IDisposable>, ProductItemViewModel> viewmModelFactory, Func<RecommendationBuilder> recommendationBuilderFactory, IEcomContext ecomContext, RecommendationsViewModel recommendations, RecommendationsViewModel emptyRecommendations, Func<ICollection<IDisposable>, ScreenViewModel, Func<string?, bool>, ProductRecommendationsViewModel> productRecommendations, SearchProductsRepository searchProductsRepository, SearchAutohintsService autohintsService, Lazy<Auchan.Common.StoreReview.StoreReview> storeReview)
	{
		_parameter = parameter;
		_searchManager = productsManager;
		_logService = logService;
		_viewModelFactory = viewmModelFactory;
		_recommendationBuilderFactory = recommendationBuilderFactory;
		_ecomContext = ecomContext;
		_searchRepository = searchProductsRepository;
		_autohintsService = autohintsService;
		_storeReview = storeReview;
		Recommendations = recommendations.Setup(base.CloseDisposable, this);
		EmptyRecommendations = emptyRecommendations.Setup(base.CloseDisposable, this);
		ProductRecommendationsViewModel = productRecommendations(base.CloseDisposable, this, IsExist);
		_searchResultsDisposables.AddTo(base.CloseDisposable);
	}

	protected override async Task Start()
	{
		await base.Start();
		_ecomContext.OnPropertyChanges((IEcomContext ec) => ec.ActiveStore).Subscribe(delegate
		{
			_storeChanged = true;
		}).AddTo(base.CloseDisposable);
		RxTaskExtensions.StartWithDefault(_searchRepository.CurrentSearchResults.CollectionChangedAsObservable()).Subscribe(delegate
		{
			ProductRecommendationsViewModel.ResetData();
			_searchResultsDisposables.Clear();
			IReadOnlyList<ProductItemViewModel> itemsForView = (SearchProductResults = _searchRepository.CurrentSearchResults.Select((Product p) => _viewModelFactory(p, ProductRecommendationsViewModel, _searchResultsDisposables)).ToList());
			ItemsForView = itemsForView;
			int count = _searchRepository.CurrentSearchResults.Count;
			string value = GrammarHelper.DeclineNoun(count, new string[3] { "Найден", "Найдено", "Найдено" });
			ProductCountText = $"{value} {count} товар{GrammarHelper.DeclineNoun(count)}";
			FiltersAvailable = _searchRepository.CurrentSearchFilters.Any();
			FiltersSelected = _searchRepository.CurrentSearchFilters.Any((BaseFilterItemViewModel f) => f.GetSelectedFilter() != null);
			if (count < 1)
			{
				LoadEmptyRecommendationsCommand.Trigger();
			}
			else if (!string.IsNullOrWhiteSpace(_searchRepository.CurrentSearchQuery))
			{
				LoadRecommendationsCommand.Trigger(_searchRepository.CurrentSearchQuery);
			}
			RaisePropertyChanged("SortTypeName");
		}).AddTo(base.CloseDisposable);
		OpenSearchFormWithClearCommand.Subscribe(delegate
		{
			OpenSearchFormCommand.Trigger(string.Empty);
		}).AddTo(base.CloseDisposable);
		_searchRepository.OnPropertyChanges((SearchProductsRepository r) => r.CurrentSearchState).Subscribe(delegate
		{
			RaisePropertyChanged("SearchState");
		}).AddTo(base.CloseDisposable);
		(from s in _searchRepository.OnPropertyChanges((SearchProductsRepository r) => r.CurrentSearchState)
			where s != SearchVisualState.Content
			select s).Subscribe(delegate
		{
			Recommendations.Clear().SafeFireAndForget((Action<Exception>)null, false);
		}).AddTo(base.CloseDisposable);
		_searchManager.OnSearchReset += new DisposableDelegate<EventHandler>(delegate
		{
			FullCloseCommand.Trigger();
		}, delegate(EventHandler d)
		{
			_searchManager.OnSearchReset -= d;
		}).AddTo(base.CloseDisposable);
		ProductRecommendationsViewModel.OnAddedOrRemoved += new DisposableDelegate<Action<ProductRecommendationsViewModel.AddOrRemoveHandler>>(delegate(ProductRecommendationsViewModel.AddOrRemoveHandler action)
		{
			IReadOnlyList<BaseItemViewModel> collection = ItemsForView;
			action(ref collection);
			ItemsForView = collection;
		}, delegate(Action<ProductRecommendationsViewModel.AddOrRemoveHandler> d)
		{
			ProductRecommendationsViewModel.OnAddedOrRemoved -= d;
		}).AddTo(base.CloseDisposable);
		_searchRepository.OnPropertyChanges((SearchProductsRepository r) => r.CurrentSearchQuery).Subscribe(delegate
		{
			_autohintsService.UpdateAutohints(SearchQuery).SafeFireAndForget((Action<Exception>)null, false);
			RaisePropertyChanged("SearchQuery");
		}).AddTo(base.CloseDisposable);
		LoadRecommendationsCommand.PerformDebouncingTask(async delegate(string query)
		{
			await LoadRecommendations(query);
		}).Subscribe().AddTo(base.CloseDisposable);
		LoadEmptyRecommendationsCommand.PerformDebouncingTask(LoadRecommendationsForEmptyScreen).Subscribe().AddTo(base.CloseDisposable);
		CloseCommand.Subscribe(delegate
		{
			ResetSearchCommand.Trigger();
		}).AddTo(base.CloseDisposable);
		ResetSearchCommand.Subscribe(delegate
		{
			_searchManager.ResetSearchState();
		}).AddTo(base.CloseDisposable);
		RxTaskExtensions.StartWithDefault(_autohintsService.Autofills.CollectionChangedAsObservable()).Subscribe(delegate
		{
			RaisePropertyChanged("AutofillsAvailable");
		}).AddTo(base.CloseDisposable);
		SelectAutofillItemCommand.PerformDebouncingTask(OnAutofillSelected).Subscribe().AddTo(base.CloseDisposable);
	}

	public async Task OnBindCompletedAsync()
	{
		if (_parameter?.Query != null)
		{
			await _searchManager.ProductsBySearchQuery(_parameter.Query);
			_parameter = null;
			_storeReview.Value.RequestReviewIfNeeded().SafeFireAndForget((Action<Exception>)null, false);
		}
		else if (!SearchProductResults.Any())
		{
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			_ = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			awaiter.GetResult();
			OpenSearchFormCommand.Trigger(null);
		}
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		_logService.LogInfo("SearchProductsResultViewModel", "Открыт экран с результатами поиска", LogType.UserAction, SystemType.MobileApp);
		_ecomContext.SyncReceiveMethodQueued().SafeFireAndForget((Action<Exception>)null, false);
		if (_lastSearchStoreId != 0 && _lastSearchStoreId != _ecomContext.ActiveStore.Id)
		{
			_storeChanged = true;
		}
		(from _ in _ecomContext.OnPropertyChanges((IEcomContext ec) => ec.ActiveStore)
			where SearchQuery.Length > 3
			select _).StartWithIf(_storeChanged, _ecomContext.ActiveStore).PerformSamplingTask((Store _) => SearchProductsAsync(SearchQuery)).Subscribe()
			.AddTo(_pauseDisposables);
		if (SearchProductResults.Any())
		{
			_storeReview.Value.RequestReviewIfNeeded().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	protected override Task OnPaused()
	{
		_pauseDisposables.Clear();
		return base.OnPaused();
	}

	private async Task SearchProductsAsync(string query)
	{
		_storeChanged = false;
		ProductRecommendationsViewModel.BlockResetData();
		Result<SearchProducts, DomainError> result = await _searchManager.ProductsBySearchQuery(query);
		_lastSearchStoreId = _ecomContext.ActiveStore.Id;
		if (result.IsFailure || result.Value.Products.Count < 1)
		{
			LoadEmptyRecommendationsCommand.Trigger();
		}
		else
		{
			LoadRecommendationsCommand.Trigger(query);
		}
	}

	public void NavigateToProductDetails(ProductItemViewModel productItemViewModel)
	{
		string code = productItemViewModel.Product.Code;
		NavigateToDetailsCommand.Trigger(new ProductDetailsViewModel.Parameter(code));
	}

	private async Task LoadRecommendations(string searchPhrase)
	{
		LoadRequest loadRequest = _recommendationBuilderFactory().AddSearch("Часто покупают", "search_bottom", searchPhrase).Build();
		await Recommendations.Load(loadRequest);
		ProductRecommendationsViewModel.ForceUpdate();
	}

	private async Task LoadRecommendationsForEmptyScreen()
	{
		LoadRequest loadRequest = _recommendationBuilderFactory().AddPersonal("Персональные рекомендации", "search_empty_screen").Build();
		await EmptyRecommendations.Load(loadRequest);
	}

	private Task OnAutofillSelected(SearchAutofillItemViewModel model)
	{
		_searchRepository.ClearSearchFilters();
		_searchRepository.ResetSearchSort();
		return _searchManager.ProductsBySearchQuery(model.FullText, null, saveQuery: true, sendAnalytics: true);
	}

	private bool IsExist(string? gimaId)
	{
		return SearchProductResults.Any((ProductItemViewModel x) => x.Product.GimaId == gimaId);
	}
}
