using System;
using Android.Content;
using Android.Util;

namespace SkiaSharp.Views.Android;

public class SKGLTextureView : GLTextureView
{
	private class InternalRenderer : SKGLTextureViewRenderer
	{
		private readonly SKGLTextureView textureView;

		public InternalRenderer(SKGLTextureView textureView)
		{
			this.textureView = textureView;
		}

		protected override void OnPaintSurface(SKPaintGLSurfaceEventArgs e)
		{
			textureView.OnPaintSurface(e);
		}
	}

	private SKGLTextureViewRenderer renderer;

	public SKSize CanvasSize => renderer.CanvasSize;

	public GRContext GRContext => renderer.GRContext;

	public event EventHandler<SKPaintGLSurfaceEventArgs> PaintSurface;

	public SKGLTextureView(Context context)
		: base(context)
	{
		Initialize();
	}

	public SKGLTextureView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize();
	}

	private void Initialize()
	{
		SetEGLContextClientVersion(2);
		SetEGLConfigChooser(8, 8, 8, 8, 0, 8);
		renderer = new InternalRenderer(this);
		SetRenderer(renderer);
	}

	protected virtual void OnPaintSurface(SKPaintGLSurfaceEventArgs e)
	{
		this.PaintSurface?.Invoke(this, e);
	}
}
