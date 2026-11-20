using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Addresses;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Address.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Address;

public interface IUserAddressService
{
	Task<Result<SavedReceiveMethods, DomainError>> SavedReceiveMethods(CancellationToken cancellationToken = default(CancellationToken));

	Task<Result<Unit, DomainError>> RemoveSavedPickupShop(int shopId, CancellationToken cancellationToken = default(CancellationToken));

	Task<Result<Unit, DomainError>> RemoveSavedCarPickupShop(int shopId, CancellationToken cancellationToken = default(CancellationToken));

	Task<Result<SavedAddress, DomainError>> SaveAddress(DeliveryAddress address, CancellationToken cancellationToken = default(CancellationToken));

	Task<Result<SavedAddress, DomainError>> SaveAddress(SavedAddress savedAddress, CancellationToken cancellationToken = default(CancellationToken));

	Task<Result<object, DomainError>> UpdateAddress(SavedAddress savedAddress, CancellationToken cancellationToken = default(CancellationToken));

	Task<Result<SuggestionResult, DomainError>> SuggestGeocode(SavedAddress savedAddress, CancellationToken cancellationToken = default(CancellationToken));

	Task<Result<SuggestionResult, DomainError>> SuggestGeocode(Coordinate coordinate, CancellationToken cancellationToken = default(CancellationToken));

	Task<Result<Unit, DomainError>> RemoveSavedAddress(long addressId, CancellationToken cancellationToken = default(CancellationToken));

	Task<Result<SuggestionResult, DomainError>> SuggestGeocode(City city, string query, CancellationToken cancellationToken = default(CancellationToken));

	Task<Result<SuggestionResult, DomainError>> SuggestGeocode(DeliveryAddress deliveryAddres, CancellationToken cancellationToken = default(CancellationToken));
}
