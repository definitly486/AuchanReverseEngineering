using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom;
using Auchan.Common.Logs;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Common.Location;

public class LocationService : ILocationService
{
	private readonly ILogService _logService;

	private readonly IEcomContext _ecomContext;

	private readonly ILocationPermissionService _locationPermissionService;

	private readonly Microsoft.Maui.Devices.Sensors.Location MoscowCenterLocation = new Microsoft.Maui.Devices.Sensors.Location(55.751244, 37.618423);

	public LocationService(ILogService logService, IEcomContext ecomContext, ILocationPermissionService locationPermissionService)
	{
		_logService = logService;
		_ecomContext = ecomContext;
		_locationPermissionService = locationPermissionService;
	}

	public async Task<double> GetDistanceFromLocationToPoint(Microsoft.Maui.Devices.Sensors.Location placeLocation, DistanceUnits distanceUnits)
	{
		Microsoft.Maui.Devices.Sensors.Location location = await GetGeoPosition();
		return (location != null) ? Microsoft.Maui.Devices.Sensors.Location.CalculateDistance(location, placeLocation, distanceUnits) : (-1.0);
	}

	public async Task<Microsoft.Maui.Devices.Sensors.Location?> GetGeoPosition()
	{
		_ = 1;
		try
		{
			if (!(await _locationPermissionService.IsForegroundPermissionGranted()))
			{
				return null;
			}
			return await Geolocation.GetLastKnownLocationAsync();
		}
		catch (FeatureNotSupportedException)
		{
			_logService.LogError("GetLocation", "Запрос геопозиции не поддерживается", LogType.UserAction, SystemType.MobileApp);
		}
		catch (FeatureNotEnabledException)
		{
			_logService.LogError("GetLocation", "Запрос геопозиции не доступен", LogType.UserAction, SystemType.MobileApp);
		}
		catch (PermissionException)
		{
			_logService.LogError("GetLocation", "Нет разрешения на запрос геопозиции", LogType.UserAction, SystemType.MobileApp);
		}
		catch (Exception ex4)
		{
			_logService.LogError("GetLocation", ex4.ToString(), LogType.UserAction, SystemType.MobileApp);
		}
		return null;
	}

	public async Task<Microsoft.Maui.Devices.Sensors.Location> GetGeoPositionOrDefault()
	{
		Microsoft.Maui.Devices.Sensors.Location location = await GetGeoPosition();
		if (location != null)
		{
			return location;
		}
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		if (double.TryParse(_ecomContext?.DeliveryAddress?.Coordinate?.Lat.ToString("G20", invariantCulture), NumberStyles.Float, invariantCulture, out var result) && double.TryParse(_ecomContext?.DeliveryAddress?.Coordinate?.Lon.ToString("G20", invariantCulture), NumberStyles.Float, invariantCulture, out var result2))
		{
			return new Microsoft.Maui.Devices.Sensors.Location(result, result2);
		}
		return MoscowCenterLocation;
	}

	public async Task<Result<Microsoft.Maui.Devices.Sensors.Location>> GetPositionSafe(GeolocationRequest request, CancellationToken token)
	{
		_ = 1;
		try
		{
			Microsoft.Maui.Devices.Sensors.Location location = await Geolocation.GetLocationAsync(request, token);
			if ((object)location == null)
			{
				location = await Geolocation.GetLastKnownLocationAsync();
			}
			Microsoft.Maui.Devices.Sensors.Location location2 = location;
			if (location2 == null)
			{
				return Result.Failure<Microsoft.Maui.Devices.Sensors.Location>("Not available");
			}
			return Result.Success(location2);
		}
		catch (Exception ex)
		{
			return Result.Failure<Microsoft.Maui.Devices.Sensors.Location>(ex.ToString());
		}
	}

	public Microsoft.Maui.Devices.Sensors.Location GetMoscowLocation()
	{
		return MoscowCenterLocation;
	}

	public Microsoft.Maui.Devices.Sensors.Location GetDefaultPosition()
	{
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		if (double.TryParse(_ecomContext?.DeliveryAddress?.Coordinate?.Lat.ToString("G20", invariantCulture), NumberStyles.Float, invariantCulture, out var result) && double.TryParse(_ecomContext?.DeliveryAddress?.Coordinate?.Lon.ToString("G20", invariantCulture), NumberStyles.Float, invariantCulture, out var result2))
		{
			return new Microsoft.Maui.Devices.Sensors.Location(result, result2);
		}
		return MoscowCenterLocation;
	}
}
