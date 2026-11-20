using System;
using Android.Text;
using Android.Text.Style;
using Android.Views;

namespace Auchan.Android.Base;

public class CustomClickableSpan : ClickableSpan
{
	private readonly Action<View>? _clickAction;

	public bool Underline { get; set; }

	public CustomClickableSpan()
	{
	}

	public CustomClickableSpan(Action<View>? clickAction)
	{
		_clickAction = clickAction;
	}

	public override void OnClick(View widget)
	{
		_clickAction?.Invoke(widget);
	}

	public override void UpdateDrawState(TextPaint ds)
	{
		base.UpdateDrawState(ds);
		ds.UnderlineText = Underline;
	}
}
