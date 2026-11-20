using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Cashback.Wallet.DTO;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Cashback.Wallet;

public class WalletService : IWalletService
{
	private readonly ITokenService _tokenService;

	private readonly IRequestExecutor _requestExecutor;

	private readonly IWalletApi _walletApi;

	private readonly IDeviceService _deviceService;

	public WalletService(IWalletApi walletApi, ITokenService tokenService, IRequestExecutor requestExecutor, IDeviceService deviceService)
	{
		_walletApi = walletApi;
		_tokenService = tokenService;
		_requestExecutor = requestExecutor;
		_deviceService = deviceService;
	}

	public async Task<Result<PassCheckAndroidDTO, DomainError>> LoyaltyQrPassCheckAndroid()
	{
		return await QrPassAndroidCheck((TokenModel tokenModel, string deviceId, CancellationToken cancellationToken) => _walletApi.LoyaltyQrPassCheckAndroid(tokenModel.Token, deviceId, cancellationToken));
	}

	public async Task<Result<PassAndroidDTO, DomainError>> CashbackQrPassAndroid()
	{
		return await QrPassAndroid((TokenModel tokenModel, string deviceId, CancellationToken cancellationToken) => _walletApi.CashbackQrPassAndroid(tokenModel.Token, cancellationToken));
	}

	public async Task<Result<PassAndroidDTO, DomainError>> LoyaltyQrPassAndroid()
	{
		return await QrPassAndroid((TokenModel tokenModel, string deviceId, CancellationToken cancellationToken) => _walletApi.LoyaltyQrPassAndroid(tokenModel.Token, deviceId, cancellationToken));
	}

	public async Task<Result<PassiOSDTO, DomainError>> CashbackQrPassiOS()
	{
		return await QrPassiOS((TokenModel tokenModel, CancellationToken cancellationToken) => _walletApi.CashbackQrPassiOS(tokenModel.Token, cancellationToken));
	}

	public async Task<Result<PassiOSDTO, DomainError>> LoyaltyQrPassiOS()
	{
		return await QrPassiOS((TokenModel tokenModel, CancellationToken cancellationToken) => _walletApi.LoyaltyQrPassiOS(tokenModel.Token, cancellationToken));
	}

	private async Task<Result<PassCheckAndroidDTO, DomainError>> QrPassAndroidCheck(Func<TokenModel, string, CancellationToken, Task<PassCheckAndroidDTO>> requestFactory)
	{
		Result<TokenModel, DomainError> token80 = await _tokenService.SavedToken80();
		if (token80.IsFailure)
		{
			return Result.Failure<PassCheckAndroidDTO, DomainError>(token80.Error);
		}
		return (await _requestExecutor.Execute((CancellationToken t) => requestFactory(token80.Value, _deviceService.Udid, t))).Ensure((PassCheckAndroidDTO x) => x != null, new UnknownServiceError()).Map((PassCheckAndroidDTO x) => x, (ServiceError x) => x.ToBaseDomainError());
	}

	private async Task<Result<PassAndroidDTO, DomainError>> QrPassAndroid(Func<TokenModel, string, CancellationToken, Task<PassAndroidDTO>> requestFactory)
	{
		Result<TokenModel, DomainError> token80 = await _tokenService.SavedToken80();
		if (token80.IsFailure)
		{
			return Result.Failure<PassAndroidDTO, DomainError>(token80.Error);
		}
		return (await _requestExecutor.Execute((CancellationToken t) => requestFactory(token80.Value, _deviceService.Udid, t))).Ensure((PassAndroidDTO x) => !string.IsNullOrEmpty(x?.AddUrl), new UnknownServiceError()).Map((PassAndroidDTO x) => x, (ServiceError x) => x.ToBaseDomainError());
	}

	private async Task<Result<PassiOSDTO, DomainError>> QrPassiOS(Func<TokenModel, CancellationToken, Task<HttpResponseMessage>> requestFactory)
	{
		Result<TokenModel, DomainError> token80 = await _tokenService.SavedToken80();
		if (token80.IsFailure)
		{
			return Result.Failure<PassiOSDTO, DomainError>(token80.Error);
		}
		return await (await _requestExecutor.Execute((CancellationToken t) => requestFactory(token80.Value, t))).Ensure((HttpResponseMessage x) => x.Content.Headers.ContentType?.MediaType?.Contains("vnd.apple.pkpass") == true, new UnknownServiceError()).MapAsync(async delegate(HttpResponseMessage x)
		{
			PassiOSDTO passiOSDTO = new PassiOSDTO();
			PassiOSDTO passiOSDTO2 = passiOSDTO;
			passiOSDTO2.FileStream = await x.Content.ReadAsStreamAsync();
			return passiOSDTO;
		}, (ServiceError x) => x.ToBaseDomainError());
	}
}
