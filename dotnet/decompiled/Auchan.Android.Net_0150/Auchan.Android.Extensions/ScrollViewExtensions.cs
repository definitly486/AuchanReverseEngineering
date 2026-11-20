using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.Versioning;
using Android.App;
using Android.Graphics;
using Android.Util;
using Android.Views;
using AndroidX.Core.Widget;
using AndroidX.RecyclerView.Widget;
using Auchan.Common.Extensions;

namespace Auchan.Android.Extensions;

public static class ScrollViewExtensions
{
	public static IObservable<EventPattern<NestedScrollView.ScrollChangeEventArgs>> ScrollAsObservable(this NestedScrollView scrollView)
	{
		return Observable.FromEventPattern(delegate(EventHandler<NestedScrollView.ScrollChangeEventArgs> h)
		{
			scrollView.ScrollChange += h;
		}, delegate(EventHandler<NestedScrollView.ScrollChangeEventArgs> h)
		{
			scrollView.ScrollChange -= h;
		});
	}

	[SupportedOSPlatform("android23.0")]
	public static IObservable<EventPattern<View.ScrollChangeEventArgs>> ScrollAsObservable(this RecyclerView scrollView)
	{
		return Observable.FromEventPattern(delegate(EventHandler<View.ScrollChangeEventArgs> h)
		{
			scrollView.ScrollChange += h;
		}, delegate(EventHandler<View.ScrollChangeEventArgs> h)
		{
			scrollView.ScrollChange -= h;
		});
	}

	public static IObservable<bool> BecameVisible(this NestedScrollView container, View child)
	{
		DisplayMetrics? displayMetrics = Application.Context.Resources.DisplayMetrics;
		int widthPixels = displayMetrics.WidthPixels;
		int heightPixels = displayMetrics.HeightPixels;
		Rect screen = new Rect(0, 0, widthPixels, heightPixels);
		return from s in container.ScrollAsObservable().StartWith(new EventPattern<NestedScrollView.ScrollChangeEventArgs>(container, new NestedScrollView.ScrollChangeEventArgs(container, container.ScrollX, container.ScrollY, 0, 0))).Debounce(100)
			select IsVisible(child, screen);
	}

	[SupportedOSPlatform("android23.0")]
	public static IObservable<bool> BecameVisible(this RecyclerView container, View child)
	{
		DisplayMetrics? displayMetrics = Application.Context.Resources.DisplayMetrics;
		int widthPixels = displayMetrics.WidthPixels;
		int heightPixels = displayMetrics.HeightPixels;
		Rect screen = new Rect(0, 0, widthPixels, heightPixels);
		return from s in container.ScrollAsObservable().StartWith(new EventPattern<View.ScrollChangeEventArgs>(container, new View.ScrollChangeEventArgs(container, container.ScrollX, container.ScrollY, 0, 0))).Debounce(100)
			select IsVisible(child, screen);
	}

	private static bool IsVisible(View view, Rect screen)
	{
		if (view == null || !view.IsShown)
		{
			return false;
		}
		if (view.Width <= 0 || view.Height <= 0)
		{
			return false;
		}
		Rect rect = new Rect();
		if (!view.GetGlobalVisibleRect(rect))
		{
			return false;
		}
		if (rect.Width() <= 0 || rect.Height() <= 0)
		{
			return false;
		}
		return Rect.Intersects(screen, rect);
	}
}
