using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Controls;

public class CrossingTextView : ConstraintLayout
{
	private View _view;

	private TextView _textView;

	public string Text
	{
		get
		{
			return _textView.Text;
		}
		set
		{
			_textView.Text = value;
		}
	}

	public CrossingTextView(Context context)
		: base(context)
	{
	}

	public CrossingTextView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		Initialize(context, attrs);
	}

	public CrossingTextView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Initialize(context, attrs);
	}

	protected CrossingTextView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private void Initialize(Context context, IAttributeSet attrs)
	{
		_view = View.Inflate(context, 2131493146, this);
		TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.CrossingTextView, 0, 0);
		_textView = _view.RequireViewById<TextView>(2131296873);
		Color color = typedArray.GetColor(1, 2131099704);
		string text = typedArray.GetString(0);
		int dimensionPixelSize = typedArray.GetDimensionPixelSize(2, 0);
		_textView.Text = text;
		_textView.SetTextColor(color);
		_textView.SetTextSize(ComplexUnitType.Fraction, dimensionPixelSize);
		typedArray.Recycle();
	}
}
