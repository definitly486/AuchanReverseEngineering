using System;
using AndroidX.Activity;

namespace Auchan.Android.Base;

internal class DelegateOnBackPressedCallback : OnBackPressedCallback
{
	private readonly Action _action;

	public DelegateOnBackPressedCallback(Action action)
		: base(enabled: true)
	{
		_action = action;
	}

	public override void HandleOnBackPressed()
	{
		_action();
	}
}
