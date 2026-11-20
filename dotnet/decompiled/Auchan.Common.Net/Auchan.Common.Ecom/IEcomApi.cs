using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.DTO;
using Refit;

namespace Auchan.Common.Ecom;

public interface IEcomApi
{
	[Get("/categories")]
	Task<IReadOnlyList<CategoryDto>> TopCategories([AliasAs("merchant_id")] int storeId, [AliasAs("promo_only")] string? promoOnly = null, [AliasAs("active_only")] string? activeOnly = null, [AliasAs("show_hidden")] string? showHidden = null, [AliasAs("cashback_only")] string? cashbackOnly = null, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/categories")]
	Task<List<CategoryDto>> Categories([AliasAs("merchant_id")] int storeId, [AliasAs("node_code")] string categoryCode, [AliasAs("show_hidden")] string? showHidden = null, [AliasAs("active_only")] string? activeOnly = null, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/categories/preview")]
	Task<CategoriesPreviewDto> CategoriesPreview([AliasAs("merchant_id")] int storeId, [AliasAs("node_code")] string categoryCode, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/brands/{brand}")]
	Task<BrandResponseDto> Brand([AliasAs("merchant_id")] int storeId, string brand, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/cart/stamp-discount")]
	Task<StampDiscountDto> CartStampDiscount([Header("X-Token-CMD")] string token80, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/cart/data?clear_cache=Y")]
	Task<CartDto> CartNoCache([Header("X-Token-CMD")] string token80, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/cart/change-items")]
	Task<CartItemsChangedDto> ChangeItems([Header("X-Token-CMD")] string token80, [Body] CartItemsChangeRequest cartItemRequest, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/cart/select-all")]
	Task<object> SetAllSelected([Header("X-Token-CMD")] string token80, [Body] SelectAllRequestDto body, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/cart/item-comment")]
	Task<object> AddCommentToItem([Header("X-Token-CMD")] string token80, CartItemAddCommentRequest cartItemRequest, CancellationToken cancellationToken = default(CancellationToken));

	[Delete("/cart/all")]
	Task<CartDto> ClearCart([Header("X-Token-CMD")] string token80, CancellationToken cancellationToken = default(CancellationToken));

	[Delete("/cart/adult")]
	Task<CartClearResponseDto> ClearAdultProductFromCart([Header("X-Token-CMD")] string token80, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/cart/share-basket")]
	Task<ShareCartResponseDto> ShareCart([Header("X-Token-CMD")] string token80, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/cart/share-basket")]
	Task<SharedCartResponseDto> GetSharedCart([Header("X-Token-CMD")] string token80, [AliasAs("token")] string cartToken, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/cart/combo-suggestions")]
	Task<ComboSuggestionsResponseDto> GetComboSuggestionsAsync([Header("X-Token-CMD")] string token80, [Body] ComboSuggestionsRequestDto request, CancellationToken cancellationToken = default(CancellationToken));
}
