using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.WaitList.Api;
using Auchan.Common.Reviews;
using EBind;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Profile.WaitList;

public class WaitListViewModel : ScreenViewModel, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public enum VisualState
	{
		Default,
		InProgress,
		Error,
		Empty
	}

	private const string ALL_CATEGORIES = "Все";

	private readonly IDataBroker _dataBroker;

	private readonly WaitListProducts _waitListProducts;

	private readonly Func<Product, ICollection<IDisposable>, ProductItemViewModel.ProductItemType, ProductItemViewModel> _viewModelFactory;

	private CategoryItemWithCodeViewModel? _selectedCategory;

	private bool _firstStart = true;

	private bool _onPause;

	private readonly TaskQueue _updateDataQueue = new TaskQueue();

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	public readonly UICommand GoToCatalogCommand = new UICommand();

	public readonly UICommand<ProductDetailsViewModel.Parameter, ProductItemViewModel> NavigateToProductDetailsCommand = new UICommand<ProductDetailsViewModel.Parameter, ProductItemViewModel>((ProductItemViewModel item) => new ProductDetailsViewModel.Parameter(item.Product.Code));

	public readonly UICommand GoBackCommand = new UICommand();

	public readonly UICommand RefreshProductsCommand = new UICommand();

	private IEcomContext _ecomContext;

	[CompilerGenerated]
	private bool _003CFilterIsActive_003Ek__BackingField;

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

	public ObservableRangeCollection<CategoryItemWithCodeViewModel> CategoriesItemViewModels { get; } = new ObservableRangeCollection<CategoryItemWithCodeViewModel>();

	public ObservableRangeCollection<GroupedProductsItemViewModel> GroupedProductsItemViewModels { get; } = new ObservableRangeCollection<GroupedProductsItemViewModel>();

	public ObservableRangeCollection<CategoryTitleItemViewModel> CategoryTitleItemViewModel { get; } = new ObservableRangeCollection<CategoryTitleItemViewModel>();

	public List<ProductItemViewModel> ProductItemViewModels { get; } = new List<ProductItemViewModel>();

	public UICommand<ProductItemViewModel> ShowQtyDialogCommand { get; } = new UICommand<ProductItemViewModel>();

	public UICommand<ProductReviewsViewModel.Parameter> OpenReviewsCommand { get; } = new UICommand<ProductReviewsViewModel.Parameter>();

	public UICommand<BrokerToken> OpenFilterCommand { get; } = new UICommand<BrokerToken>();

	public string Title => "Лист ожидания";

	public string ProgressTitle => "Проверяем наличие товаров…";

	public string EmptyTitle => "В листе ожидания пока нет\nотложенных товаров";

	public string EmptyMessage => "Подписывайтесь на уведомления, и мы\nсообщим, когда товар появится в наличии по\nвашему адресу.";

	public string GoToCatalogButtonText => "Перейти в каталог";

	public bool FilterIsActive
	{
		[CompilerGenerated]
		get
		{
			return _003CFilterIsActive_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CFilterIsActive_003Ek__BackingField != value)
			{
				_003CFilterIsActive_003Ek__BackingField = value;
				RaisePropertyChanged("FilterIsActive");
			}
		}
	}

	public string ErrorTitle => "Упс! Что-то пошло не так :(";

	public string ErrorMessage => "К сожалению, у нас что-то сломалось и\u00a0сейчас\nданный раздел недоступен. Пока мы\nисправляем ошибки, вы можете сходить\nза\u00a0покупками";

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "WaitList";

	string IYandexMetricaScreenViewModel.ScreenName => "WaitList";

	public WaitListViewModel(IDataBroker dataBroker, WaitListProducts waitListProducts, Func<Product, ICollection<IDisposable>, ProductItemViewModel.ProductItemType, ProductItemViewModel> viewModelFactory, IEcomContext ecomContext)
	{
		_dataBroker = dataBroker;
		_waitListProducts = waitListProducts;
		_viewModelFactory = viewModelFactory;
		_ecomContext = ecomContext;
		_waitListProducts.OnFilterButtonActiveChanged += new DisposableDelegate<EventHandler<bool>>(delegate(object? o, bool e)
		{
			FilterIsActive = e;
		}, delegate(EventHandler<bool> eh)
		{
			_waitListProducts.OnFilterButtonActiveChanged -= eh;
		}).AddTo(base.CloseDisposable);
		_waitListProducts.OnProductRemoved += new DisposableDelegate<Action>(delegate
		{
			MainThread.BeginInvokeOnMainThread(delegate
			{
				UpdateWaitListData(_waitListProducts.OnlyActive, _selectedCategory?.Code).SafeFireAndForget((Action<Exception>)null, false);
			});
		}, delegate(Action eh)
		{
			_waitListProducts.OnProductRemoved -= eh;
		}).AddTo(base.CloseDisposable);
	}

	protected override async Task OnResumed()
	{
		_onPause = false;
		_ecomContext.SyncReceiveMethodQueued().SafeFireAndForget((Action<Exception>)null, false);
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ReceivingMethod).PerformDebouncingTask((Func<Task>)async delegate
		{
			await UpdateWaitListData(_waitListProducts.OnlyActive, _selectedCategory?.Code);
			await RefreshProductsCommand.TriggerAsync();
		}, (IScheduler?)null).Subscribe()
			.AddTo(base.PauseDisposable);
		await base.OnResumed();
		if (_firstStart)
		{
			await UpdateWaitListData();
			_firstStart = false;
		}
		else
		{
			await UpdateWaitListData(_waitListProducts.OnlyActive, _selectedCategory?.Code);
			await RefreshProductsCommand.TriggerAsync();
		}
	}

	protected override Task OnPaused()
	{
		FilterIsActive = false;
		_onPause = true;
		return base.OnPaused();
	}

	public void OnCategorySelected(CategoryItemWithCodeViewModel selectedCategoryItemWithCodeViewModel, bool onlySelect = false)
	{
		State = VisualState.InProgress;
		foreach (CategoryItemWithCodeViewModel categoriesItemViewModel in CategoriesItemViewModels)
		{
			categoriesItemViewModel.Selected = false;
		}
		_selectedCategory = CategoriesItemViewModels.FirstOrDefault((CategoryItemWithCodeViewModel categoryItemViewModel) => categoryItemViewModel.Title == selectedCategoryItemWithCodeViewModel.Title);
		if (_selectedCategory != null)
		{
			_selectedCategory.Selected = true;
			UpdateCategories(selectedCategoryItemWithCodeViewModel.Code).SafeFireAndForget((Action<Exception>)null, false);
		}
		async Task UpdateCategories(string? selectedCategoryName)
		{
			List<WaitListDtos.WaitListCategory> list = new List<WaitListDtos.WaitListCategory>();
			if (!onlySelect)
			{
				bool onlyActive = _waitListProducts.OnlyActive;
				await _waitListProducts.LoadProductsInWaitList(selectedCategoryName, onlyActive);
				list = _waitListProducts.GetCategoriesWithProducts();
				if (selectedCategoryName != null && !list.Any())
				{
					await _waitListProducts.LoadProductsInWaitList(null, onlyActive);
					list = _waitListProducts.GetCategoriesWithProducts();
					if (onlyActive && !list.Any())
					{
						await _waitListProducts.LoadProductsInWaitList();
						list = _waitListProducts.GetCategoriesWithProducts();
					}
					OnCategorySelected(CategoriesItemViewModels.First(), onlySelect: true);
				}
				else if (selectedCategoryName == null && onlyActive && !list.Any())
				{
					await _waitListProducts.LoadProductsInWaitList();
					list = _waitListProducts.GetCategoriesWithProducts();
				}
				State = (_waitListProducts.IsError ? VisualState.Error : ((GroupedProductsItemViewModels.Count == 0) ? VisualState.Empty : VisualState.Default));
			}
			if (selectedCategoryItemWithCodeViewModel.Title == "Все")
			{
				CreateGroupedByCategoryProducts(list);
			}
			else
			{
				CreateGroupedBySelectedCategoryProducts(selectedCategoryItemWithCodeViewModel);
			}
		}
	}

	public void OnBackClicked()
	{
		GoBackCommand.Trigger();
	}

	public void OpenFilter()
	{
		_updateDataQueue.Enqueue(async delegate
		{
			WaitListFilterViewModel.Parameter parameter = new WaitListFilterViewModel.Parameter();
			OpenFilterCommand.Trigger(_dataBroker.Push(parameter));
			bool flag = await parameter.TaskCompletionSource.Task;
			if (flag != _waitListProducts.OnlyActive)
			{
				await UpdateWaitListData(flag, CategoriesItemViewModels.FirstOrDefault((CategoryItemWithCodeViewModel x) => x.Selected)?.Code);
			}
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void NavigateToProductDetails(ProductItemViewModel productItemViewModel)
	{
		NavigateToProductDetailsCommand.Trigger(productItemViewModel);
	}

	public void OnGoToCatalogClick()
	{
		GoToCatalogCommand.Trigger();
	}

	private async Task UpdateWaitListData(bool onlyActive = false, string? selectedCategoryName = null)
	{
		if (_onPause)
		{
			return;
		}
		State = VisualState.InProgress;
		await _waitListProducts.LoadProductsInWaitList(selectedCategoryName, onlyActive);
		List<WaitListDtos.WaitListCategory> categoriesWithProducts = _waitListProducts.GetCategoriesWithProducts();
		if (selectedCategoryName != null && !categoriesWithProducts.Any())
		{
			await _waitListProducts.LoadProductsInWaitList(null, onlyActive);
			categoriesWithProducts = _waitListProducts.GetCategoriesWithProducts();
			if (onlyActive && !categoriesWithProducts.Any())
			{
				await _waitListProducts.LoadProductsInWaitList();
				categoriesWithProducts = _waitListProducts.GetCategoriesWithProducts();
			}
			OnCategorySelected(CategoriesItemViewModels.First(), onlySelect: true);
		}
		else if (selectedCategoryName == null && onlyActive && !categoriesWithProducts.Any())
		{
			await _waitListProducts.LoadProductsInWaitList();
			categoriesWithProducts = _waitListProducts.GetCategoriesWithProducts();
		}
		CreateCategoriesForSelector();
		CreateGroupedByCategoryProducts(categoriesWithProducts);
		State = (_waitListProducts.IsError ? VisualState.Error : ((CategoriesItemViewModels.Count == 0) ? VisualState.Empty : VisualState.Default));
	}

	private void CreateCategoriesForSelector()
	{
		List<CategoryItemWithCodeViewModel> categories = _waitListProducts.GetWaitListCategoriesItems();
		if (categories.Count > 0 && DifferentCategories(CategoriesItemViewModels, categories))
		{
			CategoryItemWithCodeViewModel categoryItemWithCodeViewModel = new CategoryItemWithCodeViewModel(new WaitListDtos.WaitListCategoryPreview
			{
				Name = "Все"
			});
			CategoriesItemViewModels.Clear();
			CategoriesItemViewModels.Add(categoryItemWithCodeViewModel);
			CategoriesItemViewModels.AddRange(categories);
			if (_selectedCategory == null)
			{
				categoryItemWithCodeViewModel.Selected = true;
			}
			else
			{
				OnCategorySelected(_selectedCategory, onlySelect: true);
			}
		}
		else if (categories.Count == 0)
		{
			CategoriesItemViewModels.Clear();
		}
		bool DifferentCategories(ObservableCollection<CategoryItemWithCodeViewModel> oldCategories, List<CategoryItemWithCodeViewModel> newCategories)
		{
			int num = CategoriesItemViewModels.Count - 1;
			if (CategoriesItemViewModels.Any() && num != categories.Count)
			{
				return true;
			}
			foreach (CategoryItemWithCodeViewModel category in newCategories)
			{
				CategoryItemWithCodeViewModel categoryItemWithCodeViewModel2 = oldCategories.FirstOrDefault((CategoryItemWithCodeViewModel x) => x.Title == category.Title);
				if (categoryItemWithCodeViewModel2 == null || categoryItemWithCodeViewModel2.Counter != category.Counter)
				{
					return true;
				}
			}
			return false;
		}
	}

	private void CreateGroupedByCategoryProducts(List<WaitListDtos.WaitListCategory> categories)
	{
		GroupedProductsItemViewModels.Clear();
		foreach (WaitListDtos.WaitListCategory category in categories)
		{
			ObservableRangeCollection<ProductItemViewModel> products = new ObservableRangeCollection<ProductItemViewModel>(category.Products.Select((ProductDto x) => _viewModelFactory(x.Map(), base.CloseDisposable, ProductItemViewModel.ProductItemType.WaitList)));
			ObservableRangeCollection<GroupedProductsItemViewModel> collection = new ObservableRangeCollection<GroupedProductsItemViewModel>
			{
				new GroupedProductsItemViewModel(category.Name + $" ({category.ProductsCounter})", products)
			};
			GroupedProductsItemViewModels.AddRange(collection);
		}
		UpdateProducts();
		UpdateTitles();
	}

	private void CreateGroupedBySelectedCategoryProducts(CategoryItemWithCodeViewModel selectedCategoryName)
	{
		GroupedProductsItemViewModels.Clear();
		ObservableRangeCollection<ProductItemViewModel> products = new ObservableRangeCollection<ProductItemViewModel>(from x in _waitListProducts.GetProductsByCategory(selectedCategoryName.Code)
			select _viewModelFactory(x, base.CloseDisposable, ProductItemViewModel.ProductItemType.WaitList));
		ObservableRangeCollection<GroupedProductsItemViewModel> collection = new ObservableRangeCollection<GroupedProductsItemViewModel>
		{
			new GroupedProductsItemViewModel(selectedCategoryName.Title + $" ({selectedCategoryName.Counter})", products)
		};
		GroupedProductsItemViewModels.AddRange(collection);
		UpdateProducts();
		UpdateTitles();
	}

	private void UpdateTitles()
	{
		List<CategoryTitleItemViewModel> list = new List<CategoryTitleItemViewModel>();
		int num = 0;
		foreach (GroupedProductsItemViewModel groupedProductsItemViewModel in GroupedProductsItemViewModels)
		{
			list.Add(new CategoryTitleItemViewModel(groupedProductsItemViewModel.Title, num));
			num += groupedProductsItemViewModel.Products.Count;
		}
		CategoryTitleItemViewModel.Clear();
		CategoryTitleItemViewModel.AddRange(list);
	}

	private void UpdateProducts()
	{
		List<ProductItemViewModel> list = new List<ProductItemViewModel>();
		int num = 0;
		foreach (GroupedProductsItemViewModel groupedProductsItemViewModel in GroupedProductsItemViewModels)
		{
			num += groupedProductsItemViewModel.Products.Count;
			list.AddRange(groupedProductsItemViewModel.Products);
		}
		ProductItemViewModels.Clear();
		ProductItemViewModels.AddRange(list);
	}
}
