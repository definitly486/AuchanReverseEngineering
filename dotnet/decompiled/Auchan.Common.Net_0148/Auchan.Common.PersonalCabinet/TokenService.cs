using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Cache;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet.DTO;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;
using Polly;
using Polly.Timeout;

namespace Auchan.Common.PersonalCabinet;

public class TokenService : ITokenService
{
	private readonly Lazy<IPersonalCabinetApi> _api;

	private readonly Lazy<IUserPersistence> _userPersistence;

	private readonly Lazy<IDeviceService> _device;

	private readonly Lazy<IEnvironmentManager> _environmentManager;

	private readonly SemaphoreSlim _semaphoreToken20 = new SemaphoreSlim(1);

	private readonly SemaphoreSlim _semaphoreToken80 = new SemaphoreSlim(1);

	public TokenService(Lazy<IPersonalCabinetApi> api, Lazy<IUserPersistence> userPersistence, IUserContext userContext, Lazy<IDeviceService> device, Lazy<IEnvironmentManager> environmentManager)
	{
		_api = api;
		_userPersistence = userPersistence;
		_device = device;
		_environmentManager = environmentManager;
		userContext.AfterLoggedOut += ClearTokens;
	}

	public async Task<Result<TokenModel, DomainError>> Token20()
	{
		await _semaphoreToken20.WaitAsync();
		try
		{
			string authorizationRoot = string.Empty;
			switch (_environmentManager.Value.CurrentEnvironment)
			{
			case Auchan.Common.Networking.Environment.Production:
				authorizationRoot = "LqX~A4gR";
				break;
			case Auchan.Common.Networking.Environment.Preprod:
			case Auchan.Common.Networking.Environment.Stage_1:
			case Auchan.Common.Networking.Environment.Stage_2:
			case Auchan.Common.Networking.Environment.Stage_3:
			case Auchan.Common.Networking.Environment.Stage_4:
			case Auchan.Common.Networking.Environment.Stage_5:
			case Auchan.Common.Networking.Environment.Stage_6:
			case Auchan.Common.Networking.Environment.Stage_7:
			case Auchan.Common.Networking.Environment.Stage_8:
			case Auchan.Common.Networking.Environment.Stage_9:
			case Auchan.Common.Networking.Environment.Stage_10:
			case Auchan.Common.Networking.Environment.Stage_11:
			case Auchan.Common.Networking.Environment.Stage_12:
			case Auchan.Common.Networking.Environment.Stage_13:
			case Auchan.Common.Networking.Environment.Stage_14:
			case Auchan.Common.Networking.Environment.Stage_15:
			case Auchan.Common.Networking.Environment.Stage_16:
			case Auchan.Common.Networking.Environment.Stage_17:
			case Auchan.Common.Networking.Environment.Stage_18:
			case Auchan.Common.Networking.Environment.Stage_19:
			case Auchan.Common.Networking.Environment.Stage_20:
			case Auchan.Common.Networking.Environment.Stage_21:
			case Auchan.Common.Networking.Environment.Stage_22:
			case Auchan.Common.Networking.Environment.Stage_23:
			case Auchan.Common.Networking.Environment.Stage_24:
			case Auchan.Common.Networking.Environment.Stage_25:
				authorizationRoot = "18snP%qT";
				break;
			}
			Result<TokenModel, DomainError> tokenFromApiResult = (await Policy.TimeoutAsync(10, TimeoutStrategy.Pessimistic).ExecuteAsync((CancellationToken t) => _api.Value.Token20(authorizationRoot), CancellationToken.None).CatchErrors()).Ensure((TokenDto dto) => dto.AccessToken != null, new ApiContractError()).Map((TokenDto dto) => new TokenModel(dto.AccessToken, TokenLevel.L20), (ServiceError err) => err.ToGetTokenError());
			if (tokenFromApiResult.IsSuccess)
			{
				await SaveToken(tokenFromApiResult.Value);
			}
			else
			{
				TokenModel tokenModel = await SavedToken(TokenLevel.L20);
				if (tokenModel != null)
				{
					return tokenModel;
				}
			}
			return tokenFromApiResult;
		}
		finally
		{
			_semaphoreToken20.Release();
		}
	}

	public async Task<Result<TokenModel, DomainError>> SavedToken80()
	{
		TokenModel value = await SavedToken(TokenLevel.L80);
		return Result.SuccessIf<TokenModel, DomainError>(value != null, in value, (DomainError)new MissingToken80Error());
	}

	public Task<Result<TokenModel, DomainError>> Token80ByPhone(string phone, string pin)
	{
		return Token80((CancellationToken t) => _api.Value.Token80(phone, pin, _device.Value.Udid, t));
	}

	private async Task<Result<TokenModel, DomainError>> Token80(Func<CancellationToken, Task<TokenDto>> requestFactory)
	{
		await _semaphoreToken80.WaitAsync();
		try
		{
			Result<TokenModel, DomainError> apiResult = (await Policy.TimeoutAsync(15).ExecuteAsync((CancellationToken t) => requestFactory(t).CatchErrors(), CancellationToken.None)).Ensure((TokenDto dto) => dto.AccessToken != null, new ApiContractError()).Map((TokenDto dto) => new TokenModel(dto.AccessToken, TokenLevel.L80), (ServiceError err) => err.ToGetTokenError());
			if (apiResult.IsSuccess)
			{
				await SaveToken(apiResult.Value);
			}
			return apiResult;
		}
		finally
		{
			_semaphoreToken80.Release();
		}
	}

	private Task<TokenModel?> SavedToken(TokenLevel tokenLevel)
	{
		return _userPersistence.Value.TryGet<TokenModel>(TokenPersistenceKey(tokenLevel));
	}

	public Task SaveToken(TokenModel tokenModel)
	{
		return _userPersistence.Value.Save(TokenPersistenceKey(tokenModel.TokenLevel), tokenModel);
	}

	private static string TokenPersistenceKey(TokenLevel tokenLevel)
	{
		return "PersonalCabinetToken_" + tokenLevel;
	}

	public async Task ClearTokens()
	{
		await _userPersistence.Value.Remove(Enum.GetValues<TokenLevel>().Select(TokenPersistenceKey).ToArray());
		_ = 1;
		await Task.Delay(1000);
	}
}
