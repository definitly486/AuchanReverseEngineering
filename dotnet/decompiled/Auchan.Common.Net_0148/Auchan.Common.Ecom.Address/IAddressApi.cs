using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.DTO;
using Refit;

namespace Auchan.Common.Ecom.Address;

public interface IAddressApi
{
	[Post("/lk/address")]
	Task<SetAddressResponse> SaveAddress([Header("X-Token-CMD")] string token80, [Body] SaveAddressRequest request, CancellationToken cancellationToken = default(CancellationToken));

	[Put("/lk/address")]
	Task<object> UpdateAddress([Header("X-Token-CMD")] string token80, [Body] UpdateAddressRequest request, CancellationToken cancellationToken = default(CancellationToken));

	[Delete("/lk/address/{addressId}?")]
	Task<object> RemoveSavedAddress([Header("X-Token-CMD")] string token80, long addressId, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/lk/receive-methods")]
	Task<ReceiveMethodsResponseDto> SavedReceiveMethods([Header("X-Token-CMD")] string token80, CancellationToken cancellationToken = default(CancellationToken));

	[Delete("/lk/pickup-shop/{shopId}")]
	Task<object> RemoveSavedPickupShop([Header("X-Token-CMD")] string token80, int shopId, CancellationToken cancellationToken = default(CancellationToken));

	[Delete("/lk/car-pickup-shop/{shopId}")]
	Task<object> RemoveSavedCarPickupShop([Header("X-Token-CMD")] string token80, int shopId, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/address-suggest-geocode")]
	Task<SuggestGeocodeResponseDto> SuggestGeocode([Header("X-Token-CMD")] string token80, [Body] SuggestGeocodeRequestDto requestBody, CancellationToken cancellationToken = default(CancellationToken));
}
