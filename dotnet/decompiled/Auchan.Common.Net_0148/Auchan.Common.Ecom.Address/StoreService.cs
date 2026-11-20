using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Addresses;
using Auchan.Common.Analytics;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom.Address.DTO;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.Logs;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Ecom.Address;

public class StoreService : IStoreService
{
	private readonly Lazy<IStoreApi> _storeApi;

	private readonly Lazy<ILogService> _logService;

	private readonly Lazy<IRequestExecutor> _requestExecutor;

	private readonly Lazy<ILocationProvider> _locationProvider;

	private readonly Lazy<IEcomContext> _ecomContext;

	private Task<Result<Cities, DomainError>>? _citiesPrefetch;

	public StoreService(IHomeScreenTracker homeScreenTracker, Lazy<IStoreApi> storeApi, Lazy<IRequestExecutor> requestExecutor, Lazy<ILogService> logService, Lazy<ILocationProvider> locationProvider, Lazy<IEcomContext> ecomContext)
	{
		_storeApi = storeApi;
		_logService = logService;
		_requestExecutor = requestExecutor;
		_locationProvider = locationProvider;
		_ecomContext = ecomContext;
		homeScreenTracker.OnShown += delegate
		{
			_citiesPrefetch = null;
		};
	}

	public Task<Result<Cities, DomainError>> PrefetchCities()
	{
		_citiesPrefetch = null;
		return _citiesPrefetch = Cities();
	}

	public Task<Result<Cities, DomainError>> Cities(bool getCoordinates = false)
	{
		Task<Result<Cities, DomainError>>? citiesPrefetch = _citiesPrefetch;
		if (citiesPrefetch != null && citiesPrefetch.IsCompleted && _citiesPrefetch.Result.IsFailure)
		{
			_citiesPrefetch = null;
		}
		return _citiesPrefetch ?? Task.Run(() => DoAsync(getCoordinates));
		async Task<Result<Cities, DomainError>> DoAsync(bool flag)
		{
			return (await _requestExecutor.Value.Execute(async delegate(CancellationToken t)
			{
				IStoreApi value = _storeApi.Value;
				if (1 == 0)
				{
				}
				return (await value.Regions("android", flag ? 1 : 0, t)).GetVpnState();
			})).Ensure((RegionsResponse dto) => dto.Regions.Any(), new ApiContractError()).Map((RegionsResponse response) => new Cities
			{
				List = response.Regions.Select((RegionBundleDto dto) => new City
				{
					EcomId = dto.Id,
					FiasId = dto.FiasId.ToString(),
					Name = dto.Name,
					IsDefault = dto.Default,
					ChildFiasIds = (dto.childRegions?.Select((RegionDto x) => x.FiasId.ToString()).ToImmutableList() ?? ImmutableList.Create(default(ReadOnlySpan<string>))),
					IsInLoyalty = dto.InLoyalty,
					Coordinate = ((dto.RegionCoordinate != null) ? Coordinate.Parse(dto.RegionCoordinate.Latitude, dto.RegionCoordinate.Longitude) : null)
				}).ToImmutableList(),
				VpnState = response.VpnState
			}, (ServiceError error) => error.ToBaseDomainError());
		}
	}

	public async Task<Result<Cities, DomainError>> AllExistingRegions()
	{
		return (await _requestExecutor.Value.Execute(async delegate(CancellationToken t)
		{
			IStoreApi value = _storeApi.Value;
			if (1 == 0)
			{
			}
			return (await value.AllExistingRegions("android", "1", t)).GetVpnState();
		})).Ensure((RegionsResponse dto) => dto.Regions.Any(), new ApiContractError()).Map((RegionsResponse response) => new Cities
		{
			List = response.Regions.Select((RegionBundleDto dto) => new City
			{
				EcomId = dto.Id,
				FiasId = dto.FiasId.ToString(),
				Name = dto.Name,
				IsDefault = dto.Default,
				ChildFiasIds = (dto.childRegions?.Select((RegionDto x) => x.FiasId.ToString()).ToImmutableList() ?? ImmutableList.Create(default(ReadOnlySpan<string>))),
				IsInLoyalty = dto.InLoyalty,
				Coordinate = ((dto.RegionCoordinate != null) ? Coordinate.Parse(dto.RegionCoordinate.Latitude, dto.RegionCoordinate.Longitude) : null)
			}).ToImmutableList(),
			VpnState = response.VpnState
		}, (ServiceError error) => error.ToBaseDomainError());
	}

