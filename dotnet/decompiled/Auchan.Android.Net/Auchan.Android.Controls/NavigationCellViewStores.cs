using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Views;
using Android.Widget;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Controls;

public class NavigationCellViewStores : LinearLayout
{
	private TextView? _textView;

	private ImageView? _imageView;

	private View _separatorView;

	private View? _view;

	private string _text;

	private int _iconResId;

	private int _lines;

	private float _separatorMarginLeft;

	private float _separatorMarginRight;

	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
			_textView.Text = value;
		}
	}

	public NavigationCellViewStores(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
		_view = View.Inflate(context, 2131493425, this);
		TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.NavigationCellView, 0, 0);
		_lines = typedArray.GetInt(2, 1);
		_text = typedArray.GetString(1);
		_iconResId = typedArray.GetResourceId(0, 2131231403);
		_separatorMarginLeft = typedArray.GetDimension(3, 0f);
		_separatorMarginRight = typedArray.GetDimension(4, 0f);
		typedArray.Recycle();
	}

	public void SetBottomSeparatorVisibility(ViewStates state)
	{
		_separatorView.Visibility = state;
	}

	protected override void OnFinishInflate()
	{
		base.OnFinishInflate();
		_textView = _view.RequireViewById<TextView>(2131297656);
		_imageView = _view.RequireViewById<ImageView>(2131297654);
		_separatorView = _view.RequireViewById<View>(2131297655);
		_textView.Text = _text;
		_textView.SetMaxLines(_lines);
		_imageView.SetImageResource(_iconResId);
		if (_separatorMarginLeft != 0f || _separatorMarginRight != 0f)
		{
			LayoutParams layoutParams = new LayoutParams(_separatorView.LayoutParameters);
			layoutParams.SetMargins((int)_separatorMarginLeft, 0, (int)_separatorMarginRight, 0);
			_separatorView.LayoutParameters = layoutParams;
		}
	}
}
