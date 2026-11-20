using System;

namespace Microsoft.Maui.Devices;

public interface IVibration
{
	void Vibrate();

	void Vibrate(TimeSpan duration);
}
