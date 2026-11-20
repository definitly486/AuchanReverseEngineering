using System;
using System.Reactive;
using System.Reactive.Linq;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;

namespace Auchan.Android.Extensions;

public static class RxExtensions
{
	public static IObservable<EventPattern<EventArgs>> RxClick(this View view)
	{
		return Observable.FromEventPattern<EventHandler, EventArgs>(delegate(EventHandler handler)
		{
			view.Click += handler;
		}, delegate(EventHandler handler)
		{
			view.Click -= handler;
		});
	}

	public static IObservable<EventPattern<View.FocusChangeEventArgs>> RxFocusChange(this View view)
	{
		return Observable.FromEventPattern(delegate(EventHandler<View.FocusChangeEventArgs> handler)
		{
			view.FocusChange += handler;
		}, delegate(EventHandler<View.FocusChangeEventArgs> handler)
		{
			view.FocusChange -= handler;
		});
	}

	public static IObservable<EventPattern<CompoundButton.CheckedChangeEventArgs>> RxValueChanged(this SwitchCompat switcher)
	{
		return Observable.FromEventPattern(delegate(EventHandler<CompoundButton.CheckedChangeEventArgs> h)
		{
			switcher.CheckedChange += h;
		}, delegate(EventHandler<CompoundButton.CheckedChangeEventArgs> h)
		{
			switcher.CheckedChange -= h;
		});
	}
}
