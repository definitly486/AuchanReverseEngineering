using System;
using AndroidX.RecyclerView.Widget;
using Java.Lang;
using ViewSparsedRecycler;

namespace Auchan.Android.Controls;

internal class SectionedGridDataObserver : RecyclerView.AdapterDataObserver
{
	public event EventHandler? Changed;

	public event EventHandler<EventAdapterDataObserver.ItemRangeChangedEventArgs>? ItemRangeChanged;

	public event EventHandler<EventAdapterDataObserver.ItemRangeInsertedEventArgs>? ItemRangeInserted;

	public event EventHandler<EventAdapterDataObserver.ItemRangeMovedEventArgs>? ItemRangeMoved;

	public event EventHandler<EventAdapterDataObserver.ItemRangeRemovedEventArgs>? ItemRangeRemoved;

	public override void OnChanged()
	{
		this.Changed?.Invoke(this, EventArgs.Empty);
	}

	public override void OnItemRangeChanged(int positionStart, int itemCount)
	{
		this.ItemRangeChanged?.Invoke(this, new EventAdapterDataObserver.ItemRangeChangedEventArgs
		{
			PositionStart = positionStart,
			ItemCount = itemCount
		});
	}

	public override void OnItemRangeChanged(int positionStart, int itemCount, Java.Lang.Object payload)
	{
		this.ItemRangeChanged?.Invoke(this, new EventAdapterDataObserver.ItemRangeChangedEventArgs
		{
			PositionStart = positionStart,
			ItemCount = itemCount,
			Payload = payload
		});
	}

	public override void OnItemRangeInserted(int positionStart, int itemCount)
	{
		this.ItemRangeInserted?.Invoke(this, new EventAdapterDataObserver.ItemRangeInsertedEventArgs
		{
			PositionStart = positionStart,
			ItemCount = itemCount
		});
	}

	public override void OnItemRangeMoved(int fromPosition, int toPosition, int itemCount)
	{
		this.ItemRangeMoved?.Invoke(this, new EventAdapterDataObserver.ItemRangeMovedEventArgs
		{
			FromPosition = fromPosition,
			ToPosition = toPosition,
			ItemCount = itemCount
		});
	}

	public override void OnItemRangeRemoved(int positionStart, int itemCount)
	{
		this.ItemRangeRemoved?.Invoke(this, new EventAdapterDataObserver.ItemRangeRemovedEventArgs
		{
			PositionStart = positionStart,
			ItemCount = itemCount
		});
	}
}
