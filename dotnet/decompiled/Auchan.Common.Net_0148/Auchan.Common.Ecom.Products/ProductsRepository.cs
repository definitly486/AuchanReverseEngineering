using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.PriceChecker;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.Filters;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Products;

public class ProductsRepository : IProductsRepository
{
	private const string _sortTypeCache = "sort_type_cache";

	private readonly ICache _cache;

	private readonly IProductsApi _productApi;

	private readonly IRequestExecutor _requestExecutor;

	private readonly IEcomContext _ecomContext;

	private readonly ITokenService _tokenService;

	private readonly TimeSpan _sortCacheLifeTime = TimeSpan.FromHours(4);

	public ProductsRepository(IProductsApi productApi, IRequestExecutor requestExecutor, ICache cache, ISearchAPI searchAPI, ITokenService tokenService, IEcomContext ecomContext)
	{
		_productApi = productApi;
		_requestExecutor = requestExecutor;
		_cache = cache;
		_ecomContext = ecomContext;
		_tokenService = tokenService;
	}

	public async Task<Result<ProductResult, DomainError>> GetAllProductsByBrandAsync(string brandCode, int storeId, int offset, string? orderField, string? orderDirection, List<string>? filters, bool? isAdult = null, int perPage = 25)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _productApi.GetAllProductsByBrandAsync(brandCode, storeId, offset, orderField, orderDirection, filters, isAdult, perPage, t))).Map((ProductResultDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<ProductResult, DomainError>> GetAllProductsByCategoryAsync(string categoryCode, int storeId, int offset, string? orderField, string? orderDirection, bool? isAdult = null, List<string>? filters = null, int perPage = 25)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _productApi.GetAllProductsByCategoryAsync(categoryCode, storeId, offset, orderField, orderDirection, isAdult, filters, perPage, t))).Map((ProductResultDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<ProductResult, DomainError>> GetAllProductsByCategoryAsync(int storeId, int offset, string? orderField, string? orderDirection, ProductRequestDto? request = null, int perPage = 25)
	{
		Result<TokenModel, DomainError> result = await _tokenService.SavedToken80();
		if (result.IsSuccess)
		{
			string token80 = result.Value.Token;
			return (await _requestExecutor.Execute((CancellationToken t) => _productApi.GetAllProductsByCategoryAsync(token80, storeId, offset, !_ecomContext.ReceivingMethodNotSelected, orderField, orderDirection, request, perPage, t))).Map((ProductResultDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
		}
		return (await _requestExecutor.Execute((CancellationToken t) => _productApi.GetAllProductsByCategoryAsync(null, storeId, offset, !_ecomContext.ReceivingMethodNotSelected, orderField, orderDirection, request, perPage, t))).Map((ProductResultDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<ProductResult, DomainError>> GetProductsPromoOnlyAsync(int storeId, int offset, string? orderField, string? orderDirection, List<string>? filters, bool? isAdult = null, int perPage = 25)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _productApi.GetProductsPromoOnlyAsync(storeId, offset, orderField, orderDirection, filters, isAdult, 1, perPage, t))).Map((ProductResultDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<ProductResult, DomainError>> GetProductsWithCashbackAsync(int storeId, int offset, string? orderField, string? orderDirection, List<string> filters, bool? isAdult = null, int perPage = 25)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _productApi.GetProductsCashbackOnlyAsync(storeId, 1, offset, orderField, orderDirection, filters, isAdult, 1, perPage, t))).Map((ProductResultDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<Product, DomainError>> GetProductDetailAsync(string? productCode, int storeId, string? gimaId = null, string channel = "online", PriceCheckerChannel priceCheckerChannel = PriceCheckerChannel.None)
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		string pcc = priceCheckerChannel switch
		{
			PriceCheckerChannel.Online => "online", 
			PriceCheckerChannel.Offline => "offline", 
			_ => null, 
		};
		Result<ProductDto, ServiceError> result = ((!tokenResult.IsSuccess) ? (await _requestExecutor.Execute((CancellationToken cancellationToken) => _productApi.GetProductDetailWithoutTokenAsync(productCode, storeId, gimaId, channel, pcc, cancellationToken))) : (await _requestExecutor.Execute((CancellationToken cancellationToken) => _productApi.GetProductDetailWithTokenAsync(tokenResult.Value.Token, productCode, storeId, gimaId, channel, pcc, cancellationToken))));
		return result.Map((ProductDto dto) => dto.Map(priceCheckerChannel), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<IReadOnlyList<Product>, DomainError>> GetProductsByGimaIdAsync(string storeId, IEnumerable<string> gimaIds)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _productApi.GetProductsByGimaIdAsync(storeId, gimaIds, t))).Map((ProductDto[] dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<ProductSortTypes, DomainError>> GetSortTypes()
	{
		ProductSortTypes productSortTypes = await _cache.TryGet<ProductSortTypes>("sort_type_cache");
		if (productSortTypes != null)
		{
			return Result.Success<ProductSortTypes, DomainError>(productSortTypes);
		}
		Result<ProductSortTypesDto, ServiceError> result = await _requestExecutor.Execute((CancellationToken _) => _productApi.GetSortTypes());
		if (result.TryGetValue(out var value))
		{
			if (value == null)
			{
				return new NoDataError();
			}
			ProductSortTypes productTypes = value.Map();
			if (productTypes == null || productTypes.Items.IsNullOrEmpty())
			{
				return new NoDataError();
			}
			await _cache.Save("sort_type_cache", productTypes, _sortCacheLifeTime);
			return productTypes;
		}
		return result.Error.ToBaseDomainError();
	}

	public async Task<Result<ProductFilterResult, DomainError>> GetFiltersAsync(string categoryCode, int storeId, FilterRequestDto? request = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _productApi.GetFiltersAsync(categoryCode, storeId, request, t), cancellationToken)).Map((ProductFilterResponseDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}
}
