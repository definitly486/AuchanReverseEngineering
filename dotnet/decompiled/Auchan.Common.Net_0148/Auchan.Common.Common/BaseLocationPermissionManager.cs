using System.Threading.Tasks;
using Auchan.Common.Extensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Common;

public abstract class BaseLocationPermissionManager : ILocationPermissionManager
{
	private readonly IApplicationSettings _applicationSettings;

	protected BaseLocationPermissionManager(IApplicationSettings applicationSettings)
	{
		_applicationSettings = applicationSettings;
	}

	public async Task<PermissionStatus> RequestBackgroundPermission()
	{
		PermissionStatus permissionStatus = await PermissionExtensions.CheckAsyncSafe<Permissions.LocationAlways>();
		if (permissionStatus != PermissionStatus.Granted && !_applicationSettings.IsLocationDialogShown)
		{
			_applicationSettings.IsLocationDialogShown = true;
			return await RequestInternal();
		}
		return permissionStatus;
	}

	protected abstract Task<PermissionStatus> RequestInternal();
}
