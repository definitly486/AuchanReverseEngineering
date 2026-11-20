using System;
using Android.Graphics.Drawables;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Content;
using Auchan.Common.Analytics.YandexAppMetrica;
using InputMask;
using Java.Lang;
using Java.Lang.Reflect;

namespace Auchan.Android.Extensions;

public static class EditTextExtensions
{
	public static void InstallMaskedListener(this AppCompatEditText editText, string mask, ValueListener? valueListener)
	{
		MaskedTextChangedListener.Companion.InstallOn(editText, mask, valueListener);
	}

	public static void SetTextSelectHandleCompat(this EditText editText, int drawableId)
	{
		Drawable drawable = ContextCompat.GetDrawable(editText.Context, drawableId);
		try
		{
			if (OperatingSystem.IsAndroidVersionAtLeast(29))
			{
				editText.TextSelectHandle = drawable;
				editText.TextSelectHandleLeft = drawable;
				editText.TextSelectHandleRight = drawable;
				return;
			}
			Field declaredField = Class.FromType(typeof(TextView)).GetDeclaredField("mEditor");
			declaredField.Accessible = true;
			Java.Lang.Object obj = declaredField.Get(editText);
			Field declaredField2 = obj.Class.GetDeclaredField("mSelectHandleCenter");
			declaredField2.Accessible = true;
			declaredField2.Set(obj, drawable);
		}
		catch (System.Exception ex)
		{
			DevAnalytics.Report("Failed to set text select handle", ex);
		}
	}
}
