using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Controls.DynamicShadows;

[Register("auchan.StaticShadowLayout")]
public class StaticShadowLayout : FrameLayout
{
	private Bitmap _staticShadowBitmap;

	private Paint _shadowPaint;

	private Rect _drawingRect;

	private int _paddingVertical;

	private int _paddingHorizontal;

	private float _offsetBottom;

	protected StaticShadowLayout(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public StaticShadowLayout(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public StaticShadowLayout(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public StaticShadowLayout(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs, defStyleAttr);
	}

	public StaticShadowLayout(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs, defStyleAttr, defStyleRes);
	}

	private void Initialize(Context context, IAttributeSet? attrs, int defStyleAttr = 0, int defStyleRes = 0)
	{
		SetClipChildren(clipChildren: false);
		SetClipToPadding(clipToPadding: false);
		SetWillNotDraw(willNotDraw: false);
		if (attrs == null)
		{
			throw new ArgumentNullException("attrs");
		}
		TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.StaticShadowLayout, defStyleAttr, defStyleRes);
		int resourceId = typedArray.GetResourceId(3, -1);
		_paddingVertical = typedArray.GetDimensionPixelSize(2, 0);
		_paddingHorizontal = typedArray.GetDimensionPixelSize(1, 0);
		_offsetBottom = typedArray.GetFloat(0, 0f);
		typedArray.Recycle();
		_staticShadowBitmap = BitmapFactory.DecodeResource(Resources, resourceId);
		_shadowPaint = new Paint(PaintFlags.FilterBitmap);
	}

	protected override void OnDraw(Canvas canvas)
	{
		if (_staticShadowBitmap != null && _drawingRect != null)
		{
			canvas.DrawBitmap(_staticShadowBitmap, null, _drawingRect, _shadowPaint);
		}
		base.OnDraw(canvas);
	}

	protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
	{
		base.OnSizeChanged(w, h, oldw, oldh);
		ComputeRect(w, h);
	}

	private void ComputeRect(int width, int height)
	{
		int left = base.Left + _paddingHorizontal;
		int top = base.Top + _paddingVertical;
		int right = base.Right - _paddingHorizontal;
		int bottom = base.Bottom - _paddingVertical + (int)((float)height * _offsetBottom);
		_drawingRect = new Rect(left, top, right, bottom);
	}
}
