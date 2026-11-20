using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.Profile.Stores.Dto;
using Auchan.Common.Profile.Stores.Infrastructure;
using Auchan.Common.Profile.Stores.Models;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Profile.Stores.Services;

public class FullStoreService : IFullStoreService
{
	private readonly IFullStoreApi _api;

	private readonly IStoreApi _shopsApi;

	private readonly IDeviceService _deviceService;

	private readonly IRequestExecutor _requestExecutor;

	public FullStoreService(IFullStoreApi api, IStoreApi shopsApi, IRequestExecutor requestExecutor, IDeviceService deviceService)
	{
		_api = api;
		_shopsApi = shopsApi;
		_requestExecutor = requestExecutor;
		_deviceService = deviceService;
	}

	public async Task<Result<List<FullStoreModel>, DomainError>> GetSelfScanStores(CancellationToken token = default(CancellationToken))
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.GetSelfScanStores(t), token)).Ensure((List<FullStoreDto> x) => x != null && x.Count > 0, new ApiContractError()).Map((List<FullStoreDto> dto) => dto.ToModel(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<(List<FullStoreModel>, List<FullStoreServiceModel>), DomainError>> GetStoresAndServicesAsync(Location? geoPosition = null)
	{
		Result<ShopsResponse, ServiceError> result = await _requestExecutor.Execute((CancellationToken t) => _shopsApi.Shops(geoPosition?.Latitude, geoPosition?.Longitude, 1L, t));
		if (result.IsFailure)
		{
			return Result.Failure<(List<FullStoreModel>, List<FullStoreServiceModel>), DomainError>(result.Error.ToBaseDomainError());
		}
		if (result.Value.Shops == null || result.Value.Shops.Count == 0)
		{
			return Result.Failure<(List<FullStoreModel>, List<FullStoreServiceModel>), DomainError>(new ApiContractError().ToBaseDomainError());
		}
		List<FullStoreModel> item = result.Value.Shops.Select((ShopDto dto) => dto.ToModel()).ToList();
		List<FullStoreServiceModel> list = new List<FullStoreServiceModel>();
		if (result.Value.Services != null && result.Value.Services.Count > 0)
		{
			list.AddRange(result.Value.Services.Select((ShopServiceDto dto) => dto.ToModel()));
		}
		return Result.Success<(List<FullStoreModel>, List<FullStoreServiceModel>), DomainError>((item, list));
	}
}
