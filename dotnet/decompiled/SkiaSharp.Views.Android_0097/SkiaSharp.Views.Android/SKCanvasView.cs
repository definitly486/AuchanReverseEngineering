using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using _Microsoft.Android.Resource.Designer;

namespace SkiaSharp.Views.Android;

public class SKCanvasView : View
{
	private bool ignorePixelScaling;

	private bool designMode;

	private SurfaceFactory surfaceFactory;

	private float density;

	public SKSize CanvasSize { get; private set; }

	public bool IgnorePixelScaling
	{
		get
		{
			return ignorePixelScaling;
		}
		set
		{
			ignorePixelScaling = value;
			surfaceFactory.UpdateCanvasSize(base.Width, base.Height);
			Invalidate();
		}
	}

	public event EventHandler<SKPaintSurfaceEventArgs> PaintSurface;

	public SKCanvasView(Context context)
		: base(context)
	{
		Initialize();
	}

	public SKCanvasView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize(attrs);
	}

	public SKCanvasView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(attrs);
	}

	protected SKCanvasView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
		Initialize();
	}

	private void Initialize(IAttributeSet attrs = null)
	{
		designMode = !EnvironmentExtensions.IsValidEnvironment;
		surfaceFactory = new SurfaceFactory();
		density = Resources.DisplayMetrics.Density;
		if (attrs == null)
		{
			return;
		}
		using TypedArray typedArray = base.Context.ObtainStyledAttributes(attrs, Resource.Styleable.SKCanvasView);
		int indexCount = typedArray.IndexCount;
		for (int i = 0; i < indexCount; i++)
		{
			int index = typedArray.GetIndex(i);
			if (index == 0)
			{
				IgnorePixelScaling = typedArray.GetBoolean(index, defValue: false);
			}
		}
		typedArray.Recycle();
	}

	protected override void OnDraw(Canvas canvas)
	{
		base.OnDraw(canvas);
		if (designMode)
		{
			return;
		}
		if (Visibility != ViewStates.Visible)
		{
			surfaceFactory.FreeBitmap();
			return;
		}
		SKImageInfo info;
		SKSurface sKSurface = surfaceFactory.CreateSurface(out info);
		if (sKSurface == null)
		{
			CanvasSize = SKSize.Empty;
			return;
		}
		SKSizeI sKSizeI = (IgnorePixelScaling ? new SKSizeI((int)((float)info.Width / density), (int)((float)info.Height / density)) : info.Size);
		CanvasSize = sKSizeI;
		if (IgnorePixelScaling)
		{
			SKCanvas canvas2 = sKSurface.Canvas;
			canvas2.Scale(density);
			canvas2.Save();
		}
		OnPaintSurface(new SKPaintSurfaceEventArgs(sKSurface, info.WithSize(sKSizeI), info));
		surfaceFactory.DrawSurface(sKSurface, canvas);
	}

	protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
	{
		base.OnSizeChanged(w, h, oldw, oldh);
		surfaceFactory.UpdateCanvasSize(w, h);
	}

	protected virtual void OnPaintSurface(SKPaintSurfaceEventArgs e)
	{
		this.PaintSurface?.Invoke(this, e);
	}

	protected override void OnDetachedFromWindow()
	{
		surfaceFactory.Dispose();
		base.OnDetachedFromWindow();
	}

	protected override void OnAttachedToWindow()
	{
		base.OnAttachedToWindow();
		surfaceFactory.UpdateCanvasSize(base.Width, base.Height);
		Invalidate();
	}

	protected override void Dispose(bool disposing)
	{
		surfaceFactory.Dispose();
		base.Dispose(disposing);
	}
}
