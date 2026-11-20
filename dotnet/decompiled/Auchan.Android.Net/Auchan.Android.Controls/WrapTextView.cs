using System;
using Android.Content;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Widget;

namespace Auchan.Android.Controls;

[Register("auchan.WrapTextView")]
public class WrapTextView : TextView
{
	public WrapTextView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public WrapTextView(Context context)
		: base(context)
	{
	}

	public WrapTextView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public WrapTextView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public WrapTextView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
	{
		base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
		Layout layout = base.Layout;
		if (layout == null)
		{
			return;
		}
		float num = 0f;
		int i = 0;
		for (int lineCount = layout.LineCount; i < lineCount; i++)
		{
			float lineMax = layout.GetLineMax(i);
			if (lineMax > num)
			{
				num = lineMax;
			}
		}
		int measuredHeight = base.MeasuredHeight;
		int measuredWidth = (int)Math.Ceiling(num) + CompoundPaddingLeft + CompoundPaddingRight;
		SetMeasuredDimension(measuredWidth, measuredHeight);
	}
}
