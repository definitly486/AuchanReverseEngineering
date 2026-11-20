namespace System.Collections.Specialized;

public class NotifyCollectionChangedEventArgs : EventArgs
{
	private readonly NotifyCollectionChangedAction _action;

	private readonly IList _newItems;

	private readonly IList _oldItems;

	private readonly int _newStartingIndex = -1;

	private readonly int _oldStartingIndex = -1;

	public NotifyCollectionChangedAction Action => _action;

	public IList? NewItems => _newItems;

	public IList? OldItems => _oldItems;

	public int NewStartingIndex => _newStartingIndex;

	public int OldStartingIndex => _oldStartingIndex;

	public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action)
	{
		if (action != NotifyCollectionChangedAction.Reset)
		{
			throw new ArgumentException(System.SR.Format("WrongActionForCtor", NotifyCollectionChangedAction.Reset), "action");
		}
		_action = action;
	}

	public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object? changedItem, int index)
	{
		switch (action)
		{
		case NotifyCollectionChangedAction.Reset:
			if (changedItem != null)
			{
				throw new ArgumentException("ResetActionRequiresNullItem", "action");
			}
			if (index != -1)
			{
				throw new ArgumentException("ResetActionRequiresIndexMinus1", "action");
			}
			break;
		case NotifyCollectionChangedAction.Add:
			_newItems = new SingleItemReadOnlyList(changedItem);
			_newStartingIndex = index;
			break;
		case NotifyCollectionChangedAction.Remove:
			_oldItems = new SingleItemReadOnlyList(changedItem);
			_oldStartingIndex = index;
			break;
		default:
			throw new ArgumentException("MustBeResetAddOrRemoveActionForCtor", "action");
		}
		_action = action;
	}

	public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList? changedItems, int startingIndex)
	{
		switch (action)
		{
		case NotifyCollectionChangedAction.Reset:
			if (changedItems != null)
			{
				throw new ArgumentException("ResetActionRequiresNullItem", "action");
			}
			if (startingIndex != -1)
			{
				throw new ArgumentException("ResetActionRequiresIndexMinus1", "action");
			}
			break;
		case NotifyCollectionChangedAction.Add:
		case NotifyCollectionChangedAction.Remove:
			ArgumentNullException.ThrowIfNull(changedItems, "changedItems");
			ArgumentOutOfRangeException.ThrowIfLessThan(startingIndex, -1, "startingIndex");
			if (action == NotifyCollectionChangedAction.Add)
			{
				_newItems = new ReadOnlyList(changedItems);
				_newStartingIndex = startingIndex;
			}
			else
			{
				_oldItems = new ReadOnlyList(changedItems);
				_oldStartingIndex = startingIndex;
			}
			break;
		default:
			throw new ArgumentException("MustBeResetAddOrRemoveActionForCtor", "action");
		}
		_action = action;
	}

	public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object? newItem, object? oldItem, int index)
	{
		if (action != NotifyCollectionChangedAction.Replace)
		{
			throw new ArgumentException(System.SR.Format("WrongActionForCtor", NotifyCollectionChangedAction.Replace), "action");
		}
		_action = action;
		_newItems = new SingleItemReadOnlyList(newItem);
		_oldItems = new SingleItemReadOnlyList(oldItem);
		_newStartingIndex = (_oldStartingIndex = index);
	}

	public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems, int startingIndex)
	{
		if (action != NotifyCollectionChangedAction.Replace)
		{
			throw new ArgumentException(System.SR.Format("WrongActionForCtor", NotifyCollectionChangedAction.Replace), "action");
		}
		ArgumentNullException.ThrowIfNull(newItems, "newItems");
		ArgumentNullException.ThrowIfNull(oldItems, "oldItems");
		_action = action;
		_newItems = new ReadOnlyList(newItems);
		_oldItems = new ReadOnlyList(oldItems);
		_newStartingIndex = (_oldStartingIndex = startingIndex);
	}

	public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object? changedItem, int index, int oldIndex)
	{
		if (action != NotifyCollectionChangedAction.Move)
		{
			throw new ArgumentException(System.SR.Format("WrongActionForCtor", NotifyCollectionChangedAction.Move), "action");
		}
		ArgumentOutOfRangeException.ThrowIfNegative(index, "index");
		_action = action;
		_newItems = (_oldItems = new SingleItemReadOnlyList(changedItem));
		_newStartingIndex = index;
		_oldStartingIndex = oldIndex;
	}

	public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList? changedItems, int index, int oldIndex)
	{
		if (action != NotifyCollectionChangedAction.Move)
		{
			throw new ArgumentException(System.SR.Format("WrongActionForCtor", NotifyCollectionChangedAction.Move), "action");
		}
		ArgumentOutOfRangeException.ThrowIfNegative(index, "index");
		_action = action;
		_newItems = (_oldItems = ((changedItems != null) ? new ReadOnlyList(changedItems) : null));
		_newStartingIndex = index;
		_oldStartingIndex = oldIndex;
	}
}
