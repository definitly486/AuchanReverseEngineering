using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base;
using Auchan.Common.SafeEntrance.Enums;

namespace Auchan.Android.Controls;

public class PinArea : LinearLayout
{
	private static readonly Drawable _defaultDrawable;

	private static readonly GradientDrawable _errorDrawable;

	private static readonly GradientDrawable _pinDrawable;

	private CodeStates[] _pins;

	private LinearLayout _container;

	public CodeStates[] Pins
	{
		get
		{
			return _pins;
		}
		set
		{
			_pins = value;
			UpdateChildren(value);
		}
	}

	static PinArea()
	{
		_defaultDrawable = GetDefaultView();
		_errorDrawable = GetErrorView();
		_pinDrawable = GetFillCircle();
	}

	protected PinArea(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
		Initialize();
	}

	public PinArea(Context context)
		: base(context)
	{
		Initialize();
	}

	public PinArea(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize();
	}

	public PinArea(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize();
	}

	public PinArea(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
		Initialize();
	}

	private void Initialize()
	{
		FrameLayout frameLayout = new FrameLayout(base.Context)
		{
			LayoutParameters = new LayoutParams(-1, -1)
		};
		_container = new LinearLayout(base.Context)
		{
			Orientation = Orientation.Horizontal,
			LayoutParameters = new FrameLayout.LayoutParams(-2, -2)
			{
				Gravity = GravityFlags.Center
			}
		};
		frameLayout.AddView(_container);
		AddView(frameLayout);
	}

	private void UpdateChildren(CodeStates[] value)
	{
		if (value.Length == 0)
		{
			_container.RemoveAllViews();
		}
		int childCount = _container.ChildCount;
		int num = value.Length;
		if (childCount == num)
		{
			RefreshPins(value, num);
		}
		else if (childCount < num)
		{
			RefreshAndTrimPins(value, childCount, num);
		}
		else if (childCount > num)
		{
			RefreshEndExpandPins(value, childCount, num);
		}
	}

	private void RefreshPins(CodeStates[] value, int pinsValueLength)
	{
		for (int i = 0; i < pinsValueLength; i++)
		{
			ChangeItemDrawable(value, i);
		}
	}

	private void RefreshEndExpandPins(CodeStates[] value, int childrenCount, int pinsValueLength)
	{
		for (int i = 0; i < childrenCount; i++)
		{
			if (i < pinsValueLength)
			{
				ChangeItemDrawable(value, i);
			}
			else
			{
				_container.RemoveViewAt(i);
			}
		}
	}

	private void RefreshAndTrimPins(CodeStates[] value, int childrenCount, int pinsValueLength)
	{
		for (int i = 0; i < pinsValueLength; i++)
		{
			if (i < childrenCount)
			{
				ChangeItemDrawable(value, i);
				continue;
			}
			ImageView child = CreatePinImage(value[i]);
			_container.AddView(child);
		}
	}

	private void ChangeItemDrawable(CodeStates[] value, int i)
	{
		((_container.GetChildAt(i) as ImageView) ?? throw new InvalidOperationException("View of unexpected type in hierarchy")).SetImageDrawable(GetDrawableForState(value[i]));
	}

	private ImageView CreatePinImage(CodeStates state)
	{
		ImageView imageView = new ImageView(base.Context);
		imageView.SetImageDrawable(GetDrawableForState(state));
		imageView.LayoutParameters = new LayoutParams(Converter.DpToPx(16f), Converter.DpToPx(16f))
		{
			LeftMargin = Converter.DpToPx(14f),
			RightMargin = Converter.DpToPx(14f)
		};
		return imageView;
	}

	private static Drawable GetDrawableForState(CodeStates state)
	{
		return state switch
		{
			CodeStates.Error => _errorDrawable, 
			CodeStates.Field => _pinDrawable, 
			CodeStates.Empty => _defaultDrawable, 
			_ => throw new ArgumentOutOfRangeException("state", state, null), 
		};
	}

	private static GradientDrawable GetDefaultView()
	{
		return GetStrokeCircleForColor(new Color(240, 243, 247));
	}

	private static GradientDrawable GetErrorView()
	{
		return GetStrokeCircleForColor(new Color(255, 59, 47));
	}

	private static GradientDrawable GetStrokeCircleForColor(Color color)
	{
		GradientDrawable gradientDrawable = new GradientDrawable();
		gradientDrawable.SetShape(ShapeType.Oval);
		gradientDrawable.SetStroke(3, color);
		return gradientDrawable;
	}

	private static GradientDrawable GetFillCircle()
	{
		GradientDrawable gradientDrawable = new GradientDrawable();
		gradientDrawable.SetShape(ShapeType.Oval);
		gradientDrawable.SetColor(new Color(255, 5, 34));
		return gradientDrawable;
	}
}
