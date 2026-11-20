using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Auchan.Common.Profile.WaitList.Api;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.WaitList;

public class WaitListProducts
{
	private readonly Lazy<WaitListService> _waitListService;

	private readonly IUserContext _userContext;

	private readonly Lazy<ILoginManager> _loginManager;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<IEcomTracker> _ecomTracker;

	private readonly TaskQueue _waitListTaskQueue = new TaskQueue();

	private readonly List<WaitListDtos.WaitListCategory> _categories = new List<WaitListDtos.WaitListCategory>();

	private readonly List<WaitListDtos.WaitListCategoryPreview> _categoriesPreview = new List<WaitListDtos.WaitListCategoryPreview>();

	private readonly List<Product> _productsInWaitList = new List<Product>();

	private int _productsCountInWaitList;

	private bool _filterButtonActive;

	public int ProductsCountInWaitList
	{
		get
		{
			return _productsCountInWaitList;
		}
		private set
		{
			_productsCountInWaitList = value;
			this.OnProductsCountInWaitListChanged?.Invoke(this, value);
		}
	}

	public bool FilterButtonActive
	{
		get
		{
			return _filterButtonActive;
		}
		private set
		{
			_filterButtonActive = value;
			this.OnFilterButtonActiveChanged?.Invoke(this, value);
		}
	}

	public bool OnlyActive { get; private set; }

	public bool IsError { get; private set; }

	public event EventHandler<int>? OnProductsCountInWaitListChanged;

	public event EventHandler<bool>? OnFilterButtonActiveChanged;

	public event Action<Product?>? UpdateProductState;

	public event Action? OnProductRemoved;

	public WaitListProducts(Lazy<WaitListService> waitListService, IUserContext userContext, Lazy<ILoginManager> loginManager, Lazy<IInfoMessageService> infoMessageService, Lazy<IEcomContext> ecomContext, Lazy<IEcomTracker> ecomTracker)
	{
		_waitListService = waitListService;
		_userContext = userContext;
		_loginManager = loginManager;
		_infoMessageService = infoMessageService;
		_ecomContext = ecomContext;
		_ecomTracker = ecomTracker;
		_userContext.AfterLoggedIn += () => _waitListTaskQueue.Enqueue(() => UpdateBadge());
		_userContext.AfterLoggedOut += () => _waitListTaskQueue.Enqueue(delegate
		{
			_productsInWaitList.Clear();
			ProductsCountInWaitList = 0;
			_categoriesPreview.Clear();
			_categories.Clear();
			return Task.CompletedTask;
		});
	}

	public bool IsProductInWaitList(Product product)
	{
		return _productsInWaitList.Any((Product x) => x.GimaId == product.GimaId);
	}

	public async Task LoadProductsInWaitList(string? selectedCategory = null, bool onlyActive = false)
	{
		OnlyActive = onlyActive;
		IsError = false;
		_categoriesPreview.Clear();
		_categories.Clear();
		_productsInWaitList.Clear();
		if (!_userContext.Authorized)
		{
			return;
		}
		Result<WaitListDtos.WaitListProductsDto, DomainError> result = await _waitListService.Value.WaitListProducts(_ecomContext.Value.ActiveStore.Id, onlyActive, selectedCategory);
		if (result.IsSuccess)
		{
			WaitListDtos.WaitListData data = result.Value.Data;
			if (data.QtyActiveProductsInWaitList != ProductsCountInWaitList)
			{
				ProductsCountInWaitList = data.QtyActiveProductsInWaitList;
			}
			if (!data.Categories.Any() && data.QtyAllProductsInWaitList == 0)
			{
				return;
			}
			if (data.QtyActiveProductsInWaitList > 0)
			{
				FilterButtonActive = true;
			}
			else
			{
				FilterButtonActive = false;
			}
			_categoriesPreview.AddRange(data.CategoriesPreview);
			_categories.AddRange(data.Categories);
			_productsInWaitList.AddRange(data.Categories.SelectMany((WaitListDtos.WaitListCategory x) => x.Products.Select((ProductDto p) => p.Map())));
			this.UpdateProductState?.Invoke(null);
		}
		else
		{
			if (ProductsCountInWaitList != 0)
			{
				ProductsCountInWaitList = 0;
			}
			FilterButtonActive = false;
			IsError = true;
		}
	}

