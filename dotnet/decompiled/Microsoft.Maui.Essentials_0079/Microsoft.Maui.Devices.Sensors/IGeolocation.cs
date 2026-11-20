using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Maui.Devices.Sensors;

public interface IGeolocation
{
	Task<Location?> GetLastKnownLocationAsync();

	Task<Location?> GetLocationAsync(GeolocationRequest request, CancellationToken cancelToken);
}
