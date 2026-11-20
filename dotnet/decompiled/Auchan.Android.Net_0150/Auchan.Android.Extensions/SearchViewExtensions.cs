using System;
using System.Reactive.Disposables;
using AndroidX.AppCompat.Widget;

namespace Auchan.Android.Extensions;

internal static class SearchViewExtensions
{
	public static IDisposable OnQueryTextChange(this SearchView @this, Action handler)
	{
		return @this.OnQueryTextChange((EventHandler<SearchView.QueryTextChangeEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnQueryTextChange(this SearchView @this, EventHandler<SearchView.QueryTextChangeEventArgs> handler)
	{
		@this.QueryTextChange += handler;
		return Disposable.Create(delegate
		{
			@this.QueryTextChange -= handler;
		});
	}
}
