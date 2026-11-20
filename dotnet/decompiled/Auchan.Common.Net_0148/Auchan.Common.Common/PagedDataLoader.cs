using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Common;

public class PagedDataLoader<T> : ElementViewModel, IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
{
	private Func<int, int, Task<Result<(IReadOnlyList<T>, int), DomainError>>> _loadFunc;

	private readonly List<T> _items = new List<T>();

	private int _totalCount;

	private int _offset;

	public int Count => _items.Count;

	public bool HasItems => Count > 0;

	public bool IsLoading
	{
		[CompilerGenerated]
		get
		{
			return _003CIsLoading_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsLoading_003Ek__BackingField != value)
			{
				_003CIsLoading_003Ek__BackingField = value;
				RaisePropertyChanged("IsLoading");
			}
		}
	}

	public bool HasErrors
	{
		[CompilerGenerated]
		get
		{
			return _003CHasErrors_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CHasErrors_003Ek__BackingField != value)
			{
				_003CHasErrors_003Ek__BackingField = value;
				RaisePropertyChanged("HasErrors");
			}
		}
	}

	public int ItemsPerPage
	{
		[CompilerGenerated]
		get
		{
			return _003CItemsPerPage_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CItemsPerPage_003Ek__BackingField != value)
			{
				_003CItemsPerPage_003Ek__BackingField = value;
				RaisePropertyChanged("ItemsPerPage");
			}
		}
	} = 10;

	public int FetchThreshold
	{
		[CompilerGenerated]
		get
		{
			return _003CFetchThreshold_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CFetchThreshold_003Ek__BackingField != value)
			{
				_003CFetchThreshold_003Ek__BackingField = value;
				RaisePropertyChanged("FetchThreshold");
			}
		}
	} = 4;

	public T this[int index] => ItemAt(index);

	public event Action<DomainError?>? Loaded;

	public PagedDataLoader(Func<int, int, Task<Result<(IReadOnlyList<T>, int), DomainError>>> loadFunc)
	{
		_loadFunc = loadFunc;
	}

	public T ItemAt(int index)
	{
		return _items[index];
	}

	public void LoadMore()
	{
		if (!IsLoading && !HasErrors && Count < _totalCount)
		{
			LoadNext(ItemsPerPage, clearPrevious: false).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void Remove(T item)
	{
		_items.Remove(item);
		RaisePropertyChanged("Count");
	}

	public async Task<Result<(IReadOnlyList<T>, int), DomainError>> LoadFirst()
	{
		_offset = 0;
		return await LoadNext(ItemsPerPage, clearPrevious: true);
	}

	public async Task<Result<(IReadOnlyList<T>, int), DomainError>> Reload()
	{
		_offset = 0;
		int limit = Math.Max(_items.Count, ItemsPerPage);
		return await LoadNext(limit, clearPrevious: true);
	}

	public void Clear()
	{
		_items.Clear();
		_offset = 0;
		_totalCount = 0;
	}

	private async Task<Result<(IReadOnlyList<T>, int), DomainError>> LoadNext(int limit, bool clearPrevious)
	{
		IsLoading = true;
		Result<(IReadOnlyList<T>, int), DomainError> result = await _loadFunc(_offset, limit);
		if (clearPrevious)
		{
			_items.Clear();
		}
		DomainError obj = null;
		if (result.IsSuccess)
		{
			var (readOnlyList, totalCount) = result.Value;
			_items.AddRange(readOnlyList);
			_totalCount = totalCount;
			_offset += readOnlyList.Count;
		}
		else
		{
			obj = result.Error;
			HasErrors = true;
		}
		IsLoading = false;
		RaisePropertyChanged("Count");
		this.Loaded?.Invoke(obj);
		return result;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _items.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _items.GetEnumerator();
	}
}
