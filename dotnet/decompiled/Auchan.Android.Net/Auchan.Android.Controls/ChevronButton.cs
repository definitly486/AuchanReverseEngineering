using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Controls;

[Register("auchan.ChevronButton")]
public class ChevronButton : ConstraintLayout
{
	private const int DefIconResId = 0;

	private TextView? _label;

	private ImageView? _icon;

	public string Text
	{
		get
		{
			return _label.Text;
		}
		set
		{
			_label.Text = value;
		}
	}

	protected ChevronButton(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public ChevronButton(Context context)
		: this(context, null)
	{
	}

	public ChevronButton(Context context, IAttributeSet? attrs)
		: this(context, attrs, 0)
	{
	}

	public ChevronButton(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		Init(context, attrs, in defStyleAttr);
	}

	private void Init(Context context, IAttributeSet attrs, in int defStyleAttr)
	{
		LayoutInflater.From(context).Inflate(2131493532, this, attachToRoot: true);
		FindChildViews();
		ObtainStyledAttributes(context, attrs);
	}

	private void FindChildViews()
	{
		_label = RequireViewById<TextView>(2131297415);
		_icon = RequireViewById<ImageView>(2131297308);
	}

	private void ObtainStyledAttributes(Context context, IAttributeSet attrs)
	{
		if (attrs != null)
		{
			TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.ChevronButton);
			int resourceId = typedArray.GetResourceId(0, 0);
			if (resourceId == 0)
			{
				_icon.Visibility = ViewStates.Gone;
			}
			else
			{
				_icon.SetImageResource(resourceId);
			}
			_label.Text = typedArray.GetText(1);
			typedArray.Recycle();
		}
	}
}
