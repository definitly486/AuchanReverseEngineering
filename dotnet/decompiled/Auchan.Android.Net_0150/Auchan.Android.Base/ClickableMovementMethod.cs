using System;
using Android.Text;
using Android.Text.Method;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Auchan.Android.Base;

public class ClickableMovementMethod : BaseMovementMethod
{
	private static readonly Lazy<ClickableMovementMethod> _lazyInstance = new Lazy<ClickableMovementMethod>(() => new ClickableMovementMethod());

	public static ClickableMovementMethod Instance => _lazyInstance.Value;

	public override bool OnTouchEvent(TextView? widget, ISpannable? text, MotionEvent? e)
	{
		MotionEventActions actionMasked = e.ActionMasked;
		if (actionMasked == MotionEventActions.Up || actionMasked == MotionEventActions.Down)
		{
			int num = (int)e.GetX();
			int num2 = (int)e.GetY();
			num -= widget.TotalPaddingLeft;
			num2 -= widget.TotalPaddingTop;
			num += widget.ScrollX;
			num2 += widget.ScrollY;
			Layout? layout = widget.Layout;
			int lineForVertical = layout.GetLineForVertical(num2);
			int offsetForHorizontal = layout.GetOffsetForHorizontal(lineForVertical, num);
			Java.Lang.Object[] spans = text.GetSpans(offsetForHorizontal, offsetForHorizontal, Java.Lang.Class.FromType(typeof(ClickableSpan)));
			if (spans != null && spans.Length != 0 && spans.GetValue(0) is ClickableSpan clickableSpan)
			{
				if (actionMasked == MotionEventActions.Up)
				{
					clickableSpan.OnClick(widget);
				}
				return true;
			}
			Selection.RemoveSelection(text);
		}
		return false;
	}

	public override bool CanSelectArbitrarily()
	{
		return false;
	}

	public override void Initialize(TextView? widget, ISpannable? text)
	{
		Selection.RemoveSelection(text);
	}
}
