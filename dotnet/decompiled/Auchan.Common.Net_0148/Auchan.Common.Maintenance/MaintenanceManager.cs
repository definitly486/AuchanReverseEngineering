using System;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.AppConfigError;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Vpn;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Maintenance;

public class MaintenanceManager : IMaintenanceManager, IApplicationStateObserver
{
	private const string LastWarningMessageTime = "last_warning_message_time";

	private readonly Lazy<IAdminContext> _adminContext;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	private readonly Lazy<IVpnChecker> _vpnChecker;

	private volatile TaskCompletionSource? _underMaintenanceTcs;

	private bool IsUnderMaintenance => _underMaintenanceTcs != null;

	public MaintenanceManager(Lazy<IAdminContext> adminContext, Lazy<IInfoMessageService> infoMessageService, Lazy<IVpnChecker> vpnChecker)
	{
		_adminContext = adminContext;
		_infoMessageService = infoMessageService;
		_vpnChecker = vpnChecker;
	}

	public void Start()
	{
		Preferences.Clear("last_warning_message_time");
	}

	public Task OnResumedAsync()
	{
		return CheckMaintenanceOnResume();
	}

	public async Task<bool> CheckMaintenance()
	{
		Result<AppConfig, DomainError> result = await _adminContext.Value.SyncAppConfig();
		if (result.IsSuccess && (result.Value.MaintenanceStatus == MaintenanceType.Disabled || result.Value.MaintenanceStatus == MaintenanceType.Warning))
		{
			SetMaintenanceCompleted();
			return false;
		}
		return true;
	}

	private async Task CheckMaintenanceOnResume()
	{
		if (IsUnderMaintenance)
		{
			return;
		}
		Result<AppConfig, DomainError> result = await _adminContext.Value.SyncAppConfig();
		await _vpnChecker.Value.CheckAppConfigResultAndShowVpnScreenAsync(result);
		if (!result.IsSuccess || result.Value.MaintenanceStatus == MaintenanceType.Disabled)
		{
			return;
		}
		if (result.Value.MaintenanceStatus == MaintenanceType.DelayedBlocking)
		{
			DateTime dateTime = Preferences.Get("last_user_activity_time", DateTime.MinValue);
			if (DateTime.UtcNow - dateTime > TimeSpan.FromMinutes(30L))
			{
				OnMaintenanceRequired();
			}
			return;
		}
		if (result.Value.MaintenanceStatus == MaintenanceType.InstantBlocking)
		{
			OnMaintenanceRequired();
			return;
		}
		DateTime dateTime2 = Preferences.Get("last_warning_message_time", DateTime.MinValue);
		if (DateTime.UtcNow - dateTime2 > TimeSpan.FromDays(1))
		{
			Preferences.Set("last_warning_message_time", DateTime.UtcNow);
			OnMaintenanceRequired();
		}
	}

	private void OnMaintenanceRequired()
	{
		Interlocked.CompareExchange(ref _underMaintenanceTcs, new TaskCompletionSource(), null);
		_infoMessageService.Value.ShowMaintenanceScreen(new MaintenanceViewModel.Parameter());
	}

	public Task WaitWhileInMaintenanceAsync()
	{
		return _underMaintenanceTcs?.Task ?? Task.CompletedTask;
	}

	private void SetMaintenanceCompleted()
	{
		Interlocked.Exchange(ref _underMaintenanceTcs, null)?.TrySetResult();
	}
}
