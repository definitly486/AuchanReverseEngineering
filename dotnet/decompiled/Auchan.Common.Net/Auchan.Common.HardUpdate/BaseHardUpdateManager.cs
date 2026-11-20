using System;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.HardUpdate;

public class BaseHardUpdateManager : IHardUpdateManager, IApplicationStateObserver
{
	private readonly Lazy<IAdminContext> _adminContext;

	public BaseHardUpdateManager(Lazy<IAdminContext> adminContext)
	{
		_adminContext = adminContext;
	}

	public async Task OnResumedAsync()
	{
		DateTime dateTime = Preferences.Get("last_user_activity_time", DateTime.MinValue);
		if (!(DateTime.UtcNow - dateTime < TimeSpan.FromMinutes(30L)))
		{
			await CheckHardUpdate();
		}
	}

	public virtual void OnHardUpdateRequired(HardUpdateViewModel.Parameter parameter)
	{
	}

	public async Task<Result<AppConfig, DomainError>> CheckHardUpdate()
	{
		Result<AppConfig, DomainError> result = await _adminContext.Value.SyncAppConfig();
		if (result.IsFailure && result.Error is UpdateRequiredError updateRequiredError)
		{
			OnHardUpdateRequired(new HardUpdateViewModel.Parameter(updateRequiredError.Message));
		}
		return result;
	}
}
