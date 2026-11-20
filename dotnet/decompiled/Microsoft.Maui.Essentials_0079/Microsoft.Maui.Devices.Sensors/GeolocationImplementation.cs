using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Locations;
using Android.OS;
using Microsoft.Maui.ApplicationModel;

namespace Microsoft.Maui.Devices.Sensors;

internal class GeolocationImplementation : IGeolocation
{
	private static readonly string[] ignoredProviders = new string[2] { "passive", "local_database" };

	private static LocationManager? LocationManager => Application.Context.GetSystemService("location") as LocationManager;

	public async Task<Location?> GetLastKnownLocationAsync()
	{
		if (LocationManager == null)
		{
			throw new FeatureNotSupportedException("Android LocationManager is not available");
		}
		await Permissions.EnsureGrantedOrRestrictedAsync<Permissions.LocationWhenInUse>();
		global::Android.Locations.Location location = null;
		foreach (string provider in LocationManager.GetProviders(enabledOnly: true))
		{
			global::Android.Locations.Location lastKnownLocation = LocationManager.GetLastKnownLocation(provider);
			if (lastKnownLocation != null && IsBetterLocation(lastKnownLocation, location))
			{
				location = lastKnownLocation;
			}
		}
		return location?.ToLocation();
	}

	public async Task<Location?> GetLocationAsync(GeolocationRequest request, CancellationToken cancellationToken)
	{
		ArgumentNullException.ThrowIfNull(request, "request");
		if (LocationManager == null)
		{
			throw new FeatureNotSupportedException("Android LocationManager is not available");
		}
		await Permissions.EnsureGrantedOrRestrictedAsync<Permissions.LocationWhenInUse>();
		IList<string> providers = LocationManager.GetProviders(enabledOnly: true);
		if (!providers.Any((string p) => !ignoredProviders.Contains(p)))
		{
			throw new FeatureNotEnabledException("Location services are not enabled on device.");
		}
		(string, float) bestProvider = GetBestProvider(LocationManager, request.DesiredAccuracy);
		if (string.IsNullOrEmpty(bestProvider.Item1))
		{
			return await GetLastKnownLocationAsync();
		}
		TaskCompletionSource<global::Android.Locations.Location?> tcs = new TaskCompletionSource<global::Android.Locations.Location>();
		IList<string> providers2 = LocationManager.GetProviders(enabledOnly: false);
		List<string> providers3 = new List<string>();
		if (providers2.Contains("gps"))
		{
			providers3.Add("gps");
		}
		if (providers2.Contains("network"))
		{
			providers3.Add("network");
		}
		if (providers3.Count == 0)
		{
			providers3.Add(bestProvider.Item1);
		}
		SingleLocationListener listener = new SingleLocationListener(LocationManager, bestProvider.Item2, providers3);
		listener.LocationHandler = HandleLocation;
		cancellationToken = Utils.TimeoutToken(cancellationToken, request.Timeout);
		cancellationToken.Register(Cancel);
		Looper looper = Looper.MyLooper() ?? Looper.MainLooper;
		foreach (string item in providers3)
		{
			LocationManager.RequestLocationUpdates(item, 0L, 0f, listener, looper);
		}
		return (await tcs.Task)?.ToLocation();
		void Cancel()
		{
			RemoveUpdates();
			tcs.TrySetResult(listener?.BestLocation);
		}
		void HandleLocation(global::Android.Locations.Location location)
		{
			RemoveUpdates();
			tcs.TrySetResult(location);
		}
		void RemoveUpdates()
		{
			if (LocationManager != null)
			{
				for (int i = 0; i < providers3.Count; i++)
				{
					LocationManager.RemoveUpdates(listener);
				}
			}
		}
	}

	private static (string? Provider, float Accuracy) GetBestProvider(LocationManager locationManager, GeolocationAccuracy accuracy)
	{
		Criteria criteria = new Criteria
		{
			BearingRequired = false,
			AltitudeRequired = false,
			SpeedRequired = false
		};
		int num = 100;
		switch (accuracy)
		{
		case GeolocationAccuracy.Lowest:
			criteria.Accuracy = Accuracy.NoRequirement;
			criteria.HorizontalAccuracy = Accuracy.NoRequirement;
			criteria.PowerRequirement = Power.NoRequirement;
			num = 500;
			break;
		case GeolocationAccuracy.Low:
			criteria.Accuracy = Accuracy.Coarse;
			criteria.HorizontalAccuracy = Accuracy.Fine;
			criteria.PowerRequirement = Power.Low;
			num = 500;
			break;
		case GeolocationAccuracy.Default:
		case GeolocationAccuracy.Medium:
			criteria.Accuracy = Accuracy.Coarse;
			criteria.HorizontalAccuracy = Accuracy.Coarse;
			criteria.PowerRequirement = Power.Medium;
			num = 250;
			break;
		case GeolocationAccuracy.High:
			criteria.Accuracy = Accuracy.Fine;
			criteria.HorizontalAccuracy = Accuracy.High;
			criteria.PowerRequirement = Power.High;
			num = 100;
			break;
		case GeolocationAccuracy.Best:
			criteria.Accuracy = Accuracy.Fine;
			criteria.HorizontalAccuracy = Accuracy.High;
			criteria.PowerRequirement = Power.High;
			num = 50;
			break;
		}
		string item = locationManager.GetBestProvider(criteria, enabledOnly: true) ?? locationManager.GetProviders(enabledOnly: true).FirstOrDefault();
		return (Provider: item, Accuracy: num);
	}

	internal static bool IsBetterLocation(global::Android.Locations.Location location, global::Android.Locations.Location? bestLocation)
	{
		if (bestLocation == null)
		{
			return true;
		}
		long num = location.Time - bestLocation.Time;
		bool flag = num > 120000;
		bool flag2 = num < -120000;
		bool flag3 = num > 0;
		if (flag)
		{
			return true;
		}
		if (flag2)
		{
			return false;
		}
		int num2 = (int)(location.Accuracy - bestLocation.Accuracy);
		bool flag4 = num2 > 0;
		bool flag5 = num2 < 0;
		bool flag6 = num2 > 200;
		bool valueOrDefault = location?.Provider?.Equals(bestLocation?.Provider, StringComparison.OrdinalIgnoreCase) == true;
		if (flag5)
		{
			return true;
		}
		if (flag3 && !flag4)
		{
			return true;
		}
		if (flag3 && !flag6 && valueOrDefault)
		{
			return true;
		}
		return false;
	}
}
