using System;
using System.Reactive.Disposables;
using Android.Widget;

namespace Auchan.Android.Extensions;

internal static class RadioGroupExtensions
{
	public static IDisposable OnCheckedChange(this RadioGroup @this, Action handler)
	{
		return @this.OnCheckedChange((EventHandler<RadioGroup.CheckedChangeEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnCheckedChange(this RadioGroup @this, EventHandler<RadioGroup.CheckedChangeEventArgs> handler)
	{
		@this.CheckedChange += handler;
		return Disposable.Create(delegate
		{
			@this.CheckedChange -= handler;
		});
	}
}
