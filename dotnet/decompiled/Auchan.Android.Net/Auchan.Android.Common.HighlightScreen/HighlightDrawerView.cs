using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace Auchan.Android.Common.HighlightScreen;

[Register("auchan.HighlightDrawerView")]
public class HighlightDrawerView : View
{
	private readonly Rect _cacheRect = new Rect();

	private Paint _maskPaint;

	private Path _maskPath;

	public HighlightDrawerView(Context context)
		: base(context)
	{
		Initialize(context, null);
	}

	public HighlightDrawerView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public HighlightDrawerView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public HighlightDrawerView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize(context, attrs);
	}

	private void Initialize(Context context, IAttributeSet attrs)
	{
		if (!IsHardwareAccelerated)
		{
			SetLayerType(LayerType.Software, null);
		}
		_maskPaint = new Paint(PaintFlags.AntiAlias)
		{
			Color = Color.Argb(153, 0, 0, 0)
		};
		_maskPath = new Path();
	}

	public void DrawOverViews(params (View view, float inset, float? customRadius)[] views)
	{
		_maskPath.Reset();
		for (int i = 0; i < views.Length; i++)
		{
			(View, float, float?) tuple = views[i];
			if (tuple.Item1.GetGlobalVisibleRect(_cacheRect))
			{
				int identifier = Resources.GetIdentifier("status_bar_height", "dimen", "android");
				int dimensionPixelSize = Resources.GetDimensionPixelSize(identifier);
				_cacheRect.Top -= dimensionPixelSize;
				_cacheRect.Bottom -= dimensionPixelSize;
				RectF rectF = new RectF(_cacheRect);
				rectF.Inset(tuple.Item2, tuple.Item2);
				_maskPath.AddRoundRect(rectF, tuple.Item3.GetValueOrDefault(), tuple.Item3.GetValueOrDefault(), Path.Direction.Cw);
			}
		}
		_maskPath.SetFillType(Path.FillType.InverseWinding);
		Invalidate();
	}

	protected override void OnDraw(Canvas canvas)
	{
		if (_maskPath != null)
		{
			canvas.DrawPath(_maskPath, _maskPaint);
		}
	}
}
