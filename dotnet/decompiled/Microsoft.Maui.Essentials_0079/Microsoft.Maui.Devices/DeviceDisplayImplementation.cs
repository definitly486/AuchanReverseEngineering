using System;
using Android.App;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Lang;

namespace Microsoft.Maui.Devices;

internal sealed class DeviceDisplayImplementation : DeviceDisplayImplementationBase
{
	protected override DisplayInfo GetMainDisplayInfo()
	{
		using DisplayMetrics displayMetrics = new DisplayMetrics();
		Display defaultDisplay = GetDefaultDisplay();
		defaultDisplay?.GetRealMetrics(displayMetrics);
		return new DisplayInfo(displayMetrics?.WidthPixels ?? 0, displayMetrics?.HeightPixels ?? 0, displayMetrics?.Density ?? 1f, CalculateOrientation(), CalculateRotation(defaultDisplay), defaultDisplay?.RefreshRate ?? 0f);
	}

	private static DisplayRotation CalculateRotation(Display? display)
	{
		return display?.Rotation switch
		{
			SurfaceOrientation.Rotation270 => DisplayRotation.Rotation270, 
			SurfaceOrientation.Rotation180 => DisplayRotation.Rotation180, 
			SurfaceOrientation.Rotation90 => DisplayRotation.Rotation90, 
			SurfaceOrientation.Rotation0 => DisplayRotation.Rotation0, 
			_ => DisplayRotation.Unknown, 
		};
	}

	private static DisplayOrientation CalculateOrientation()
	{
		return Application.Context.Resources?.Configuration?.Orientation switch
		{
			Orientation.Landscape => DisplayOrientation.Landscape, 
			Orientation.Portrait => DisplayOrientation.Portrait, 
			Orientation.Square => DisplayOrientation.Portrait, 
			_ => DisplayOrientation.Unknown, 
		};
	}

	private static Display? GetDefaultDisplay()
	{
		try
		{
			using Java.Lang.Object obj = Application.Context.GetSystemService("window");
			using IWindowManager windowManager = ((obj != null) ? obj.JavaCast<IWindowManager>() : null);
			return windowManager?.DefaultDisplay;
		}
		catch (System.Exception)
		{
			return null;
		}
	}
}
