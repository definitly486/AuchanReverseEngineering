using System;
using System.Globalization;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Xamarin.RangeSlider.Common;
using _Microsoft.Android.Resource.Designer;

namespace Xamarin.RangeSlider;

public class RangeSliderControl : ImageView
{
	public static readonly Color DefaultDarkBlueColor = Color.Argb(255, 51, 181, 229);

	public static readonly Color DefaultLightBlueColor = Color.Argb(154, 51, 181, 229);

	public static readonly Color DefaultGrayColor = Color.Argb(77, 136, 136, 136);

	public static readonly Color DefaultLightestBlueColor = Color.Argb(102, 51, 181, 229);

	private readonly Paint _paint = new Paint(PaintFlags.AntiAlias);

	private readonly Paint _shadowPaint = new Paint();

	private readonly Matrix _thumbShadowMatrix = new Matrix();

	private readonly Path _translatedThumbShadowPath = new Path();

	private int _activePointerId = 255;

	private int _distanceToTop;

	private float _downMotionX;

	private float _internalPad;

	private bool _isDragging;

	private float _padding;

	private Thumb? _pressedThumb;

	private RectF _rect;

	private int _scaledTouchSlop;

	private int _textOffset;

	private int _textSize;

	private float _thumbHalfHeight;

	private float _thumbHalfWidth;

	private int _thumbShadowBlur;

	private Path _thumbShadowPath;

	protected float MinDeltaForDefault;

	protected float NormalizedMaxValue = 1f;

	protected float NormalizedMinValue;

	private Color _activeColor;

	private bool _minThumbHidden;

	private bool _minThumbLabelHidden;

	private bool _maxThumbHidden;

	private bool _maxThumbLabelHidden;

	private bool _showTextAboveThumbs;

	private float _barHeight;

	private string _textFormat = "F0";

	private bool _materialUI;

	public float AbsoluteMinValue { get; protected set; }

	public float AbsoluteMaxValue { get; protected set; }

	private float MinToMaxRange => AbsoluteMaxValue - AbsoluteMinValue;

	public bool ActivateOnDefaultValues { get; set; }

	public Color ActiveColor
	{
		get
		{
			return _activeColor;
		}
		set
		{
			_activeColor = value;
			UpdateThumbImages();
			RequestLayout();
			Invalidate();
		}
	}

	public Func<Thumb, float, string> FormatLabel { get; set; }

	public override bool Enabled
	{
		get
		{
			return base.Enabled;
		}
		set
		{
			base.Enabled = value;
			Invalidate();
		}
	}

	public bool AlwaysActive { get; set; }

	public Color DefaultColor { get; set; }

	public bool ShowLabels { get; set; }

	public int TextSizeInSp
	{
		get
		{
			return PixelUtil.PxToSp(base.Context, _textSize);
		}
		set
		{
			_textSize = PixelUtil.SpToPx(base.Context, value);
			UpdateTextOffset();
			SetBarHeight(_barHeight);
			RequestLayout();
			Invalidate();
		}
	}

	public bool ShowTextAboveThumbs
	{
		get
		{
			return _showTextAboveThumbs;
		}
		set
		{
			_showTextAboveThumbs = value;
			UpdateTextOffset();
			SetBarHeight(_barHeight);
			RequestLayout();
			Invalidate();
		}
	}

	public string TextFormat
	{
		get
		{
			return _textFormat;
		}
		set
		{
			_textFormat = (string.IsNullOrWhiteSpace(value) ? "F0" : value);
			Invalidate();
		}
	}

	public bool MaterialUI
	{
		get
		{
			return _materialUI;
		}
		set
		{
			_materialUI = value;
			UpdateThumbImages();
			SetBarHeight(_barHeight);
			RequestLayout();
			Invalidate();
		}
	}

	public bool MinThumbHidden
	{
		get
		{
			return _minThumbHidden;
		}
		set
		{
			_minThumbHidden = value;
			Invalidate();
		}
	}

