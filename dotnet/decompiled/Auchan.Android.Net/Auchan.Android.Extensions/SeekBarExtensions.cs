using System;
using System.Reactive.Disposables;
using Android.Widget;

namespace Auchan.Android.Extensions;

internal static class SeekBarExtensions
{
	public static IDisposable OnProgressChanged(this SeekBar @this, Action handler)
	{
		return @this.OnProgressChanged((EventHandler<SeekBar.ProgressChangedEventArgs>)delegate
		{
			handler();
		});
	}

	public static IDisposable OnProgressChanged(this SeekBar @this, EventHandler<SeekBar.ProgressChangedEventArgs> handler)
	{
		@this.ProgressChanged += handler;
		return Disposable.Create(delegate
		{
			@this.ProgressChanged -= handler;
		});
	}
}
