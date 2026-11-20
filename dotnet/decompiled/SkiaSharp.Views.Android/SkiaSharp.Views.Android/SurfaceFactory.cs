using System;
using Android.Graphics;

namespace SkiaSharp.Views.Android;

internal class SurfaceFactory : IDisposable
{
	private Bitmap bitmap;

	public SKImageInfo Info { get; private set; }

	public void UpdateCanvasSize(int w, int h, float density = 1f)
	{
		if (density != 1f)
		{
			Info = CreateInfo((int)((float)w / density), (int)((float)h / density));
		}
		else
		{
			Info = CreateInfo(w, h);
		}
		if (Info.Width == 0 || Info.Height == 0)
		{
			FreeBitmap();
		}
	}

	public SKSurface CreateSurface(out SKImageInfo info)
	{
		info = Info;
		if (info.Width == 0 || info.Height == 0)
		{
			Dispose();
			return null;
		}
		if (bitmap?.Handle == IntPtr.Zero || bitmap?.Width != info.Width || bitmap?.Height != info.Height)
		{
			FreeBitmap();
		}
		if (bitmap == null)
		{
			bitmap = Bitmap.CreateBitmap(info.Width, info.Height, Bitmap.Config.Argb8888);
		}
		return SKSurface.Create(info, bitmap.LockPixels(), info.RowBytes);
	}

	public void DrawSurface(SKSurface surface, Canvas canvas)
	{
		surface.Canvas.Flush();
		surface.Dispose();
		bitmap.UnlockPixels();
		Rect src = new Rect(0, 0, Info.Width, Info.Height);
		RectF dst = new RectF(0f, 0f, canvas.Width, canvas.Height);
		canvas.DrawBitmap(bitmap, src, dst, null);
	}

	public void Dispose()
	{
		FreeBitmap();
		Info = CreateInfo(0, 0);
	}

	public void FreeBitmap()
	{
		if (bitmap != null)
		{
			if (bitmap.Handle != IntPtr.Zero && !bitmap.IsRecycled)
			{
				bitmap.Recycle();
			}
			bitmap.Dispose();
			bitmap = null;
		}
	}

	private SKImageInfo CreateInfo(int width, int height)
	{
		return new SKImageInfo(width, height, SKColorType.Rgba8888, SKAlphaType.Premul);
	}
}
