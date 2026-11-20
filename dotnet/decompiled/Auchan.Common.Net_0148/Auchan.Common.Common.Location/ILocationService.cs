using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Common.Location;

public interface ILocationService
{
	Task<double> GetDistanceFromLocationToPoint(Microsoft.Maui.Devices.Sensors.Location placeLocation, DistanceUnits distanceUnits);

	Task<Microsoft.Maui.Devices.Sensors.Location?> GetGeoPosition();

	Task<Microsoft.Maui.Devices.Sensors.Location> GetGeoPositionOrDefault();

	Microsoft.Maui.Devices.Sensors.Location GetDefaultPosition();

	Task<Result<Microsoft.Maui.Devices.Sensors.Location>> GetPositionSafe(GeolocationRequest request, CancellationToken token = default(CancellationToken));

	Microsoft.Maui.Devices.Sensors.Location GetMoscowLocation();
}
