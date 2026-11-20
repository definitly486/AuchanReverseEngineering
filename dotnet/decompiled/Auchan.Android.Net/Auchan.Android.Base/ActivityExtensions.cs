using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Helpers;

namespace Auchan.Android.Base;

public static class ActivityExtensions
{
	public static void HideKeyboard(this Activity activity)
	{
		InputMethodManager? inputMethodManager = InputMethodManager.FromContext(activity);
		View view = activity.CurrentFocus ?? new View(activity);
		inputMethodManager.HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
	}

	public static void ShowKeyboard(this Context context, View focusView)
	{
		((InputMethodManager)context.GetSystemService("input_method")).ShowSoftInput(focusView, (ShowFlags)0);
	}

	public static float ConvertDpToPx(this Activity activity, float dp)
	{
		return TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, activity.Resources.DisplayMetrics);
	}

	public static bool IsKeyboardOpened(this Activity activity)
	{
		Rect rect = new Rect();
		View rootView = activity.GetRootView();
		activity.GetRootView().GetWindowVisibleDisplayFrame(rect);
		int num = rootView.Height - rect.Height();
		double num2 = Math.Round(activity.ConvertDpToPx(50f));
		return (double)num > num2;
	}

	public static bool IsKeyboardClosed(this Activity activity)
	{
		return !activity.IsKeyboardOpened();
	}

	public static View GetRootView(this Activity activity)
	{
		return activity.FindViewById<View>(2131296838);
	}

	public static void SetNavbarVisibility(this Activity activity, bool isVisible)
	{
		if (isVisible)
		{
			ActivityHelper.ClearDecorFlags(activity, SystemUiFlags.HideNavigation | SystemUiFlags.ImmersiveSticky);
		}
		else
		{
			ActivityHelper.AddDecorFlags(activity, SystemUiFlags.HideNavigation | SystemUiFlags.ImmersiveSticky);
		}
	}

	public static int GetScreenWidthInPixels(this Activity @this)
	{
		IWindowManager windowManager = @this.WindowManager;
		if (OperatingSystem.IsAndroidVersionAtLeast(30))
		{
			return windowManager.CurrentWindowMetrics.Bounds.Width();
		}
		DisplayMetrics displayMetrics = new DisplayMetrics();
		windowManager.DefaultDisplay.GetMetrics(displayMetrics);
		return displayMetrics.WidthPixels;
	}

	public static int GetScreenHeightInPixels(this Activity @this)
	{
		IWindowManager windowManager = @this.WindowManager;
		if (OperatingSystem.IsAndroidVersionAtLeast(30))
		{
			return windowManager.CurrentWindowMetrics.Bounds.Height();
		}
		DisplayMetrics displayMetrics = new DisplayMetrics();
		windowManager.DefaultDisplay.GetMetrics(displayMetrics);
		return displayMetrics.HeightPixels;
	}

	public static Task WaitForStateAsync(this FragmentActivity @this, Lifecycle.State targetState)
	{
		if ((@this?.Lifecycle?.CurrentState ?? Lifecycle.State.Destroyed) == targetState)
		{
			return Task.CompletedTask;
		}
		TaskCompletionSource<object?> tcs = new TaskCompletionSource<object>();
		LifecycleEventObserver leo = new LifecycleEventObserver();
		leo.StateChanged += OnStateChanged;
		@this?.Lifecycle?.AddObserver(leo);
		return tcs.Task;
		void OnStateChanged(ILifecycleOwner lo, Lifecycle.Event @event)
		{
			if (@event.TargetState == targetState)
			{
				leo.StateChanged -= OnStateChanged;
				@this?.Lifecycle?.RemoveObserver(leo);
				tcs.TrySetResult(null);
			}
		}
	}

	public static async Task<FragmentManager> GetSupportFragmentManagerAsync(this FragmentActivity @this)
	{
		await @this.WaitForStateAsync(Lifecycle.State.Resumed);
		return @this.SupportFragmentManager;
	}
}
