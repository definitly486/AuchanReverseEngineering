using System;
using System.Reactive.Disposables;
using Google.Android.Material.Navigation;

namespace Auchan.Android.Extensions;

internal static class NavigationBarViewExtensions
{
	public static IDisposable OnItemSelected(this NavigationBarView @this, Action handler)
	{
		return @this.OnItemSelected((EventHandler<NavigationBarView.ItemSelectedEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnItemSelected(this NavigationBarView @this, EventHandler<NavigationBarView.ItemSelectedEventArgs> handler)
	{
		@this.ItemSelected += handler;
		return Disposable.Create(delegate
		{
			@this.ItemSelected -= handler;
		});
	}
}
