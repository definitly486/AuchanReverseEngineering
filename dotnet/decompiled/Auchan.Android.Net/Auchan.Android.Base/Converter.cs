using System;
using System.Collections.Generic;
using System.Drawing;
using Android.App;
using Android.Views;

namespace Auchan.Android.Base;

internal static class Converter
{
	[Obsolete("Use BoolToVisibilityExtensions.ToVisibility", true)]
	public static ViewStates BoolToVisible(bool value)
	{
		if (!value)
		{
			return ViewStates.Gone;
		}
		return ViewStates.Visible;
	}

	public static bool VisibilityToBool(ViewStates value)
	{
		switch (value)
		{
		case ViewStates.Gone:
			return false;
		case ViewStates.Visible:
			return true;
		case ViewStates.Invisible:
			return false;
		default:
		{
			global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(value);
			bool result = default(bool);
			return result;
		}
		}
	}

	public static ViewStates BoolToVisible(bool? value)
	{
		if (!value.HasValue || !value.Value)
		{
			return ViewStates.Gone;
		}
		return ViewStates.Visible;
	}

	public static ViewStates BoolToInvisibleVisibility(bool value)
	{
		if (!value)
		{
			return ViewStates.Invisible;
		}
		return ViewStates.Visible;
	}

	public static int BoolToInts(bool value, int positiveInt, int negativeInt)
	{
		if (!value)
		{
			return negativeInt;
		}
		return positiveInt;
	}

	public static ViewStates EnumToVisible<TEnum>(TEnum value, TEnum visibleFlag) where TEnum : Enum
	{
		if (!EqualityComparer<TEnum>.Default.Equals(value, visibleFlag))
		{
			return ViewStates.Gone;
		}
		return ViewStates.Visible;
	}

	public static ViewStates StringToVisibility(string value)
	{
		if (!string.IsNullOrWhiteSpace(value))
		{
			return ViewStates.Visible;
		}
		return ViewStates.Gone;
	}

	public static int SpToPx(float spValue)
	{
		float scaledDensity = Application.Context.Resources.DisplayMetrics.ScaledDensity;
		return (int)(spValue * scaledDensity + 0.5f);
	}

	public static int DpToPx(float dpValue)
	{
		float density = Application.Context.Resources.DisplayMetrics.Density;
		return (int)(dpValue * density + 0.5f);
	}

	public static int PxToDp(float pxValue)
	{
		return (int)(pxValue / Application.Context.Resources.DisplayMetrics.Density);
	}

	public static Size DpToPx(this Size @this)
	{
		return new Size(DpToPx(@this.Width), DpToPx(@this.Height));
	}
}
