using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Java.Lang;

namespace ViewSparsedRecycler;

[Obsolete("due DAT-5559. Can produce crash on refresh, use ConcatAdapter or AutoLayout instead", true)]
public class ViewSparseRecyclerAdapter : RecyclerView.Adapter
{
	private class SparseViewHolder : RecyclerView.ViewHolder
	{
		private int _position = -1;

		public int InsertPosition { get; private set; }

		public new int Position
		{
			get
			{
				return _position;
			}
			internal set
			{
				PreviousPosition = _position;
				_position = value;
			}
		}

		public int PreviousPosition { get; set; } = -1;

		public Func<int> InsertPositionDelegate { get; }

		public int ViewType { get; }

		public int Priority { get; set; }

		public SparseViewHolder(View itemView, Func<int> positionDelegate, int uniqueViewType, int priority)
			: base(itemView)
		{
			ViewType = uniqueViewType;
			Priority = priority;
			InsertPositionDelegate = positionDelegate;
		}

		public void UpdateInsertPosition()
		{
			InsertPosition = InsertPositionDelegate();
		}
	}

	private readonly RecyclerView.Adapter _innerAdapter;

	private EventAdapterDataObserver? _innerAdapterDataObserver;

	private bool _isAttached;

	private int _latestAddedViewType = -100;

	private List<SparseViewHolder> _sparseViewHolders = new List<SparseViewHolder>();

	private List<int> _viewOrder = new List<int>();

	public new bool HasStableIds => _innerAdapter.HasStableIds;

	public override int ItemCount => _viewOrder.Count;

	public ViewSparseRecyclerAdapter(RecyclerView.Adapter adapter)
	{
		_innerAdapter = adapter ?? throw new ArgumentNullException("adapter");
	}

	public RecyclerView.ViewHolder AddView(View view, Func<int> insertPositionDelegate, int priority = 0)
	{
		if (view == null)
		{
			throw new ArgumentNullException("view", "No view");
		}
		if (insertPositionDelegate == null)
		{
			throw new ArgumentNullException("insertPositionDelegate", "Position delegate must be set");
		}
		if (_sparseViewHolders.Any((SparseViewHolder h) => h.ItemView == view))
		{
			throw new InvalidOperationException("View has already been added");
		}
		SparseViewHolder sparseViewHolder = new SparseViewHolder(view, insertPositionDelegate, --_latestAddedViewType, priority);
		_sparseViewHolders.Add(sparseViewHolder);
		if (_isAttached)
		{
			sparseViewHolder.UpdateInsertPosition();
			if (IsInAdapterRange(sparseViewHolder.InsertPosition))
			{
				UpdateViewOrder();
				NotifySparseViewAdded(sparseViewHolder);
			}
		}
		return sparseViewHolder;
	}

	public bool ContainsView(View view)
	{
		return _sparseViewHolders.Any((SparseViewHolder h) => h.ItemView == view);
	}

	public override long GetItemId(int position)
	{
		if (_viewOrder[position] >= 0)
		{
			return _innerAdapter.GetItemId(GetInnerAdapterPosition(position));
		}
		return _viewOrder[position];
	}

	public override int GetItemViewType(int position)
	{
		if (_viewOrder[position] >= 0)
		{
			return _innerAdapter.GetItemViewType(GetInnerAdapterPosition(position));
		}
		return _viewOrder[position];
	}

	public override void OnAttachedToRecyclerView(RecyclerView recyclerView)
	{
		UpdateViewOrder();
		_innerAdapter.OnAttachedToRecyclerView(recyclerView);
		_isAttached = true;
	}

	public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
	{
		if (!(holder is SparseViewHolder))
		{
			int innerAdapterPosition = GetInnerAdapterPosition(position);
			_innerAdapter.OnBindViewHolder(holder, innerAdapterPosition);
		}
	}

