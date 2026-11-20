using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Tooltips;

[Register("auchan.TooltipDrawerView")]
public class TooltipDrawerView : View
{
	private readonly Rect _cacheRect = new Rect();

	private Paint _maskPaint;

	private Path _maskPath;

	private float _cornerRadius;

	public TooltipDrawerView(Context? context)
		: base(context)
	{
		Initialize(context, null);
	}

	public TooltipDrawerView(Context? context, IAttributeSet? attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public TooltipDrawerView(Context? context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	public TooltipDrawerView(Context? context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
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
		TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.TooltipDrawerView);
		Color color = typedArray.GetColor(1, 0);
		float dimension = typedArray.GetDimension(0, -1f);
		typedArray.Recycle();
		_cornerRadius = dimension;
		_maskPaint = new Paint(PaintFlags.AntiAlias)
		{
			Color = color
		};
		_maskPath = new Path();
	}

	public void DrawOverView(View view, float inset, float? customRadius, bool ignoreView = false)
	{
		view.GetGlobalVisibleRect(_cacheRect);
		RectF rectF = new RectF(_cacheRect);
		rectF.Inset(inset, inset);
		_maskPath.Reset();
		if (!ignoreView)
		{
			_maskPath.AddRoundRect(rectF, customRadius ?? _cornerRadius, customRadius ?? _cornerRadius, Path.Direction.Cw);
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