	public bool MinThumbTextHidden
	{
		get
		{
			return _minThumbLabelHidden;
		}
		set
		{
			_minThumbLabelHidden = value;
			Invalidate();
		}
	}

	public bool MaxThumbHidden
	{
		get
		{
			return _maxThumbHidden;
		}
		set
		{
			_maxThumbHidden = value;
			Invalidate();
		}
	}

	public bool MaxThumbTextHidden
	{
		get
		{
			return _maxThumbLabelHidden;
		}
		set
		{
			_maxThumbLabelHidden = value;
			Invalidate();
		}
	}

	public Color TextAboveThumbsColor { get; set; }

	private Color thumbShadowColor { get; set; }

	public Bitmap ThumbDisabledImage { get; set; }

	public Bitmap ThumbImage { get; set; }

	public Bitmap ThumbPressedImage { get; set; }

	public Bitmap DefaultThumbImage { get; private set; }

	public Bitmap DefaultThumbDisabledImage { get; private set; }

	public Bitmap DefaultThumbPressedImage { get; private set; }

	public bool ThumbShadow { get; set; }

	public int ThumbShadowXOffset { get; set; }

	public int ThumbShadowYOffset { get; set; }

	public bool NotifyWhileDragging { get; set; }

	public float StepValue { get; set; }

	public bool StepValueContinuously { get; set; }

	public event EventHandler LowerValueChanged;

	public event EventHandler UpperValueChanged;

	public event EventHandler DragStarted;

	public event EventHandler DragCompleted;

