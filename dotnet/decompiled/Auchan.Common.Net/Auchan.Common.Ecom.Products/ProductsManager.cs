using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.Filters;
using Auchan.Common.Extensions;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Products;

public class ProductsManager : IProductsManager
{
	private readonly IProductsRepository _productsRepository;

	private readonly IEcomContext _ecomContext;

	public ProductsManager(IProductsRepository productsRepository, IEcomContext ecomContext)
	{
		_productsRepository = productsRepository;
		_ecomContext = ecomContext;
	}

	public async Task<Result<ProductResult, DomainError>> GetProductsByCategoryAsync(string categoryCode, int offset, ProductSortType? orderType, bool isAdult = true, List<string>? filters = null, int perPage = 25)
	{
		Result<ProductResult, DomainError> result = await _productsRepository.GetAllProductsByCategoryAsync(categoryCode, _ecomContext.ActiveStore.Id, offset, orderType?.Field, orderType?.Direction, isAdult.ToNullIfTrue(), filters, perPage);
		if (result.IsFailure)
		{
			return Result.Failure<ProductResult, DomainError>(result.Error);
		}
		if (result.Value.Items == null)
		{
			return default(Result<ProductResult, DomainError>);
		}
		return Result.Success<ProductResult, DomainError>(result.Value);
	}

	public async Task<Result<ProductResult, DomainError>> GetProductsByCategoryAsync(string categoryCode, int offset, ProductSortType? orderType, bool isAdult = true, IReadOnlyDictionary<string, object>? filters = null, int perPage = 25)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (filters != null)
		{
			dictionary.AddCollection<KeyValuePair<string, object>>(filters);
		}
		if (!isAdult)
		{
			dictionary["is_adult"] = false;
		}
		dictionary["category"] = categoryCode;
		Result<ProductResult, DomainError> result = await _productsRepository.GetAllProductsByCategoryAsync(_ecomContext.ActiveStore.Id, offset, orderType?.Field, orderType?.Direction, new ProductRequestDto(dictionary), perPage);
		if (result.IsFailure)
		{
			return Result.Failure<ProductResult, DomainError>(result.Error);
		}
		if (result.Value.Items == null)
		{
			return default(Result<ProductResult, DomainError>);
		}
		return Result.Success<ProductResult, DomainError>(result.Value);
	}

	public async Task<Result<ProductResult, DomainError>> GetProductsByBrandAsync(string brandCode, int offset, ProductSortType? orderType, List<string> filters, bool isAdult = true, int perPage = 25)
	{
		Result<ProductResult, DomainError> result = await _productsRepository.GetAllProductsByBrandAsync(brandCode, _ecomContext.ActiveStore.Id, offset, orderType?.Field, orderType?.Direction, (filters.Count > 0) ? filters : null, isAdult.ToNullIfTrue(), perPage);
		if (result.IsFailure)
		{
			return Result.Failure<ProductResult, DomainError>(result.Error);
		}
		if (result.Value.Items == null)
		{
			return default(Result<ProductResult, DomainError>);
		}
		return Result.Success<ProductResult, DomainError>(result.Value);
	}

	public async Task<Result<ProductResult, DomainError>> GetProductsByCategoryAndBrandAsync(string categoryCode, string brandCode, int offset, ProductSortType? orderType, bool isAdult = true, IReadOnlyDictionary<string, object>? filters = null, int perPage = 25)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (filters != null)
		{
			dictionary.AddCollection<KeyValuePair<string, object>>(filters);
		}
		if (!isAdult)
		{
			dictionary["is_adult"] = false;
		}
		dictionary["category"] = categoryCode;
		dictionary["brand"] = brandCode;
		Result<ProductResult, DomainError> result = await _productsRepository.GetAllProductsByCategoryAsync(_ecomContext.ActiveStore.Id, offset, orderType?.Field, orderType?.Direction, new ProductRequestDto(dictionary), perPage);
		if (result.IsFailure)
		{
			return Result.Failure<ProductResult, DomainError>(result.Error);
		}
		if (result.Value.Items == null)
		{
			return default(Result<ProductResult, DomainError>);
		}
		return Result.Success<ProductResult, DomainError>(result.Value);
	}

	public async Task<Result<ProductResult, DomainError>> GetProductsSuperPricesAsync(int offset, ProductSortType? orderType, List<string> filters, bool isAdult = true, int perPage = 25)
	{
		Result<ProductResult, DomainError> result = await _productsRepository.GetProductsPromoOnlyAsync(_ecomContext.ActiveStore.Id, offset, orderType?.Field, orderType?.Direction, (filters.Count > 0) ? filters : null, isAdult.ToNullIfTrue(), perPage);
		if (result.IsFailure)
		{
			return Result.Failure<ProductResult, DomainError>(result.Error);
		}
		if (result.Value.Items == null)
		{
			return default(Result<ProductResult, DomainError>);
		}
		return Result.Success<ProductResult, DomainError>(result.Value);
	}

	public async Task<Result<ProductResult, DomainError>> GetProductsByCashbackAvailableAsync(int offset, ProductSortType? orderType, List<string> filters, bool isAdult, int perPage = 25)
	{
		Result<ProductResult, DomainError> result = await _productsRepository.GetProductsWithCashbackAsync(_ecomContext.ActiveStore.Id, offset, orderType?.Field, orderType?.Direction, filters, isAdult.ToNullIfTrue(), perPage);
		if (result.IsFailure)
		{
			return Result.Failure<ProductResult, DomainError>(result.Error);
		}
		if (result.Value.Items == null)
		{
			return default(Result<ProductResult, DomainError>);
		}
		return Result.Success<ProductResult, DomainError>(result.Value);
	}

	public Task<Result<Product, DomainError>> GetProductDetailAsync(string productCode)
	{
		return _productsRepository.GetProductDetailAsync(productCode, _ecomContext.ActiveStore.Id);
	}

	public Task<Result<ProductFilterResult, DomainError>> GetFiltersAsync(string categoryCode, FilterRequestDto? request = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return _productsRepository.GetFiltersAsync(categoryCode, _ecomContext.ActiveStore.Id, request, cancellationToken);
	}
}
