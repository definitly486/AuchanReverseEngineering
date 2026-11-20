using System;
using System.Linq;
using System.Reactive.Disposables;
using Android.Views;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;

namespace Auchan.Android.Extensions;

internal static class IBindableExtensions
{
	public static IDisposable ConnectClickCommands(this IBindable @this, params (View view, UICommand command)[] @params)
	{
		return ConnectClickCommands(@params);
	}

	public static IDisposable ConnectClickCommands(params (View view, UICommand command)[] @params)
	{
		return new CompositeDisposable(@params.Select(((View view, UICommand command) i) => i.view.OnClick((EventHandler)delegate
		{
			i.command.Trigger();
		})));
	}

	public static IDisposable ConnectClickEvents(this IBindable @this, params (View view, Action handler)[] @params)
	{
		return ConnectClickEvents(@params);
	}

	public static IDisposable ConnectClickEvents(params (View view, Action handler)[] @params)
	{
		return new CompositeDisposable(@params.Select(((View view, Action handler) i) => i.view.OnClick((EventHandler)delegate
		{
			i.handler();
		})));
	}
}