	public async Task<Result<IEnumerable<IGrouping<City, Store>>, DomainError>> AllCityShops(Location? coordinates = null, bool showVisible = false)
	{
		Task<Result<Cities, DomainError>> citiesTask = Cities(getCoordinates: true);
		Task<Result<ShopsResponse, ServiceError>> shopsTask = _requestExecutor.Value.Execute((CancellationToken t) => _storeApi.Value.Shops(coordinates?.Latitude, coordinates?.Longitude, showVisible ? new long?(1L) : ((long?)null), t));
		await Task.WhenAll(citiesTask, shopsTask);
		Result<Cities, DomainError> citiesResult = citiesTask.Result;
		if (citiesResult.IsFailure)
		{
			return Result.Failure<IEnumerable<IGrouping<City, Store>>, DomainError>(citiesResult.Error);
		}
		Result<IEnumerable<Store>, DomainError> result = shopsTask.Result.Ensure<ShopsResponse, ServiceError>((ShopsResponse dto) => dto.Shops.Count > 0, new ApiContractError()).Map((ShopsResponse response) => response.Shops.SelectNotNull(delegate(ShopDto dto)
		{
			City city = citiesResult.Value.FirstOrDefault((City c) => c.EcomId == dto.RegionId);
			return (city == null) ? null : dto.ToStoreModel(city, _logService);
		}), (ServiceError error) => error.ToBaseDomainError());
		if (result.TryGetValue(out var value))
		{
			_ecomContext.Value.UpdateActiveStoreProperties(value);
		}
		return result.Map((IEnumerable<Store> s) => (from store in s
			group store by store.City).ToImmutableList()).Map(RestoreCitiesOrder);
		IEnumerable<IGrouping<City, Store>> RestoreCitiesOrder(IReadOnlyList<IGrouping<City, Store>> citiesWithStores)
		{
			return citiesResult.Value.Select((City city) => citiesWithStores.FirstOrDefault((IGrouping<City, Store> x) => x.Key.EcomId == city.EcomId)).WhereNotNull();
		}
	}

	private int GetDeliveryMethod(Store store, ReceivingMethod receivingMethod)
	{
		return receivingMethod switch
		{
			ReceivingMethod.CarPickup => store.HasCarPickup ? 3 : GetDefaultDeliveryMethod(store), 
			ReceivingMethod.Pickup => store.HasStorePickUp ? 2 : GetDefaultDeliveryMethod(store), 
			ReceivingMethod.Delivery => store.HasDelivery ? 1 : GetDefaultDeliveryMethod(store), 
			ReceivingMethod.ExpressDelivery => store.HasExpressDelivery ? 4 : GetDefaultDeliveryMethod(store), 
			_ => GetDefaultDeliveryMethod(store), 
		};
	}

	private int GetDefaultDeliveryMethod(Store store)
	{
		if (store.HasDelivery)
		{
			return 1;
		}
		if (store.HasStorePickUp)
		{
			return 2;
		}
		if (store.HasCarPickup)
		{
			return 3;
		}
		if (store.HasExpressDelivery)
		{
			return 4;
		}
		return 0;
	}

	public async Task<Result<SetShopResponse, DomainError>> SetCurrentUserStore(Store store, ReceivingMethod receivingMethod, bool? simulate)
	{
		if (store == null)
		{
			return Result.Failure<SetShopResponse, DomainError>(new UnknownError
			{
				Message = "Store is null"
			});
		}
		bool goingToChangeMerchant = _ecomContext.Value.ActiveStore.Id != store.Id;
		Result<SetShopResponse, DomainError> result = (await _requestExecutor.Value.ExecuteWithToken((CancellationToken cancellationToken, TokenModel tokenModel) => _storeApi.Value.SetCurrentShop(tokenModel.Token, new SetShopRequest(store.Id, GetDeliveryMethod(store, receivingMethod), simulate), cancellationToken))).Map((SetShopResponse dto) => dto, (ServiceError error) => error.ToBaseDomainError());
		if (result.IsSuccess && simulate == false && goingToChangeMerchant)
		{
			AppAnalytics.Loymax.MerchantSelection(store);
		}
		return result;
	}

