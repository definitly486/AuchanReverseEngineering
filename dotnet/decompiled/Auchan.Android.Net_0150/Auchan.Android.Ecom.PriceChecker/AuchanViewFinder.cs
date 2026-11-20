using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Auchan.Android.Base;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Ecom.PriceChecker;

public sealed class AuchanViewFinder : View
{
	private Rect? _framingRect;

	private readonly Paint? _maskPaint;

	private readonly Path? _maskPath;

	private readonly int _maskCornerRadius;

	private readonly Paint? _focusPaint;

	private readonly Path? _focusPath;

	private readonly float _focusOffset;

	private readonly float _focusStrokeWidth;

	public Color FocusColor
	{
		get
		{
			return _focusPaint.Color;
		}
		set
		{
			_focusPaint.Color = value;
			Invalidate();
		}
	}

	public AuchanViewFinder(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public AuchanViewFinder(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		if (!IsHardwareAccelerated)
		{
			SetLayerType(LayerType.Software, null);
		}
		TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.AuchanBarcodeView);
		_maskCornerRadius = typedArray.GetDimensionPixelSize(0, 0);
		_focusStrokeWidth = typedArray.GetDimensionPixelSize(1, 0);
		int argb = typedArray.GetColor(5, 0);
		typedArray.Recycle();
		_focusOffset = Converter.DpToPx(50f);
		_maskPaint = new Paint(PaintFlags.AntiAlias)
		{
			Color = new Color(argb)
		};
		_focusPaint = new Paint(PaintFlags.AntiAlias)
		{
			Color = Color.White,
			StrokeWidth = _focusStrokeWidth
		};
		_focusPaint.SetStyle(Paint.Style.Stroke);
		_maskPath = new Path();
		_focusPath = new Path();
		_focusPaint.SetPathEffect(new CornerPathEffect(_maskCornerRadius));
	}

	protected override void OnDraw(Canvas canvas)
	{
		if (_framingRect != null)
		{
			canvas.DrawPath(_maskPath, _maskPaint);
			canvas.DrawPath(_focusPath, _focusPaint);
		}
	}

	public void SetFramingRect(Rect rect)
	{
		_framingRect = rect;
		Compute();
		Invalidate();
	}

	private void Compute()
	{
		_maskPath.Reset();
		_focusPath.Reset();
		RectF rect = new RectF(_framingRect);
		_maskPath.AddRoundRect(rect, _maskCornerRadius, _maskCornerRadius, Path.Direction.Cw);
		_maskPath.SetFillType(Path.FillType.InverseWinding);
		BuildCurve(_framingRect.Left, (float)_framingRect.Top + _focusOffset, _framingRect.Left, _framingRect.Top, (float)_framingRect.Left + _focusOffset, _framingRect.Top);
		BuildCurve((float)_framingRect.Right - _focusOffset, _framingRect.Top, _framingRect.Right, _framingRect.Top, _framingRect.Right, (float)_framingRect.Top + _focusOffset);
		BuildCurve(_framingRect.Left, (float)_framingRect.Bottom - _focusOffset, _framingRect.Left, _framingRect.Bottom, (float)_framingRect.Left + _focusOffset, _framingRect.Bottom);
		BuildCurve((float)_framingRect.Right - _focusOffset, _framingRect.Bottom, _framingRect.Right, _framingRect.Bottom, _framingRect.Right, (float)_framingRect.Bottom - _focusOffset);
	}

	private void BuildCurve(float startX, float startY, float centerX, float centerY, float endX, float endY)
	{
		_focusPath.MoveTo(startX, startY);
		_focusPath.LineTo(centerX, centerY);
		_focusPath.LineTo(endX, endY);
	}
}