	protected RangeSliderControl(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public RangeSliderControl(Context context)
		: base(context)
	{
		Init(context, null);
	}

	public RangeSliderControl(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Init(context, attrs);
	}

	public RangeSliderControl(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Init(context, attrs);
	}

	public RangeSliderControl(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Init(context, attrs);
	}

	private float ExtractNumericValueFromAttributes(TypedArray a, int attribute, int defaultValue)
	{
		if (a.PeekValue(attribute) != null)
		{
			return a.GetFloat(attribute, defaultValue);
		}
		return defaultValue;
	}

	private static ShapeDrawable Circle(Color color)
	{
		ShapeDrawable shapeDrawable = new ShapeDrawable(new OvalShape());
		shapeDrawable.Paint.Color = color;
		return shapeDrawable;
	}

	private void Init(Context context, IAttributeSet attrs)
	{
		Color color = Color.Argb(75, 0, 0, 0);
		int num = PixelUtil.DpToPx(context, 2);
		int num2 = PixelUtil.DpToPx(context, 0);
		int num3 = PixelUtil.DpToPx(context, 2);
		_distanceToTop = PixelUtil.DpToPx(context, 8);
		if (attrs == null)
		{
			SetRangeToDefaultValues();
			_internalPad = PixelUtil.DpToPx(context, 8);
			_barHeight = PixelUtil.DpToPx(context, 1);
			ActiveColor = DefaultDarkBlueColor;
			DefaultColor = Color.Gray;
			AlwaysActive = false;
			ShowTextAboveThumbs = true;
			TextAboveThumbsColor = Color.White;
			thumbShadowColor = color;
			ThumbShadowXOffset = num2;
			ThumbShadowYOffset = num;
			_thumbShadowBlur = num3;
			ActivateOnDefaultValues = false;
			TextSizeInSp = 15;
			MaterialUI = false;
		}
		else
		{
			TypedArray typedArray = base.Context.ObtainStyledAttributes(attrs, Resource.Styleable.RangeSliderControl, 0, 0);
			try
			{
				SetRangeValues(ExtractNumericValueFromAttributes(typedArray, 1, 0), ExtractNumericValueFromAttributes(typedArray, 0, 100));
				ShowTextAboveThumbs = typedArray.GetBoolean(24, defValue: true);
				TextAboveThumbsColor = typedArray.GetColor(14, Color.White);
				MinThumbHidden = typedArray.GetBoolean(10, defValue: false);
				MaxThumbHidden = typedArray.GetBoolean(9, defValue: false);
				ShowLabels = typedArray.GetBoolean(11, defValue: true);
				_internalPad = typedArray.GetDimensionPixelSize(7, 8);
				_barHeight = typedArray.GetDimensionPixelSize(5, 1);
				ActiveColor = typedArray.GetColor(3, DefaultDarkBlueColor);
				DefaultColor = typedArray.GetColor(6, Color.Gray);
				AlwaysActive = typedArray.GetBoolean(4, defValue: false);
				StepValue = ExtractNumericValueFromAttributes(typedArray, 12, 0);
				StepValueContinuously = typedArray.GetBoolean(13, defValue: false);
				Drawable drawable = typedArray.GetDrawable(17);
				if (drawable != null)
				{
					DefaultThumbImage = BitmapUtil.DrawableToBitmap(drawable);
				}
				Drawable drawable2 = typedArray.GetDrawable(16);
				if (drawable2 != null)
				{
					DefaultThumbDisabledImage = BitmapUtil.DrawableToBitmap(drawable2);
				}
				Drawable drawable3 = typedArray.GetDrawable(18);
				if (drawable3 != null)
				{
					DefaultThumbPressedImage = BitmapUtil.DrawableToBitmap(drawable3);
				}
				ThumbShadow = typedArray.GetBoolean(19, defValue: false);
				thumbShadowColor = typedArray.GetColor(21, color);
				ThumbShadowXOffset = typedArray.GetDimensionPixelSize(22, num2);
				ThumbShadowYOffset = typedArray.GetDimensionPixelSize(23, num);
				_thumbShadowBlur = typedArray.GetDimensionPixelSize(20, num3);
				ActivateOnDefaultValues = typedArray.GetBoolean(2, defValue: false);
				TextSizeInSp = typedArray.GetInt(15, 15);
				MaterialUI = typedArray.GetBoolean(8, defValue: false);
			}
			finally
			{
				typedArray.Recycle();
			}
		}
		SetBarHeight(_barHeight);
		base.Focusable = true;
		base.FocusableInTouchMode = true;
		_scaledTouchSlop = ViewConfiguration.Get(base.Context).ScaledTouchSlop;
		UpdateThumbImages();
	}

	private void UpdateThumbImages()
	{
		ThumbImage = DefaultThumbImage ?? BitmapUtil.DrawableToBitmap(GetThumbDrawable());
		ThumbPressedImage = DefaultThumbPressedImage ?? BitmapUtil.DrawableToBitmap(GetPressedThumbDrawable());
		ThumbDisabledImage = DefaultThumbDisabledImage ?? BitmapUtil.DrawableToBitmap(GetDisabledThumbDrawable());
		UpdateThumbValues();
	}

	private void UpdateThumbValues()
	{
		_thumbHalfWidth = 0.5f * (float)ThumbImage.Width;
		_thumbHalfHeight = 0.5f * (float)ThumbImage.Height;
		if (ThumbShadow)
		{
			SetLayerType(LayerType.Software, null);
			_shadowPaint.Color = thumbShadowColor;
			_shadowPaint.SetMaskFilter(new BlurMaskFilter(_thumbShadowBlur, BlurMaskFilter.Blur.Normal));
			_thumbShadowPath = new Path();
			_thumbShadowPath.AddCircle(0f, 0f, _thumbHalfHeight, Path.Direction.Cw);
		}
	}

	private Drawable GetMaterialUiThumbDrawable(Color color)
	{
		ShapeDrawable shapeDrawable = Circle(color);
		LayerDrawable layerDrawable = new LayerDrawable(new Drawable[1] { shapeDrawable });
		layerDrawable.SetLayerInset(0, 19, 19, 19, 19);
		layerDrawable.SetBounds(0, 0, 64, 64);
		return layerDrawable;
	}

	private Drawable GetThumbDrawable()
	{
		if (MaterialUI)
		{
			return GetMaterialUiThumbDrawable(ActiveColor);
		}
		ShapeDrawable shapeDrawable = Circle(DefaultLightBlueColor);
		ShapeDrawable shapeDrawable2 = Circle(DefaultDarkBlueColor);
		LayerDrawable layerDrawable = new LayerDrawable(new Drawable[2] { shapeDrawable, shapeDrawable2 });
		layerDrawable.SetLayerInset(0, 4, 4, 4, 4);
		layerDrawable.SetLayerInset(1, 23, 23, 23, 23);
		layerDrawable.SetBounds(0, 0, 64, 64);
		return layerDrawable;
	}

	private Drawable GetPressedThumbDrawable()
	{
		if (MaterialUI)
		{
			return GetMaterialUiThumbDrawable(ActiveColor);
		}
		ShapeDrawable shapeDrawable = Circle(DefaultDarkBlueColor);
		shapeDrawable.Paint.StrokeWidth = 4f;
		shapeDrawable.Paint.SetStyle(Paint.Style.Stroke);
		ShapeDrawable shapeDrawable2 = Circle(DefaultLightestBlueColor);
		ShapeDrawable shapeDrawable3 = Circle(DefaultDarkBlueColor);
		LayerDrawable layerDrawable = new LayerDrawable(new Drawable[3] { shapeDrawable, shapeDrawable2, shapeDrawable3 });
		layerDrawable.SetLayerInset(0, 4, 4, 4, 4);
		layerDrawable.SetLayerInset(1, 4, 4, 4, 4);
		layerDrawable.SetLayerInset(2, 23, 23, 23, 23);
		layerDrawable.SetBounds(0, 0, 64, 64);
		return layerDrawable;
	}

	private Drawable GetDisabledThumbDrawable()
	{
		if (MaterialUI)
		{
			return GetMaterialUiThumbDrawable(DefaultColor);
		}
		ShapeDrawable shapeDrawable = Circle(DefaultGrayColor);
		ShapeDrawable shapeDrawable2 = Circle(DefaultDarkBlueColor);
		LayerDrawable layerDrawable = new LayerDrawable(new Drawable[2] { shapeDrawable, shapeDrawable2 });
		layerDrawable.SetLayerInset(0, 8, 8, 8, 8);
		layerDrawable.SetLayerInset(1, 28, 28, 28, 28);
		layerDrawable.SetBounds(0, 0, 64, 64);
		return layerDrawable;
	}

	public void SetBarHeight(float barHeight)
	{
		_barHeight = barHeight;
		if (_rect == null)
		{
			_rect = new RectF(_padding, (float)_textOffset + _thumbHalfHeight - _barHeight / 2f, (float)base.Width - _padding, (float)_textOffset + _thumbHalfHeight + _barHeight / 2f);
		}
		else
		{
			_rect = new RectF(_rect.Left, (float)_textOffset + _thumbHalfHeight - _barHeight / 2f, _rect.Right, (float)_textOffset + _thumbHalfHeight + _barHeight / 2f);
		}
		Invalidate();
	}

	public void SetRangeValues(float minValue, float maxValue)
	{
		float value = NormalizedToValue(NormalizedMinValue);
		float value2 = NormalizedToValue(NormalizedMaxValue);
		AbsoluteMinValue = minValue;
		AbsoluteMaxValue = maxValue;
		if (Math.Abs(MinToMaxRange) < float.Epsilon)
		{
			SetNormalizedMinValue(0f, step: true, checkValue: true);
			SetNormalizedMaxValue(0f, step: true, checkValue: true);
		}
		else
		{
			SetNormalizedMinValue(ValueToNormalized(value), step: true, checkValue: true);
			SetNormalizedMaxValue(ValueToNormalized(value2), step: true, checkValue: true);
		}
		Invalidate();
	}

	public void SetTextAboveThumbsColor(Color textAboveThumbsColor)
	{
		TextAboveThumbsColor = textAboveThumbsColor;
		Invalidate();
	}

	public void SetTextAboveThumbsColorResource(int resId)
	{
		SetTextAboveThumbsColor(new Color(Resources.GetColor(resId, null)));
	}

	private void SetRangeToDefaultValues()
	{
		AbsoluteMinValue = 0f;
		AbsoluteMaxValue = 100f;
	}

	public void ResetSelectedValues()
	{
		SetSelectedMinValue(AbsoluteMinValue);
		SetSelectedMaxValue(AbsoluteMaxValue);
	}

	public float GetSelectedMinValue()
	{
		return NormalizedToValue(NormalizedMinValue);
	}

	public void SetSelectedMinValue(float value, bool force = false)
	{
		if (_pressedThumb != Thumb.Lower || force)
		{
			SetNormalizedMinValue((Math.Abs(MinToMaxRange) < float.Epsilon) ? 0f : ValueToNormalized(value), step: true, checkValue: false);
		}
	}

	public float GetSelectedMaxValue()
	{
		return NormalizedToValue(NormalizedMaxValue);
	}

	public void SetSelectedMaxValue(float value, bool force = false)
	{
		if (_pressedThumb != Thumb.Upper || force)
		{
			SetNormalizedMaxValue((Math.Abs(MinToMaxRange) < float.Epsilon) ? 1f : ValueToNormalized(value), step: true, checkValue: false);
		}
	}

	public void SetThumbShadowPath(Path thumbShadowPath)
	{
		_thumbShadowPath = thumbShadowPath;
	}

	public void SetCustomThumbImage(Bitmap customThumbImage)
	{
		ThumbImage = customThumbImage;
		UpdateThumbValues();
	}

	public void SetCustomThumbPressedImage(Bitmap customThumbImage)
	{
		ThumbPressedImage = customThumbImage;
		UpdateThumbValues();
	}

	public void SetCustomThumbDisabledImage(Bitmap customThumbDisabledImage)
	{
		ThumbDisabledImage = customThumbDisabledImage;
		UpdateThumbValues();
	}

	public override bool OnTouchEvent(MotionEvent ev)
	{
		if (!Enabled)
		{
			return false;
		}
		switch (ev.Action & MotionEventActions.Mask)
		{
		case MotionEventActions.Down:
		{
			_activePointerId = ev.GetPointerId(ev.PointerCount - 1);
			int pointerIndex = ev.FindPointerIndex(_activePointerId);
			_downMotionX = ev.GetX(pointerIndex);
			_pressedThumb = EvalPressedThumb(_downMotionX);
			if (!_pressedThumb.HasValue)
			{
				return base.OnTouchEvent(ev);
			}
			Pressed = true;
			Invalidate();
			OnStartTrackingTouch();
			TrackTouchEvent(ev, StepValueContinuously);
			AttemptClaimDrag();
			break;
		}
		case MotionEventActions.Move:
			if (!_pressedThumb.HasValue)
			{
				break;
			}
			if (_isDragging)
			{
				TrackTouchEvent(ev, StepValueContinuously);
			}
			else
			{
				int pointerIndex = ev.FindPointerIndex(_activePointerId);
				if (Math.Abs(ev.GetX(pointerIndex) - _downMotionX) > (float)_scaledTouchSlop)
				{
					Pressed = true;
					Invalidate();
					OnStartTrackingTouch();
					TrackTouchEvent(ev, StepValueContinuously);
					AttemptClaimDrag();
				}
			}
			if (NotifyWhileDragging)
			{
				if (_pressedThumb == Thumb.Lower)
				{
					OnLowerValueChanged();
				}
				if (_pressedThumb == Thumb.Upper)
				{
					OnUpperValueChanged();
				}
			}
			break;
		case MotionEventActions.Up:
			if (_isDragging)
			{
				TrackTouchEvent(ev, step: true);
				OnStopTrackingTouch();
				Pressed = false;
			}
			else
			{
				OnStartTrackingTouch();
				TrackTouchEvent(ev, step: true);
				OnStopTrackingTouch();
			}
			if (_pressedThumb == Thumb.Lower)
			{
				OnLowerValueChanged();
			}
			if (_pressedThumb == Thumb.Upper)
			{
				OnUpperValueChanged();
			}
			_pressedThumb = null;
			Invalidate();
			break;
		case MotionEventActions.Pointer1Down:
		{
			int pointerIndex2 = ev.PointerCount - 1;
			_downMotionX = ev.GetX(pointerIndex2);
			_activePointerId = ev.GetPointerId(pointerIndex2);
			Invalidate();
			break;
		}
		case MotionEventActions.Pointer1Up:
			OnSecondaryPointerUp(ev);
			Invalidate();
			break;
		case MotionEventActions.Cancel:
			if (_isDragging)
			{
				OnStopTrackingTouch();
				Pressed = false;
			}
			Invalidate();
			break;
		}
		return true;
	}

	private void OnSecondaryPointerUp(MotionEvent ev)
	{
		int num = (int)(ev.Action & MotionEventActions.PointerIdMask) >> 8;
		if (ev.GetPointerId(num) == _activePointerId)
		{
			int pointerIndex = ((num == 0) ? 1 : 0);
			_downMotionX = ev.GetX(pointerIndex);
			_activePointerId = ev.GetPointerId(pointerIndex);
		}
	}

	private void TrackTouchEvent(MotionEvent ev, bool step)
	{
		int pointerIndex = ev.FindPointerIndex(_activePointerId);
		float x = ev.GetX(pointerIndex);
		if (Thumb.Lower.Equals(_pressedThumb) && !MinThumbHidden)
		{
			SetNormalizedMinValue(ScreenToNormalized(x), step, checkValue: true);
		}
		else if (Thumb.Upper.Equals(_pressedThumb) && !MaxThumbHidden)
		{
			SetNormalizedMaxValue(ScreenToNormalized(x), step, checkValue: true);
		}
	}

	private void AttemptClaimDrag()
	{
		base.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: true);
	}

