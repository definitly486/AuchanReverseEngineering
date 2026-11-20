using System;
using AndroidX.RecyclerView.Widget;
using Java.Lang;

namespace ViewSparsedRecycler;

internal class EventAdapterDataObserver : RecyclerView.AdapterDataObserver
{
	public class ItemRangeChangedEventArgs
	{
		public int ItemCount { get; set; }

		public Java.Lang.Object? Payload { get; set; }

		public int PositionStart { get; set; }
	}

	public class ItemRangeInsertedEventArgs
	{
		public int ItemCount { get; set; }

		public int PositionStart { get; set; }
	}

	public class ItemRangeMovedEventArgs
	{
		public int FromPosition { get; set; }

		public int ItemCount { get; set; }

		public int ToPosition { get; set; }
	}

	public class ItemRangeRemovedEventArgs
	{
		public int ItemCount { get; set; }

		public int PositionStart { get; set; }
	}

	private readonly RecyclerView.Adapter _adapter;

	public event EventHandler? Changed;

	public event EventHandler<ItemRangeChangedEventArgs>? ItemRangeChanged;

	public event EventHandler<ItemRangeInsertedEventArgs>? ItemRangeInserted;

	public event EventHandler<ItemRangeMovedEventArgs>? ItemRangeMoved;

	public event EventHandler<ItemRangeRemovedEventArgs>? ItemRangeRemoved;

	public EventAdapterDataObserver(RecyclerView.Adapter adapter)
	{
		_adapter = adapter;
	}

	public override void OnChanged()
	{
		this.Changed?.Invoke(_adapter, EventArgs.Empty);
	}

	public override void OnItemRangeChanged(int positionStart, int itemCount)
	{
		this.ItemRangeChanged?.Invoke(_adapter, new ItemRangeChangedEventArgs
		{
			PositionStart = positionStart,
			ItemCount = itemCount
		});
	}

	public override void OnItemRangeChanged(int positionStart, int itemCount, Java.Lang.Object payload)
	{
		this.ItemRangeChanged?.Invoke(_adapter, new ItemRangeChangedEventArgs
		{
			PositionStart = positionStart,
			ItemCount = itemCount,
			Payload = payload
		});
	}

	public override void OnItemRangeInserted(int positionStart, int itemCount)
	{
		this.ItemRangeInserted?.Invoke(_adapter, new ItemRangeInsertedEventArgs
		{
			PositionStart = positionStart,
			ItemCount = itemCount
		});
	}

	public override void OnItemRangeMoved(int fromPosition, int toPosition, int itemCount)
	{
		this.ItemRangeMoved?.Invoke(_adapter, new ItemRangeMovedEventArgs
		{
			FromPosition = fromPosition,
			ToPosition = toPosition,
			ItemCount = itemCount
		});
	}

	public override void OnItemRangeRemoved(int positionStart, int itemCount)
	{
		this.ItemRangeRemoved?.Invoke(_adapter, new ItemRangeRemovedEventArgs
		{
			PositionStart = positionStart,
			ItemCount = itemCount
		});
	}
}
