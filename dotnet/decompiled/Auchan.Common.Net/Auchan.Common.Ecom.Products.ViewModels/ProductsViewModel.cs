using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.Banners;
using Auchan.Common.Ecom.Banners.Models;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.Reviews;
using Auchan.Common.StoreReview;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Ecom.Products.ViewModels;

public class ProductsViewModel : ScreenViewModel, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public class Parameter
	{
		public long? Id { get; init; }

		public required string Title { get; init; }

		public required string Code { get; init; }

		public ProductsToLoad ProductsToLoadType { get; init; }

		public ProductSortSelection? DefaultSortSelection { get; init; }

		public required IReadOnlyList<string> Breadcrumbs { get; init; }
	}

	private const int ItemsPerPage = 25;

	private readonly Parameter _parameter;

	private readonly IProductsManager _productsManager;

	private readonly IProductsRepository _productsRepository;

	private readonly DefaultErrorTranslator _errorTranslator;

	private readonly IEcomContext _ecomContext;

	private readonly ILogService _logService;

	private readonly ICategoryRepository _categoryRepository;

	private readonly IDataBroker _dataBroker;

	private readonly IUserContext _userContext;

	private readonly Func<Product, ICollection<IDisposable>, ProductItemViewModel> _viewModelFactory;

	private readonly Func<RecommendationBuilder> _recommendationBuilderFactory;

	private readonly Lazy<IBannersRepository> _bannersRepository;

	private readonly Subject<Unit> _loadMore = new Subject<Unit>();

	private readonly Subject<ProductSortType?> _onSortSelected = new Subject<ProductSortType>();

	private readonly TaskQueue _loadRecommendationsQueue = new TaskQueue();

	private bool _isSecondLevelCategory;

	private int nextPageCount;

	private bool _loadedAll;

	private bool _activeStoreWasChanged;

	private ProductSortType? _selectedSort;

	private List<string> _selectedCategoryCodes = new List<string>();

	private string? _recommendationsCategoryPath;

	private IReadOnlyList<ProductSortType>? _sortTypes;

	private Category? _category;

	private long? _brandId;

	[CompilerGenerated]
	private UICommand<WebViewModel.Parameter> _003COpenBannerRulesCommand_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsSortButtonVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsFiltersButtonBadgeVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CHasBanners_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsFilteringAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CFiltersBadgeText_003Ek__BackingField;

	private List<ProductsFilterItemViewModel> FilterOptions { get; } = new List<ProductsFilterItemViewModel>();

	private IReadOnlyList<string> Breadcrumbs => _parameter.Breadcrumbs;

	public ObservableRangeCollection<Banner> SalesBannerList { get; } = new ObservableRangeCollection<Banner>();

	public UICommand<ProductDetailsViewModel.Parameter> NavigateToProductDetailsCommand { get; } = new UICommand<ProductDetailsViewModel.Parameter>();

	public UICommand<ProductReviewsViewModel.Parameter> OpenReviewsCommand { get; } = new UICommand<ProductReviewsViewModel.Parameter>();

	public UICommand OnItemsResetCommand { get; } = new UICommand();

	public UICommand NavigateBackCommand { get; } = new UICommand();

	public UICommand<BrokerToken> OpenSortCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<ProductItemViewModel> ShowQtyDialogCommand { get; } = new UICommand<ProductItemViewModel>();

	public UICommand<BrokerToken> OpenFiltersCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<WebViewModel.Parameter> OpenBannerRulesCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenBannerRulesCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenBannerRulesCommand_003Ek__BackingField, value))
			{
				_003COpenBannerRulesCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenBannerRulesCommand");
			}
		}
	} = new UICommand<WebViewModel.Parameter>();

	public string ProgressTitle => "Загружаем товары…";

	public string SearchPlaceholder => "Поиск товаров";

	public string OkEmptyText => "Понятно";

	public string EmptyOffersText => "Скоро появятся новые предложения";

	public RecommendationsViewModel Recommendations { get; }

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return _003CTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
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
	} = VisualState.Default;

	public string ErrorTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CErrorTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorTitle");
			}
		}
	} = string.Empty;

	public string EmptyGoodsTitle => "Скоро появятся новые предложения";

	public string ErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorMessage");
			}
		}
	} = string.Empty;

	public bool IsCodeAvailable => _userContext.Authorized;

	public ObservableRangeCollection<ProductItemViewModel> Products { get; } = new ObservableRangeCollection<ProductItemViewModel>();

	public bool IsSortButtonVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsSortButtonVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsSortButtonVisible_003Ek__BackingField != value)
			{
				_003CIsSortButtonVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsSortButtonVisible");
			}
		}
	}

	public bool IsFiltersButtonBadgeVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsFiltersButtonBadgeVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsFiltersButtonBadgeVisible_003Ek__BackingField != value)
			{
				_003CIsFiltersButtonBadgeVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsFiltersButtonBadgeVisible");
			}
		}
	}

	public bool HasBanners
	{
		[CompilerGenerated]
		get
		{
			return _003CHasBanners_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CHasBanners_003Ek__BackingField != value)
			{
				_003CHasBanners_003Ek__BackingField = value;
				RaisePropertyChanged("HasBanners");
			}
		}
	}

	public bool IsFilteringAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CIsFilteringAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsFilteringAvailable_003Ek__BackingField != value)
			{
				_003CIsFilteringAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("IsFilteringAvailable");
			}
		}
	}

	public string FiltersBadgeText
	{
		[CompilerGenerated]
		get
		{
			return _003CFiltersBadgeText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CFiltersBadgeText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CFiltersBadgeText_003Ek__BackingField = value;
				RaisePropertyChanged("FiltersBadgeText");
			}
		}
	} = "0";

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "Catalog_" + _parameter.Title;

	string IYandexMetricaScreenViewModel.ScreenName => "Catalog_" + _parameter.Title;

	public BannerNavigationSupport BannerNavigationSupport { get; } = new BannerNavigationSupport();

	public ProductsViewModel(Parameter parameter, IProductsManager productManager, IProductsRepository productsRepository, DefaultErrorTranslator errorTranslator, IEcomContext ecomContext, ILogService logService, ICategoryRepository categoryRepository, Func<Product, ICollection<IDisposable>, ProductItemViewModel> viewModelFactory, Func<RecommendationBuilder> recommendationBuilderFactory, RecommendationsViewModel recommendations, IDataBroker dataBroker, IUserContext userContext, Lazy<IBannersRepository> bannersRepository)
	{
		_parameter = parameter;
		_productsManager = productManager;
		_productsRepository = productsRepository;
		_errorTranslator = errorTranslator;
		_ecomContext = ecomContext;
		_categoryRepository = categoryRepository;
		_viewModelFactory = viewModelFactory;
		_recommendationBuilderFactory = recommendationBuilderFactory;
		_logService = logService;
		_dataBroker = dataBroker;
		_userContext = userContext;
		_bannersRepository = bannersRepository;
		Recommendations = recommendations.Setup(base.CloseDisposable, this);
		_selectedSort = ((_parameter.ProductsToLoadType != ProductsToLoad.ByCashbackAvailable) ? null : new ProductSortType
		{
			Field = "cashbackValue",
			Direction = "desc"
		});
		_onSortSelected.PerformDebouncingTask(async delegate(ProductSortType order)
		{
			_selectedSort = order;
			await ReloadProducts();
		}).Subscribe().AddTo(base.CloseDisposable);
		IsFilteringAvailable = _parameter.ProductsToLoadType == ProductsToLoad.ByBrand || _parameter.ProductsToLoadType == ProductsToLoad.ByPromoOnly || _parameter.ProductsToLoadType == ProductsToLoad.ByCashbackAvailable;
		Title = _parameter.Title;
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadAll(null);
		if (_parameter.ProductsToLoadType == ProductsToLoad.ByCategory && _parameter.Id.HasValue)
		{
			AppAnalytics.Ecom.ViewCategory(_parameter.Id.Value);
		}
		if (_parameter.ProductsToLoadType == ProductsToLoad.ByCategory && !string.IsNullOrWhiteSpace(_recommendationsCategoryPath))
		{
			AppAnalytics.Ecom.ViewCategoryByPath(_recommendationsCategoryPath);
		}
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).Subscribe(delegate
		{
			_activeStoreWasChanged = true;
		}).AddTo(base.CloseDisposable);
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		_ecomContext.SyncReceiveMethodQueued().SafeFireAndForget((Action<Exception>)null, false);
		_logService.LogInfo("ProductsViewModel", "Открыт список товаров", LogType.UserAction, SystemType.MobileApp);
		if (_activeStoreWasChanged)
		{
			_activeStoreWasChanged = false;
			await LoadAll(_selectedSort);
		}
		_loadMore.Debounce(500).PerformDebouncingTask((Unit _) => LoadNextPageCommand()).Subscribe()
			.AddTo(base.PauseDisposable);
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).PerformTask((Func<Store, Task>)async delegate
		{
			_activeStoreWasChanged = false;
			await LoadAll(_selectedSort);
		}, (IScheduler?)null).Subscribe()
			.AddTo(base.PauseDisposable);
		DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<Auchan.Common.StoreReview.StoreReview>().RequestReviewIfNeeded().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void LoadNextPage()
	{
		_loadMore.OnNext(Unit.Default);
	}

	public async Task OpenSort()
	{
		ProductsOrderViewModel.Parameter parameter = new ProductsOrderViewModel.Parameter(GetSortType(), _sortTypes);
		OpenSortCommand.Trigger(_dataBroker.Push(parameter));
		Result<ProductSortType> result = await parameter.WaitForResultAsync();
		if (result.IsSuccess)
		{
			_selectedSort = result.Value;
			await ReloadProducts();
		}
		ProductSortType? GetSortType()
		{
			if (_selectedSort == null && _parameter.DefaultSortSelection != null)
			{
				ProductSortSelection defaultSort = _parameter.DefaultSortSelection;
				return _sortTypes.FirstOrDefault((ProductSortType sortType) => sortType.Direction == defaultSort.Direction && sortType.Field == defaultSort.Field);
			}
			return _selectedSort;
		}
	}

	public async Task OpenFiltersAsync()
	{
		ProductsFilterViewModel.Parameter parameter = new ProductsFilterViewModel.Parameter(_parameter.ProductsToLoadType, _parameter.Code, FilterOptions);
		OpenFiltersCommand.Trigger(_dataBroker.Push(parameter));
		Maybe<List<string>> maybe = await parameter.WaitForResultAsync();
		if (maybe.HasValue)
		{
			_selectedCategoryCodes = maybe.Value;
			IsFiltersButtonBadgeVisible = IsFilteringAvailable && _selectedCategoryCodes.Count > 0;
			FiltersBadgeText = _selectedCategoryCodes.Count.ToString();
			FilterOptions.ForEach(delegate(ProductsFilterItemViewModel x)
			{
				x.Selected = _selectedCategoryCodes.Contains(x.Code);
			});
			await ReloadProducts();
		}
	}

	public void Retry()
	{
		LoadAll(_selectedSort).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void NavigateToDetails(ProductItemViewModel itemViewModel)
	{
		_logService.LogInfo("ProductsViewModel", "Запрошен переход на экран товара", LogType.UserAction, SystemType.MobileApp);
		NavigateToProductDetailsCommand.Trigger(new ProductDetailsViewModel.Parameter(itemViewModel.Code));
	}

	public void OnSortSelected(ProductSortType? sort)
	{
		_onSortSelected.OnNext(sort);
	}

	public void OnFiltersSelected(List<string> filters)
	{
		IsFiltersButtonBadgeVisible = IsFilteringAvailable && _selectedCategoryCodes.Count > 0;
		FiltersBadgeText = _selectedCategoryCodes.Count.ToString();
	}

	private async Task LoadAll(ProductSortType? selectedSort)
	{
		State = VisualState.InProgress;
		await LoadParentCategoryInfo();
		await GetSortTypes(selectedSort);
		if (_parameter.ProductsToLoadType == ProductsToLoad.ByCategory)
		{
			await LoadRecommendations();
		}
		await Task.WhenAll(LoadProducts(), LoadFilters());
		await LoadPromotions();
		await Task.Delay(300);
		IsSortButtonVisible = _sortTypes.IsNotNullOrEmpty();
		if (State != VisualState.Error && State != VisualState.Empty)
		{
			State = VisualState.Default;
		}
	}

	private async Task LoadRecommendations()
	{
		if (!string.IsNullOrWhiteSpace(_recommendationsCategoryPath))
		{
			LoadRequest builder = _recommendationBuilderFactory().AddPopularInCategoryByPath("Хиты продаж из категории", "product_list", new global::_003C_003Ez__ReadOnlySingleElementList<string>(_recommendationsCategoryPath)).Build();
			_loadRecommendationsQueue.Enqueue(async delegate
			{
				await Recommendations.Load(builder);
			}).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private async Task ReloadProducts()
	{
		State = VisualState.InProgress;
		await LoadProducts();
		OnItemsResetCommand.Trigger();
		if (State != VisualState.Error && State != VisualState.Empty)
		{
			State = VisualState.Default;
		}
	}

	private async Task LoadProducts()
	{
		nextPageCount = 0;
		_loadedAll = false;
		Products.Clear();
		Result<ProductResult, DomainError> result = await Load(0);
		if (result.IsFailure)
		{
			(string, string) tuple = _errorTranslator.Translate(result.Error);
			ErrorTitle = tuple.Item1;
			ErrorMessage = tuple.Item2;
			State = VisualState.Error;
			return;
		}
		_logService.LogInfo("Products for Adults", $"Получили новый набор товаров с IsAdult={result.Value.IsAdult}", LogType.ApiRequest, SystemType.ECom);
		if (result.Value.Items.Count == 0)
		{
			State = VisualState.Empty;
			return;
		}
		if (_parameter.ProductsToLoadType == ProductsToLoad.ByCategory && _parameter.Id.HasValue)
		{
			AppAnalytics.Ecom.ViewCategoryListing(_parameter.Id.Value, 1, Title, result.Value.Items, _parameter.Breadcrumbs);
		}
		if (_parameter.ProductsToLoadType == ProductsToLoad.ByBrand && string.IsNullOrEmpty(Title))
		{
			Title = (from i in result.Value.Items
				where !string.IsNullOrEmpty(i.Brand?.Name) || string.IsNullOrEmpty(i.BrandName)
				select i.Brand?.Name ?? i.BrandName).FirstOrDefault() ?? Title;
		}
		Products.ReplaceRange(result.Value.Items.Select(delegate(Product x)
		{
			ProductItemViewModel productItemViewModel = _viewModelFactory(x, base.CloseDisposable);
			productItemViewModel.Breadcrumbs = Breadcrumbs;
			return productItemViewModel;
		}));
	}

	private async Task LoadParentCategoryInfo()
	{
		if (_parameter.ProductsToLoadType != ProductsToLoad.ByCategory)
		{
			return;
		}
		var (flag3, _, source) = await _categoryRepository.GetCategoriesTree(_parameter.Code);
		if (!flag3)
		{
			return;
		}
		Category category = source.First();
		StringBuilder stringBuilder = new StringBuilder();
		for (Category category2 = category; category2 != null; category2 = category2.Items?.FirstOrDefault())
		{
			stringBuilder.Append(category2.Name);
			if (category2.Code == _parameter.Code)
			{
				break;
			}
			if (category2.HasChildCategories)
			{
				stringBuilder.Append("/");
			}
		}
		_recommendationsCategoryPath = stringBuilder.ToString();
	}

	private async Task LoadFilters()
	{
		List<Category> result = null;
		switch (_parameter.ProductsToLoadType)
		{
		case ProductsToLoad.ByCategory:
		{
			Result<List<Category>, DomainError> result3 = await _categoryRepository.GetSubCategories(_parameter.Code);
			if (result3.IsFailure)
			{
				result3 = await _categoryRepository.GetSubCategoriesSecondLevel(_parameter.Code, isShowHidden: true);
				if (result3.IsFailure)
				{
					IsFilteringAvailable = false;
					return;
				}
				_isSecondLevelCategory = true;
			}
			IsFilteringAvailable = true;
			result = result3.Value;
			break;
		}
		case ProductsToLoad.ByBrand:
		{
			Result<Brand, DomainError> result6 = await _categoryRepository.Brand(_parameter.Code);
			if (result6.IsFailure)
			{
				_ = result6.Error;
				break;
			}
			result = result6.Value.Categories;
			_brandId = result6.Value.Id;
			break;
		}
		case ProductsToLoad.ByPromoOnly:
		{
			Result<List<Category>, DomainError> result4 = await _categoryRepository.TopCategories(promoOnly: true, activeOnly: true);
			if (result4.IsFailure)
			{
				_ = result4.Error;
			}
			else
			{
				result = result4.Value;
			}
			break;
		}
		case ProductsToLoad.ByCashbackAvailable:
		{
			Result<List<Category>, DomainError> result5 = await _categoryRepository.TopCategories(promoOnly: false, activeOnly: false, cashbackOnly: true);
			if (result5.IsFailure)
			{
				_ = result5.Error;
			}
			else
			{
				result = result5.Value;
			}
			break;
		}
		default:
		{
			Result<List<Category>, DomainError> result2 = await _categoryRepository.TopCategories();
			if (result2.IsFailure)
			{
				_ = result2.Error;
			}
			else
			{
				result = result2.Value;
			}
			break;
		}
		}
		if (result != null)
		{
			FilterOptions.Clear();
			IReadOnlyList<Category> readOnlyList = ((!_isSecondLevelCategory) ? result : result.FirstOrDefaultRecursive((Category categiry) => categiry.Code == _parameter.Code, (Category x) => x.Items)?.Items);
			if (readOnlyList != null)
			{
				foreach (Category item in readOnlyList)
				{
					FilterOptions.Add(new ProductsFilterItemViewModel(item.Name, _selectedCategoryCodes.Contains(item.Code), item.ProductsCount, item.Code));
				}
			}
			if (FilterOptions.Count < 2)
			{
				IsFilteringAvailable = false;
			}
		}
		else
		{
			IsFilteringAvailable = false;
		}
	}

	private async Task LoadNextPageCommand()
	{
		if (_loadedAll)
		{
			return;
		}
		nextPageCount++;
		int offset = nextPageCount * 25;
		Result<ProductResult, DomainError> result = await Load(offset);
		if (!result.IsSuccess)
		{
			return;
		}
		_logService.LogInfo("Products for Adults", $"Получили новый набор товаров с IsAdult={result.Value.IsAdult}", LogType.ApiRequest, SystemType.ECom);
		IReadOnlyList<Product> items = result.Value.Items;
		if (items.Count > 0)
		{
			if (_parameter.ProductsToLoadType == ProductsToLoad.ByCategory && _parameter.Id.HasValue)
			{
				AppAnalytics.Ecom.ViewCategoryListing(_parameter.Id.Value, nextPageCount + 1, Title, items, _parameter.Breadcrumbs);
			}
			IEnumerable<ProductItemViewModel> collection = await Task.Run(() => items.Select(delegate(Product x)
			{
				ProductItemViewModel productItemViewModel = _viewModelFactory(x, base.CloseDisposable);
				productItemViewModel.Breadcrumbs = Breadcrumbs;
				return productItemViewModel;
			}));
			Products.InsertRange(Products.Count, collection);
		}
		else
		{
			_loadedAll = true;
		}
	}

	private async Task<Result<ProductResult, DomainError>> Load(int offset)
	{
		return _parameter.ProductsToLoadType switch
		{
			ProductsToLoad.ByCategory => await _productsManager.GetProductsByCategoryAsync(_parameter.Code, offset, _selectedSort, isAdult: true, _selectedCategoryCodes), 
			ProductsToLoad.ByBrand => await _productsManager.GetProductsByBrandAsync(_parameter.Code, offset, _selectedSort, _selectedCategoryCodes), 
			ProductsToLoad.ByPromoOnly => await _productsManager.GetProductsSuperPricesAsync(offset, _selectedSort, _selectedCategoryCodes), 
			ProductsToLoad.ByCashbackAvailable => await _productsManager.GetProductsByCashbackAvailableAsync(offset, _selectedSort, _selectedCategoryCodes, isAdult: true), 
			_ => Result.Failure<ProductResult, DomainError>(new UnknownError()), 
		};
	}

	private async Task GetSortTypes(ProductSortType? selectedSort)
	{
		Result<ProductSortTypes, DomainError> result = await _productsRepository.GetSortTypes();
		ProductsViewModel productsViewModel = this;
		IReadOnlyList<ProductSortType> sortTypes;
		if (!result.IsSuccess)
		{
			IReadOnlyList<ProductSortType> readOnlyList = new global::_003C_003Ez__ReadOnlySingleElementList<ProductSortType>(ProductSortTypes.DefaultSort);
			sortTypes = readOnlyList;
		}
		else
		{
			sortTypes = result.Value.Items;
		}
		productsViewModel._sortTypes = sortTypes;
		ProductSortSelection sort = selectedSort ?? _parameter.DefaultSortSelection ?? _category?.DefaultSortMap?.FirstOrDefault().Value;
		_selectedSort = _sortTypes?.FirstOrDefault((ProductSortType sortType) => sortType.Direction == sort?.Direction && sortType.Field == sort.Field);
	}

	private async Task LoadPromotions()
	{
		if (!(await _bannersRepository.Value.GetBannersAsync()).TryGetValue(out var value))
		{
			return;
		}
		if (_parameter.ProductsToLoadType == ProductsToLoad.ByCategory && value.TryGetValue(BannerType.Category, out var value2) && _parameter.Id.HasValue)
		{
			SalesBannerList.ReplaceRange(value2.Where((Banner b) => b.CategoryIds.Contains(_parameter.Id.Value)));
		}
		else if (_parameter.ProductsToLoadType == ProductsToLoad.ByBrand && _brandId.HasValue && value.TryGetValue(BannerType.Brands, out value2))
		{
			SalesBannerList.ReplaceRange(value2.Where((Banner b) => b.BrandId == _brandId.Value));
		}
		HasBanners = SalesBannerList.Count > 0;
	}
}
