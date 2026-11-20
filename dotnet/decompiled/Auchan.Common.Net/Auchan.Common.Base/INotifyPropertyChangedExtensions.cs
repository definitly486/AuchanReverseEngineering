using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;

namespace Auchan.Common.Base;

public static class INotifyPropertyChangedExtensions
{
	public static IDisposable OnPropertyChanged(this INotifyPropertyChanged @this, Action handler)
	{
		return @this.OnPropertyChanged((PropertyChangedEventHandler)delegate
		{
			handler();
		});
	}

	public static IDisposable OnPropertyChanged(this INotifyPropertyChanged @this, PropertyChangedEventHandler handler)
	{
		@this.PropertyChanged += handler;
		return Disposable.Create(delegate
		{
			@this.PropertyChanged -= handler;
		});
	}

	public static IDisposable OnPropertyChanged(this INotifyPropertyChanged @this, string propertyName, Action handler)
	{
		return @this.OnPropertyChanged(delegate(object? o, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == propertyName)
			{
				handler();
			}
		});
	}

	public static IDisposable OnPropertyChanged(this INotifyPropertyChanged @this, IEnumerable<string> propertyNames, Action handler)
	{
		return @this.OnPropertyChanged(delegate(object? o, PropertyChangedEventArgs e)
		{
			if (propertyNames.Any((string i) => i == e.PropertyName))
			{
				handler();
			}
		});
	}
}
