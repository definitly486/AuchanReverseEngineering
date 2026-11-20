using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Addresses;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Address;

public class UserAddressService : IUserAddressService
{
	private readonly IAddressApi _api;

	private readonly IRequestExecutor _requestExecutor;

	public UserAddressService(IAddressApi api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<SavedReceiveMethods, DomainError>> SavedReceiveMethods(CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken2, TokenModel tokenModel) => _api.SavedReceiveMethods(tokenModel.Token, cancellationToken2), TokenLevel.L80, cancellationToken)).Map((ReceiveMethodsResponseDto dto) => dto.Data?.ToModel(), (ServiceError error) => error.ToBaseDomainError()).EnsureNotNull(() => NoDataError.Empty);
	}

	public async Task<Result<Unit, DomainError>> RemoveSavedAddress(long addressId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken2, TokenModel tokenModel) => _api.RemoveSavedAddress(tokenModel.Token, addressId, cancellationToken2), TokenLevel.L80, cancellationToken)).Map((object dto) => Unit.Default, (ServiceError error) => error.ToBaseDomainError());
	}

	public async Task<Result<Unit, DomainError>> RemoveSavedPickupShop(int shopId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken2, TokenModel tokenModel) => _api.RemoveSavedPickupShop(tokenModel.Token, shopId, cancellationToken2), TokenLevel.L80, cancellationToken)).Map((object dto) => Unit.Default, (ServiceError error) => error.ToBaseDomainError());
	}

	public async Task<Result<Unit, DomainError>> RemoveSavedCarPickupShop(int shopId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken2, TokenModel tokenModel) => _api.RemoveSavedCarPickupShop(tokenModel.Token, shopId, cancellationToken2), TokenLevel.L80, cancellationToken)).Map((object dto) => Unit.Default, (ServiceError error) => error.ToBaseDomainError());
	}

	public async Task<Result<SavedAddress, DomainError>> SaveAddress(DeliveryAddress address, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken2, TokenModel tokenModel) => _api.SaveAddress(tokenModel.Token, new SaveAddressRequest
		{
			AddressString = address.AddressLine,
			Uri = address.Uri
		}, cancellationToken2), TokenLevel.L80, cancellationToken)).Ensure((SetAddressResponse dto) => dto.Address != null, new ApiContractError()).Map((SetAddressResponse dto) => dto.Address.ToAddress(), (ServiceError error) => error.ToBaseDomainError());
	}

	public async Task<Result<SavedAddress, DomainError>> SaveAddress(SavedAddress savedAddress, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken2, TokenModel tokenModel) => _api.SaveAddress(tokenModel.Token, new SaveAddressRequest
		{
			AddressId = savedAddress.Id
		}, cancellationToken2), TokenLevel.L80, cancellationToken)).Ensure((SetAddressResponse dto) => dto.Address != null, new ApiContractError()).Map((SetAddressResponse dto) => dto.Address.ToAddress(), (ServiceError error) => error.ToBaseDomainError());
	}

	public async Task<Result<object, DomainError>> UpdateAddress(SavedAddress savedAddress, CancellationToken cancellationToken = default(CancellationToken))
	{
		UpdateAddressRequest req = new UpdateAddressRequest
		{
			Address = new UpdateAddressDto
			{
				Id = savedAddress.Id,
				Flat = savedAddress.Flat,
				Floor = savedAddress.Floor,
				Porch = savedAddress.Porch,
				Intercom = savedAddress.Intercom
			},
			Name = savedAddress.Name,
			Comment = savedAddress.Comment
		};
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken2, TokenModel tokenModel) => _api.UpdateAddress(tokenModel.Token, req, cancellationToken2), TokenLevel.L80, cancellationToken)).Map((object dto) => dto, (ServiceError error) => error.ToBaseDomainError());
	}

	public async Task<Result<SuggestionResult, DomainError>> SuggestGeocode(City city, string query, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.SuggestGeocode(t.Token, new SuggestGeocodeRequestDto(city, query), ct), TokenLevel.L80, cancellationToken)).Map((SuggestGeocodeResponseDto dto) => dto.ToModel(), (ServiceError error) => error.ToBaseDomainError()).EnsureNotNull(() => NoDataError.Empty);
	}

	public async Task<Result<SuggestionResult, DomainError>> SuggestGeocode(SavedAddress savedAddress, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.SuggestGeocode(t.Token, new SuggestGeocodeRequestDto(savedAddress.AddressLine, savedAddress.Coordinate, null), ct), TokenLevel.L80, cancellationToken)).Map((SuggestGeocodeResponseDto dto) => dto.ToModel(), (ServiceError error) => error.ToBaseDomainError()).EnsureNotNull(() => NoDataError.Empty);
	}

	public async Task<Result<SuggestionResult, DomainError>> SuggestGeocode(DeliveryAddress deliveryAddres, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.SuggestGeocode(t.Token, new SuggestGeocodeRequestDto(deliveryAddres.AddressLine, deliveryAddres.Coordinate, deliveryAddres.Uri), ct), TokenLevel.L80, cancellationToken)).Map((SuggestGeocodeResponseDto dto) => dto.ToModel(), (ServiceError error) => error.ToBaseDomainError()).EnsureNotNull(() => NoDataError.Empty);
	}

	public async Task<Result<SuggestionResult, DomainError>> SuggestGeocode(Coordinate coordinate, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel t) => _api.SuggestGeocode(t.Token, new SuggestGeocodeRequestDto(coordinate), ct), TokenLevel.L80, cancellationToken)).Map((SuggestGeocodeResponseDto dto) => dto.ToModel(), (ServiceError error) => error.ToBaseDomainError()).EnsureNotNull(() => NoDataError.Empty);
	}
}
