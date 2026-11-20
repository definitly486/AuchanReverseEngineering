using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace ObservableLinq;

public interface IObservableGrouping<out TKey, out TElement> : IGrouping<TKey, TElement>, IEnumerable<TElement>, IEnumerable, IReadOnlyList<TElement>, IReadOnlyCollection<TElement>, INotifyCollectionChanged, INotifyPropertyChanged
{
}
