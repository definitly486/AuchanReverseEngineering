using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Maui.Devices.Sensors;

public static class Geolocation
{
	private static IGeolocation? defaultImplementation;

	private static IGeolocation Current => Default;

	public static IGeolocation Default => defaultImplementation ?? (defaultImplementation = new GeolocationImplementation());

	public static Task<Location?> GetLastKnownLocationAsync()
	{
		return Current.GetLastKnownLocationAsync();
	}

	public static Task<Location?> GetLocationAsync(GeolocationRequest request)
	{
		return Current.GetLocationAsync(request);
	}

	public static Task<Location?> GetLocationAsync(GeolocationRequest request, CancellationToken cancelToken)
	{
		return Current.GetLocationAsync(request, cancelToken);
	}
}
