using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection;

namespace Auchan.Common.Extensions;

public static class RxExtensions
{
	public static T AddTo<T>(this T disposable, ICollection<IDisposable> container) where T : IDisposable
	{
		container.Add(disposable);
		return disposable;
	}

	public static IObservable<TSource2> Concat<TSource, TSource2>(this IObservable<TSource> source, IObservable<TSource2> source2)
	{
		return Observable.Concat(from _ in source.IgnoreElements()
			select default(TSource2), source2);
	}

	public static IObservable<T> Debounce<T>(this IObservable<T> source, TimeSpan interval)
	{
		DateTime last = DateTime.MinValue;
		return source.Where((T _) => DateTime.UtcNow >= last + interval).Do(delegate
		{
			last = DateTime.UtcNow;
		});
	}

	public static IObservable<T> Debounce<T>(this IObservable<T> source, int intervalMs = 300)
	{
		return source.Debounce(TimeSpan.FromMilliseconds(intervalMs));
	}

	public static IObservable<T> SkipFirst<T>(this IObservable<T> source)
	{
		return source.Skip(1);
	}

	public static IObservable<TProperty> OnPropertyChanges<T, TProperty>(this T source, Expression<Func<T, TProperty>> property) where T : INotifyPropertyChanged
	{
		MemberExpression memberExpression = (MemberExpression)property.Body;
		PropertyInfo propertyInfo = (PropertyInfo)memberExpression.Member;
		string propertyName = propertyInfo.Name;
		return from _ in Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(delegate(PropertyChangedEventHandler h)
			{
				source.PropertyChanged += h;
			}, delegate(PropertyChangedEventHandler h)
			{
				source.PropertyChanged -= h;
			})
			where _.EventArgs.PropertyName == propertyName
			select (TProperty)propertyInfo.GetValue(source);
	}

	public static IObservable<T> StartWithIf<T>(this IObservable<T> observable, bool condition, params T[] values)
	{
		if (condition)
		{
			return observable.StartWith(values);
		}
		return observable;
	}

	public static void DisposeAll(this IEnumerable<IDisposable> disposables)
	{
		foreach (IDisposable disposable in disposables)
		{
			disposable?.Dispose();
		}
	}

	public static IObservable<T> StartWithDefault<T>(this IObservable<T> observable) where T : struct
	{
		return observable.StartWith(default(T));
	}
}
