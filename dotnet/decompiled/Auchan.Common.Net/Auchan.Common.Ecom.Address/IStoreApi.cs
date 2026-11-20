using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.Address.DTO;
using Auchan.Common.Ecom.DTO;
using Refit;

namespace Auchan.Common.Ecom.Address;

public interface IStoreApi
{
	[Get("/regions")]
	Task<IApiResponse<RegionsResponse>> Regions([Header("user-agent-new")] string userAgent, [AliasAs("need_ll")] int getCoordinates, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/regions")]
	Task<IApiResponse<RegionsResponse>> AllExistingRegions([Header("user-agent-new")] string userAgent, [AliasAs("show_all_regions")] string showAll = "1", CancellationToken cancellationToken = default(CancellationToken));

	[Get("/shops")]
	Task<ShopsResponse> Shops([AliasAs("lat")] double? lat = null, [AliasAs("lon")] double? lon = null, [AliasAs("only_visible")] long? showVisible = null, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/shops/delivery-methods-for-address")]
	Task<DeliveryMethodsForAddressResponseDto> DeliveryMethodsForAddressAsync([AliasAs("geo_lat")] float latitude, [AliasAs("geo_lon")] float longitude, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/shops/delivery-methods-for-address")]
	Task<DeliveryMethodsForAddressResponseDto> DeliveryMethodsForAddressAsync([AliasAs("region_id")] long regionId, [AliasAs("geo_lat")] float latitude, [AliasAs("geo_lon")] float longitude, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/shops/current")]
	Task<CurrentShopResponse> CurrentOrDefault([Header("X-Token-CMD")] string token80, CancellationToken cancellationToken = default(CancellationToken));

	[Put("/shops/current")]
	Task<SetShopResponse> SetCurrentShop([Header("X-Token-CMD")] string token80, [Body] SetShopRequest request, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/customers/receive-methods")]
	Task<ReceiveMethodsResponseDTO> GetReceiveMethods([Header("X-Token-CMD")] string token80, [Query("lat")] double? lat, [Query("lon")] double? lon, CancellationToken cancellationToken = default(CancellationToken));
}
