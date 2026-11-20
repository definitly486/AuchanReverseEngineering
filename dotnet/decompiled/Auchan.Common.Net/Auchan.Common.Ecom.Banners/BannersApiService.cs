using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.Banners.DTO;
using Auchan.Common.Ecom.Banners.Mappers;
using Auchan.Common.Ecom.Banners.Models;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Ecom.Banners;

internal class BannersApiService : IBannersApiService
{
	private readonly IResolver _resolver;

	private readonly Lazy<IBannersApi> _api;

	private readonly Lazy<IRequestExecutor> _requestExecutor;

	private readonly Lazy<IDeviceService> _deviceService;

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<IUserContext> _userContext;

	public BannersApiService(IResolver resolver, Lazy<IBannersApi> api, Lazy<IRequestExecutor> requestExecutor, Lazy<IDeviceService> deviceService, Lazy<IEcomContext> ecomContext, Lazy<IUserContext> userContext)
	{
		_resolver = resolver;
		_api = api;
		_requestExecutor = requestExecutor;
		_deviceService = deviceService;
		_ecomContext = ecomContext;
		_userContext = userContext;
	}

	public Task<Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError>> GetBanners(CancellationToken cancellationToken = default(CancellationToken))
	{
		return Task.Run(async delegate
		{
			string userAgent = _deviceService.Value.BuildNumberAndOSVersion;
			Store store = await _ecomContext.Value.GetActiveStoreAsync();
			BannersRequestDto request = new BannersRequestDto
			{
				Filter = new BannersRequestDto.FilterDto
				{
					MerchantId = store.Id,
					RegionId = store.City.EcomId
				}
			};
			Result<IReadOnlyDictionary<string, IReadOnlyList<BannerDto>>, ServiceError> result = ((!_userContext.Value.Authorized) ? (await _requestExecutor.Value.Execute((CancellationToken ct) => _api.Value.GetBanners(userAgent, request, ct), cancellationToken)) : (await _requestExecutor.Value.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.Value.GetBanners(t.Token, userAgent, request, ct), TokenLevel.L80, cancellationToken)));
			Result<IReadOnlyDictionary<string, IReadOnlyList<BannerDto>>, ServiceError> result2 = result;
			ServiceError error;
			return result2.TryGetError(out error) ? ((Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError>)error.ToBaseDomainError()) : ((Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError>)(IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>)(from i in result2.Value.SelectMany((KeyValuePair<string, IReadOnlyList<BannerDto>> i) => i.Value)
				where i.Type.IsSupported()
				orderby i.Priority
				select i.Map(_resolver) into i
				group i by i.Type).ToImmutableDictionary((Func<IGrouping<BannerType, Banner>, BannerType>)((IGrouping<BannerType, Banner> i) => i.Key), (Func<IGrouping<BannerType, Banner>, IReadOnlyList<Banner>>)((IGrouping<BannerType, Banner> g) => g.ToImmutableList())));
		});
	}
}
