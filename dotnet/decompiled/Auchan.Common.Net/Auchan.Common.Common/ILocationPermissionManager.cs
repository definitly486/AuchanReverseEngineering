using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Common;

public interface ILocationPermissionManager
{
	Task<PermissionStatus> RequestBackgroundPermission();
}
