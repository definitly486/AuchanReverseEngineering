using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile;

public class Favorites
{
	private readonly FavoritesService _favoritesService;

	private readonly IUserContext _userContext;

	private readonly ILoginManager _loginManager;

	private readonly IInfoMessageService _infoMessageService;

	private readonly Lazy<IEcomTracker> _ecomTracker;

	private readonly TaskQueue _favoritesTaskQueue = new TaskQueue();

	private IReadOnlyList<Product> _productsInFavorites = ImmutableList<Product>.Empty;

	private readonly List<FavoritesDtos.SortDto> _lastRequestedSorts = new List<FavoritesDtos.SortDto>();

	public Action<Product, bool>? UpdateProductCommand { get; set; }

	public event Action? UpdateAllHeartsStates;

	public Favorites(FavoritesService favoritesService, IUserContext userContext, ILoginManager loginManager, IInfoMessageService infoMessageService, Lazy<IEcomTracker> ecomTracker)
	{
		_favoritesService = favoritesService;
		_userContext = userContext;
		_loginManager = loginManager;
		_infoMessageService = infoMessageService;
		_ecomTracker = ecomTracker;
		_favoritesTaskQueue.Enqueue(() => LoadFavorites()).SafeFireAndForget((Action<Exception>)null, false);
		_userContext.AfterLoggedIn += () => _favoritesTaskQueue.Enqueue(() => LoadFavorites());
		_userContext.AfterLoggedOut += () => _favoritesTaskQueue.Enqueue(delegate
		{
			_productsInFavorites = ImmutableList<Product>.Empty;
			return Task.CompletedTask;
		});
	}

	private async Task LoadFavorites(string selectedSortName = "")
	{
		if (!_userContext.Authorized)
		{
			return;
		}
		_productsInFavorites = ImmutableList<Product>.Empty;
		List<FavoritesDtos.SortDto> list = await GetSortsDto();
		if (list.Count <= 0)
		{
			return;
		}
		string orderFields;
		string orderDirection;
		if (string.IsNullOrWhiteSpace(selectedSortName))
		{
			FavoritesDtos.SortDto sortDto = list.FirstOrDefault();
			if (sortDto == null)
			{
				this.UpdateAllHeartsStates?.Invoke();
				return;
			}
			orderFields = sortDto.Field ?? string.Empty;
			orderDirection = sortDto.Direction ?? string.Empty;
		}
		else
		{
			FavoritesDtos.SortDto? sortDto2 = list.FirstOrDefault((FavoritesDtos.SortDto x) => x.Name == selectedSortName);
			orderFields = sortDto2?.Field ?? string.Empty;
			orderDirection = sortDto2?.Direction ?? string.Empty;
		}
		Result<List<Product>, DomainError> result = await _favoritesService.Favorites(orderFields, orderDirection);
		if (result.IsSuccess)
		{
			_productsInFavorites = result.Value;
			this.UpdateAllHeartsStates?.Invoke();
		}
	}

	private async Task<List<FavoritesDtos.SortDto>> GetSortsDto()
	{
		Result<FavoritesDtos.FavoriteFieldsDto, DomainError> result = await _favoritesService.FavoriteFields();
		if (result.IsSuccess)
		{
			List<FavoritesDtos.SortDto> list = result.Value.Sorts ?? new List<FavoritesDtos.SortDto>();
			_lastRequestedSorts.Clear();
			_lastRequestedSorts.AddRange(list);
			return list;
		}
		return new List<FavoritesDtos.SortDto>();
	}

	public async Task<List<string>> GetSortNames()
	{
		return (await GetSortsDto()).Select((FavoritesDtos.SortDto x) => x.Name ?? string.Empty).ToList();
	}

	public async Task<IReadOnlyList<Product>> GetFavoritesFromApi(string selectedSortName = "")
	{
		await _favoritesTaskQueue.Enqueue(() => LoadFavorites(selectedSortName));
		return _productsInFavorites;
	}

	public bool IsProductInFavorites(Product product)
	{
		return _productsInFavorites.Any((Product x) => x.GimaId == product.GimaId);
	}

	public void Add(Product product)
	{
		_favoritesTaskQueue.Enqueue(async delegate
		{
			if (!_userContext.Authorized)
			{
				_loginManager.LoginAsync(displayOnboardings: false).SafeFireAndForget((Action<Exception>)null, false);
			}
			else if (!_productsInFavorites.Any((Product x) => x.GimaId == product.GimaId))
			{
				IReadOnlyList<Product> productsInFavorites = _productsInFavorites;
				int num = 0;
				Product[] array = new Product[1 + productsInFavorites.Count];
				foreach (Product item in productsInFavorites)
				{
					array[num] = item;
					num++;
				}
				array[num] = product;
				_productsInFavorites = new global::_003C_003Ez__ReadOnlyArray<Product>(array);
				UpdateProductCommand?.Invoke(product, arg2: true);
				this.UpdateAllHeartsStates?.Invoke();
				Result<FavoritesDtos.AddDto, DomainError> result = await _favoritesService.Add(product.GimaId ?? string.Empty);
				if (result.IsSuccess)
				{
					_ecomTracker.Value.AddToFavorites(product);
				}
				if (result.IsFailure)
				{
					Favorites favorites = this;
					List<Product> list = new List<Product>();
					list.AddRange(_productsInFavorites.Where((Product x) => x.GimaId != product.GimaId));
					favorites._productsInFavorites = new _003C_003Ez__ReadOnlyList<Product>(list);
					UpdateProductCommand?.Invoke(product, arg2: false);
					this.UpdateAllHeartsStates?.Invoke();
					ShowErrorAddingToFavorites();
				}
			}
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void Remove(Product product)
	{
		_favoritesTaskQueue.Enqueue(async delegate
		{
			Favorites favorites = this;
			List<Product> list = new List<Product>();
			list.AddRange(_productsInFavorites.Where((Product x) => x.GimaId != product.GimaId));
			favorites._productsInFavorites = new _003C_003Ez__ReadOnlyList<Product>(list);
			UpdateProductCommand?.Invoke(product, arg2: false);
			this.UpdateAllHeartsStates?.Invoke();
			if ((await _favoritesService.Delete(product.GimaId ?? string.Empty)).IsFailure)
			{
				IReadOnlyList<Product> productsInFavorites = _productsInFavorites;
				int num = 0;
				Product[] array = new Product[1 + productsInFavorites.Count];
				foreach (Product item in productsInFavorites)
				{
					array[num] = item;
					num++;
				}
				array[num] = product;
				_productsInFavorites = new global::_003C_003Ez__ReadOnlyArray<Product>(array);
				UpdateProductCommand?.Invoke(product, arg2: true);
				this.UpdateAllHeartsStates?.Invoke();
				ShowErrorDeletingFromFavorites();
			}
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	private void ShowErrorAddingToFavorites()
	{
		_infoMessageService.ShowSnackbar("Ошибка добавления товара в избранное");
	}

	private void ShowErrorDeletingFromFavorites()
	{
		_infoMessageService.ShowSnackbar("Ошибка удаления товара из избранного");
	}
}
