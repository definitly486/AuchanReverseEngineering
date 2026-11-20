using System;
using System.Reactive.Disposables;
using AndroidX.Core.Widget;

namespace Auchan.Android.Extensions;

internal static class NestedScrollViewExtensions
{
	public static IDisposable OnScrollChange(this NestedScrollView @this, Action handler)
	{
		return @this.OnScrollChange((EventHandler<NestedScrollView.ScrollChangeEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnScrollChange(this NestedScrollView @this, EventHandler<NestedScrollView.ScrollChangeEventArgs> handler)
	{
		@this.ScrollChange += handler;
		return Disposable.Create(delegate
		{
			@this.ScrollChange -= handler;
		});
	}
}
