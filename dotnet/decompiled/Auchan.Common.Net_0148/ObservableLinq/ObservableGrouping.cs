using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Net;

namespace ObservableLinq;

public class ObservableGrouping<TKey, TElement> : ObservableRangeCollection<TElement>, IObservableGrouping<TKey, TElement>, IGrouping<TKey, TElement>, IEnumerable<TElement>, IEnumerable, IReadOnlyList<TElement>, IReadOnlyCollection<TElement>, INotifyCollectionChanged, INotifyPropertyChanged
{
	public TKey Key { get; }

	internal int StartIndex
	{
		[CompilerGenerated]
		get
		{
			return _003CStartIndex_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CStartIndex_003Ek__BackingField != value)
			{
				_003CStartIndex_003Ek__BackingField = value;
				((ObservableRangeCollection<_003F>)(object)this).OnPropertyChanged(_003C_003EPropertyChangedEventArgs.StartIndex);
			}
		}
	}

	public ObservableGrouping(TKey key)
	{
		Key = key;
	}

	public ObservableGrouping(IGrouping<TKey, TElement> grouping)
		: this(grouping.Key, (IEnumerable<TElement>)grouping)
	{
	}

	public ObservableGrouping(TKey key, IEnumerable<TElement> collection)
		: base(collection)
	{
		Key = key;
	}

	public ObservableGrouping(TKey key, List<TElement> list)
		: base(list)
	{
		Key = key;
	}
}
