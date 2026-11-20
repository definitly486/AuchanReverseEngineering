using System.Reactive;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.PersonalCabinet.Interactors;

public class PinInteractor
{
	private readonly ITokenService _tokenService;

	private readonly IUserContext _userContext;

	private readonly IPersonalCabinetService _personalCabinetService;

	private readonly ProfileInteractor _profileInteractor;

	private readonly IDeviceService _deviceService;

	public PinInteractor(ITokenService tokenService, IUserContext userContext, IPersonalCabinetService personalCabinetService, ProfileInteractor profileInteractor, IDeviceService deviceService)
	{
		_tokenService = tokenService;
		_userContext = userContext;
		_personalCabinetService = personalCabinetService;
		_profileInteractor = profileInteractor;
		_deviceService = deviceService;
		_userContext.AfterLoggedIn += AfterLoggedIn;
	}

	public async Task<Result<int, DomainError>> SendPin(string phone, bool needHash)
	{
		Result<TokenModel, DomainError> result = await _tokenService.Token20();
		if (result.IsFailure)
		{
			return Result.Failure<int, DomainError>(result.Error);
		}
		Result<int, DomainError> result2 = await _personalCabinetService.CheckPhone(result.Value.Token, phone, _deviceService.Udid, needHash);
		if (result2.IsFailure)
		{
			return Result.Failure<int, DomainError>(result2.Error);
		}
		_userContext.PhoneStatus = result2.Value;
		_userContext.IsJustRegistered = _userContext.PhoneStatus == 1;
		return result2.Value;
	}

	public async Task<Result<PhoneStatus, DomainError>> VerifyPin(string token80)
	{
		Result<ProfileModel, DomainError> result = await _profileInteractor.GetProfile(token80);
		if (result.IsFailure)
		{
			return Result.Failure<PhoneStatus, DomainError>(result.Error);
		}
		return (!string.IsNullOrEmpty(result.Value.FirstName)) ? PhoneStatus.Registered : PhoneStatus.New;
	}

	public async Task<Result<Unit, DomainError>> BeginVerifyPhone(string phone, string token80, bool needHash)
	{
		return await _personalCabinetService.BeginVerifyPhone(token80, phone, needHash);
	}

	public async Task<Result<Unit, DomainError>> VerifyPhone(string phone, string pin)
	{
		Result<TokenModel, DomainError> result = await _tokenService.SavedToken80();
		if (result.IsFailure)
		{
			return Result.Failure<Unit, DomainError>(result.Error);
		}
		Result<Unit, DomainError> verifyResult = await _personalCabinetService.VerifyPhone(result.Value.Token, phone, pin);
		if (verifyResult.IsSuccess)
		{
			await _userContext.LogIn();
		}
		return verifyResult;
	}

	public async Task<Result<Unit, DomainError>> VerifyPhoneNumber(string phone, string pin)
	{
		var (_, flag3, tokenModel2, error) = await _tokenService.SavedToken80();
		if (flag3)
		{
			return Result.Failure<Unit, DomainError>(error);
		}
		return await _personalCabinetService.VerifyPhone(tokenModel2.Token, phone, pin);
	}

	private async Task AfterLoggedIn()
	{
		await _profileInteractor.SyncProfile();
	}
}
