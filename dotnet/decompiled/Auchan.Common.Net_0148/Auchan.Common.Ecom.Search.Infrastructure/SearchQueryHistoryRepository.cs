using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Cache;
using Auchan.Common.Extensions;

namespace Auchan.Common.Ecom.Search.Infrastructure;

public class SearchQueryHistoryRepository
{
	private const int SEARCH_HISTORY_ENTRIES_MAX = 20;

	private const string CacheKey = "Search_query_history";

	private readonly ICache _cache;

	private ObservableRangeCollection<string> _queryHistory;

	public SearchQueryHistoryRepository(ICache cache)
	{
		_queryHistory = new ObservableRangeCollection<string>();
		_cache = cache;
	}

	public Task AddSearchQueryEntry(string entry)
	{
		while (_queryHistory.Count >= 20)
		{
			_queryHistory.RemoveAt(_queryHistory.Count - 1);
		}
		int num = _queryHistory.IndexOfIgnoreCase(entry);
		if (num >= 0)
		{
			if (_queryHistory.Count > 1)
			{
				_queryHistory.Move(num, 0);
			}
		}
		else
		{
			_queryHistory.Insert(0, entry);
		}
		return SaveToCache();
	}

	public async Task<ObservableRangeCollection<string>> GetSearchQueryHistory()
	{
		if (_queryHistory.Count == 0)
		{
			await TryLoadFromCache();
		}
		return _queryHistory;
	}

	public Task RemoveSearchHistoryItem(string entry)
	{
		_queryHistory.Remove(entry);
		return SaveToCache();
	}

	public Task ClearSearchHistory()
	{
		_queryHistory.Clear();
		return ClearCache();
	}

	private async Task TryLoadFromCache()
	{
		List<string> list = await _cache.Get("Search_query_history", new List<string>());
		if (list.Any())
		{
			_queryHistory.ReplaceRange(list);
		}
	}

	private Task SaveToCache()
	{
		return _cache.Save("Search_query_history", _queryHistory);
	}

	private Task ClearCache()
	{
		return _cache.Remove("Search_query_history");
	}
}
