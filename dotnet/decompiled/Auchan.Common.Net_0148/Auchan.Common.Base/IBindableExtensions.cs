using System;
using System.Collections.Generic;
using System.Reactive.Disposables;

namespace Auchan.Common.Base;

public static class IBindableExtensions
{
	public static IDisposable BindEvents(this IBindable @this, params IDisposable[] @params)
	{
		return new CompositeDisposable(@params);
	}

	public static IDisposable BindProperties(this IBindable @this, IReadOnlyList<(Action, IReadOnlyList<string>)> bindings)
	{
		return @this.BindProperties(bindings);
	}

	public static IDisposable BindProperty(this IBindable @this, Action action, params string[] properties)
	{
		return @this.BindProperty(action, properties);
	}
}