	public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position, IList<Java.Lang.Object> payloads)
	{
		if (!(holder is SparseViewHolder))
		{
			int innerAdapterPosition = GetInnerAdapterPosition(position);
			_innerAdapter.OnBindViewHolder(holder, innerAdapterPosition, payloads);
		}
	}

	public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
	{
		if (viewType < 0)
		{
			return _sparseViewHolders.First((SparseViewHolder d) => d.ViewType == viewType);
		}
		return _innerAdapter.OnCreateViewHolder(parent, viewType);
	}

	public override void OnDetachedFromRecyclerView(RecyclerView recyclerView)
	{
		_innerAdapter.OnDetachedFromRecyclerView(recyclerView);
		_isAttached = false;
	}

	public override bool OnFailedToRecycleView(Java.Lang.Object holder)
	{
		if (holder is SparseViewHolder)
		{
			return false;
		}
		return _innerAdapter.OnFailedToRecycleView(holder);
	}

	public override void OnViewAttachedToWindow(Java.Lang.Object holder)
	{
		if (!(holder is SparseViewHolder))
		{
			_innerAdapter.OnViewAttachedToWindow(holder);
		}
	}

	public override void OnViewDetachedFromWindow(Java.Lang.Object holder)
	{
		if (!(holder is SparseViewHolder))
		{
			_innerAdapter.OnViewDetachedFromWindow(holder);
		}
	}

	public override void OnViewRecycled(Java.Lang.Object holder)
	{
		if (!(holder is SparseViewHolder))
		{
			_innerAdapter.OnViewRecycled(holder);
		}
	}

	public override void RegisterAdapterDataObserver(RecyclerView.AdapterDataObserver observer)
	{
		if (!base.HasObservers)
		{
			base.HasStableIds = HasStableIds;
			SubscribeInnerAdapter();
		}
		base.RegisterAdapterDataObserver(observer);
	}

	public void RemoveView(View view)
	{
		SparseViewHolder sparseViewHolder = _sparseViewHolders.Find((SparseViewHolder h) => h.ItemView == view);
		if (sparseViewHolder != null)
		{
			_sparseViewHolders.Remove(sparseViewHolder);
			if (_isAttached && _viewOrder.Contains(sparseViewHolder.ViewType))
			{
				UpdateViewOrder();
				NotifySparseViewRemoved(sparseViewHolder);
			}
		}
	}

	public override void UnregisterAdapterDataObserver(RecyclerView.AdapterDataObserver observer)
	{
		base.UnregisterAdapterDataObserver(observer);
		if (!base.HasObservers)
		{
			UnsubscribeInnerAdapter();
		}
	}

	public void UpdateViewPosition(View view)
	{
		SparseViewHolder sparseViewHolder = _sparseViewHolders.Find((SparseViewHolder h) => h.ItemView == view) ?? throw new ArgumentException("View is not present in adapter", "view");
		int insertPosition = sparseViewHolder.InsertPosition;
		sparseViewHolder.UpdateInsertPosition();
		int insertPosition2 = sparseViewHolder.InsertPosition;
		if (insertPosition != insertPosition2 && (IsHolderUsed(sparseViewHolder) || WillHolderBeUsed(sparseViewHolder)))
		{
			UpdateViewOrder();
			NotifySparseViewPositionChanges();
		}
	}

	private int GetAdjustedPosition(int innerAdapterPosition)
	{
		return _viewOrder.IndexOf(innerAdapterPosition, innerAdapterPosition);
	}

	public int GetInnerAdapterPosition(int position)
	{
		return _viewOrder[position];
	}

	private bool IsHolderUsed(SparseViewHolder holder)
	{
		return _viewOrder.Contains(holder.ViewType);
	}

	private bool IsInAdapterRange(int holderInsertPosition)
	{
		if (_innerAdapter.ItemCount != 0)
		{
			if (holderInsertPosition < 0 || holderInsertPosition > _innerAdapter.ItemCount)
			{
				return holderInsertPosition == 2;
			}
			return true;
		}
		return false;
	}

	private void NotifySparseViewAdded(SparseViewHolder newHolder)
	{
		int newHolderInsertPosition = newHolder.InsertPosition;
		if (IsInAdapterRange(newHolderInsertPosition))
		{
			int position = _viewOrder.IndexOf(newHolder.ViewType);
			SparseViewHolder sparseViewHolder = _sparseViewHolders.Where((SparseViewHolder h) => h != newHolder).LastOrDefault((SparseViewHolder h) => h.InsertPosition == newHolderInsertPosition);
			if (sparseViewHolder == null)
			{
				NotifyItemInserted(position);
			}
			else if (sparseViewHolder.Position != -1)
			{
				sparseViewHolder.Position = -1;
				NotifyItemChanged(position);
			}
		}
	}

	private void NotifySparseViewPositionChanges()
	{
		foreach (SparseViewHolder sparseViewHolder2 in _sparseViewHolders)
		{
			int previousPosition = sparseViewHolder2.PreviousPosition;
			int newPosition = sparseViewHolder2.Position;
			bool flag = previousPosition != -1;
			bool flag2 = newPosition != -1;
			if (previousPosition == newPosition || newPosition == sparseViewHolder2.AdapterPosition || (!flag && !flag2))
			{
				continue;
			}
			SparseViewHolder sparseViewHolder = _sparseViewHolders.Find((SparseViewHolder h) => h.PreviousPosition == newPosition);
			bool flag3 = _viewOrder.ElementAtOrDefault(previousPosition) < 0;
			bool flag4 = sparseViewHolder != null && sparseViewHolder.Position == -1;
			if (flag && !flag3 && flag2 && !flag4)
			{
				NotifyItemMoved(previousPosition, newPosition);
			}
			else if (flag && !flag2)
			{
				NotifyItemRemoved(previousPosition);
			}
			else if (!flag && flag2)
			{
				if (flag4)
				{
					NotifyItemChanged(newPosition);
				}
				else
				{
					NotifyItemInserted(newPosition);
				}
			}
		}
	}

	private void NotifySparseViewRemoved(SparseViewHolder deletedHolder)
	{
		if (deletedHolder.Position != -1)
		{
			if (_viewOrder.Count > deletedHolder.Position && _viewOrder[deletedHolder.Position] < 0)
			{
				NotifyItemChanged(deletedHolder.Position);
			}
			else
			{
				NotifyItemRemoved(deletedHolder.Position);
			}
		}
	}

	private void OnInnerAdapterDataSourceChanged(object sender, EventArgs e)
	{
		UpdateViewOrder();
		NotifyDataSetChanged();
	}

	private void OnInnerAdapterItemRangeChanged(object sender, EventAdapterDataObserver.ItemRangeChangedEventArgs e)
	{
		int adjustedPosition = GetAdjustedPosition(e.PositionStart);
		int itemCount = (from p in _viewOrder.Skip(adjustedPosition)
			where p >= 0
			select p).TakeWhile((int p) => p < e.PositionStart + e.ItemCount).Count();
		NotifyItemRangeChanged(adjustedPosition, itemCount);
		UpdateViewOrder();
		NotifySparseViewPositionChanges();
	}

	private async void OnInnerAdapterItemRangeInserted(object sender, EventAdapterDataObserver.ItemRangeInsertedEventArgs e)
	{
		InsertInnerAdapterItemsIntoViewOrder(e.PositionStart, e.ItemCount);
		int adjustedPosition = GetAdjustedPosition(e.PositionStart);
		NotifyItemRangeInserted(adjustedPosition, e.ItemCount);
		foreach (int holderType in from i in _viewOrder.Skip(adjustedPosition)
			where i < 0
			select i)
		{
			_sparseViewHolders.Find((SparseViewHolder h) => h.ViewType == holderType).Position += e.ItemCount;
		}
		await Task.Delay(300);
		NotifySparseViewPositionChanges();
	}

	private void InsertInnerAdapterItemsIntoViewOrder(int startPosition, int itemCount)
	{
		int num = GetAdjustedPosition(startPosition);
		if (num == -1)
		{
			if (startPosition == 0)
			{
				num = ((_viewOrder.Count > 0 && _sparseViewHolders.Find((SparseViewHolder d) => d.ViewType == _viewOrder[0]).InsertPosition == 0) ? 1 : 0);
			}
			else if (startPosition > 0)
			{
				num = GetAdjustedPosition(startPosition - 1) + 1;
			}
		}
		if (_sparseViewHolders.Count != 0 && _viewOrder.Count == 0)
		{
			foreach (SparseViewHolder sparseViewHolder in _sparseViewHolders)
			{
				_viewOrder.Add(sparseViewHolder.ViewType);
			}
			_viewOrder.InsertRange(num + _sparseViewHolders.Count, Enumerable.Range(startPosition, itemCount));
			return;
		}
		_viewOrder.InsertRange(num, Enumerable.Range(startPosition, itemCount));
		for (int num2 = num + itemCount; num2 < _viewOrder.Count; num2++)
		{
			if (_viewOrder[num2] >= 0)
			{
				_viewOrder[num2] += itemCount;
			}
		}
	}

	private void OnInnerAdapterItemRangeMoved(object sender, EventAdapterDataObserver.ItemRangeMovedEventArgs e)
	{
		int adjustedPosition = GetAdjustedPosition(e.FromPosition);
		int adjustedPosition2 = GetAdjustedPosition(e.ToPosition);
		NotifyItemMoved(adjustedPosition, adjustedPosition2);
		UpdateViewOrder();
		NotifySparseViewPositionChanges();
	}

	private void OnInnerAdapterItemRangeRemoved(object sender, EventAdapterDataObserver.ItemRangeRemovedEventArgs e)
	{
		int adjustedPosition = GetAdjustedPosition(e.PositionStart);
		NotifyItemRangeRemoved(adjustedPosition, e.ItemCount);
		foreach (int holderType in from i in _viewOrder.Skip(adjustedPosition + e.ItemCount)
			where i < 0
			select i)
		{
			_sparseViewHolders.Find((SparseViewHolder h) => h.ViewType == holderType).Position -= e.ItemCount;
		}
		UpdateViewOrder();
		NotifySparseViewPositionChanges();
	}

	private void SubscribeInnerAdapter()
	{
		_innerAdapterDataObserver = new EventAdapterDataObserver(_innerAdapter);
		_innerAdapterDataObserver.Changed += OnInnerAdapterDataSourceChanged;
		_innerAdapterDataObserver.ItemRangeChanged += OnInnerAdapterItemRangeChanged;
		_innerAdapterDataObserver.ItemRangeInserted += OnInnerAdapterItemRangeInserted;
		_innerAdapterDataObserver.ItemRangeMoved += OnInnerAdapterItemRangeMoved;
		_innerAdapterDataObserver.ItemRangeRemoved += OnInnerAdapterItemRangeRemoved;
		_innerAdapter.RegisterAdapterDataObserver(_innerAdapterDataObserver);
	}

	private void UnsubscribeInnerAdapter()
	{
		if (_innerAdapterDataObserver != null)
		{
			_innerAdapterDataObserver.Changed -= OnInnerAdapterDataSourceChanged;
			_innerAdapterDataObserver.ItemRangeChanged -= OnInnerAdapterItemRangeChanged;
			_innerAdapterDataObserver.ItemRangeInserted -= OnInnerAdapterItemRangeInserted;
			_innerAdapterDataObserver.ItemRangeMoved -= OnInnerAdapterItemRangeMoved;
			_innerAdapterDataObserver.ItemRangeRemoved -= OnInnerAdapterItemRangeRemoved;
			_innerAdapter.UnregisterAdapterDataObserver(_innerAdapterDataObserver);
		}
	}

	private void UpdateViewOrder()
	{
		_viewOrder.Clear();
		_sparseViewHolders.ForEach(delegate(SparseViewHolder h)
		{
			h.UpdateInsertPosition();
		});
		List<SparseViewHolder> list = (from x in _sparseViewHolders.Where((SparseViewHolder h) => IsInAdapterRange(h.InsertPosition)).GroupBy((SparseViewHolder h) => h.InsertPosition, (int position, IEnumerable<SparseViewHolder> holders) => holders.First())
			orderby x.InsertPosition
			select x).ToList();
		int num = 0;
		int num2 = _innerAdapter.ItemCount + list.Count;
		foreach (SparseViewHolder item2 in _sparseViewHolders.Except(list))
		{
			item2.Position = -1;
		}
		int i;
		for (i = 0; i < num2; i++)
		{
			int item = i - num;
			SparseViewHolder sparseViewHolder = list.Find((SparseViewHolder h) => h.InsertPosition == i);
			if (sparseViewHolder != null)
			{
				sparseViewHolder.Position = i;
				item = sparseViewHolder.ViewType;
				list.Remove(sparseViewHolder);
				num++;
			}
			_viewOrder.Add(item);
		}
	}

	private bool WillHolderBeUsed(SparseViewHolder holder)
	{
		if (IsInAdapterRange(holder.InsertPosition))
		{
			return _sparseViewHolders.Where((SparseViewHolder h) => IsInAdapterRange(h.InsertPosition)).Last((SparseViewHolder h) => h.InsertPosition == holder.InsertPosition) == holder;
		}
		return false;
	}
}
