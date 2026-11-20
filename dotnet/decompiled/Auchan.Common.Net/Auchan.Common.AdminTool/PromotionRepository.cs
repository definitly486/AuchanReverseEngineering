using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool.DTO;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Common;
using Auchan.Common.Deeplinks;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Extensions;
using CSharpFunctionalExtensions;
using Polly;

namespace Auchan.Common.AdminTool;

public class PromotionRepository : IPromotionRepository
{
	private readonly Lazy<IPromotionsApi> _api;

	private readonly Lazy<IAdminToolAuthorizer> _authorizer;

	private readonly Lazy<IProductsRepository> _productsRepository;

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<IDeviceService> _deviceService;

	public PromotionRepository(Lazy<IPromotionsApi> api, Lazy<IAdminToolAuthorizer> authorizer, Lazy<IProductsRepository> productsRepository, Lazy<IEcomContext> ecomContext, Lazy<IDeviceService> deviceService)
	{
		_api = api;
		_authorizer = authorizer;
		_productsRepository = productsRepository;
		_ecomContext = ecomContext;
		_deviceService = deviceService;
	}

	public Task<Result<List<Promotion>, DomainError>> Promotions(string regionFiasId, string storeId, List<string>? segments)
	{
		return Task.Run(async delegate
		{
			Result<List<PromotionDto>, ServiceError> serviceResult = await Policy.TimeoutAsync(15).ExecuteAsync((CancellationToken t) => RequestPromotions(regionFiasId, storeId, segments, t), CancellationToken.None);
			if (serviceResult.IsSuccess)
			{
				foreach (PromotionDto promotion in serviceResult.Value.Where((PromotionDto x) => x.Deeplink == DeeplinkType.Product))
				{
					Result<Product, DomainError> result = await _productsRepository.Value.GetProductDetailAsync(promotion.DeeplinkId ?? "", _ecomContext.Value.ActiveStore.Id);
					if (result.IsSuccess)
					{
						promotion.GimaId = result.Value.GimaId ?? "";
					}
				}
			}
			return serviceResult.Map((List<PromotionDto> dto) => dto.Select(PromotionMapper.ToModel).ToList(), (ServiceError err) => err.ToBaseDomainError());
		});
	}

	public Task<Result<ImmutableList<ExtraPromotion>, DomainError>> ExtraPromotions(string regionFiasId)
	{
		return Task.Run(async () => (await Policy.TimeoutAsync(15).ExecuteAsync((CancellationToken t) => RequestExtraPromotions(regionFiasId, t), CancellationToken.None)).Map((List<ExtraPromotionDto> dto) => dto.Select(PromotionMapper.ToModel).ToImmutableList(), (ServiceError err) => err.ToBaseDomainError()));
	}

	private async Task<Result<List<PromotionDto>, ServiceError>> RequestPromotions(string regionFiasId, string storeId, IEnumerable<string>? segments, CancellationToken t)
	{
		Result<string, ServiceError> result = await _authorizer.Value.UdidKey(t);
		if (result.IsFailure)
		{
			return Result.Failure<List<PromotionDto>, ServiceError>(result.Error);
		}
		return await _api.Value.Promotions(result.Value, regionFiasId, storeId, segments, _deviceService.Value.BuildNumberAndOSVersion, t).CatchErrors();
	}

	private async Task<Result<List<ExtraPromotionDto>, ServiceError>> RequestExtraPromotions(string regionFiasId, CancellationToken t)
	{
		Result<string, ServiceError> result = await _authorizer.Value.UdidKey(t);
		if (result.IsFailure)
		{
			return Result.Failure<List<ExtraPromotionDto>, ServiceError>(result.Error);
		}
		return await _api.Value.ExtraPromotions(result.Value, regionFiasId, t).CatchErrors();
	}
}
