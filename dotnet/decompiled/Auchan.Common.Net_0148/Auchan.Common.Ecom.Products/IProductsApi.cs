using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.DTO;
using Refit;

namespace Auchan.Common.Ecom.Products;

public interface IProductsApi
{
	[Get("/catalog/products")]
	Task<ProductResultDto> GetAllProductsByCategoryAsync([AliasAs("filter[category]")] string categoryCode, [AliasAs("merchantId")] int storeId, [AliasAs("offset")] int offset, [AliasAs("orderField")] string? orderField, [AliasAs("orderDirection")] string? orderDirection, [AliasAs("filter[is_adult]")] bool? isAdult, [Query(CollectionFormat.Multi)][AliasAs("filter[category][]")] List<string>? filters, [AliasAs("perPage")] int perPage = 25, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/catalog/products")]
	Task<ProductResultDto> GetAllProductsByCategoryAsync([Header("X-Token-CMD")] string? accessToken, [AliasAs("merchantId")] int storeId, [AliasAs("offset")] int offset, [AliasAs("deliveryAddressSelected")] bool deliveryAddressSelected, [AliasAs("orderField")] string? orderField, [AliasAs("orderDirection")] string? orderDirection, [Body] ProductRequestDto? request, [AliasAs("perPage")] int perPage = 25, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/catalog/products")]
	Task<ProductResultDto> GetAllProductsByBrandAsync([AliasAs("filter[brand][]")] string brandCode, [AliasAs("merchantId")] int storeId, [AliasAs("offset")] int offset, [AliasAs("orderField")] string? orderField, [AliasAs("orderDirection")] string? orderDirection, [Query(CollectionFormat.Multi)][AliasAs("filter[category][]")] List<string>? filters, [AliasAs("filter[is_adult]")] bool? isAdult, [AliasAs("perPage")] int perPage = 25, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/catalog/product-detail")]
	Task<ProductDto> GetProductDetailWithoutTokenAsync([AliasAs("code")] string? productCode, [AliasAs("merchantId")] int storeId, [AliasAs("gima_id")] string? gimaId = null, [AliasAs("channel")] string channel = "online", [AliasAs("pricechecker_channel")] string? pricecheckerChannel = null, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/catalog/product-detail")]
	Task<ProductDto> GetProductDetailWithTokenAsync([Header("X-Token-CMD")] string accessToken, [AliasAs("code")] string? productCode, [AliasAs("merchantId")] int storeId, [AliasAs("gima_id")] string? gimaId = null, [AliasAs("channel")] string channel = "online", [AliasAs("pricechecker_channel")] string? pricecheckerChannel = null, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/catalog/get-products")]
	Task<ProductDto[]> GetProductsByGimaIdAsync([AliasAs("merchantId")] string merchantId, [Body] IEnumerable<string> gimaIds, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/catalog/order-fields")]
	Task<ProductSortTypesDto> GetSortTypes();

	[Get("/catalog/products")]
	Task<ProductResultDto> GetProductsPromoOnlyAsync([AliasAs("merchantId")] int storeId, [AliasAs("offset")] int? offset, [AliasAs("orderField")] string? orderField, [AliasAs("orderDirection")] string? orderDirection, [Query(CollectionFormat.Multi)][AliasAs("filter[category][]")] List<string>? filters, [AliasAs("filter[is_adult]")] bool? isAdult, [AliasAs("filter[promo_only]")] int promoOnly = 1, [AliasAs("perPage")] int perPage = 25, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/catalog/products")]
	Task<ProductResultDto> GetProductsCashbackOnlyAsync([AliasAs("merchantId")] int storeId, [AliasAs("page")] int page, [AliasAs("offset")] int offset, [AliasAs("orderField")] string? orderField, [AliasAs("orderDirection")] string? orderDirection, [Query(CollectionFormat.Multi)][AliasAs("filter[category][]")] List<string>? filters, [AliasAs("filter[is_adult]")] bool? isAdult, [AliasAs("filter[cashback_only]")] int cashbackOnly = 1, [AliasAs("perPage")] int perPage = 25, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/catalog/filter")]
	Task<ProductFilterResponseDto> GetFiltersAsync([AliasAs("categoryCode")] string categoryCode, [AliasAs("merchantId")] int storeId, [Body] FilterRequestDto? request, CancellationToken cancellationToken = default(CancellationToken));
}
