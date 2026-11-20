using Android.Views;
using Auchan.Android.Base;

namespace Auchan.Android.Extensions;

public static class BoolToVisibilityExtensions
{
	public static ViewStates ToVisibility(this bool value)
	{
		if (!value)
		{
			return ViewStates.Gone;
		}
		return ViewStates.Visible;
	}

	public static ViewStates ToInvisibleVisibility(this bool value)
	{
		return Converter.BoolToInvisibleVisibility(value);
	}

	public static ViewStates ToVisibility(this object? value)
	{
		return (value != null).ToVisibility();
	}

	public static ViewStates ToInvisibleVisibility(this object? value)
	{
		return (value != null).ToInvisibleVisibility();
	}

	public static ViewStates ToVisibility<T>(this T? value) where T : struct
	{
		return value.HasValue.ToVisibility();
	}

	public static ViewStates ToInvisibleVisibility<T>(this T? value) where T : struct
	{
		return value.HasValue.ToInvisibleVisibility();
	}
}
