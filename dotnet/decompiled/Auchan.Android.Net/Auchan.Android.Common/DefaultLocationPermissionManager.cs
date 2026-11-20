using System;
using System.Threading.Tasks;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Common;

public class DefaultLocationPermissionManager : BaseLocationPermissionManager
{
	private const string DisclosureText = "Разрешите доступ к вашему местоположению в любом режиме для поиска ближайшего магазина АШАН.\n\nПриложение будет использовать ваше местоположение в фоновом режиме.";

	private readonly IInfoMessageService _messageService;

	public DefaultLocationPermissionManager(IApplicationSettings applicationSettings, IInfoMessageService infoMessageService)
		: base(applicationSettings)
	{
		_messageService = infoMessageService;
	}

	protected override async Task<PermissionStatus> RequestInternal()
	{
		AlertButton alertButton = await _messageService.ShowAlertAsync(string.Empty, "Разрешите доступ к вашему местоположению в любом режиме для поиска ближайшего магазина АШАН.\n\nПриложение будет использовать ваше местоположение в фоновом режиме.", AlertButtons.YesNo);
		if (alertButton == null || alertButton.Type != ActionType.Positive)
		{
			return PermissionStatus.Denied;
		}
		if (OperatingSystem.IsAndroidVersionAtLeast(30) && await PermissionExtensions.RequestAsync<Permissions.LocationWhenInUse>() != PermissionStatus.Granted)
		{
			if (await PermissionExtensions.ShouldShowRationale<Permissions.LocationWhenInUse>())
			{
				await _messageService.ShowAlertAsync(string.Empty, "Разрешите доступ к вашему местоположению в любом режиме для поиска ближайшего магазина АШАН.\n\nПриложение будет использовать ваше местоположение в фоновом режиме.", new AlertButton[1] { AlertButtons.Settings });
			}
			return PermissionStatus.Denied;
		}
		PermissionStatus result = await PermissionExtensions.RequestAsync<Permissions.LocationAlways>();
		if (result != PermissionStatus.Granted)
		{
			result = await PermissionExtensions.CheckAsyncSafe<Permissions.LocationAlways>();
		}
		if (result != PermissionStatus.Granted && await PermissionExtensions.ShouldShowRationale<Permissions.LocationAlways>())
		{
			await _messageService.ShowAlertAsync(string.Empty, "Разрешите доступ к вашему местоположению в любом режиме для поиска ближайшего магазина АШАН.\n\nПриложение будет использовать ваше местоположение в фоновом режиме.", new AlertButton[1] { AlertButtons.Settings });
		}
		return result;
	}
}
