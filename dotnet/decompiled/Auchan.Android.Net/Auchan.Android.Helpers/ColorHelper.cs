using Android.Content;
using Android.Graphics;
using AndroidX.Core.Content;

namespace Auchan.Android.Helpers;

public static class ColorHelper
{
	public static Color FromId(Context context, int colorId)
	{
		return new Color(ContextCompat.GetColor(context, colorId));
	}
}
