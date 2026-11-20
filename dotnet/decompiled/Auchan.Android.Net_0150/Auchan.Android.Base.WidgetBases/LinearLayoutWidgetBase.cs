using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;

namespace Auchan.Android.Base.WidgetBases;

public class LinearLayoutWidgetBase : LinearLayout
{
	public LinearLayoutWidgetBase(Context context)
		: base(context)
	{
	}

	public LinearLayoutWidgetBase(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public LinearLayoutWidgetBase(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public LinearLayoutWidgetBase(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public LinearLayoutWidgetBase(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}
}
