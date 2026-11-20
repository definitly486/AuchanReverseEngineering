using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Common.Location;

public interface ILocationPermissionService
{
	Task<bool> IsForegroundPermissionGranted();

	Task<PermissionStatus> GetForegroundPermissionStatus();

	Task<PermissionStatus> RequestForegroundPermission();
}
