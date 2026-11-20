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

public sealed class CollectionProductsViewModel : ScreenViewModel<CollectionProductsViewModel.Parameter>, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public sealed class Parameter : BrokeredParameter
	{
		public long? Id { get; }

		public string Title { get; }

		public string Code { get; }

		public BrandDto? Brand { get; }

		public ProductsToLoad ProductsToLoadType { get; }

		public ProductSortSelection? DefaultSortSelection { get; }

		public IReadOnlyList<string> Breadcrumbs { get; }

		public IReadOnlyList<Category>? Categories { get; }

		public Parameter(string title, string code, ProductsToLoad productsToLoadType, long? id = null, ProductSortSelection? sortSelection = null)
		{
			Id = id;
			Title = title;
			Code = code;
			ProductsToLoadType = productsToLoadType;
			DefaultSortSelection = sortSelection;
			Breadcrumbs = new global::_003C_003Ez__ReadOnlySingleElementList<string>(Title);
		}

		public Parameter(Category category, IReadOnlyList<string>? breadcrumbs = null)
			: this(category.Name, category.Code, ProductsToLoad.ByCategory, category.Id, category.DefaultSortMap?.FirstOrDefault().Value)
		{
			Breadcrumbs = breadcrumbs ?? new global::_003C_003Ez__ReadOnlySingleElementList<string>(category.Name);
			Categories = category?.Items;
		}

		public Parameter(Product product)
			: this(product.CategoryCodes.Last().Name, product.CategoryCodes.Last().Code, ProductsToLoad.ByBrand)
		{
			Brand = product.Brand;
		}
	}

	private const int ItemsPerPage = 25;

	private const string AllCategories = "Все";

	private readonly bool _constructed;

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

	private readonly Subject<Unit> _loadMore = new Subject<Unit>();

	private readonly TaskQueue _loadRecommendationsQueue = new TaskQueue();

	private int nextPageCount;

	private bool _loadedAll;

	private bool _activeStoreWasChanged;

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
	private bool _003CHasBanners_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CProductsCount_003Ek__BackingField;

	[CompilerGenerated]
	private SelectionItemViewModel<Category>? _003CSelectedCategory_003Ek__BackingField;

	private ProductFilterResult? _productFilterResult;

	[CompilerGenerated]
	private IReadOnlyList<ProductSortType>? _003CSortTypes_003Ek__BackingField;

	[CompilerGenerated]
	private ProductSortType? _003CSelectedSort_003Ek__BackingField;

	private IReadOnlyList<string> Breadcrumbs => base.Argument.Breadcrumbs ?? new List<string>();

	public UICommand<ProductDetailsViewModel.Parameter> NavigateToProductDetailsCommand { get; } = new UICommand<ProductDetailsViewModel.Parameter>();

	public UICommand<ProductReviewsViewModel.Parameter> OpenReviewsCommand { get; } = new UICommand<ProductReviewsViewModel.Parameter>();

	public UICommand NavigateBackCommand { get; } = new UICommand();

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
				RaisePropertyChanged("HasTopContent");
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

	public string SortTypeName => SelectedSort?.Name ?? ProductSortTypes.DefaultSort.Name;

	public string FiltersText => "Фильтры";

	public string? ProductsCount
	{
		[CompilerGenerated]
		get
		{
			return _003CProductsCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CProductsCount_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CProductsCount_003Ek__BackingField = value;
				RaisePropertyChanged("ProductsCount");
			}
		}
	}

	public IReadOnlyList<SelectionItemViewModel<Category>> CategoryItemViewModels { get; } = Array.Empty<SelectionItemViewModel<Category>>();

	public SelectionItemViewModel<Category>? SelectedCategory
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedCategory_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSelectedCategory_003Ek__BackingField, value))
			{
				SelectionItemViewModel<Category> selectedCategory = SelectedCategory;
				_003CSelectedCategory_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedCategoryCode");
				SelectionItemViewModel<Category> selectedCategory2 = SelectedCategory;
				OnSelectedCategoryChanged(selectedCategory, selectedCategory2);
				RaisePropertyChanged("SelectedCategory");
			}
		}
	}

	private string SelectedCategoryCode => SelectedCategory?.Item.Code ?? base.Argument.Code;

	public bool CategoriesVisible => CategoryItemViewModels.Count > 1;

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

	private IReadOnlyList<ProductSortType>? SortTypes
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
	}

	private ProductSortType? SelectedSort
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedSort_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!(_003CSelectedSort_003Ek__BackingField == value))
			{
				_003CSelectedSort_003Ek__BackingField = value;
				RaisePropertyChanged("SortTypeName");
				RaisePropertyChanged("SelectedSort");
			}
		}
	}

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "Catalog_" + Title;

	string IYandexMetricaScreenViewModel.ScreenName => "Catalog_" + Title;

	public string OkEmptyText => "Понятно";

	public string EmptyOffersText => "Скоро появятся новые предложения";

	public UICommand<int> OnItemsResetCommand { get; } = new UICommand<int>();

	public bool HasTopContent
	{
		get
		{
			if (!HasBanners)
			{
				return Recommendations.HasItems;
			}
			return true;
		}
	}

	public BannerNavigationSupport BannerNavigationSupport { get; } = new BannerNavigationSupport();

	public UICommand<PromotionViewModel.Parameter> OpenPromotionDetailsCommand { get; } = new UICommand<PromotionViewModel.Parameter>();

	public CollectionProductsViewModel(BrokerToken brokerToken, IResolver resolver, IProductsManager productManager, IProductsRepository productsRepository, DefaultErrorTranslator errorTranslator, IEcomContext ecomContext, ILogService logService, ICategoryRepository categoryRepository, Func<Product, ICollection<IDisposable>, ProductItemViewModel> viewModelFactory, Func<RecommendationBuilder> recommendationBuilderFactory, RecommendationsViewModel recommendations, IDataBroker dataBroker, IUserContext userContext, Lazy<IBannersRepository> bannersRepository, IAdminContext adminContext, IRecommendationsRepository recommendationsRepository, Func<ProductWithAnalyticsInfo, ICollection<IDisposable>, RecomProductItemViewModel> recomItemViewModelFactory)
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
		if (base.Argument.Categories.IsNotNullOrEmpty())
		{
			CategoryItemViewModels = CreateCategories(base.Argument.Categories);
			SelectedCategory = CategoryItemViewModels.FirstOrDefault();
		}
		_constructed = true;
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadAll(null);
		SortCommand.PerformDebouncingTask(OpenSort).Subscribe().AddTo(base.CloseDisposable);
		FiltersCommand.PerformDebouncingTask(OpenFiltersAsync).Subscribe().AddTo(base.CloseDisposable);
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
		_logService.LogInfo("CollectionProductsViewModel", "Открыт список товаров", LogType.UserAction, SystemType.MobileApp);
		if (_activeStoreWasChanged)
		{
			_activeStoreWasChanged = false;
			await LoadAll(SelectedSort);
		}
		_loadMore.Debounce(500).PerformDebouncingTask((Unit _) => LoadNextPageCommand()).Subscribe()
			.AddTo(base.PauseDisposable);
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).PerformTask((Func<Store, Task>)async delegate
		{
			_activeStoreWasChanged = false;
			await LoadAll(SelectedSort);
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
			SelectedSort = result.Value;
			_sortOrFilterSelectedByUser = true;
			await ReloadProducts();
			OnItemsResetCommand.Trigger(-1);
		}
		ProductSortType? GetSortType()
		{
			if (SelectedSort == null && base.Argument.DefaultSortSelection != null)
			{
				ProductSortSelection defaultSort = base.Argument.DefaultSortSelection;
				return SortTypes?.FirstOrDefault((ProductSortType sortType) => sortType.Direction == defaultSort.Direction && sortType.Field == defaultSort.Field);
			}
			return SelectedSort;
		}
	}

	private async Task OpenFiltersAsync()
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
		ProductFiltersViewModel.Parameter parameter = new ProductFiltersViewModel.Parameter(productFilterResult, _usages, SelectedCategoryCode);
		OpenFiltersCommand.Trigger(_dataBroker.Push(parameter));
		ProductFiltersViewModel.Result result2 = await parameter.WaitForResultAsync();
		if (result2 != null)
		{
			ProductFilterResult = result2.Filters;
			_usages = result2.Usages;
			_sortOrFilterSelectedByUser = true;
			await ReloadProducts();
			OnItemsResetCommand.Trigger(-1);
		}
	}

	public void Retry()
	{
		LoadAll(SelectedSort).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void NavigateToDetails(ProductItemViewModel itemViewModel)
	{
		_logService.LogInfo("CollectionProductsViewModel", "Запрошен переход на экран товара", LogType.UserAction, SystemType.MobileApp);
		itemViewModel.RecomAnalyticActions.OnNavigateToProductDetails(itemViewModel);
		NavigateToProductDetailsCommand.Trigger(new ProductDetailsViewModel.Parameter(itemViewModel.Code));
	}

	private async Task LoadAll(ProductSortSelection? selectedSort)
	{
		State = VisualState.InProgress;
		await LoadParentCategoryInfo();
		await GetSortTypes(selectedSort);
		if (base.Argument.ProductsToLoadType == ProductsToLoad.ByCategory)
		{
			LoadRecommendations();
		}
		await Task.WhenAll(LoadProducts(), LoadPromotions());
		await Task.Delay(300);
		if (State == VisualState.InProgress)
		{
			State = VisualState.Default;
		}
	}

	private void LoadRecommendations()
	{
		if (!string.IsNullOrWhiteSpace(_recommendationsCategoryPath))
		{
			LoadRequest builder = _recommendationBuilderFactory().AddCategoryPlacementsAndPopularsInCategory("Хиты продаж из категории", PlacementId.Category, _recommendationsCategoryPath, "product_list").Build();
			_loadRecommendationsQueue.Enqueue(async delegate
			{
				await Recommendations.Clear();
				await Recommendations.Load(builder);
				RaisePropertyChanged("HasTopContent");
			}).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private async Task ReloadProducts()
	{
		State = VisualState.InProgress;
		await LoadProducts();
		if (State == VisualState.InProgress)
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
		_logService.LogInfo("Products for Adults", $"Получили новый набор товаров с IsAdult={value.IsAdult}", LogType.ApiRequest, SystemType.ECom);
		if (base.Argument.ProductsToLoadType == ProductsToLoad.ByCategory && base.Argument.Id.HasValue)
		{
			AppAnalytics.Ecom.ViewCategoryListing(base.Argument.Id.Value, 1, Title, value.Items, base.Argument.Breadcrumbs);
		}
		if (!result2.TryGetValue(out var value2))
		{
			value2 = Array.Empty<ProductWithAnalyticsInfo>();
		}
		IReadOnlyList<RecomProductItemViewModel> readOnlyList = CreateRecomViewModels(value2);
		IReadOnlyList<ProductItemViewModel> second = CreateProductViewModels(value.Items);
		Products.ReplaceRange(readOnlyList.Concat(second));
		ProductsCount = (value2.Count + value.TotalCount).ToString();
		if (!Products.Any())
		{
			State = VisualState.Empty;
		}
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
		var (flag3, _, list2) = await Task.Run(() => _categoryRepository.GetCategoriesTree(SelectedCategoryCode));
		if (!flag3)
		{
			return;
		}
		Category category = list2.First();
		_category = list2.FirstOrDefaultRecursive((Category category3) => category3.Code == base.Argument.Code, (Category category3) => category3.Items);
		StringBuilder stringBuilder = new StringBuilder();
		for (Category category2 = category; category2 != null; category2 = category2.Items?.FirstOrDefault())
		{
			stringBuilder.Append(category2.Name);
			if (category2.Code == SelectedCategoryCode)
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
		return Task.Run(() => _productsManager.GetFiltersAsync(SelectedCategoryCode, new FilterRequestDto(selected)));
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
			return Task.Run(() => _productsManager.GetProductsByCategoryAndBrandAsync(SelectedCategoryCode, Brand.Code, offset, SelectedSort, isAdult: true, ProductFilterResult?.GetSelectedFiltersForRequest()));
		default:
			return Task.FromResult(Result.Failure<ProductResult, DomainError>(new UnknownError()));
		}
		Task<Result<ProductResult, DomainError>> LoadByCategory(int offset2)
		{
			return Task.Run(() => _productsManager.GetProductsByCategoryAsync(SelectedCategoryCode, offset2, SelectedSort, isAdult: true, ProductFilterResult?.GetSelectedFiltersForRequest()));
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

	private async Task GetSortTypes(ProductSortSelection? selectedSort)
	{
		Result<ProductSortTypes, DomainError> result = await Task.Run(() => _productsRepository.GetSortTypes());
		CollectionProductsViewModel collectionProductsViewModel = this;
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
		collectionProductsViewModel.SortTypes = sortTypes;
		UpdateSortBy(selectedSort);
	}

	private void UpdateSortBy(ProductSortSelection? sortSelection)
	{
		ProductSortSelection defaultSort = sortSelection ?? _category?.DefaultSortMap?.FirstOrDefault().Value ?? base.Argument.DefaultSortSelection;
		SelectedSort = SortTypes?.FirstOrDefault((ProductSortType sortType) => sortType.Direction == defaultSort?.Direction && sortType.Field == defaultSort.Field);
	}

	private async Task LoadPromotions()
	{
		if ((await _bannersRepository.Value.GetBannersAsync()).TryGetValue(out var value) && value.TryGetValue(BannerType.Category, out var value2) && base.Argument.Id.HasValue)
		{
			SalesBannerList.ReplaceRange(value2.Where((Banner b) => b.CategoryIds.Contains(base.Argument.Id.Value)));
		}
		HasBanners = SalesBannerList.Count > 0;
		RaisePropertyChanged("HasTopContent");
	}

	private IReadOnlyList<SelectionItemViewModel<Category>> CreateCategories(IReadOnlyList<Category> categories)
	{
		ImmutableList<SelectionItemViewModel<Category>>.Builder builder = ImmutableList.CreateBuilder<SelectionItemViewModel<Category>>();
		builder.Add(new SelectionItemViewModel<Category>(new Category
		{
			Code = base.Argument.Code,
			Name = "Все"
		}, selected: true));
		builder.AddRange(categories.Select((Category i) => new SelectionItemViewModel<Category>(i, selected: false)));
		return builder;
	}

	public void SelectCategory(SelectionItemViewModel<Category> selectedCategoryViewModel)
	{
		if (SelectedCategory == selectedCategoryViewModel)
		{
			if (SelectedCategory.Item.Name != "Все" && SelectedCategory.Selected)
			{
				SelectedCategory = CategoryItemViewModels.First();
			}
		}
		else
		{
			SelectedCategory = selectedCategoryViewModel;
		}
	}

	private void OnSelectedCategoryChanged(SelectionItemViewModel<Category>? previousCategory, SelectionItemViewModel<Category>? currentCategory)
	{
		if (previousCategory != null)
		{
			previousCategory.Selected = false;
		}
		if (currentCategory != null)
		{
			currentCategory.Selected = true;
		}
		if (_constructed)
		{
			UpdateStateAsync().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private async Task UpdateStateAsync()
	{
		if (SelectedCategory?.Item.Name == "Все")
		{
			UpdateSortBy(base.Argument.DefaultSortSelection);
		}
		else
		{
			UpdateSortBy(SelectedCategory?.Item.DefaultSortMap?.FirstOrDefault().Value);
		}
		ProductFilterResult = null;
		_usages = null;
		if (!string.IsNullOrWhiteSpace(_recommendationsCategoryPath))
		{
			_recommendationsCategoryPath = ((SelectedCategory?.Item.Name == "Все") ? _recommendationsCategoryPath : (_recommendationsCategoryPath + "/" + SelectedCategory?.Item.Name));
			LoadRecommendations();
		}
		await ReloadProducts();
		int subject = CategoryItemViewModels.IndexOf<SelectionItemViewModel<Category>>(SelectedCategory);
		OnItemsResetCommand.Trigger(subject);
	}
}
