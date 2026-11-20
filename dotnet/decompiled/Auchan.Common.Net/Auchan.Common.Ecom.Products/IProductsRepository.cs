using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.PriceChecker;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.Filters;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Products;

public interface IProductsRepository
{
	Task<Result<ProductSortTypes, DomainError>> GetSortTypes();

	Task<Result<ProductResult, DomainError>> GetAllProductsByCategoryAsync(string categoryCode, int storeId, int offset, string? orderField, string? orderDirection, bool? isAdult = null, List<string>? filters = null, int perPage = 25);

	Task<Result<ProductResult, DomainError>> GetAllProductsByBrandAsync(string brandCode, int storeId, int offset, string? orderField, string? orderDirection, List<string>? filters, bool? isAdult = null, int perPage = 25);

	Task<Result<ProductResult, DomainError>> GetProductsPromoOnlyAsync(int storeId, int offset, string? orderField, string? orderDirection, List<string>? filters, bool? isAdult = null, int perPage = 25);

	Task<Result<ProductResult, DomainError>> GetProductsWithCashbackAsync(int storeId, int offset, string? orderField, string? orderDirection, List<string> filters, bool? isAdult = null, int perPage = 25);

	Task<Result<ProductResult, DomainError>> GetAllProductsByCategoryAsync(int storeId, int offset, string? orderField, string? orderDirection, ProductRequestDto? request = null, int perPage = 25);

	Task<Result<Product, DomainError>> GetProductDetailAsync(string? productCode, int storeId, string? gimaId = null, string channel = "online", PriceCheckerChannel priceCheckerChannel = PriceCheckerChannel.None);

	Task<Result<IReadOnlyList<Product>, DomainError>> GetProductsByGimaIdAsync(string storeId, IEnumerable<string> gimaIds);

	Task<Result<ProductFilterResult, DomainError>> GetFiltersAsync(string categoryCode, int storeId, FilterRequestDto? request = null, CancellationToken cancellationToken = default(CancellationToken));
}
