using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.Filters;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Products;

public interface IProductsManager
{
	Task<Result<ProductResult, DomainError>> GetProductsByCategoryAsync(string categoryCode, int offset, ProductSortType? orderType, bool isAdult = true, List<string>? filters = null, int perPage = 25);

	Task<Result<ProductResult, DomainError>> GetProductsByCategoryAsync(string categoryCode, int offset, ProductSortType? orderType, bool isAdult = true, IReadOnlyDictionary<string, object>? filters = null, int perPage = 25);

	Task<Result<ProductResult, DomainError>> GetProductsByBrandAsync(string brandCode, int offset, ProductSortType? orderType, List<string> filters, bool isAdult = true, int perPage = 25);

	Task<Result<ProductResult, DomainError>> GetProductsByCategoryAndBrandAsync(string categoryCode, string brandCode, int offset, ProductSortType? orderType, bool isAdult = true, IReadOnlyDictionary<string, object>? filters = null, int perPage = 25);

	Task<Result<ProductResult, DomainError>> GetProductsSuperPricesAsync(int offset, ProductSortType? orderType, List<string> filters, bool isAdult = true, int perPage = 25);

	Task<Result<ProductResult, DomainError>> GetProductsByCashbackAvailableAsync(int offset, ProductSortType? orderType, List<string> filters, bool isAdult, int perPage = 25);

	Task<Result<Product, DomainError>> GetProductDetailAsync(string productCode);

	Task<Result<ProductFilterResult, DomainError>> GetFiltersAsync(string categoryCode, FilterRequestDto? request = null, CancellationToken cancellationToken = default(CancellationToken));
}
