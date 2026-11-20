using Android.Graphics;
using Android.Widget;
using Google.Android.Material.TextField;

namespace Auchan.Android.Extensions;

public static class TextInputExtensions
{
	public static void SetError(this TextInputLayout textInputLayout, string error, bool isVisible)
	{
		if (isVisible)
		{
			if (!textInputLayout.ErrorEnabled || !(textInputLayout.Error == error))
			{
				textInputLayout.Error = null;
				textInputLayout.ErrorEnabled = true;
				textInputLayout.Error = error;
			}
		}
		else
		{
			textInputLayout.Error = null;
			textInputLayout.ErrorEnabled = false;
		}
	}

	public static void SetEndIconVisible(this TextInputLayout textInputLayout, bool isVisible)
	{
		textInputLayout.EndIconVisible = isVisible;
	}

	public static void SetErrorOrCorrect(this TextInputLayout textInputLayout, bool isCorrect, string str)
	{
		textInputLayout.Error = null;
		textInputLayout.ErrorEnabled = false;
		if (string.IsNullOrEmpty(str))
		{
			textInputLayout.EndIconVisible = false;
		}
		else
		{
			textInputLayout.EndIconVisible = isCorrect;
		}
	}

	public static void SetEnabledAlpha(this TextInputLayout textInputLayout, bool enabled)
	{
		textInputLayout.Alpha = (enabled ? 1f : 0.5f);
	}

	public static void RemoveRippleFromEndIcon(this TextInputLayout inputLayout)
	{
		inputLayout.RequireViewById<ImageButton>(2131298617).SetBackgroundColor(Color.Transparent);
	}
}
