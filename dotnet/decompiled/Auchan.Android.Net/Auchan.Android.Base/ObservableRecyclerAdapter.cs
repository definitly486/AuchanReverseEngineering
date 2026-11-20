using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Disposables;
using System.Reflection;
using Android.Runtime;
using Android.Views;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using Java.Interop;
using Java.Lang;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Base;

public class ObservableRecyclerAdapter<TItem, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THolder> : RecyclerView.Adapter, ILifecycleEventObserver, ILifecycleObserver, IJavaObject, IDisposable, IJavaPeerable, View.IOnAttachStateChangeListener where THolder : notnull, RecyclerView.ViewHolder
{
	private IReadOnlyList<TItem>? _dataSource;

	private INotifyCollectionChanged? _notifier;

	private readonly IDictionary<RecyclerView.ViewHolder, CompositeDisposable> _holderDisposables = new Dictionary<RecyclerView.ViewHolder, CompositeDisposable>();

	public Action<THolder, TItem, int, CompositeDisposable>? BindViewHolderDelegate { get; set; }

	public int CellLayoutId { get; set; }

	public Action<THolder, TItem, int>? ClickCallback { get; set; }

	public Func<ViewGroup, int, THolder>? CreateViewHolderDelegate { get; set; }

	public Func<int, int>? GetItemViewTypeDelegate { get; set; }

	public Func<int, TItem, long>? GetItemIdDelegate { get; set; }

	public IReadOnlyList<TItem>? DataSource
	{
		get
		{
			return _dataSource;
		}
		set
		{
			if (!object.Equals(_dataSource, value))
			{
				if (_notifier != null)
				{
					_notifier.CollectionChanged -= HandleCollectionChanged;
				}
				_dataSource = value;
				_notifier = value as INotifyCollectionChanged;
				if (_notifier != null)
				{
					_notifier.CollectionChanged += HandleCollectionChanged;
				}
				NotifyDataSetChanged();
			}
		}
	}

	public override int ItemCount
	{
		get
		{
			if (_dataSource != null)
			{
				return _dataSource.Count;
			}
			return 0;
		}
	}

	public TItem this[int position] => _dataSource[position];

	public override long GetItemId(int position)
	{
		return GetItemIdDelegate?.Invoke(position, this[position]) ?? 0;
	}

	public TItem GetItem(int position)
	{
		return this[position];
	}

	public override void OnViewRecycled(Java.Lang.Object holder)
	{
		base.OnViewRecycled(holder);
		if (holder is RecyclerView.ViewHolder key && _holderDisposables.TryGetValue(key, out CompositeDisposable value))
		{
			value.Dispose();
			_holderDisposables.Remove(key);
		}
	}

	public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
	{
		if (BindViewHolderDelegate == null)
		{
			throw new InvalidOperationException("OnBindViewHolder was called but no BindViewHolderDelegate was found");
		}
		_holderDisposables.TryGetValue(holder, out CompositeDisposable value);
		value?.Dispose();
		value = new CompositeDisposable();
		_holderDisposables[holder] = value;
		BindViewHolderDelegate((THolder)holder, this[position], position, value);
	}

	public override int GetItemViewType(int position)
	{
		if (GetItemViewTypeDelegate == null)
		{
			return 0;
		}
		return GetItemViewTypeDelegate(position);
	}

	public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
	{
		THolder holder;
		if (CellLayoutId != 0)
		{
			Type typeFromHandle = typeof(THolder);
			ConstructorInfo constructor = typeFromHandle.GetConstructor(new Type[1] { typeof(View) });
			if (constructor == null)
			{
				throw new InvalidOperationException("No suitable constructor found for " + typeFromHandle.FullName);
			}
			View view = LayoutInflater.From(parent.Context).Inflate(CellLayoutId, parent, attachToRoot: false);
			holder = (THolder)constructor.Invoke(new object[1] { view });
		}
		else
		{
			if (CreateViewHolderDelegate == null)
			{
				throw new InvalidOperationException("OnCreateViewHolder was called but no CreateViewHolderDelegate or CellLayoutId was found");
			}
			holder = CreateViewHolderDelegate(parent, viewType);
		}
		if (holder == null)
		{
			throw new InvalidOperationException("Could not create a view holder");
		}
		holder.ItemView.Click += delegate
		{
			OnItemClick(holder, holder.AdapterPosition);
		};
		return holder;
	}

	public void OnItemClick(THolder holder, int position)
	{
		if (ClickCallback != null && position != -1 && position <= ItemCount - 1)
		{
			ClickCallback(holder, GetItem(position), position);
		}
	}

	private void HandleCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		MainThread.BeginInvokeOnMainThread(delegate
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				NotifyItemRangeInserted(e.NewStartingIndex, e.NewItems.Count);
				break;
			case NotifyCollectionChangedAction.Remove:
				NotifyItemRangeRemoved(e.OldStartingIndex, e.OldItems.Count);
				break;
			case NotifyCollectionChangedAction.Replace:
			{
				int num = e.OldItems?.Count ?? 0;
				int num2 = e.NewItems?.Count ?? 0;
				int num3 = System.Math.Min(num, num2);
				if (num > num3)
				{
					NotifyItemRangeRemoved(e.OldStartingIndex + num3, num - num3);
				}
				else if (num2 > num3)
				{
					NotifyItemRangeInserted(e.OldStartingIndex + num3, num2 - num3);
				}
				if (num3 != 0)
				{
					NotifyItemRangeChanged(e.OldStartingIndex, num3);
				}
				break;
			}
			default:
				NotifyDataSetChanged();
				break;
			}
		});
	}

	private void DisposeViewHoldersInternal()
	{
		if (_notifier != null)
		{
			_notifier.CollectionChanged -= HandleCollectionChanged;
		}
		foreach (CompositeDisposable value in _holderDisposables.Values)
		{
			if (!value.IsDisposed)
			{
				value.Dispose();
			}
		}
		_holderDisposables.Clear();
	}

	public IDisposable DisposeViewHolders()
	{
		return Disposable.Create(this, delegate(ObservableRecyclerAdapter<TItem, THolder> i)
		{
			i.DisposeViewHoldersInternal();
		});
	}

	public override void OnAttachedToRecyclerView(RecyclerView recyclerView)
	{
		base.OnAttachedToRecyclerView(recyclerView);
		if (!recyclerView.IsAttachedToWindow)
		{
			recyclerView.AddOnAttachStateChangeListener(this);
		}
		else
		{
			ViewTreeLifecycleOwner.Get(recyclerView).Lifecycle.AddObserver(this);
		}
	}

	public override void OnDetachedFromRecyclerView(RecyclerView recyclerView)
	{
		base.OnDetachedFromRecyclerView(recyclerView);
		ViewTreeLifecycleOwner.Get(recyclerView)?.Lifecycle.RemoveObserver(this);
		DisposeViewHoldersInternal();
	}

	public void OnStateChanged(ILifecycleOwner source, Lifecycle.Event e)
	{
		if (e == Lifecycle.Event.OnDestroy)
		{
			source.Lifecycle.RemoveObserver(this);
			DisposeViewHoldersInternal();
		}
	}

	public void OnViewAttachedToWindow(View attachedView)
	{
		ILifecycleOwner? lifecycleOwner = ViewTreeLifecycleOwner.Get(attachedView);
		lifecycleOwner.Lifecycle.RemoveObserver(this);
		lifecycleOwner.Lifecycle.AddObserver(this);
	}

	public void OnViewDetachedFromWindow(View detachedView)
	{
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
