using Android.Content;
using Android.Graphics;
using Android.Renderscripts;

namespace Auchan.Android.Controls.DynamicShadows;

public class RenderScriptBlur
{
	private readonly RenderScript _renderScript;

	private readonly ScriptIntrinsicBlur _blurScript;

	private Allocation _outAllocation;

	private int lastWidth;

	private int lastHeight;

	public RenderScriptBlur(Context context)
	{
		_renderScript = RenderScript.Create(context);
		_blurScript = ScriptIntrinsicBlur.Create(_renderScript, Element.U8_4(_renderScript));
	}

	public Bitmap Blur(Bitmap bitmap, float blurRadius)
	{
		Allocation allocation = Allocation.CreateFromBitmap(_renderScript, bitmap);
		if (!CanReuseAllocation(bitmap))
		{
			_outAllocation?.Destroy();
			_outAllocation = Allocation.CreateTyped(_renderScript, allocation.Type);
			lastWidth = bitmap.Width;
			lastHeight = bitmap.Height;
		}
		_blurScript.SetRadius(blurRadius);
		_blurScript.SetInput(allocation);
		_blurScript.ForEach(_outAllocation);
		_outAllocation.CopyTo(bitmap);
		allocation.Destroy();
		return bitmap;
	}

	private bool CanReuseAllocation(Bitmap bitmap)
	{
		if (bitmap.Width == lastWidth)
		{
			return bitmap.Height == lastHeight;
		}
		return false;
	}
}
