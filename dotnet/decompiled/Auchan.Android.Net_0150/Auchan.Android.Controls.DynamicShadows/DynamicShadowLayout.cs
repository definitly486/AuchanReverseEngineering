using System;
using System.Runtime.Versioning;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Controls.DynamicShadows;

[Register("auchan.DynamicShadowLayout")]
public class DynamicShadowLayout : FrameLayout
{
	private const int ROUNDING_VALUE = 64;

	private const float SCALE_FACTOR = 16f;

	private float _roundingWidthScaleFactor = 1f;

	private float _roundingHeightScaleFactor = 1f;

	private Bitmap _bitmap;

	private Canvas _canvas;

	private Paint _paint;

	private float _shadowDx;

	private float _shadowDy;

	private float _blurRadius = 25f;

	private int _shadowAlpha = 255;

	private RenderScriptBlur renderScript;

	protected DynamicShadowLayout(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public DynamicShadowLayout(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public DynamicShadowLayout(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public DynamicShadowLayout(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs, defStyleAttr);
	}

	public DynamicShadowLayout(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs, defStyleAttr, defStyleRes);
	}

	private void Initialize(Context context, IAttributeSet? attrs, int defStyleAttr = 0, int defStyleRes = 0)
	{
		if (attrs != null)
		{
			TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.DynamicShadowLayout, defStyleAttr, defStyleRes);
			_shadowDx = typedArray.GetDimensionPixelSize(1, 0);
			_shadowDy = typedArray.GetDimensionPixelSize(2, 0);
			_blurRadius = typedArray.GetDimensionPixelSize(3, 25);
			_shadowAlpha = typedArray.GetInt(0, 255);
			typedArray.Recycle();
		}
		_blurRadius = Math.Clamp(_blurRadius, 0f, 25f);
		SetClipChildren(clipChildren: false);
		SetClipToPadding(clipToPadding: false);
		SetWillNotDraw(willNotDraw: false);
		_canvas = new Canvas();
		_paint = new Paint(PaintFlags.FilterBitmap)
		{
			Alpha = _shadowAlpha
		};
		renderScript = new RenderScriptBlur(context);
	}

	protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
	{
		base.OnSizeChanged(w, h, oldw, oldh);
		_bitmap = AllocateBitmap(w, h);
		_canvas.SetBitmap(_bitmap);
	}

	protected override void OnDraw(Canvas canvas)
	{
		BlurChild(GetChildAt(0));
		DrawShadow(canvas);
		base.OnDraw(canvas);
	}

	[SupportedOSPlatform("android26.0")]
	public override void OnDescendantInvalidated(View child, View target)
	{
		base.OnDescendantInvalidated(child, target);
		BlurChild(child);
	}

	[Obsolete("deprecated")]
	public override IViewParent InvalidateChildInParent(int[] location, Rect dirty)
	{
		BlurChild(GetChildAt(0));
		return base.InvalidateChildInParent(location, dirty);
	}

	private Bitmap AllocateBitmap(int measuredWidth, int measuredHeight)
	{
		int num = DownscaleSize(measuredWidth);
		int num2 = DownscaleSize(measuredHeight);
		int num3 = RoundSize(num);
		int num4 = RoundSize(num2);
		_roundingHeightScaleFactor = (float)num2 / (float)num4;
		_roundingWidthScaleFactor = (float)num / (float)num3;
		return Bitmap.CreateBitmap(num3 + (int)_blurRadius * 2, num4 + (int)_blurRadius * 2, Bitmap.Config.Argb8888);
	}

	private void BlurChild(View child)
	{
		_canvas.Save();
		_bitmap.EraseColor(0);
		SetCanvasMatrix();
		child.Draw(_canvas);
		_canvas.Restore();
		_bitmap = renderScript.Blur(_bitmap, _blurRadius);
	}

	private void SetCanvasMatrix()
	{
		float num = 16f * _roundingWidthScaleFactor;
		float num2 = 16f * _roundingHeightScaleFactor;
		_canvas.Translate(_blurRadius, _blurRadius);
		_canvas.Scale(1f / num, 1f / num2);
	}

	private void DrawShadow(Canvas canvas)
	{
		canvas.Save();
		canvas.Translate(_shadowDx, _shadowDy);
		canvas.Scale(16f * _roundingWidthScaleFactor, 16f * _roundingHeightScaleFactor);
		canvas.Translate(0f - _blurRadius, 0f - _blurRadius);
		canvas.DrawBitmap(_bitmap, 0f, 0f, _paint);
		canvas.Restore();
	}

	private static int DownscaleSize(float value)
	{
		return (int)MathF.Ceiling(value / 16f);
	}

	private static int RoundSize(int value)
	{
		if (value % 64 == 0)
		{
			return value;
		}
		return value - value % 64 + 64;
	}
}
