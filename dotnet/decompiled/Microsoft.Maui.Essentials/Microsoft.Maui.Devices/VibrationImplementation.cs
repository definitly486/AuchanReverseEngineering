using System;
using Android.App;
using Android.OS;
using Microsoft.Maui.ApplicationModel;

namespace Microsoft.Maui.Devices;

internal class VibrationImplementation : IVibration
{
	private static Vibrator? vibrator;

	private static VibratorManager? VibratorManager
	{
		get
		{
			if (!OperatingSystem.IsAndroidVersionAtLeast(31))
			{
				return null;
			}
			return Application.Context.GetSystemService("vibrator_manager") as VibratorManager;
		}
	}

	private static Vibrator? VibratorManagerVibrator
	{
		get
		{
			if (!OperatingSystem.IsAndroidVersionAtLeast(31))
			{
				return null;
			}
			return VibratorManager?.DefaultVibrator;
		}
	}

	private static Vibrator? VibratorServiceVibrator => Application.Context.GetSystemService("vibrator") as Vibrator;

	private static Vibrator? Vibrator
	{
		get
		{
			object obj = vibrator;
			if (obj == null)
			{
				obj = VibratorManagerVibrator ?? VibratorServiceVibrator;
				vibrator = (Vibrator?)obj;
			}
			return (Vibrator?)obj;
		}
	}

	public bool IsSupported => true;

	public void Vibrate()
	{
		if (!IsSupported)
		{
			throw new FeatureNotSupportedException();
		}
		PlatformVibrate();
	}

	public void Vibrate(TimeSpan duration)
	{
		if (!IsSupported)
		{
			throw new FeatureNotSupportedException();
		}
		if (duration.TotalMilliseconds < 0.0)
		{
			duration = TimeSpan.Zero;
		}
		else if (duration.TotalSeconds > 5.0)
		{
			duration = TimeSpan.FromSeconds(5L);
		}
		PlatformVibrate(duration);
	}

	private void PlatformVibrate()
	{
		PlatformVibrate(TimeSpan.FromMilliseconds(500L, 0L));
	}

	private void PlatformVibrate(TimeSpan duration)
	{
		Permissions.EnsureDeclared<Permissions.Vibrate>();
		long num = (long)duration.TotalMilliseconds;
		if (num > 0)
		{
			if (OperatingSystem.IsAndroidVersionAtLeast(26))
			{
				Vibrator?.Vibrate(VibrationEffect.CreateOneShot(num, -1));
			}
			else
			{
				Vibrator?.Vibrate(num);
			}
		}
	}
}