	public async Task<Result<(ReceivingMethod?, Store?), DomainError>> CurrentUserStore()
	{
		Result<Cities, DomainError> citiesResult = await Cities();
		if (citiesResult.IsFailure)
		{
			return Result.Failure<(ReceivingMethod?, Store), DomainError>(citiesResult.Error);
		}
		Result<CurrentShopResponse, ServiceError> result = await _requestExecutor.Value.ExecuteWithToken((CancellationToken cancellationToken, TokenModel tokenModel) => _storeApi.Value.CurrentOrDefault(tokenModel.Token, cancellationToken));
		if (result.IsFailure)
		{
			return Result.Failure<(ReceivingMethod?, Store), DomainError>(result.Error.ToBaseDomainError());
		}
		ShopDto dto = result.Value.Current;
		if (dto == null)
		{
			return Result.Success<(ReceivingMethod?, Store), DomainError>((result.Value.CurrentReceiveMethod, null));
		}
		City city = citiesResult.Value.FirstOrDefault((City city2) => city2.EcomId == dto.RegionId);
		if (city == null)
		{
			return Result.Failure<(ReceivingMethod?, Store), DomainError>(new UnknownError());
		}
		return Result.Success<(ReceivingMethod?, Store), DomainError>((result.Value.CurrentReceiveMethod, dto.ToStoreModel(city, _logService)));
	}

	public async Task<Result<Store, DomainError>> DefaultStore()
	{
		Result<IEnumerable<IGrouping<City, Store>>, DomainError> result = await AllCityShops();
		if (result.IsFailure)
		{
			return Result.Failure<Store, DomainError>(result.Error);
		}
		Store store = result.Value.FirstOrDefault((IGrouping<City, Store> group) => group.Key.IsDefault)?.FirstOrDefault((Store store2) => store2.IsDefaultInCity);
		return (store == null) ? Result.Failure<Store, DomainError>(new UnknownError()) : Result.Success<Store, DomainError>(store);
	}

	public async Task<Result<City?, DomainError>> CityByLocation(IEnumerable<City> cities, Coordinate coordinate)
	{
		return (await _requestExecutor.Value.Execute((CancellationToken t) => _storeApi.Value.DeliveryMethodsForAddressAsync(coordinate.Lat, coordinate.Lon, t))).Map(delegate(DeliveryMethodsForAddressResponseDto dto)
		{
			DeliveryMethodsForAddressResponseDto.DataDto? data = dto.Data;
			return ((object)data != null && data.RegionId.HasValue) ? cities.Where((City c) => c.EcomId == dto.Data?.RegionId).FirstOrDefault() : null;
		}, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<DeliveryMethodsForAddress, DomainError>> DeliveryMethodsForAddressAsync(Coordinate coordinate, IEnumerable<IGrouping<City, Store>> allCityStores)
	{
		return (await _requestExecutor.Value.Execute((CancellationToken t) => _storeApi.Value.DeliveryMethodsForAddressAsync(coordinate.Lat, coordinate.Lon, t))).Map((DeliveryMethodsForAddressResponseDto dto) => dto.ToModel(allCityStores), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<DeliveryMethodsForAddress, DomainError>> DeliveryMethodsForAddressAsync(City region, Coordinate coordinate, IEnumerable<IGrouping<City, Store>> allCityStores)
	{
		return (await _requestExecutor.Value.Execute((CancellationToken t) => _storeApi.Value.DeliveryMethodsForAddressAsync(region.EcomId, coordinate.Lat, coordinate.Lon, t))).Map((DeliveryMethodsForAddressResponseDto dto) => dto.ToModel(allCityStores), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<DeliveryMethodsForAddress, DomainError>> DeliveryMethodsForAddressAsync(long storeId, Coordinate coordinate, IEnumerable<IGrouping<City, Store>> allCityStores)
	{
		return (await _requestExecutor.Value.Execute((CancellationToken t) => _storeApi.Value.DeliveryMethodsForAddressAsync(storeId, coordinate.Lat, coordinate.Lon, t))).Map((DeliveryMethodsForAddressResponseDto dto) => dto.ToModel(allCityStores), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<ReceiveMethodsResponseDTO, DomainError>> ReceiveMethods()
	{
		Result<Location, DomainError> result = await _locationProvider.Value.GetLocation(askPermission: false, GeolocationAccuracy.High, TimeSpan.FromSeconds(5L));
		double? lat = null;
		double? lon = null;
		if (result.IsSuccess)
		{
			lat = result.Value.Latitude;
			lon = result.Value.Longitude;
		}
		return (await _requestExecutor.Value.ExecuteWithToken((CancellationToken ct, TokenModel token) => _storeApi.Value.GetReceiveMethods(token, lat, lon, ct))).Map((ReceiveMethodsResponseDTO dto) => dto, (ServiceError err) => err.ToBaseDomainError());
	}
}