	private void OnStartTrackingTouch()
	{
		_isDragging = true;
		this.DragStarted?.Invoke(this, EventArgs.Empty);
	}

	private void OnStopTrackingTouch()
	{
		_isDragging = false;
		this.DragCompleted?.Invoke(this, EventArgs.Empty);
	}

	protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
	{
		int measuredWidth = 200;
		if (MeasureSpec.GetMode(widthMeasureSpec) != MeasureSpecMode.Unspecified)
		{
			measuredWidth = MeasureSpec.GetSize(widthMeasureSpec);
		}
		int num = ThumbImage.Height + (ShowTextAboveThumbs ? (PixelUtil.DpToPx(base.Context, 16) + PixelUtil.SpToPx(base.Context, TextSizeInSp)) : 0) + (ThumbShadow ? (ThumbShadowYOffset + _thumbShadowBlur) : 0);
		if (MeasureSpec.GetMode(heightMeasureSpec) != MeasureSpecMode.Unspecified)
		{
			num = Math.Min(num, MeasureSpec.GetSize(heightMeasureSpec));
		}
		SetMeasuredDimension(measuredWidth, num);
	}

	protected override void OnDraw(Canvas canvas)
	{
		base.OnDraw(canvas);
		_paint.TextSize = _textSize;
		_paint.SetStyle(Paint.Style.Fill);
		_paint.Color = DefaultColor;
		_paint.AntiAlias = true;
		float num = 0f;
		if (ShowLabels)
		{
			string text = base.Context.GetString(2131886151);
			string text2 = base.Context.GetString(2131886150);
			num = Math.Max(_paint.MeasureText(text), _paint.MeasureText(text2));
			float y = (float)_textOffset + _thumbHalfHeight + (float)_textSize / 3f;
			if (!MinThumbTextHidden)
			{
				canvas.DrawText(text, 0f, y, _paint);
			}
			if (!MaxThumbTextHidden)
			{
				canvas.DrawText(text2, (float)base.Width - num, y, _paint);
			}
		}
		_padding = _internalPad + num + _thumbHalfWidth;
		_rect.Left = _padding;
		_rect.Right = (float)base.Width - _padding;
		_rect.Top = (float)_textOffset + _thumbHalfHeight - _barHeight / 2f;
		_rect.Bottom = (float)_textOffset + _thumbHalfHeight + _barHeight / 2f;
		canvas.DrawRect(_rect, _paint);
		bool flag = NormalizedMinValue <= MinDeltaForDefault && NormalizedMaxValue >= 1f - MinDeltaForDefault;
		Color color = ((!Enabled || (!AlwaysActive && !ActivateOnDefaultValues && flag)) ? DefaultColor : ActiveColor);
		_rect.Left = NormalizedToScreen(NormalizedMinValue);
		_rect.Right = NormalizedToScreen(NormalizedMaxValue);
		_paint.Color = color;
		canvas.DrawRect(_rect, _paint);
		if (!MinThumbHidden)
		{
			if (ThumbShadow)
			{
				DrawThumbShadow(NormalizedToScreen(NormalizedMinValue), canvas);
			}
			DrawThumb(NormalizedToScreen(NormalizedMinValue), Thumb.Lower.Equals(_pressedThumb), canvas, flag);
		}
		if (!MaxThumbHidden)
		{
			if (ThumbShadow)
			{
				DrawThumbShadow(NormalizedToScreen(NormalizedMaxValue), canvas);
			}
			DrawThumb(NormalizedToScreen(NormalizedMaxValue), Thumb.Upper.Equals(_pressedThumb), canvas, flag);
		}
		if (!ShowTextAboveThumbs || (!ActivateOnDefaultValues && flag))
		{
			return;
		}
		_paint.TextSize = _textSize;
		_paint.Color = TextAboveThumbsColor;
		string text3 = ValueToString(GetSelectedMinValue(), Thumb.Lower);
		string text4 = ValueToString(GetSelectedMaxValue(), Thumb.Upper);
		float num2 = _paint.MeasureText(text3);
		float num3 = _paint.MeasureText(text4);
		float num4 = Math.Max(0f, NormalizedToScreen(NormalizedMinValue) - num2 * 0.5f);
		float num5 = Math.Min((float)base.Width - num3, NormalizedToScreen(NormalizedMaxValue) - num3 * 0.5f);
		if (!MaxThumbHidden && !MinThumbHidden)
		{
			int num6 = PixelUtil.DpToPx(base.Context, 5);
			float num7 = num4 + num2 - num5 + (float)num6;
			if (num7 > 0f)
			{
				num4 -= num7 * NormalizedMinValue / (NormalizedMinValue + 1f - NormalizedMaxValue);
				num5 += num7 * (1f - NormalizedMaxValue) / (NormalizedMinValue + 1f - NormalizedMaxValue);
			}
		}
		if (!MinThumbHidden && !MinThumbTextHidden)
		{
			canvas.DrawText(text3, num4, _distanceToTop + _textSize, _paint);
		}
		if (!MaxThumbHidden && !MaxThumbTextHidden)
		{
			canvas.DrawText(text4, num5, _distanceToTop + _textSize, _paint);
		}
	}

