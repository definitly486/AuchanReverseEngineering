using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Reviews;
using Auchan.Common.StoreReview;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Profile;

public class FavoritesViewModel : ScreenViewModel, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public enum VisualState
	{
		Default,
		InProgress,
		Error,
		Empty
	}

	private readonly IResolver _resolver;

	private readonly Favorites _favorites;

	private readonly IDataBroker _dataBroker;

	private readonly Func<Product, ICollection<IDisposable>, ProductItemViewModel.ProductItemType, UICommand<ProductItemViewModel>, ProductItemViewModel> _viewModelFactory;

	private readonly IRecommendationsRepository _recommendationRepository;

	private string _selectedSortName = string.Empty;

	private readonly TaskQueue _updateDataQueue = new TaskQueue();

	private readonly IEcomContext _ecomContext;

	private readonly IInfoMessageService _infoMessageService;

	[CompilerGenerated]
	private UICommand<ProductItemViewModel> _003CShowReplacementCommand_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<CategoryItemViewModel> _003CCategoriesItemViewModels_003Ek__BackingField;

	public readonly UICommand GoToCatalogCommand = new UICommand();

	public readonly UICommand<ProductDetailsViewModel.Parameter, ProductItemViewModel> NavigateToProductDetailsCommand = new UICommand<ProductDetailsViewModel.Parameter, ProductItemViewModel>((ProductItemViewModel item) => new ProductDetailsViewModel.Parameter(item.Product.Code));

	public readonly UICommand GoBackCommand = new UICommand();

	private IReadOnlyList<ProductItemViewModel> _favoriteViewModels = ImmutableList<ProductItemViewModel>.Empty;

	[CompilerGenerated]
	private int _003CSelectedCategoryIndex_003Ek__BackingField;

	[CompilerGenerated]
	private CategoryItemViewModel _003CSelectedCategory_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<BrokerToken> _003CNavigateToReplacementCommand_003Ek__BackingField;

	private UICommand<ProductItemViewModel> ShowReplacementCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CShowReplacementCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CShowReplacementCommand_003Ek__BackingField, value))
			{
				_003CShowReplacementCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ShowReplacementCommand");
			}
		}
	} = new UICommand<ProductItemViewModel>();

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.InProgress;

	public IReadOnlyList<CategoryItemViewModel> CategoriesItemViewModels
	{
		[CompilerGenerated]
		get
		{
			return _003CCategoriesItemViewModels_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCategoriesItemViewModels_003Ek__BackingField, value))
			{
				_003CCategoriesItemViewModels_003Ek__BackingField = value;
				OnCategoriesItemViewModelsChanged();
				RaisePropertyChanged("CategoriesItemViewModels");
			}
		}
	} = ImmutableList<CategoryItemViewModel>.Empty;

	public ObservableRangeCollection<GroupedProductsItemViewModel> GroupedFavoritesItemViewModels { get; } = new ObservableRangeCollection<GroupedProductsItemViewModel>();

	public ObservableRangeCollection<CategoryTitleItemViewModel> CategoryTitleItemViewModel { get; } = new ObservableRangeCollection<CategoryTitleItemViewModel>();

	public ObservableRangeCollection<ProductItemViewModel> FavoritesItemViewModels { get; } = new ObservableRangeCollection<ProductItemViewModel>();

	public UICommand<ProductItemViewModel> ShowQtyDialogCommand { get; } = new UICommand<ProductItemViewModel>();

	public UICommand<ProductReviewsViewModel.Parameter> OpenReviewsCommand { get; } = new UICommand<ProductReviewsViewModel.Parameter>();

	public UICommand<BrokerToken, ProductsOrderViewModel.Parameter> OpenSortCommand { get; }

	public UICommand ScrollToTopCommand { get; } = new UICommand();

	public string Title => "Избранное";

	public string EmptyTitle => "В Избранном пока ничего нет";

	public string EmptyMessage => "Добавляйте товары в Избранное, и они появятся в этом разделе";

	public string GoToCatalogButtonText => "Перейти в каталог";

	public string ProgressTitle => "Загружаем ваши любимые товары…";

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "Favourite";

	string IYandexMetricaScreenViewModel.ScreenName => "Favourite";

	public int SelectedCategoryIndex
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedCategoryIndex_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CSelectedCategoryIndex_003Ek__BackingField != value)
			{
				_003CSelectedCategoryIndex_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedCategoryIndex");
			}
		}
	}

	public CategoryItemViewModel SelectedCategory
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
				CategoryItemViewModel selectedCategory = SelectedCategory;
				_003CSelectedCategory_003Ek__BackingField = value;
				CategoryItemViewModel selectedCategory2 = SelectedCategory;
				OnSelectedCategoryChanged(selectedCategory, selectedCategory2);
				RaisePropertyChanged("SelectedCategory");
			}
		}
	} = CategoryItemViewModel.NewAllCategories();

	public UICommand<BrokerToken> NavigateToReplacementCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CNavigateToReplacementCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CNavigateToReplacementCommand_003Ek__BackingField, value))
			{
				_003CNavigateToReplacementCommand_003Ek__BackingField = value;
				RaisePropertyChanged("NavigateToReplacementCommand");
			}
		}
	} = new UICommand<BrokerToken>();

	public FavoritesViewModel(IResolver resolver, Favorites favorites, IDataBroker dataBroker, Func<Product, ICollection<IDisposable>, ProductItemViewModel.ProductItemType, UICommand<ProductItemViewModel>, ProductItemViewModel> viewModelFactory, IRecommendationsRepository recommendationRepository, IEcomContext ecomContext, IInfoMessageService infoMessageService)
	{
		_resolver = resolver;
		_favorites = favorites;
		_dataBroker = dataBroker;
		_viewModelFactory = viewModelFactory;
		_recommendationRepository = recommendationRepository;
		_ecomContext = ecomContext;
		_infoMessageService = infoMessageService;
		_favorites.UpdateAllHeartsStates += delegate
		{
			_updateDataQueue.Enqueue(() => UpdateFavoritesData(_selectedSortName, dataFromMemory: true)).SafeFireAndForget((Action<Exception>)null, false);
		};
		_favorites.UpdateProductCommand = AddOrRemoveProduct;
		OpenSortCommand = new UICommand<BrokerToken, ProductsOrderViewModel.Parameter>((ProductsOrderViewModel.Parameter p) => _dataBroker.Push(p));
		ShowReplacementCommand.PerformDebouncingTask(ShowReplacementFor).Subscribe().AddTo(base.CloseDisposable);
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ReceivingMethod).PerformDebouncingTask(OnResumed).Subscribe()
			.AddTo(base.CloseDisposable);
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		_ecomContext.SyncReceiveMethodQueued().SafeFireAndForget((Action<Exception>)null, false);
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ReceivingMethod).PerformDebouncingTask((Func<Task>)async delegate
		{
			await _updateDataQueue.Enqueue(() => UpdateFavoritesData(_selectedSortName));
			DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<Auchan.Common.StoreReview.StoreReview>().RequestReviewIfNeeded().SafeFireAndForget((Action<Exception>)null, false);
		}, (IScheduler?)null).Subscribe()
			.AddTo(base.PauseDisposable);
		await _updateDataQueue.Enqueue(() => UpdateFavoritesData(_selectedSortName));
		DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<Auchan.Common.StoreReview.StoreReview>().RequestReviewIfNeeded().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void OnCategorySelected(CategoryItemViewModel selectedCategoryItemViewModel)
	{
		if (selectedCategoryItemViewModel == SelectedCategory)
		{
			CategoryItemViewModel categoryItemViewModel = CategoriesItemViewModels.FirstOrDefault();
			SelectedCategory = categoryItemViewModel ?? CategoryItemViewModel.NewAllCategories();
		}
		else
		{
			SelectedCategory = selectedCategoryItemViewModel;
		}
	}

	public void OnBackClicked()
	{
		GoBackCommand.Trigger();
	}

	public async Task OpenSort()
	{
		List<string> source = await _favorites.GetSortNames();
		List<ProductSortType> collection = source.Select((string x) => new ProductSortType
		{
			Name = x
		}).ToList();
		string name = ((!string.IsNullOrWhiteSpace(_selectedSortName)) ? _selectedSortName : (source.FirstOrDefault() ?? string.Empty));
		ProductsOrderViewModel.Parameter parameter = new ProductsOrderViewModel.Parameter(new ProductSortType
		{
			Name = name
		}, new List<ProductSortType>(collection));
		OpenSortCommand.Trigger(parameter);
		Result<ProductSortType?> result = await parameter.WaitForResultAsync();
		if (!result.IsFailure)
		{
			_updateDataQueue.Enqueue(async delegate
			{
				_selectedSortName = result.Value?.Name ?? string.Empty;
				await UpdateFavoritesData(_selectedSortName);
				ScrollToTopCommand.Trigger();
			}).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void NavigateToProductDetails(ProductItemViewModel productItemViewModel)
	{
		NavigateToProductDetailsCommand.Trigger(productItemViewModel);
	}

	public void OnGoToCatalogClick()
	{
		GoToCatalogCommand.Trigger();
	}

	private async Task UpdateFavoritesData(string selectedSortName = "", bool dataFromMemory = false)
	{
		if (State == VisualState.InProgress && dataFromMemory)
		{
			return;
		}
		State = VisualState.InProgress;
		if (!dataFromMemory)
		{
			IReadOnlyList<Product> source = await _favorites.GetFavoritesFromApi(selectedSortName);
			FavoritesViewModel favoritesViewModel = this;
			List<ProductItemViewModel> list = new List<ProductItemViewModel>();
			list.AddRange(source.Select((Product x) => _viewModelFactory(x, base.CloseDisposable, ProductItemViewModel.ProductItemType.Favorite, ShowReplacementCommand)));
			favoritesViewModel._favoriteViewModels = new _003C_003Ez__ReadOnlyList<ProductItemViewModel>(list);
		}
		CreateCategoriesForSelector();
		CreateProductsBy(SelectedCategory);
		State = ((GroupedFavoritesItemViewModels.Count == 0) ? VisualState.Empty : VisualState.Default);
	}

	private void CreateCategoriesForSelector()
	{
		List<CategoryItemViewModel> list = new List<CategoryItemViewModel>();
		list.Add(CategoryItemViewModel.NewAllCategories());
		list.AddRange(from x in (from product in _favoriteViewModels
				select product.Product.CategoryCodes?.FirstOrDefault()?.Name ?? string.Empty into categoryName
				where !string.IsNullOrWhiteSpace(categoryName)
				select categoryName).Distinct()
			select new CategoryItemViewModel(x));
		ImmutableList<CategoryItemViewModel> immutableList = ImmutableList.Create(new ReadOnlySpan<CategoryItemViewModel>(list.ToArray()));
		if (immutableList.Count > 1)
		{
			if (!CategoriesItemViewModels.SequenceEqual(immutableList, EqualityComparer<CategoryItemViewModel>.Create((CategoryItemViewModel? a, CategoryItemViewModel? b) => string.Equals(a?.Title, b?.Title))))
			{
				CategoriesItemViewModels = immutableList;
			}
		}
		else
		{
			CategoriesItemViewModels = ImmutableList<CategoryItemViewModel>.Empty;
		}
	}

	private void CreateProductsBy(CategoryItemViewModel? civm)
	{
		if (civm == null || civm.IsAllCategories)
		{
			CreateGroupedByCategoryProducts();
		}
		else
		{
			CreateGroupedBySelectedCategoryProducts(civm.Title);
		}
	}

	private void CreateGroupedByCategoryProducts()
	{
		GroupedFavoritesItemViewModels.Clear();
		foreach (CategoryItemViewModel categoriesItemViewModel in CategoriesItemViewModels)
		{
			if (!categoriesItemViewModel.IsAllCategories)
			{
				List<ProductItemViewModel> list = _favoriteViewModels.Where((ProductItemViewModel product) => product.Product.CategoryCodes?.FirstOrDefault()?.Name == categoriesItemViewModel.Title).ToList();
				ObservableRangeCollection<ProductItemViewModel> products = new ObservableRangeCollection<ProductItemViewModel>(list);
				ObservableRangeCollection<GroupedProductsItemViewModel> collection = new ObservableRangeCollection<GroupedProductsItemViewModel>
				{
					new GroupedProductsItemViewModel(categoriesItemViewModel.Title + $" ({list.Count})", products)
				};
				GroupedFavoritesItemViewModels.AddRange(collection);
			}
		}
		UpdateFavorites();
		UpdateTitles();
	}

	private void CreateGroupedBySelectedCategoryProducts(string selectedCategoryName)
	{
		GroupedFavoritesItemViewModels.Clear();
		List<ProductItemViewModel> list = _favoriteViewModels.Where((ProductItemViewModel product) => product.Product.CategoryCodes?.FirstOrDefault()?.Name == selectedCategoryName).ToList();
		ObservableRangeCollection<ProductItemViewModel> products = new ObservableRangeCollection<ProductItemViewModel>(list);
		ObservableRangeCollection<GroupedProductsItemViewModel> collection = new ObservableRangeCollection<GroupedProductsItemViewModel>
		{
			new GroupedProductsItemViewModel(selectedCategoryName + $" ({list.Count})", products)
		};
		GroupedFavoritesItemViewModels.AddRange(collection);
		UpdateFavorites();
		UpdateTitles();
	}

	private void UpdateTitles()
	{
		List<CategoryTitleItemViewModel> list = new List<CategoryTitleItemViewModel>();
		int num = 0;
		foreach (GroupedProductsItemViewModel groupedFavoritesItemViewModel in GroupedFavoritesItemViewModels)
		{
			list.Add(new CategoryTitleItemViewModel(groupedFavoritesItemViewModel.Title, num));
			num += groupedFavoritesItemViewModel.Products.Count;
		}
		CategoryTitleItemViewModel.Clear();
		CategoryTitleItemViewModel.AddRange(list);
	}

	private void UpdateFavorites()
	{
		List<ProductItemViewModel> list = new List<ProductItemViewModel>();
		int num = 0;
		foreach (GroupedProductsItemViewModel groupedFavoritesItemViewModel in GroupedFavoritesItemViewModels)
		{
			num += groupedFavoritesItemViewModel.Products.Count;
			list.AddRange(groupedFavoritesItemViewModel.Products);
		}
		FavoritesItemViewModels.Clear();
		FavoritesItemViewModels.AddRange(list);
	}

	private void AddOrRemoveProduct(Product product, bool isAdded)
	{
		IReadOnlyList<ProductItemViewModel> favoriteViewModels2;
		if (isAdded)
		{
			IReadOnlyList<ProductItemViewModel> favoriteViewModels = _favoriteViewModels;
			int num = 0;
			ProductItemViewModel[] array = new ProductItemViewModel[1 + favoriteViewModels.Count];
			foreach (ProductItemViewModel item in favoriteViewModels)
			{
				array[num] = item;
				num++;
			}
			array[num] = _viewModelFactory(product, base.CloseDisposable, ProductItemViewModel.ProductItemType.Favorite, ShowReplacementCommand);
			favoriteViewModels2 = new global::_003C_003Ez__ReadOnlyArray<ProductItemViewModel>(array);
		}
		else
		{
			List<ProductItemViewModel> list = new List<ProductItemViewModel>();
			list.AddRange(_favoriteViewModels.Where((ProductItemViewModel x) => x.Product.GimaId != product.GimaId));
			favoriteViewModels2 = new _003C_003Ez__ReadOnlyList<ProductItemViewModel>(list);
		}
		_favoriteViewModels = favoriteViewModels2;
	}

	private async Task ShowReplacementFor(ProductItemViewModel item)
	{
		string gimaId = item.Product.GimaId;
		State = VisualState.InProgress;
		Result<(IAlgorithm, IReadOnlyList<ProductWithAnalyticsInfo>), DomainError> result = await _recommendationRepository.GetFirstAvailableAsync(new global::_003C_003Ez__ReadOnlyArray<IAlgorithm>(new IAlgorithm[2]
		{
			AnalogsOutOfStockProductsAlgorithm.Create(_resolver, new AnalogsOutOfStockProductsArgument
			{
				ProductIds = new global::_003C_003Ez__ReadOnlySingleElementList<string>(gimaId),
				BlockId = "analogs",
				Title = "Замена товара"
			}),
			AlternativesAlgorithm.Create(_resolver, new AlternativesArgument
			{
				ProductIds = new global::_003C_003Ez__ReadOnlySingleElementList<string>(gimaId),
				BlockId = "alternatives",
				Title = "Замена товара"
			})
		}));
		State = VisualState.Default;
		if (result.TryGetError(out var _))
		{
			ShowError();
		}
		if (result.TryGetValue(out var value))
		{
			IReadOnlyList<ProductWithAnalyticsInfo> item2 = value.Item2;
			if (item2.Count == 0)
			{
				ShowError();
				return;
			}
			NavigateToReplacementCommand.Trigger(_dataBroker.Push(new StaticProductListViewModel.Parameter
			{
				Title = "Замена товара",
				Items = item2
			}));
		}
		void ShowError()
		{
			_infoMessageService.ShowSnackbar("Не удалось подобрать товары");
		}
	}

	private void OnSelectedCategoryChanged(CategoryItemViewModel? previousCategory, CategoryItemViewModel? currentCategory)
	{
		if (previousCategory != null)
		{
			previousCategory.Selected = false;
		}
		if (currentCategory != null)
		{
			currentCategory.Selected = true;
		}
		UpdateSelectedIndex();
		CreateProductsBy(currentCategory);
	}

	private void OnCategoriesItemViewModelsChanged()
	{
		CategoryItemViewModel selectedCategory = SelectedCategory;
		IReadOnlyList<CategoryItemViewModel> categoriesItemViewModels = CategoriesItemViewModels;
		if (selectedCategory != null)
		{
			foreach (CategoryItemViewModel item in categoriesItemViewModels)
			{
				item.Selected = item.Title == selectedCategory.Title;
				if (item.Selected)
				{
					SelectedCategory = item;
				}
			}
			return;
		}
		SelectedCategory = categoriesItemViewModels.FirstOrDefault() ?? CategoryItemViewModel.NewAllCategories();
	}

	private void UpdateSelectedIndex()
	{
		CategoryItemViewModel sc = SelectedCategory;
		if (sc == null)
		{
			SelectedCategoryIndex = 0;
			return;
		}
		IReadOnlyList<CategoryItemViewModel> categoriesItemViewModels = CategoriesItemViewModels;
		CategoryItemViewModel categoryItemViewModel = categoriesItemViewModels.Where((CategoryItemViewModel i) => i.Title == sc.Title).FirstOrDefault();
		if (categoryItemViewModel == null)
		{
			SelectedCategoryIndex = 0;
			return;
		}
		int num = categoriesItemViewModels.IndexOf(categoryItemViewModel);
		if (num >= 0)
		{
			SelectedCategoryIndex = num;
		}
		else
		{
			SelectedCategoryIndex = 0;
		}
	}
}
