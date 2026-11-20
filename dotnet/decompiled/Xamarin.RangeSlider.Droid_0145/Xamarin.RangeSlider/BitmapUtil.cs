using Android.Graphics;
using Android.Graphics.Drawables;

namespace Xamarin.RangeSlider;

public class BitmapUtil
{
	public static Bitmap DrawableToBitmap(Drawable drawable)
	{
		if (drawable is BitmapDrawable)
		{
			return ((BitmapDrawable)drawable).Bitmap;
		}
		int num = ((!drawable.Bounds.IsEmpty) ? drawable.Bounds.Width() : drawable.IntrinsicWidth);
		int num2 = ((!drawable.Bounds.IsEmpty) ? drawable.Bounds.Height() : drawable.IntrinsicHeight);
		Bitmap bitmap = Bitmap.CreateBitmap((num <= 0) ? 1 : num, (num2 <= 0) ? 1 : num2, Bitmap.Config.Argb8888);
		Canvas canvas = new Canvas(bitmap);
		drawable.SetBounds(0, 0, canvas.Width, canvas.Height);
		drawable.Draw(canvas);
		return bitmap;
	}
}
