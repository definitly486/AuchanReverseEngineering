using System;
using System.Reactive.Disposables;
using Android.Widget;

namespace Auchan.Android.Extensions;

internal static class CompoundButtonExtensions
{
	public static IDisposable OnCheckedChange(this CompoundButton @this, Action handler)
	{
		return @this.OnCheckedChange((EventHandler<CompoundButton.CheckedChangeEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnCheckedChange(this CompoundButton @this, EventHandler<CompoundButton.CheckedChangeEventArgs> handler)
	{
		@this.CheckedChange += handler;
		return Disposable.Create(delegate
		{
			@this.CheckedChange -= handler;
		});
	}
}
