using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Widget;
using _Microsoft.Android.Resource.Designer;

namespace Auchan.Android.Controls;

[Register("auchan.CustomSearchView")]
public class CustomSearchView : SearchView
{
	private readonly ImageView _searchIconImage;

	private Drawable _searchIconDrawable;

	private bool _isSearchIconVisible = true;

	public bool IsSearchIconVisible
	{
		get
		{
			return _isSearchIconVisible;
		}
		set
		{
			if (!value && _isSearchIconVisible)
			{
				_searchIconImage.SetImageDrawable(null);
				_searchIconImage.Visibility = ViewStates.Gone;
			}
			if (value && !_isSearchIconVisible)
			{
				_searchIconImage.SetImageDrawable(_searchIconDrawable);
				_searchIconImage.Visibility = ViewStates.Visible;
			}
			_isSearchIconVisible = value;
		}
	}

	protected CustomSearchView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public CustomSearchView(Context context)
		: this(context, null)
	{
	}

	public CustomSearchView(Context context, IAttributeSet? attrs)
		: this(context, attrs, 0)
	{
	}

	public CustomSearchView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
		_searchIconImage = RequireViewById<ImageView>(2131298319);
		Init();
		ObtainStyledAttributes(context, attrs);
	}

	private void ObtainStyledAttributes(Context context, IAttributeSet attrs)
	{
		if (attrs != null)
		{
			TypedArray typedArray = context.ObtainStyledAttributes(attrs, ResourceConstant.Styleable.CustomSearchView);
			_searchIconDrawable = typedArray.GetDrawable(0);
			typedArray.Recycle();
		}
	}

	private void Init()
	{
		AutoCompleteTextView autoCompleteTextView = RequireViewById<AutoCompleteTextView>(2131298321);
		TextViewCompat.SetTextAppearance(autoCompleteTextView, 2131952189);
		autoCompleteTextView.SetHintTextColor(new Color(ContextCompat.GetColor(base.Context, 2131100600)));
	}

	public void SetSearchIconImage(int drawableResourceId)
	{
		_searchIconDrawable = base.Context.GetDrawable(drawableResourceId);
		_searchIconImage.SetImageDrawable(_searchIconDrawable);
	}

	public override bool OnInterceptTouchEvent(MotionEvent ev)
	{
		if (ev.Action == MotionEventActions.Down && HasOnClickListeners)
		{
			return true;
		}
		return base.OnInterceptTouchEvent(ev);
	}

	public override bool OnTouchEvent(MotionEvent e)
	{
		if (e.Action == MotionEventActions.Up)
		{
			return CallOnClick();
		}
		return base.OnTouchEvent(e);
	}
}
