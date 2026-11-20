using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auchan.Common.Base.PopupQueue;

public abstract class AbstractPopupQueue<TItem>
{
	protected Queue<TItem> Queue { get; set; } = new Queue<TItem>();

	protected bool IsShowing { get; set; }

	protected virtual bool CanShow => true;

	public event Action? QueueDrained;

	public void RaiseQueue()
	{
		if (!CanShow || IsShowing)
		{
			return;
		}
		if (Queue.Count > 0)
		{
			TItem item = Queue.Peek();
			if (CanShowItem(item))
			{
				OnPopupRequested(Queue.Dequeue());
			}
		}
		else
		{
			this.QueueDrained?.Invoke();
		}
	}

	protected void Enqueue(TItem item)
	{
		Queue.Enqueue(item);
		RaiseQueue();
	}

	protected void RemoveFromQueue(TItem item)
	{
		Queue = new Queue<TItem>(Queue.ToList().Where(delegate(TItem x)
		{
			ref TItem reference = ref x;
			TItem val = default(TItem);
			if (val == null)
			{
				val = reference;
				reference = ref val;
				if (val == null)
				{
					return true;
				}
			}
			object obj = item;
			return !reference.Equals(obj);
		}));
	}

	protected bool Contains(TItem item)
	{
		return Queue.Contains(item);
	}

	protected async Task RunAction(Func<Task> action)
	{
		IsShowing = true;
		try
		{
			await action();
		}
		finally
		{
			IsShowing = false;
			RaiseQueue();
		}
	}

	protected virtual bool CanShowItem(TItem item)
	{
		return true;
	}

	protected abstract void OnPopupRequested(TItem item);
}
