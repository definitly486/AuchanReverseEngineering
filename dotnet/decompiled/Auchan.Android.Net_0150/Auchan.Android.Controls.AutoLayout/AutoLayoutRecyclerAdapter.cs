using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Disposables;
using Android.Content;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Common.Controls.AutoLayout;
using Auchan.Common.Extensions;
using Java.Lang;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Controls.AutoLayout;

public class AutoLayoutRecyclerAdapter : RecyclerView.Adapter
{
	private readonly LayoutInflater _layoutInflater;

	private readonly ObservableRangeCollection<AutoLayoutViewModel.AutoLayoutElement> _layoutElements;

	private readonly Action<AutoLayoutViewModel.AutoLayoutElement, int, CachingViewHolder, CompositeDisposable> _bindCallback;

	private RecyclerView? _recyclerView;

	private readonly IDictionary<CachingViewHolder, CompositeDisposable> _disposables = new Dictionary<CachingViewHolder, CompositeDisposable>();

	private int _viewTypeMaxValue;

	private readonly Dictionary<int, string> _viewTypeMap = new Dictionary<int, string>();

	public override int ItemCount => _layoutElements.Count;

	public AutoLayoutRecyclerAdapter(Context context, AutoLayoutViewModel viewModel, Action<AutoLayoutViewModel.AutoLayoutElement, int, CachingViewHolder, CompositeDisposable> bindCallback)
	{
		_layoutInflater = LayoutInflater.From(context);
		_layoutElements = viewModel.Elements;
		_bindCallback = bindCallback;
		UpdateViewTypeMap();
		_layoutElements.CollectionChanged += HandleCollectionChanged;
		NotifyDataSetChanged();
	}

	public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
	{
		if (!(holder is CachingViewHolder cachingViewHolder))
		{
			throw new ArgumentException("Must use caching view holder");
		}
		_disposables.TryGetValue(cachingViewHolder, out CompositeDisposable value);
		value?.Dispose();
		value = new CompositeDisposable();
		_disposables[cachingViewHolder] = value;
		_bindCallback(_layoutElements.ElementAt(position), position, cachingViewHolder, value);
	}

	public override int GetItemViewType(int position)
	{
		return _viewTypeMap.First<KeyValuePair<int, string>>((KeyValuePair<int, string> kvp) => kvp.Value == _layoutElements.ElementAt(position).Type).Key;
	}

	public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
	{
		string type = _viewTypeMap[viewType];
		View view = _layoutInflater.Inflate(AutoLayoutViewMapper.GetLayoutIdByType(type), parent, attachToRoot: false);
		if (view == null)
		{
			throw new ArgumentException($"can't create view by viewType == {viewType}");
		}
		return AutoLayoutViewMapper.NewViewHolderByType(type, view);
	}

	public override void OnAttachedToRecyclerView(RecyclerView recyclerView)
	{
		base.OnAttachedToRecyclerView(recyclerView);
		_recyclerView = recyclerView;
	}

	public override void OnDetachedFromRecyclerView(RecyclerView recyclerView)
	{
		base.OnDetachedFromRecyclerView(recyclerView);
		_recyclerView = null;
	}

	public override void OnViewRecycled(Java.Lang.Object holder)
	{
		base.OnViewRecycled(holder);
		if (holder is CachingViewHolder key && _disposables.TryGetValue(key, out CompositeDisposable value))
		{
			value.Dispose();
			_disposables.Remove(key);
		}
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (disposing)
		{
			_layoutElements.CollectionChanged -= HandleCollectionChanged;
		}
		_disposables.Values.ForEach(delegate(CompositeDisposable d)
		{
			d.Dispose();
		});
		_disposables.Clear();
	}

	private void HandleCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		UpdateViewTypeMap();
		MainThread.BeginInvokeOnMainThread(delegate
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
			{
				int num4;
				if (e.NewStartingIndex == 0)
				{
					RecyclerView? recyclerView = _recyclerView;
					num4 = ((recyclerView != null && recyclerView.ComputeVerticalScrollOffset() == 0) ? 1 : 0);
				}
				else
				{
					num4 = 0;
				}
				NotifyItemRangeInserted(e.NewStartingIndex, e.NewItems.Count);
				if (num4 != 0)
				{
					_recyclerView.ScrollToPosition(0);
				}
				break;
			}
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

	private void UpdateViewTypeMap()
	{
		_layoutElements.Select((AutoLayoutViewModel.AutoLayoutElement le) => le.Type).Distinct().ForEach(delegate(string type)
		{
			if (!_viewTypeMap.ContainsValue(type))
			{
				_viewTypeMap[_viewTypeMaxValue++] = type;
			}
		});
	}
}
