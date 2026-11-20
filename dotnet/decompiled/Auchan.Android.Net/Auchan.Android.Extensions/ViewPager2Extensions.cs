using System;
using System.Reactive.Disposables;
using AndroidX.ViewPager2.Widget;
using Auchan.Android.Common.UiUtils;

namespace Auchan.Android.Extensions;

internal static class ViewPager2Extensions
{
	public static IDisposable OnPageSelected(this ViewPager2 @this, EventHandler<ViewPager2SelectedEventArgs> handler)
	{
		ViewPager2OnPageChangeCallback callback = new ViewPager2OnPageChangeCallback(delegate(int pos)
		{
			handler(@this, new ViewPager2SelectedEventArgs(pos));
		});
		@this.RegisterOnPageChangeCallback(callback);
		return Disposable.Create(delegate
		{
			@this.UnregisterOnPageChangeCallback(callback);
		});
	}

	public static IDisposable OnPageScrolled(this ViewPager2 @this, EventHandler<ViewPager2ScrolledEventArgs> handler)
	{
		ViewPager2OnPageChangeCallback callback = new ViewPager2OnPageChangeCallback(null, delegate(int pos, float posOffset, int posOffsetPixels)
		{
			handler(@this, new ViewPager2ScrolledEventArgs(pos, posOffset, posOffsetPixels));
		});
		@this.RegisterOnPageChangeCallback(callback);
		return Disposable.Create(delegate
		{
			@this.UnregisterOnPageChangeCallback(callback);
		});
	}

	public static IDisposable OnPageScrollStateChanged(this ViewPager2 @this, EventHandler<ViewPager2ScrollStateEventArgs> handler)
	{
		ViewPager2OnPageChangeCallback callback = new ViewPager2OnPageChangeCallback(null, null, delegate(int state)
		{
			handler(@this, new ViewPager2ScrollStateEventArgs(state));
		});
		@this.RegisterOnPageChangeCallback(callback);
		return Disposable.Create(delegate
		{
			@this.UnregisterOnPageChangeCallback(callback);
		});
	}
}