	public async Task UpdateBadge()
	{
		_productsInWaitList.Clear();
		if (!_userContext.Authorized)
		{
			return;
		}
		Task<Store> activeStoreAsync = _ecomContext.Value.GetActiveStoreAsync();
		Result<WaitListDtos.WaitListProductsDto, DomainError> result = await _waitListService.Value.WaitListProducts(activeStoreAsync.Id, onlyActive: false, null);
		if (!result.IsSuccess)
		{
			return;
		}
		ProductsCountInWaitList = result.Value.Data.QtyActiveProductsInWaitList;
		_productsInWaitList.AddRange(result.Value.Data.Categories.SelectMany((WaitListDtos.WaitListCategory x) => x.Products.Select((ProductDto p) => p.Map())));
	}

	public void Add(Product product, UICommand showPopupCommand)
	{
		_waitListTaskQueue.Enqueue(async delegate
		{
			if (!_userContext.Authorized)
			{
				_loginManager.Value.LoginAsync(displayOnboardings: false).SafeFireAndForget((Action<Exception>)null, false);
			}
			else
			{
				Result<WaitListDtos.AddDto, DomainError> result = await _waitListService.Value.Add(int.Parse(product.GimaId), _ecomContext.Value.ActiveStore.Id);
				if (result.IsFailure)
				{
					ShowErrorAddingToWaitList();
				}
				else
				{
					_ecomTracker.Value.AddToWaitList(product);
					if (result.Value.Data.QtyActiveProductsInWaitList != ProductsCountInWaitList)
					{
						ProductsCountInWaitList = result.Value.Data.QtyActiveProductsInWaitList;
					}
					_productsInWaitList.Add(product);
					this.UpdateProductState?.Invoke(product);
					showPopupCommand.Trigger();
				}
			}
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void Remove(Product product)
	{
		_waitListTaskQueue.Enqueue(async delegate
		{
			Result<WaitListDtos.DeleteDto, DomainError> result = await _waitListService.Value.Delete(int.Parse(product.GimaId));
			if (result.IsFailure)
			{
				ShowErrorDeletingFromWaitList();
			}
			else
			{
				if (result.Value.Data.QtyActiveProductsInWaitList != ProductsCountInWaitList)
				{
					ProductsCountInWaitList = result.Value.Data.QtyActiveProductsInWaitList;
				}
				_productsInWaitList.Remove(_productsInWaitList.FirstOrDefault((Product x) => x.GimaId == product.GimaId));
				this.UpdateProductState?.Invoke(product);
				this.OnProductRemoved?.Invoke();
			}
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public async Task<(Product?, bool, int)> GetNotificationData()
	{
		(Product?, bool, int) defaultData = (null, false, 0);
		Result<WaitListDtos.NotificationResponseDto, DomainError> result = await _waitListService.Value.GetNotification(_ecomContext.Value.ActiveStore.Id);
		if (result.IsFailure)
		{
			return defaultData;
		}
		if (!result.Value.DataForNotification.NotificationRequired)
		{
			return defaultData;
		}
		ProductsCountInWaitList = result.Value.DataForNotification.QtyActiveProductsInWaitList;
		return (result.Value.DataForNotification.Data.Product?.Map(), result.Value.DataForNotification.NotificationRequired, result.Value.DataForNotification.QtyProductsForNotification);
	}

	public List<WaitListDtos.WaitListCategory> GetCategoriesWithProducts()
	{
		return _categories;
	}

	public List<CategoryItemWithCodeViewModel> GetWaitListCategoriesItems()
	{
		return _categoriesPreview.Select((WaitListDtos.WaitListCategoryPreview x) => new CategoryItemWithCodeViewModel(x)).ToList();
	}

	private void ShowErrorAddingToWaitList()
	{
		_infoMessageService.Value.ShowSnackbar("Не удалось подписаться на товар");
	}

	private void ShowErrorDeletingFromWaitList()
	{
		_infoMessageService.Value.ShowSnackbar("Не удалось отписаться от товара");
	}

	public IEnumerable<Product> GetProductsByCategory(string categoryCode)
	{
		return _productsInWaitList.Where((Product x) => x.CategoryCodes.Any((CategoryCodeDto categoryCodeDto) => categoryCodeDto.Code == categoryCode));
	}
}
