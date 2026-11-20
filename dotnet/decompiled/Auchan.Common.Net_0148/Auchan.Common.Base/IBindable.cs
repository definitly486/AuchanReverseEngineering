using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Base;

public interface IBindable : INotifyPropertyChanged
{
	sealed IDisposable BindProperties(IReadOnlyList<(Action, IReadOnlyList<string>)> bindings)
	{
		CompositeDisposable result = new CompositeDisposable(bindings.Select<(Action, IReadOnlyList<string>), IDisposable>(((Action, IReadOnlyList<string>) b) => BindProperty(b.Item1, b.Item2)));
		foreach (var binding in bindings)
		{
			var (action, _) = binding;
			MainThread.BeginInvokeOnMainThread(delegate
			{
				action();
			});
		}
		return result;
	}

	sealed IDisposable BindProperty(Action action, IReadOnlyList<string> properties)
	{
		return new CompositeDisposable(properties.Select((string p) => this.OnPropertyChanged(delegate(object? o, PropertyChangedEventArgs e)
		{
			if (properties.Contains<string>(e.PropertyName))
			{
				MainThread.BeginInvokeOnMainThread(delegate
				{
					action();
				});
			}
		})));
	}
}
