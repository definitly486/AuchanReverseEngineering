using System;
using Android.Text.Style;
using Android.Views;

namespace Auchan.Android.Common;

public class ClickableActionSpan : ClickableSpan
{
	private readonly Action _onClick;

	public ClickableActionSpan(Action onClick)
	{
		_onClick = onClick;
	}

	public override void OnClick(View widget)
	{
		_onClick();
	}
}