	protected string ValueToString(float value, Thumb thumb)
	{
		Func<Thumb, float, string> formatLabel = FormatLabel;
		if (formatLabel != null)
		{
			return formatLabel(thumb, value);
		}
		return value.ToString(_textFormat, CultureInfo.InvariantCulture);
	}

	protected override IParcelable OnSaveInstanceState()
	{
		Bundle bundle = new Bundle();
		bundle.PutParcelable("SUPER", base.OnSaveInstanceState());
		bundle.PutFloat("MIN", NormalizedMinValue);
		bundle.PutFloat("MAX", NormalizedMaxValue);
		return bundle;
	}

	protected override void OnRestoreInstanceState(IParcelable parcel)
	{
		Bundle bundle = (Bundle)parcel;
		base.OnRestoreInstanceState((IParcelable)bundle.GetParcelable("SUPER"));
		NormalizedMinValue = bundle.GetFloat("MIN");
		NormalizedMaxValue = bundle.GetFloat("MAX");
	}

	private void DrawThumb(float screenCoord, bool pressed, Canvas canvas, bool areSelectedValuesDefault)
	{
		Bitmap bitmap = ((Enabled && !(!ActivateOnDefaultValues && areSelectedValuesDefault)) ? (pressed ? ThumbPressedImage : ThumbImage) : ThumbDisabledImage);
		canvas.DrawBitmap(bitmap, screenCoord - (float)bitmap.Width * 0.5f, _textOffset + (ThumbImage.Height - bitmap.Height) / 2, _paint);
	}

