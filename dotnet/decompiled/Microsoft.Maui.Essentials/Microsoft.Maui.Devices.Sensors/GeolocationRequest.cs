using System;

namespace Microsoft.Maui.Devices.Sensors;

public class GeolocationRequest
{
	public TimeSpan Timeout { get; set; }

	public GeolocationAccuracy DesiredAccuracy { get; set; }

	public GeolocationRequest()
	{
		Timeout = TimeSpan.Zero;
		DesiredAccuracy = GeolocationAccuracy.Default;
	}

	public override string ToString()
	{
		return $"{"DesiredAccuracy"}: {DesiredAccuracy}, {"Timeout"}: {Timeout}";
	}
}
