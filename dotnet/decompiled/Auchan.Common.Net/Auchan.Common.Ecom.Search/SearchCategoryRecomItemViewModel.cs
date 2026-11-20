using Auchan.Common.Base;
using Auchan.Common.Ecom.Search.Models;

namespace Auchan.Common.Ecom.Search;

public sealed class SearchCategoryRecomItemViewModel : ElementViewModel
{
	private readonly SearchAutohintsResult _hintResult;

	private readonly SearchAutohintCategory _category;

	private readonly string _searchQuery;

	public string Title
	{
		get
		{
			if (!string.IsNullOrEmpty(_hintResult.Correction))
			{
				return _hintResult.Correction;
			}
			if (!string.IsNullOrEmpty(_hintResult.Query))
			{
				return _hintResult.Query;
			}
			return _searchQuery;
		}
	}

	public string Description => "В категории " + _category.Name;

	public string Code => _category.Code;

	public SearchCategoryRecomItemViewModel(SearchAutohintsResult hintResult, string searchQuery, SearchAutohintCategory category)
	{
		_hintResult = hintResult;
		_searchQuery = searchQuery;
		_category = category;
	}
}
