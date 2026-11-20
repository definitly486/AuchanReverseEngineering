using System;
using System.Collections.Generic;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Microsoft.Maui.Devices.Sensors;

internal class SingleLocationListener : Java.Lang.Object, ILocationListener, IJavaObject, IDisposable, IJavaPeerable
{
	private readonly object locationSync = new object();

	private float desiredAccuracy;

	private HashSet<string> activeProviders = new HashSet<string>();

	private bool wasRaised;

	internal global::Android.Locations.Location? BestLocation { get; set; }

	internal Action<global::Android.Locations.Location>? LocationHandler { get; set; }

	internal SingleLocationListener(LocationManager? manager, float desiredAccuracy, IEnumerable<string> activeProviders)
	{
		this.desiredAccuracy = desiredAccuracy;
		this.activeProviders = new HashSet<string>(activeProviders);
		foreach (string activeProvider in activeProviders)
		{
			global::Android.Locations.Location location = manager?.GetLastKnownLocation(activeProvider);
			if (location != null && GeolocationImplementation.IsBetterLocation(location, BestLocation))
			{
				BestLocation = location;
			}
		}
	}

	void ILocationListener.OnLocationChanged(global::Android.Locations.Location location)
	{
		if (location.Accuracy <= desiredAccuracy)
		{
			if (!wasRaised)
			{
				wasRaised = true;
				LocationHandler?.Invoke(location);
			}
			return;
		}
		lock (locationSync)
		{
			if (GeolocationImplementation.IsBetterLocation(location, BestLocation))
			{
				BestLocation = location;
			}
		}
	}

	void ILocationListener.OnProviderDisabled(string provider)
	{
		lock (activeProviders)
		{
			activeProviders.Remove(provider);
		}
	}

	void ILocationListener.OnProviderEnabled(string provider)
	{
		lock (activeProviders)
		{
			activeProviders.Add(provider);
		}
	}

	void ILocationListener.OnStatusChanged(string? provider, Availability status, Bundle? extras)
	{
		if (provider != null)
		{
			switch (status)
			{
			case Availability.Available:
				((ILocationListener)this).OnProviderEnabled(provider);
				break;
			case Availability.OutOfService:
				((ILocationListener)this).OnProviderDisabled(provider);
				break;
			}
		}
	}
}
