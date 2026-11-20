using System.ComponentModel;

namespace Auchan.Common.Base;

public interface ISelectionItemViewModel : IBindable, INotifyPropertyChanged
{
	bool Selected { get; set; }
}
public interface ISelectionItemViewModel<TItem> : IBindable, INotifyPropertyChanged, ISelectionItemViewModel
{
	TItem Item { get; }
}
public interface ISelectionItemViewModel<TItem, TParent> : ISelectionItemViewModel<TItem>, IBindable, INotifyPropertyChanged, ISelectionItemViewModel
{
	TParent Parent { get; }
}
