using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive.Disposables;
using EBind;

namespace Auchan.Common.Extensions;

public static class ObservableCollectionExtensions
{
	public static ReadOnlyObservableCollection<T> AsReadOnly<T>(this ObservableCollection<T> source)
	{
		return new ReadOnlyObservableCollection<T>(source);
	}

	public static void SetState<T>(this ObservableCollection<T> @this, IReadOnlyList<T> targetState) where T : IEquatable<T>
	{
		T val2;
		for (int i = 0; i < @this.Count; i++)
		{
			T val = @this[i];
			bool flag = false;
			for (int j = 0; j < targetState.Count; j++)
			{
				ref T reference = ref val;
				val2 = default(T);
				if (val2 == null)
				{
					val2 = reference;
					reference = ref val2;
				}
				T other = targetState[j];
				if (reference.Equals(other))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				@this.RemoveAt(i--);
			}
		}
		for (int k = 0; k < targetState.Count; k++)
		{
			T val3 = targetState[k];
			bool flag2 = false;
			for (int l = 0; l < @this.Count; l++)
			{
				val2 = @this[l];
				if (val2.Equals(val3))
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				@this.Insert(k, val3);
			}
		}
		for (int m = 0; m < @this.Count; m++)
		{
			T other2 = @this[m];
			for (int n = 0; n < targetState.Count; n++)
			{
				if (m != n)
				{
					val2 = targetState[n];
					if (val2.Equals(other2))
					{
						@this.Move(m, n);
					}
				}
			}
		}
	}

	public static void SubscribeToCollectionChanged(this INotifyCollectionChanged collection, Action<NotifyCollectionChangedEventArgs> action, ICollection<IDisposable> disposables)
	{
		collection.CollectionChanged += new DisposableDelegate<NotifyCollectionChangedEventHandler>(delegate(object? o, NotifyCollectionChangedEventArgs e)
		{
			action(e);
		}, delegate(NotifyCollectionChangedEventHandler eh)
		{
			collection.CollectionChanged -= eh;
		}).AddTo(disposables);
	}

	public static IDisposable OnCollectionChanged(this INotifyCollectionChanged @this, Action hander)
	{
		return @this.OnCollectionChanged((NotifyCollectionChangedEventHandler)delegate
		{
			hander();
		});
	}

	public static IDisposable OnCollectionChanged(this INotifyCollectionChanged @this, NotifyCollectionChangedEventHandler hander)
	{
		@this.CollectionChanged += hander;
		return Disposable.Create(delegate
		{
			@this.CollectionChanged -= hander;
		});
	}
}