	private void DrawThumbShadow(float screenCoord, Canvas canvas)
	{
		_thumbShadowMatrix.SetTranslate(screenCoord + (float)ThumbShadowXOffset, (float)_textOffset + _thumbHalfHeight + (float)ThumbShadowYOffset);
		_translatedThumbShadowPath.Set(_thumbShadowPath);
		_translatedThumbShadowPath.Transform(_thumbShadowMatrix);
		canvas.DrawPath(_translatedThumbShadowPath, _shadowPaint);
	}

	private Thumb? EvalPressedThumb(float touchX)
	{
		Thumb? result = null;
		bool flag = IsInThumbRange(touchX, NormalizedMinValue);
		bool flag2 = IsInThumbRange(touchX, NormalizedMaxValue);
		if (flag && flag2)
		{
			result = ((touchX / (float)base.Width > 0.5f) ? Thumb.Lower : Thumb.Upper);
		}
		else if (flag)
		{
			result = Thumb.Lower;
		}
		else if (flag2)
		{
			result = Thumb.Upper;
		}
		return result;
	}

	private bool IsInThumbRange(float touchX, float normalizedThumbValue)
	{
		return Math.Abs(touchX - NormalizedToScreen(normalizedThumbValue)) <= _thumbHalfWidth;
	}

