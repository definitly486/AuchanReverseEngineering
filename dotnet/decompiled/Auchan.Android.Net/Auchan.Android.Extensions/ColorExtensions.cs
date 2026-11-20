using System.Drawing;
using Android.Content.Res;
using Android.Graphics;

namespace Auchan.Android.Extensions;

internal static class ColorExtensions
{
	public static global::Android.Graphics.Color ToColor(this System.Drawing.Color @this)
	{
		return new global::Android.Graphics.Color(@this.ToArgb());
	}

	public static ColorStateList ToColorStateList(this global::Android.Graphics.Color @this)
	{
		return ColorStateList.ValueOf(@this);
	}

	public static ColorStateList ToColorStateList(this System.Drawing.Color @this)
	{
		return @this.ToColor().ToColorStateList();
	}
}
