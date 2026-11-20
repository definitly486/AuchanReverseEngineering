using System;
using Android.Graphics;
using Android.Text;
using Android.Text.Style;
using Android.Views;

namespace Auchan.Android.Base;

internal sealed class ClearClickableSpan : ClickableSpan
{
	private readonly Action _clickAction;

	public ClearClickableSpan(Action clickAction)
	{
		_clickAction = clickAction;
	}

	public override void OnClick(View widget)
	{
		_clickAction?.Invoke();
	}

	public override void UpdateDrawState(TextPaint ds)
	{
		if (OperatingSystem.IsAndroidVersionAtLeast(29))
		{
			ds.UnderlineColor = Color.Transparent;
		}
		ds.UnderlineText = false;
	}
}