	private void SetNormalizedMinValue(float value, bool step, bool checkValue)
	{
		NormalizedMinValue = (checkValue ? Math.Max(0f, Math.Min(1f, Math.Min(value, NormalizedMaxValue))) : value);
		if (step)
		{
			NormalizedMinValue = ValueToNormalized(NormalizedToValue(NormalizedMinValue));
		}
		Invalidate();
	}

	private void SetNormalizedMaxValue(float value, bool step, bool checkValue)
	{
		NormalizedMaxValue = (checkValue ? Math.Max(0f, Math.Min(1f, Math.Max(value, NormalizedMinValue))) : value);
		if (step)
		{
			NormalizedMaxValue = ValueToNormalized(NormalizedToValue(NormalizedMaxValue));
		}
		Invalidate();
	}

	protected float NormalizedToValue(float normalized)
	{
		float num = normalized * MinToMaxRange;
		if (Math.Abs(StepValue) < float.Epsilon)
		{
			return AbsoluteMinValue + (float)Math.Round(num * 100f) / 100f;
		}
		float val = AbsoluteMinValue + (float)Math.Round(num / StepValue) * StepValue;
		return Math.Max(AbsoluteMinValue, Math.Min(AbsoluteMaxValue, val));
	}

	protected float ValueToNormalized(float value)
	{
		if (Math.Abs(MinToMaxRange) < float.Epsilon)
		{
			return 0f;
		}
		return (value - AbsoluteMinValue) / MinToMaxRange;
	}

	private void UpdateTextOffset()
	{
		_textOffset = (_showTextAboveThumbs ? (_textSize + PixelUtil.DpToPx(base.Context, 8) + _distanceToTop) : 0);
	}

	private float NormalizedToScreen(float normalizedCoord)
	{
		return _padding + normalizedCoord * ((float)base.Width - 2f * _padding);
	}

	private float ScreenToNormalized(float screenCoord)
	{
		int width = base.Width;
		if ((float)width <= 2f * _padding)
		{
			return 0f;
		}
		float val = (screenCoord - _padding) / ((float)width - 2f * _padding);
		return Math.Min(1f, Math.Max(0f, val));
	}

	protected virtual void OnLowerValueChanged()
	{
		this.LowerValueChanged?.Invoke(this, EventArgs.Empty);
	}

	protected virtual void OnUpperValueChanged()
	{
		this.UpperValueChanged?.Invoke(this, EventArgs.Empty);
	}
}
