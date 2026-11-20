using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Addresses;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Address.DTO;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.DTO;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Ecom.Address;

public interface IStoreService
{
	Task<Result<Cities, DomainError>> PrefetchCities();

	Task<Result<IEnumerable<IGrouping<City, Store>>, DomainError>> AllCityShops(Location? coordinates = null, bool showVisible = false);

	Task<Result<(ReceivingMethod? currentReceiveMethod, Store? store), DomainError>> CurrentUserStore();

	Task<Result<Store, DomainError>> DefaultStore();

	Task<Result<SetShopResponse, DomainError>> SetCurrentUserStore(Store store, ReceivingMethod receivingMethod, bool? simulate = null);

	Task<Result<Cities, DomainError>> Cities(bool getCoordinates = false);

	Task<Result<Cities, DomainError>> AllExistingRegions();

	Task<Result<ReceiveMethodsResponseDTO, DomainError>> ReceiveMethods();

	Task<Result<DeliveryMethodsForAddress, DomainError>> DeliveryMethodsForAddressAsync(Coordinate coordinate, IEnumerable<IGrouping<City, Store>> allCityStores);

	Task<Result<DeliveryMethodsForAddress, DomainError>> DeliveryMethodsForAddressAsync(City region, Coordinate coordinate, IEnumerable<IGrouping<City, Store>> allCityStores);

	Task<Result<DeliveryMethodsForAddress, DomainError>> DeliveryMethodsForAddressAsync(long storeId, Coordinate coordinate, IEnumerable<IGrouping<City, Store>> allCityStores);

	Task<Result<City?, DomainError>> CityByLocation(IEnumerable<City> cities, Coordinate coordinate);
}
