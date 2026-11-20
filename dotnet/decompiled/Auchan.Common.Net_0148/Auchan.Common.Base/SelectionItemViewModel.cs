using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Base;

public class SelectionItemViewModel<T> : BaseItemViewModel, ISelectionItemViewModel<T>, IBindable, INotifyPropertyChanged, ISelectionItemViewModel
{
	public T Item { get; }

	public bool Selected
	{
		[CompilerGenerated]
		get
		{
			return _003CSelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CSelected_003Ek__BackingField != value)
			{
				_003CSelected_003Ek__BackingField = value;
				RaisePropertyChanged("Selected");
			}
		}
	}

	public SelectionItemViewModel(T item, bool selected)
	{
		Item = item;
		Selected = selected;
	}
}
public class SelectionItemViewModel<TItem, TParent> : SelectionItemViewModel<TItem>, ISelectionItemViewModel<TItem, TParent>, ISelectionItemViewModel<TItem>, IBindable, INotifyPropertyChanged, ISelectionItemViewModel
{
	public TParent Parent { get; }

	public SelectionItemViewModel(TItem item, TParent parent, bool selected)
		: base(item, selected)
	{
		Parent = parent;
	}
}
