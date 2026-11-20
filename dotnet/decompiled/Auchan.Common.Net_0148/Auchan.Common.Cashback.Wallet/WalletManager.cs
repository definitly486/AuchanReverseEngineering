using System;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cashback.Wallet.DTO;
using Auchan.Common.Common;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices;

namespace Auchan.Common.Cashback.Wallet;

public class WalletManager : IWalletManager
{
	private readonly IWalletPassManager _walletPassManager;

	private readonly IWalletService _walletService;

	private readonly IDeviceService _deviceService;

	public WalletManager(IWalletPassManager walletPassManager, IWalletService walletService, IDeviceService deviceService)
	{
		_walletPassManager = walletPassManager;
		_walletService = walletService;
		_deviceService = deviceService;
	}

	public async Task<bool> CanAddLoyaltyQr()
	{
		if (DeviceInfo.Platform == DevicePlatform.Android && !_deviceService.IsHuawei)
		{
			Result<PassCheckAndroidDTO, DomainError> result = await _walletService.LoyaltyQrPassCheckAndroid();
			if (result.IsSuccess)
			{
				return result.Value.CanAdd;
			}
			return true;
		}
		if (DeviceInfo.Platform == DevicePlatform.iOS)
		{
			return await _walletPassManager.LoyaltyQrPassCheckiOS();
		}
		return false;
	}

	public async Task<bool> AddLoyaltyQr()
	{
		return await SaveToWallet(() => _walletService.LoyaltyQrPassAndroid(), () => _walletService.LoyaltyQrPassiOS());
	}

	public async Task<bool> AddCashbackQr()
	{
		return await SaveToWallet(() => _walletService.CashbackQrPassAndroid(), () => _walletService.CashbackQrPassiOS());
	}

	private async Task<bool> SaveToWallet(Func<Task<Result<PassAndroidDTO, DomainError>>> androidPassRequestFactory, Func<Task<Result<PassiOSDTO, DomainError>>> iOSPassRequestFactory)
	{
		bool added = false;
		if (DeviceInfo.Platform == DevicePlatform.Android)
		{
			Result<PassAndroidDTO, DomainError> result = await androidPassRequestFactory();
			if (result.IsSuccess && !string.IsNullOrEmpty(result.Value.AddUrl))
			{
				added = await _walletPassManager.AddPassAndroid(result.Value.AddUrl);
			}
		}
		else if (DeviceInfo.Platform == DevicePlatform.iOS)
		{
			Result<PassiOSDTO, DomainError> result2 = await iOSPassRequestFactory();
			if (result2.IsSuccess && result2.Value.FileStream != null)
			{
				added = await _walletPassManager.AddPassiOS(result2.Value.FileStream);
			}
		}
		return added;
	}
}
