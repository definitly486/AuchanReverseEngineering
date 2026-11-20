using Android.Content;
using Android.Runtime;
using Android.Util;
using AndroidX.ConstraintLayout.Widget;

namespace Auchan.Android.Base.WidgetBases;

public class ConstraintLayoutWidgetBase : ConstraintLayout
{
	public ConstraintLayoutWidgetBase(Context context)
		: base(context)
	{
	}

	public ConstraintLayoutWidgetBase(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public ConstraintLayoutWidgetBase(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public ConstraintLayoutWidgetBase(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public ConstraintLayoutWidgetBase(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}
}
