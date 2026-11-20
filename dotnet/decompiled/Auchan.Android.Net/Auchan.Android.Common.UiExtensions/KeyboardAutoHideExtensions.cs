using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Views.InputMethods;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using EBind;

namespace Auchan.Android.Common.UiExtensions;

public static class KeyboardAutoHideExtensions
{
	public static void HideKeyboardOnTouchOutside(this Window window, View view, ILifecycleOwner lifecycleOwner, params View[] exceptions)
	{
		WindowCallbackInterceptor windowCallbackInterceptor = (window.Callback as WindowCallbackInterceptor) ?? WindowCallbackInterceptor.Setup(window);
		windowCallbackInterceptor.BeforeDispatchTouchEvent += OnDispatchTouchEvent;
		LifecycleEventObserver observer = new LifecycleEventObserver();
		observer.StateChanged += delegate(ILifecycleOwner s, Lifecycle.Event e)
		{
			if (e == Lifecycle.Event.OnDestroy)
			{
				windowCallbackInterceptor.BeforeDispatchTouchEvent -= OnDispatchTouchEvent;
				s.Lifecycle.RemoveObserver(observer);
			}
		};
		lifecycleOwner.Lifecycle.AddObserver(observer);
		void OnDispatchTouchEvent(object sender, MotionEvent ev)
		{
			if (ev.Action == MotionEventActions.Up && view.HasFocus)
			{
				int touchX = (int)ev.RawX;
				int touchY = (int)ev.RawY;
				if (!view.ScreenVisibleRect().Contains(touchX, touchY) && (exceptions == null || !exceptions.Select((View v) => v.ScreenVisibleRect()).Any((Rect r) => r.Contains(touchX, touchY))))
				{
					view.ClearFocus();
					((InputMethodManager)view.Context.GetSystemService("input_method")).HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
				}
			}
		}
	}

	public static void HideKeyboardOnTouchOutside(this Window window, ILifecycleOwner lifecycleOwner, params View[] views)
	{
		WindowCallbackInterceptor windowCallbackInterceptor = (window.Callback as WindowCallbackInterceptor) ?? WindowCallbackInterceptor.Setup(window);
		windowCallbackInterceptor.BeforeDispatchTouchEvent += new DisposableDelegate<EventHandler<MotionEvent>>(OnDispatchTouchEvent, delegate(EventHandler<MotionEvent> h)
		{
			windowCallbackInterceptor.BeforeDispatchTouchEvent -= h;
		}).AutoDisposeOnDestroy(lifecycleOwner);
		void OnDispatchTouchEvent(object sender, MotionEvent ev)
		{
			View[] array = views;
			foreach (View view in array)
			{
				if (ev.Action == MotionEventActions.Up && view.HasFocus)
				{
					int x = (int)ev.RawX;
					int y = (int)ev.RawY;
					if (!view.ScreenVisibleRect().Contains(x, y))
					{
						view.ClearFocus();
						((InputMethodManager)view.Context.GetSystemService("input_method")).HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
					}
				}
			}
		}
	}

	public static void HideKeyboard(this View view, Context context)
	{
		InputMethodManager.FromContext(context)?.HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
	}

	public static void HideKeyboard(this Context context, params View[] views)
	{
		InputMethodManager inputMethodManager = InputMethodManager.FromContext(context);
		foreach (View view in views)
		{
			inputMethodManager?.HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
		}
	}

	public static void ShowKeyboard(this View view, Context context)
	{
		InputMethodManager? inputMethodManager = InputMethodManager.FromContext(context);
		view.RequestFocus();
		inputMethodManager?.ToggleSoftInputFromWindow(view.WindowToken, ShowSoftInputFlags.Explicit, HideSoftInputFlags.NotAlways);
	}

	public static void ShowKeyboardForced(this View view, ShowFlags flags = ShowFlags.Implicit)
	{
		view.RequestFocus();
		using InputMethodManager inputMethodManager = InputMethodManager.FromContext(view.Context);
		inputMethodManager.ShowSoftInput(view, flags);
	}

	public static void ToggleKeyboard(this View view, FragmentActivity activity)
	{
		((InputMethodManager)activity.GetSystemService("input_method")).ToggleSoftInput(ShowFlags.Implicit, HideSoftInputFlags.None);
	}

	public static void HideKeyboardInDialog(this Dialog dialog)
	{
		View currentFocus = dialog.CurrentFocus;
		if (currentFocus != null)
		{
			InputMethodManager.FromContext(dialog.Context).HideSoftInputFromWindow(currentFocus.WindowToken, HideSoftInputFlags.None);
		}
	}
}
