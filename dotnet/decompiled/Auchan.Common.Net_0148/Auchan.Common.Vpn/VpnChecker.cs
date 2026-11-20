using System;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Vpn;

public class VpnChecker : IVpnChecker
{
	private readonly IAdminContext _adminContext;

	private readonly IStoreService _storeService;

	private readonly Lazy<AppMetrica> _appMetrica;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	public VpnChecker(IAdminContext adminContext, IStoreService storeService, Lazy<AppMetrica> appMetrica, Lazy<IInfoMessageService> infoMessageService)
	{
		_adminContext = adminContext;
		_storeService = storeService;
		_appMetrica = appMetrica;
		_infoMessageService = infoMessageService;
	}

	public async Task<VpnState> GetVpnState()
	{
		Result<AppConfig, DomainError> result = await _adminContext.SyncAppConfig();
		if (result.IsSuccess)
		{
			if ((await _storeService.PrefetchCities()).TryGetValue(out var value))
			{
				return value.VpnState;
			}
		}
		else if (result.Error is DisableVpnError)
		{
			return VpnState.Block;
		}
		return VpnState.None;
	}

	public async Task<VpnState> VpnStateAtAppStart()
	{
		VpnState state = await Task.Run((Func<Task<VpnState>?>)GetVpnState);
		switch (state)
		{
		case VpnState.Block:
			await _infoMessageService.Value.ShowVpnScreenAsync(new VpnViewModel.Parameter(restartAppOnActionButton: true));
			break;
		case VpnState.Warning:
			_appMetrica.Value.TrackEvent("vpnAlert", ("viewScreen", "splashScreen"));
			_infoMessageService.Value.ShowSnackbar("Приложение будет работать быстрее и стабильнее, если отключить VPN", TimeSpan.FromSeconds(5L), SnackbarStyle.Warning);
			break;
		}
		return state;
	}

	public Task CheckAppConfigResultAndShowVpnScreenAsync(Result<AppConfig, DomainError> appConfigResult)
	{
		if (appConfigResult.IsFailure && appConfigResult.Error is DisableVpnError)
		{
			return _infoMessageService.Value.ShowVpnScreenAsync(new VpnViewModel.Parameter());
		}
		return Task.CompletedTask;
	}
}
