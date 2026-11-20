using System;
using AndroidX.Activity;
using AndroidX.Lifecycle;

namespace Auchan.Android.Base;

internal static class BackPressDispatcherExtensions
{
	public static OnBackPressedCallback AddCallback(this OnBackPressedDispatcher dispatcher, ILifecycleOwner lifecycleOwner, Action action)
	{
		DelegateOnBackPressedCallback delegateOnBackPressedCallback = new DelegateOnBackPressedCallback(action);
		dispatcher.AddCallback(lifecycleOwner, delegateOnBackPressedCallback);
		return delegateOnBackPressedCallback;
	}
}
