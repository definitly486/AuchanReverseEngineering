using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.Banners;
using Auchan.Common.Ecom.Banners.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.Filters;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels.Filters;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.Promotions;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.API.DTO;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.Reviews;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Ecom.Products.ViewModels;

public sealed class CatalogProductsViewModel : ScreenViewModel<CatalogProductsViewModel.Parameter>, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public sealed class Parameter : BrokeredParameter
	{
		public long? Id { get; }

		public string Title { get; }

		public string Code { get; }

		public BrandDto? Brand { get; }

		public ProductsToLoad ProductsToLoadType { get; }

		public ProductSortSelection? DefaultSortSelection { get; }

		public bool FromSpotlight { get; }

		public IReadOnlyList<string> Breadcrumbs { get; }

		public bool FromMyCategories { get; }

		public Parameter(string title, string code, ProductsToLoad productsToLoadType, long? id = null, ProductSortSelection? sortSelection = null, bool fromSpotlight = false, bool fromMyCategories = false)
		{
			Id = id;
			Title = title;
			Code = code;
			ProductsToLoadType = productsToLoadType;
			DefaultSortSelection = sortSelection;
			FromSpotlight = fromSpotlight;
			Breadcrumbs = new global::_003C_003Ez__ReadOnlySingleElementList<string>(Title);
			FromMyCategories = fromMyCategories;
		}

		public Parameter(Category category, IReadOnlyList<string>? breadcrumbs = null)
			: this(category.Name, category.Code, ProductsToLoad.ByCategory, category.Id, category.DefaultSortMap?.FirstOrDefault().Value)
		{
			Breadcrumbs = breadcrumbs ?? new global::_003C_003Ez__ReadOnlySingleElementList<string>(category.Name);
		}
	}

	private const int ItemsPerPage = 25;

	private readonly IResolver _resolver;

	private readonly IProductsManager _productsManager;

	private readonly IProductsRepository _productsRepository;

	private readonly DefaultErrorTranslator _errorTranslator;

	private readonly IEcomContext _ecomContext;

	private readonly ILogService _logService;

	private readonly ICategoryRepository _categoryRepository;

	private readonly IDataBroker _dataBroker;

	private readonly IUserContext _userContext;

	private readonly Lazy<IBannersRepository> _bannersRepository;

	private readonly IAdminContext _adminContext;

	private readonly IRecommendationsRepository _recommendationsRepository;

	private readonly Func<ProductWithAnalyticsInfo, ICollection<IDisposable>, RecomProductItemViewModel> _recomItemViewModelFactory;

	private readonly Func<Product, ICollection<IDisposable>, ProductItemViewModel> _viewModelFactory;

	private readonly Func<RecommendationBuilder> _recommendationBuilderFactory;

	private readonly IAgeGateDialog _ageGateDialog;

	private readonly Subject<Unit> _loadMore = new Subject<Unit>();

	private readonly TaskQueue _loadRecommendationsQueue = new TaskQueue();

	private int nextPageCount;

	private bool _loadedAll;

	private bool _activeStoreWasChanged;

	private ProductSortType? _selectedSort;

	private bool _sortOrFilterSelectedByUser;

	private string? _recommendationsCategoryPath;

	private Category? _category;

	private readonly HashSet<string> _loadedGimaIds = new HashSet<string>();

	private IEnumerable<BaseProductFilterItemViewModel.Usage>? _usages;

	[CompilerGenerated]
	private UICommand<WebViewModel.Parameter> _003COpenBannerRulesCommand_003Ek__BackingField;

	[CompilerGenerated]
	private BrandDto? _003CBrand_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CTotalCount_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CHasBanners_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	private ProductFilterResult? _productFilterResult;

	[CompilerGenerated]
	private IReadOnlyList<ProductSortType> _003CSortTypes_003Ek__BackingField;

	public bool FromMyCategories => base.Argument.FromMyCategories;

	private IReadOnlyList<string> Breadcrumbs => base.Argument.Breadcrumbs;

	public UICommand<ProductDetailsViewModel.Parameter> NavigateToProductDetailsCommand { get; } = new UICommand<ProductDetailsViewModel.Parameter>();

	public UICommand<ProductReviewsViewModel.Parameter> OpenReviewsCommand { get; } = new UICommand<ProductReviewsViewModel.Parameter>();

	public UICommand OnItemsResetCommand { get; } = new UICommand();

	public UICommand SortCommand { get; } = new UICommand();

	public UICommand FiltersCommand { get; } = new UICommand();

	public UICommand<BrokerToken> OpenSortCommand { get; } = new UICommand<BrokerToken>();

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

	public UICommand<ProductItemViewModel> ShowQtyDialogCommand { get; } = new UICommand<ProductItemViewModel>();

	public string SearchPlaceholder => "Поиск товаров";

	public RecommendationsViewModel Recommendations { get; }

	public ObservableRangeCollection<Banner> SalesBannerList { get; } = new ObservableRangeCollection<Banner>();

	public string Title { get; }

	public string ProgressTitle => "Загружаем товары…";

	public BrandDto? Brand
	{
		[CompilerGenerated]
		get
		{
			return _003CBrand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CBrand_003Ek__BackingField, value))
			{
				_003CBrand_003Ek__BackingField = value;
				RaisePropertyChanged("IsFiltersButtonBadgeVisible");
				RaisePropertyChanged("Brand");
			}
		}
	}

	public int TotalCount
	{
		[CompilerGenerated]
		get
		{
			return _003CTotalCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CTotalCount_003Ek__BackingField != value)
			{
				_003CTotalCount_003Ek__BackingField = value;
				RaisePropertyChanged("CountVisible");
				RaisePropertyChanged("TotalCount");
			}
		}
	}

	public bool CountVisible => TotalCount > 0;

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
				RaisePropertyChanged("IsSortButtonVisible");
				RaisePropertyChanged("IsFilteringAvailable");
				RaisePropertyChanged("IsFiltersButtonBadgeVisible");
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

	public bool IsAuthorized => _userContext.Authorized;

	public ObservableRangeCollection<ProductItemViewModel> Products { get; } = new ObservableRangeCollection<ProductItemViewModel>();

	public bool IsSortButtonVisible
	{
		get
		{
			if (State == VisualState.Default)
			{
				return SortTypes.IsNotNullOrEmpty();
			}
			return false;
		}
	}

	public bool IsFiltersButtonBadgeVisible
	{
		get
		{
			if (IsFilteringAvailable)
			{
				ProductFilterResult? productFilterResult = ProductFilterResult;
				if (productFilterResult == null || !productFilterResult.IsFiltersSelected)
				{
					return Brand != null;
				}
				return true;
			}
			return false;
		}
	}

	public bool IsFilteringAvailable => State == VisualState.Default;

	public UICommand ClosePageCommand { get; } = new UICommand();

	private ProductFilterResult? ProductFilterResult
	{
		get
		{
			return _productFilterResult;
		}
		set
		{
			if (!object.Equals(_productFilterResult, value))
			{
				_productFilterResult = value;
				RaisePropertyChanged("IsFiltersButtonBadgeVisible");
				RaisePropertyChanged("ProductFilterResult");
				Brand = null;
			}
		}
	}

	private IReadOnlyList<ProductSortType> SortTypes
	{
		[CompilerGenerated]
		get
		{
			return _003CSortTypes_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CSortTypes_003Ek__BackingField, value))
			{
				_003CSortTypes_003Ek__BackingField = value;
				RaisePropertyChanged("IsSortButtonVisible");
				RaisePropertyChanged("SortTypes");
			}
		}
	} = Array.Empty<ProductSortType>();

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "Catalog_" + Title;

	string IYandexMetricaScreenViewModel.ScreenName => "Catalog_" + Title;

	public BannerNavigationSupport BannerNavigationSupport { get; } = new BannerNavigationSupport();

	public UICommand<PromotionViewModel.Parameter> OpenPromotionDetailsCommand { get; } = new UICommand<PromotionViewModel.Parameter>();

	public CatalogProductsViewModel(BrokerToken brokerToken, IResolver resolver, IProductsManager productManager, IProductsRepository productsRepository, DefaultErrorTranslator errorTranslator, IEcomContext ecomContext, ILogService logService, ICategoryRepository categoryRepository, Func<Product, ICollection<IDisposable>, ProductItemViewModel> viewModelFactory, Func<RecommendationBuilder> recommendationBuilderFactory, IAgeGateDialog ageGateDialog, RecommendationsViewModel recommendations, IDataBroker dataBroker, IUserContext userContext, Lazy<IBannersRepository> bannersRepository, IAdminContext adminContext, IRecommendationsRepository recommendationsRepository, Func<ProductWithAnalyticsInfo, ICollection<IDisposable>, RecomProductItemViewModel> recomItemViewModelFactory)
		: base(brokerToken)
	{
		_resolver = resolver;
		_productsManager = productManager;
		_productsRepository = productsRepository;
		_errorTranslator = errorTranslator;
		_ecomContext = ecomContext;
		_categoryRepository = categoryRepository;
		_viewModelFactory = viewModelFactory;
		_recommendationBuilderFactory = recommendationBuilderFactory;
		_ageGateDialog = ageGateDialog;
		_logService = logService;
		_dataBroker = dataBroker;
		_userContext = userContext;
		_bannersRepository = bannersRepository;
		_adminContext = adminContext;
		_recommendationsRepository = recommendationsRepository;
		_recomItemViewModelFactory = recomItemViewModelFactory;
		Recommendations = recommendations.Setup(base.CloseDisposable, this);
		Title = base.Argument.Title;
		Brand = base.Argument.Brand;
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadAll();
		SortCommand.PerformDebouncingTask(OpenSort).Subscribe().AddTo(base.CloseDisposable);
		FiltersCommand.PerformDebouncingTask(OpenFiltersAsync).Subscribe().AddTo(base.CloseDisposable);
		if (base.Argument.FromSpotlight)
		{
			AppAnalytics.AppMetrica.TrackEvent("Spotlight");
		}
		if (base.Argument.ProductsToLoadType == ProductsToLoad.ByCategory && base.Argument.Id.HasValue)
		{
			AppAnalytics.Ecom.ViewCategory(base.Argument.Id.Value);
		}
		if (base.Argument.ProductsToLoadType == ProductsToLoad.ByCategory && !string.IsNullOrWhiteSpace(_recommendationsCategoryPath))
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
		_logService.LogInfo("CatalogProductsViewModel", "Открыт список товаров", LogType.UserAction, SystemType.MobileApp);
		if (_activeStoreWasChanged)
		{
			_activeStoreWasChanged = false;
			await LoadAll();
		}
		_loadMore.Debounce(500).PerformDebouncingTask((Unit _) => LoadNextPageCommand()).Subscribe()
			.AddTo(base.PauseDisposable);
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).PerformTask((Func<Store, Task>)async delegate
		{
			_activeStoreWasChanged = false;
			await LoadAll();
		}, (IScheduler?)null).Subscribe()
			.AddTo(base.PauseDisposable);
	}

	public void LoadNextPage()
	{
		_loadMore.OnNext(Unit.Default);
	}

	public async Task OpenSort()
	{
		ProductsOrderViewModel.Parameter parameter = new ProductsOrderViewModel.Parameter(GetSortType(), SortTypes);
		OpenSortCommand.Trigger(_dataBroker.Push(parameter));
		Result<ProductSortType> result = await parameter.WaitForResultAsync();
		if (result.IsSuccess)
		{
			_selectedSort = result.Value;
			_sortOrFilterSelectedByUser = true;
			await ReloadProducts();
		}
		ProductSortType? GetSortType()
		{
			if (_selectedSort == null && base.Argument.DefaultSortSelection != null)
			{
				ProductSortSelection defaultSort = base.Argument.DefaultSortSelection;
				return SortTypes.FirstOrDefault((ProductSortType sortType) => sortType.Direction == defaultSort.Direction && sortType.Field == defaultSort.Field);
			}
			return _selectedSort;
		}
	}

	public async Task OpenFiltersAsync()
	{
		ProductFilterResult productFilterResult = ProductFilterResult;
		State = VisualState.InProgress;
		Result<ProductFilterResult, DomainError> result = await GetFiltersAsync(productFilterResult);
		if (result.IsFailure)
		{
			State = VisualState.Error;
			return;
		}
		State = VisualState.Default;
		productFilterResult = (ProductFilterResult = result.Value);
		ProductFiltersViewModel.Parameter parameter = new ProductFiltersViewModel.Parameter(productFilterResult, _usages, base.Argument.Code);
		OpenFiltersCommand.Trigger(_dataBroker.Push(parameter));
		ProductFiltersViewModel.Result result2 = await parameter.WaitForResultAsync();
		if (result2 != null)
		{
			ProductFilterResult = result2.Filters;
			_usages = result2.Usages;
			_sortOrFilterSelectedByUser = true;
			await ReloadProducts();
		}
	}

	public void Retry()
	{
		LoadAll().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void NavigateToDetails(ProductItemViewModel itemViewModel)
	{
		_logService.LogInfo("CatalogProductsViewModel", "Запрошен переход на экран товара", LogType.UserAction, SystemType.MobileApp);
		itemViewModel.RecomAnalyticActions.OnNavigateToProductDetails(itemViewModel);
		NavigateToProductDetailsCommand.Trigger(new ProductDetailsViewModel.Parameter(itemViewModel.Code));
	}

	private async Task LoadAll()
	{
		State = VisualState.InProgress;
		await LoadParentCategoryInfo();
		await GetSortTypes();
		if (base.Argument.ProductsToLoadType == ProductsToLoad.ByCategory)
		{
			LoadRecommendations().SafeFireAndForget((Action<Exception>)null, false);
		}
		await Task.WhenAll(LoadProducts(), LoadPromotions());
		await Task.Delay(300);
		if (State != VisualState.Error)
		{
			State = VisualState.Default;
		}
	}

	private async Task LoadRecommendations()
	{
		if (!string.IsNullOrWhiteSpace(_recommendationsCategoryPath))
		{
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			_ = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			awaiter.GetResult();
			LoadRequest builder = _recommendationBuilderFactory().AddCategoryPlacementsAndPopularsInCategory("Хиты продаж из категории", PlacementId.Category, _recommendationsCategoryPath, "product_list").Build();
			await _loadRecommendationsQueue.Enqueue(async delegate
			{
				await Recommendations.Clear();
				await Recommendations.Load(builder);
			});
		}
	}

	private async Task ReloadProducts()
	{
		State = VisualState.InProgress;
		await LoadProducts();
		OnItemsResetCommand.Trigger();
		if (State != VisualState.Error)
		{
			State = VisualState.Default;
		}
	}

	private async Task LoadProducts()
	{
		nextPageCount = 0;
		_loadedAll = false;
		_loadedGimaIds.Clear();
		Products.Clear();
		Task task = LoadFilters();
		Task<Result<ProductResult, DomainError>> productsTask = Load(0);
		Task<Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError>> rrTask = LoadTopProductsFromRR();
		await Task.WhenAll(productsTask, task, rrTask);
		Result<ProductResult, DomainError> result = productsTask.Result;
		Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError> result2 = rrTask.Result;
		Result<ProductResult, DomainError> result3 = result;
		if (result3.IsFailure && result2.IsFailure)
		{
			(string, string) tuple = _errorTranslator.Translate(result3.Error);
			ErrorTitle = tuple.Item1;
			ErrorMessage = tuple.Item2;
			State = VisualState.Error;
			return;
		}
		if (!result3.TryGetValue(out var value))
		{
			value = new ProductResult
			{
				Items = Array.Empty<Product>()
			};
		}
		if (!result2.TryGetValue(out var value2))
		{
			value2 = Array.Empty<ProductWithAnalyticsInfo>();
		}
		ImmutableList<Product> immutableList = value2.Select((ProductWithAnalyticsInfo i) => i.Product).Concat(value.Items).ToImmutableList();
		if (immutableList.Count == 0 || immutableList.All((Product x) => !x.IsActive || !x.InStock))
		{
			State = VisualState.Empty;
		}
		_logService.LogInfo("Products for Adults", $"Получили новый набор товаров с IsAdult={value.IsAdult}", LogType.ApiRequest, SystemType.ECom);
		if (base.Argument.ProductsToLoadType == ProductsToLoad.ByCategory && base.Argument.Id.HasValue)
		{
			AppAnalytics.Ecom.ViewCategoryListing(base.Argument.Id.Value, 1, Title, value.Items, base.Argument.Breadcrumbs);
		}
		IReadOnlyList<RecomProductItemViewModel> readOnlyList = CreateRecomViewModels(value2);
		IReadOnlyList<ProductItemViewModel> second = CreateProductViewModels(value.Items);
		Products.ReplaceRange(readOnlyList.Concat(second));
		RecomProductItemViewModel recomProductItemViewModel = readOnlyList.FirstOrDefault();
		recomProductItemViewModel?.RecomAnalyticActions.BlockViewed(recomProductItemViewModel.RecomAnalytics.BlockId);
	}

	private IReadOnlyList<RecomProductItemViewModel> CreateRecomViewModels(IReadOnlyList<ProductWithAnalyticsInfo> recommendations)
	{
		return recommendations.Where((ProductWithAnalyticsInfo i) => !string.IsNullOrEmpty(i.Product.GimaId) && !_loadedGimaIds.Contains(i.Product.GimaId)).Select(delegate(ProductWithAnalyticsInfo i)
		{
			_loadedGimaIds.Add(i.Product.GimaId);
			RecomProductItemViewModel recomProductItemViewModel = _recomItemViewModelFactory(i, base.CloseDisposable);
			recomProductItemViewModel.Breadcrumbs = Breadcrumbs;
			return recomProductItemViewModel;
		}).ToImmutableList();
	}

	private IReadOnlyList<ProductItemViewModel> CreateProductViewModels(IReadOnlyList<Product> items)
	{
		return items.Where((Product x) => !string.IsNullOrEmpty(x.GimaId) && !_loadedGimaIds.Contains(x.GimaId)).Select(delegate(Product x)
		{
			_loadedGimaIds.Add(x.GimaId);
			ProductItemViewModel productItemViewModel = _viewModelFactory(x, base.CloseDisposable);
			productItemViewModel.Breadcrumbs = Breadcrumbs;
			return productItemViewModel;
		}).ToImmutableList();
	}

	private async Task LoadParentCategoryInfo()
	{
		if (base.Argument.ProductsToLoadType != ProductsToLoad.ByCategory)
		{
			return;
		}
		var (flag3, _, list2) = await Task.Run(() => _categoryRepository.GetCategoriesTree(base.Argument.Code));
		if (!flag3)
		{
			return;
		}
		Category top = list2.First();
		_category = list2.FirstOrDefaultRecursive((Category category2) => category2.Code == base.Argument.Code, (Category category2) => category2.Items);
		bool flag4 = (_category?.IsAdult ?? false) && _ecomContext.AgeGateAgreement != AgreeState.Yes;
		if (flag4)
		{
			flag4 = await _ageGateDialog.ShowAgeGateDialogAsync() != AgreeState.Yes;
		}
		if (flag4)
		{
			ClosePageCommand.Trigger();
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (Category category = top; category != null; category = category.Items?.FirstOrDefault())
		{
			stringBuilder.Append(category.Name);
			if (category.Code == base.Argument.Code)
			{
				break;
			}
			if (category.HasChildCategories)
			{
				stringBuilder.Append("/");
			}
		}
		_recommendationsCategoryPath = stringBuilder.ToString();
	}

	private async Task LoadFilters()
	{
		ProductFilterResult productFilterResult = ProductFilterResult;
		if (productFilterResult != null)
		{
			Result<ProductFilterResult, DomainError> result = await GetFiltersAsync(productFilterResult);
			if (result.IsSuccess)
			{
				ProductFilterResult = result.Value;
			}
		}
	}

	private Task<Result<ProductFilterResult, DomainError>> GetFiltersAsync(ProductFilterResult? fr)
	{
		Dictionary<string, object> selected = new Dictionary<string, object>();
		if (fr != null)
		{
			selected.AddCollection(fr.GetSelectedFiltersForRequest());
		}
		if (Brand != null && !string.IsNullOrEmpty(Brand.Code))
		{
			selected["brand"] = new string[1] { Brand.Code };
		}
		return Task.Run(() => _productsManager.GetFiltersAsync(base.Argument.Code, new FilterRequestDto(selected)));
	}

	private async Task LoadNextPageCommand()
	{
		if (_loadedAll)
		{
			return;
		}
		nextPageCount++;
		int offset = nextPageCount * 25;
		if (!(await Load(offset)).TryGetValue(out var value))
		{
			return;
		}
		_logService.LogInfo("Products for Adults", $"Получили новый набор товаров с IsAdult={value.IsAdult}", LogType.ApiRequest, SystemType.ECom);
		IReadOnlyList<Product> items = value.Items;
		if (items.Count > 0)
		{
			if (base.Argument.ProductsToLoadType == ProductsToLoad.ByCategory && base.Argument.Id.HasValue)
			{
				AppAnalytics.Ecom.ViewCategoryListing(base.Argument.Id.Value, nextPageCount + 1, Title, items, base.Argument.Breadcrumbs);
			}
			IReadOnlyList<ProductItemViewModel> collection = CreateProductViewModels(items);
			Products.InsertRange(Products.Count, collection);
		}
		else
		{
			_loadedAll = true;
		}
	}

	private Task<Result<ProductResult, DomainError>> Load(int offset)
	{
		switch (base.Argument.ProductsToLoadType)
		{
		case ProductsToLoad.ByCategory:
			return LoadByCategory(offset);
		case ProductsToLoad.ByBrand:
			if (Brand == null || string.IsNullOrEmpty(Brand.Code))
			{
				return LoadByCategory(offset);
			}
			return Task.Run(() => _productsManager.GetProductsByCategoryAndBrandAsync(base.Argument.Code, Brand.Code, offset, _selectedSort, isAdult: true, ProductFilterResult?.GetSelectedFiltersForRequest()));
		default:
			return Task.FromResult(Result.Failure<ProductResult, DomainError>(new UnknownError()));
		}
		Task<Result<ProductResult, DomainError>> LoadByCategory(int offset2)
		{
			return Task.Run(() => _productsManager.GetProductsByCategoryAsync(base.Argument.Code, offset2, _selectedSort, isAdult: true, ProductFilterResult?.GetSelectedFiltersForRequest()));
		}
	}

	private async Task<Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError>> LoadTopProductsFromRR()
	{
		if (string.IsNullOrEmpty(_recommendationsCategoryPath) || !_userContext.Authorized || _sortOrFilterSelectedByUser || !_adminContext.AppConfig.RetailRocketActiveFeatures.Contains(RetailRocketFeature.PersonalizedCategory))
		{
			return (Result<IReadOnlyList<ProductWithAnalyticsInfo>, DomainError>)(IReadOnlyList<ProductWithAnalyticsInfo>)ImmutableList<ProductWithAnalyticsInfo>.Empty;
		}
		PersonalCompositeForCategoryByCategoryPathAlgorithm algorithm = PersonalCompositeForCategoryByCategoryPathAlgorithm.Create(_resolver, new PersonalCompositeForCategoryByCategoryPathArgument
		{
			CategoryPath = _recommendationsCategoryPath,
			Title = "",
			BlockId = "category_personalized"
		});
		return await _recommendationsRepository.Get(algorithm);
	}

	private async Task GetSortTypes()
	{
		Result<ProductSortTypes, DomainError> result = await Task.Run(() => _productsRepository.GetSortTypes());
		CatalogProductsViewModel catalogProductsViewModel = this;
		IReadOnlyList<ProductSortType> sortTypes;
		if (!result.IsSuccess)
		{
			IReadOnlyList<ProductSortType> readOnlyList = new List<ProductSortType> { ProductSortTypes.DefaultSort };
			sortTypes = readOnlyList;
		}
		else
		{
			sortTypes = result.Value.Items;
		}
		catalogProductsViewModel.SortTypes = sortTypes;
		if (base.Argument.DefaultSortSelection == null)
		{
			ProductSortSelection defaultSort = _category?.DefaultSortMap?.FirstOrDefault().Value;
			_selectedSort = SortTypes?.FirstOrDefault((ProductSortType sortType) => sortType.Direction == defaultSort?.Direction && sortType.Field == defaultSort.Field);
		}
	}

	private async Task LoadPromotions()
	{
		if ((await _bannersRepository.Value.GetBannersAsync()).TryGetValue(out var value) && value.TryGetValue(BannerType.Category, out var value2) && base.Argument.Id.HasValue)
		{
			SalesBannerList.ReplaceRange(value2.Where((Banner b) => b.CategoryIds.Contains(base.Argument.Id.Value)));
		}
		HasBanners = SalesBannerList.Count > 0;
	}

	public void TrackGoBack()
	{
		if (base.Argument.FromMyCategories)
		{
			AppAnalytics.AppMetrica.TrackEvent("Tap_MainPersonal_Back");
		}
	}
}
