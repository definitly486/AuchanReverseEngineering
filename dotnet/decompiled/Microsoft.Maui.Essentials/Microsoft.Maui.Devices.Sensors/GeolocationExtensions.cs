using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Maui.Devices.Sensors;

public static class GeolocationExtensions
{
	public static Task<Location?> GetLocationAsync(this IGeolocation geolocation, GeolocationRequest request)
	{
		return geolocation.GetLocationAsync(request ?? new GeolocationRequest(), default(CancellationToken));
	}
}
