using System;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet.DTO;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.PersonalCabinet;

public class PersonalCabinetService : IPersonalCabinetService
{
	private readonly Lazy<IPersonalCabinetApi> _api;

	private readonly Lazy<IRequestExecutor> _requestExecutor;

	private readonly Lazy<ILoymaxLoyaltyApi> _loymaxLoyaltyApi;

	public PersonalCabinetService(Lazy<IPersonalCabinetApi> api, Lazy<IRequestExecutor> requestExecutor, Lazy<ILoymaxLoyaltyApi> loymaxLoyaltyApi)
	{
		_api = api;
		_requestExecutor = requestExecutor;
		_loymaxLoyaltyApi = loymaxLoyaltyApi;
	}

	public async Task<Result<int, DomainError>> CheckPhone(string token20, string phone, string deviceid, bool needHash)
	{
		return (await _requestExecutor.Value.Execute((CancellationToken t) => _api.Value.CheckPhone(token20, phone, deviceid, needHash, t))).Map((CheckPhoneDto dto) => dto.Result, (ServiceError err) => err.ToCheckPhoneError());
	}

	public async Task<Result<ProfileModel, DomainError>> GetProfile(string token80)
	{
		return (await _requestExecutor.Value.Execute((CancellationToken t) => _loymaxLoyaltyApi.Value.GetProfile(token80, t))).Ensure((ProfileResponseSnackCaseDto p) => p != null, new ApiContractError()).Map((ProfileResponseSnackCaseDto dto) => dto.Profile.ToProfileModel(), (ServiceError err) => err.ToProfileByDeviceError());
	}

	public async Task<Result<SubscriptionsListModel, DomainError>> GetSubscriptionTypes(string token80)
	{
		return (await _requestExecutor.Value.Execute((CancellationToken t) => _api.Value.GetSubscriptions(token80, t))).Ensure((SubscriptionsListDto p) => p != null, new ApiContractError()).Map((SubscriptionsListDto dto) => dto.ToSubscriptionModel(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<ProfileModel, DomainError>> UpdateProfile(ProfileModel profileModel, string token80)
	{
		return (await _requestExecutor.Value.Execute((CancellationToken t) => _loymaxLoyaltyApi.Value.UpdateProfile(profileModel.ToProfileSnackCaseDto(), token80, t))).Map((ProfileResponseSnackCaseDto dto) => dto.Profile.ToProfileModel(), (ServiceError err) => err.ToUpdateProfileError());
	}

	public async Task<Result<Unit, DomainError>> BeginVerifyPhone(string token80, string phone, bool needHash)
	{
		return (await _requestExecutor.Value.Execute((CancellationToken t) => _api.Value.BeginVerifyPhone(token80, phone, needHash, t))).Map((BasePersonalCabinetResponseDto dto) => Unit.Default, (ServiceError err) => err.ToBeginVerifyPhoneError());
	}

	public async Task<Result<Unit, DomainError>> VerifyPhone(string token80, string phone, string pin)
	{
		return (await _requestExecutor.Value.Execute((CancellationToken t) => _api.Value.VerifyPhone(token80, phone, pin, t))).Map((BasePersonalCabinetResponseDto dto) => Unit.Default, (ServiceError err) => err.ToVerifyPhoneError());
	}

	public async Task<Result<Unit, DomainError>> Logout(string token80, bool forAll, string osType = "", string mobileType = "", string resolution = "")
	{
		return (await _requestExecutor.Value.Execute((CancellationToken t) => _api.Value.Logout(token80, forAll, osType, mobileType, resolution))).Map((LogoutResponseDto dto) => Unit.Default, (ServiceError err) => err.ToBaseDomainError());
	}
}
