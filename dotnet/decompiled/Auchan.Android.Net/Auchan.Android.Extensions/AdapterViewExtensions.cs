using System;
using System.Reactive.Disposables;
using Android.Widget;

namespace Auchan.Android.Extensions;

internal static class AdapterViewExtensions
{
	public static IDisposable OnItemSelected(this AdapterView @this, Action handler)
	{
		return @this.OnItemSelected((EventHandler<AdapterView.ItemSelectedEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnItemSelected(this AdapterView @this, EventHandler<AdapterView.ItemSelectedEventArgs> handler)
	{
		@this.ItemSelected += handler;
		return Disposable.Create(delegate
		{
			@this.ItemSelected -= handler;
		});
	}
}
